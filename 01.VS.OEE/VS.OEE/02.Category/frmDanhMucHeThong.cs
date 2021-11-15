using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using System.Data.SqlClient;
using DevExpress.XtraEditors.DXErrorProvider;

namespace VS.OEE
{
    public partial class frmDanhMucHeThong : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;  // == 1  full; <> 1 la read only
        static int iMS_HE_THONG = -1;

        public frmDanhMucHeThong(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();

            if (iPQ != 1)
            {
                btnGhi.Visible = false;
                btnKhongGhi.Visible = false;
                btnXoa.Visible = false;
            }
            else
            {
                btnGhi.Visible = true;
                btnKhongGhi.Visible = true;
                btnXoa.Visible = true;
                txtTAI_LIEU.ReadOnly = false;
            }
            this.lblMA_HE_THONG.Font = new System.Drawing.Font(lblMA_HE_THONG.Font, System.Drawing.FontStyle.Bold);
            this.lblTEN_HE_THONG.Font = new System.Drawing.Font(lblTEN_HE_THONG.Font, System.Drawing.FontStyle.Bold);
        }
        #region Event
        private void frmLoaiBaoTri_Load(object sender, EventArgs e)
        {
            LoadTreeList();
            LockControl(true);
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void txtTAI_LIEU_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (btnGhi.Visible)
            {
                OpenFileDialog ofdHinh = new OpenFileDialog();
                ofdHinh.ShowDialog();
                if (ofdHinh.FileName == "")
                {
                    txtTAI_LIEU.Text = "";
                    return;
                }
                else
                    txtTAI_LIEU.Text = ofdHinh.FileName;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (TreeList.FocusedNode != null)
            {
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgBanCoChacXoa"), Commons.Modules.ObjLanguages.GetLanguage("frmChung", "sThongBao"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Data.SqlClient.SqlConnection conn;
                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                    conn.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spHeThong", conn);
                    cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 2;
                    cmd.Parameters.Add("@iID", SqlDbType.Int).Value = iMS_HE_THONG;
                    cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Commons.Modules.UserName;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        LoadTreeList();
                    }
                    else
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgXoa_DangSuDung"));
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            LockControl(true);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (TreeList.FocusedNode != null)
                {
                    if (!dxValidationProvider1.Validate()) return;
                    if (!KiemTrung()) return;

                    System.Data.SqlClient.SqlConnection conn;
                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                    conn.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spHeThong", conn);
                    cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
                    cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Commons.Modules.UserName;
                    cmd.Parameters.Add("@iID", SqlDbType.Int).Value = iMS_HE_THONG;
                    cmd.Parameters.Add("@MA_HE_THONG", SqlDbType.Int).Value = txtMA_HE_THONG.Text;
                    cmd.Parameters.Add("@MS_CHA", SqlDbType.NVarChar).Value = TreeList.FocusedNode["MS_HE_THONG"].ToString();
                    cmd.Parameters.Add("@TEN_HE_THONG", SqlDbType.NVarChar).Value = txtTEN_HE_THONG.Text;
                    cmd.Parameters.Add("@TEN_HE_THONG_ANH", SqlDbType.NVarChar).Value = txtTEN_HE_THONG_ANH.Text;
                    cmd.Parameters.Add("@TEN_HE_THONG_HOA", SqlDbType.NVarChar).Value = txtTEN_HE_THONG_HOA.Text;
                    cmd.Parameters.Add("@STT", SqlDbType.Int).Value = txtSTT.EditValue;
                    cmd.Parameters.Add("@TAI_LIEU", SqlDbType.NVarChar).Value = txtTAI_LIEU.Text;
                    cmd.Parameters.Add("@NO_LINE", SqlDbType.Bit).Value = chkNO_LINE.EditValue;
                    cmd.Parameters.Add("@GHI_CHU", SqlDbType.NVarChar).Value = txtGHI_CHU.Text;
                    cmd.CommandType = CommandType.StoredProcedure;

                    int MS_HE_THONG = Convert.ToInt32(cmd.ExecuteScalar());

                    if (MS_HE_THONG > -1)
                    {
                        LoadTreeList();
                        TreeList.FocusedNode = TreeList.FindNodeByFieldValue("MS_HE_THONG", MS_HE_THONG);
                    }
                    else
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgGhi_ThatBai"));
                    }
                }
              LockControl(true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgGhi_ThatBai") + "\n" + ex.Message.ToString());
            }
        }

