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
    public partial class frmEditDonViTinh : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true; // True la add, False la edit 
        static DataRow drRow;
        static string iDVT = "-1";
        public frmEditDonViTinh(DataRow row, Boolean bAddEdit)
        {
            drRow = row;
            AddEdit = bAddEdit;
            InitializeComponent();

            try
            {
                if (drRow["DVT"] == null)
                    iDVT = "-1";
                else
                    iDVT = drRow["DVT"].ToString();
            }
            catch { iDVT = "-1"; }

            this.lblDVT.Font = new System.Drawing.Font(lblDVT.Font, System.Drawing.FontStyle.Bold);
            this.lblTEN_1.Font = new System.Drawing.Font(lblTEN_1.Font, System.Drawing.FontStyle.Bold);
        }

        #region Event
        private void frmEditDonViTinh_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            LoadNN();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            //DVT
            if (!KiemTrung(1)) return;
            //kiem ten viet
            if (txtTEN_1.Text.Trim() != "") if (!KiemTrung(2)) return;
            //kiem ten anh
            if (txtTEN_2.Text.Trim() != "") if (!KiemTrung(3)) return;
            //kiem ten hoa
            if (txtTEN_3.Text.Trim() != "") if (!KiemTrung(4)) return;

            #region Them
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuDonViTinh";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iDVT;
            cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtDVT.Text;
            cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtTEN_1.Text;
            cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtTEN_2.Text;
            cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtTEN_3.Text;
            cmd.Parameters.Add("@COT5", SqlDbType.NVarChar).Value = txtGHI_CHU.Text;
            cmd.Parameters.Add("@COT8", SqlDbType.Int).Value = txtSO_SO_LE.EditValue;
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
        public void LoadNN()
        {
            lblDVT.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDVT");
            lblTEN_1.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTEN_1");
            lblTEN_2.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTEN_2");
            lblTEN_3.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTEN_3");
            lblSO_SO_LE.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblSO_SO_LE");
            lblGHI_CHU.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblGHI_CHU");
            btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnGhi");
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnThoat");
        }

        private void LoadText()
        {
            try
            {
                txtDVT.Text = drRow["DVT"].ToString();
                txtTEN_1.Text = drRow["TEN_1"].ToString();
                txtTEN_2.Text = drRow["TEN_2"].ToString();
                txtTEN_3.Text = drRow["TEN_3"].ToString();
                txtSO_SO_LE.EditValue = drRow["SO_SO_LE"];
                txtGHI_CHU.Text = drRow["GHI_CHU"].ToString();
               
            }
            catch (Exception ex)
            {
                txtDVT.Text = ""; txtTEN_1.Text = ""; txtTEN_2.Text = ""; txtGHI_CHU.Text = ""; txtSO_SO_LE.EditValue = 0;
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
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuDonViTinh";
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iDVT ;
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                if (Cot == 1)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtDVT.Text;
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 2)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtTEN_1.Text;
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 3)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtTEN_2.Text;
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 4)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtTEN_3.Text;
                }

                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblDVT.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtDVT.Focus();
                    }
                    if (Cot == 2)
                    {
                        XtraMessageBox.Show(lblTEN_1.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_1.Focus();
                    }
                    if (Cot == 3)
                    {
                        XtraMessageBox.Show(lblTEN_2.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_2.Focus();
                    }
                    if (Cot == 4)
                    {
                        XtraMessageBox.Show(lblTEN_3.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_3.Focus();
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