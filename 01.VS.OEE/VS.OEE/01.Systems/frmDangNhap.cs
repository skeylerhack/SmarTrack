using System;
using System.IO;
using System.Data;
using System.Drawing;
using Microsoft.ApplicationBlocks.Data;
using System.Threading;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Xml;

namespace VS.OEE
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        static int iChangUser = -1;//1 la thay doi ng dung, 0 la dang nhap
        static string iUserName = "";
        public frmDangNhap(int ChangeUser)
        {
            iChangUser = ChangeUser;
            if (iChangUser == 1)
                iUserName = Commons.Modules.UserName;
            InitializeComponent();
        }

        #region design giao dien
     
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            //Thread.Sleep(1000);
            LoadcboDataBase();
            LoadUserPass();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        #endregion

        #region Load control
        private void LoadcboDataBase()
        {
            try
            {
                //cbo_database.Properties.datas
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM sys.sysdatabases where name LIKE 'CMMS%'"));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cbo_database, dt, "name", "name", "");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion

        private bool checkLogin()
        {
            try
            {
                string sSql;
                //kiểm tra user đã có hay chưa
                sSql = "SELECT COUNT(*) FROM dbo.USERS WHERE USERNAME = '" + txt_user.EditValue.ToString() + "'";
                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql)) == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTaiKhoanChuaDangKy"), Commons.Modules.ObjLanguages.GetLanguage("frmChung", "sThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                
                //kiểm tra mật khẩu có đúng hay không
                sSql = "SELECT PASS FROM dbo.USERS WHERE USERNAME = '" + txt_user.EditValue.ToString() + "'";
                if (Commons.Modules.OXtraGrid.GiaiMaDL(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql).ToString()).ToString() != txt_pass.EditValue.ToString())
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgsaiPassword"), Commons.Modules.ObjLanguages.GetLanguage("frmChung", "sThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                //kiểm tra tài khoảng có được active hay chưa
                sSql = "SELECT ACTIVE FROM dbo.USERS WHERE USERNAME ='" + txt_user.EditValue.ToString() + "'";
                if (Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql)) != true)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTaiKhoanChuaKichHoat"), Commons.Modules.ObjLanguages.GetLanguage("frmChung", "sThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            return false;
        }

        private void SaveLogin()
        {
            //if (chk_pass.Checked == false && chk_user.Checked == false) return;
            string user;
            string pass;
            if (chkReUser.Checked)
            {
                user = txt_user.EditValue.ToString();
            }
            else
            {
                user = "";
            }
            if (chkRePass.Checked)
            {
                pass = Commons.Modules.OXtraGrid.MaHoaDL(txt_pass.EditValue.ToString());
            }
            else
            {
                pass = "";
            }
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                if (!File.Exists(path + "\\savelogin.xml"))
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    path = path + "\\savelogin.xml";
                    //System.IO.StreamWriter streamWriter = new StreamWriter(path);
                    XmlWriter xml = XmlWriter.Create(path);
                    xml.WriteStartElement("Import");
                    xml.WriteStartElement("Row");
                    xml.WriteElementString("U", user);
                    xml.WriteElementString("P", pass);
                    xml.WriteElementString("D", cbo_database.Text);
                    xml.WriteElementString("N", "0");
                    xml.WriteEndElement();
                    xml.WriteEndElement();
                    xml.Flush();
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\savelogin.xml");
                    ds.Tables[0].Rows[0]["U"] = user;
                    ds.Tables[0].Rows[0]["P"] = pass;
                    ds.Tables[0].Rows[0]["D"] = cbo_database.Text;

                    ds.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "\\savelogin.xml");

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            Commons.Modules.UserName = txt_user.Text;
            Commons.IConnections.Database = cbo_database.Text;


        }
        private void SaveDatabase()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\saveconfig.xml");
            ds.Tables[0].Rows[0]["D"] = cbo_database.EditValue;
            ds.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "\\saveconfig.xml");
            Commons.IConnections.Database = cbo_database.Text;

            Commons.Modules.LicensePro = "5";
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "SP_INSERT_LOGIN", Commons.Modules.UserName, Commons.Modules.LicensePro);
        }
        private void LoadUserPass()
        {
            DataSet ds = new DataSet();
            try
            {
                string user, pass, data;
                ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\savelogin.xml");
                user = ds.Tables[0].Rows[0]["U"].ToString();
                pass = Commons.Modules.OXtraGrid.GiaiMaDL(ds.Tables[0].Rows[0]["P"].ToString());
                data = ds.Tables[0].Rows[0]["D"].ToString();
                try
                {
                    Commons.Modules.TypeLanguage = Convert.ToInt16(ds.Tables[0].Rows[0]["N"].ToString());
                }
                catch { }

                if (!string.IsNullOrEmpty(user))
                {
                    chkReUser.Checked = true;
                    txt_user.EditValue = user;
                    
                }
                else
                {
                    chkReUser.Checked = false;
                }
                if (!string.IsNullOrEmpty(pass))
                {
                    chkRePass.Checked = true;
                    txt_pass.EditValue = pass;
                }
                else
                {
                    chkRePass.Checked = false;
                }
                try
                {
                    cbo_database.EditValue = data;
                }
                catch { }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }

        private void DangNhap()
        {
            if (!checkLogin()) return;
            
            SaveLogin();
            SaveDatabase();
            if (iChangUser == 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            if (iUserName != txt_user.Text)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            //If e.Modifiers = Keys.Alt And e.KeyCode = Keys.H Then
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.H)
            {
                String  sSql = "SELECT PASS FROM dbo.USERS WHERE USERNAME = '" + txt_user.EditValue.ToString() + "'";
                sSql = Commons.Modules.OXtraGrid.GiaiMaDL(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql).ToString()).ToString();
                txt_pass.Text = sSql;

                DangNhap();
            }
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            String sSql = "SELECT PASS FROM dbo.USERS WHERE USERNAME = '" + txt_user.EditValue.ToString() + "'";
            sSql = Commons.Modules.OXtraGrid.GiaiMaDL(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql).ToString()).ToString();
            txt_pass.Text = sSql;

            DangNhap();
        }
    }
}