        private void TreeList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {

                iMS_HE_THONG = Convert.ToInt32(TreeList.FocusedNode["MS_HE_THONG"]);
                LoadText();
            }
            catch
            {
            }
        }
        #endregion

        #region Function
        private void LoadTreeList()
        {
            try
            {
                TreeList.DataSource = null;

                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spHeThong", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Commons.Modules.UserName;
                cmd.Parameters.Add("@FORMNAME", SqlDbType.NVarChar).Value = this.Name;
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();

                TreeList.BeginUpdate();
                TreeList.KeyFieldName = "MS_HE_THONG";
                TreeList.ParentFieldName = "MS_CHA";
                TreeList.OptionsBehavior.Editable = false;
                TreeList.DataSource = dt;


                TreeList.PopulateColumns();

                for (int i = 0; i <= TreeList.Columns.Count - 1; i++)
                {
                    TreeList.Columns[i].Visible = false;
                }
                string sTenHT;
                if (Commons.Modules.TypeLanguage == 0)
                    sTenHT = "TEN_HE_THONG";
                else
                {
                    if (Commons.Modules.TypeLanguage == 1)
                        sTenHT = "TEN_HE_THONG_ANH";
                    else
                        sTenHT = "TEN_HE_THONG_HOA";
                }

                TreeList.Columns[sTenHT].Visible = true;
                TreeList.Columns[sTenHT].BestFit();
                TreeList.Columns[sTenHT].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblHeThong", Commons.Modules.TypeLanguage);

                TreeList.ExpandAll();
                TreeList.EndUpdate();
                try
                {

                    if (iMS_HE_THONG != -1)
                    {
                        TreeList.FocusedNode = TreeList.FindNodeByFieldValue("MS_HE_THONG", iMS_HE_THONG);
                    }
                    else
                    {
                        TreeList.FocusedNode = TreeList.FindNodeByFieldValue("MS_HE_THONG", dt.Rows[0][0]);
                    }
                }
                catch { TextTrong(); }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void TextTrong()
        {
            txtMA_HE_THONG.Text = "";
            chkNO_LINE.Checked = false;
            txtSTT.Text = "";
            txtTEN_HE_THONG.Text = "";
            txtTEN_HE_THONG_ANH.Text = "";
            txtTEN_HE_THONG_HOA.Text = "";
            txtTAI_LIEU.Text = "";
            txtGHI_CHU.Text = "";
        }

        private void LoadText()
        {
            if (TreeList.FocusedNode == null)
            {
                TextTrong();
                return;
            }
            if (TreeList.FocusedNode["MS_HE_THONG"].ToString() == "-1")
            {
                TextTrong();
            }
            else
            {
                txtMA_HE_THONG.Text = TreeList.FocusedNode["MA_HE_THONG"].ToString();
                chkNO_LINE.Checked = TreeList.FocusedNode["NO_LINE"].ToString() == "0" ? false : true;
                if (TreeList.FocusedNode["STT"].ToString() == "")
                    txtSTT.Text = "";
                else
                    txtSTT.Text = TreeList.FocusedNode["STT"].ToString();


                txtTEN_HE_THONG.Text = TreeList.FocusedNode["TEN_HE_THONG"].ToString();
                txtTEN_HE_THONG_ANH.Text = TreeList.FocusedNode["TEN_HE_THONG_ANH"].ToString();
                txtTEN_HE_THONG_HOA.Text = TreeList.FocusedNode["TEN_HE_THONG_HOA"].ToString();
                txtTAI_LIEU.Text = TreeList.FocusedNode["TAI_LIEU"].ToString();
                txtGHI_CHU.Text = TreeList.FocusedNode["GHI_CHU"].ToString();
            }
        }
        private bool KiemTrung()
        {
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spHeThong", conn);
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
            cmd.Parameters.Add("@iID", SqlDbType.Int).Value = iMS_HE_THONG;
            cmd.Parameters.Add("@MA_HE_THONG", SqlDbType.Int).Value = txtMA_HE_THONG.Text;
            cmd.Parameters.Add("@TEN_HE_THONG", SqlDbType.NVarChar).Value = txtTEN_HE_THONG.Text;
            cmd.Parameters.Add("@TEN_HE_THONG_ANH", SqlDbType.NVarChar).Value = txtTEN_HE_THONG_ANH.Text;
            cmd.Parameters.Add("@TEN_HE_THONG_HOA", SqlDbType.NVarChar).Value = txtTEN_HE_THONG_HOA.Text;
            cmd.CommandType = CommandType.StoredProcedure;

            int KIEMTRUNG = 0;
            KIEMTRUNG = Convert.ToInt32(cmd.ExecuteScalar());

            if (KIEMTRUNG == 1)
            {
                XtraMessageBox.Show(lblMA_HE_THONG.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                txtMA_HE_THONG.Focus();
                return false;
            }

            if (KIEMTRUNG == 2)
            {
                XtraMessageBox.Show(lblTEN_HE_THONG.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                txtTEN_HE_THONG.Focus();
                return false;
            }

            if (KIEMTRUNG == 3)
            {
                XtraMessageBox.Show(lblTEN_HE_THONG_ANH.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                txtTEN_HE_THONG_ANH.Focus();
                return false;
            }

            if (KIEMTRUNG == 4)
            {
                XtraMessageBox.Show(lblTEN_HE_THONG_HOA.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                txtTEN_HE_THONG_HOA.Focus();
                return false;
            }
            return true;
        }
        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {
            iMS_HE_THONG = -1;
            TextTrong();
            LockControl(false);
        }
        private void LockControl(Boolean bLock)
        {
            txtMA_HE_THONG.Properties.ReadOnly = bLock;
            chkNO_LINE.Properties.ReadOnly = bLock;
            txtGHI_CHU.Properties.ReadOnly = bLock;
            txtTEN_HE_THONG.Properties.ReadOnly = bLock;
            txtTEN_HE_THONG_ANH.Properties.ReadOnly = bLock;
            txtTEN_HE_THONG_HOA.Properties.ReadOnly = bLock;
            txtTAI_LIEU.Properties.ReadOnly = bLock;
            txtSTT.Properties.ReadOnly = bLock;

            txtTim.ReadOnly = !bLock;
            TreeList.Enabled = bLock;

            this.btnThem.Visible = bLock;
            this.btnSua.Visible = bLock;
            this.btnXoa.Visible = bLock;
            this.btnThoat.Visible = bLock;
            this.btnGhi.Visible = !bLock;
            this.btnKhongGhi.Visible = !bLock;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (iMS_HE_THONG == -1)
            {
                Commons.Modules.msgThayThe(Commons.ThongBao.msgBanChuaChonDuLieu, this.Text);
                return;
            }
            LockControl(false);
        }
    }
}

