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

namespace VS.OEE
{
    public partial class ucBaocaoDoThiOEE : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaocaoDoThiOEE()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void ucBaocaoDoThiOEE_Load(object sender, EventArgs e)
        {
            datNam.DateTime = DateTime.Now;
            Commons.Modules.sId = "0Load";
            Commons.Modules.ObjSystems.MLoadTreeLookUpEdit(cboNhaXuong, Commons.Modules.ObjSystems.DataNhaXuongTree(true), "MS_N_XUONG", "TEN_N_XUONG", "MS_CHA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_N_XUONG"));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiMay, Commons.Modules.ObjSystems.DataLoaiTB(true), "MS_LOAI_MAY", "TEN_LOAI_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_LOAI_MAY"));
            LoadgrdMayPar();
            LoadDoThi();
            cboNhaXuong.EditValue = "-1";
            Commons.Modules.sId = "";
        }
        private void LoadDoThi()
        {
            DataTable dt = new DataTable();
            //lấy bảng tạm chọn máy
            try
            {
                dt = Commons.Modules.ObjSystems.ConvertDatatable(grdMayDTOEE).AsEnumerable().Where(x => x.Field<bool>("CHON") == true).CopyToDataTable();
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "sBTMay" + Modules.UserName, dt, "");
            }
            catch
            {
                chartControl1.Series.Clear();
                return;
            }
            chartControl1.Series.Clear();
            dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetBaoCaoDoThiOEE",datNam.DateTime.Year, "-1", "-1", "sBTMay" + Modules.UserName, Commons.Modules.UserName, Commons.Modules.TypeLanguage));

            Commons.Modules.ObjSystems.MLoadXtraGrid(gridControl1, gridView1, dt, false, false, true,false);
            gridView1.Columns["TEN_MAY"].Caption =  Commons.Modules.ObjLanguages.GetLanguage(this.Name,"TEN_MAY");
            foreach (DataRow item in dt.Rows)
            {
                Series series1 = new Series(item["TEN_MAY"].ToString(), ViewType.Line);
                chartControl1.Series.Add(series1);
                for (int i = 1; i <= dt.Columns.Count - 1; i++)
                {
                    series1.Points.Add(new SeriesPoint(i, item["" + dt.Columns[i].ColumnName + ""].ToString() == "" ? 0 : item["" + dt.Columns[i].ColumnName + ""]));
                }
            }
        }

        private void LoadgrdMayPar()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListChosseMayPro", cboNhaXuong.EditValue, cboLoaiMay.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            //update data table những cái nào chọn ở dưới
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ReadOnly = true;
            }
            dt.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMayDTOEE, grvMayDTOEE, dt, true, false, true, true, true, "");
            grvMayDTOEE.Columns["CHON"].Visible = false;
            grvMayDTOEE.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            grvMayDTOEE.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            grvMayDTOEE.OptionsSelection.CheckBoxSelectorField = "CHON";
            grvMayDTOEE.ExpandAllGroups();
        }

        private void grvMayDTOEE_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            LoadDoThi();
        }

       

        private void grvMayDTOEE_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            LoadDoThi();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (chartControl1.Series.Count ==0)
            {
                Modules.msgChung(ThongBao.msgKhongCoDuLieuIn);
                return;
            }
            try
            {
                CompositeLink composLink = new CompositeLink(new PrintingSystem());
                composLink.Margins.Left = 60;
                composLink.Margins.Right = 60;
                composLink.Margins.Top = 50;
                composLink.Margins.Bottom = 50;

                composLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
                composLink.Landscape = true;

                string leftColumn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sTrang", Commons.Modules.TypeLanguage) + "[Page # of Pages #]";
                string middleColumn = "User: " + Commons.Modules.UserName;
                string rightColumn = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucBaoCaoChung", "sNgayIn", Commons.Modules.TypeLanguage) + "[Date Printed]";

                // Create a PageHeaderFooter object and initializing it with
                // the link's PageHeaderFooter.
                PageHeaderFooter phf = composLink.PageHeaderFooter as PageHeaderFooter;
                // Clear the PageHeaderFooter's contents.
                phf.Footer.Content.Clear();
                // Add custom information to the link's header.
                phf.Footer.Content.AddRange(new string[] { middleColumn, "", leftColumn });
                phf.Footer.LineAlignment = BrickAlignment.Far;



                // Create a PageHeaderFooter object and initializing it with
                // the link's PageHeaderFooter.
                PageHeaderFooter ph = composLink.PageHeaderFooter as PageHeaderFooter;
                // Clear the PageHeaderFooter's contents.
                ph.Header.Content.Clear();
                // Add custom information to the link's header.
                ph.Header.Content.AddRange(new string[] { "", "", rightColumn });
                ph.Header.LineAlignment = BrickAlignment.Far;

                //composLink.Margins.Clone();
                //composLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(composLink_CreateMarginalHeaderArea);//Ngay IN               
                composLink.CreateReportHeaderArea += new CreateAreaEventHandler(composLink_CreateReportHeaderArea);//tieu de + logo           

                PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
                PrintableComponentLink link2 = new PrintableComponentLink(new PrintingSystem());
                link.Component = this.chartControl1;
                link2.Component = this.gridControl1;
                composLink.Links.Add(link);
                composLink.Links.Add(link2);
                composLink.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                composLink.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        public void composLink_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, System.Data.CommandType.Text, " SELECT LOGO FROM THONG_TIN_CHUNG"));
            Byte[] data = new Byte[0];
            data = (Byte[])(dtTmp.Rows[0][0]);
            RectangleF rec1 = new RectangleF(1, 5, 150, 50);
            MemoryStream mem = new MemoryStream(data);
            e.Graph.DrawImage(Image.FromStream(mem), rec1, BorderSide.None, Color.Transparent);
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 18, FontStyle.Bold);
            RectangleF rec = new RectangleF(200, 5, e.Graph.ClientPageSize.Width - 600, 30);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "TieuDeDoThiOEE", Commons.Modules.TypeLanguage) +" " + datNam.DateTime.Year, Color.Black, rec, BorderSide.None);
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 14, FontStyle.Bold);
     

            RectangleF rec3 = new RectangleF(200, 65, 300, 25);
            e.Graph.DrawString(lblDiaDiem.Text + " : " + cboNhaXuong.Text, Color.Black, rec3, BorderSide.None);
            RectangleF rec31 = new RectangleF(500, 65, 300, 25);
            e.Graph.DrawString(lblLoaiMay.Text + " : " + cboLoaiMay.Text, Color.Black, rec31, BorderSide.None);
            RectangleF rec5 = new RectangleF(300, 110, 500, 10);
            e.Graph.DrawString("", Color.Transparent, rec5, BorderSide.None);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void cboNhaXuong_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadgrdMayPar();
            LoadDoThi();
        }

        private void datNam_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadDoThi();
        }
    }
}
