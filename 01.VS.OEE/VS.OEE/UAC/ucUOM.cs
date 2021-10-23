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
using System.Linq;

namespace VS.OEE
{
    public partial class ucUOM : DevExpress.XtraEditors.XtraForm
    {
        public ucUOM()
        {
            InitializeComponent();
            LockControl(true);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        #region "SelectText"
        private void txtLength_Enter(object sender, EventArgs e)
        {
            var edit = ((DevExpress.XtraEditors.TextEdit)sender);
            BeginInvoke(new MethodInvoker(() =>
            {
                edit.SelectionStart = 0;
                edit.SelectionLength = edit.Text.Length;
            }));
        }

        private void txtWidth_Enter(object sender, EventArgs e)
        {
            var edit = ((DevExpress.XtraEditors.TextEdit)sender);
            BeginInvoke(new MethodInvoker(() =>
            {
                edit.SelectionStart = 0;
                edit.SelectionLength = edit.Text.Length;
            }));
        }

        private void txtHeight_Enter(object sender, EventArgs e)
        {
            var edit = ((DevExpress.XtraEditors.TextEdit)sender);
            BeginInvoke(new MethodInvoker(() =>
            {
                edit.SelectionStart = 0;
                edit.SelectionLength = edit.Text.Length;
            }));
        }

        private void txtVolume_Enter(object sender, EventArgs e)
        {
            var edit = ((DevExpress.XtraEditors.TextEdit)sender);
            BeginInvoke(new MethodInvoker(() =>
            {
                edit.SelectionStart = 0;
                edit.SelectionLength = edit.Text.Length;
            }));
        }
        #endregion
        private void txtWeight_Enter(object sender, EventArgs e)
        {
            var edit = ((DevExpress.XtraEditors.TextEdit)sender);
            BeginInvoke(new MethodInvoker(() =>
            {
                edit.SelectionStart = 0;
                edit.SelectionLength = edit.Text.Length;
            }));
        }


        private void ucUOM_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData(-1);
                LoadText(false);
                if (Modules.iPermission != 1)
                {
                    this.btnThem.Visible = false;
                    this.btnSua.Visible = false;
                    this.btnXoa.Visible = false;
                    this.btnGhi.Visible = false;
                    this.btnKhong.Visible = false;

                }
                txtUOMCode.Properties.MaxLength = 50;
                txtUOMName.Properties.MaxLength = 250;
                txtUOMNameA.Properties.MaxLength = 250;
                txtUOMNameH.Properties.MaxLength = 250;
                txtUOMNote.Properties.MaxLength = 500;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LockControl(Boolean bLock)
        {

            txtUOMCode.Properties.ReadOnly = bLock;
            txtHeight.Properties.ReadOnly = bLock;
            txtWidth.Properties.ReadOnly = bLock;
            txtLength.Properties.ReadOnly = bLock;
            txtUOMName.Properties.ReadOnly = bLock;
            txtUOMNameA.Properties.ReadOnly = bLock;
            txtUOMNameH.Properties.ReadOnly = bLock;
            txtVolume.Properties.ReadOnly = bLock;
            txtWeight.Properties.ReadOnly = bLock;
            chkBaseUOM.Properties.ReadOnly = bLock;
            txtUOMNote.Properties.ReadOnly = bLock;
            txtSearch.ReadOnly = !bLock;
            grdUOM.Enabled = bLock;
            this.btnThem.Visible = bLock;
            this.btnSua.Visible = bLock;
            this.btnXoa.Visible = bLock;
            this.btnThoat.Visible = bLock;
            this.btnGhi.Visible = !bLock;
            this.btnKhong.Visible = !bLock;

        }
        private void LoadText(Boolean nullText)
        {

            if (grvUOM == null) return;
            if (grvUOM.RowCount == 0) nullText = true;
            try
            {
                txtID.Text = (nullText ? "-1" : Modules.ToInt64(grvUOM.GetFocusedRowCellValue("ID")).ToString());
                txtUOMCode.Text = (nullText ? "" : Modules.ToStr(grvUOM.GetFocusedRowCellValue("UOMCode")));
                txtUOMName.Text = (nullText ? "" : Modules.ToStr(grvUOM.GetFocusedRowCellValue("UOMName")));
                txtUOMNameA.Text = (nullText ? "" : Modules.ToStr(grvUOM.GetFocusedRowCellValue("UOMNameA")));
                txtUOMNameH.Text = (nullText ? "" : Modules.ToStr(grvUOM.GetFocusedRowCellValue("UOMNameH")));

                txtHeight.Text = (nullText ? "" : Modules.ToDouble(grvUOM.GetFocusedRowCellValue("Height").ToString()).ToString());
                txtWidth.Text = (nullText ? "" : Modules.ToDouble(grvUOM.GetFocusedRowCellValue("Width").ToString()).ToString());
                txtLength.Text = (nullText ? "" : Modules.ToDouble(grvUOM.GetFocusedRowCellValue("Length").ToString()).ToString());
                txtUOMNote.Text = (nullText ? "" : Modules.ToStr(grvUOM.GetFocusedRowCellValue("UOMNote").ToString()).ToString());
                txtVolume.Text = (nullText ? "" : Modules.ToDouble(grvUOM.GetFocusedRowCellValue("Volume").ToString()).ToString());
                txtWeight.Text = (nullText ? "" : Modules.ToDouble(grvUOM.GetFocusedRowCellValue("Weight").ToString()).ToString());
                if ((nullText ? false : Modules.ToBoolean(grvUOM.GetFocusedRowCellValue("BasedUOM").ToString()))) chkBaseUOM.Checked = true; else chkBaseUOM.Checked = false;

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
                comd.CommandText = "spUOM";
                comd.Parameters.Add(new SqlParameter("@Loai", "Grd"));
                dt = IConnections.MGetDataTable(comd);
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
                if (grdUOM.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdUOM, grvUOM, dt, false, true, true, false, true, this.Name);
                    grvUOM.Columns["ID"].Visible = false;
                    grvUOM.Columns["UOMName"].Width = 250;grvUOM.Columns["UOMNote"].Width = 250;
                }
                else
                    Modules.ObjSystems.MLoadXtraGrid(grdUOM, grvUOM, dt, false, false, true, false, false, this.Name);

                if (id != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvUOM.FocusedRowHandle = grvUOM.GetRowHandle(index);
                    //int rowHandle = grvChung.LocateByDisplayText(grvChung.FocusedRowHandle + 1, grvChung.Columns["UOMName"], "M");
                    //grvChung.FocusedRowHandle = rowHandle;
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
            txtUOMCode.Focus();
            //nếu có đơn vị tính gốc rồi thì readonly
            int n = Commons.Modules.ObjSystems.ConvertDatatable(grvUOM).AsEnumerable().Count(x=>x.Field<Boolean>("BasedUOM") == true);
            if(n != 0)
            {
                chkBaseUOM.Properties.ReadOnly = true;
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtUOMCode.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuSua,lblUOMName.Text);
                return;
            }
            LockControl(false);

            int n = Commons.Modules.ObjSystems.ConvertDatatable(grvUOM).AsEnumerable().Count(x=>x.Field<Boolean>("BasedUOM") == true && x.Field<Int64>("ID") != Convert.ToInt64(grvUOM.GetFocusedRowCellValue("ID")));
            if (n != 0)
            {
              
                    chkBaseUOM.Properties.ReadOnly = true;
              
            }
            else
            {
                if (chkBaseUOM.Checked)
                {
                    //kiểm tra có trong bassUOM chưa
                    n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.UOMConversionGroupDetails WHERE UOMID = " + Convert.ToInt64(grvUOM.GetFocusedRowCellValue("ID") + " ")));
                    if (n == 0)
                    {
                        chkBaseUOM.Properties.ReadOnly = false;
                    }
                    else
                    {
                        chkBaseUOM.Properties.ReadOnly = true;
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtUOMCode.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, lblUOMName.Text);
                return;
            }

            DeleteData( Modules.ToInt64(txtID.Text));

        }
        private void grdChung_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (btnGhi.Visible) return;
            if (e.KeyCode != Keys.Delete) return;
            if (grvUOM.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvUOM.GetFocusedRowCellValue("ID").ToString()); } catch { }
            if (iId == -1)
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, lblUOMName.Text);
                return;
            }
            DeleteData(iId);
        }
        private void DeleteData(Int64 iId)
        {
            if (Modules.msgHoiThayThe(ThongBao.msgXoa,lblUOMName.Text) == DialogResult.No) return;
            var comd = new SqlCommand();
            comd.CommandType = CommandType.StoredProcedure;
            comd.CommandText = "spUOM";

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
                Modules.msgThayThe(ThongBao.msgDangSuDung,lblUOMName.Text);
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (txtUOMCode.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuIn, lblUOMName.Text);
                return;
            }
            //grdChung.ShowPrintPreview();
            InReport();
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

                printableComponentLink1.Component = this.grdUOM;

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
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucUOM" , "bcTieuDeUOM", Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);



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
            if (txtID.Text.Trim() == "") return false;
            try
            {
                #region Kiem du lieu
                if (txtUOMCode.Text.Trim() == "")
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong,lblUOMCode.Text, txtUOMCode);
                    return false;
                }
                //dxValidationProvider1.Validate();
                object rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.UOM WHERE UOMCode =    N'"  +  txtUOMCode.Text + "'  " + (txtID.Text == "-1" ? "" : "AND ID <> " + txtID.Text));
                if (rs != null && (Int32)rs > 0)
                {

                    Modules.msgThayThe(ThongBao.msgDaTonTai, lblUOMCode.Text, txtUOMCode);
                    return false;
                }

                if (txtUOMName.Text.Trim() == "")
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblUOMName.Text, txtUOMName);
                    return false;
                }
                rs = null;
                rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.UOM WHERE UOMName = N'" + txtUOMName.Text + "' " + (txtID.Text == "-1" ? "" : "AND ID <> " + txtID.Text));
                if (rs != null && (Int32)rs > 0)
                {
                    Modules.msgThayThe(ThongBao.msgDaTonTai, lblUOMName.Text, txtUOMName);
                    return false;
                }

                #endregion


                var comd = new SqlCommand();
                comd.CommandType = CommandType.StoredProcedure;
                comd.CommandText = "spUOM";
                comd.Parameters.Add(new SqlParameter("@Loai", "Save"));
                comd.Parameters.Add(new SqlParameter("@ID", Modules.ToInt64(txtID.Text)));
                comd.Parameters.Add(new SqlParameter("@UOMCode", Modules.ToStr(txtUOMCode.Text)));
                comd.Parameters.Add(new SqlParameter("@UOMName", Modules.ToStr(txtUOMName.Text)));
                comd.Parameters.Add(new SqlParameter("@UOMNameA", Modules.ToStr(txtUOMNameA.Text)));
                comd.Parameters.Add(new SqlParameter("@UOMNameH", Modules.ToStr(txtUOMNameH.Text)));
                comd.Parameters.Add(new SqlParameter("@Length", Modules.ToDouble(txtLength.Text)));
                comd.Parameters.Add(new SqlParameter("@Width", Modules.ToDouble(txtWidth.Text)));
                comd.Parameters.Add(new SqlParameter("@Height", Modules.ToDouble(txtHeight.Text)));
                comd.Parameters.Add(new SqlParameter("@Volume", Modules.ToDouble(txtVolume.Text)));
                comd.Parameters.Add(new SqlParameter("@Weight", Modules.ToDouble(txtWeight.Text)));
                comd.Parameters.Add(new SqlParameter("@BasedUOM", Modules.ToBoolean(chkBaseUOM.Checked)));
                comd.Parameters.Add(new SqlParameter("@UOMNote", Modules.ToStr(txtUOMNote.Text)));
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
            if (grvUOM.FocusedRowHandle == -2147483646) return;
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
            //DataTable filteredDataView = new DataTable(table);
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
                txtUOMCode.Text = (nullText ? "" : Modules.ToStr(dt.Rows[0]["UOMCode"].ToString()));
                txtUOMName.Text = (nullText ? "" : Modules.ToStr(dt.Rows[0]["UOMName"].ToString()));
                txtUOMNameA.Text = (nullText ? "" : Modules.ToStr(dt.Rows[0]["UOMNameA"].ToString()));
                txtUOMNameH.Text = (nullText ? "" : Modules.ToStr(dt.Rows[0]["UOMNameH"].ToString()));
                txtHeight.Text = (nullText ? "" : Modules.ToDouble(dt.Rows[0]["Height"].ToString()).ToString());
                txtWidth.Text = (nullText ? "" : Modules.ToDouble(dt.Rows[0]["Width"].ToString()).ToString());
                txtLength.Text = (nullText ? "" : Modules.ToDouble(dt.Rows[0]["Length"].ToString()).ToString());
                txtVolume.Text = (nullText ? "" : Modules.ToDouble(dt.Rows[0]["Volume"].ToString()).ToString());
                txtWeight.Text = (nullText ? "" : Modules.ToDouble(dt.Rows[0]["Weight"].ToString()).ToString());
                txtUOMNote.Text = (nullText ? "" : Modules.ToStr(dt.Rows[0]["UOMNote"].ToString()));
                if ((nullText ? false : Modules.ToBoolean(dt.Rows[0]["BasedUOM"].ToString()))) chkBaseUOM.Checked = true; else chkBaseUOM.Checked = false;

            }
            catch
            {
                LoadText(true);
            }
        }

        private void searchControl1_TextChanged(object sender, EventArgs e)
        {

            grvUOM.FocusedRowHandle = 0;
        }




    }
}