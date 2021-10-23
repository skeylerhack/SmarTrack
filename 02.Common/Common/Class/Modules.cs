using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Commons
{
    
    public class Modules
    {
        
        private static string _ModuleName;
        private static string myHost = System.Net.Dns.GetHostName();

        public static List<string> lstControlName
        {
            get
            {
                return _lstControlName;
            }
            set
            {
                _lstControlName = value;
            }
        }

        // Private Shared _lstControlName As New List(Of String)(New String() {"LookUpEdit", "Label", "RadioButton", "CheckBox", "GroupBox", "TabPage", "LabelControl", "CheckButton", "CheckEdit", "XtraTabPage", "GroupControl", "Button", "SimpleButton", "RadioGroup", "CheckedListBoxControl", "XtraTabControl", "GridControl", "DataGridView", "DataGridViewNew", "DataGridViewEditor", "NavBarControl", "navBarControl", "TextEdit", "TextBox", "ComboBox", "ButtonEdit", "MemoEdit"}) '"DateEdit",

        private static List<string> _lstControlName = new List<string>(new string[] { "LookUpEdit", "RadioButton", "CheckBox", "GroupBox", "TabPage", "LabelControl", "CheckButton", "CheckEdit", "XtraTabPage", "GroupControl", "Button", "SimpleButton", "RadioGroup", "CheckedListBoxControl", "XtraTabControl", "GridControl", "DataGridView", "DataGridViewNew", "DataGridViewEditor", "NavBarControl", "navBarControl", "BarManager", "TextEdit", "tablePanel", "navigationFrame", "navigationPage", "LayoutControlGroup" });

        //dinh nghia ID cho cac form danh muc khi tra ve
        private static string _sId;
        public static string sId
        {
            get
            {
                return _sId;
            }
            set
            {
                _sId = value;
            }
        }

        
        
        private static DateTime _DemoDate;
        public static DateTime DemoDate
        {
            get
            {
                return _DemoDate;
            }
            set
            {
                _DemoDate = value;
            }
        }
        private static bool _LicDemo;
        public static bool LicDemo
        {
            get
            {
                return _LicDemo;
            }
            set
            {
                _LicDemo = value;
            }
        }

        private static string _LicensePro;
        public static string LicensePro
        {
            get
            {
                return _LicensePro;
            }
            set
            {
                _LicensePro = value;
            }
        }

        
        //dinh nghia cau store dung cho toan bo danh muc
        private static string _sPS;
        public static string sPS
        {
            get
            {
                return _sPS;
            }
            set
            {
                _sPS = value;
            }
        }
        private static Int64 _iCongNhan;
        public static Int64 iCongNhan
        {
            get
            {
                return _iCongNhan;
            }
            set
            {
                _iCongNhan = value;
            }
        }

        //dinh nghia phan quyen       //1 Full ,2Read Only,3No access
        //dtTempt.Rows.Add(1, "Full access");
        //dtTempt.Rows.Add(2, "Read Only");
        private static int _iPermission;
        public static int iPermission
        {
            get
            {
                return _iPermission;
            }
            set
            {
                _iPermission = value;
            }
        }


        public static string ModuleName
        {
            get
            {
                return _ModuleName;
            }
            set
            {
                _ModuleName = value;
            }
        }

        private static string _UserName = string.Empty;
        public static string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }

        private static int _TypeLanguage;
        public static int TypeLanguage
        {
            get
            {
                return _TypeLanguage;
            }
            set
            {
                _TypeLanguage = value;
            }
        }

        private static OSystems _OSystems = new OSystems();
        public static OSystems ObjSystems
        {
            get
            {
                return _OSystems;
            }
            set
            {
                _OSystems = value;
            }
        }


        private static OXtraGrid _OXtraGrid = new OXtraGrid();
        public static OXtraGrid OXtraGrid
        {
            get
            {
                return _OXtraGrid;
            }
            set
            {
                _OXtraGrid = value;
            }
        }

        private static MExcel _MExcel = new MExcel();
        public static MExcel MExcel
        {
            get
            {
                return _MExcel;
            }
            set
            {
                _MExcel = value;
            }
        }

        private static OLanguages _OLanguages = new OLanguages();
        public static OLanguages ObjLanguages
        {
            get
            {
                return _OLanguages;
            }
            set
            {
                _OLanguages = value;
            }
        }

        // Xac dinh thong tin cong ty
        private static string _sPrivate;
        public static string sPrivate
        {
            get
            {
                return _sPrivate.ToUpper();
            }
            set
            {
                _sPrivate = value.ToUpper();
            }
        }

        private static int _iSoLeSL;
        public static int iSoLeSL
        {
            get
            {
                return _iSoLeSL;
            }
            set
            {
                _iSoLeSL = value;
            }
        }

        private static int _iSoLeDG;
        public static int iSoLeDG
        {
            get
            {
                return _iSoLeDG;
            }
            set
            {
                _iSoLeDG = value;
            }
        }

        private static int _iSoLeTT;
        public static int iSoLeTT
        {
            get
            {
                return _iSoLeTT;
            }
            set
            {
                _iSoLeTT = value;
            }
        }

        private static string _sSoLeSL;
        public static string sSoLeSL
        {
            get
            {
                return _sSoLeSL;
            }
            set
            {
                _sSoLeSL = value;
            }
        }

        private static string _sSoLeDG;
        public static string sSoLeDG
        {
            get
            {
                return _sSoLeDG;
            }
            set
            {
                _sSoLeDG = value;
            }
        }

        private static string _sSoLeTT;
        public static string sSoLeTT
        {
            get
            {
                return _sSoLeTT;
            }
            set
            {
                _sSoLeTT = value;
            }
        }

        private static string _sSoLe4;
        public static string sSoLe4
        {
            get
            {
                return _sSoLe4;
            }
            set
            {
                _sSoLe4 = value;
            }
        }

        private static string _sTenNhanVienMD;
        public static string sTenNhanVienMD
        {
            get
            {
                return _sTenNhanVienMD;
            }
            set
            {
                _sTenNhanVienMD = value;
            }
        }

        private static string _sMaNhanVienMD;
        public static string sMaNhanVienMD
        {
            get
            {
                return _sMaNhanVienMD;
            }
            set
            {
                _sMaNhanVienMD = value;
            }
        }



     




        #region Convert 

        public static String ToStr(object e)
        {
            try
            {
                if (e == null) return "";
                return Convert.ToString(e);
            }
            catch
            {
                return "";
            }

        }

        public static DateTime ToDateTime(object e)
        {
            if (e == null)
                return Convert.ToDateTime("1/1/1900");
            return Convert.ToDateTime(e);
        }

        public static Decimal ToDecimal(object e)
        {
            try
            {
                if (e == null) return 0;
                decimal re = 0;
                decimal.TryParse(e.ToString(), out re);
                return re;
            }
            catch
            {
                return 0;
            }
        }

        public static Double ToDouble(object e)
        {
            try
            {
                if (e == null) return 0;
                double re = 0;
                double.TryParse(e.ToString(), out re);
                return re;
            }
            catch
            {
                return 0;
            }
        }
        public static Int16 ToInt16(object e)
        {
            try
            {
                if (e == null) return 0;
                if (e.GetType() == typeof(bool)) return Convert.ToInt16(e);
                Int16 re = 0;
                Int16.TryParse(e.ToString(), out re);
                return re;
            }
            catch
            {
                return 0;
            }

        }
        public static Int32 ToInt32(object e)
        {
            try
            {
                if (e == null) return 0;
                if (e.GetType() == typeof(bool)) return Convert.ToInt32(e);
                Int32 re = 0;
                Int32.TryParse(e.ToString(), out re);
                return re;
            }
            catch
            {
                return 0;
            }

        }
        public static Int64 ToInt64(object e)
        {
            try
            {
                if (e == null) return 0;
                if (e.GetType() == typeof(bool)) return Convert.ToInt64(e);
                Int64 re = 0;
                Int64.TryParse(e.ToString(), out re);
                return re;
            }
            catch
            {
                return 0;
            }

        }
        public static Boolean ToBoolean(object e)
        {
            try
            {
                
                Boolean re = false;
                Boolean.TryParse(e.ToString(),out re);

                return re;
            }
            catch { return false; }
            
        }

        #endregion

        #region MessageChung

  
        //xoa
        public static DialogResult msgHoi(string sThongBao)
        {
            //ThongBao.Thông_Báo

            DialogResult dl = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage("frmChung", sThongBao),
                 (Commons.Modules.TypeLanguage == 0 ? Commons.ThongBao.msgTBV : Commons.ThongBao.msgTBA), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dl;
        }
        public static DialogResult msgHoiThayThe(string sThongBao, string sThayThe)
        {
            //ThongBao.Thông_Báo

            DialogResult dl = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage("frmChung", sThongBao).Replace("msgThayThe", sThayThe),
                 (Commons.Modules.TypeLanguage == 0 ? Commons.ThongBao.msgTBV : Commons.ThongBao.msgTBA), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dl;
        }
        public static void msgChung(string sThongBao)
        {
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage("frmChung", sThongBao), (Commons.Modules.TypeLanguage == 0 ? Commons.ThongBao.msgTBV : Commons.ThongBao.msgTBA), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static void msgChung(string sThongBao, string sLoi)
        {
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage("frmChung", sThongBao) + "\n" + sLoi, (Commons.Modules.TypeLanguage == 0 ? Commons.ThongBao.msgTBV : Commons.ThongBao.msgTBA), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void msgChung(string sThongBao, string sText, Boolean bTruoc)
        {
            string sTB = "";
            if (bTruoc)
                sTB = sText + " " + Commons.Modules.ObjLanguages.GetLanguage("frmChung", sThongBao);
            else
                sTB = Commons.Modules.ObjLanguages.GetLanguage("frmChung", sThongBao) + " " + sText;

            XtraMessageBox.Show(sTB, (Commons.Modules.TypeLanguage == 0 ? Commons.ThongBao.msgTBV : Commons.ThongBao.msgTBA), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void msgform(string fName,string sKeyword)
        {
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(fName, sKeyword),Commons.Modules.ObjLanguages.GetLanguage("frmChung","sThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult msgformHoi(string fName, string sKeyword)
        {
            DialogResult dl = XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(fName, sKeyword), Commons.Modules.ObjLanguages.GetLanguage("frmChung", "sThongBao"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            return dl;
        }

        public static void msgThayThe(string sThongBao, string sThayThe)
        {
            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage("frmChung", sThongBao).Replace("msgThayThe", sThayThe), (Commons.Modules.TypeLanguage == 0 ? Commons.ThongBao.msgTBV : Commons.ThongBao.msgTBA), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void msgThayThe(string sThongBao, string sThayThe, DevExpress.XtraEditors.TextEdit control)
        {
            
            string sTmp = Commons.Modules.ObjLanguages.GetLanguage("frmChung", sThongBao).Replace("msgThayThe", sThayThe);
            control.ErrorText = sTmp;
            XtraMessageBox.Show(sTmp, (Commons.Modules.TypeLanguage == 0 ? Commons.ThongBao.msgTBV : Commons.ThongBao.msgTBA), MessageBoxButtons.OK, MessageBoxIcon.Information);
            control.Focus();
        }
        #endregion
    }
}
