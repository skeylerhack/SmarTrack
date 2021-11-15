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
    public partial class ucBaocaoPareto : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaocaoPareto()
        {
            InitializeComponent();
        }
        private void ucBaocaoPareto_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            datTuNgay.DateTime = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
            datDenNgay.DateTime = DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Date.Day);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiNguyenNhan, Commons.Modules.ObjSystems.DataLoaiNguyenNhan(true), "ID", "DownTimeTypeName", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "DownTimeTypeName"), false);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDacDiem, Commons.Modules.ObjSystems.DataPlanned(true), "ID", "StopTypeName", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "StopTypeName"));
            Commons.Modules.ObjSystems.MLoadTreeLookUpEdit(cboNhaXuong, Commons.Modules.ObjSystems.DataNhaXuongTree(true), "MS_N_XUONG", "TEN_N_XUONG", "MS_CHA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_N_XUONG"));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiMay, Commons.Modules.ObjSystems.DataLoaiTB(true), "MS_LOAI_MAY", "TEN_LOAI_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_LOAI_MAY"));
            cboNhaXuong.EditValue = "-1";
            LoadgrdMayPar();
            LoadgrdNguyenNhanPar();
            //LoadgrdPareto();
            Commons.Modules.sId = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
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
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdMayPar, grvMayPar, dt, true, false, true, true, true, "");
            grvMayPar.Columns["CHON"].Visible = false;
            grvMayPar.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            grvMayPar.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            grvMayPar.OptionsSelection.CheckBoxSelectorField = "CHON";
            grvMayPar.ExpandAllGroups();
        }
        private void LoadgrdNguyenNhanPar()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListChosseNguyenNhanPro", cboLoaiNguyenNhan.EditValue, cboDacDiem.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            //update data table những cái nào chọn ở dưới
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ReadOnly = true;
            }
            dt.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNguyenNhanPar, grvNguyenNhanPar, dt, true, false, true, true, true, "");
            grvNguyenNhanPar.Columns["CHON"].Visible = false;
            grvNguyenNhanPar.Columns["MS_NGUYEN_NHAN"].Visible = false;
            grvNguyenNhanPar.Columns["DownTimeTypeID"].Visible = false;
            grvNguyenNhanPar.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            grvNguyenNhanPar.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            grvNguyenNhanPar.OptionsSelection.CheckBoxSelectorField = "CHON";
            grvNguyenNhanPar.ExpandAllGroups();
        }

        private void LoadgrdPareto()
        {
            try
            {
                DataTable dt = new DataTable();
                //lấy bảng tạm chọn máy
                try
                {
                    dt = Commons.Modules.ObjSystems.ConvertDatatable(grdMayPar).AsEnumerable().Where(x => x.Field<bool>("CHON") == true).CopyToDataTable();
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "sBTMay" + Modules.UserName, dt, "");
                }
                catch
                {
                    Modules.msgform(this.Name, "MsgBanChuaChonMay");
                    return;
                }
                //láy bản tạm chọn nguyên nhân
                try
                {
                    dt = new DataTable();
                    dt = Commons.Modules.ObjSystems.ConvertDatatable(grdNguyenNhanPar).AsEnumerable().Where(x => x.Field<bool>("CHON") == true).CopyToDataTable();
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "sBTNguyenNhan" + Modules.UserName, dt, "");
                }
                catch
                {
                    Modules.msgform(this.Name, "MsgBanChuaChonNguyenNhan");
                    return;
                }
                //tạo bản tạm chọn máy

                //update data table những cái nào chọn ở dưới
                dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListPareto", datTuNgay.DateTime, datDenNgay.DateTime, "sBTMay" + Modules.UserName, "sBTNguyenNhan" + Modules.UserName, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                if (grdPareto.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdPareto, grvPareto, dt,false, true, true, true,true, this.Name);
                    grvPareto.OptionsCustomization.AllowGroup = true;
                    grvPareto.ClearGrouping();
                    grvPareto.BeginSort();
                    try
                    {
                        GridColumn col1 = grvPareto.Columns["TEN_MAY"];
                        grvPareto.ClearGrouping();
                        col1.GroupIndex = 0;
                    }
                    finally
                    {
                        grvPareto.EndSort();
                    }
                    grvPareto.ExpandAllGroups();

                    GridGroupSummaryItem item = new GridGroupSummaryItem();
                    item.FieldName = "TONG_SO_PHUT";
                    item.ShowInGroupColumnFooter = grvPareto.Columns["TONG_SO_PHUT"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "{0:N2}";
                    grvPareto.GroupSummary.Add(item);
                }
                else
                {
                    grdPareto.DataSource = dt;
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
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, ("TieuDeBaoCaoPareto"), Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 14, FontStyle.Bold);
            //
            RectangleF rec2 = new RectangleF(200, 40, 300, 25);
            e.Graph.DrawString(lblTuNgay.Text + " : " + datTuNgay.Text, Color.Black, rec2, BorderSide.None);

            RectangleF rec21 = new RectangleF(500, 40, 300, 25);
            e.Graph.DrawString(lblDenNgay.Text + " : " + datDenNgay.Text, Color.Black, rec21, BorderSide.None);

            RectangleF rec5 = new RectangleF(300,60, 500,10);
            e.Graph.DrawString("", Color.Transparent, rec5, BorderSide.None);


        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (grvPareto.RowCount == 0)
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
                composLink.CreateReportHeaderArea += new CreateAreaEventHandler(composLink_CreateReportHeaderArea);//tieu de + logo           

                PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
                link.Component = this.grdPareto;
                composLink.Links.Add(link);
                composLink.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void cboNhaXuong_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadgrdMayPar();
        }

        private void cboLoaiNguyenNhan_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadgrdNguyenNhanPar();
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadgrdPareto();
            //if(grvPareto.RowCount == 0)
            //{
            //    btnIn.Visible = false;
            //}
            //else
            //{
            //    btnIn.Visible = true;
            //}
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
