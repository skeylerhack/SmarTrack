using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;

namespace VS.OEE
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        DocumentManager manager;
        public static frmMain _instance;
        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap(0);
            if (frm.ShowDialog() == DialogResult.Cancel)
            {
                Environment.Exit(Environment.ExitCode);
                return;
            }
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackgroundImage = global::VS.OEE.Properties.Resources.backmain;
                    ctl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    break;
                }
            }
            AddBarItems();
            string sVersionold = Commons.Modules.ObjSystems.LayDuLieu("Version.txt");
            barInfo.Caption = "Version: " + sVersionold.Substring(0, 4) + "." + sVersionold.Substring(4, 2) + "." + sVersionold.Substring(6, 2) + "." + sVersionold.Substring(8, 4);
            barServer.Caption = "Server: " + Commons.IConnections.Server + "- Database: " + Commons.IConnections.Database + "- Login: " + Commons.Modules.UserName + "";
            barTTC.Caption = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TEN_CTY_TIENG_VIET FROM dbo.THONG_TIN_CHUNG").ToString().ToUpper();

            manager = new DocumentManager(components);
            manager.MdiParent = this;
            manager.View = new TabbedView();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void AddBarItems()
        {
            bm.BeginUpdate();
            bar2.ClearLinks();
            bm.EndUpdate();
            DataTable dtRoot = new DataTable();

            string sSql = "SELECT DISTINCT T1.ID_MENU,T1.KEY_MENU,CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN T1.TEN_MENU WHEN 1 THEN ISNULL(NULLIF(T1.TEN_MENU_A, ''), T1.TEN_MENU) ELSE ISNULL(NULLIF(T1.TEN_MENU_H, ''), T1.TEN_MENU) END AS TEN_MENU, T1.STT_MENU FROM dbo.MENU_OEE T1 INNER JOIN dbo.NHOM_MENU_OEE T2 ON T2.ID_MENU = T1.ID_MENU INNER JOIN dbo.USERS T3 ON T3.GROUP_ID = T2.ID_NHOM WHERE(ISNULL(T1.MENU_PARENT, '') = '') AND(T3.USERNAME = '" + Commons.Modules.UserName + "') AND(ISNULL(T1.HIDE, 0) = 1) ORDER BY STT_MENU";
            dtRoot.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
            foreach (DataRow item in dtRoot.Rows)
            {
                bm.BeginUpdate();
                BarSubItem bsRoot = new BarSubItem(bm, item["TEN_MENU"].ToString());
                bsRoot.Name = item["KEY_MENU"].ToString();
                ////bsRoot.Tag = item["CONTROLS"].ToString();
                bsRoot.Id = int.Parse(item["ID_MENU"].ToString());
                ////bsRoot.Description = item["MENU_PARAMETER"].ToString();
                bm.MainMenu.AddItem(bsRoot);
                AddBarChild(bsRoot);
                bm.EndUpdate();
            }
        }

        private void AddBarChild(BarSubItem bsiRoot)
        {
            DataTable dtChild = new DataTable();
            string sSql = "SELECT DISTINCT	T1.ID_MENU,	T1.KEY_MENU,	CASE " + Commons.Modules.TypeLanguage + "	WHEN 0 THEN	T1.TEN_MENU	WHEN 1 THEN	ISNULL(NULLIF(T1.TEN_MENU_A, ''), T1.TEN_MENU)    ELSE ISNULL(NULLIF(T1.TEN_MENU_H, ''), T1.TEN_MENU)	END AS TEN_MENU,	T1.MENU_PARENT,	T1.INACTIVE,	T1.STT_MENU,	T1.CONTROLS,	CONVERT(INT, ISNULL(T1.MENU_LINE, 0)) AS MENU_LINE, T1.MENU_PARAMETER,	T1.HOT_KEY FROM dbo.MENU_OEE T1    INNER JOIN dbo.NHOM_MENU_OEE T2     ON T2.ID_MENU = T1.ID_MENU  INNER JOIN dbo.USERS T3 ON T3.GROUP_ID = T2.ID_NHOM WHERE(ISNULL(T1.MENU_PARENT, '') = N'" + bsiRoot.Name + "')    AND(T3.USERNAME = '" + Commons.Modules.UserName + "') AND(ISNULL(T1.INACTIVE, 0) = 1)    ORDER BY STT_MENU";
            dtChild.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
            foreach (DataRow item in dtChild.Rows)
            {
                DataTable dt = new DataTable();
                sSql = "SELECT DISTINCT T1.ID_MENU,T1.KEY_MENU,CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN T1.TEN_MENU WHEN 1 THEN ISNULL(NULLIF(T1.TEN_MENU_A, ''), T1.TEN_MENU)ELSE ISNULL(NULLIF(T1.TEN_MENU_H, ''), T1.TEN_MENU)END AS TEN_MENU,T1.MENU_PARENT,T1.INACTIVE,T1.STT_MENU,T1.CONTROLS,CONVERT(INT, ISNULL(T1.MENU_LINE, 0)) AS MENU_LINE,T1.MENU_PARAMETER,T1.HOT_KEY FROM dbo.MENU_OEE T1 INNER JOIN dbo.NHOM_MENU_OEE T2 ON T2.ID_MENU = T1.ID_MENU INNER JOIN dbo.USERS T3 ON T3.GROUP_ID = T2.ID_NHOM WHERE(ISNULL(T1.MENU_PARENT, '') = N'" + item["KEY_MENU"].ToString() + "')AND(T3.USERNAME = '" + Commons.Modules.UserName + "')AND(ISNULL(T1.INACTIVE, 0) = 1) ORDER BY STT_MENU";
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                if (dt.Rows.Count == 0)
                {
                    if (item["CONTROLS"].ToString().ToUpper() == "ShowNNgu".ToUpper())
                    {
                        bool bCheck = false;
                        if (Commons.Modules.TypeLanguage == 0 && item["KEY_MENU"].ToString().ToUpper() == "mnuOEENNViet".ToUpper()) bCheck = true;
                        if (Commons.Modules.TypeLanguage == 1 && item["KEY_MENU"].ToString().ToUpper() == "mnuOEENNAnh".ToUpper()) bCheck = true;
                        if (Commons.Modules.TypeLanguage == 2 && item["KEY_MENU"].ToString().ToUpper() == "mnuOEENNHoa".ToUpper()) bCheck = true;
                        BarCheckItem bbiChild = new BarCheckItem(bm, bCheck);
                        bbiChild.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                        bbiChild.Name = item["KEY_MENU"].ToString();
                        bbiChild.Tag = item["CONTROLS"].ToString();
                        bbiChild.Id = int.Parse(item["ID_MENU"].ToString());
                        bbiChild.Description = item["MENU_PARAMETER"].ToString();
                        bbiChild.Caption = item["TEN_MENU"].ToString();
                        bbiChild.Category.Name = bsiRoot.Name;
                        bbiChild.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChild_ItemClick);
                        if (int.Parse(item["MENU_LINE"].ToString()) == 1)
                            bsiRoot.AddItem(bbiChild).BeginGroup = true;
                        else
                            bsiRoot.AddItem(bbiChild);
                    }
                    else
                    {
                        BarButtonItem bbiChild = new BarButtonItem(bm, item["TEN_MENU"].ToString());
                        bbiChild.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                        bbiChild.Name = item["KEY_MENU"].ToString();
                        bbiChild.Tag = item["CONTROLS"].ToString();
                        bbiChild.Id = int.Parse(item["ID_MENU"].ToString());
                        bbiChild.Description = item["MENU_PARAMETER"].ToString();
                        bbiChild.Category.Name = bsiRoot.Name;
                        bbiChild.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChild_ItemClick);
                        if (int.Parse(item["MENU_LINE"].ToString()) == 1)
                            bsiRoot.AddItem(bbiChild).BeginGroup = true;
                        else
                            bsiRoot.AddItem(bbiChild);
                    }
                }
                else
                {
                    BarSubItem bsRoot1 = new BarSubItem(bm, item["TEN_MENU"].ToString());
                    bsRoot1.Name = item["KEY_MENU"].ToString();
                    bsRoot1.Tag = item["CONTROLS"].ToString();
                    bsRoot1.Id = int.Parse(item["ID_MENU"].ToString());
                    bsRoot1.Description = item["MENU_PARAMETER"].ToString();
                    bsRoot1.Category.Name = bsiRoot.Name;
                    if (int.Parse(item["MENU_LINE"].ToString()) == 1)
                        bsiRoot.AddItem(bsRoot1).BeginGroup = true;
                    else
                        bsiRoot.AddItem(bsRoot1);
                    AddBarChild(bsRoot1);
                }
            }
        }


        private void bbiChild_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region Kiem form active
            FormCollection frmOpen = Application.OpenForms;
            List<System.Windows.Forms.Form> ListForm = new List<System.Windows.Forms.Form>();
            foreach (System.Windows.Forms.Form frmO in frmOpen)
            {
                if (frmO.Name != "frmMain" && frmO.Name == e.Item.Name.Replace("mnuOEE", "frm"))
                {
                    ListForm.Add(frmO);
                }
            }
            if (ListForm.Count > 0)
            {
                ListForm.ForEach(f => f.Activate());
                return;
            }
            #endregion
            Commons.Modules.iPermission = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID_PERMISSION FROM dbo.NHOM_MENU_OEE WHERE ID_NHOM =(SELECT GROUP_ID FROM dbo.USERS WHERE USERNAME ='" + Commons.Modules.UserName + "') AND ID_MENU = '" + e.Item.Id + "'"));
            switch (e.Item.Tag.ToString())
            {
                case "ShowNNgu": { ShowNgonNgu((e.Item as BarCheckItem), e.Item.Description.ToString()); return; }
                case "ShowThoat":
                    {
                        if (Commons.Modules.msgHoi("msgBanCoChacThoatPhanMem") == DialogResult.No) return;
                        try
                        {
                            Commons.Modules.sPS = "0Load";
                            Environment.Exit(Environment.ExitCode);
                        }
                        catch { }
                        return;
                    }
                case "ShowDangNhap": { ShowDangNhap(e); return; }
                case "ShowDoiMatKhau":
                    {
                        frmDoiMatKhau frm = new frmDoiMatKhau(Commons.Modules.UserName, 0);
                        frm.ShowDialog();
                        return;
                    }
                case "ShowDiaDiem": { ShowDiaDiem(); return; }
                case "ShowDayChuyen": { ShowDayChuyen(); return; }
                case "ShowTTTB": { ShowTTTB(); return; }
                case "ShowHieuSuatTheoNam": { ShowHieuSuatTheoNam(); return; }
                case "ShowNhomMatHang": { ShowNhomMatHang(); return; }
                case "ShowMatHang": { ShowMatHang(); return; }
                case "ShowLenhSanXuat": { ShowLenhSanXuat(); return; }
                case "ShowSoLieuLoi": { SoLieuLoi(); return; }
                case "ShowTienDoSX": { ShowTienDoSX(); return; }
                //case "ShowThoiGianNgungMay": { ShowThoiGianNgungMay(); return; }
                //case "ShowThoiGianChayMay": { ShowThoiGianChayMay(); return; }
                case "ShowNhanVien": { ShowNhanVien(); return; }
                case "ShowThoiGiamLamViec": { ShowThoiGiamLamViec(); return; }
                case "ShowCaLamViec": { ShowCaLamViec(); return; }
                case "ShowBaoCao": { ShowBaoCao(); return; }
                case "ShowPhanQuyenTheoCN": { ShowPhanQuyenTheoCN(); return; }
                case "ShowPhanQuyenTheoDL": { ShowPhanQuyenTheoDL(); return; }
                case "ShowDSNguoiDung": { ShowDSNguoiDung(); return; }
                case "ShowNhomNguoiDung": { ShowNhomNguoiDung(); return; }
                case "ShowThongTinChung": { ShowThongTinChung(); return; }
                case "ShowBoPhanChiuPhi": { ShowBoPhanChiuPhi(); return; }
                case "ShowCa": { ShowCa(); return; }
                case "ShowDNTGNM": { ShowDinhNghiaTHNM(); return; }
                case "ShowThongSoVanHanh": { ShowThongSoVanHanh(); return; }
                case "ShowNguyenNhanNM": { ShowNguyenNhanNM(); return; }
                case "ShowLoaiNM": { ShowLoaiNM(); return; }
                case "ShowUOM": { ShowUOM(); return; }
                case "ShowUOMGroup": { ShowUOMGroup(); return; }
                case "ShowQLCa": { ShowQLCa(); return; }
                case "ShowNM_PX_TO": { ShowNM_PX_TO(); return; }
                case "ShowShiftLeader": { ShowShiftLeader(); return; }
                case "ShowVaiTro": { ShowVaiTro(); return; }
                case "ShowThoiGianNgungMay_KTTD": { ShowThoiGianNgungMay_KTTD(); return; }
                case "ShowYeuCauHoTro": { ShowYeuCauHoTro(); return; }
                case "ShowElearning": { ShowELearning(); return; }
                    
                default:
                    {
                        break;
                    }
            }
            try
            {

                string sSql = "";
                XtraForm ctl = new XtraForm();
                if (e.Item.Tag.ToString() == "") return;
                sSql = "1";
                System.Windows.Forms.Form fc = Application.OpenForms[e.Item.Name.Replace("mnu", "frm")];
                //if (fc == null) return;
                this.Cursor = Cursors.WaitCursor;
                if (e.Item.Description.ToString() == "1")
                {
                    Type newType = Type.GetType(e.Item.Tag.ToString(), true, true);
                    object o1 = Activator.CreateInstance(newType, int.Parse(sSql));
                    ctl = o1 as XtraForm;
                }
                if (e.Item.Description.ToString() == "2")
                {

                    Type newType = Type.GetType(e.Item.Tag.ToString(), true, true);
                    string DMuc = "spDanhMuc";
                    if (e.Item.Name.ToUpper() == "mnuNhomNguoiDung".ToUpper())
                    {
                        DMuc = "spNguoiDung";
                        if (Commons.Modules.UserName != "admin" && Commons.Modules.UserName != "administrator")
                        {
                            sSql = "2";
                        }
                    }

                    if (e.Item.Name.ToUpper() == "mnuOEEDonVi".ToUpper() || e.Item.Name.ToUpper() == "mnuOEETo".ToUpper() || e.Item.Name.ToUpper() == "mnuOEEToPhongBan".ToUpper())
                    {
                        DMuc = "spDonViPhongBanTo";
                    }
                    object o1 = Activator.CreateInstance(newType, int.Parse(sSql), "-1", DMuc);
                    ctl = o1 as XtraForm;
                }

                Commons.Modules.sPS = e.Item.Name;
                ctl.MdiParent = this;
                ctl.Tag = e.Item.Name;

                ctl.Text = e.Item.ToString();
                ctl.Name = e.Item.Name.Replace("mnuOEE", "frm");

                ctl.Show();

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message); }
            this.Cursor = Cursors.Default;
        }



        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            if (Commons.Modules.msgHoi("msgBanCoChacThoatPhanMem") == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        #region Load NN
        private void ShowNgonNgu(BarCheckItem barItem, string NNgu)
        {
            try
            {
                FormCollection formCollection = Application.OpenForms;
                List<System.Windows.Forms.Form> ListFormToClose = new List<System.Windows.Forms.Form>();
                foreach (System.Windows.Forms.Form form in formCollection)
                {
                    if (form.Name == "")
                    {
                        form.Close();
                    }
                    if (form.Name != "frmMain" && form.Name != "")
                    {
                        ListFormToClose.Add(form);
                    }
                }
                //ListFormToClose.ForEach(f => f.Close());
                if (formCollection.Count > 1)
                {
                    Commons.Modules.msgChung("msgVuiLongDongCacFormDangMo");

                    try { barItem.Checked = false; } catch { }
                    return;
                }
            }
            catch { }


            if (NNgu.ToUpper() == "ShowNNguViet".ToUpper()) Commons.Modules.TypeLanguage = 0;
            if (NNgu.ToUpper() == "ShowNNguAnh".ToUpper()) Commons.Modules.TypeLanguage = 1;
            if (NNgu.ToUpper() == "ShowNNguHoa".ToUpper()) Commons.Modules.TypeLanguage = 2;

            string path = System.IO.Directory.GetCurrentDirectory();
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\savelogin.xml");
            ds.Tables[0].Rows[0]["N"] = Commons.Modules.TypeLanguage;
            ds.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "\\savelogin.xml");


            AddBarItems();
            try { if (!barItem.Checked) barItem.Checked = true; } catch { }

        }
        #endregion

        #region Dang Nhap
        private void ShowDangNhap(ItemClickEventArgs e)
        {
            //Xóa tài khoản đăng nhập
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE FROM [dbo].[LOGIN] WHERE USER_LOGIN = N'" + Commons.Modules.UserName + "'  ");

            //Load frmDangNHap
            frmDangNhap frmDN = new frmDangNhap(1);
            //Xóa các form con
            if (frmDN.ShowDialog() != DialogResult.OK) return;

            FormCollection formCollection = Application.OpenForms;
            List<XtraForm> ListFormToClose = new List<XtraForm>();
            foreach (XtraForm form in formCollection)
            {
                if (form.Name != "frmMain" && form.Name != e.Item.Name.Replace("mnu", "frm"))
                {
                    ListFormToClose.Add(form);
                }
            }
            ListFormToClose.ForEach(f => f.Close());

            bm.Items.Clear();
            AddBarItems();

        }
        #endregion

        #region frmNhaXuong
        private void ShowDiaDiem()
        {
            this.Cursor = Cursors.WaitCursor;
            frmNhaXuong frm = new frmNhaXuong(Commons.Modules.iPermission);
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region frmDanhMucHeThong
        private void ShowDayChuyen()
        {
            this.Cursor = Cursors.WaitCursor;
            frmDanhMucHeThong frm = new frmDanhMucHeThong(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowTTTB
        private void ShowTTTB()
        {
            this.Cursor = Cursors.WaitCursor;
            frmThongTinThietBi frm = new frmThongTinThietBi(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowHieuSuatTheoNam
        private void ShowHieuSuatTheoNam()
        {
            this.Cursor = Cursors.WaitCursor;
            frmHieuSuatTheoThang frm = new frmHieuSuatTheoThang(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowNhomMatHang
        private void ShowNhomMatHang()
        {
            this.Cursor = Cursors.WaitCursor;
            frmItemGroup frm = new frmItemGroup(Commons.Modules.iPermission);
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowMatHang
        private void ShowMatHang()
        {
            this.Cursor = Cursors.WaitCursor;
            frmItemMay frm = new frmItemMay(Commons.Modules.iPermission);
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowLenhSanXuat
        private void ShowLenhSanXuat()
        {
            this.Cursor = Cursors.WaitCursor;
            frmProductOrder frm = new frmProductOrder(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region SoLieuLoi
        private void SoLieuLoi()
        {
            this.Cursor = Cursors.WaitCursor;
            frmQLChatLuong frm = new frmQLChatLuong(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowTienDoSX
        private void ShowTienDoSX()
        {
            this.Cursor = Cursors.WaitCursor;
            frmProductRun frm = new frmProductRun(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowThoiGianNgungMay
        //private void ShowThoiGianNgungMay()
        //{
        //    this.Cursor = Cursors.WaitCursor;
        //    frmThongTinThietBi frm = new frmThongTinThietBi(Commons.Modules.iPermission);
        //    frm.WindowState = FormWindowState.Maximized;
        //    frm.MdiParent = this;
        //    frm.Show();
        //    this.Cursor = Cursors.Default;
        //}
        #endregion

        #region ShowThoiGianChayMay
        //private void ShowThoiGianChayMay()
        //{
        //    this.Cursor = Cursors.WaitCursor;
        //    frmThongTinThietBi frm = new frmThongTinThietBi(Commons.Modules.iPermission);
        //    frm.WindowState = FormWindowState.Maximized;
        //    frm.MdiParent = this;
        //    frm.Show();
        //    this.Cursor = Cursors.Default;
        //}
        #endregion

        #region ShowNhanVien
        private void ShowNhanVien()
        {
            this.Cursor = Cursors.WaitCursor;
            frmQuanlynhanvien frm = new frmQuanlynhanvien(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowThoiGiamLamViec
        private void ShowThoiGiamLamViec()
        {
            //this.Cursor = Cursors.WaitCursor;
            //frmThongTinThietBi frm = new frmThongTinThietBi(Commons.Modules.iPermission);
            //frm.WindowState = FormWindowState.Maximized;
            //frm.MdiParent = this;
            //frm.Show();
            //this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowCaLamViec
        private void ShowCaLamViec()
        {
            this.Cursor = Cursors.WaitCursor;
            frmOperator frm = new frmOperator(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion
        #region ShowPhanQuyenTheoCN
        private void ShowPhanQuyenTheoCN()
        {
            this.Cursor = Cursors.WaitCursor;
            frmPhanQuyenChucNang frm = new frmPhanQuyenChucNang(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }

        #endregion

        #region ShowThongTinChung
        private void ShowThongTinChung()
        {
            this.Cursor = Cursors.WaitCursor;
            frmThongTinChung frm = new frmThongTinChung(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }

        #endregion

        #region ShowNguyenNhanNM
        private void ShowNguyenNhanNM()
        {
            this.Cursor = Cursors.WaitCursor;
            frmDownTimeCause frm = new frmDownTimeCause(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowUOM
        private void ShowUOM()
        {
            this.Cursor = Cursors.WaitCursor;
            frmUOM frm = new frmUOM(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowUOMGroup
        private void ShowUOMGroup()
        {
            this.Cursor = Cursors.WaitCursor;
            frmUOMGroup frm = new frmUOMGroup(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowLoaiNM
        private void ShowLoaiNM()
        {
            this.Cursor = Cursors.WaitCursor;
            frmDownTimeType frm = new frmDownTimeType(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowThongSoVanHanh
        private void ShowThongSoVanHanh()
        {
            this.Cursor = Cursors.WaitCursor;
            frmThongSoVanHanh frm = new frmThongSoVanHanh(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion
        #region ShowDinhNghiaTHNM
        private void ShowDinhNghiaTHNM()
        {
            this.Cursor = Cursors.WaitCursor;
            frmDeviceCause frm = new frmDeviceCause(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion
        #region ShowCa
        private void ShowCa()
        {
            this.Cursor = Cursors.WaitCursor;
            frmOperator frm = new frmOperator(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion
        #region ShowBoPhanChiuPhi
        private void ShowBoPhanChiuPhi()
        {
            this.Cursor = Cursors.WaitCursor;
            frmBoPhanChiuPhi frm = new frmBoPhanChiuPhi(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowNhomNguoiDung
        private void ShowNhomNguoiDung()
        {
            this.Cursor = Cursors.WaitCursor;
            frmNhomNguoiDung frm = new frmNhomNguoiDung(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowPhanQuyenTheoCN
        private void ShowDSNguoiDung()
        {
            this.Cursor = Cursors.WaitCursor;
            frmNguoiDung frm = new frmNguoiDung(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowPhanQuyenTheoCN
        private void ShowPhanQuyenTheoDL()
        {
            this.Cursor = Cursors.WaitCursor;
            frmPhanQuyenDuLieu frm = new frmPhanQuyenDuLieu(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowBaoCao
        private void ShowBaoCao()
        {
            this.Cursor = Cursors.WaitCursor;
            frmReport frm = new frmReport();
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowQLCa
        private void ShowQLCa()
        {
            this.Cursor = Cursors.WaitCursor;
            frmQLCa frm = new frmQLCa(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowNM_PX_TO
        private void ShowNM_PX_TO()
        {
            this.Cursor = Cursors.WaitCursor;
            frmNM_PX_TO frm = new frmNM_PX_TO(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowShiftLeader
        private void ShowShiftLeader()
        {
            this.Cursor = Cursors.WaitCursor;
            frmShiftLeader frm = new frmShiftLeader(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowVaiTro
        private void ShowVaiTro()
        {
            this.Cursor = Cursors.WaitCursor;
            frmVaiTro frm = new frmVaiTro(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowThoiGianNgungMay_KTTD
        private void ShowThoiGianNgungMay_KTTD()
        {
            this.Cursor = Cursors.WaitCursor;
            frmThoiGianNgungMay_KTTD frm = new frmThoiGianNgungMay_KTTD(Commons.Modules.iPermission);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion


       
        public void ShowYeuCauHoTro()
        {
            string sTenCty = "VietSoft";
            string sMail = "sales@vietsoft.com.vn";
            string sDThoai = "(028) 38 110 770";
            string iCus = "(028) 38 110 770";

            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT  ISNULL(EMAIL,'') AS EMAIL,ISNULL(Phone,'') AS DIEN_THOAI, CASE "+Commons.Modules.TypeLanguage.ToString() +" WHEN 0 THEN TEN_CTY_TIENG_VIET ELSE ISNULL(NULLIF(TEN_CTY_TIENG_ANH,''), TEN_CTY_TIENG_VIET)	END AS TEN_CTY,ISNULL(CustomerID,'-1') AS CustomerID FROM THONG_TIN_CHUNG"));

                sTenCty = dt.Rows[0]["TEN_CTY"].ToString();
                sMail = dt.Rows[0]["EMAIL"].ToString();
                sDThoai = dt.Rows[0]["DIEN_THOAI"].ToString();
                iCus = dt.Rows[0]["CustomerID"].ToString();
            }
            catch { }


            Vs.Support.frmSupport frm = new Vs.Support.frmSupport(Commons.IConnections.CNStr, Commons.Modules.TypeLanguage, Commons.Modules.UserName, Commons.Modules.sTenNhanVienMD, Commons.Modules.ModuleName, sTenCty, sMail, sDThoai, sDThoai, int.Parse(iCus));

            frm.ShowDialog();
        }

        public  void ShowELearning()
        {
            try
            {
                //Vs.Support.frmELearning frm = new Vs.Support.frmELearning(4);
                //frm.ShowDialog();
            }
            catch { }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                try
                {
                    Form activeChild = this.ActiveMdiChild;
                    frmNNgu frm = new frmNNgu(activeChild.Name);
                    if (frm.ShowDialog() != DialogResult.OK) return;
                }
                catch { }
            }
        }
        private void barInfo_ItemDoubleClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Form activeChild = this.ActiveMdiChild;
                XtraInputBox.Show("Tên form", "Tên form", activeChild.Name);
            }
            catch
            {
            }
        }
    }
}