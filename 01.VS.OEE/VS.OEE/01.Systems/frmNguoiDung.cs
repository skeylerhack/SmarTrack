using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace VS.OEE
{
    public partial class frmNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = -1;
        public frmNguoiDung(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            LoadCbo();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                frmEditThemNguoiDung ctl = new frmEditThemNguoiDung(null, true);
                ctl.Size = new System.Drawing.Size(675, 450);
                ctl.StartPosition = FormStartPosition.CenterParent;
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        private void LoadData()
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.Parameters.Add("@iID", SqlDbType.BigInt).Value = cboNhom.SelectedValue;
                cmd.Parameters.Add("sDMuc", SqlDbType.NVarChar).Value = "mnuNguoiDung";
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();

                Boolean bLoad = true;
                try { if (grdNguoiDung.DataSource != null) bLoad = false; } catch { }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNguoiDung, grvNguoiDung, dt, false, bLoad, true, false, true, this.Name);

                grvNguoiDung.Columns["GROUP_ID"].Visible = false;
                grvNguoiDung.Columns["PASS"].Visible = false;
                grvNguoiDung.Columns["GROUP_NAME"].GroupIndex = 0;
                grvNguoiDung.ExpandAllGroups();

                grvNguoiDung.Columns["TIME_LOGIN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                grvNguoiDung.Columns["TIME_LOGIN"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void grdChung_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (iPQ != 1) return;

                DataRow row = grvNguoiDung.GetDataRow(grvNguoiDung.FocusedRowHandle) as DataRow;
                frmEditThemNguoiDung ctl = new frmEditThemNguoiDung(row, false);
                ctl.Size = new System.Drawing.Size(675, 450);
                ctl.StartPosition = FormStartPosition.CenterParent;
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                frmXacNhan ctl = new frmXacNhan();
                ctl.StartPosition = FormStartPosition.CenterParent;
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                    conn.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
                    cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 2;
                    cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuNguoiDung";
                    cmd.Parameters.Add("@sUserName", SqlDbType.NVarChar).Value = grvNguoiDung.GetRowCellValue(grvNguoiDung.FocusedRowHandle, grvNguoiDung.Columns["USERNAME"]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (int.Parse(cmd.ExecuteScalar().ToString()) == 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage("frmNguoiDung", "msgXoaThanhCong"));
                        LoadData();
                    }
                    else
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage("frmNguoiDung", "msgXoaKhongThanhCong"));
                    }
                }
            }
            catch
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Name == tsmiResetPassword.Name)
                {
                    string UserName = grvNguoiDung.GetRowCellValue(grvNguoiDung.FocusedRowHandle, grvNguoiDung.Columns["USER_NAME"]).ToString();
                    XtraForm ctl = new XtraForm();
                    Type newType = Type.GetType("OEE.frmDoiMatKhau", true, true);
                    object o1 = Activator.CreateInstance(newType, UserName, 1);
                    ctl = o1 as XtraForm;
                    ctl.StartPosition = FormStartPosition.CenterParent;
                    ctl.ShowDialog();
                }

                if (e.ClickedItem.Name == tsmiKick.Name)
                {
                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                    conn.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
                    cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuDangNhap";
                    cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 2;
                    cmd.Parameters.Add("@COT12", SqlDbType.DateTime).Value = grvNguoiDung.GetRowCellValue(grvNguoiDung.FocusedRowHandle, grvNguoiDung.Columns["TIME_LOGIN"]);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            tsmiKick.Visible = false;
            tsmiResetPassword.Visible = false;
            try
            {
                if ((string.IsNullOrEmpty(grvNguoiDung.GetRowCellValue(grvNguoiDung.FocusedRowHandle, grvNguoiDung.Columns["TIME_LOGIN"]).ToString()) ? "" : " ") == " ")
                {
                    tsmiKick.Visible = true;
                }

                if ((string.IsNullOrEmpty(grvNguoiDung.GetRowCellValue(grvNguoiDung.FocusedRowHandle, grvNguoiDung.Columns["ID_USER"]).ToString()) ? "" : " ") == " ")
                {
                    tsmiResetPassword.Visible = true;
                }
            }
            catch
            {
                contextMenuStrip.Close();
            }
        }

        private void LoadCbo()
        {
            string sSQL = "SELECT GROUP_ID ID_NHOM,GROUP_NAME AS TEN_NHOM FROM dbo.NHOM UNION SELECT - 1 , '< All >' ";
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSQL));
            cboNhom.ValueMember = "ID_NHOM";
            cboNhom.DisplayMember = "TEN_NHOM";
            cboNhom.DataSource = dt;
        }

        private void cboNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhom.DataSource != null)
            {
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (iPQ != 1) return;
                DataRow row = grvNguoiDung.GetDataRow(grvNguoiDung.FocusedRowHandle) as DataRow;
                frmEditThemNguoiDung ctl = new frmEditThemNguoiDung(row, false);
                ctl.Size = new System.Drawing.Size(675, 450);
                ctl.StartPosition = FormStartPosition.CenterParent;
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}