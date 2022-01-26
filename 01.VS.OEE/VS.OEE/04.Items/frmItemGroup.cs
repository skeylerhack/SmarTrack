using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Reflection;
using Commons;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using Microsoft.ApplicationBlocks.Data;
using System.Drawing;
using System.IO;


namespace VS.OEE
{
    public partial class frmItemGroup : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        public frmItemGroup(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
            LockControl(true);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void frmItemGroup_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData(-1);
                LoadText(false);
                if (iPQ != 1)
                {
                    this.btnThem.Visible = false;
                    this.btnSua.Visible = false;
                    this.btnXoa.Visible = false;
                    this.btnGhi.Visible = false;
                    this.btnKhong.Visible = false;
                }
                txtGroupName.Properties.MaxLength = 250;
                txtGroupNameA.Properties.MaxLength = 250;
                txtGroupNameH.Properties.MaxLength = 250;
                txtNote.Properties.MaxLength = 500;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LockControl(Boolean bLock)
        {


            txtGroupName.Properties.ReadOnly = bLock;
            txtGroupNameA.Properties.ReadOnly = bLock;
            txtGroupNameH.Properties.ReadOnly = bLock;
            txtNote.Properties.ReadOnly = bLock;

            txtSearch.ReadOnly = !bLock;
            grdGroupUOM.Enabled = bLock;

            this.btnThem.Visible = bLock;
            this.btnSua.Visible = bLock;
            this.btnXoa.Visible = bLock;
            this.btnThoat.Visible = bLock;
            this.btnGhi.Visible = !bLock;
            this.btnKhong.Visible = !bLock;
        }
        private void LoadText(Boolean nullText)
        {
            if (grvGroupUOM == null) return;
            if (grvGroupUOM.RowCount == 0) nullText = true;
            try
            {
                txtID.Text = (nullText ? "-1" : Modules.ToInt64(grvGroupUOM.GetFocusedRowCellValue("ID")).ToString());
                txtGroupName.Text = (nullText ? "" : Modules.ToStr(grvGroupUOM.GetFocusedRowCellValue("ItemGroupName")));
                txtGroupNameA.Text = (nullText ? "" : Modules.ToStr(grvGroupUOM.GetFocusedRowCellValue("ItemGroupNameA")));
                txtGroupNameH.Text = (nullText ? "" : Modules.ToStr(grvGroupUOM.GetFocusedRowCellValue("ItemGroupNameH")));
                txtNote.Text = (nullText ? "" : Modules.ToStr(grvGroupUOM.GetFocusedRowCellValue("Note").ToString()).ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadData(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                var comd = new SqlCommand();
                comd.CommandType = CommandType.StoredProcedure;
                comd.CommandText = "spItemGroup";
                comd.Parameters.Add(new SqlParameter("@Loai", "Grd"));
                dt = IConnections.MGetDataTable(comd);
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
                if (grdGroupUOM.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdGroupUOM, grvGroupUOM, dt, false, true, true, false, true, this.Name);
                    grvGroupUOM.Columns["ID"].Visible = false;
                    grvGroupUOM.Columns["ItemGroupName"].Width = 250;
                    grvGroupUOM.Columns["ItemGroupNameA"].Width = 250;
                    grvGroupUOM.Columns["ItemGroupNameH"].Width = 250;
                    grvGroupUOM.Columns["Note"].Width = 500;
                }
                else
                    Modules.ObjSystems.MLoadXtraGrid(grdGroupUOM, grvGroupUOM, dt, false, false, true, false, false, this.Name);
                if (id != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvGroupUOM.FocusedRowHandle = grvGroupUOM.GetRowHandle(index);
                }
                else { LoadText(false); }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockControl(false);
            LoadText(true);
            txtGroupName.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuSua, lblGroupName.Text);
                return;
            }
            LockControl(false);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, lblGroupName.Text);
                return;
            }

