using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Reflection;
using Commons;

namespace VS.OEE
{
    public partial class frmNhomNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        public frmNhomNguoiDung(int iPQCN)
        {
            iPQ = iPQCN;
            InitializeComponent();
            LockControl(true);
            Commons.Modules.ObjSystems.ThayDoiNN(this);

        }
        private void frmDownTimeType_Load(object sender, EventArgs e)
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
                txtDownTimeType.Properties.MaxLength = 250;
                txtNote.Properties.MaxLength = 500;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LockControl(Boolean bLock)
        {

            txtDownTimeType.Properties.ReadOnly = bLock;
            txtNote.Properties.ReadOnly = bLock;

            txtSearch.ReadOnly = !bLock;
            grdNhomNguoiDung.Enabled = bLock;

            this.btnThem.Visible = bLock;
            this.btnSua.Visible = bLock;
            this.btnXoa.Visible = bLock;
            this.btnThoat.Visible = bLock;
            this.btnGhi.Visible = !bLock;
            this.btnKhong.Visible = !bLock;
        }
        private void LoadText(Boolean nullText)
        {
            if (grvNhomNguoiDung == null) return;
            if (grvNhomNguoiDung.RowCount == 0) nullText = true;
            try
            {
                txtID.Text = (nullText ? "-1" : Modules.ToInt64(grvNhomNguoiDung.GetFocusedRowCellValue("GROUP_ID")).ToString());
                txtDownTimeType.Text = (nullText ? "" : Modules.ToStr(grvNhomNguoiDung.GetFocusedRowCellValue("GROUP_NAME")));
                txtNote.Text = (nullText ? "" : Modules.ToStr(grvNhomNguoiDung.GetFocusedRowCellValue("DESCRIPTION").ToString()).ToString());
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
                comd.CommandText = "spNhomNguoiDung";
                comd.Parameters.Add(new SqlParameter("@Loai", "Grd"));
                dt = IConnections.MGetDataTable(comd);
                dt.PrimaryKey = new DataColumn[] { dt.Columns["GROUP_ID"] };
                if (grdNhomNguoiDung.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdNhomNguoiDung, grvNhomNguoiDung, dt, false, false, true, true, true, this.Name);
                }
                else
                {
                    grdNhomNguoiDung.DataSource = dt;
                }
                if (id != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvNhomNguoiDung.FocusedRowHandle = grvNhomNguoiDung.GetRowHandle(index);
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
            txtDownTimeType.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtDownTimeType.Text == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuSua, lblGroupName.Text);
                return;
            }
            LockControl(false);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtDownTimeType.Text == "")
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
            if (grvNhomNguoiDung.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvNhomNguoiDung.GetFocusedRowCellValue("GROUP_ID").ToString()); } catch { }
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
            comd.CommandText = "spNhomNguoiDung";

            comd.Parameters.Add(new SqlParameter("@Loai", "Delete"));
            comd.Parameters.Add(new SqlParameter("@GROUP_ID", Modules.ToInt64(txtID.Text)));
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

                if (txtDownTimeType.Text == "")
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblGroupName.Text, txtDownTimeType);
                    return false;
                }
                object rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.DownTimeType WHERE DownTimeTypeName = N'" + txtDownTimeType.Text + "' " + (txtID.Text == "-1" ? "" : "AND ID_DownTime <> " + txtID.Text));
                if (rs != null && (Int32)rs > 0)
                {
                    Modules.msgThayThe(ThongBao.msgDaTonTai, lblGroupName.Text, txtDownTimeType);
                    return false;
                }
                #endregion
                var comd = new SqlCommand();
                comd.CommandType = CommandType.StoredProcedure;
                comd.CommandText = "spNhomNguoiDung";
                comd.Parameters.Add(new SqlParameter("@Loai", "Save"));
                comd.Parameters.Add(new SqlParameter("@GROUP_ID", Modules.ToInt64(txtID.Text)));
                comd.Parameters.Add(new SqlParameter("@GROUP_NAME", Modules.ToStr(txtDownTimeType.Text)));
                comd.Parameters.Add(new SqlParameter("@DESCRIPTION", Modules.ToStr(txtNote.Text)));
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
            if (grvNhomNguoiDung.FocusedRowHandle == -2147483646) return;
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
                txtDownTimeType.Text = (nullText ? "" : Modules.ToStr(dt.Rows[0]["DownTimeTypeName"].ToString()));
                txtNote.Text = (nullText ? "" : Modules.ToStr(dt.Rows[0]["Note"].ToString()));
            }
            catch
            {
                LoadText(true);
            }
        }

        private void searchControl1_TextChanged(object sender, EventArgs e)
        {
            grvNhomNguoiDung.FocusedRowHandle = 0;
        }

        private void grdDownTimeType_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteData(Modules.ToInt64(grvNhomNguoiDung.GetFocusedRowCellValue("ID").ToString()));
            }
        }
    }
}
