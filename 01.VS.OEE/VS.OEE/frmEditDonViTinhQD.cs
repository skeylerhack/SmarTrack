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
    public partial class frmEditDonViTinhQD : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true; // True la add, False la edit 
        static DataRow drRow;
        static Int64 iID_DVTQD = -1;
        public frmEditDonViTinhQD(DataRow row, Boolean bAddEdit)
        {
            drRow = row;
            AddEdit = bAddEdit;
            InitializeComponent();
            try
            {
                if (drRow["ID_DVTQD"] == null)
                    iID_DVTQD = -1;
                else
                    iID_DVTQD = Convert.ToInt64(drRow["ID_DVTQD"]);
            }
            catch { iID_DVTQD = -1; }

            this.lblDVT.Font = new System.Drawing.Font(lblDVT.Font, System.Drawing.FontStyle.Bold);
            this.lblDVT1.Font = new System.Drawing.Font(lblDVT1.Font, System.Drawing.FontStyle.Bold);
            this.lblHE_SO_QD.Font = new System.Drawing.Font(lblHE_SO_QD.Font, System.Drawing.FontStyle.Bold);
        }

        #region Event
        private void frmEditDonViTinhQD_Load(object sender, EventArgs e)
        {
            LoadCbo();
            if (!AddEdit) LoadText();
            LoadNN();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (!KiemTra()) return;

            #region Them
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuDonViTinhQD";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iID_DVTQD.ToString();
            cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = cboDVT.EditValue.ToString();
            cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = cboDVT1.EditValue.ToString();
            cmd.Parameters.Add("@COT10", SqlDbType.Float).Value = txtHE_SO_QD.EditValue;
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
            lblDVT1.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDVT1");
            lblHE_SO_QD.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblHE_SO_QD");
            btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnGhi");
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnThoat");
        }

        private void LoadCbo()
        {
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuDonViTinhQD";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 5;
            cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
            cmd.CommandType = CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Copy();
            Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboDVT, dt, "DVT", "TEN_DVT", this.Name);
            Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboDVT1, dt, "DVT", "TEN_DVT", this.Name);
        }

        private void LoadText()
        {
            try
            {
                cboDVT.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 DVT FROM dbo.DON_VI_TINH_QD WHERE ID_DVTQD = " + iID_DVTQD);
                cboDVT1.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 DVT1 FROM dbo.DON_VI_TINH_QD WHERE ID_DVTQD = " + iID_DVTQD);
                txtHE_SO_QD.EditValue = drRow["HE_SO_QD"];
            }
            catch (Exception ex)
            {
                cboDVT.Refresh(); cboDVT1.Refresh(); txtHE_SO_QD.EditValue = 0; 
                XtraMessageBox.Show(ex.Message);
            }
        }

        private Boolean KiemTra()
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuDonViTinhQD";
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iID_DVTQD.ToString();
                cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = cboDVT.EditValue.ToString();
                cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = cboDVT1.EditValue.ToString();
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;

                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgkhongDuocTrung"));
                    cboDVT1.Focus();
                    return false;
                }

                if (Convert.ToDecimal(txtHE_SO_QD.EditValue) < 0)
                {
                    XtraMessageBox.Show(lblHE_SO_QD.Text + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocAm"));
                    txtHE_SO_QD.Focus();
                    return false;
                }
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