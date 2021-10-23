using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
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
            LoadNN();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                XtraForm ctl;
                Type newType = Type.GetType("OEE.frmEdit" + this.Tag.ToString().Replace("mnu", "Them"), true, true);
                object o1 = Activator.CreateInstance(newType, null, true);
                ctl = o1 as XtraForm;
                ctl.StartPosition = FormStartPosition.CenterParent;
                Commons.Modules.sPS = this.Tag.ToString();
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch ( Exception ex )
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void LoadNN()
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
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
                try { if (grdChung.DataSource != null) bLoad = false; } catch { }
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChung, grvChung, dt, false, bLoad, true, false);

                grvChung.Columns[0].Visible = false;
                grvChung.Columns["ID_NHOM"].Visible = false;
                grvChung.Columns["PASSWORD"].Visible = false;
                grvChung.Columns["TEN_NHOM"].GroupIndex = 0;
                grvChung.ExpandAllGroups();

                grvChung.Columns["TIME_LOGIN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                grvChung.Columns["TIME_LOGIN"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";


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

                DataRowView vrow = grvChung.GetRow(grvChung.FocusedRowHandle) as DataRowView;
                DataRow row = grvChung.GetDataRow(grvChung.FocusedRowHandle) as DataRow;
                XtraForm ctl;
                Type newType = Type.GetType("OEE.frmEdit" + this.Tag.ToString().Replace("mnu", "Them"), true, true);
                object o1 = Activator.CreateInstance(newType, row, false);
                ctl = o1 as XtraForm;
                ctl.StartPosition = FormStartPosition.CenterParent;
                ctl.Tag = this.Tag;
                Commons.Modules.sPS = this.Tag.ToString();
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
            XtraForm ctl;
            Type newType = Type.GetType("OEE.frmXacNhan", true, true);
            object o1 = Activator.CreateInstance(newType);
            ctl = o1 as XtraForm;
            ctl.StartPosition = FormStartPosition.CenterParent;
            if (ctl.ShowDialog() == DialogResult.OK)
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 2;
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuNguoiDung";
                cmd.Parameters.Add("@iID", SqlDbType.BigInt).Value = grvChung.GetRowCellValue(grvChung.FocusedRowHandle, grvChung.Columns["ID_USER"]);
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

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Name == tsmiResetPassword.Name)
                {
                    string UserName = grvChung.GetRowCellValue(grvChung.FocusedRowHandle, grvChung.Columns["USER_NAME"]).ToString();
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
                    cmd.Parameters.Add("@COT12", SqlDbType.DateTime).Value = grvChung.GetRowCellValue(grvChung.FocusedRowHandle, grvChung.Columns["TIME_LOGIN"]);
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
                if ((string.IsNullOrEmpty(grvChung.GetRowCellValue(grvChung.FocusedRowHandle, grvChung.Columns["TIME_LOGIN"]).ToString()) ? "" : " ") == " ")
                {
                    tsmiKick.Visible = true;
                }
       
                if ((string.IsNullOrEmpty(grvChung.GetRowCellValue(grvChung.FocusedRowHandle, grvChung.Columns["ID_USER"]).ToString()) ? "" : " ") == " ")
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
            string sSQL = "SELECT ID_NHOM, CASE 0 WHEN 0 THEN TEN_NHOM WHEN 1 THEN ISNULL(NULLIF(TEN_NHOM_A, ''), TEN_NHOM) ELSE ISNULL(NULLIF(TEN_NHOM_H, ''), TEN_NHOM) END AS TEN_NHOM FROM dbo.NHOM UNION SELECT - 1 ID_NHOM, '" + Commons.Modules.ObjLanguages.GetLanguage("OEE", "frmNguoiDung", "cboNhom", Commons.Modules.TypeLanguage) + "' TEN_NHOM";
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
    }
}