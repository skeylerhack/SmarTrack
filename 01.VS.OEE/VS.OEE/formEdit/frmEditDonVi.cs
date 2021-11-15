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
using System.Reflection;

namespace VS.OEE
{
    public partial class frmEditDonVi : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true; // True la add, False la edit 
        static DataRow drRow;
        static string iMS_DON_VI;
        public frmEditDonVi(DataRow row, Boolean bAddEdit)
        {
            drRow = row;
            AddEdit = bAddEdit;
            InitializeComponent();

            try
            {
                if (drRow["MS_DON_VI"] == null)
                    iMS_DON_VI = "-1";
                else
                    iMS_DON_VI = drRow["MS_DON_VI"].ToString();
            }
            catch { iMS_DON_VI = "-1"; }

            this.lblMS_DON_VI.Font = new System.Drawing.Font(lblMS_DON_VI.Font, System.Drawing.FontStyle.Bold);
            this.lblTEN_DON_VI.Font = new System.Drawing.Font(lblTEN_DON_VI.Font, System.Drawing.FontStyle.Bold);
        }
        #region Event
        private void frmDonVi_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            //kiem ma don vi
            if (!KiemTrung(1)) return;
            //kiem ten viet
            if (txtTEN_DON_VI.Text.Trim() != "") if (!KiemTrung(2)) return;
            //kiem ten anh
            if (txtTEN_DON_VI_ANH.Text.Trim() != "") if (!KiemTrung(3)) return;
            //kiem ten hoa
            if (txtTEN_DON_VI_HOA.Text.Trim() != "") if (!KiemTrung(4)) return;

            #region Them
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDonViPhongBanTo", conn);
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuDonVi";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iMS_DON_VI;
            cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtMS_DON_VI.Text;
            cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtTEN_DON_VI.Text;
            cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtTEN_DON_VI_ANH.Text;
            cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtTEN_DON_VI_HOA.Text;
            cmd.Parameters.Add("@COT5", SqlDbType.NVarChar).Value = txtTEN_NGAN.Text;
            cmd.Parameters.Add("@COT6", SqlDbType.NVarChar).Value = txtTEN_RUT_GON.Text;
            cmd.Parameters.Add("@COT7", SqlDbType.NVarChar).Value = txtDIA_CHI.Text;
            cmd.Parameters.Add("@COT8", SqlDbType.NVarChar).Value = txtDIEN_THOAI.Text;
            cmd.Parameters.Add("@COT9", SqlDbType.NVarChar).Value = txtFAX.Text;
            cmd.Parameters.Add("@COT16", SqlDbType.Int).Value = chkTHUE_NGOAI.EditValue;
            cmd.Parameters.Add("@COT17", SqlDbType.Int).Value = chkMAC_DINH.EditValue;
            cmd.CommandType = CommandType.StoredProcedure;
            Commons.Modules.sId = Convert.ToString(cmd.ExecuteScalar());
            this.DialogResult = DialogResult.OK;
            #endregion
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Function

        private void LoadText()
        {
            try
            {
                txtMS_DON_VI.Text = drRow["MS_DON_VI"].ToString();
                txtTEN_DON_VI.Text = drRow["TEN_DON_VI"].ToString();
                txtTEN_DON_VI_ANH.Text = drRow["TEN_DON_VI_ANH"].ToString();
                txtTEN_DON_VI_HOA.Text = drRow["TEN_DON_VI_HOA"].ToString();
                txtTEN_NGAN.Text = drRow["TEN_NGAN"].ToString();
                txtTEN_RUT_GON.Text = drRow["TEN_RUT_GON"].ToString();
                txtDIA_CHI.Text = drRow["DIA_CHI"].ToString();
                txtDIEN_THOAI.Text = drRow["DIEN_THOAI"].ToString();
                txtFAX.Text = drRow["FAX"].ToString();
                chkTHUE_NGOAI.EditValue = drRow["THUE_NGOAI"];
                chkMAC_DINH.EditValue = drRow["MAC_DINH"];
            }
            catch (Exception ex)
            {
                txtMS_DON_VI.Text = ""; txtTEN_DON_VI.Text = ""; txtTEN_DON_VI_ANH.Text = ""; txtTEN_DON_VI_HOA.Text = ""; txtTEN_NGAN.Text = ""; txtTEN_RUT_GON.Text = ""; txtDIEN_THOAI.Text = ""; txtDIEN_THOAI.Text = ""; txtFAX.Text = ""; chkTHUE_NGOAI.EditValue = false; chkMAC_DINH.EditValue = false;
                XtraMessageBox.Show(ex.Message);
            }
        }

        private Boolean KiemTrung(int Cot)
        {
            try
            {
                #region KiemTrung loai = 4
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDonViPhongBanTo", conn);
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuDonVi";
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iMS_DON_VI;
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                if (Cot == 1)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtMS_DON_VI.Text;
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 2)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtTEN_DON_VI.Text;
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 3)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtTEN_DON_VI_ANH.Text;
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";

                }
                if (Cot == 4)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtTEN_DON_VI_HOA.Text;
                }

                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblMS_DON_VI.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtMS_DON_VI.Focus();
                    }
                    if (Cot == 2)
                    {
                        XtraMessageBox.Show(lblTEN_DON_VI.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_DON_VI.Focus();
                    }
                    if (Cot == 3)
                    {
                        XtraMessageBox.Show(lblTEN_DON_VI_ANH.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_DON_VI_ANH.Focus();
                    }
                    if (Cot == 4)
                    {
                        XtraMessageBox.Show(lblTEN_DON_VI_HOA.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_DON_VI_HOA.Focus();
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
        #endregion
    }
}