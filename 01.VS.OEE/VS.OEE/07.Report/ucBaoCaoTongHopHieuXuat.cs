using System;
using System.Data;
using DevExpress.XtraEditors;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using System.Drawing;
using System.Windows.Forms;

namespace VS.OEE
{
    public partial class ucBaoCaoTongHopHieuXuat : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoTongHopHieuXuat()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void ucBaoCaoTongHopHieuXuat_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            datTuNgay.DateTime = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
            datDenNgay.DateTime = DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Date.Day);
            Commons.Modules.ObjSystems.MLoadTreeLookUpEdit(cboNhaXuong, Commons.Modules.ObjSystems.DataNhaXuongTree(true), "MS_N_XUONG", "TEN_N_XUONG", "MS_CHA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_N_XUONG"));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiMay, Commons.Modules.ObjSystems.DataLoaiTB(true), "MS_LOAI_MAY", "TEN_LOAI_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_LOAI_MAY"));
            cboNhaXuong.EditValue = "-1";
            Loadgrdata();
            Commons.Modules.sId = "";
        }
        private void Loadgrdata()
        {
            DataTable dtmp = new DataTable();
            try
            {
                    dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetBaoCaoTongHopHieuXuat", cboNhaXuong.EditValue, cboLoaiMay.EditValue, datTuNgay.DateTime, datDenNgay.DateTime, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    Modules.ObjSystems.MLoadXtraGrid(grdTongHopHieuXuat, grvTongHopHieuXuat, dtmp, false, true,true, true, this.Name);

                for (int i = grvTongHopHieuXuat.Columns.Count - 4; i < grvTongHopHieuXuat.Columns.Count; i++)
                {
                    grvTongHopHieuXuat.Columns[i].AppearanceHeader.BackColor = Color.BlueViolet;
                }
            }
            catch
            {
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            if(grvTongHopHieuXuat.RowCount == 0)
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
            Excel.FormatCondition condition;
            int TCot = grvTongHopHieuXuat.Columns.Count;
            int TDong = grvTongHopHieuXuat.RowCount;
            int Dong = 1;
            excelApplication.Visible = false;
            grvTongHopHieuXuat.ActiveFilter.Clear();
            grvTongHopHieuXuat.ExportToXlsx(sPath);
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
                excelWorkSheet.AutoFilterMode =false;
                excelWorkSheet.Application.ActiveWindow.FreezePanes = false;
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 2, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown,4, Dong);
                Dong = 4;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TieuDeTongHopHieuXuat", Commons.Modules.TypeLanguage)
                    , Dong, 2, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 1,25);
                Dong = 6;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "" + lblDiaDiem.Text + "" + ": " + cboNhaXuong.Text, Dong, 4, "@", 9, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot / 2),15);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "" + lblLoaiMay.Text + "" + ": " + cboLoaiMay.Text,Dong, (TCot / 2) + 1, "@", 9, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 3,15);


                //thêm ghi chú
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong - 1, TCot - 2, Dong - 1, TCot - 2);
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#ffc000"));
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "-2% < CL < 0%", Dong - 1, TCot - 1, "@", 9, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong - 1, TCot, 15);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong , TCot - 2, Dong , TCot - 2);
                title.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#e26b0a"));
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "CL <= -2%" , Dong, TCot - 1,"@", 9, false, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot, 15);


                Dong = Dong + 2;
                //format colums header
                 

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 7, Dong, 10);
                title.Merge(true);
                title.Value2 = "Thực tế "+ datTuNgay.DateTime.Year +"";
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.LineStyle = 1;
                title.Font.Bold = true;
                title.WrapText = true;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 11, Dong, TCot);
                title.Merge(true);
                title.Value2 = "Định  mức " + (datTuNgay.DateTime.Year - 1);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.LineStyle = 1;
                title.Interior.Color = Color.FromArgb(228, 183, 181);
                title.Font.Bold = true;
                title.WrapText = true;

                Dong++;
                //Tô mầu table
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong+ TDong+1, 1);
                title.Interior.Color = Color.FromArgb(252, 213, 180);
                title.Font.Bold = true;
                title.WrapText = true;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 2, Dong , 10);
                title.Interior.Color = Color.FromArgb(204, 192, 218);
                title.Font.Bold = true;
                title.WrapText = true;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 11, Dong, TCot);
                title.Interior.Color = Color.FromArgb(230, 184, 183);
                title.Font.Bold = true;
                title.WrapText = true;

                Dong++;
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + TDong, 1, Dong+ TDong, 1);
                title.Value2 = "TỔNG PX:";

         

                for (int i = 2; i <= TCot; i++)
                {
                    title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + TDong, i, Dong + TDong, i);
                    if (i < 7)
                    {
                        title.Value2 = "=SUM(" + Commons.Modules.MExcel.TimDiemExcel(Dong , i) + ":" +
                            Commons.Modules.MExcel.TimDiemExcel(Dong + TDong -1, i) + "";
              
                    }
                    if(i ==7)
                    {
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + TDong, i, Dong + TDong, i);
                        title.Value2 = "=(" + Commons.Modules.MExcel.TimDiemExcel(Dong + TDong, 2) + "/" +
                          Commons.Modules.MExcel.TimDiemExcel(Dong + TDong, 3) + ")*100";

                    }
                    if(i==8)
                    {
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + TDong, i, Dong + TDong, i);
                        title.Value2 = "=(" + Commons.Modules.MExcel.TimDiemExcel(Dong + TDong, 2) + "/" +
                          Commons.Modules.MExcel.TimDiemExcel(Dong + TDong, 4) + ")*100";
                    }
                    if(i==9)
                    {
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + TDong, i, Dong + TDong, i);
                        title.Value2 = "=(" + Commons.Modules.MExcel.TimDiemExcel(Dong + TDong, 5) + "/" +
                          Commons.Modules.MExcel.TimDiemExcel(Dong + TDong, 4) + ")*100";
                    }
                    if(i == 10)
                    {
                        title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + TDong, i, Dong + TDong, i);
                        title.Value2 = "=(" + Commons.Modules.MExcel.TimDiemExcel(Dong + TDong, 6) + "/" +
                          Commons.Modules.MExcel.TimDiemExcel(Dong + TDong, 2) + ")*100";
                    }
                    title.NumberFormat = "#,##0.00";
                    title.ColumnWidth = 10;
                    title.Font.Bold = true;
                    title.Font.Color = Color.Red;
                    title.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                }
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + TDong, 11, Dong + TDong, TCot);
                //lấy table target yer của năm trước
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT OEE,PE,EL,SpeedVar FROM dbo.TargetOfYear WHERE YEAR = " + datTuNgay.DateTime.Year +""));
                Commons.Modules.MExcel.MExportExcel(dt, excelWorkSheet, title,false);


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 7, Dong + TDong, 7);
                condition =(title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlLessEqual, "=K" + Dong + " - 2"));
                condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#e26b0a"));
                condition = (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlBetween, "=K" + Dong + " - 2", "=K" + Dong));
                condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#ffc000"));

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 8, Dong + TDong, 8);
                condition = (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlLessEqual, "=L" + Dong + " - 2"));
                condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#e26b0a"));
                condition = (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlBetween, "=L" + Dong + " - 2", "=L" + Dong));
                condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#ffc000"));

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 9, Dong + TDong, 9);
                condition = (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreater, "=M" + Dong + " +2"));
                condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#e26b0a"));
                condition = (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlBetween, "=M" + Dong,"=M" + Dong + " +2"));
                condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#ffc000"));

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 10, Dong + TDong, 10);
                condition = (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlLessEqual, "=N" + Dong + " - 2"));
                condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#e26b0a"));
                condition = (title.FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlBetween, "=N" + Dong + " - 2", "=N" + Dong));
                condition.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml("#ffc000"));


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong-1,1, Dong + TDong,TCot);
                title.Borders.LineStyle = 1;

                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet,21, "@", true, 1, 1, 1, 1);

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

        private void datTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            Loadgrdata();
        }
    }
}
