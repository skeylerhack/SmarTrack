using System;
using System.Data;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace VS.OEE
{
    public partial class frmChangePass : DevExpress.XtraEditors.XtraForm
    {
        public frmChangePass()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void frmChangePass_Load(object sender, EventArgs e)
        {
            txtUsername.EditValue = Commons.Modules.UserName;
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            //kiểm tra mật khẩu có đúng hay không
            string sSql = "SELECT PASS FROM dbo.USERS WHERE USERNAME = '" + Commons.Modules.UserName + "'";
            if (Commons.Modules.OXtraGrid.GiaiMaDL(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql).ToString()).ToString() != txtPassold.EditValue.ToString().Trim())
            {
                Commons.Modules.msgChung("msgsaiPassword"); return;
            }
            //kiểm tra 3 mật khẩu phải giống nhau
            if(txtPassnew.Text != txtPassnew1.Text)
            {
                Commons.Modules.msgChung("msgPasswordKhongGiongNhap"); return;
            }
            //cập nhật mật khẩu
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.USERS SET PASS = N'" + Commons.Modules.OXtraGrid.MaHoaDL(txtPassnew.EditValue.ToString()) + "' WHERE USERNAME = N'" + Commons.Modules.UserName + "'");
            Commons.Modules.msgChung("msgUpdateSuccess"); return;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}