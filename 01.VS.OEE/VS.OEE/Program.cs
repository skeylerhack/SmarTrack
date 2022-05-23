using System;
using System.Windows.Forms;
using DevExpress.UserSkins;
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
            ClsMain.LayThongTinConfig();
            Commons.Modules.ModuleName ="ECOMAIN";
            Commons.Modules.sPrivate = @"TRUNGNGUYEN";
            Commons.Modules.UserName = "admin";
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
            Commons.Modules.ObjSystems.CheckUpdate();
            Thread t = new Thread(() => MRunForm());
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        static void MRunForm()
        {
            try
            {
                //Application.Run(new frmMain());
                Application.Run(new frmQLCa(1));
                //Application.Run(new XtraForm1());
                //Application.Run(new frmThoiGianNgungMay(1));
                //Application.Run(new frmShiftLeader(1));
                //Application.Run(new frmProductOrder(1));
                //Application.Run(new frmProductOrder(1));
                //Application.Run(new frmProductRun(1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}