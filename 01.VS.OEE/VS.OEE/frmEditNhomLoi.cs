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
    public partial class frmEditNhomLoi : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true; // True la add, False la edit 
        static DataRow drRow;
        static int iID;
        public frmEditNhomLoi(DataRow row, Boolean bAddEdit)
        {
            drRow = row;
            AddEdit = bAddEdit;

            InitializeComponent();
            try
            {
                if (drRow["ID"] == null)
                    iID = -1;
                else
                    iID = Convert.ToInt32(drRow["ID"]);
            }
            catch { iID = -1; }
            this.lblDefectGroupName.Font = new System.Drawing.Font(lblDefectGroupName.Font, System.Drawing.FontStyle.Bold);
        }

        private void frmEditNhomLoi_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            LoadNN();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                //kiem ten viet
                if (txtDefectGroupName.Text.Trim() != "") if (!KiemTrung(1)) return;
                //kiem ten anh
                if (txtDefectGroupName_C.Text.Trim() != "") if (!KiemTrung(2)) return;
                //kiem ten hoa
                if (txtDefectGroupName_E.Text.Trim() != "") if (!KiemTrung(3)) return;


                #region Them
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuNhomLoi";
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iID.ToString();
                cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtDefectGroupName.Text;
                cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtDefectGroupName_E.Text;
                cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtDefectGroupName_C.Text;
                cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtNote.Text;
                cmd.Parameters.Add("@COT8", SqlDbType.Int).Value = Convert.ToInt32(txtTHU_TU.EditValue);
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

        private void LoadText()
        {
            try
            {
                txtTHU_TU.Text = drRow["THU_TU"].ToString();
                txtDefectGroupName.Text = drRow["DefectGroupName"].ToString();
                txtDefectGroupName_E.Text = drRow["DefectGroupName_E"].ToString();
                txtDefectGroupName_C.Text = drRow["DefectGroupName_C"].ToString();
                txtNote.Text = drRow["Note"].ToString();
            }
            catch (Exception ex)
            {
                txtTHU_TU.Text = "0"; txtDefectGroupName.Text = ""; txtDefectGroupName_E.Text = ""; txtDefectGroupName_C.Text = ""; txtNote.Text = "";
                XtraMessageBox.Show(ex.Message);
            }
        }

        public void LoadNN()
        {
            lblTHU_TU.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTHU_TU");
            lblDefectGroupName.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDefectGroupName");
            lblDefectGroupName_E.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDefectGroupName_E");
            lblDefectGroupName_C.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDefectGroupName_C");
            lblNote.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblNote");
            btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnGhi");
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnThoat");
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
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuNhomLoi";
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iID;
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                if (Cot == 1)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtDefectGroupName.Text;
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 2)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtDefectGroupName_E.Text;
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 3)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtDefectGroupName_C.Text;

                }

                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblDefectGroupName.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtDefectGroupName.Focus();
                    }
                    if (Cot == 2)
                    {
                        XtraMessageBox.Show(lblDefectGroupName_E.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgDaTonTai"));
                        txtDefectGroupName_E.Focus();
                    }
                    if (Cot == 3)
                    {
                        XtraMessageBox.Show(lblDefectGroupName_C.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgDaTonTai"));
                        txtDefectGroupName_C.Focus();
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