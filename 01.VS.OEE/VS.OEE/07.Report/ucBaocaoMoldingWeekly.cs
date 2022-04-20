using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraCharts;
using Commons;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraPrinting;
using System.Drawing;
using System.IO;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.Utils;
using System.Globalization;

namespace VS.OEE
{
    public partial class ucBaocaoMoldingWeekly : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaocaoMoldingWeekly()
        {
            Commons.Modules.sId = "0Load";
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        #region Event
        private void ucBaocaoMoldingWeekly_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            datTNgay.DateTime = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
            datDNgay.DateTime = DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Date.Day);
            LoadCbo();
            Commons.Modules.sId = "";
            ccbMS_MAY.Properties.SelectAllItemVisible = true;
            LoadDataGrid();
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvBCMoldWeekly.RowCount == 0)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuIn);
                    return;
                }
                InDuLieu();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        private void ccbMS_MAY_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadDataGrid();
        }
        private void cboID_CA_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadDataGrid();
        }
        private void cboShiftLeader_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadDataGrid();
        }
        private void cboTuan_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadDataGrid();
        }

        private void grvBCMoldWeekly_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int ID_Result = string.IsNullOrEmpty(grvBCMoldWeekly.GetFocusedRowCellValue("ID_Result").ToString()) ? 0 : Convert.ToInt32(grvBCMoldWeekly.GetFocusedRowCellValue("ID_Result"));
            if (ID_Result == 19)// Actual_Labor
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spSaveActualLabor", Convert.ToDateTime(grvBCMoldWeekly.FocusedColumn.FieldName), Convert.ToDouble(grvBCMoldWeekly.GetFocusedRowCellValue(grvBCMoldWeekly.FocusedColumn.FieldName)));
                }
                catch { }
            }
        }
        private void grvBCMoldWeekly_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int ID_Result = string.IsNullOrEmpty(grvBCMoldWeekly.GetFocusedRowCellValue("ID_Result").ToString()) ? 0 : Convert.ToInt32(grvBCMoldWeekly.GetFocusedRowCellValue("ID_Result"));
            if (ID_Result != 19 || grvBCMoldWeekly.FocusedColumn.FieldName == "ID_Result" || grvBCMoldWeekly.FocusedColumn.FieldName == "Name_Result")
                e.Cancel = true;
        }
        #endregion
        #region Function
        private void LoadCbo()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboID_CA, Commons.Modules.ObjSystems.DataCa(true), "STT", "CA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "CA"));
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT O.ID_Operator, O.OperatorCode, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN O.OperatorName WHEN 1 THEN ISNULL(NULLIF(O.OperatorNameA, ''),O.OperatorName) ELSE ISNULL(NULLIF(O.OperatorNameH, ''),O.OperatorName) END AS OperatorName FROM dbo.Operator O INNER JOIN dbo.VAITRO_OPERATOR VO ON VO.OPERATOR_ID = O.ID_Operator INNER JOIN dbo.VAI_TRO VT ON VT.MS_VAI_TRO = VO.ID_VAI_TRO WHERE VT.MS_VAI_TRO = 2 UNION SELECT - 1, ' < ALL > ', ' < ALL > '   ORDER BY OperatorCode"));
            Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboShiftLeader, dt, "ID_Operator", "OperatorCode", this.Name);
            try
            {
                ccbMS_MAY.Properties.DataSource = null;
                ccbMS_MAY.Properties.DisplayMember = "";
                ccbMS_MAY.Properties.ValueMember = "";
                ccbMS_MAY.Properties.DataSource = Commons.Modules.ObjSystems.DataMay(false);
                ccbMS_MAY.Properties.DisplayMember = "TEN_MAY";
                ccbMS_MAY.Properties.ValueMember = "MS_MAY";
                ccbMS_MAY.Refresh();
                ccbMS_MAY.CheckAll();
            }
            catch { }
        }
        private void LoadDataGrid()
        {
            if (Commons.Modules.sId == "0Load") return;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DataTable dt = new DataTable();
                //Get ngay

                //Get MS_MAY
                string[] arrMS_MAY = ccbMS_MAY.EditValue.ToString().Split(',');
                DataTable dt_MS_MAY = new DataTable();
                try
                {
                    dt_MS_MAY.Columns.Add("MS_MAY");
                    foreach (string MS_MAY in arrMS_MAY)
                    {
                        dt_MS_MAY.Rows.Add(MS_MAY.Trim());
                    }
                }
                catch { }
                string sBT_MS_MAY = "sBT_MS_MAY" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT_MS_MAY, dt_MS_MAY, "");
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetReportMoldingWeekly", Commons.Modules.TypeLanguage, this.Name, datTNgay.DateTime, datDNgay.DateTime, cboID_CA.EditValue, cboShiftLeader.EditValue, sBT_MS_MAY));
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].ColumnName == "ID_Result" || dt.Columns[i].ColumnName == "Name_Result") continue;
                    dt.Columns[i].ReadOnly = false;
                }
                 Commons.Modules.ObjSystems.MLoadXtraGrid(grdBCMoldWeekly, grvBCMoldWeekly, dt, true, false, true, true, this.Name);
                grvBCMoldWeekly.OptionsBehavior.Editable = true;
                for (int i = 0; i < grvBCMoldWeekly.Columns.Count; i++)
                {
                    if (grvBCMoldWeekly.Columns[i].FieldName == "ID_Result" || grvBCMoldWeekly.Columns[i].FieldName == "Name_Result") continue;
                    grvBCMoldWeekly.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldWeekly.Columns[i].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    grvBCMoldWeekly.Columns[i].OptionsColumn.AllowEdit = true;
                }

                grvBCMoldWeekly.Columns["ID_Result"].Visible = false;
            }
            catch(Exception ex)
            {
                
            }
            Cursor.Current = Cursors.Default;
        }
        private void InDuLieu()
        {
            try
            {
                string sPath = "";
                sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
                if (sPath == "") return;
                //this.Cursor = Cursors.WaitCursor;
                Excel.Application excelApplication = new Excel.Application();
                excelApplication.DisplayAlerts = true;
                Excel.Range title;
                Excel.FormatCondition condition;
                int TCot = 8;
                int TDong = grvBCMoldWeekly.RowCount;
                int Dong = 1;
                excelApplication.Visible = false;
                grvBCMoldWeekly.ActiveFilter.Clear();
                grvBCMoldWeekly.ExportToXlsx(sPath);
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
                Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", false, false, 0, true);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            
                excelApplication.Cells.Borders.LineStyle = 0;
                excelApplication.Cells.Font.Name = "Tahoma";
                excelApplication.Cells.Font.Size = 10;
                excelWorkSheet.AutoFilterMode = false;
                excelWorkSheet.Application.ActiveWindow.FreezePanes = false;
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 2, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 4, Dong);
                Dong = 4;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "rptMoldingWeekly", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 1, 25);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 4, 1, Dong + TDong + 5, 
                    grvBCMoldWeekly.Columns.Count - 1);
                title.Borders.LineStyle = 1;

                Dong = 5;
                Excel.Range MS_MAY = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                MS_MAY.Merge();
                MS_MAY.Font.Bold = true;
                MS_MAY.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                bool CheckAll = true;
                for (int i = 0; i < ccbMS_MAY.Properties.Items.Count; i ++)
                {
                    if (ccbMS_MAY.Properties.Items[i].CheckState != CheckState.Checked)
                    {
                        CheckAll = false;
                        break;
                    }
                }
                if(CheckAll == true)
                    MS_MAY.Value = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblMS_MAY") + ": < ALL >";
                else
                    MS_MAY.Value = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblMS_MAY") + ": " + ccbMS_MAY.EditValue;

                Dong = 6;
                Excel.Range ID_CA = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 2, Dong, 4);
                ID_CA.Merge();
                ID_CA.Value = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblID_CA") + ": " + cboID_CA.Text;
                ID_CA.Font.Bold = true;

                Excel.Range ShiftLeader = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 5, Dong, TCot - 1);
                ShiftLeader.Merge();
                ShiftLeader.Value = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblShiftLeader") + ": " + cboShiftLeader.Text;
                ShiftLeader.Font.Bold = true;


                Excel.Range HeaderColumn = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 2, 1, Dong + 3, grvBCMoldWeekly.Columns.Count - 1);
                HeaderColumn.Font.Bold = true;
                HeaderColumn.WrapText = true;
                HeaderColumn.Interior.Color = Color.FromArgb(141, 180, 226);

                Excel.Range HeaderRow = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 4, 1, Dong + TDong + 5, 1);
                HeaderRow.Font.Bold = true;

                Excel.Range Summary = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 2, 1, Dong + 3, 1);
                Summary.Merge();

                Excel.Range Tuan = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 2, 2, Dong + 2, grvBCMoldWeekly.Columns.Count - 1);
                Tuan.Merge();
                Tuan.Value = datTNgay.Text + " - " + datDNgay.Text;
                Tuan.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21, "@", true, 1, 1, 1, 1);

                for (int i = 2; i < grvBCMoldWeekly.Columns.Count; i++)
                {
                    Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 13, "@", true, 1, i, 1, i);
                }
                excelWorkbook.Save();
                excelApplication.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch (Exception ex)  { XtraMessageBox.Show(ex.Message); }
        }
        #endregion
        private void datDNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadDataGrid();
        }
    }
}
