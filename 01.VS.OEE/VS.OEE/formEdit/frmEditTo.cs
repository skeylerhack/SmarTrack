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
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;

namespace VS.OEE
{
    public partial class frmEditTo : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true; // True la add, False la edit 
        static DataRow drRow;
        static int iMS_TO1;
        private DataTable dt_MS_TO = new DataTable();
        public frmEditTo(DataRow row, Boolean bAddEdit)
        {
            drRow = row;
            AddEdit = bAddEdit;
            InitializeComponent();
            try
            {
                if (drRow["MS_TO1"] == null)
                    iMS_TO1 = -1;
                else
                    iMS_TO1 = Convert.ToInt32(drRow["MS_TO1"]);
            }
            catch { iMS_TO1 = -1; }

            this.lblMS_TO.Font = new System.Drawing.Font(lblMS_TO.Font, System.Drawing.FontStyle.Bold);
            this.lblTEN_TO.Font = new System.Drawing.Font(lblTEN_TO.Font, System.Drawing.FontStyle.Bold);
        }

        private void frmTo_Load(object sender, EventArgs e)
        {
            LoadCbo();
            if (!AddEdit) LoadText();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
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
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuTo";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@iID", SqlDbType.Int).Value = iMS_TO1;
            cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtTEN_TO.Text;
            cmd.Parameters.Add("@COT11", SqlDbType.Int).Value = Convert.ToInt32(cboMS_TO.EditValue);
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
            try
            {
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDonViPhongBanTo", conn);
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuTo";
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

                dt_MS_TO = ds.Tables[1].Copy();
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMS_TO, dt_MS_TO, "MS_TO", "TEN_TO", this.Name);
                cboMS_TO.Properties.PopulateViewColumns();
                cboMS_TO.Properties.View.Columns["MS_TO"].Visible = false;
                cboMS_TO.Properties.View.Columns["STT_TO"].Visible = false;
                cboMS_TO.Properties.View.Columns["MS_DON_VI"].Visible = false;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }


        private void LoadText()
        {
            try
            {
                cboMS_DON_VI.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TPB.MS_DON_VI FROM dbo.[TO] T INNER JOIN dbo.TO_PHONG_BAN TPB ON T.MS_TO = TPB.MS_TO INNER JOIN dbo.DON_VI DV ON TPB.MS_DON_VI = DV.MS_DON_VI WHERE MS_TO1 = " + iMS_TO1).ToString();
                cboMS_TO.EditValue = Int64.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT MS_TO FROM dbo.[TO] WHERE MS_TO1 = " + iMS_TO1).ToString());
                txtTEN_TO.Text = drRow["TEN_TO1"].ToString();
            }
            catch (Exception ex)
            {
                txtTEN_TO.Text = "";
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
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuTo";
                cmd.Parameters.Add("@iID", SqlDbType.Int).Value = iMS_TO1;
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
            if (Convert.ToInt32(cboMS_TO.EditValue) == -99)
            {
                XtraMessageBox.Show(lblMS_TO.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgKhongDuocTrong"));
                cboMS_TO.Focus();
                return false;
            }
            return true;
        }

        private void cboMS_DON_VI_EditValueChanged(object sender, EventArgs e)
        {
            cboMS_TO.Properties.DataSource = null;
            DataTable dt = new DataTable();
            dt = dt_MS_TO.Select("MS_DON_VI IN ('-99', '" + cboMS_DON_VI.EditValue.ToString() +"')").CopyToDataTable().Copy();
            cboMS_TO.Properties.DataSource = dt;
        }
    }
}