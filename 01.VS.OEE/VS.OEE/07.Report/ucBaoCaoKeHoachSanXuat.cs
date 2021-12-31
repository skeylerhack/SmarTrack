using System;
using System.Data;
using DevExpress.XtraEditors;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using System.Globalization;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;

namespace VS.OEE
{
    public partial class ucBaoCaoKeHoachSanXuat : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoKeHoachSanXuat()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void ucBaoCaoKeHoachSanXuat_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            LoadTuan();
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMay, Commons.Modules.ObjSystems.DataMay(true), "MS_MAY", "TEN_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_MAY"));
            Loadgrdata();
            Commons.Modules.sId = "";
        }
        public void LoadTuan()
        {
            DataTable tb = new DataTable();
            tb = SqlHelper.ExecuteDataset(Commons.IConnections.CNStr, "GetTUAN_TRONG_NAM", "01/01/" + DateTime.Now.Year.ToString(), "31/12/" + DateTime.Now.Year.ToString(), Commons.Modules.TypeLanguage).Tables[0];
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTuan, tb, "TUAN", "TEN_TUAN", "");
            try
            {
                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                cboTuan.EditValue = weekNum;
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }

        private void Loadgrdata()
        {
            DataTable dtmp = new DataTable();
            try
            {
                DateTime dTNgay = Convert.ToDateTime(cboTuan.Text.Split(' ')[2].Split('_')[0]);
                DateTime dDNgay = dTNgay.AddDays(6);
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetBCKeHoachSanXuat", Commons.Modules.UserName, Commons.Modules.TypeLanguage, dTNgay, dDNgay, cboMay.EditValue));
                Modules.ObjSystems.MLoadXtraGrid(grdKeHoachSanXuat, grvKeHoachSanXuat, dtmp, false, true, true, true, this.Name);
                for (int i = 0; i < grvKeHoachSanXuat.Columns.Count; i++)
                {
                    if (i > 4)
                    {
                        grvKeHoachSanXuat.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                        grvKeHoachSanXuat.Columns[i].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    }
                }
            }
            catch
            {
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (grvKeHoachSanXuat.RowCount == 0)
            {
                Modules.msgChung(ThongBao.msgKhongCoDuLieuIn);
                return;
            }
            InDuLieu();
        }
        private void InDuLieu()
        {
            string sPath = "";
            sPath = Commons.Modules.MExcel.SaveFiles("Excel file (*.xlsx)|*.xlsx");
            if (sPath == "") return;
            //this.Cursor = Cursors.WaitCursor;
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.DisplayAlerts = true;
            Excel.Range title;
            int TCot = grvKeHoachSanXuat.Columns.Count;
            int TDong = grvKeHoachSanXuat.RowCount;
            int Dong = 1;
            excelApplication.Visible = false;
            //grvKeHoachSanXuat.ActiveFilter.Clear();
            XlsxExportOptions xlsxExportOptions = new XlsxExportOptions()
            {
                ExportMode = XlsxExportMode.SingleFile,
                ShowGridLines = true,
                TextExportMode = TextExportMode.Text,
                FitToPrintedPageHeight = true
            };
            grvKeHoachSanXuat.ExportToXlsx(sPath, xlsxExportOptions);
            System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Excel.Workbooks excelWorkbooks = excelApplication.Workbooks;
            Excel.Workbook excelWorkbook = excelWorkbooks.Open(sPath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", false, false, 0, true);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1];
            try
            {
                excelApplication.Cells.Borders.LineStyle = 0;
                excelApplication.Cells.Font.Name = "Tahoma";
                excelApplication.Cells.Font.Size = 10;
                excelWorkSheet.AutoFilterMode = false;
                excelWorkSheet.Application.ActiveWindow.FreezePanes = false;
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 2, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 5, Dong);
                Dong = 5;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TieuDeKeHoachSanXuat", Commons.Modules.TypeLanguage)
                    , Dong, 2, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot, 25);
                Dong = 7;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "" + lblMay.Text + "" + ": " + cboMay.Text, Dong,1, "@", 9, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot, 16);
                Dong = 9;
                //thêm ghi chú
                Commons.Modules.MExcel.DinhDang(excelWorkSheet,lblTuan.Text, Dong, 5);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "lblNgay", Commons.Modules.TypeLanguage), Dong+1, 5);

                for (int i = 1; i <= 5; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, i, Dong + 1, i);
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    title.Interior.Color = Color.FromArgb(204,204, 255);
                    title.Font.Bold = true;
                    if (i < 5)
                    {
                        title.MergeCells = true;
                    }
                }
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, cboTuan.Text , Dong,6,"@",9,true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter,true,Dong,13,13);

                Dong = 11;
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21, "@", true, Dong, 1, Dong + TDong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong, 2, Dong + TDong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 35, "@", true, Dong, 3, Dong + TDong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 8, "#,##0", true, Dong, 4, Dong + TDong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 14, "@", true, Dong, 5, Dong + TDong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 11, "@", true, Dong, 6, Dong + TDong, 13);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21, "@", true, 1, 1, 1, 1);
                excelWorkbook.Save();
                excelApplication.Visible = true;
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkSheet);
                Commons.Modules.ObjSystems.MReleaseObject(excelWorkbook);
                Commons.Modules.ObjSystems.MReleaseObject(excelApplication);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "InKhongThanhCong", Commons.Modules.TypeLanguage) + ": " + ex.Message);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void cboTuan_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            Loadgrdata();

        }

        private void grvKeHoachSanXuat_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "MS_MAY":
                    {
                        string value1 = Convert.ToString(grvKeHoachSanXuat.GetRowCellValue(e.RowHandle1, e.Column));
                        string value2 = Convert.ToString(grvKeHoachSanXuat.GetRowCellValue(e.RowHandle2, e.Column));

                        if (value1 == value2)
                        {
                            e.Merge = true;
                            e.Handled = true;
                        }
                        else
                        {
                            e.Merge = false;
                            e.Handled = true;
                        }
                        break;
                    }
                case "ItemCode":
                case "ItemName":
                    {
                        string value1 = Convert.ToString(grvKeHoachSanXuat.GetRowCellValue(e.RowHandle1, e.Column));
                        string value2 = Convert.ToString(grvKeHoachSanXuat.GetRowCellValue(e.RowHandle2, e.Column));
                        string value3 = Convert.ToString(grvKeHoachSanXuat.GetRowCellValue(e.RowHandle1, "MS_MAY"));
                        string value4 = Convert.ToString(grvKeHoachSanXuat.GetRowCellValue(e.RowHandle2, "MS_MAY"));

                        if (value1 == value2 && value3 == value4)
                        {
                            e.Merge = true;
                            e.Handled = true;
                        }
                        else
                        {
                            e.Merge = false;
                            e.Handled = true;
                        }
                        break;
                    }

                case "PPH":
                    {
                        string value1 = Convert.ToString(grvKeHoachSanXuat.GetRowCellValue(e.RowHandle1, e.Column));
                        string value2 = Convert.ToString(grvKeHoachSanXuat.GetRowCellValue(e.RowHandle2, e.Column));
                        string value3 = Convert.ToString(grvKeHoachSanXuat.GetRowCellValue(e.RowHandle1, "MS_MAY"));
                        string value4 = Convert.ToString(grvKeHoachSanXuat.GetRowCellValue(e.RowHandle2, "MS_MAY"));
                        string value5 = Convert.ToString(grvKeHoachSanXuat.GetRowCellValue(e.RowHandle1, "ItemCode"));
                        string value6 = Convert.ToString(grvKeHoachSanXuat.GetRowCellValue(e.RowHandle2, "ItemCode"));
                        if (value1 == value2 && value3 == value4 && value5 == value6)
                        {
                            e.Merge = true;
                            e.Handled = true;
                        }
                        else
                        {
                            e.Merge = false;
                            e.Handled = true;
                        }
                        break;
                    }
                default:
                    {
                        e.Merge = false;
                        e.Handled = true;
                    }
                    break;
            }

        }

        private void grvKeHoachSanXuat_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.VisibleIndex >4  && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                string resulst = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Name_Resulst").ToString();
                decimal price;
                 price = Convert.ToDecimal(e.Value.ToString() == "" ? 0 :e.Value);
                switch (resulst)
                {
                    case "EFF": { e.DisplayText = string.Format("{0:0%}", price); break; }
                    default:
                        {
                            e.DisplayText = string.Format("{0:n2}", price);
                            break;
                        }
                }
            }
        }
    }
}
