using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;
using DevExpress.Utils;
using System.Web.UI.WebControls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;

namespace VS.OEE
{
    public partial class frmShiftLeader : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        private DataTable dt_Operator;
        public frmShiftLeader(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
        }
       
        #region Event
        private void frmShiftLeader_Load(object sender, EventArgs e)
        {
            if (iPQ != 1)
            {
                this.btnCopy.Visible = false;
                this.btnSua.Visible = false;
                this.btnXoa.Visible = false;
                this.btnGhi.Visible = false;
                this.btnKhong.Visible = false;
            }
            else
            {
                Commons.Modules.sId = "0Load";
                datNGAY.DateTime = DateTime.Now.Date;
                LoadgrdShiftLeader();
                Commons.Modules.sId = "";
                LockControl(true);
            }

            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                frmShiftLeader_Copy frm = new frmShiftLeader_Copy();

                if (frm.ShowDialog() != DialogResult.OK) return;
                DateTime TuNgay = frm.TuNgay;
                DateTime DenNgay = frm.DenNgay;
                if (TuNgay == null || DenNgay == null) return;

                int bGhi_De = 0;
                string str = "IF EXISTS (SELECT * FROM  dbo.SHIFT_LEADER WHERE NGAY BETWEEN '" + TuNgay.ToString("dd-MM-yyyy") + "' AND '" + DenNgay.ToString("dd-MM-yyyy") + "') SELECT 1 ELSE SELECT 0";
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, str)) == 1 && Modules.msgHoiThayThe(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgBanCoMuonGhiDeChoNhungNgayDaCoDuLieu"), groShiftLeader.Text) == DialogResult.Yes)
                {
                        bGhi_De = 1;
                }
                //if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "IF EXISTS (SELECT * FROM  dbo.SHIFT_LEADER WHERE NGAY BETWEEN '" + TuNgay.ToString("MM-dd-yyyy") + "' AND '" + DenNgay.ToString("MM-dd-yyyy") + "') SELECT 1 ELSE SELECT 0")) == 1 && Modules.msgHoiThayThe(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgBanCoMuonGhiDeChoNhungNgayDaCoDuLieu"), groShiftLeader.Text) == DialogResult.Yes)
                //{
                //    bGhi_De = 1;
                //}

                string sBT = "sBT_ShiftLeader" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, Commons.Modules.ObjSystems.ConvertDatatable(grdShiftLeader), "");

                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spCopyShiftLeader", TuNgay, DenNgay, sBT, bGhi_De)) == 1)
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgCopySuccessful"));
                Commons.Modules.ObjSystems.XoaTable(sBT);
            }
            catch { }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            LockControl(false);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DeleteData();
            LoadgrdShiftLeader();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                //Commons.Modules.msgChung(Commons.ThongBao.msgCapNhatThatBai);
                return;
            }
            LoadgrdShiftLeader();
            LockControl(true);
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            LockControl(true);
            if (datNGAY.Text == "")
            {
                datNGAY.DateTime = DateTime.Now;
            }
            else
            {
                LoadgrdShiftLeader();
            }
        }
        private void datNGAY_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadgrdShiftLeader();
        }
        private void grdShiftLeader_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteData();
                LoadgrdShiftLeader();
            }
        }
        private void grvShiftLeader_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

                if (view == null) return;
                if (e.Column.FieldName == "ID_Operator")
                {
                    Int64 ID_Operator = string.IsNullOrEmpty(view.GetFocusedRowCellValue("ID_Operator").ToString()) ? 0 : Convert.ToInt64(view.GetFocusedRowCellValue("ID_Operator"));

                    for (int i = 0; i < dt_Operator.Rows.Count; i++)
                    {
                        if ((string.IsNullOrEmpty(dt_Operator.Rows[i]["ID_Operator"].ToString()) ? 0 : Convert.ToInt64(dt_Operator.Rows[i]["ID_Operator"])) == ID_Operator)
                        {
                            view.SetFocusedRowCellValue(view.Columns["OperatorName"], dt_Operator.Rows[i]["OperatorName"]);
                            view.SetFocusedRowCellValue(view.Columns["CardID"], dt_Operator.Rows[i]["CardID"]);
                            view.SetFocusedRowCellValue(view.Columns["PHONE"], dt_Operator.Rows[i]["PHONE"]);
                            view.SetFocusedRowCellValue(view.Columns["MAIL"], dt_Operator.Rows[i]["MAIL"]);
                            view.SetFocusedRowCellValue(view.Columns["MS_TO"], dt_Operator.Rows[i]["MS_TO"]);
                            view.SetFocusedRowCellValue(view.Columns["Note"], dt_Operator.Rows[i]["Note"]);
                        }
                    }
                }
            }
            catch { }
        }
        //private void grvShiftLeader_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        //{
        //    try
        //    {
        //        DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
        //        GridControl grid = view.GridControl;
        //        DataTable dt = new DataTable();
        //        dt = (DataTable)grid.DataSource;

        //        int count = 0;

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            if ((string.IsNullOrEmpty(dt.Rows[i]["ID_Operator"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["ID_Operator"])) == (string.IsNullOrEmpty(view.GetFocusedRowCellValue("ID_Operator").ToString()) ? 0 : Convert.ToInt64(view.GetFocusedRowCellValue("ID_Operator"))))
        //            {
        //                count++;
        //            }
        //        }

        //        DevExpress.XtraGrid.Columns.GridColumn ID = view.Columns["ID_Operator"];
        //        if (view.FocusedRowHandle != DevExpress.XtraGrid.GridControl.NewItemRowHandle && count == 2)
        //        {
        //            e.Valid = false;
        //            XtraMessageBox.Show(ID.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
        //            view.SetColumnError(ID, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
        //            view.FocusedColumn = ID;
        //            return;
        //        }
        //    }
        //    catch { }
        //}
        //private void grvShiftLeader_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        //{
        //    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        //}
        #endregion

        #region Function
        private void LockControl(Boolean bLock)
        {
            this.btnCopy.Visible = bLock;
            this.btnSua.Visible = bLock;
            this.btnXoa.Visible = bLock;
            this.btnThoat.Visible = bLock;
            this.btnGhi.Visible = !bLock;
            this.btnKhong.Visible = !bLock;
            this.txtSearch.ReadOnly = !bLock;
            this.datNGAY.Properties.ReadOnly = !bLock;
            grvShiftLeader.OptionsBehavior.Editable = !bLock;
        }
        private void LoadgrdShiftLeader()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListShiftLeader", datNGAY.DateTime, Commons.Modules.UserName, Commons.Modules.TypeLanguage));

                dt.Columns["ID_Operator"].ReadOnly = false;
                dt.Columns["OperatorName"].ReadOnly = false;
                dt.Columns["CardID"].ReadOnly = false;
                dt.Columns["PHONE"].ReadOnly = false;
                dt.Columns["MAIL"].ReadOnly = false;
                dt.Columns["MS_TO"].ReadOnly = false;
                dt.Columns["Note"].ReadOnly = false;

                if (grvShiftLeader.DataSource == null)
                {

                    Modules.ObjSystems.MLoadXtraGrid(grdShiftLeader, grvShiftLeader, dt, true, true, false, false, true, this.Name);
                    for (int i = 0; i < grvShiftLeader.Columns.Count; i++)
                    {
                        grvShiftLeader.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                    grvShiftLeader.Columns["ID_Operator"].OptionsColumn.AllowEdit = true;
                    grvShiftLeader.Columns["ID_CA"].Visible = false;
                    grvShiftLeader.Columns["NGAY"].Visible = false;
                    grvShiftLeader.Columns["Note"].Visible = false;

                    //Lấy Operator có vai trò bằng 2: Team leader
                    dt_Operator = new DataTable();
                    dt_Operator.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT O.ID_Operator, O.OperatorCode, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN O.OperatorName WHEN 1 THEN ISNULL(NULLIF(O.OperatorNameA, ''),O.OperatorName) ELSE ISNULL(NULLIF(O.OperatorNameH, ''),O.OperatorName) END AS OperatorName, O.CardID, O.Note, O.PHONE, O.MAIL, TOO.MS_TO FROM dbo.Operator O LEFT JOIN dbo.TO_Operator TOO ON TOO.ID_TO = O.ID_TO INNER JOIN dbo.VAITRO_OPERATOR VO ON VO.OPERATOR_ID = O.ID_Operator INNER JOIN dbo.VAI_TRO VT ON VT.MS_VAI_TRO = VO.ID_VAI_TRO WHERE VT.MS_VAI_TRO = 2 ORDER BY OperatorCode"));

                    try
                    {
                        RepositoryItemSearchLookUpEdit cbo = new RepositoryItemSearchLookUpEdit();
                        Commons.Modules.ObjSystems.AddCombSearchLookUpEdit(cbo,"ID_Operator", "OperatorCode", grvShiftLeader, dt_Operator, this.Name);
                        cbo.View.Columns["ID_Operator"].Visible = false;
                        cbo.View.Columns["CardID"].Visible = false;
                        cbo.View.Columns["Note"].Visible = false;
                        cbo.View.Columns["MAIL"].Visible = false;
                        cbo.View.Columns["MS_TO"].Visible = false;
                        cbo.View.Columns["PHONE"].Visible = false;
                    }
                    catch { }
                }
                else
                    grdShiftLeader.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteData()
        {
            try
            {
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groShiftLeader.Text) == DialogResult.No) return;

                if (!Commons.Modules.ObjSystems.IsnullorEmpty(grvShiftLeader.GetFocusedRowCellValue("ID_Operator")))
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.SHIFT_LEADER WHERE ID_Operator = " + grvShiftLeader.GetFocusedRowCellValue("ID_Operator") + " AND NGAY = '" + datNGAY.DateTime.Date.ToString("yyyy-MM-dd") + "'");
                }
            }
            catch 
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }
        private bool SaveData()
        {
            try
            {
                string sBT = "sBT_ShiftLeader" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, Commons.Modules.ObjSystems.ConvertDatatable(grdShiftLeader), "");

                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spSaveShiftLeader", datNGAY.DateTime, sBT)) == 1)
                {
                    Commons.Modules.ObjSystems.XoaTable(sBT);
                    return true;
                }
                else
                {
                    Commons.Modules.ObjSystems.XoaTable(sBT);
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

    }
}