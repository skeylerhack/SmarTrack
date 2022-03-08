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

namespace VS.OEE
{
    public partial class ucBaocaoMoldingDaily : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaocaoMoldingDaily()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

      

     

        #region Event
        private void ucBaocaoMoldingDaily_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            datTNgay.DateTime = DateTime.Now;
            datDNgay.DateTime = DateTime.Now;
            LoadCbo();
            Commons.Modules.sId = "";
            LoadDataGrid();
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvBCMoldDaily.RowCount == 0)
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
        private void datTNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadDataGrid();
        }
        private void datDNgay_EditValueChanged(object sender, EventArgs e)
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
        #endregion

        #region Function
        private void LoadCbo()
        {
            Commons.Modules.sId = "0Load";
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

            Commons.Modules.sId = "";
        }
        private void LoadDataGrid()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DataTable dt = new DataTable();
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
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetReportMoldingDaily", Commons.Modules.TypeLanguage, datTNgay.DateTime, datDNgay.DateTime, cboID_CA.EditValue, cboShiftLeader.EditValue, sBT_MS_MAY));

                if (grdBCMoldDaily.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdBCMoldDaily, grvBCMoldDaily, dt, true, false, false, true, this.Name);

                    grvBCMoldDaily.Columns["StartTime"].DisplayFormat.FormatType = FormatType.DateTime;
                    grvBCMoldDaily.Columns["NumberPerCycle"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["NumberPerCycle"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["WorkingCycle"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["WorkingCycle"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["ActualQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["ActualQuantity"].DisplayFormat.FormatString = "#,##0.00";
                    grvBCMoldDaily.Columns["ScrapRate"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["ScrapRate"].DisplayFormat.FormatString = "#,##0.00";
                    grvBCMoldDaily.Columns["ScrapParts"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["ScrapParts"].DisplayFormat.FormatString = "#,##0.00";
                    grvBCMoldDaily.Columns["AcceptableParts"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["AcceptableParts"].DisplayFormat.FormatString = "#,##0.00";
                    grvBCMoldDaily.Columns["TheoreticalOutput"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["TheoreticalOutput"].DisplayFormat.FormatString = "#,##0.00";
                    grvBCMoldDaily.Columns["PlanProductionTime"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["PlanProductionTime"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["ActualOperatingTime"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["ActualOperatingTime"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["IdealRunRate"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["IdealRunRate"].DisplayFormat.FormatString = "#,##0.00";
                    grvBCMoldDaily.Columns["AvailabilityRate"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["AvailabilityRate"].DisplayFormat.FormatString = "#,##0.00%";
                    grvBCMoldDaily.Columns["PerformanceRate"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["PerformanceRate"].DisplayFormat.FormatString = "#,##0.00%";
                    grvBCMoldDaily.Columns["QualityRate"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["QualityRate"].DisplayFormat.FormatString = "#,##0.00%";
                    grvBCMoldDaily.Columns["OEERate"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["OEERate"].DisplayFormat.FormatString = "#,##0.00%";
                    grvBCMoldDaily.Columns["18"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["18"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["19"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["19"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["20"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["20"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["21"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["21"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["22"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["22"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["23"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["23"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["25"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["25"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["27"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["27"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["28"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["28"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["29"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["29"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["31"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["31"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["32"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["32"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["30"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["30"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["34"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["34"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["35"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["35"].DisplayFormat.FormatString = "#,##0";
                    grvBCMoldDaily.Columns["36"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBCMoldDaily.Columns["36"].DisplayFormat.FormatString = "#,##0";
                }
                else
                    grdBCMoldDaily.DataSource = dt;
            }
            catch (Exception ex)  { }
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
                int TCot = grvBCMoldDaily.Columns.Count;
                int TDong = grvBCMoldDaily.RowCount;
                int Dong = 1;
                excelApplication.Visible = false;
                grvBCMoldDaily.ActiveFilter.Clear();
                DataTable dt = new DataTable();
                grvBCMoldDaily.ExportToXlsx(sPath);
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
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 3, Dong);
                Dong = 4;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "rptMoldingDaily", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 1, 25);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 4, 1, Dong + TDong + 4, TCot);
                title.Borders.LineStyle = 1;

                Dong = 5;
                Excel.Range MS_MAY = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot);
                MS_MAY.Merge();
                MS_MAY.Font.Bold = true;
                MS_MAY.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                bool CheckAll = true;
                for (int i = 0; i < ccbMS_MAY.Properties.Items.Count; i++)
                {
                    if (ccbMS_MAY.Properties.Items[i].CheckState != CheckState.Checked)
                    {
                        CheckAll = false;
                        break;
                    }
                }
                if (CheckAll == true)
                    MS_MAY.Value = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblMS_MAY") + ": < ALL >";
                else
                    MS_MAY.Value = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblMS_MAY") + ": " + ccbMS_MAY.EditValue;

                Dong = 6;
                Excel.Range ID_CA = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, TCot / 2);
                ID_CA.Merge();
                ID_CA.Value = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblID_CA") + ": " + cboID_CA.Text;
                ID_CA.Font.Bold = true;

                Excel.Range ShiftLeader = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, (TCot / 2) + 1, Dong, TCot);
                ShiftLeader.Merge();
                ShiftLeader.Value = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblShiftLeader") + ": " + cboShiftLeader.Text;
                ShiftLeader.Font.Bold = true;


                Excel.Range HeaderColumn = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 2, 1, Dong + 2, TCot);
                HeaderColumn.Font.Bold = true;
                HeaderColumn.WrapText = true;
                HeaderColumn.Interior.Color = Color.FromArgb(141, 180, 226);

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21, "@", true, 1, 1, 1, 1);

                excelWorkbook.Save();
                excelApplication.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch (Exception ex)  { XtraMessageBox.Show(ex.Message); }
        }
        #endregion
    }
}
