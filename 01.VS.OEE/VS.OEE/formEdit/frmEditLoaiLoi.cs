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
    public partial class frmEditLoaiLoi : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit = true; // True la add, False la edit 
        static DataRow drRow;
        static int iID;
        public frmEditLoaiLoi(DataRow row, Boolean bAddEdit)
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
            this.lblID_DG.Font = new System.Drawing.Font(lblID_DG.Font, System.Drawing.FontStyle.Bold);
            this.lblDefectName.Font = new System.Drawing.Font(lblDefectName.Font, System.Drawing.FontStyle.Bold);
        }

        private void frmEditLoaiLoi_Load(object sender, EventArgs e)
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
                //kiem ten viet
                if (txtDefectName.Text != "") if (!KiemTrung(1)) return;
                //kiem ten anh
                if (txtDefectName_E.Text != "") if (!KiemTrung(2)) return;
                //kiem ten hoa
                if (txtDefectName_C.Text != "") if (!KiemTrung(3)) return;


                #region Them
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuLoaiLoi";
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iID.ToString();
                cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtDefectName.Text;
                cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtDefectName_E.Text;
                cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtDefectName_C.Text;
                cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtNote.Text;
                cmd.Parameters.Add("@COT8", SqlDbType.Int).Value = Convert.ToInt32(txtTHU_TU.EditValue);
                cmd.Parameters.Add("@COT9", SqlDbType.Int).Value = Convert.ToInt32(cboID_DG.EditValue);
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
                txtTHU_TU.Text = drRow["THU_TU"].ToString();
                txtDefectName.Text = drRow["DefectName"].ToString();
                txtDefectName_E.Text = drRow["DefectName_E"].ToString();
                txtDefectName_C.Text = drRow["DefectName_C"].ToString();
                txtNote.Text = drRow["Note"].ToString();
                cboID_DG.EditValue = (string.IsNullOrEmpty(drRow["ID"].ToString()) ? -99 : Int64.Parse(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 ID_DG FROM dbo.Defect WHERE ID = " + drRow["ID"]).ToString()));
            }
            catch (Exception ex)
            {
                txtTHU_TU.Text = "0"; txtDefectName.Text = ""; txtDefectName_E.Text = ""; txtDefectName_C.Text = ""; txtNote.Text = "";
                XtraMessageBox.Show(ex.Message);
            }
        }

        public void LoadNN()
        {
            lblID_DG.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblID_DG");
            lblTHU_TU.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblTHU_TU");
            lblDefectName.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDefectName");
            lblDefectName_E.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDefectName_E");
            lblDefectName_C.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblDefectName_C");
            lblNote.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblNote");
            btnGhi.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnGhi");
            btnThoat.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "btnThoat");
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
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spDanhMuc", conn);
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuLoaiLoi";
                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 5;
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                if (dt != null)
                {
                    Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboID_DG, dt, "ID", "DefectGroupName", this.Name);
                    cboID_DG.Properties.PopulateViewColumns();
                    cboID_DG.Properties.View.Columns[0].Visible = false;
                    cboID_DG.Properties.View.Columns["ID"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "ID");
                    cboID_DG.Properties.View.Columns["DefectGroupName"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "DefectGroupName");
                }
           
            }

            catch (Exception ex)
            {
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
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuLoaiLoi";
                cmd.Parameters.Add("@iID", SqlDbType.NVarChar).Value = iID;
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                if (Cot == 1)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtDefectName.Text;
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 2)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtDefectName_E.Text;
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                }
                if (Cot == 3)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = txtDefectName_C.Text;

                }

                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblDefectName.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtDefectName.Focus();
                    }
                    if (Cot == 2)
                    {
                        XtraMessageBox.Show(lblDefectName_E.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgDaTonTai"));
                        txtDefectName_E.Focus();
                    }
                    if (Cot == 3)
                    {
                        XtraMessageBox.Show(lblDefectName_C.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgDaTonTai"));
                        txtDefectName_C.Focus();
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