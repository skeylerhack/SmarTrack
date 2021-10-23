using System;
using System.Windows.Forms;
using DevExpress.UserSkins;
using System.Data;
using System.Threading;
namespace VS.OEE
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //if (args[0].ToString() == "") return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            Commons.Modules.ModuleName = "ECOMAIN";
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\saveconfig.xml");
            Commons.IConnections.Server = ds.Tables[0].Rows[0]["S"].ToString();
            Commons.IConnections.Database = ds.Tables[0].Rows[0]["D"].ToString();
            Commons.IConnections.Username = ds.Tables[0].Rows[0]["U"].ToString();
            Commons.IConnections.Password = ds.Tables[0].Rows[0]["P"].ToString();
            Commons.Modules.UserName = ds.Tables[0].Rows[0]["US"].ToString();
            //Commons.IConnections.Server = "localhost\\MSSQLSERVER01";
            //Commons.IConnections.Password = "123";
            //Commons.IConnections.Database = "CMMS_OEE";
            //Commons.IConnections.Username = "sa";

            Commons.Modules.TypeLanguage = Convert.ToInt32(ds.Tables[0].Rows[0]["LA"]);
            Properties.Settings.Default.lang = Commons.Modules.TypeLanguage;
            Commons.Modules.sPrivate = @"TRUNGNGUYEN";
            //1 Full ,2Read Only,3No access.
            Commons.Modules.iPermission = 1;
            Commons.Modules.iSoLeSL = 0;
            Commons.Modules.iSoLeDG = 2;
            Commons.Modules.iSoLeTT = 3;
            Commons.Modules.sSoLeSL = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL);
            Commons.Modules.sSoLeDG = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
            Commons.Modules.sSoLeTT = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT);
            Commons.Modules.sSoLe4 = Commons.Modules.ObjSystems.sDinhDangSoLe(4);
            Commons.Modules.TypeLanguage = Properties.Settings.Default.lang;
            Thread t = new Thread(() => MRunForm());
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        static void MRunForm()
        {
            try
            {
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}