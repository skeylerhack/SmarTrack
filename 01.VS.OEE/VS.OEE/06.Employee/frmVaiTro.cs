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
    public partial class frmVaiTro : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        Int64 ithem = 0;
        string sBT = "TMPVTOperator" + Commons.Modules.UserName;
        private DataTable dt_Operator;
        public frmVaiTro(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        #region eventForm
        private void frmVaiTro_Load(object sender, EventArgs e)
        {
            if (iPQ != 1)
            {
                this.btnSua.Visible = false;
                this.btnXoa.Visible = false;
                this.btnChooseOperator.Visible = false;
                this.btnGhi.Visible = false;
                this.btnKhong.Visible = false;
            }
            else
            {
                VisibleButon(true);
            }
       
            LoadgrdVaiTro(-1);
            if (grvVaiTro.RowCount == 0)
            {
                LoadgrdVTOperator(-1,null);
            }

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvVaiTro.GetFocusedRowCellValue("ID_VAI_TRO") == null || grvVaiTro.GetFocusedRowCellValue("ID_VAI_TRO").ToString() == "")
            {
                Modules.msgThayThe(ThongBao.msgBanChuaChonDuLieu, lblTEN_VAI_TRO_A.Text);
                return;
            }
            VisibleButon(false);
            ithem = Convert.ToInt64(grvVaiTro.GetFocusedRowCellValue("ID_VAI_TRO"));
            Commons.Modules.ObjSystems.AddnewRow(grvVTOperator, true);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvVTOperator.RowCount == 0) return; 
            DeleteDatadetails();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            grvVTOperator.PostEditor();
            grvVTOperator.UpdateCurrentRow();
            if (!dxValidationProvider1.Validate()) return;

            SaveData();
            Commons.Modules.ObjSystems.DeleteAddRow(grvVTOperator);
            VisibleButon(true);
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.DeleteAddRow(grvVTOperator);
            VisibleButon(true);
            grvVaiTro_FocusedRowChanged(null, null);

        }
        private void btnChooseOperator_Click(object sender, EventArgs e)
        {
            frmChooseOperator Operator = new frmChooseOperator();
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, Operator.sBTChon, Commons.Modules.ObjSystems.ConvertDatatable(grdVTOperator), "");
            if (Operator.ShowDialog() == DialogResult.OK)
            {
                //load lại item máy
                LoadgrdVTOperator(Convert.ToInt64(grvVaiTro.GetFocusedRowCellValue("ID_VAI_TRO")), Operator.dt_Operator);
            }
        }
        private void grvVaiTro_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadgrdVTOperator(Convert.ToInt64(grvVaiTro.GetFocusedRowCellValue("ID_VAI_TRO")), null);
            BingdingControl();
        }
        private void grdVTOperator_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteDatadetails();
            }
        }
        private void grvVTOperator_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                view.SetFocusedRowCellValue(view.Columns["ID_VAI_TRO"], grvVaiTro.GetFocusedRowCellValue("ID_VAI_TRO"));

                Int64 Operator_ID = string.IsNullOrEmpty(view.GetFocusedRowCellValue("Operator_ID").ToString()) ? 0 : Convert.ToInt64(view.GetFocusedRowCellValue("Operator_ID"));

                for (int i = 0; i < dt_Operator.Rows.Count; i++)
                {
                    if ((string.IsNullOrEmpty(dt_Operator.Rows[i]["ID_Operator"].ToString()) ? 0 : Convert.ToInt64(dt_Operator.Rows[i]["ID_Operator"])) == Operator_ID)
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
        private void grvVTOperator_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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
        private void grvVTOperator_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
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
                    XtraMessageBox.Show(ID.Caption + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                    view.SetColumnError(ID, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = ID;
                    return;
                }

                if (view.FocusedRowHandle != DevExpress.XtraGrid.GridControl.NewItemRowHandle && count == 2)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(ID.Caption + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                    view.SetColumnError(ID, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = ID;
                    return;
                }


            }
            catch { }
        }
        private void grvVTOperator_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        #endregion

        #region function 
        private void VisibleButon(bool flag)
        {
            btnThoat.Visible = flag;
            btnXoa.Visible = flag;
            btnSua.Visible = flag;
            btnGhi.Visible = !flag;
            btnKhong.Visible = !flag;
            btnChooseOperator.Visible = !flag;
            //ReadonlyControl(flag);
            grdVaiTro.Enabled = flag;
        }
        private void BingdingControl()
        {
            txtTEN_VAI_TRO.EditValue = grvVaiTro.GetFocusedRowCellValue("TEN_VAI_TRO");
            txtTEN_VAI_TRO_A.EditValue = grvVaiTro.GetFocusedRowCellValue("TEN_VAI_TRO_A");
            txtTEN_VAI_TRO_H.EditValue = grvVaiTro.GetFocusedRowCellValue("TEN_VAI_TRO_H");
        }
        //private void ReadonlyControl(bool flag)
        //{
        //    txtTEN_VAI_TRO.Properties.ReadOnly = flag;
        //    txtTEN_VAI_TRO_A.Properties.ReadOnly = flag;
        //    txtTEN_VAI_TRO_H.Properties.ReadOnly = flag;
        //}
        private void LoadgrdVaiTro(Int64 id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID_VAI_TRO, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN TEN_VAI_TRO WHEN 1 THEN TEN_VAI_TRO_A ELSE TEN_VAI_TRO_H END AS TEN_VT, TEN_VAI_TRO, TEN_VAI_TRO_A, TEN_VAI_TRO_H, ID_DEPARTMENT FROM dbo.VAI_TRO_HMI ORDER BY TEN_VT"));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID_VAI_TRO"] };
                if (grdVaiTro.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdVaiTro, grvVaiTro, dt, false, true, false, false, true, this.Name);
                    grvVaiTro.Columns["TEN_VT"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvVaiTro.Columns["ID_VAI_TRO"].Visible = false;
                    grvVaiTro.Columns["TEN_VAI_TRO"].Visible = false;
                    grvVaiTro.Columns["TEN_VAI_TRO_A"].Visible = false;
                    grvVaiTro.Columns["TEN_VAI_TRO_H"].Visible = false;
                    grvVaiTro.Columns["ID_DEPARTMENT"].Visible = false;
                }
                else
                    grdVaiTro.DataSource = dt;


                if (id != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvVaiTro.FocusedRowHandle = grvVaiTro.GetRowHandle(index);
                }
                else {/* LoadText(false);*/ }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadgrdVTOperator(Int64 ID_VAI_TRO, DataTable choseOperator)
        {
            try
            {
                if (choseOperator == null)
                {
                    choseOperator = new DataTable();
                    choseOperator.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT VO.ID_VAI_TRO, VO.OPERATOR_ID AS ID_Operator, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN O.OperatorName WHEN 1 THEN ISNULL(NULLIF(O.OperatorNameA, ''), O.OperatorName) ELSE ISNULL(NULLIF(O.OperatorNameA, ''), O.OperatorName) END AS OperatorName, O.CardID, O.PHONE, O.MAIL, O.ID_TO, O.Note FROM dbo.VAITRO_OPERATOR VO LEFT JOIN dbo.Operator O ON O.ID_Operator = VO.OPERATOR_ID WHERE VO.ID_VAI_TRO = " + Convert.ToInt64(grvVaiTro.GetFocusedRowCellValue("ID_VAI_TRO")) + "  ORDER BY O.OperatorCode "));
                }
                if (grdVTOperator.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdVTOperator, grvVTOperator, choseOperator, false, false,false, false, true, this.Name);

                    dt_Operator = new DataTable();
                    dt_Operator.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID_Operator, OperatorCode, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN OperatorName WHEN 1 THEN ISNULL(NULLIF(OperatorNameA, ''),OperatorName) ELSE ISNULL(NULLIF(OperatorNameH, ''),OperatorName) END AS OperatorName FROM dbo.Operator ORDER BY OperatorCode"));
                    try
                    {
                        Commons.Modules.ObjSystems.AddCombXtra("ID_Operator", "OperatorCode", "ID_Operator", grvVTOperator, dt_Operator, true, this.Name);
                    }
                    catch { }
                    DataTable dt1 = new DataTable();
                    dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID_TO, MS_TO, TEN_TO FROM dbo.TO_Operator ORDER BY MS_TO"));

                    try
                    {
                        Commons.Modules.ObjSystems.AddCombXtra("ID_TO", "MS_TO", "ID_TO", grvVTOperator, dt1, false, this.Name);
                    }
                    catch { }

                    for (int i = 1; i < grvVTOperator.Columns.Count; i++)
                    {
                        grvVTOperator.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                    grvVTOperator.Columns["ID_Operator"].OptionsColumn.AllowEdit = true;
                    grvVTOperator.Columns["Note"].Visible = false;
                    grvVTOperator.Columns["ID_VAI_TRO"].Visible = false;
                }
                else
                    grdVTOperator.DataSource = choseOperator;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveData()
        {
            //tạo bảng tạm
            try
            {
                Commons.Modules.ObjSystems.XoaTable(sBT);
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, Commons.Modules.ObjSystems.ConvertDatatable(grdVTOperator), "");
                LoadgrdVaiTro(Convert.ToInt64(
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditVaiTro", ithem, sBT)));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteDatadetails()
        {
            try
            {
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, "Operator") == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.VAITRO_OPERATOR WHERE OPERATOR_ID = " + grvVTOperator.GetFocusedRowCellValue("ID_Operator") + " AND ID_VAI_TRO = " + grvVaiTro.GetFocusedRowCellValue("ID_VAI_TRO") + "");
                grvVTOperator.DeleteSelectedRows();
                ((DataTable)grdVTOperator.DataSource).AcceptChanges();
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);

            }
        }
        #endregion



    }
}