            DeleteData(Modules.ToInt64(txtID.Text));

        }
        private void grdChung_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (btnGhi.Visible) return;
            if (e.KeyCode != Keys.Delete) return;
            if (grvGroupUOM.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvGroupUOM.GetFocusedRowCellValue("ID").ToString()); } catch { }
            if (iId == -1)
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, lblGroupName.Text);
                return;
            }
            DeleteData(iId);
        }
        private void DeleteData(Int64 iId)
        {
            if (Modules.msgHoiThayThe(ThongBao.msgXoa, lblGroupName.Text) == DialogResult.No) return;
            var comd = new SqlCommand();
            comd.CommandType = CommandType.StoredProcedure;
            comd.CommandText = "spItemGroup";

            comd.Parameters.Add(new SqlParameter("@Loai", "Delete"));
            comd.Parameters.Add(new SqlParameter("@ID", Modules.ToInt64(txtID.Text)));
            object rs;
            rs = IConnections.MExecuteScalar(comd);
            if (Modules.ToStr(rs) == "0")
            {
                LoadData(-1);
            }
            else
            {
                Modules.msgThayThe(ThongBao.msgDangSuDung, lblGroupName.Text);
            }
        }
        private void InReport()
        {
            try
            {
                PrintableComponentLink printableComponentLink1 = new PrintableComponentLink();
                CompositeLink composLink = new CompositeLink(new PrintingSystem());
                composLink.Margins.Left = 30;
                composLink.Margins.Right = 30;
                composLink.Margins.Top = 100;


                composLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
                composLink.Landscape = false;

                composLink.Margins.Clone();
                composLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(composLink_CreateMarginalHeaderArea);//tieu de + logo    
                composLink.CreateMarginalFooterArea += new CreateAreaEventHandler(composLink_CreateReportFooterArea);

                printableComponentLink1.Component = this.grdGroupUOM;

                composLink.Links.Add(printableComponentLink1);
                composLink.ShowRibbonPreview(DevExpress.LookAndFeel.UserLookAndFeel.Default);
                //composLink.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        void composLink_CreateReportFooterArea(object sender, CreateAreaEventArgs e)
        {

            string format = "Page {0} of {1}";
            e.Graph.Font = e.Graph.DefaultFont;
            e.Graph.BackColor = Color.Transparent;

            RectangleF r = new RectangleF(0, 0, 0, e.Graph.Font.Height);

            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, format,
                Color.Black, r, BorderSide.None);
            brick.Alignment = BrickAlignment.Far;
            brick.AutoWidth = true;

            brick = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.Black, r, BorderSide.None);
            brick.Alignment = BrickAlignment.Near;
            brick.AutoWidth = true;
        }
        void composLink_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
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

            RectangleF rec = new RectangleF(200, 5, e.Graph.ClientPageSize.Width - 200, 25);
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmItemGroup", "bcTieuDefrmItemGroup", Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);



            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near);
            e.Graph.Font = new Font(e.Graph.DefaultFont.Name.ToString(), 14, FontStyle.Bold);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SaveData()) return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LockControl(true);
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            try
            {
                LoadText(false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LockControl(true);
        }


        private Boolean SaveData()
        {
            if (txtID.Text == "") return false;
            try
            {
                #region Kiem du lieu

                if (txtGroupName.Text == "")
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblGroupName.Text, txtGroupName);
                    return false;
                }
                object rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.ItemGroup WHERE ItemGroupName = N'" + txtGroupName.Text + "' " + (txtID.Text == "-1" ? "" : "AND ID <> " + txtID.Text));
                if (rs != null && (Int32)rs > 0)
                {
                    Modules.msgThayThe(ThongBao.msgDaTonTai, lblGroupName.Text, txtGroupName);
                    return false;
                }
                #endregion
                var comd = new SqlCommand();
                comd.CommandType = CommandType.StoredProcedure;
                comd.CommandText = "spItemGroup";
                comd.Parameters.Add(new SqlParameter("@Loai", "Save"));
                comd.Parameters.Add(new SqlParameter("@ID", Modules.ToInt64(txtID.Text)));
                comd.Parameters.Add(new SqlParameter("@ItemGroupName", Modules.ToStr(txtGroupName.Text)));
                comd.Parameters.Add(new SqlParameter("@ItemGroupNameA", Modules.ToStr(txtGroupNameA.Text)));
                comd.Parameters.Add(new SqlParameter("@ItemGroupNameH", Modules.ToStr(txtGroupNameH.Text)));
                comd.Parameters.Add(new SqlParameter("@Note", Modules.ToStr(txtNote.Text)));
                rs = null;
                rs = IConnections.MExecuteScalar(comd);
                LoadData(Modules.ToInt16(rs));
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void grvChung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGroupUOM.FocusedRowHandle == -2147483646) return;
            LoadText(false);
        }

        private void grvChung_ColumnFilterChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            dt = GetFilteredDataView(view);
            LoadFilter(dt);
            grvChung_FocusedRowChanged(sender, null);

        }

        public static DataTable GetFilteredDataView(DevExpress.XtraGrid.Views.Base.ColumnView view)
        {
            if (view == null) return null;
            if (view.ActiveFilter == null || !view.ActiveFilterEnabled
                || view.ActiveFilter.Expression == "")
                return ((DataView)view.DataSource).Table.Copy();

            DataTable table = ((DataView)view.DataSource).Table.Copy();
            table.DefaultView.RowFilter = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(view.ActiveFilterCriteria);

            return table.DefaultView.ToTable().Copy();
        }

        public void LoadFilter(DataTable dt)
        {
            Boolean nullText = false;
            if (dt.Rows.Count == 0) nullText = true;
            try
            {
                txtID.Text = (nullText ? "-1" : Modules.ToInt64(dt.Rows[0]["ID"].ToString()).ToString());
                txtGroupName.Text = (nullText ? "" : Modules.ToStr(dt.Rows[0]["ItemGroupName"].ToString()));
                txtGroupNameA.Text = (nullText ? "" : Modules.ToStr(dt.Rows[0]["ItemGroupNameA"].ToString()));
                txtGroupNameH.Text = (nullText ? "" : Modules.ToStr(dt.Rows[0]["ItemGroupNameH"].ToString()));
                txtNote.Text = (nullText ? "" : Modules.ToStr(dt.Rows[0]["Note"].ToString()));
            }
            catch
            {
                LoadText(true);
            }
        }

        private void searchControl1_TextChanged(object sender, EventArgs e)
        {
            grvGroupUOM.FocusedRowHandle = 0;
        }

   
    }
}
