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
using System.IO;
namespace VS.OEE
{
    public partial class frmNhaXuong : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;  // == 1  full; <> 1 la read only
        static string iMS_N_XUONG = "-1";
        public frmNhaXuong(int PQ)
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
            }
            Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblNhaXuong", Commons.Modules.TypeLanguage);
            this.lblMS_N_XUONG.Font = new System.Drawing.Font(lblMS_N_XUONG.Font, System.Drawing.FontStyle.Bold);
            this.lblTen_N_XUONG.Font = new System.Drawing.Font(lblTen_N_XUONG.Font, System.Drawing.FontStyle.Bold);
        }

        #region Event
        private void frmNhaXuong_Load(object sender, EventArgs e)
        {
            LoadCbo();
            LoadTreeList();
            LoadNN();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (TreeList.FocusedNode != null)
            {
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgBanCoChacXoa"), this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Data.SqlClient.SqlConnection conn;
                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                    conn.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNhaXuong", conn);
                    cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 2;
                    cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iMS_N_XUONG;
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
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNhaXuong", conn);
                    cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
                    cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Commons.Modules.UserName;
                    cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iMS_N_XUONG;
                    cmd.Parameters.Add("@MS_N_XUONG", SqlDbType.NVarChar).Value = txtMS_N_XUONG.Text;
                    cmd.Parameters.Add("@MS_CHA", SqlDbType.NVarChar).Value = TreeList.FocusedNode["MS_N_XUONG"].ToString();
                    cmd.Parameters.Add("@Ten_N_XUONG", SqlDbType.NVarChar).Value = txtTen_N_XUONG.Text;
                    cmd.Parameters.Add("@TEN_N_XUONG_A", SqlDbType.NVarChar).Value = txtTEN_N_XUONG_A.Text;
                    cmd.Parameters.Add("@TEN_N_XUONG_H", SqlDbType.NVarChar).Value = txtTEN_N_XUONG_H.Text;
                    cmd.Parameters.Add("@TRU_SO", SqlDbType.NVarChar).Value = txtTRU_SO.Text;
                    cmd.Parameters.Add("@NGUOI_DAI_DIEN", SqlDbType.NVarChar).Value = txtNGUOI_DAI_DIEN.Text;
                    cmd.Parameters.Add("@DIEN_THOAI", SqlDbType.NVarChar).Value = txtDIEN_THOAI.Text;
                    cmd.Parameters.Add("@DIEN_TICH", SqlDbType.Float).Value = txtDIEN_TICH.Text;
                    cmd.Parameters.Add("@KHOANG_CACH", SqlDbType.Float).Value = txtKHOANG_CACH.Text;
                    cmd.Parameters.Add("@GHI_CHU", SqlDbType.NVarChar).Value = txtGHI_CHU.Text;
                    cmd.Parameters.Add("@MS_DON_VI", SqlDbType.NVarChar).Value = cboMS_DON_VI.EditValue.ToString();

                    ImageConverter imgCon = new ImageConverter();
                    cmd.Parameters.Add("@HINH_ANH", SqlDbType.Image).Value = (byte[])imgCon.ConvertTo(pieHINH_ANH.Image, typeof(byte[]));
                    cmd.CommandType = CommandType.StoredProcedure;

                    string MS_N_XUONG = cmd.ExecuteScalar().ToString();

                    if (MS_N_XUONG != "-1")
                    {
                        LoadTreeList();
                        TreeList.FocusedNode = TreeList.FindNodeByFieldValue("MS_N_XUONG", MS_N_XUONG);
                    }
                    else
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgGhi_ThatBai"));
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgGhi_ThatBai") + "\n" + ex.Message.ToString());
            }
            
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            iMS_N_XUONG = "-1";
            TextTrong();
            StatusControl();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TreeList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            iMS_N_XUONG = TreeList.FocusedNode["MS_N_XUONG"].ToString();
            LoadText();
        }
        #endregion

        #region Function
        public void LoadNN()
        {
            lblMS_N_XUONG.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblMS_N_XUONG");
            lblTen_N_XUONG.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTen_N_XUONG");
            lblTEN_N_XUONG_A.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTEN_N_XUONG_A");
            lblTEN_N_XUONG_H.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTEN_N_XUONG_H");
            lblMS_DON_VI.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblMS_DON_VI");
            lblTRU_SO.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTRU_SO");
            lblNGUOI_DAI_DIEN.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblNGUOI_DAI_DIEN");
            lblDIEN_THOAI.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDIEN_THOAI");
            lblDIEN_TICH.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDIEN_TICH");
            lblKHOANG_CACH.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblKHOANG_CACH");
            lblGHI_CHU.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblGHI_CHU");
            lblHINH_ANH.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblHINH_ANH");
            btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnGhi");
            btnKhongGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnKhongGhi");
            btnXoa.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnXoa");
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnThoat");
        }

        private void LoadTreeList()
        {
            TreeList.DataSource = null;
            
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNhaXuong", conn);
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Commons.Modules.UserName;
            cmd.Parameters.Add("@FORMNAME", SqlDbType.NVarChar).Value = this.Name;
            cmd.CommandType = CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Copy();

            TreeList.BeginUpdate();
            TreeList.KeyFieldName = "MS_N_XUONG";
            TreeList.ParentFieldName = "MS_CHA";
            TreeList.OptionsBehavior.Editable = false;
            TreeList.DataSource = dt;

            TreeList.PopulateColumns();

            for (int i = 0; i < TreeList.Columns.Count; i++)
            {
                TreeList.Columns[i].Visible = false;
            }
            string sTen_N_Xuong;
            if (Commons.Modules.TypeLanguage == 0)
                sTen_N_Xuong = "Ten_N_XUONG";
            else
            {
                if (Commons.Modules.TypeLanguage == 1)
                    sTen_N_Xuong = "TEN_N_XUONG_A";
                else
                    sTen_N_Xuong = "TEN_N_XUONG_H";
            }

            TreeList.Columns[sTen_N_Xuong].Visible = true;
            TreeList.Columns[sTen_N_Xuong].BestFit();
            TreeList.Columns[sTen_N_Xuong].Caption = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "lblNhaXuong", Commons.Modules.TypeLanguage);

            TreeList.ExpandAll();
            TreeList.EndUpdate();
            
          
            try
            {

                if (iMS_N_XUONG != "-1")
                {
                    TreeList.FocusedNode = TreeList.FindNodeByFieldValue("MS_N_XUONG", iMS_N_XUONG);
                }
                else
                {
                    TreeList.FocusedNode = TreeList.FindNodeByFieldValue("MS_N_XUONG", ((DataTable)TreeList.DataSource).Rows[0][0]);
                }
            }
            catch { TextTrong(); }
        }

        private void TextTrong()
        {
            txtMS_N_XUONG.Text = "";
            txtTen_N_XUONG.Text = "";
            txtTEN_N_XUONG_A.Text = "";
            txtTEN_N_XUONG_H.Text = "";
            cboMS_DON_VI.EditValue = "";
            txtTRU_SO.Text = "";
            txtNGUOI_DAI_DIEN.Text = "";
            txtDIEN_THOAI.Text = "";
            txtDIEN_TICH.Text = "0";
            txtKHOANG_CACH.Text = "0";
            txtGHI_CHU.Text = "";
            pieHINH_ANH.EditValue = null;
        }

        private void LoadText()
        {
            try
            {
                if (TreeList.FocusedNode == null)
                {
                    TextTrong();
                    return;
                }
                if (TreeList.FocusedNode["MS_N_XUONG"].ToString() == "-1")
                {
                    TextTrong();
                }
                else
                {
                    txtMS_N_XUONG.Text = TreeList.FocusedNode["MS_N_XUONG"].ToString();
                    txtTen_N_XUONG.Text = TreeList.FocusedNode["Ten_N_XUONG"].ToString();
                    txtTEN_N_XUONG_A.Text = TreeList.FocusedNode["TEN_N_XUONG_A"].ToString();
                    txtTEN_N_XUONG_H.Text = TreeList.FocusedNode["TEN_N_XUONG_H"].ToString();
                    cboMS_DON_VI.EditValue = TreeList.FocusedNode["MS_DON_VI"].ToString();
                    txtTRU_SO.Text = TreeList.FocusedNode["TRU_SO"].ToString();
                    txtNGUOI_DAI_DIEN.Text = TreeList.FocusedNode["NGUOI_DAI_DIEN"].ToString();
                    txtDIEN_THOAI.Text = TreeList.FocusedNode["DIEN_THOAI"].ToString();
                    txtDIEN_TICH.Text = TreeList.FocusedNode["DIEN_TICH"].ToString();
                    txtKHOANG_CACH.Text = TreeList.FocusedNode["KHOANG_CACH"].ToString();
                    txtGHI_CHU.Text = TreeList.FocusedNode["GHI_CHU"].ToString();

                    if (TreeList.FocusedNode["HINH_ANH"] != DBNull.Value && ((Byte[])TreeList.FocusedNode["HINH_ANH"]).Length != 0)
                    {
                        Byte[] imgSource = new Byte[0];
                        imgSource = (Byte[])TreeList.FocusedNode["HINH_ANH"];
                        MemoryStream mem = new MemoryStream(imgSource);
                        pieHINH_ANH.Image = Image.FromStream(mem, true);
                    }
                    else
                        pieHINH_ANH.Image = null;
                }
                StatusControl();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);

            }
        }

        private void StatusControl()
        {
            if (iMS_N_XUONG == "-1")
            {
                txtMS_N_XUONG.ReadOnly = false;
            }
            if (iMS_N_XUONG != "-1")
            {
                txtMS_N_XUONG.ReadOnly = true;
            }
        }

        private void LoadCbo()
        {
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNhaXuong", conn);
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Commons.Modules.UserName;
            cmd.CommandType = CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Copy();
            Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMS_DON_VI, dt, "MS_DON_VI", "TEN_NGAN", this.Name);
        }

        private bool KiemTrung()
        {
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNhaXuong", conn);
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
            cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iMS_N_XUONG;
            cmd.Parameters.Add("@MS_N_XUONG", SqlDbType.NVarChar).Value = txtMS_N_XUONG.Text;
            cmd.Parameters.Add("@Ten_N_XUONG", SqlDbType.NVarChar).Value = txtTen_N_XUONG.Text;
            cmd.Parameters.Add("@TEN_N_XUONG_A", SqlDbType.NVarChar).Value = txtTEN_N_XUONG_A.Text;
            cmd.Parameters.Add("@TEN_N_XUONG_H", SqlDbType.NVarChar).Value = txtTEN_N_XUONG_H.Text;
            cmd.CommandType = CommandType.StoredProcedure;



            int KIEMTRUNG = 0;
            KIEMTRUNG = Convert.ToInt32(cmd.ExecuteScalar());

            if (KIEMTRUNG == 1)
            {
                XtraMessageBox.Show(lblMS_N_XUONG.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                txtMS_N_XUONG.Focus();
                return false;
            }

            if (KIEMTRUNG == 2)
            {
                XtraMessageBox.Show(lblTen_N_XUONG.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                txtTen_N_XUONG.Focus();
                return false;
            }

            if (KIEMTRUNG == 3)
            {
                XtraMessageBox.Show(lblTEN_N_XUONG_A.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                txtTEN_N_XUONG_A.Focus();
                return false;
            }

            if (KIEMTRUNG == 4)
            {
                XtraMessageBox.Show(lblTEN_N_XUONG_H.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                txtTEN_N_XUONG_H.Focus();
                return false;
            }
            return true;
        }
        #endregion
    }
}