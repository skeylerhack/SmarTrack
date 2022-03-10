using System;
using System.Data;
using DevExpress.XtraEditors;
using Commons;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using Microsoft.ApplicationBlocks.Data;
using System.Drawing;
using System.IO;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
namespace VS.OEE
{
    public partial class ucBaoCaoTinhHinhSanXuat : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoTinhHinhSanXuat()
        {
            InitializeComponent();
        }
        private void ucBaoCaoTinhHinhSanXuat_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            datTuNgay.DateTime = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
            datDenNgay.DateTime = DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Date.Day);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTo, Commons.Modules.ObjSystems.DataOpetator(true), "ID", "OperatorName", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "OperatorName"), false);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMay, Commons.Modules.ObjSystems.DataMay(true), "MS_MAY", "TEN_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_MAY"), false);
            Loadgrdata(true);
            Commons.Modules.sId = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void Loadgrdata(bool iLoad)
        {
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetBaoCaoChiTiet", cboTo.EditValue, cboMay.EditValue, datTuNgay.DateTime, datDenNgay.DateTime, Commons.Modules.UserName, Commons.Modules.TypeLanguage, rdoDK.SelectedIndex));
                if (iLoad == true)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdTinhHinhSanXuat, grvTinhHinhSanXuat, dtmp, true, true, true, true, this.Name);
                    grvTinhHinhSanXuat.GroupSummary.Clear();
                    grvTinhHinhSanXuat.OptionsCustomization.AllowGroup = true;
                    grvTinhHinhSanXuat.ClearGrouping();
                    grvTinhHinhSanXuat.BeginSort();
                    try
                    {
                        GridColumn col1 = grvTinhHinhSanXuat.Columns["OperatorName"];
                        GridColumn col2 = grvTinhHinhSanXuat.Columns["TEN_MAY"];
                        grvTinhHinhSanXuat.ClearGrouping();
                        col1.GroupIndex = 0;
                        col2.GroupIndex = 1;
                        if (rdoDK.SelectedIndex != 0)
                        {
                            grvTinhHinhSanXuat.Columns["ItemID"].Visible = false;
                            grvTinhHinhSanXuat.Columns["StartTime"].Width = 200;
                        }
                    }
                    finally
                    {
                        grvTinhHinhSanXuat.EndSort();
                    }
                    grvTinhHinhSanXuat.ExpandAllGroups();

                    GridGroupSummaryItem item = new GridGroupSummaryItem();
                    item.FieldName = "NPH";
                    item.ShowInGroupColumnFooter = grvTinhHinhSanXuat.Columns["NPH"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvTinhHinhSanXuat.GroupSummary.Add(item);

                    item = new GridGroupSummaryItem();
                    item.FieldName = "TH";
                    item.ShowInGroupColumnFooter = grvTinhHinhSanXuat.Columns["TH"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvTinhHinhSanXuat.GroupSummary.Add(item);

                    item = new GridGroupSummaryItem();
                    item.FieldName = "DT";
                    item.ShowInGroupColumnFooter = grvTinhHinhSanXuat.Columns["DT"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvTinhHinhSanXuat.GroupSummary.Add(item);

                    item = new GridGroupSummaryItem();
                    item.FieldName = "GPH";
                    item.ShowInGroupColumnFooter = grvTinhHinhSanXuat.Columns["GPH"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvTinhHinhSanXuat.GroupSummary.Add(item);

                    item = new GridGroupSummaryItem();
                    item.FieldName = "EL";
                    item.ShowInGroupColumnFooter = grvTinhHinhSanXuat.Columns["EL"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvTinhHinhSanXuat.GroupSummary.Add(item);

                    item = new GridGroupSummaryItem();
                    item.FieldName = "ItemName";
                    item.ShowInGroupColumnFooter = grvTinhHinhSanXuat.Columns["ItemName"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    item.DisplayFormat = Commons.Modules.ObjLanguages.GetLanguage("frmChung", "lblTong");
                    grvTinhHinhSanXuat.GroupSummary.Add(item);

                    item = new GridGroupSummaryItem();
                    item.FieldName = "ELV";
                    item.ShowInGroupColumnFooter = grvTinhHinhSanXuat.Columns["ELV"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvTinhHinhSanXuat.GroupSummary.Add(item);

                    item = new GridGroupSummaryItem();
                    item.FieldName = "ELP";
                    item.ShowInGroupColumnFooter = grvTinhHinhSanXuat.Columns["ELP"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvTinhHinhSanXuat.GroupSummary.Add(item);

                }
                else
                {
                    grdTinhHinhSanXuat.DataSource = dtmp;
                }
            }
            catch
            { }
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
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, (rdoDK.SelectedIndex == 0 ? "TieuDeTongQuat" : "TieuDeChiTiet"), Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 14, FontStyle.Bold);
            //
            RectangleF rec2 = new RectangleF(200, 40, 300, 25);
            e.Graph.DrawString(lblTuNgay.Text + " : " + datTuNgay.Text, Color.Black, rec2, BorderSide.None);

            RectangleF rec21 = new RectangleF(500, 40, 300, 25);
            e.Graph.DrawString(lblDenNgay.Text + " : " + datDenNgay.Text, Color.Black, rec21, BorderSide.None);


            RectangleF rec3 = new RectangleF(200, 65, 300, 25);
            e.Graph.DrawString(lblTo.Text + " : " + cboTo.Text, Color.Black, rec3, BorderSide.None);
            RectangleF rec31 = new RectangleF(500, 65, 300, 25);
            e.Graph.DrawString(lblMay.Text + " : " + cboMay.Text, Color.Black, rec31, BorderSide.None);



            RectangleF rec5 = new RectangleF(300, 110, 500, 10);
            e.Graph.DrawString("", Color.Transparent, rec5, BorderSide.None);


        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (grvTinhHinhSanXuat.RowCount == 0)
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
                link.Component = this.grdTinhHinhSanXuat;
                composLink.Links.Add(link);
                composLink.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }

        }

        private void rdoDK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            if (rdoDK.SelectedIndex == 0)
            {
                grvTinhHinhSanXuat.Tag = "grvTinhHinhSanXuat";
            }
            else
            {
                grvTinhHinhSanXuat.Tag = "grvTinhHinhSanXuatCT";
            }
            Loadgrdata(true);
        }

        private void datTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            Loadgrdata(false);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
