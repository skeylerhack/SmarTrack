using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;

namespace VS.OEE
{
    public partial class frmEditThemNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        static Boolean AddEdit; //True la add, false la edit
        static DataRow drRow;
        static string sUserName = "-1";
        public frmEditThemNguoiDung(DataRow row, Boolean bAddEdit)
        {
            InitializeComponent();
            drRow = row;
            AddEdit = bAddEdit;

            try {
                if (drRow["USERNAME"] == null)
                    sUserName = "-1";
                else
                    sUserName = drRow["USERNAME"].ToString();
            }
            catch { sUserName = "-1"; }
            LoadCbo();
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboCongNhan, Commons.Modules.ObjSystems.DataOpetator(false), "ID", "OperatorName",Commons.Modules.ObjLanguages.GetLanguage(this.Name, "OperatorName"));
        }
        private void frmEditThemNguoiDung_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void LoadCbo()
        {
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
            cmd.Parameters.Add("@sUserName", SqlDbType.NVarChar).Value = sUserName;
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuThemNguoiDung";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 5;
            cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
            cmd.CommandType = CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Copy();
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboID_NHOM, dt, "GROUP_ID", "GROUP_NAME", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "GROUP_NAME"));
        }

        private void LoadText()
        {
            try
            {
                cboID_NHOM.EditValue = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT GROUP_ID as ID_NHOM FROM dbo.USERS WHERE USERNAME = '" + sUserName + "' "));
                txtUSER_NAME.Text = drRow["USERNAME"].ToString();
                txtFULL_NAME.Text = drRow["FULL_NAME"].ToString();
                txtPASSWORD.Text = Commons.Modules.OXtraGrid.GiaiMaDL(drRow["PASS"].ToString());
                txtDESCRIPTION.Text = drRow["DESCRIPTION"].ToString();
                txtUSER_MAIL.Text = drRow["USER_MAIL"].ToString();
                ckbACTIVE.EditValue = drRow["ACTIVE"];
                try
                {
                    cboCongNhan.EditValue = Convert.ToInt64(drRow["MS_CONG_NHAN"]);
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                txtUSER_NAME.Text = ""; txtFULL_NAME.Text = ""; txtPASSWORD.Text = ""; txtDESCRIPTION.Text = ""; txtUSER_MAIL.Text = ""; cboID_NHOM.EditValue = 0;
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                //KIEM TRA USER NAME
                if (!KiemTrung(1)) return;

                if (AddEdit == true)
                {
                    Them();
                }
                else
                {
                    frmXacNhan ctl = new frmXacNhan();
                    ctl.StartPosition = FormStartPosition.CenterParent;
                    if (ctl.ShowDialog() == DialogResult.OK)
                    {
                        Them();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, btnGhi.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Them()
        {
            #region Them
            System.Data.SqlClient.SqlConnection conn;
            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
            cmd.Parameters.Add("@sUserName", SqlDbType.NVarChar).Value = sUserName;
            cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuThemNguoiDung";
            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 3;
            cmd.Parameters.Add("@COT8", SqlDbType.Int).Value = cboID_NHOM.EditValue;
            cmd.Parameters.Add("@COT9", SqlDbType.Int).Value = cboCongNhan.EditValue;
            cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtUSER_NAME.Text;
            cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = txtFULL_NAME.Text;
            cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = Commons.Modules.OXtraGrid.MaHoaDL(txtPASSWORD.Text);
            cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = txtDESCRIPTION.Text;
            cmd.Parameters.Add("@COT5", SqlDbType.NVarChar).Value = txtUSER_MAIL.Text;
            cmd.Parameters.Add("@COT6", SqlDbType.Bit).Value = ckbACTIVE.EditValue;
            cmd.CommandType = CommandType.StoredProcedure;
            Commons.Modules.sId = Convert.ToString(cmd.ExecuteScalar());

            this.DialogResult = DialogResult.OK;
            #endregion
        }

        private Boolean KiemTrung(int Cot)
        {
            try
            {
                #region KiemTrung loai = 4
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spNguoiDung", conn);
                cmd.Parameters.Add("@sUserName", SqlDbType.NVarChar).Value = sUserName;
                cmd.Parameters.Add("@sDMuc", SqlDbType.NVarChar).Value = "mnuThemNguoiDung";
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                if (Cot == 1)
                {
                    cmd.Parameters.Add("@COT1", SqlDbType.NVarChar).Value = txtUSER_NAME.Text;
                    cmd.Parameters.Add("@COT2", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT3", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@COT4", SqlDbType.NVarChar).Value = "";
                }
          
                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    if (Cot == 1)
                    {
                        XtraMessageBox.Show(lblUSER_NAME.Text + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", "msgNayDaTonTai"));
                        txtUSER_NAME.Focus();
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

        private void btnKhong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboID_NHOM_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (e.Button.Index == 1)
            //{
            //    try
            //    {
            //        XtraForm ctl;
            //        Type newType = Type.GetType("VS.ERP.frmEditNhomNguoiDung", true, true);
            //        object o1 = Activator.CreateInstance(newType, null, true);
            //        ctl = o1 as XtraForm;
            //        ctl.StartPosition = FormStartPosition.CenterParent;
            //        if (ctl.ShowDialog() == DialogResult.OK)
            //        {
            //            LoadCbo();
            //            int ID_NHOM_cbo;
            //            ID_NHOM_cbo = int.Parse(string.IsNullOrEmpty(ctl.Tag.ToString()) ? "1" : ctl.Tag.ToString());
            //            cboID_NHOM.EditValue = ID_NHOM_cbo;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show(ex.Message);
            //    }
            //}
        }
    }
}