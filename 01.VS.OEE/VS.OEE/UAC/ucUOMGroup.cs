using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Commons;
using System.Reflection;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using DevExpress.Utils;

namespace VS.OEE
{
    public partial class ucUOMGroup : DevExpress.XtraEditors.XtraForm
    {

        Int64 ithem = 0;
        string sBT = "TMPGroupDetails" + Commons.Modules.UserName;
        public ucUOMGroup()
        {
            InitializeComponent();
        }
        #region eventForm
        private void ucUOMGroup_Load(object sender, EventArgs e)
        {
            if (Modules.iPermission != 1)
            {
                this.btnThem.Visible = false;
                this.btnSua.Visible = false;
                this.btnXoa.Visible = false;
                this.btnGhi.Visible = false;
                this.btnKhong.Visible = false;
            }
            else
            {
                VisibleButon(true);
            }
            Commons.Modules.ObjSystems.MLoadLookUpEditTab(cboBasedUOM, Commons.Modules.ObjSystems.DataUOM(false), "ID", "UOMName", this.Name);
            LoadgrdGroup(-1);
            if (grvGroup.RowCount == 0)
            {
                LoadgrdGroupDetails();
            }
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            VisibleButon(false);
            ithem = -1;
            LoadgrdGroupDetails();
            BingdingControl(true);
            cboBasedUOM.EditValue = Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 ID FROM dbo.UOM WHERE BasedUOM = 1"));
            txtGroupName.Focus();
            Commons.Modules.ObjSystems.AddnewRow(grvGroupDetails, true);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvGroup.GetFocusedRowCellValue("ID") == null || grvGroup.GetFocusedRowCellValue("ID").ToString() == "")
            {
                Modules.msgThayThe(ThongBao.msgBanChuaChonDuLieu, lblNote.Text);
                return;
            }
            VisibleButon(false);
            ithem = Convert.ToInt64(grvGroup.GetFocusedRowCellValue("ID"));
            Commons.Modules.ObjSystems.AddnewRow(grvGroupDetails, true);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvGroup.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvGroup.GetFocusedRowCellValue("ID").ToString()); } catch { }
            if (iId == -1)
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, lblNote.Text);
                return;
            }
            if (grvGroupDetails.RowCount == 0)
            {
                DeleteData();
            }
            else
            {
                DeleteDetail();
            }
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            #region Kiem du lieu
            if (txtGroupName.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblGroupName.Text, txtGroupName);
                return ;
            }
            object rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.UOMConversionGroup WHERE GroupName ='"+ txtGroupName.Text.Trim() + "'  "+ (ithem == -1 ? "" : "AND ID <> "+ ithem +"") +"  ");
            if (rs != null && (Int32)rs > 0)
            {
                Modules.msgThayThe(ThongBao.msgDaTonTai, lblGroupName.Text, txtGroupName);
                return ;
            }
            #endregion
            if (grvGroupDetails.HasColumnErrors) return;
            grvGroupDetails.PostEditor();
            grvGroupDetails.UpdateCurrentRow();
            SaveGroupDetails();
            Commons.Modules.ObjSystems.DeleteAddRow(grvGroupDetails);
            VisibleButon(true);
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            Validate();
            Commons.Modules.ObjSystems.DeleteAddRow(grvGroupDetails);
            VisibleButon(true);
            grvGroup_FocusedRowChanged(null, null);
        }
        private void grvGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ithem = 0;
            LoadgrdGroupDetails();
            BingdingControl(false);
        }
        #endregion

        #region function 
        private void VisibleButon(bool flag)
        {
            btnThem.Visible = flag;
            btnThoat.Visible = flag;
            btnXoa.Visible = flag;
            btnSua.Visible = flag;
            btnGhi.Visible = !flag;
            btnKhong.Visible = !flag;
            ReadonlyControl(flag);
            grdGroup.Enabled = flag;
        }
        private void BingdingControl(bool them)
        {
            if (them == true)
            {
                txtGroupName.ResetText();
                txtGroupNameA.ResetText();
                txtGroupNameH.ResetText();
                txtNote.ResetText();
            }
            else
            {
                try
                {
                    txtGroupName.EditValue = grvGroup.GetFocusedRowCellValue("GroupName");
                    txtGroupNameA.EditValue = grvGroup.GetFocusedRowCellValue("GroupNameA");
                    txtGroupNameH.EditValue = grvGroup.GetFocusedRowCellValue("GroupNameH");
                    cboBasedUOM.EditValue = Convert.ToInt64(grvGroup.GetFocusedRowCellValue("BasedUOMID"));
                    txtNote.EditValue = grvGroup.GetFocusedRowCellValue("Note");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ReadonlyControl(bool flag)
        {
            txtGroupName.Properties.ReadOnly = flag;
            txtGroupNameA.Properties.ReadOnly = flag;
            txtGroupNameH.Properties.ReadOnly = flag;
            txtNote.Properties.ReadOnly = flag;
            cboBasedUOM.Properties.ReadOnly = flag;
        }
        private void LoadgrdGroup(Int64 id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID, GroupName,GroupNameA,GroupNameH, BasedUOMID, Note FROM dbo.UOMConversionGroup"));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
                if (grdGroup.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdGroup, grvGroup, dt, false, true, true, false, true, this.Name);
                }
                else
                    grdGroup.DataSource = dt;
                if (id != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvGroup.FocusedRowHandle = grvGroup.GetRowHandle(index);
                }
                else {/* LoadText(false);*/ }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadgrdGroupDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT A.ID, A.UOMConversionGroupID,A.UOMQuantity, A.UOMID, A.BasedUOMQuantity,B.BasedUOMID,A.Note,  ISNULL(A.CapacityUOM,0) As CapacityUOM FROM dbo.UOMConversionGroupDetails A INNER JOIN dbo.UOMConversionGroup B ON B.ID = A.UOMConversionGroupID WHERE A.UOMConversionGroupID = " + (ithem == 0 ? Convert.ToInt64(grvGroup.GetFocusedRowCellValue("ID")) : ithem) + ""));
                dt.Columns["CapacityUOM"].ReadOnly = false;
                if (grdGroupDetails.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdGroupDetails, grvGroupDetails, dt, false, true, true, false, true, this.Name);
                    Commons.Modules.ObjSystems.AddCombXtra("ID", "UOMName", "UOMID", grvGroupDetails, Commons.Modules.ObjSystems.DataUOM(true), false,this.Name);
                    Commons.Modules.ObjSystems.AddCombXtra("ID", "UOMName", "BasedUOMID", grvGroupDetails, Commons.Modules.ObjSystems.DataUOM(false), false,this.Name);
                    grvGroupDetails.Columns["UOMQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvGroupDetails.Columns["UOMQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLe4;
                    grvGroupDetails.Columns["BasedUOMQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvGroupDetails.Columns["BasedUOMQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLe4;
                }
                else
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dt.Columns[i].ReadOnly = false;
                    }
                    grdGroupDetails.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveGroupDetails()
        {
            //tạo bảng tạm
            try
            {
                Commons.Modules.ObjSystems.XoaTable(sBT);
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, Commons.Modules.ObjSystems.ConvertDatatable(grdGroupDetails), "");
                LoadgrdGroup(Convert.ToInt64(
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditGroupDetails", ithem, txtGroupName.EditValue, txtGroupNameA.EditValue, txtGroupNameH.EditValue, cboBasedUOM.EditValue, txtNote.EditValue, sBT)));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteData()
        {
            int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.Item WHERE UOMConverionGroupID  = " + (grvGroup.GetFocusedRowCellValue("ID")) + " "));
            if (n != 0)
            {
                Commons.Modules.msgChung("msgDuLieuDaPhatSinh");
                return;
            }

            if (Modules.msgHoiThayThe(ThongBao.msgXoa, lblGroupName.Text) == DialogResult.No) return;
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.UOMConversionGroupDetails WHERE UOMConversionGroupID =" + Convert.ToInt64(grvGroup.GetFocusedRowCellValue("ID")) + " DELETE	dbo.UOMConversionGroup WHERE ID = " + Convert.ToInt64(grvGroup.GetFocusedRowCellValue("ID")) + "");
                grvGroup.DeleteSelectedRows();
                grvGroup_FocusedRowChanged(null, null);
            }
            catch (Exception )
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }

        private void DeleteDetail()
        {
            try
            {
                //kiểm tra máy trong item của pro duction
                int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, " SELECT COUNT(*) FROM dbo.Item WHERE UOM = " + Convert.ToInt64((grvGroupDetails.GetFocusedRowCellValue("ID")) + "")));
                if (n != 0)
                {
                    Commons.Modules.msgChung("msgDuLieuDaPhatSinh");
                    return;
                }
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, "Hệ quy đổi này") == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE FROM dbo.UOMConversionGroupDetails WHERE UOMConversionGroupID = " + Convert.ToInt64(grvGroup.GetFocusedRowCellValue("ID")) + " AND UOMID =" + Convert.ToInt64((grvGroupDetails.GetFocusedRowCellValue("UOMID")) + ""));
                grvGroupDetails.DeleteSelectedRows();
            }
            catch (Exception )
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh); 
            }
        }
        #endregion

        private void grdGroupDetails_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteDetail();
            }
        }
        private void grdGroup_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteData();
            }
        }
        private void grvGroupDetails_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                view.SetFocusedRowCellValue(view.Columns["UOMConversionGroupID"], Convert.ToInt64(grvGroup.GetFocusedRowCellValue("ID")));
                view.SetFocusedRowCellValue(view.Columns["BasedUOMID"], Convert.ToInt64(cboBasedUOM.EditValue));
                view.SetFocusedRowCellValue(view.Columns["CapacityUOM"], Convert.ToBoolean(false));
                view.Columns["BasedUOMID"].OptionsColumn.ReadOnly = true;
            }
            catch
            {
            }
        }
        private void grvGroupDetails_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            grvGroupDetails.ClearColumnErrors();
            GridView view = sender as GridView;
            if (view == null) return;
            if (view.FocusedColumn.Name == "colUOMID")
            {
                DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grdGroupDetails);
                if (dt.Rows.Count == 0) return;
                if (dt.AsEnumerable().Count(x => x.Field<Int64>("UOMID").Equals(e.Value)) > 0)
                {
                    e.Valid = false;
                    e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "erTrungDuLieu");
                    view.SetColumnError(view.Columns["UOMID"], e.ErrorText);
                    return;
                }   
            }
            if (view.FocusedColumn.Name == "colCapacityUOM" && Convert.ToBoolean(e.Value) == true)
            {
                view.SetFocusedRowCellValue("CapacityUOM", true); 
                DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grvGroupDetails);
                if (dt.Rows.Count == 0) return;
                if (dt.AsEnumerable().Count(x => x.Field<Boolean>("CapacityUOM").Equals(true)) > 1)
                {
                    view.SetFocusedRowCellValue("CapacityUOM", false);
                }
            }
        }
        private void cboBasedUOM_MouseHover(object sender, EventArgs e)
        {
            if (btnGhi.Visible == false) return;
            DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grvGroupDetails);
            if (dt.Rows.Count == 0)
            {
                cboBasedUOM.Properties.ReadOnly = false;
            }
            else
            {
                cboBasedUOM.Properties.ReadOnly = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grvGroupDetails_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvGroupDetails_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }



        private void grvGroupDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //kiểm tra null
            DevExpress.XtraGrid.Views.Grid.GridView View = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            DevExpress.XtraGrid.Columns.GridColumn sUOM = View.Columns["UOMID"];
            if (Commons.Modules.ObjSystems.IsnullorEmpty(View.GetRowCellValue(e.RowHandle, sUOM)))
            {
                e.Valid = false;
                View.SetColumnError(sUOM, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtraUOMNULL", Commons.Modules.TypeLanguage)); return;
            }

            DevExpress.XtraGrid.Columns.GridColumn sUOMQuantity = View.Columns["UOMQuantity"];
            if (Commons.Modules.ObjSystems.IsnullorEmpty(View.GetRowCellValue(e.RowHandle, sUOMQuantity)))
            {
                e.Valid = false;
                View.SetColumnError(sUOMQuantity, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtraUOMNULL", Commons.Modules.TypeLanguage)); return;
            }

            DevExpress.XtraGrid.Columns.GridColumn sBasedUOMQuantity = View.Columns["BasedUOMQuantity"];
            if (Commons.Modules.ObjSystems.IsnullorEmpty(View.GetRowCellValue(e.RowHandle, sBasedUOMQuantity)))
            {
                e.Valid = false;
                View.SetColumnError(sBasedUOMQuantity, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtraUOMNULL", Commons.Modules.TypeLanguage)); return;
            }
        }
    }
}