using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;
using Microsoft.ApplicationBlocks.Data;

namespace VS.OEE
{
    public partial class frmEditNhomMay : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true; // True la add, False la edit 
        static DataRow drRow;
        static string iMS_NHOM_MAY;

        public frmEditNhomMay(DataRow row, Boolean bAddEdit)
        {
            drRow = row;
            AddEdit = bAddEdit;
            InitializeComponent();

            try
            {
                if (drRow["MS_NHOM_MAY"] == null)
                    iMS_NHOM_MAY = "-1";
                else
                    iMS_NHOM_MAY = drRow["MS_NHOM_MAY"].ToString();
            }
            catch { iMS_NHOM_MAY = "-1"; }

            this.lblMS_LOAI_MAY.Font = new System.Drawing.Font(lblMS_LOAI_MAY.Font, System.Drawing.FontStyle.Bold);
            this.lblMS_NHOM_MAY.Font = new System.Drawing.Font(lblMS_NHOM_MAY.Font, System.Drawing.FontStyle.Bold);
            this.lblTEN_NHOM_MAY.Font = new System.Drawing.Font(lblTEN_NHOM_MAY.Font, System.Drawing.FontStyle.Bold);
        }

        private void frmEditNhomMay_Load(object sender, EventArgs e)
        {
            LoadCbo();
            if (!AddEdit) LoadText();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                //kiem ma may
                if (!KiemTrung(1)) return;
                //kiem ten viet
                if (txtTEN_NHOM_MAY.Text != "") if (!KiemTrung(2)) return;
                //kiem ten anh
                if (txtTEN_NHOM_MAY_ANH.Text != "") if (!KiemTrung(3)) return;
                //kiem ten hoa
                if (txtTEN_NHOM_MAY_HOA.Text != "") if (!KiemTrung(4)) return;


                #region Them
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuNhomMay";
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iMS_NHOM_MAY;
                cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtMS_NHOM_MAY.Text;
                cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtTEN_NHOM_MAY.Text;
                cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtTEN_NHOM_MAY_ANH.Text;
                cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtTEN_NHOM_MAY_HOA.Text;
                cmd.Parameters.Add("@COT5", SqlDbType.NVarChar).Value = txtGHI_CHU.Text;
                cmd.Parameters.Add("@COT12", SqlDbType.NVarChar).Value = cboMS_LOAI_MAY.EditValue;
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

        private void LoadText()
        {
            try
            {
                txtMS_NHOM_MAY.Text = drRow["MS_NHOM_MAY"].ToString();
                txtTEN_NHOM_MAY.Text = drRow["TEN_NHOM_MAY"].ToString();
                txtTEN_NHOM_MAY_ANH.Text = drRow["TEN_NHOM_MAY_ANH"].ToString();
                txtTEN_NHOM_MAY_HOA.Text = drRow["TEN_NHOM_MAY_HOA"].ToString();
                txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
                cboMS_LOAI_MAY.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT MS_LOAI_MAY FROM dbo.NHOM_MAY WHERE MS_NHOM_MAY = '" + iMS_NHOM_MAY + "'").ToString();
            }
            catch (Exception ex)
            {
                txtMS_NHOM_MAY.Text = ""; txtTEN_NHOM_MAY.Text = ""; txtTEN_NHOM_MAY_ANH.Text = ""; txtTEN_NHOM_MAY_HOA.Text = ""; txtGHI_CHU.Text = "";
                XtraMessageBox.Show(ex.Message);
            }
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
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuNhomMay";
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iMS_NHOM_MAY;
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                if (Cot == 1)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtMS_NHOM_MAY.Text;
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 2)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtTEN_NHOM_MAY.Text;
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 3)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtTEN_NHOM_MAY_ANH.Text;
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";

                }
                if (Cot == 4)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtTEN_NHOM_MAY_HOA.Text;
                }

                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblMS_NHOM_MAY.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtMS_NHOM_MAY.Focus();
                    }
                    if (Cot == 2)
                    {
                        XtraMessageBox.Show(lblTEN_NHOM_MAY.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_NHOM_MAY.Focus();
                    }
                    if (Cot == 3)
                    {
                        XtraMessageBox.Show(lblTEN_NHOM_MAY_ANH.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_NHOM_MAY_ANH.Focus();
                    }
                    if (Cot == 4)
                    {
                        XtraMessageBox.Show(lblTEN_NHOM_MAY_HOA.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_NHOM_MAY_HOA.Focus();
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

        private void LoadCbo()
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuNhomMay";
                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 5;
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                if (dt != null)
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMS_LOAI_MAY, dt, "MS_LOAI_MAY", "TEN_LOAI_MAY", this.Name);
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
           
        }

    }
}
