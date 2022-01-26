using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using Commons;
using DevExpress.XtraEditors;
using System.Reflection;

namespace VS.OEE
{
    public partial class frmBoPhanChiuPhi : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        public frmBoPhanChiuPhi(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
            LockControl(true);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        public DataTable DataLoaiChiPhi(bool CoAll)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetLoaiChiPhiAll", CoAll, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            return dt;
        }

        public DataTable DataDonVi(bool CoAll)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetDonViAll", CoAll, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            return dt;
        }

        private void frmBoPhanChiuPhi_Load(object sender, EventArgs e)
        {
            
            try
            {
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiChiPhi, DataLoaiChiPhi(true), "LOAI_CHI_PHI", "TEN_LOAI_CHI_PHI", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_LOAI_CHI_PHI"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDonVi, DataDonVi(true), "MS_DON_VI", "TEN_DON_VI", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_DON_VI"));
                LoadData(-1);
                LoadText(false);
                if (iPQ != 1)
                {
                    this.btnThem.Visible = false;
                    this.btnSua.Visible = false;
                    this.btnXoa.Visible = false;
                    this.btnLuu.Visible = false;
                    this.btnKhong.Visible = false;
                }
                txtTenBoPhanChiuPhi.Properties.MaxLength = 250;
                memoGhiChu.Properties.MaxLength = 250;
                cboLoaiChiPhi.Properties.MaxLength = 250;
              
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            grdBoPhanChiuPhi.Focus();
        }

        private void LockControl(Boolean bLock)
        {
            txtMaBPChiuPhi.Properties.ReadOnly = bLock;
            txtTenBoPhanChiuPhi.Properties.ReadOnly = bLock;
            memoGhiChu.Properties.ReadOnly = bLock;
            cboLoaiChiPhi.Properties.ReadOnly = bLock;
            cboDonVi.Properties.ReadOnly = bLock;
            grdBoPhanChiuPhi.Enabled = bLock;
            txtSearch.ReadOnly = !bLock;

            this.btnThem.Visible = bLock;
            this.btnSua.Visible = bLock;
            this.btnXoa.Visible = bLock;
            this.btnThoat.Visible = bLock;

            this.btnKhong.Visible = !bLock;
            this.btnLuu.Visible = !bLock;
        }

        private void LoadText(Boolean nullText)
        {
            if (grvBoPhanChiuPhi == null) return;
            if (grvBoPhanChiuPhi.RowCount == 0) nullText = true;
            try
            {
                grvBoPhanChiuPhi.Columns["MS_BP_CHIU_PHI"].Visible = false;
                grvBoPhanChiuPhi.Columns["LOAI_CHI_PHI"].Visible = false;
                //MS_NGUYEN_NHAN, TEN_NGUYEN_NHAN_ANH, TEN_NGUYEN_NHAN, HU_HONG, BTDK,
                //MAC_DINH, Planned, DownTimeTypeID
                txtID.Text = (nullText ? "-1" : Modules.ToInt32(grvBoPhanChiuPhi.GetFocusedRowCellValue("MS_BP_CHIU_PHI")).ToString());
                txtMaBPChiuPhi.Text = (nullText ? "" : Modules.ToStr(grvBoPhanChiuPhi.GetFocusedRowCellValue("MA_BP_CHIU_PHI")));
                txtTenBoPhanChiuPhi.Text = (nullText ? "" : Modules.ToStr(grvBoPhanChiuPhi.GetFocusedRowCellValue("TEN_BP_CHIU_PHI")));
                cboLoaiChiPhi.EditValue = Convert.ToInt16(grvBoPhanChiuPhi.GetFocusedRowCellValue("LOAI_CHI_PHI"));
                cboDonVi.EditValue = Modules.ToStr(grvBoPhanChiuPhi.GetFocusedRowCellValue("MS_DON_VI"));
                memoGhiChu.EditValue = Modules.ToStr(grvBoPhanChiuPhi.GetFocusedRowCellValue("GHI_CHU"));        
                // cboPlanned.EditValue = Convert.ToInt32(grvDownTimeCause.GetFocusedRowCellValue("Planned"));
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
                comd.CommandText = "spBoPhanChiuPhi";
                comd.Parameters.Add(new SqlParameter("@Loai", "Grd"));
                dt = IConnections.MGetDataTable(comd);
                dt.PrimaryKey = new DataColumn[] { dt.Columns["MS_BP_CHIU_PHI"] };
                if (grdBoPhanChiuPhi.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdBoPhanChiuPhi, grvBoPhanChiuPhi, dt, false, false, true, true, true, this.Name);
                }
                else
                {
                    grdBoPhanChiuPhi.DataSource = dt;
                }
                if (id != 1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvBoPhanChiuPhi.FocusedRowHandle = grvBoPhanChiuPhi.GetRowHandle(index);
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
            txtMaBPChiuPhi.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenBoPhanChiuPhi.Text == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuSua, lblTenBPChiuPhi.Text);
                return;
            }
            LockControl(false);
        }

        private void DeleteData(Int64 iID)
        {
            if (Modules.msgHoiThayThe(ThongBao.msgXoa, lblTenBPChiuPhi.Text) == DialogResult.No) return;
            var comd = new SqlCommand();
            comd.CommandType = CommandType.StoredProcedure;
            comd.CommandText = "spBoPhanChiuPhi";

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
                Modules.msgThayThe(ThongBao.msgDangSuDung, lblTenBPChiuPhi.Text);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTenBoPhanChiuPhi.Text == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuSua, lblTenBPChiuPhi.Text);
                return;
            }
            DeleteData(Modules.ToInt64(txtID.Text));
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
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

        private void btnLuu_Click(object sender, EventArgs e)
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
        private Boolean SaveData()
        {
            object rs;
            if (txtID.Text == "") return false;
            try
            {
                #region Kiem du lieu
                //txtMaBPChiuPhi không trống
                if (Commons.Modules.ObjSystems.IsnullorEmpty(txtMaBPChiuPhi.Text))
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblMaBPChiuPhi.Text, txtMaBPChiuPhi);
                    return false;
                }
                //txtMaBPChiuPhi không trùng
                rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.BO_PHAN_CHIU_PHI WHERE MA_BP_CHIU_PHI  = N'" + txtMaBPChiuPhi.Text + "' " + (txtID.Text == "-1" ? "" : "AND MS_BP_CHIU_PHI <> " + txtID.Text));
                if (rs != null && (Int32)rs > 0)
                {
                    Modules.msgThayThe(ThongBao.msgDaTonTai, lblMaBPChiuPhi.Text, txtMaBPChiuPhi);
                    return false;
                }

                //Tên bộ phận chiu phí không trống
                if (txtTenBoPhanChiuPhi.Text == "")
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblTenBPChiuPhi.Text, txtTenBoPhanChiuPhi);
                    return false;
                }
                //Tên bộ phận chiu phí không  trùng
                rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.BO_PHAN_CHIU_PHI WHERE TEN_BP_CHIU_PHI = N'" + txtTenBoPhanChiuPhi.Text + "' " + (txtID.Text == "-1" ? "" : "AND MS_BP_CHIU_PHI <> " + txtID.Text));
                if (rs != null && (Int32)rs > 0)
                {
                    Modules.msgThayThe(ThongBao.msgDaTonTai, lblTenBPChiuPhi.Text, txtTenBoPhanChiuPhi);
                    return false;
                }
                // loại chi phí không trống
                if (Commons.Modules.ObjSystems.IsnullorEmpty(cboLoaiChiPhi.Text))
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblLoaiChiPhi.Text, cboLoaiChiPhi);
                    return false;
                }

                #endregion
                var comd = new SqlCommand();
                comd.CommandType = CommandType.StoredProcedure;
                comd.CommandText = "spBoPhanChiuPhi";
                comd.Parameters.Add(new SqlParameter("@Loai", "Save"));
                comd.Parameters.Add(new SqlParameter("@ID", Modules.ToInt32(txtID.Text)));
                comd.Parameters.Add(new SqlParameter("@TEN_BP_CHIU_PHI", Modules.ToStr(txtTenBoPhanChiuPhi.Text)));
                comd.Parameters.Add(new SqlParameter("@LOAI_CHI_PHI", Modules.ToInt32(cboLoaiChiPhi.EditValue)));
                comd.Parameters.Add(new SqlParameter("@MSDV", Modules.ToStr(cboDonVi.EditValue)));
                comd.Parameters.Add(new SqlParameter("@GHI_CHU", Modules.ToStr(memoGhiChu.Text)));
                comd.Parameters.Add(new SqlParameter("@MA_BP_CHIU_PHI", Modules.ToStr(txtMaBPChiuPhi.Text)));
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

        private void grvBoPhanChiuPhi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvBoPhanChiuPhi.FocusedRowHandle < 0) return;
            LoadText(false);
        }

        private void grvBoPhanChiuPhi_ColumnFilterChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            dt = GetFilteredDataView(view);
            LoadFilter(dt);
            grvBoPhanChiuPhi_FocusedRowChanged(sender, null);
        }
        public void LoadFilter(DataTable dt)
        {
            Boolean nullText = false;
            if (dt.Rows.Count == 0) nullText = true;
            try
            {
                txtID.Text = (nullText ? "-1" : Modules.ToInt32(grvBoPhanChiuPhi.GetFocusedRowCellValue("MS_BP_CHIU_PHI")).ToString());
                txtTenBoPhanChiuPhi.Text = (nullText ? "" : Modules.ToStr(grvBoPhanChiuPhi.GetFocusedRowCellValue("TEN_BP_CHIU_PHI")));
                cboLoaiChiPhi.EditValue = Modules.ToInt32(grvBoPhanChiuPhi.GetFocusedRowCellValue("LOAI_CHI_PHI"));
             
                cboDonVi.EditValue = Convert.ToInt32(grvBoPhanChiuPhi.GetFocusedRowCellValue("TEN_DON_VI"));
            }
            catch
            {
                LoadText(true);
            }
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
    }
}
