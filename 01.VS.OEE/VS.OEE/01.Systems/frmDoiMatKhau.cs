using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
namespace VS.OEE
{
    public partial class frmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        static int iChangeForOther = 0; // 0 la tu doi mat khau, 1 doi mat khau cho nguoi khac
        public frmDoiMatKhau(string sUser, int ChangeForOther)
        {
            InitializeComponent();
            iChangeForOther = ChangeForOther;
            if (sUser != "-1")
            {
                Eneblecontrol(sUser);
            }
            this.lblUSER_NAME.Font = new System.Drawing.Font(lblUSER_NAME.Font, System.Drawing.FontStyle.Bold);
            this.lblPASSWORD_OLD.Font = new System.Drawing.Font(lblPASSWORD_OLD.Font, System.Drawing.FontStyle.Bold);
            this.lblPASSWORD_NEW.Font = new System.Drawing.Font(lblPASSWORD_NEW.Font, System.Drawing.FontStyle.Bold);
            this.lblPASSWORD_NEW_RE.Font = new System.Drawing.Font(lblPASSWORD_NEW_RE.Font, System.Drawing.FontStyle.Bold);
        }

        private void Eneblecontrol(string sUser)
        {
            txtUSER_NAME.EditValue = (sUser != "-1") ? sUser : Commons.Modules.UserName;

            if (iChangeForOther == 0)
            {
                txtUSER_NAME.ReadOnly = true;
                txtPASSWORD_OLD.Text = "";
                txtPASSWORD_NEW.Text = "";
                txtPASSWORD_NEW_RE.Text = "";
                this.ActiveControl = txtPASSWORD_OLD;
            }
            if (iChangeForOther == 1)
            {
                txtUSER_NAME.ReadOnly = true;
                txtPASSWORD_OLD.ReadOnly = true;
                txtPASSWORD_OLD.Text = Commons.Modules.ObjSystems.Decrypt(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT PASSWORD FROM dbo.USERS WHERE USER_NAME ='" + sUser + "'").ToString(), true);
                txtPASSWORD_NEW.Text = "";
                txtPASSWORD_NEW_RE.Text = "";
                this.ActiveControl = txtPASSWORD_NEW;
            }
        }
        private void ChangePassWord()
        {
            try
            {
                //kiêm tra pass cũ có đúng không
                string sPass = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT PASS FROM dbo.USERS WHERE USERNAME ='" + txtUSER_NAME.EditValue + "'").ToString();
                if (txtPASSWORD_OLD.EditValue.ToString() != Commons.Modules.OXtraGrid.GiaiMaDL(sPass))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgPassWorkkhongdung"), Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgChangePassword"), MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                if (txtPASSWORD_NEW.EditValue.ToString() != txtPASSWORD_NEW_RE.EditValue.ToString())
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgPassWordKhongKhop"), Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgChangePassword"), MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                //Xác nhận khi đổi mật khẩu cho người khác
                if (iChangeForOther == 1)
                {
                    XtraForm ctl;
                    Type newType = Type.GetType("OEE.frmXacNhan", true, true);
                    object o1 = Activator.CreateInstance(newType);
                    ctl = o1 as XtraForm;
                    ctl.StartPosition = FormStartPosition.CenterParent;
                    if (ctl.ShowDialog() != DialogResult.OK)
                        return;
                }
                //update password
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.USERS SET PASS = N'" + Commons.Modules.OXtraGrid.MaHoaDL(txtPASSWORD_NEW.EditValue.ToString()) + "' WHERE USERNAME = N'" + Commons.Modules.UserName + "'");
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgSaveThanhCong"), Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgChangePassword"), MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close();
                //kiểm tra pass mới có giống nhâu không
            }
            catch
            {
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ChangePassWord();
        }

        private void frmChangePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ChangePassWord();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            lblPASSWORD_NEW.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblPASSWORD_NEW");
            lblPASSWORD_NEW_RE.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblPASSWORD_NEW_RE");
            lblPASSWORD_OLD.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblPASSWORD_OLD");
            lblUSER_NAME.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "lblUSER_NAME");
        }
    }
}