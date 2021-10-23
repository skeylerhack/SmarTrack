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
    public partial class ucDownTimeCause : DevExpress.XtraEditors.XtraForm
    {
        
        public ucDownTimeCause()
        {
            InitializeComponent();
            LockControl(true);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void ucDownTimeType_Load(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDownTimeType, Commons.Modules.ObjSystems.DataDownTimeType(false), "ID", "DownTimeTypeName", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "DownTimeTypeName"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboPlanned, Commons.Modules.ObjSystems.DataPlanned(false),  "ID","StopTypeName", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "StopTypeName"));
                LoadData(-1);
                LoadText(false);
                if (Modules.iPermission != 1)
                {
                    this.btnThem.Visible = false;
                    this.btnSua.Visible = false;
                    this.btnXoa.Visible = false;
                    this.btnThoat.Visible = false;
                    this.btnGhi.Visible = false;
                    this.btnKhong.Visible = false;
                }
                txtTenNN.Properties.MaxLength = 250;
                txtTenNNA.Properties.MaxLength = 250;
                cboDownTimeType.Properties.MaxLength = 250;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LockControl(Boolean bLock)
        {
            txtTenNN.Properties.ReadOnly = bLock;
            txtTenNNA.Properties.ReadOnly = bLock;
            cboDownTimeType.Properties.ReadOnly = bLock;
            txtCauseCode.Properties.ReadOnly = bLock;
            cboPlanned.Properties.ReadOnly = bLock;
            chkHuHong.Properties.ReadOnly = bLock;
            chkSanXuat.Properties.ReadOnly = bLock;
            txtSearch.ReadOnly = !bLock;
            grdDownTimeCause.Enabled = bLock;

            this.btnThem.Visible = bLock;
            this.btnSua.Visible = bLock;
            this.btnXoa.Visible = bLock;
            this.btnThoat.Visible = bLock;
            this.btnGhi.Visible = !bLock;
            this.btnKhong.Visible = !bLock;
        }
        private void LoadText(Boolean nullText)
        {
            if (grvDownTimeCause == null) return;
            if (grvDownTimeCause.RowCount == 0) nullText = true;
            try
            {
                //MS_NGUYEN_NHAN, TEN_NGUYEN_NHAN_ANH, TEN_NGUYEN_NHAN, HU_HONG, BTDK,
                //MAC_DINH, Planned, DownTimeTypeID

                txtID.Text = (nullText ? "-1" : Modules.ToInt32(grvDownTimeCause.GetFocusedRowCellValue("MS_NGUYEN_NHAN")).ToString());
                txtTenNN.Text = (nullText ? "" : Modules.ToStr(grvDownTimeCause.GetFocusedRowCellValue("TEN_NGUYEN_NHAN")));
                txtTenNNA.Text = (nullText ? "" : Modules.ToStr(grvDownTimeCause.GetFocusedRowCellValue("TEN_NGUYEN_NHAN_ANH")));
                cboDownTimeType.EditValue =Modules.ToInt32(grvDownTimeCause.GetFocusedRowCellValue("DownTimeTypeID"));
                chkHuHong.Checked = Modules.ToBoolean(grvDownTimeCause.GetFocusedRowCellValue("HU_HONG"));
                chkSanXuat.Checked = Modules.ToBoolean(grvDownTimeCause.GetFocusedRowCellValue("BTDK"));
                txtCauseCode.EditValue = (nullText ? "" : grvDownTimeCause.GetFocusedRowCellValue("CauseCode"));
                cboPlanned.EditValue = Convert.ToInt32(grvDownTimeCause.GetFocusedRowCellValue("Planned"));
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
                comd.CommandText = "spDownTimeCause";
                comd.Parameters.Add(new SqlParameter("@Loai", "Grd"));
                dt = IConnections.MGetDataTable(comd);
                dt.PrimaryKey = new DataColumn[] { dt.Columns["MS_NGUYEN_NHAN"] };
                if (grdDownTimeCause.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdDownTimeCause, grvDownTimeCause, dt, false, false, true, true, true, this.Name);
                }
                else
                {
                    grdDownTimeCause.DataSource = dt;
                }
                if (id != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvDownTimeCause.FocusedRowHandle = grvDownTimeCause.GetRowHandle(index);
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
            txtCauseCode.Focus();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenNN.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuSua, lblTenNN.Text);
                return;
            }
            LockControl(false);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTenNN.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, lblTenNN.Text);
                return;
            }

            DeleteData(Modules.ToInt64(txtID.Text));

        }
        private void grdChung_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (btnGhi.Visible) return;
            if (e.KeyCode != Keys.Delete) return;
            if (grvDownTimeCause.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvDownTimeCause.GetFocusedRowCellValue("ID").ToString()); } catch { }
            if (iId == -1)
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, lblTenNN.Text);
                return;
            }
            DeleteData(iId);
        }
        private void DeleteData(Int64 iId)
        {
            if (Modules.msgHoiThayThe(ThongBao.msgXoa, lblTenNN.Text) == DialogResult.No) return;
            var comd = new SqlCommand();
            comd.CommandType = CommandType.StoredProcedure;
            comd.CommandText = "spDownTimeCause";

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
                Modules.msgThayThe(ThongBao.msgDangSuDung, lblTenNN.Text);
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

                printableComponentLink1.Component = this.grdDownTimeCause;

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
            e.Graph.DrawString(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucDownTimeType", "bcTieuDeucDownTimeType", Commons.Modules.TypeLanguage), Color.Black, rec, BorderSide.None);



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
            object rs;
            if (txtID.Text.Trim() == "") return false;
            try
            {
                #region Kiem du lieu
                //txtCauseCode không trống
                if (Commons.Modules.ObjSystems.IsnullorEmpty(txtCauseCode.Text))
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblCauseCode.Text, txtCauseCode);
                    return false;
                }
                //txtCauseCode không trùng
                rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.NGUYEN_NHAN_DUNG_MAY WHERE CauseCode = N'" + txtCauseCode.Text + "' " + (txtID.Text == "-1" ? "" : "AND MS_NGUYEN_NHAN <> " + txtID.Text));
                if (rs != null && (Int32)rs > 0)
                {
                    Modules.msgThayThe(ThongBao.msgDaTonTai, lblCauseCode.Text, txtCauseCode);
                    return false;
                }
                //nguyên nhân không trống
                if (txtTenNN.Text.Trim() == "")
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblTenNN.Text, txtTenNN);
                    return false;
                }
               //tên nguyên nhân không  trùng
                rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.NGUYEN_NHAN_DUNG_MAY WHERE TEN_NGUYEN_NHAN = N'" + txtTenNN.Text + "' " + (txtID.Text == "-1" ? "" : "AND MS_NGUYEN_NHAN <> " + txtID.Text));
                if (rs != null && (Int32)rs > 0)
                {
                    Modules.msgThayThe(ThongBao.msgDaTonTai, lblTenNN.Text, txtTenNN);
                    return false;
                }
                // loại ngừng máy không trống
                if (Commons.Modules.ObjSystems.IsnullorEmpty(cboDownTimeType.Text))
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblDownTimeType.Text, cboDownTimeType);
                    return false;
                }

                #endregion
                var comd = new SqlCommand();
                comd.CommandType = CommandType.StoredProcedure;
                comd.CommandText = "spDownTimeCause";
                comd.Parameters.Add(new SqlParameter("@Loai", "Save"));
                comd.Parameters.Add(new SqlParameter("@ID", Modules.ToInt32(txtID.Text)));
                comd.Parameters.Add(new SqlParameter("@TEN_NGUYEN_NHAN", Modules.ToStr(txtTenNN.Text)));
                comd.Parameters.Add(new SqlParameter("@TEN_NGUYEN_NHANA", Modules.ToStr(txtTenNNA.Text)));
                comd.Parameters.Add(new SqlParameter("@DownTimeTypeID", Modules.ToInt32(cboDownTimeType.EditValue)));
                comd.Parameters.Add(new SqlParameter("@HU_HONG",chkHuHong.Checked));
                comd.Parameters.Add(new SqlParameter("@BTDK", chkSanXuat.Checked));
                comd.Parameters.Add(new SqlParameter("@MAC_DINH", 0));
                comd.Parameters.Add(new SqlParameter("@CauseCode", txtCauseCode.EditValue));
                comd.Parameters.Add(new SqlParameter("@Planned", cboPlanned.EditValue));
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
            if (grvDownTimeCause.FocusedRowHandle <0) return;
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
                txtID.Text = (nullText ? "-1" : Modules.ToInt32(grvDownTimeCause.GetFocusedRowCellValue("MS_NGUYEN_NHAN")).ToString());
                txtTenNN.Text = (nullText ? "" : Modules.ToStr(grvDownTimeCause.GetFocusedRowCellValue("TEN_NGUYEN_NHAN")));
                txtTenNNA.Text = (nullText ? "" : Modules.ToStr(grvDownTimeCause.GetFocusedRowCellValue("TEN_NGUYEN_NHAN_ANH")));
                cboDownTimeType.EditValue = Modules.ToInt32(grvDownTimeCause.GetFocusedRowCellValue("DownTimeTypeID"));
                chkHuHong.Checked = Modules.ToBoolean(grvDownTimeCause.GetFocusedRowCellValue("HU_HONG"));
                chkSanXuat.Checked = Modules.ToBoolean(grvDownTimeCause.GetFocusedRowCellValue("BTDK"));
                txtCauseCode.EditValue = grvDownTimeCause.GetFocusedRowCellValue("CauseCode");
                cboPlanned.EditValue = Convert.ToInt32(grvDownTimeCause.GetFocusedRowCellValue("Planned"));
            }
            catch
            {
                LoadText(true);
            }
        }

        private void searchControl1_TextChanged(object sender, EventArgs e)
        {
            grvDownTimeCause.FocusedRowHandle = 0;
        }

   
    }
}
