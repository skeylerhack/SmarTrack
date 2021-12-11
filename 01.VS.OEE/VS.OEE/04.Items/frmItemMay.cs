using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Commons;
using System.Reflection;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using DevExpress.Utils;

namespace VS.OEE
{
    public partial class frmItemMay : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        Int64 ithem = 0;
        string sBT = "TMPItemMay" + Commons.Modules.UserName;
        public frmItemMay(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        #region eventForm
        private void frmItemMay_Load(object sender, EventArgs e)
        {
            if (iPQ != 1)
            {
                this.btnThem.Visible = false;
                this.btnSua.Visible = false;
                this.btnXoa.Visible = false;
                this.btnChooseMay.Visible = false;
                this.btnGhi.Visible = false;
                this.btnKhong.Visible = false;
            }
            else
            {
                VisibleButon(true);
            }
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboItemGroup, Commons.Modules.ObjSystems.DataItemGroup(false), "ID", "ItemGroupName", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "ItemGroupName"));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboUOMGroupID, Commons.Modules.ObjSystems.DataUOMConversionGroup(false), "ID", "GroupName", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "GroupName"));
       
            LoadgrdItem(-1);
            if (grvItem.RowCount == 0)
            {
                LoadgrdItemMay(-1,null);
            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            VisibleButon(false);
            ithem = -1;
            LoadgrdItemMay(-1, null);
            BingdingControl(true);
            txtItemCode.Focus();
            Commons.Modules.ObjSystems.AddnewRow(grvItemMay, true);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvItem.GetFocusedRowCellValue("ID") == null || grvItem.GetFocusedRowCellValue("ID").ToString() == "")
            {
                Modules.msgThayThe(ThongBao.msgBanChuaChonDuLieu, lblItemName.Text);
                return;
            }
            VisibleButon(false);
            ithem = Convert.ToInt64(grvItem.GetFocusedRowCellValue("ID"));
            Commons.Modules.ObjSystems.AddnewRow(grvItemMay, true);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvItem.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvItem.GetFocusedRowCellValue("ID").ToString()); } catch { }
            if (iId == -1)
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, lblItemName.Text);
                return;
            }
            if (grvItemMay.RowCount == 0)
            {
                DeleteData();
            }
            else
            {
                DeleteDatadetails();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu
            #region Kiem du lieu của mã item 
            if (txtItemCode.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblItemCode.Text, txtItemCode);
                return;
            }
            if (cboBasedUOM.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong,lblBasedUOM.Text, cboBasedUOM);
                return;
            }
            if (txtItemName.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblItemName.Text, txtItemName);
                return;
            }
            if (cboItemGroup.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblItemGroup.Text, cboItemGroup);
                return;
            }
            object rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.Item WHERE ItemCode ='" + txtItemCode.Text.Trim() + "'  " + (ithem == -1 ? "" : "AND ID <> " + ithem + "") + "  ");
            if (rs != null && (Int32)rs > 0)
            {
                Modules.msgThayThe(ThongBao.msgDaTonTai, txtItemCode.Text, txtItemCode);
                return;
            }
            #endregion
            #region Kiem du lieu của ten item 
            if (txtItemName.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, txtItemName.Text, txtItemName);
                return;
            }
            rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.Item WHERE ItemName ='" + txtItemName.Text.Trim() + "'  " + (ithem == -1 ? "" : "AND ID <> " + ithem + "") + "  ");
            if (rs != null && (Int32)rs > 0)
            {
                Modules.msgThayThe(ThongBao.msgDaTonTai, txtItemName.Text, txtItemName);
                return;
            }
            if (cboItemGroup.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, cboItemGroup.Text, cboItemGroup);
                return;
            }
            if (cboUOMGroupID.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, cboUOMGroupID.Text, cboUOMGroupID);
                return;
            }
            #endregion
            grvItemMay.PostEditor();
            grvItemMay.UpdateCurrentRow();
            SaveItemMay();
            Commons.Modules.ObjSystems.DeleteAddRow(grvItemMay);
            VisibleButon(true);
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.DeleteAddRow(grvItemMay);
            VisibleButon(true);
            grvProDuctOD_FocusedRowChanged(null, null);

        }
        private void btnChooseMay_Click(object sender, EventArgs e)
        {
            frmChooseDevice device = new frmChooseDevice();
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, device.sBTChon, Commons.Modules.ObjSystems.ConvertDatatable(grdItemMay), "");
            if (device.ShowDialog() == DialogResult.OK)
            {
                //load lại item máy
                LoadgrdItemMay(Convert.ToInt64(grvItem.GetFocusedRowCellValue("ID")),device.TabMayItem);
            }
        }
        private void grvProDuctOD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadgrdItemMay(Convert.ToInt64(grvItem.GetFocusedRowCellValue("ID")), null);
            BingdingControl(false);
        }
        #endregion

        #region function 
        private void VisibleButon(bool flag)
        {
            btnThoat.Visible = flag;
            btnThem.Visible = flag;
            btnXoa.Visible = flag;
            btnSua.Visible = flag;
            btnGhi.Visible = !flag;
            btnKhong.Visible = !flag;
            btnChooseMay.Visible = !flag;
            ReadonlyControl(flag);
            grdItem.Enabled = flag;
        }
        private void BingdingControl(bool them)
        {
            if (them == true)
            {
                cboBasedUOM.EditValue = null;
                cboItemGroup.EditValue = null;
                cboUOMGroupID.EditValue = null;
                txtItemCode.ResetText();
                txtBarcode.ResetText();
                txtDescription.ResetText();
                txtItemName.ResetText();
                txtItemNameA.ResetText();
                txtItemNameH.ResetText();
                txtOtherName.ResetText();
            }
            else
            {
                txtItemCode.EditValue = grvItem.GetFocusedRowCellValue("ItemCode");
                txtBarcode.EditValue = grvItem.GetFocusedRowCellValue("Barcode");
                txtDescription.EditValue = grvItem.GetFocusedRowCellValue("Description");
                txtItemName.EditValue = grvItem.GetFocusedRowCellValue("ItemName");
                txtItemNameA.EditValue = grvItem.GetFocusedRowCellValue("ItemNameA");
                txtItemNameH.EditValue = grvItem.GetFocusedRowCellValue("ItemNameH");
                txtOtherName.EditValue = grvItem.GetFocusedRowCellValue("OtherName");
                cboBasedUOM.EditValue = Convert.ToInt64(grvItem.GetFocusedRowCellValue("UOM"));
                cboItemGroup.EditValue = Convert.ToInt64(grvItem.GetFocusedRowCellValue("IDItemGroup"));
                cboUOMGroupID.EditValue = Convert.ToInt64(grvItem.GetFocusedRowCellValue("UOMConverionGroupID"));
            }
        }
        private void ReadonlyControl(bool flag)
        {
            txtItemCode.Properties.ReadOnly = flag;
            txtBarcode.Properties.ReadOnly = flag;
            txtDescription.Properties.ReadOnly = flag;
            txtItemName.Properties.ReadOnly = flag;
            txtItemNameA.Properties.ReadOnly = flag;
            txtItemNameH.Properties.ReadOnly = flag;
            txtOtherName.Properties.ReadOnly = flag;
            cboBasedUOM.Properties.ReadOnly = flag;
            cboItemGroup.Properties.ReadOnly = flag;
            cboUOMGroupID.Properties.ReadOnly = flag;
        }
        private void LoadgrdItem(Int64 id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID, ItemCode, CASE "+Commons.Modules.TypeLanguage+" WHEN 0 THEN ItemName WHEN 1 THEN ISNULL(NULLIF(ItemNameA,''),ItemName) ELSE ISNULL(NULLIF(ItemNameH,''),ItemName) END AS ItemName,ItemNameA,ItemNameH, OtherName, Barcode, IDItemGroup, Description,UOMConverionGroupID, UOM FROM dbo.Item"));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
                if (grdItem.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdItem, grvItem, dt, false, true, false, false, true, this.Name);
                    grvItem.Columns["ItemCode"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvItem.Columns["ItemName"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                }
                else
                    grdItem.DataSource = dt;
                if (id != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvItem.FocusedRowHandle = grvItem.GetRowHandle(index);
                }
                else {/* LoadText(false);*/ }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadgrdItemMay(Int64 n, DataTable chooseDevice)
        {
            try
            {
                DataTable dt = new DataTable();
                if (chooseDevice == null)
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetItemMay", n, Commons.Modules.UserName, Commons.Modules.TypeLanguage, "NO"));
                }
                else
                {
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "BT" + Commons.Modules.UserName, chooseDevice, "");
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetItemMay", n, Commons.Modules.UserName, Commons.Modules.TypeLanguage, "BT" + Commons.Modules.UserName));
                }
                if (grdItemMay.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdItemMay, grvItemMay, dt, false, false,false, false, true, this.Name);
                    Commons.Modules.ObjSystems.AddCombXtra("MS_DVT_RT", "TEN_DVT_RT", "MS_DV_TG_Output", grvItemMay, Commons.Modules.ObjSystems.DataDonViTinhRunTime(), false, this.Name);
                    Commons.Modules.ObjSystems.AddCombXtra("MS_DVT_TD", "TEN_DVT_TD", "MS_DV_TG_Speed", grvItemMay, Commons.Modules.ObjSystems.DataDonViTinhTocDo(), false, this.Name);
                    Commons.Modules.ObjSystems.AddCombXtra("MS_MAY", "TEN_MAY", grvItemMay, "spGetMay",this.Name);
                    grvItemMay.Columns["StandardOutput"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvItemMay.Columns["StandardOutput"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    grvItemMay.Columns["StandardSpeed"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvItemMay.Columns["StandardSpeed"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    grvItemMay.Columns["TimeSendMgs"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvItemMay.Columns["TimeSendMgs"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    grvItemMay.Columns["NumberPerCyle"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvItemMay.Columns["NumberPerCyle"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    grvItemMay.Columns["DataCollectionCycle"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvItemMay.Columns["DataCollectionCycle"].DisplayFormat.FormatString = Commons.Modules.sSoLeSL;
                    grvItemMay.Columns["DownTimeRecord"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvItemMay.Columns["DownTimeRecord"].DisplayFormat.FormatString = Commons.Modules.sSoLeSL;
                    grvItemMay.Columns["WorkingCycle"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvItemMay.Columns["WorkingCycle"].DisplayFormat.FormatString = Commons.Modules.sSoLeSL;

                    grvItemMay.Columns["Consumption"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvItemMay.Columns["Consumption"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                }
                else
                {
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        dt.Columns[i].ReadOnly = false;
                    }
                    grdItemMay.DataSource = dt;
                }
                grvItemMay.Columns["DeviceID"].OptionsColumn.ReadOnly = true;
                grvItemMay.Columns["CapacityUOM"].OptionsColumn.ReadOnly = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveItemMay()
        {
            //tạo bảng tạm
            try
            {
                Commons.Modules.ObjSystems.XoaTable(sBT);
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, Commons.Modules.ObjSystems.ConvertDatatable(grdItemMay), "");
                LoadgrdItem(Convert.ToInt64(
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditItemMay", ithem, txtItemCode.EditValue, txtItemName.EditValue, txtItemNameA.EditValue, txtItemNameH.EditValue, txtOtherName.EditValue, txtBarcode.EditValue,
                            cboItemGroup.EditValue, txtDescription.EditValue, cboUOMGroupID.EditValue,
                            string.IsNullOrEmpty(cboBasedUOM.Text) ? 0 : cboBasedUOM.EditValue, sBT)));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteData()
        {
            // kiểm tra item không cho xóa khi có trong pro ductdetail theo itemid của prod

            int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.PrODetails WHERE ItemID  =  " + (grvItem.GetFocusedRowCellValue("ID")) + " "));
            if (n != 0)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
                return;
            }

            if (Modules.msgHoiThayThe(ThongBao.msgXoa, lblItemName.Text) == DialogResult.No) return;
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.ItemMay WHERE ItemID ='" + Convert.ToInt64(grvItem.GetFocusedRowCellValue("ID")) + "' DELETE dbo.Item WHERE ID = '" + Convert.ToInt64(grvItem.GetFocusedRowCellValue("ID")) + "'");
                grvItem.DeleteSelectedRows();
                grvProDuctOD_FocusedRowChanged(null, null);
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }
        #endregion

        private void grvItemMay_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view == null) return;
                if (e.Column.Name == "colMS_MAY")
                {
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT  ISNULL(StandardSpeed,0) AS StandardSpeed ,ISNULL(DataCollectionCycle,15) AS  DataCollectionCycle,ISNULL(WorkingCycle,0) AS  WorkingCycle,ISNULL(NumberPerCyle, 0) AS  NumberPerCyle, ISNULL(TimeSendMgs, 0) TimeSendMgs FROM dbo.MAY WHERE MS_MAY ='" + e.Value.ToString() + "'"));
                    if (dt.Rows.Count == 0) return;
                    view.SetFocusedRowCellValue(view.Columns["StandardSpeed"], dt.Rows[0]["StandardSpeed"]);
                    view.SetFocusedRowCellValue(view.Columns["DataCollectionCycle"], dt.Rows[0]["DataCollectionCycle"]);
                    view.SetFocusedRowCellValue(view.Columns["WorkingCycle"], dt.Rows[0]["WorkingCycle"]);
                    view.SetFocusedRowCellValue(view.Columns["NumberPerCyle"], dt.Rows[0]["NumberPerCyle"]);
                    view.SetFocusedRowCellValue(view.Columns["TimeSendMgs"], dt.Rows[0]["TimeSendMgs"]);
                    view.SetFocusedRowCellValue(view.Columns["DownTimeRecord"],1);
                }
            }
            catch
            {

            }
        }
        private void DeleteDatadetails()
        {
            try
            {
                //kiểm tra máy trong item của pro duction
                int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.ProductionOrder A INNER JOIN dbo.PrODetails B ON B.PROID = A.ID INNER JOIN dbo.ProSchedule C ON C.DetailsID = B.DetailsID WHERE B.ItemID = " + Convert.ToInt64(grvItem.GetFocusedRowCellValue("ID")) + " AND C.MS_MAY = '" + grvItemMay.GetFocusedRowCellValue("MS_MAY") + "'"));
                if (n != 0)
                {
                    Commons.Modules.msgChung("msgDuLieuDaPhatSinh");
                    return;
                }
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, "Device") == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.ItemMay WHERE MS_MAY ='" + (grvItemMay.GetFocusedRowCellValue("MS_MAY") + "'"));
                grvItemMay.DeleteSelectedRows();
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);

            }
        }
        private void grdItemMay_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteDatadetails();
            }
        }
        private void grdItem_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteData();
            }
        }
        private void cboBasedUOM_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            //DataRowView row = (DataRowView)cboBasedUOM.Properties.GetDataSourceRowByKeyValue(e.Value);
            //if (row != null)
            //{
            //    e.DisplayText = row["UOMQuantity"] + " " + row["UOMName"] + " = " + row["BasedUOMQuantity"] + " " + row["BasedUOMName"];
            //}
        }
        private void cboUOMGroupID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEditTab(cboBasedUOM, Commons.Modules.ObjSystems.DataUOMConversionGroupDetail(Convert.ToInt64(cboUOMGroupID.EditValue)), "ID", "UOMName", this.Name);
                if(grvItemMay.RowCount > 0)
                {
                    string sDVT = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT  [dbo].[fnGetDVTCongSuatByGroup](" + Convert.ToInt64(cboUOMGroupID.EditValue) + ")"));
                    for (int i = 0; i < grvItemMay.RowCount; i++)
                    {
                        grvItemMay.SetRowCellValue(i, "CapacityUOM", sDVT);
                    }
                }
            }
            catch
            {

            }
        }

        private void grvItemMay_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                view.SetFocusedRowCellValue(view.Columns["MS_DV_TG_Output"], 3);
                view.SetFocusedRowCellValue(view.Columns["MS_DV_TG_Speed"], 3);
                string sDVT = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT  [dbo].[fnGetDVTCongSuatByGroup](" + Convert.ToInt64(cboUOMGroupID.EditValue) + ")"));
                view.SetFocusedRowCellValue(view.Columns["CapacityUOM"], sDVT);
            }
            catch
            {
            }
        }

        private void grvItemMay_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            grvItemMay.ClearColumnErrors();
            GridView view = sender as GridView;
            if (view == null) return;
            if (view.FocusedColumn.Name == "colMS_MAY")
            {
                DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grdItemMay);
                if (dt.AsEnumerable().Count(x => x.Field<string>("MS_MAY").Equals(e.Value)) > 0)
                {
                    e.Valid = false;
                    e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "erTrungDuLieu");
                    view.SetColumnError(view.Columns["MS_MAY"], e.ErrorText);
                    return;
                }
                else
                {
                    view.SetFocusedRowCellValue(view.Columns["DeviceID"], e.Value);
                    view.SetFocusedRowCellValue(view.Columns["MS_MAY"], e.Value);
                }
            }
        }

        private void grvItemMay_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvItemMay_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvItemMay_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

        }
    }
}