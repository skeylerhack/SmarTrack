﻿using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace VS.OEE
{
    public static class ClsMain
    {
        public static bool LayThongTinConfig()
        {
            if (File.Exists(Application.StartupPath + @"\VSConfig.ini"))
            {
                var sFileInclude = System.IO.File.OpenText(Application.StartupPath + @"\VSConfig.ini");
                try
                {
                    string sRowStream = sFileInclude.ReadToEnd();
                    sRowStream = Commons.Modules.OXtraGrid.GiaiMaDL(sRowStream);
                    string[] sArr = sRowStream.Split('!');
                    Commons.IConnections.Server = sArr[0];
                    Commons.IConnections.Database = sArr[1];
                    Commons.IConnections.Username = sArr[2];
                    Commons.IConnections.Password = sArr[3];


                }
                catch (Exception Excep)
                {
                    sFileInclude.Dispose();
                    XtraMessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                XtraMessageBox.Show("Config not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public static bool Kiemtrathongtinserver()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string response = client.DownloadString("http://192.168.2.55/apiServer/api/Management/GetProcessID");
            return Convert.ToBoolean(response);
        }


       


    }
}
