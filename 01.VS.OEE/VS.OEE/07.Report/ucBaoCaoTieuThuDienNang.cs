using System;
using System.Data;
using DevExpress.XtraEditors;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;

namespace VS.OEE
{
    public partial class ucBaoCaoTieuThuDienNang : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoTieuThuDienNang()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void ucBaoCaoTieuThuDienNang_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            datTuNgay.DateTime = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
            datDenNgay.DateTime = DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Date.Day);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMay, Commons.Modules.ObjSystems.DataMay(true), "MS_MAY", "TEN_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_MAY"));
            Loadgrdata();
            Commons.Modules.sId = "";
        }
        private void Loadgrdata()
        {
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetBaoCaoTieuThuDienNang", cboMay.EditValue, datTuNgay.DateTime, datDenNgay.DateTime, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Modules.ObjSystems.MLoadXtraGrid(grdTongHopHieuXuat, grvTongHopHieuXuat, dtmp, false, true, true, true, this.Name);
                grvTongHopHieuXuat.Columns["W"].DisplayFormat.FormatType = FormatType.Numeric;
                grvTongHopHieuXuat.Columns["W"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                //for (int i = grvTongHopHieuXuat.Columns.Count - 4; i < grvTongHopHieuXuat.Columns.Count; i++)
                //{
                //    grvTongHopHieuXuat.Columns[i].AppearanceHeader.BackColor = Color.BlueViolet;
                //}
            }
            catch
            {

            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (grvTongHopHieuXuat.RowCount == 0)
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
                excelWorkSheet.AutoFilterMode = false;
                excelWorkSheet.Application.ActiveWindow.FreezePanes = false;
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 2, 1, TCot);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 4, Dong);
                Dong = 4;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TieuDeTongHopHieuXuat", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 1, 25);
                Dong = 6;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "" + lblTuNgay.Text + "" + ": " + datTuNgay.Text +" - "+ lblDenNgay.Text + "" + ": " + datDenNgay.Text, Dong, 1 , "@", 9, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong,TCot, 15);

                Dong= 7;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, lblMay.Text + "" + ": " + cboMay.Text, Dong, 1, "@", 9, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot, 15);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 2, 1, Dong + 2, TCot);
                title.Font.Bold = true;
                title.WrapText = true;
                title.RowHeight = 22;
                title.Interior.Color = Color.FromArgb(141, 180, 226);

                //thêm ghi chú
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21, "@", true,Dong, 1, Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong, 2, Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong, 3, Dong, TCot);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong+3,1, Dong+3+TDong, 1);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

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
