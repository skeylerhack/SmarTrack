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
using Microsoft.ApplicationBlocks.Data;

namespace VS.OEE
{
    public partial class frmEditToPhongBan : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true; // True la add, False la edit 
        static DataRow drRow;
        static int iMS_TO;
        public frmEditToPhongBan(DataRow row, Boolean bAddEdit)
        {
            drRow = row;
            AddEdit = bAddEdit;
            InitializeComponent();

            try
            {
                if (drRow["MS_TO"] == null)
                    iMS_TO = -1;
                else
                    iMS_TO = Convert.ToInt32(drRow["MS_TO"]);
            }
            catch { iMS_TO = -1; }

            this.lblMS_DON_VI.Font = new System.Drawing.Font(lblMS_DON_VI.Font, System.Drawing.FontStyle.Bold);
            this.lblTEN_TO.Font = new System.Drawing.Font(lblTEN_TO.Font, System.Drawing.FontStyle.Bold);
        }

        private void frmToPhongBan_Load(object sender, EventArgs e)
        {
            LoadCbo();
            if (!AddEdit) LoadText();
            LoadNN();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            //Kiem trong
            if (!dxValidationProvider1.Validate()) return;
            if (!KiemTrong()) return;
            //kiem ma don vi
            if (!KiemTrung(1)) return;

            #region Them
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDonViPhongBanTo", conn);
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuToPhongBan";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@iID", SqlDbType.Int).Value = iMS_TO;
            cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtTEN_TO.Text;
            cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = cboMS_DON_VI.EditValue.ToString();
            cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtTO_TRUONG.Text;
            cmd.Parameters.Add("@COT11", SqlDbType.Int).Value = Convert.ToInt32(txtSTT_TO.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            Commons.Modules.sId = Convert.ToString(cmd.ExecuteScalar());
            this.DialogResult = DialogResult.OK;
            #endregion
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCbo()
        {
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDonViPhongBanTo", conn);
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuToPhongBan";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 5;
            cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
            cmd.CommandType = CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Copy();

            Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMS_DON_VI, dt, "MS_DON_VI", "TEN_NGAN", this.Name);
            cboMS_DON_VI.Properties.PopulateViewColumns();
            cboMS_DON_VI.Properties.View.Columns["MS_DON_VI"].Visible = false;

        }
        public void LoadNN()
        {
            lblMS_DON_VI.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblMS_DON_VI");
            lblSTT_TO.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblSTT_TO");
            lblTEN_TO.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTEN_TO");
            lblTO_TRUONG.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTO_TRUONG");
            btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnGhi");
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnThoat");
        }

        private void LoadText()
        {
            try
            {
                txtSTT_TO.Text = drRow["STT_TO"].ToString();
                txtTEN_TO.Text = drRow["TEN_TO"].ToString();
                txtTO_TRUONG.Text = drRow["TO_TRUONG"].ToString();
                cboMS_DON_VI.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT MS_DON_VI FROM dbo.TO_PHONG_BAN WHERE MS_TO = " + iMS_TO).ToString();
            }
            catch (Exception ex)
            {
                txtSTT_TO.Text = ""; txtTEN_TO.Text = ""; txtTO_TRUONG.Text = "";
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
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuToPhongBan";
                cmd.Parameters.Add("@iID", SqlDbType.Int).Value = iMS_TO;
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                if (Cot == 1)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtTEN_TO.Text;
                }
                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblTEN_TO.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtTEN_TO.Focus();
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

        private Boolean KiemTrong()
        {
            if (cboMS_DON_VI.EditValue.ToString() == "-99")
            {
                XtraMessageBox.Show(lblMS_DON_VI.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgKhongDuocTrong"));
                cboMS_DON_VI.Focus();
                return false;
            }
            return true;
        }
    }
}