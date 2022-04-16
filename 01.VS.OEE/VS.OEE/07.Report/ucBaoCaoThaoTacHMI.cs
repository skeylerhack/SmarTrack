using System;
using System.Data;
using DevExpress.XtraEditors;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace VS.OEE
{
    public partial class ucBaoCaoThaoTacHMI : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoThaoTacHMI()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void ucBaoCaoThaoTacHMI_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            datTuNgay.DateTime = DateTime.Now.Date;
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMay, Commons.Modules.ObjSystems.DataMay(false), "MS_MAY", "TEN_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_MAY"));
            Loadgrdata();
            Commons.Modules.sId = "";
        }
        private void Loadgrdata()
        {
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetThaoTacHMI", cboMay.EditValue, datTuNgay.DateTime));
                Modules.ObjSystems.MLoadXtraGrid(grdThaoTacHMI, grvThaoTacHMI, dtmp, false, true, true, true, this.Name);
                grvThaoTacHMI.Columns["TT"].Visible = false;
            }
            catch
            {
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (grvThaoTacHMI.RowCount == 0)
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
            int TCot = grvThaoTacHMI.Columns.Count - 1;
            int TDong = grvThaoTacHMI.RowCount;
            int Dong = 1;
            excelApplication.Visible = false;
            grvThaoTacHMI.ActiveFilter.Clear();
            grvThaoTacHMI.ExportToXlsx(sPath);
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
                    this.Name, "TieuDeBaoCaoThaoTacNguoiDung", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 1, 25);
                Dong = 6;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "" + lblTuNgay.Text + "" + ": " + datTuNgay.Text, Dong, 1, "@", 9, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot, 15);

                Dong = 7;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, lblMay.Text + "" + ": " + cboMay.Text, Dong, 1, "@", 9, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot, 15);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 2, 1, Dong + 2, TCot);
                title.Font.Bold = true;
                title.WrapText = true;
                title.RowHeight = 22;
                title.Interior.Color = Color.FromArgb(141, 180, 226);

                //thêm ghi chú
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21, "@", true, Dong, 1, Dong, 1);
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 3, 1, Dong + 3 + TDong, 1);
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

        private void grvThaoTacHMI_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                int category = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, "TT"));
                if (category == 1)
                {

                    e.Appearance.BackColor = Color.LawnGreen;
                    e.Appearance.BackColor2 = Color.Honeydew;
                    e.HighPriority = true;
                }
                if (category == 2)
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                    e.HighPriority = true;
                }
            }
        }
    }
}
