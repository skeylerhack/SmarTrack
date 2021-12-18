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
using DevExpress.XtraGrid;

namespace VS.OEE
{
    public partial class frmQLCa : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        private int ithem = 0;
        private string sBT = "TMPOperator_CA" + Commons.Modules.UserName;
        private DataTable dt_Operator;
        public frmQLCa(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        #region eventForm
        private void frmQLCa_Load(object sender, EventArgs e)
        {
            if (iPQ != 1)
            {
                this.btnThem.Visible = false;
                this.btnSua.Visible = false;
                this.btnXoa.Visible = false;
                this.btnChoose.Visible = false;
                this.btnGhi.Visible = false;
                this.btnKhong.Visible = false;
            }
            else
            {
                VisibleButon(true);
            }
            LoadgrdCa(-1);
            if (grvCa.RowCount == 0)
            {
                LoadgrdOperator(-1,null);
            }
            Commons.Modules.ObjSystems.DeleteAddRow(grvOperator);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            VisibleButon(false);
            ithem = -1;
            LoadgrdOperator(-1, null);
            BingdingControl(true);
            txtCA.Focus();
            Commons.Modules.ObjSystems.AddnewRow(grvOperator, true);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvCa.GetFocusedRowCellValue("STT") == null || grvCa.GetFocusedRowCellValue("STT").ToString() == "")
            {
                Modules.msgThayThe(ThongBao.msgBanChuaChonDuLieu, lblCA.Text);
                return;
            }
            VisibleButon(false);
            ithem = Convert.ToInt32(grvCa.GetFocusedRowCellValue("STT"));
            Commons.Modules.ObjSystems.AddnewRow(grvOperator, true);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvCa.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvCa.GetFocusedRowCellValue("STT").ToString()); } catch { }
            if (iId == -1)
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, lblCA.Text);
                return;
            }
            if (grvOperator.RowCount == 0)
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
            #region kiem trong
            if (txtCA.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblCA.Text, txtCA);
                return;
            }
            if (txtCA_ANH.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblCA_ANH.Text, txtCA_ANH);
                return;
            }
            if (datTU_GIO.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblTU_GIO.Text, datTU_GIO);
                return;
            }
            if (datDEN_GIO.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblDEN_GIO.Text, datDEN_GIO);
                return;
            }
            #endregion
            #region kiem trung 
            object rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.CA WHERE CA = '" + txtCA.Text.Trim() + "' " + (ithem == -1 ? "" : "AND STT <> " + ithem + "") + "  ");
            if (rs != null && (Int32)rs > 0)
            {
                Modules.msgThayThe(ThongBao.msgDaTonTai, txtCA.Text, txtCA);
                return;
            }
            rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.CA WHERE CA_ANH ='" + txtCA_ANH.Text.Trim() + "'  " + (ithem == -1 ? "" : "AND STT <> " + ithem + "") + "  ");
            if (rs != null && (Int32)rs > 0)
            {
                Modules.msgThayThe(ThongBao.msgDaTonTai, txtCA_ANH.Text, txtCA_ANH);
                return;
            }

            if (KiemTraGio()) return;

            #endregion
            grvOperator.PostEditor();
            grvOperator.UpdateCurrentRow();
            SaveOperator_CA();
            Commons.Modules.ObjSystems.DeleteAddRow(grvOperator);
            VisibleButon(true);
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.DeleteAddRow(grvOperator);
            VisibleButon(true);
            grvCa_FocusedRowChanged(null, null);

        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                frmChooseOperator frm = new frmChooseOperator();
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, frm.sBTChon, Commons.Modules.ObjSystems.ConvertDatatable(grdOperator), "");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //load lại item máy
                    LoadgrdOperator(Convert.ToInt32(grvCa.GetFocusedRowCellValue("STT")), frm.dt_Operator);
                }
            }
            catch { }
        }
        private void grvCa_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                LoadgrdOperator(Convert.ToInt32(grvCa.GetFocusedRowCellValue("STT")), null);
                BingdingControl(false);
            }
            catch { }
        }
        private void grdCa_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteData();
            }
        }
        private void grvOperator_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
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
                            view.SetFocusedRowCellValue(view.Columns["ID_TO"], dt_Operator.Rows[i]["ID_TO"]);
                            view.SetFocusedRowCellValue(view.Columns["Note"], dt_Operator.Rows[i]["Note"]);
                        }
                    }
                }
            }
            catch { }
        }
        private void grdOperator_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteDatadetails();
            }
        }
        private void grvOperator_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                view.SetFocusedRowCellValue(view.Columns["ID_CA"], grvCa.GetFocusedRowCellValue("STT"));

                Int64 ID_Operator = string.IsNullOrEmpty(view.GetFocusedRowCellValue("ID_Operator").ToString()) ? 0 : Convert.ToInt64(view.GetFocusedRowCellValue("ID_Operator"));

                for (int i = 0; i < dt_Operator.Rows.Count; i++)
                {
                    if ((string.IsNullOrEmpty(dt_Operator.Rows[i]["ID_Operator"].ToString()) ? 0 : Convert.ToInt64(dt_Operator.Rows[i]["ID_Operator"])) == ID_Operator)
                    {
                        view.SetFocusedRowCellValue(view.Columns["OperatorName"], dt_Operator.Rows[i]["OperatorName"]);
                        view.SetFocusedRowCellValue(view.Columns["CardID"], dt_Operator.Rows[i]["CardID"]);
                        view.SetFocusedRowCellValue(view.Columns["PHONE"], dt_Operator.Rows[i]["PHONE"]);
                        view.SetFocusedRowCellValue(view.Columns["MAIL"], dt_Operator.Rows[i]["MAIL"]);
                        view.SetFocusedRowCellValue(view.Columns["ID_TO"], dt_Operator.Rows[i]["ID_TO"]);
                        view.SetFocusedRowCellValue(view.Columns["Note"], dt_Operator.Rows[i]["Note"]);
                    }
                }
            }
            catch
            {
            }
        }
        private void grvOperator_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                GridControl grid = view.GridControl;
                DataTable dt = new DataTable();
                dt = (DataTable)grid.DataSource;

                int count = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((string.IsNullOrEmpty(dt.Rows[i]["ID_Operator"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["ID_Operator"])) == (string.IsNullOrEmpty(view.GetFocusedRowCellValue("ID_Operator").ToString()) ? 0 : Convert.ToInt64(view.GetFocusedRowCellValue("ID_Operator"))))
                    {
                        count++;
                    }
                }

                DevExpress.XtraGrid.Columns.GridColumn ID = view.Columns["ID_Operator"];
                if (view.FocusedRowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle && count == 1)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(ID.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                    view.SetColumnError(ID, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = ID;
                    return;
                }

                if (view.FocusedRowHandle != DevExpress.XtraGrid.GridControl.NewItemRowHandle && count == 2)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(ID.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                    view.SetColumnError(ID, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = ID;
                    return;
                }


            }
            catch { }
        }
        private void grvOperator_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
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
            btnChoose.Visible = !flag;
            ReadonlyControl(flag);
            grdCa.Enabled = flag;
        }
        private void BingdingControl(bool them)
        {
            if (them == true)
            {
                txtCA.ResetText();
                txtCA_ANH.ResetText();
                txtCA_HOA.ResetText();
                datTU_GIO.EditValue = Convert.ToDateTime("1900/01/01 00:00");
                datDEN_GIO.EditValue = Convert.ToDateTime("1900/01/01 00:00");
                chkCA_DEM.Checked = false;
            }
            else
            {
                txtCA.EditValue = grvCa.GetFocusedRowCellValue("CA");
                txtCA_ANH.EditValue = grvCa.GetFocusedRowCellValue("CA_ANH");
                txtCA_HOA.EditValue = grvCa.GetFocusedRowCellValue("CA_HOA");
                datTU_GIO.EditValue = grvCa.GetFocusedRowCellValue("TU_GIO");
                datDEN_GIO.EditValue = grvCa.GetFocusedRowCellValue("DEN_GIO");
                chkCA_DEM.Checked = string.IsNullOrEmpty(grvCa.GetFocusedRowCellValue("CA_DEM").ToString())? false : Convert.ToBoolean(grvCa.GetFocusedRowCellValue("CA_DEM"));
            }
        }
        private void ReadonlyControl(bool flag)
        {
            txtCA.Properties.ReadOnly = flag;
            txtCA_ANH.Properties.ReadOnly = flag;
            txtCA_HOA.Properties.ReadOnly = flag;
            datTU_GIO.Properties.ReadOnly = flag;
            datDEN_GIO.Properties.ReadOnly = flag;
            chkCA_DEM.Properties.ReadOnly = flag;
            
        }
        private void LoadgrdCa(Int64 STT)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT STT, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN CA WHEN 1 THEN ISNULL(NULLIF(CA_ANH, ''), CA) ELSE ISNULL(NULLIF(CA_HOA, ''), CA) END AS TEN_CA, CA, CA_ANH, CA_HOA, TU_GIO, DEN_GIO, CA_DEM FROM dbo.CA"));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["STT"] };
                if (grdCa.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdCa, grvCa, dt, false, true, false, false, true, this.Name);
                    grvCa.Columns["STT"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvCa.Columns["TEN_CA"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvCa.Columns["CA"].Visible = false;
                    grvCa.Columns["CA_ANH"].Visible = false;
                    grvCa.Columns["CA_HOA"].Visible = false;
                    grvCa.Columns["TU_GIO"].Visible = false;
                    grvCa.Columns["DEN_GIO"].Visible = false;
                    grvCa.Columns["CA_DEM"].Visible = false;
                }
                else
                    grdCa.DataSource = dt;
                if (STT != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(STT));
                    grvCa.FocusedRowHandle = grvCa.GetRowHandle(index);
                }
                else {/* LoadText(false);*/ }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadgrdOperator(Int64 STT, DataTable choseOperator)
        {
            try
            {
                if (choseOperator == null)
                {
                    choseOperator = new DataTable();
                    choseOperator.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT OC.ID_CA, OC.ID_Operator, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN O.OperatorName WHEN 1 THEN ISNULL(NULLIF(O.OperatorNameA, ''), O.OperatorName) ELSE ISNULL(NULLIF(O.OperatorNameA, ''), O.OperatorName) END AS OperatorName, O.CardID, O.PHONE, O.MAIL, O.ID_TO, O.Note FROM dbo.Operator_CA OC LEFT JOIN dbo.Operator O ON O.ID_Operator = OC.ID_Operator WHERE OC.ID_CA = " + STT + " ORDER BY O.OperatorCode"));
                }


                if (grdOperator.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdOperator, grvOperator, choseOperator, false, false, false, false, true, this.Name);

                    dt_Operator = new DataTable();
                    dt_Operator.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID_Operator, OperatorCode, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN OperatorName WHEN 1 THEN ISNULL(NULLIF(OperatorNameA, ''),OperatorName) ELSE ISNULL(NULLIF(OperatorNameH, ''),OperatorName) END AS OperatorName, CardID, Note, PHONE, MAIL, ID_TO FROM dbo.Operator ORDER BY OperatorCode"));

                    try
                    {
                        Commons.Modules.ObjSystems.AddCombXtra("ID_Operator", "OperatorCode", "ID_Operator", grvOperator, dt_Operator, false, this.Name);
                    }
                    catch { }

                    DataTable dt1 = new DataTable();
                    dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID_TO, MS_TO, TEN_TO FROM dbo.TO_Operator ORDER BY MS_TO"));

                    try
                    {
                        Commons.Modules.ObjSystems.AddCombXtra("ID_TO", "MS_TO", "ID_TO", grvOperator, dt1, false, this.Name);
                    }
                    catch { }

                    for (int i = 0; i < grvOperator.Columns.Count; i++)
                    {
                        grvOperator.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                    grvOperator.Columns["ID_Operator"].OptionsColumn.AllowEdit = true;
                    grvOperator.Columns["Note"].Visible = false;
                    grvOperator.Columns["ID_CA"].Visible = false;

                }
                else
                    grdOperator.DataSource = choseOperator;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveOperator_CA()
        {
            //tạo bảng tạm
            try
            {
              

                Commons.Modules.ObjSystems.XoaTable(sBT);
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, Commons.Modules.ObjSystems.ConvertDatatable(grdOperator), "");
                LoadgrdCa(Convert.ToInt32(
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditQLCa", ithem, txtCA.EditValue, txtCA_ANH.EditValue, txtCA_HOA.EditValue, Convert.ToDateTime(datTU_GIO.EditValue).ToString("MM-dd-yyyy HH:mm:ss"), Convert.ToDateTime(datDEN_GIO.EditValue).ToString("MM-dd-yyyy HH:mm:ss"), chkCA_DEM.Checked, sBT)));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteData()
        {
            if (Modules.msgHoiThayThe(ThongBao.msgXoa, lblCA.Text) == DialogResult.No) return;
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.Operator_CA WHERE ID_CA ='" + Convert.ToInt32(grvCa.GetFocusedRowCellValue("STT")) + "' DELETE dbo.CA WHERE STT = '" + Convert.ToInt32(grvCa.GetFocusedRowCellValue("STT")) + "'");
                grvCa.DeleteSelectedRows();
                ((DataTable)grdCa.DataSource).AcceptChanges();
                grvCa_FocusedRowChanged(null, null);
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }
        private void DeleteDatadetails()
        {
            try
            {
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, "Operator") == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.Operator_CA WHERE ID_Operator = " + (grvOperator.GetFocusedRowCellValue("ID_Operator") + " AND ID_CA = " + (grvOperator.GetFocusedRowCellValue("ID_CA"))));
                grvOperator.DeleteSelectedRows();
                ((DataTable)grdOperator.DataSource).AcceptChanges();
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);

            }
        }
        private bool KiemTraGio()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)grdCa.DataSource;

                int TU_GIO = (datTU_GIO.Time.Hour * 60) + datTU_GIO.Time.Minute;
                int DEN_GIO = (datDEN_GIO.Time.Hour * 60) + datDEN_GIO.Time.Minute;

                //Ca dem + them 1 ngay
                if (chkCA_DEM.Checked)
                    DEN_GIO = DEN_GIO + 1440;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if((string.IsNullOrEmpty(grvCa.GetFocusedRowCellValue("STT").ToString()) ? -1 : Convert.ToInt64(grvCa.GetFocusedRowCellValue("STT"))) != (string.IsNullOrEmpty(dt.Rows[i]["STT"].ToString()) ? -1 : Convert.ToInt64(dt.Rows[i]["STT"])))
                    {
                        int iTU_GIO = (string.IsNullOrEmpty(dt.Rows[i]["TU_GIO"].ToString()) ? 0 : (Convert.ToDateTime(dt.Rows[i]["TU_GIO"]).Hour * 60) + Convert.ToDateTime(dt.Rows[i]["TU_GIO"]).Minute);
                        int iDEN_GIO = (string.IsNullOrEmpty(dt.Rows[i]["DEN_GIO"].ToString()) ? 0 : (Convert.ToDateTime(dt.Rows[i]["DEN_GIO"]).Hour * 60) + Convert.ToDateTime(dt.Rows[i]["DEN_GIO"]).Minute);
                        if (chkCA_DEM.Checked)
                            iDEN_GIO = iDEN_GIO + 1440;

                        if ((TU_GIO > iTU_GIO && TU_GIO < iDEN_GIO) || (DEN_GIO > iTU_GIO && DEN_GIO < iDEN_GIO))
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTrungThoiGian"));
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); return true; }
        }
        #endregion

       
    }
}