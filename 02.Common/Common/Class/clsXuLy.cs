using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Commons
{
    public class OXtraGrid
    {
        public string sHDD   = "-1";
        public string sLic   = "-1";
        public string sIP   = "";
        private const int _CODE_ = 354;
        public static string iId;
        private string ID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        DevExpress.XtraGrid.GridControl grd_DonVi = new DevExpress.XtraGrid.GridControl();
        public void CreateMenuReset(DevExpress.XtraGrid.GridControl grd)
        {
            grd_DonVi = grd;
            DevExpress.XtraGrid.Views.Grid.GridView grv = grd.MainView as GridView;
#pragma warning disable CS0618 // Type or member is obsolete
            grv.ShowGridMenu += Grv_ShowGridMenu;
#pragma warning restore CS0618 // Type or member is obsolete
        }
#pragma warning disable CS0618 // Type or member is obsolete
        private void Grv_ShowGridMenu(object sender, GridMenuEventArgs e)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (e.MenuType != DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
                return;
            try
            {
                DevExpress.XtraGrid.Menu.GridViewMenu headerMenu = (DevExpress.XtraGrid.Menu.GridViewMenu)e.Menu;
                if (headerMenu.Items.Count > 11) return;

                DevExpress.Utils.Menu.DXMenuItem menuItem = new DevExpress.Utils.Menu.DXMenuItem("Reset Layout Grid", new EventHandler(MyMenuItem));
                DevExpress.Utils.Menu.DXMenuItem menuSave = new DevExpress.Utils.Menu.DXMenuItem("Save Layout Grid", new EventHandler(MenuSave));
                DevExpress.Utils.Menu.DXMenuItem menuItemClear = new DevExpress.Utils.Menu.DXMenuItem("Clear Layout Grid", new EventHandler(MenuClear));
                menuItem.BeginGroup = true;
                menuItem.Tag = e.Menu;
                menuItem.BeginGroup = true;
                menuItemClear.Tag = e.Menu;
                menuSave.Tag = e.Menu;

                headerMenu.Items.Add(menuItem);
                headerMenu.Items.Add(menuItemClear);
                headerMenu.Items.Add(menuSave);

            }
            catch
            {

            }
        }
        private void MyMenuItem(System.Object sender, System.EventArgs e)
        {
            try
            {
                DevExpress.Utils.OptionsLayoutGrid opt = new DevExpress.Utils.OptionsLayoutGrid();
                opt.Columns.StoreAllOptions = true;
                grd_DonVi.MainView.RestoreLayoutFromXml(Application.StartupPath + "\\XML\\grd" + Commons.Modules.sPS.Replace("spGetList", "") + ".xml", opt);
            }
            catch
            {

                DevExpress.XtraGrid.Views.Grid.GridView grv = grd_DonVi.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                grv.PopulateColumns();
            }
        }
        public string GiaiMaDL(string str)
        {
            double dLen = str.Length;
            string sTam = "";
            for (int i = 1; i <= dLen; i++)
                sTam += Strings.ChrW((Strings.AscW(Strings.Mid(str, i, 1)) / 2) - _CODE_).ToString();
            return sTam;
        }

        public string MaHoaDL(string str)
        {
            double dLen = str.Length;
            string sTam = "";


            for (int i = 1; i <= dLen; i++)
                sTam += Strings.ChrW((Strings.AscW(Strings.Mid(str, i, 1)) + _CODE_) * 2).ToString();
            return sTam;
        }

        private void MenuClear(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (File.Exists(Application.StartupPath + "\\XML\\grd" + Commons.Modules.sPS.Replace("spGetList", "") + ".xml"))
                    File.Delete(Application.StartupPath + "\\XML\\grd" + Commons.Modules.sPS.Replace("spGetList", "") + ".xml");

                DeleteRegisterGrid();
            }
            catch
            {
            }
        }
        private void MenuSave(System.Object sender, System.EventArgs e)
        {
            try
            {
                SaveXmlGrid(grd_DonVi);
            }
            catch
            {
            }
        }



        public void SaveRegisterGrid(DevExpress.XtraGrid.GridControl grdDanhMuc)
        {
            try
            {
                DevExpress.Utils.OptionsLayoutGrid opt = new DevExpress.Utils.OptionsLayoutGrid();
                opt.Columns.StoreAllOptions = true;
                grdDanhMuc.MainView.SaveLayoutToRegistry("DevExpress\\XtraGrid\\Layouts\\HRM\\grd" + Commons.Modules.sPS.Replace("spGetList", ""), opt);
            }
            catch
            { }

        }

        public void DeleteRegisterGrid()
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("DevExpress\\XtraGrid\\Layouts\\HRM", true);
                reg.DeleteSubKeyTree("grd" + Commons.Modules.sPS.Replace("spGetList", ""));
                reg.Close();
            }
            catch
            { }
        }
        public void SaveXmlGrid(DevExpress.XtraGrid.GridControl grdDanhMuc)
        {
            DeleteRegisterGrid();
            DevExpress.Utils.OptionsLayoutGrid opt = new DevExpress.Utils.OptionsLayoutGrid();
            opt.Columns.StoreAllOptions = true;
            grdDanhMuc.MainView.SaveLayoutToXml(Application.StartupPath + "\\XML\\grd" + Commons.Modules.sPS.Replace("spGetList", "") + ".xml", opt);
            SaveRegisterGrid(grdDanhMuc);
        }

        private bool bCheckReg()
        {
            try
            {
                using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"DevExpress\XtraGrid\Layouts\HRM\grd" + Commons.Modules.sPS.Replace("spGetList", "")))
                {
                    string tmp = (string)registryKey.GetValue("(Default)");
                }
            }
            catch { return false; }
            return true;
        }

        public void loadXmlgrd(DevExpress.XtraGrid.GridControl grdDanhMuc)
        {
            try
            {
                DevExpress.Utils.OptionsLayoutGrid opt = new DevExpress.Utils.OptionsLayoutGrid();
                opt.Columns.StoreAllOptions = true;

                if (!bCheckReg())
                {
                    grdDanhMuc.MainView.RestoreLayoutFromXml(Application.StartupPath + "\\XML\\grd" + Commons.Modules.sPS.Replace("spGetList", "") + ".xml", opt);
                    SaveRegisterGrid(grdDanhMuc);
                }
                else
                    grdDanhMuc.MainView.RestoreLayoutFromRegistry("DevExpress\\XtraGrid\\Layouts\\HRM\\grd" + Commons.Modules.sPS.Replace("spGetList", ""), opt);
            }
            catch (Exception)
            {
                SaveXmlGrid(grdDanhMuc);
                loadXmlgrd(grdDanhMuc);
            }
        }

        public bool CheckService()
        {
            string stmp = "0";
            stmp = "2";
            try
            {
                var client = new UdpClient();
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 10000);

                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(sIP), Convert.ToInt32(65000));
                // Dim ep As New IPEndPoint(IPAddress.Parse(sIP), Integer.Parse(80))
                // endpoint where server is listening
                client.Connect(ep);
                stmp = "3";
                // send data
                byte[] buffer = Encoding.ASCII.GetBytes("HDD");
                client.Send(buffer, buffer.Length);
                stmp = "4";
                // then receive data
                var rev = client.Receive(ref ep);
                stmp = "41";
                // lb_stt.Text = Encoding.ASCII.GetString(rev);
                string sStr = "";
                stmp = "42";
                sStr = Encoding.ASCII.GetString(rev);
                stmp = "5";
                string[] sArr = Strings.Split(sStr, "!");
                sHDD = sArr[0];
                try
                {
                    Commons.Modules.DemoDate = Convert.ToDateTime(sArr[1].Substring(6) + "/" + sArr[1].Substring(4, 2) + "/" + sArr[1].Substring(0, 4));
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                stmp = "6";
                // send data
                buffer = Encoding.ASCII.GetBytes("LIC");
                client.Send(buffer, buffer.Length);
                stmp = "7";
                // then receive data
                rev = client.Receive(ref ep);
                stmp = "8";
                sStr = Encoding.ASCII.GetString(rev);
                sArr = null;
                sArr = Strings.Split(sStr, "!");
                try
                {
                    Commons.Modules.LicensePro = sArr[0].ToString();
                    sLic = Commons.Modules.LicensePro;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                stmp = "9";

                // send data
                buffer = Encoding.ASCII.GetBytes("LICCOM");
                client.Send(buffer, buffer.Length);
                stmp = "10";
                // then receive data
                rev = client.Receive(ref ep);
                stmp = "11";
                sStr = Encoding.Unicode.GetString(rev);
                sArr = null;
                sArr = Strings.Split(sStr, "|");

                stmp = "12";
                foreach (string sData in sArr)
                {
                    string[] sArr1 = Strings.Split(sData, "~");
                    if (sArr1.Length == 1)
                    {
                        if (sArr1[0].ToString().ToUpper() == "DEMO")
                            Commons.Modules.LicDemo = true;
                        else
                            Commons.Modules.LicDemo = false;
                    }
                    //if (sArr1.Length > 1)
                    //    sSql = IIf(sSql.Length == 0, " SELECT N'" + sArr1[0].ToString() + "' AS NAME, N'" + Commons.Modules.MExcel.MCot(sArr1[1].ToString()) + "' AS LIC, " + iSTT.ToString() + " AS STT ", sSql + " UNION SELECT N'" + sArr1[0].ToString() + "' AS NAME, N'" + Commons.Modules.MExcel.MCot(sArr1[1].ToString()) + "' AS LIC , " + iSTT.ToString() + " AS STT ");
                    //iSTT = iSTT + 1;
                }
                stmp = "13";
                client.Close();

                //////try
                //////{
                //////    if (!Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLic, sSql + " ORDER BY STT ", "LIC", "NAME", ""))
                //////    {
                //////        XtraMessageBox.Show("CheckService : " + stmp + Constants.vbLf + sSql);
                //////        return false;
                //////    }
                //////    else
                //////    {
                //////        Commons.Modules.LicensePro = int.Parse(cboLic.EditValue.ToString());
                //////        sLic = Commons.Modules.LicensePro;
                //////    }
                //////}
                //////catch (Exception ex)
                //////{
                //////    XtraMessageBox.Show("CheckService : " + Constants.vbLf + ex.Message.ToString());
                //////    return false;
                //////}

                stmp = "14";
            }
            catch (Exception ex)
            {
                // XtraMessageBox.Show(ex.ToString() & " " & stmp)
                XtraMessageBox.Show("Sever name is incorrect or service in server is not running. Please contact admin." + Constants.vbCrLf + stmp + Constants.vbCrLf + ex.Message.ToString() + Constants.vbCrLf + stmp, "CMMS Services", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Environment.Exit(0);
                return false;
            }
            return true;
        }

        public void CheckServer()
        {
            IPAddress ip= null;
            try
            {
                sIP = Commons.IConnections.Server;
                string[] sArr1 = sIP.Split('\\');

                if (sArr1.Length > 1)
                    sIP = sArr1[0];

                string myHost = System.Net.Dns.GetHostName();
                if (sIP == ".")
                    ip = Dns.GetHostEntry(myHost).AddressList.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
                else
                    try
                    {
                        ip = IPAddress.Parse(sIP);
                    }
                    catch
                    {
                        ip = Dns.GetHostEntry(sIP).AddressList.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
                    }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sever name is incorrect or service in server is not running. Please contact admin." + Constants.vbCrLf + "A" + ex.Message.ToString(), "CMMS Services", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Environment.Exit(0);
            }


            sIP = ip.ToString();
            sHDD = "-1";
            sLic = "-1";
            try
            {
                if (CheckService() == false)
                {
                    XtraMessageBox.Show("Sever name is incorrect or service in server is not running. Please contact admin." + Constants.vbCrLf + "B", "CMMS Services", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    System.Environment.Exit(0);
                }
                if (Commons.Modules.LicDemo == true)
                {
                    if (!KiemHetHan())
                        System.Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sever name is incorrect or service in server is not running. Please contact admin." + Constants.vbCrLf + "C" + ex.Message.ToString(), "CMMS Services", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Environment.Exit(0);
            }
        }

        public bool KiemHetHan()
        {
            try
            {
                System.IO.FileInfo fInfo = new System.IO.FileInfo(System.Windows.Forms.Application.StartupPath + @"\CMMS.exe");
                DateTime dateMod = fInfo.LastWriteTime.Date;
                if (DateTime.Now.Date < (DateTime)Commons.Modules.DemoDate)
                {
                    MessageBox.Show("Thời hạn chạy phiên bản dùng thử đã hết " + Application.ProductName + "Bạn vui lòng liên hệ với nhà cung cấp để được hướng dẫn.");
                    return false;
                }
                else if ((DateTime)dateMod < DateTime.Now.Date)
                {
                    MessageBox.Show("Thời hạn chạy phiên bản dùng thử đã hết " + Application.ProductName +  "Bạn vui lòng liên hệ với nhà cung cấp để được hướng dẫn.");
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }


    }
}
