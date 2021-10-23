using System;
using System.Data;
using DevExpress.XtraEditors;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DevExpress.XtraGrid;

namespace VS.OEE
{
    public partial class ucBaoCaoTienDoSanXuat : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoTienDoSanXuat()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void ucBaoCaoTienDoSanXuat_Load(object sender, EventArgs e)
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
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetBaoCaoTienDoSanXuat", cboNhaXuong.EditValue, cboLoaiMay.EditValue, datTuNgay.DateTime, datDenNgay.DateTime, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                if (grdTienDoSanXoat.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdTienDoSanXoat, grvTienDoSanXoat, dtmp, false, true, true, true, this.Name);
                    grvTienDoSanXoat.Columns["KLQD"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTienDoSanXoat.Columns["KLQD"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvTienDoSanXoat.Columns["PTTH"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTienDoSanXoat.Columns["PTTH"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvTienDoSanXoat.Columns["SLCSX"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTienDoSanXoat.Columns["SLCSX"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvTienDoSanXoat.Columns["SLGCSX"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTienDoSanXoat.Columns["SLGCSX"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    //grvTienDoSanXoat.Columns["PTCTH"].DisplayFormat.FormatType = FormatType.Numeric;
                    //grvTienDoSanXoat.Columns["PTCTH"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvTienDoSanXoat.Columns["SoCaSX"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTienDoSanXoat.Columns["SoCaSX"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvTienDoSanXoat.Columns["PlannedQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTienDoSanXoat.Columns["PlannedQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;


                    for (int i = 2; i < grvTienDoSanXoat.Columns.Count; i++)
                    {
                        grvTienDoSanXoat.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    }
                }
                else
                {
                    grdTienDoSanXoat.DataSource = dtmp;
                }
                if (grdBaoCaoTienDoView.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdBaoCaoTienDoView, grvBaoCaoTienDoView, dtmp, false, true, true, true, this.Name);
                    grvBaoCaoTienDoView.Columns["KLQD"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBaoCaoTienDoView.Columns["KLQD"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvBaoCaoTienDoView.Columns["PTTH"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBaoCaoTienDoView.Columns["PTTH"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvBaoCaoTienDoView.Columns["SLCSX"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBaoCaoTienDoView.Columns["SLCSX"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvBaoCaoTienDoView.Columns["SLGCSX"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBaoCaoTienDoView.Columns["SLGCSX"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    //grvBaoCaoTienDoView.Columns["PTCTH"].DisplayFormat.FormatType = FormatType.Numeric;
                    //grvBaoCaoTienDoView.Columns["PTCTH"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvBaoCaoTienDoView.Columns["SoCaSX"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBaoCaoTienDoView.Columns["SoCaSX"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvBaoCaoTienDoView.Columns["PlannedQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvBaoCaoTienDoView.Columns["PlannedQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    //fort mart group

                    grvBaoCaoTienDoView.ClearGrouping();
                    grvBaoCaoTienDoView.BeginSort();
                    try
                    {
                        GridColumn col1 = grvBaoCaoTienDoView.Columns["Code"];
                        GridColumn col2 = grvBaoCaoTienDoView.Columns["ItemCode"];
                        grvBaoCaoTienDoView.ClearGrouping();
                        col1.GroupIndex = 0;
                        col2.GroupIndex = 1;
                    }
                    finally
                    {
                        grvBaoCaoTienDoView.EndSort();
                    }
                    grvBaoCaoTienDoView.ExpandAllGroups();

                    GridGroupSummaryItem item = new GridGroupSummaryItem();
                    
                    item = new GridGroupSummaryItem();
                    item.FieldName = "PlannedQuantity";
                    item.ShowInGroupColumnFooter = grvBaoCaoTienDoView.Columns["PlannedQuantity"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvBaoCaoTienDoView.GroupSummary.Add(item);

                    item = new GridGroupSummaryItem();
                    item.FieldName = "KLQD";
                    item.ShowInGroupColumnFooter = grvBaoCaoTienDoView.Columns["KLQD"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvBaoCaoTienDoView.GroupSummary.Add(item);

                    item = new GridGroupSummaryItem();
                    item.FieldName = "ActualQuantity";
                    item.ShowInGroupColumnFooter = grvBaoCaoTienDoView.Columns["ActualQuantity"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvBaoCaoTienDoView.GroupSummary.Add(item);

                    item = new GridGroupSummaryItem();
                    item.FieldName = "SLCSX";
                    item.ShowInGroupColumnFooter = grvBaoCaoTienDoView.Columns["SLCSX"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvBaoCaoTienDoView.GroupSummary.Add(item);


                    item = new GridGroupSummaryItem();
                    item.FieldName = "SLGCSX";
                    item.ShowInGroupColumnFooter = grvBaoCaoTienDoView.Columns["SLGCSX"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvBaoCaoTienDoView.GroupSummary.Add(item);


                    item = new GridGroupSummaryItem();
                    item.FieldName = "SoCaSX";
                    item.ShowInGroupColumnFooter = grvBaoCaoTienDoView.Columns["SoCaSX"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvBaoCaoTienDoView.GroupSummary.Add(item);




                    item = new GridGroupSummaryItem();
                    item.FieldName = "SoCaSX";
                    item.ShowInGroupColumnFooter = grvBaoCaoTienDoView.Columns["SoCaSX"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvBaoCaoTienDoView.GroupSummary.Add(item);




                    item = new GridGroupSummaryItem();
                    item.FieldName = "PrOrNumber";
                    item.ShowInGroupColumnFooter = grvBaoCaoTienDoView.Columns["PrOrNumber"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    item.DisplayFormat = "Tổng";
                    grvBaoCaoTienDoView.GroupSummary.Add(item);

                    for (int i = 2; i < grvTienDoSanXoat.Columns.Count; i++)
                    {
                        grvBaoCaoTienDoView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    }
                }
                else
                {
                    grdBaoCaoTienDoView.DataSource = dtmp;
                }

            }
            catch
            {
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (grvTienDoSanXoat.RowCount == 0)
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
            int TCot = grvTienDoSanXoat.Columns.Count;
            int TDong = grvTienDoSanXoat.RowCount;
            int Dong = 1;

            excelApplication.Visible = false;
            grvTienDoSanXoat.ActiveFilter.Clear();
            grvTienDoSanXoat.ExportToXlsx(sPath);

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
                    this.Name, "TieuDeTienDoSanXuat", Commons.Modules.TypeLanguage)
                    , Dong, 2, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 1, 25);

                Dong = 6;

                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "" + lblDiaDiem.Text + "" + ": " + cboNhaXuong.Text, Dong, 4, "@", 9, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, (TCot / 2), 15);
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, "" + lblLoaiMay.Text + "" + ": " + cboLoaiMay.Text, Dong, (TCot / 2) + 1, "@", 9, true, Excel.XlHAlign.xlHAlignLeft, Excel.XlVAlign.xlVAlignCenter, true, Dong, TCot - 2, 15);



                Dong = Dong + 2;
                //format colums header
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong, 6);
                title.Merge(true);
                title.Value2 = "" + lblTuNgay.Text + "" + ": " + datTuNgay.Text + "     " + lblDenNgay.Text + ": " + datDenNgay.Text + "";
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 7, Dong, 9);
                title.Merge(true);
                title.Value2 = "Kế hoạch Quantity Planned";
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 10, Dong, TCot - 1);
                title.Merge(true);
                title.Value2 = "Kế hoạch sản xuất production results";

                //Tô mầu table
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 1, TCot - 1);
                title.Interior.Color = Color.FromArgb(155, 194, 230);

                //Tô mầu table
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, TCot, Dong + 1, TCot);
                title.Interior.Color = Color.FromArgb(219, 153, 249);
                title.MergeCells = true;

                //toboder
                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong, 1, Dong + 1, TCot);
                title.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                title.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                title.Borders.LineStyle = 1;
                title.Font.Bold = true;
                title.WrapText = true;
                title.RowHeight = 35;
                //định dạng colums
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21, "@", true, Dong + 2, 1, Dong + 2 + TDong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong + 2, 2, Dong + 2 + TDong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "@", true, Dong + 2, 3, Dong + 2 + TDong, 3);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 40, "@", true, Dong + 2, 4, Dong + 2 + TDong, 4);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 2, 5, Dong + 2 + TDong, 5);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "@", true, Dong + 2, 6, Dong + 2 + TDong, 6);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "#,##0.00", true, Dong + 2, 7, Dong + 2 + TDong, 7);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "#,##0", true, Dong + 2, 8, Dong + 2 + TDong, 8);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "#,##0.00", true, Dong + 2, 9, Dong + 2 + TDong, 9);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "#,##0.00", true, Dong + 2, 10, Dong + 2 + TDong, 10);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 7, "#,##0.00", true, Dong + 2, 11, Dong + 2 + TDong, 11);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "#,##0.00", true, Dong + 2, 12, Dong + 2 + TDong, 12);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 10, "#,##0.00", true, Dong + 2, 13, Dong + 2 + TDong, 13);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 12, "#,##0.00", true, Dong + 2, 14, Dong + 2 + TDong, 14);
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

        private void grvTienDoSanXoat_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            GridColumn colTEN_HE_THONG = view.Columns["TEN_HE_THONG"];
            if (e.Column == colTEN_HE_THONG)
            {
                string text1 = view.GetRowCellDisplayText(e.RowHandle1, colTEN_HE_THONG);
                string text2 = view.GetRowCellDisplayText(e.RowHandle2, colTEN_HE_THONG);
                e.Merge = (text1 == text2);
                e.Handled = true;
            }
            else
            {
                return;
            }
        }

        private void datTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            Loadgrdata();
        }
    }
}
