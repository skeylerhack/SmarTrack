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
    public partial class frmEditCA : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true; // True la add, False la edit 
        static DataRow drRow;
        static int iSTT = -1;
        public frmEditCA(DataRow row, Boolean bAddEdit)
        {
            drRow = row;
            AddEdit = bAddEdit;
            InitializeComponent();

            try
            {
                if (drRow["STT"] == null)
                    iSTT = -1;
                else
                    iSTT = Convert.ToInt32(drRow["STT"]);
            }
            catch { iSTT = -1; }

            this.lblCA.Font = new System.Drawing.Font(lblCA.Font, System.Drawing.FontStyle.Bold);
        }

        #region Event
        private void frmEditCA_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            LoadNN();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            //kiem ten viet
            if (!KiemTrung(1)) return;
            //kiem ten anh
            if (txtCA_ANH.Text.Trim() != "") if (!KiemTrung(2)) return;
            //kiem ten hoa
            if (txtCA_HOA.Text.Trim() != "") if (!KiemTrung(3)) return;

            #region Them
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuCA";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iSTT.ToString();
            cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtCA.Text;
            cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtCA_ANH.Text;
            cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtCA_HOA.Text;
            cmd.Parameters.Add("@COT6", SqlDbType.Bit).Value = chkCA_DEM.EditValue;
            cmd.Parameters.Add("@COT8", SqlDbType.Int).Value = txtTU_PHUT.EditValue;
            cmd.Parameters.Add("@COT9", SqlDbType.Int).Value = txtDEN_PHUT.EditValue;

            string[] arrTU_GIO = dedTU_GIO.EditValue.ToString().Split(':');
            DateTime dateTU_GIO = new System.DateTime(1990, 1, 1, Convert.ToInt32(arrTU_GIO[0]), Convert.ToInt32(arrTU_GIO[1]), Convert.ToInt32(arrTU_GIO[2]));
            cmd.Parameters.Add("@COT15", SqlDbType.DateTime).Value = dateTU_GIO;

            string[] arrDEN_GIO = dedDEN_GIO.EditValue.ToString().Split(':');
            DateTime dateDEN_GIO = new System.DateTime(1990, 1, 1, Convert.ToInt32(arrDEN_GIO[0]), Convert.ToInt32(arrDEN_GIO[1]), Convert.ToInt32(arrDEN_GIO[2]));
            cmd.Parameters.Add("@COT16", SqlDbType.DateTime).Value = dateDEN_GIO;

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
            lblCA.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblCA");
            lblCA_ANH.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblCA_ANH");
            lblCA_HOA.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblCA_HOA");
            lblTU_GIO.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTU_GIO");
            lblDEN_GIO.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDEN_GIO");
            lblTU_PHUT.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTU_PHUT");
            lblDEN_PHUT.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDEN_PHUT");
            chkCA_DEM.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "chkCA_DEM");
            btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnGhi");
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnThoat");
        }

        private void LoadText()
        {
            try
            {
                txtCA.Text = drRow["CA"].ToString();
                txtCA_ANH.Text = drRow["CA_ANH"].ToString();
                txtCA_HOA.Text = drRow["CA_HOA"].ToString();
                dedTU_GIO.EditValue = Convert.ToDateTime(drRow["TU_GIO"]).TimeOfDay;
                dedDEN_GIO.EditValue = Convert.ToDateTime(drRow["DEN_GIO"]).TimeOfDay;
                txtTU_PHUT.Text = drRow["TU_PHUT"].ToString();
                txtDEN_PHUT.Text = drRow["DEN_PHUT"].ToString();
                chkCA_DEM.EditValue = Convert.ToBoolean(string.IsNullOrEmpty(drRow["CA_DEM"].ToString()) ? 0 : drRow["CA_DEM"]);
            }
            catch (Exception ex)
            {
                txtCA.Text = ""; txtCA_ANH.Text = ""; txtCA_HOA.Text = ""; txtTU_PHUT.Text = ""; txtDEN_PHUT.Text = ""; dedTU_GIO.Text = ""; dedDEN_GIO.Text = ""; chkCA_DEM.Text = ""; chkCA_DEM.EditValue = false;
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
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuCA";
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iSTT.ToString();
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                if (Cot == 1)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtCA.Text;
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 2)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtCA_ANH.Text;
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 3)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtCA_HOA.Text;

                }
                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblCA.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtCA.Focus();
                    }
                    if (Cot == 2)
                    {
                        XtraMessageBox.Show(lblCA_ANH.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtCA_ANH.Focus();
                    }
                    if (Cot == 3)
                    {
                        XtraMessageBox.Show(lblCA_HOA.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtCA_HOA.Focus();
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