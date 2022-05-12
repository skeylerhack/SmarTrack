using System;
using System.Data;
using DevExpress.XtraEditors;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace VS.OEE
{
    public partial class ucBaoCaoTargetMoldID : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoTargetMoldID()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void ucBaoCaoTargetMoldID_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            this.Cursor = Cursors.WaitCursor;
            Loadgrdata();
            Commons.Modules.ObjSystems.DoiNNTooltip(contextMenuStrip1,this);
            this.Cursor = Cursors.Default;
            Commons.Modules.sId = "";

        }
        private void Loadgrdata()
        {
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetBaoCaoTargetMoldID"));
                if (grdTargetMoldID.DataSource == null)
                {
                    dtmp.Columns["NGAY"].ReadOnly = false;
                    dtmp.Columns["TarGetActual"].ReadOnly = false;
                    dtmp.Columns["SL"].ReadOnly = false;
                    Modules.ObjSystems.MLoadXtraGrid(grdTargetMoldID, grvTargetMoldID, dtmp, true, false, true, true, true, this.Name);
                    grvTargetMoldID.Columns["SL"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTargetMoldID.Columns["SL"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvTargetMoldID.Columns["TarGetActual"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTargetMoldID.Columns["TarGetActual"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvTargetMoldID.Columns["SL"].OptionsColumn.AllowEdit = false;
                    grvTargetMoldID.Columns["MOLD_ID"].OptionsColumn.AllowEdit = false;
                }
                grdTargetMoldID.DataSource = dtmp;
            }
            catch
            {
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (grvTargetMoldID.RowCount == 0)
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
            int TCot = grvTargetMoldID.Columns.Count;
            int TDong = grvTargetMoldID.RowCount;
            int Dong = 1;
            excelApplication.Visible = false;
            grvTargetMoldID.ActiveFilter.Clear();
            grvTargetMoldID.ExportToXlsx(sPath);
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
                Dong = Commons.Modules.MExcel.TaoTTChung(excelWorkSheet, 1, 2, 1, 12);
                Commons.Modules.MExcel.TaoLogo(excelWorkSheet, 0, 0, 110, 45, Application.StartupPath);
                Commons.Modules.MExcel.ThemDong(excelWorkSheet, Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, 1, Dong);
                Dong = 4;
                Commons.Modules.MExcel.DinhDang(excelWorkSheet, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                    this.Name, "TieuDeTargetMold", Commons.Modules.TypeLanguage)
                    , Dong, 1, "@", 16, true, Excel.XlHAlign.xlHAlignCenter, Excel.XlVAlign.xlVAlignCenter, true, Dong, 12 - 1, 25);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong + 2, 1, Dong + 2, TCot);
                title.Font.Bold = true;
                title.WrapText = true;
                title.RowHeight = 22;
                title.Interior.Color = Color.FromArgb(141, 180, 226);

                //thêm ghi chú
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 21, "@", true,Dong, 1, Dong, 1);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 20, "@", true, Dong, 2, Dong, 2);
                Commons.Modules.MExcel.ColumnWidth(excelWorkSheet, 15, "@", true, Dong, 3, Dong, TCot);

                title = Commons.Modules.MExcel.GetRange(excelWorkSheet, Dong+2,1, Dong+2+TDong, 1);
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
        private void grvTargetMoldID_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string sMoldID = grvTargetMoldID.GetFocusedRowCellValue("MOLD_ID").ToString();
                if (e.Column.FieldName == "TarGetActual")
                {
                    //nếu change target
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "IF NOT EXISTS( SELECT * FROM dbo.TargetMold WHERE MOLD_ID ='" + sMoldID + "')INSERT INTO dbo.TargetMold(MOLD_ID, NGAY, TarGetActual) VALUES('" + sMoldID + "', NULL, " + e.Value + ") ELSE UPDATE dbo.TargetMold SET TarGetActual = " + e.Value + " WHERE MOLD_ID = '" + sMoldID + "'");
                }
                //nếu đổi thời gian thì tính lại số lượng
                if (e.Column.FieldName == "NGAY")
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "IF NOT EXISTS( SELECT * FROM dbo.TargetMold WHERE MOLD_ID ='" + sMoldID + "')INSERT INTO dbo.TargetMold(MOLD_ID, NGAY, TarGetActual) VALUES('" + sMoldID + "','" + Convert.ToDateTime(e.Value).ToString("MM/dd/yyyy") + "',NULL) ELSE UPDATE dbo.TargetMold SET NGAY = '" + Convert.ToDateTime(e.Value).ToString("MM/dd/yyyy") + "' WHERE MOLD_ID = '" + sMoldID + "'");
                    //tính lại số lượng

                    double SL = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT ISNULL(SUM(A.ActualQuantity),0) FROM dbo.W_ProductionRunDetails A INNER JOIN dbo.Item B ON A.ItemID = B.ID WHERE  B.Barcode = '" + sMoldID + "' AND dbo.fnGetNgayTheoCa(A.StartTime) > '" + Convert.ToDateTime(e.Value).ToString("MM/dd/yyyy") + "'"));
                    grvTargetMoldID.SetFocusedRowCellValue("SL", SL);
                }
            }
            catch
            {
                
            }
            this.Cursor = Cursors.Default;
        }

        private void grvTargetMoldID_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InDataRow)
                {
                    contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                }
                else
                {
                    contextMenuStrip1.Hide();
                }
            }
            catch
            {
            }
        }

        private void mnuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string sMoldID = grvTargetMoldID.GetFocusedRowCellValue("MOLD_ID").ToString();
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "IF NOT EXISTS( SELECT * FROM dbo.TargetMold WHERE MOLD_ID ='" + sMoldID + "')INSERT INTO dbo.TargetMold(MOLD_ID, NGAY, TarGetActual) VALUES('" + sMoldID + "',GETDATE(),NULL) ELSE UPDATE dbo.TargetMold SET NGAY = GETDATE() WHERE MOLD_ID = '" + sMoldID + "'");
                //tính lại số lượng
                grvTargetMoldID.SetFocusedRowCellValue("NGAY", DateTime.Now.Date);
                //grvTargetMoldID.SetFocusedRowCellValue("SL", 0);
            }
            catch (Exception ex)
            {

            }
        }

        private void grvTargetMoldID_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (Commons.Modules.sId == "0Load" || e.RowHandle < 0) return;
            try
            {
                int target = Convert.ToInt32(grvTargetMoldID.GetRowCellValue(e.RowHandle, "TarGetActual"));
                if (Convert.ToInt32(grvTargetMoldID.GetRowCellValue(e.RowHandle, "SL")) >= target && target > 0)
                {
                    e.Appearance.BackColor = Color.LightPink;
                    e.HighPriority = true;
                }
            }
            catch
            {
                return;
            }
        }
    }
}
