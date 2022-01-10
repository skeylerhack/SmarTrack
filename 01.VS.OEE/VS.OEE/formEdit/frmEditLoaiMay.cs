using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;

namespace VS.OEE
{
    public partial class frmEditLoaiMay : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true; // True la add, False la edit 
        static DataRow drRow;
        static string iMS_LOAI_MAY;
        public frmEditLoaiMay(DataRow row, Boolean bAddEdit)
        {
            drRow = row;
            AddEdit = bAddEdit;
            InitializeComponent();
            try
            {
                if (drRow["MS_LOAI_MAY"] == null)
                    iMS_LOAI_MAY = "-1";
                else
                    iMS_LOAI_MAY = drRow["MS_LOAI_MAY"].ToString();
            }
            catch { iMS_LOAI_MAY = "-1"; }
            this.lblMS_LOAI_MAY.Font = new System.Drawing.Font(lblMS_LOAI_MAY.Font, System.Drawing.FontStyle.Bold);
            this.lblTEN_LOAI_MAY.Font = new System.Drawing.Font(lblTEN_LOAI_MAY.Font, System.Drawing.FontStyle.Bold);
        }

        private void frmEditLoaiMay_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void LoadText()
        {
            try
            {
                txtMS_LOAI_MAY.Text = drRow["MS_LOAI_MAY"].ToString();
                txtSTT_MAY.Text = drRow["STT_MAY"].ToString();
                txtTEN_LOAI_MAY.Text = drRow["TEN_LOAI_MAY"].ToString();
                txtTEN_LOAI_MAY_ANH.Text = drRow["TEN_LOAI_MAY_ANH"].ToString();
                txtTEN_LOAI_MAY_HOA.Text = drRow["TEN_LOAI_MAY_HOA"].ToString();
                txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
            }
            catch (Exception ex)
            {
                txtMS_LOAI_MAY.Text = ""; txtSTT_MAY.Text = ""; txtTEN_LOAI_MAY.Text = ""; txtTEN_LOAI_MAY_ANH.Text = ""; txtTEN_LOAI_MAY_HOA.Text = ""; txtGHI_CHU.Text = "";
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                //kiem ma may
                if (!KiemTrung(1)) return;
                //kiem ten viet
                if (txtTEN_LOAI_MAY.Text.Trim() != "") if (!KiemTrung(2)) return;
                //kiem ten anh
                if (txtTEN_LOAI_MAY_ANH.Text.Trim() != "") if (!KiemTrung(3)) return;
                //kiem ten hoa
                if (txtTEN_LOAI_MAY_HOA.Text.Trim() != "") if (!KiemTrung(4)) return;
                #region Them
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuLoaiMay";
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iMS_LOAI_MAY;
                cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtMS_LOAI_MAY.Text;
                cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtTEN_LOAI_MAY.Text;
                cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtTEN_LOAI_MAY_ANH.Text;
                cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtTEN_LOAI_MAY_HOA.Text;
                cmd.Parameters.Add("@COT5", SqlDbType.NVarChar).Value = txtGHI_CHU.Text;
                cmd.Parameters.Add("@COT8", SqlDbType.Int).Value = txtSTT_MAY.EditValue;
                cmd.CommandType = CommandType.StoredProcedure;
                Commons.Modules.sId = Convert.ToString(cmd.ExecuteScalar());
                this.DialogResult = DialogResult.OK;
                #endregion
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgDelDangSuDung") + "\n" + ex.Message.ToString(), "");
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, btnGhi.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            return;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean KiemTrung(int Cot)
        {
            try
            {
                #region KiemTrung loai = 4
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuLoaiMay";
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iMS_LOAI_MAY;
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                if (Cot == 1)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtMS_LOAI_MAY.Text;
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 2)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtTEN_LOAI_MAY.Text;
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 3)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtTEN_LOAI_MAY_ANH.Text;
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";

                }
                if (Cot == 4)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtTEN_LOAI_MAY_HOA.Text;
                }
               
                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblMS_LOAI_MAY.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtMS_LOAI_MAY.Focus();
                    }
                    if (Cot == 2)
                    {
                        XtraMessageBox.Show(lblTEN_LOAI_MAY.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_LOAI_MAY.Focus();
                    }
                    if (Cot == 3)
                    {
                        XtraMessageBox.Show(lblTEN_LOAI_MAY_ANH.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_LOAI_MAY_ANH.Focus();
                    }
                    if (Cot == 4)
                    {
                        XtraMessageBox.Show(lblTEN_LOAI_MAY_HOA.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_LOAI_MAY_HOA.Focus();
                    }
                    return false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, btnGhi.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}