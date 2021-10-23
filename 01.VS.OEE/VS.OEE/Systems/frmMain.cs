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

            string sSql = "	SELECT DISTINCT T1.ID_MENU, KEY_MENU,CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN T1.TEN_MENU WHEN 1 THEN ISNULL(NULLIF(T1.TEN_MENU_A,''),TEN_MENU) ELSE ISNULL(NULLIF(T1.TEN_MENU_H,''),T1.TEN_MENU) END AS TEN_MENU,T1.MENU_PARENT, HIDE, BACK_COLOR, IMG, STT_MENU, CONTROLS,ISNULL(MENU_LINE,0) AS MENU_LINE, T1.MENU_PARAMETER,T1.HOT_KEY FROM dbo.MENU_OEE T1 	INNER JOIN dbo.NHOM_MENU_OEE T2 ON T1.ID_MENU = T2.ID_MENU INNER JOIN dbo.USERS T3 ON T3.GROUP_ID = T2.ID_NHOM 	WHERE (ISNULL(MENU_PARENT,'') = '0' ) AND (ISNULL(HIDE,0) = 0) AND INACTIVE = 0	AND (T3.USERNAME = '" + Commons.Modules.UserName + "') 	ORDER BY STT_MENU ";


            sSql = "	SELECT DISTINCT T1.MENU_ID AS ID_MENU,T1.MENU_ID AS KEY_MENU, CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN T1.MENU_TEXT WHEN 1 THEN ISNULL(NULLIF(T1.MENU_ENGLISH,''),T1.MENU_TEXT) ELSE ISNULL(NULLIF(T1.MENU_CHINESE,''),T1.MENU_TEXT) END AS TEN_MENU,MENU_INDEX FROM dbo.MENU T1 INNER JOIN dbo.NHOM_MENU T2 ON T2.MENU_ID = T1.MENU_ID INNER JOIN dbo.USERS T3 ON T3.GROUP_ID = T2.GROUP_ID WHERE(ISNULL(T1.MENU_PARENT, '') = '') AND(T3.USERNAME = '" + Commons.Modules.UserName + "') AND(ISNULL(T1.AN_HIEN, 0) = 1) AND(ISNULL(T1.LOAI_MENU, 0) = 3) ORDER BY MENU_INDEX  ";


            dtRoot.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));


            foreach (DataRow item in dtRoot.Rows)
            {
                bm.BeginUpdate();
                BarSubItem bsRoot = new BarSubItem(bm, item["TEN_MENU"].ToString());
                bsRoot.Name = item["KEY_MENU"].ToString();
                ////bsRoot.Tag = item["CONTROLS"].ToString();
                ////bsRoot.Id = int.Parse(item["ID_MENU"].ToString());
                ////bsRoot.Description = item["MENU_PARAMETER"].ToString();
                bm.MainMenu.AddItem(bsRoot);
                AddBarChild(bsRoot);
                bm.EndUpdate();

            }




            //#region Status Bar
            //BarStaticItem bsiLinePos = new BarStaticItem()
            //{
            //    Caption = "Line: 0 Position: 0",
            //    Alignment = BarItemLinkAlignment.Left,
            //    Width = 150,
            //    AutoSize = BarStaticItemSize.None,
            //    TextAlignment = System.Drawing.StringAlignment.Center
            //};
            //BarStaticItem bsiReady = new BarStaticItem()
            //{
            //    Caption = "Ready",
            //    Alignment = BarItemLinkAlignment.Right,
            //    Width = 80,
            //    AutoSize = BarStaticItemSize.None,
            //    TextAlignment = System.Drawing.StringAlignment.Far,
            //    Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            //};
            //BarEditItem beiZoom = new BarEditItem(bm, new RepositoryItemZoomTrackBar())
            //{
            //    EditWidth = 150,
            //    Alignment = BarItemLinkAlignment.Right
            //};
            //beiZoom.Edit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            //bm.StatusBar.AddItems(new BarItem[] { bsiLinePos, beiZoom, bsiReady });
            //#endregion
        }


        private void AddBarChild(BarSubItem bsiRoot)
        {

            DataTable dtChild = new DataTable();
            //string sSql = "	SELECT T1.ID_MENU, KEY_MENU,CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN T1.TEN_MENU WHEN 1 THEN ISNULL(NULLIF(T1.TEN_MENU_A,''),TEN_MENU) ELSE ISNULL(NULLIF(T1.TEN_MENU_H,''),T1.TEN_MENU) END AS TEN_MENU,T1.MENU_PARENT, HIDE, BACK_COLOR, IMG, STT_MENU, CONTROLS,ISNULL(MENU_LINE,0) AS MENU_LINE, T1.MENU_PARAMETER,T1.HOT_KEY FROM dbo.MENU_OEE T1 	INNER JOIN dbo.NHOM_MENU_OEE T2 ON T1.ID_MENU = T2.ID_MENU INNER JOIN dbo.USERS T3 ON T3.GROUP_ID = T2.ID_NHOM 	WHERE (ISNULL(MENU_PARENT,'') = N'" + bsiRoot.Name + "' ) AND (ISNULL(HIDE,0) = 0) AND INACTIVE = 0	AND (T3.USERNAME = '" + Commons.Modules.UserName + "') 	ORDER BY STT_MENU ";

            string sSql = "	SELECT T1.ID_MENU, KEY_MENU,CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN T1.TEN_MENU WHEN 1 THEN ISNULL(NULLIF(T1.TEN_MENU_A,''),TEN_MENU) ELSE ISNULL(NULLIF(T1.TEN_MENU_H,''),T1.TEN_MENU) END AS TEN_MENU,T1.MENU_PARENT, HIDE, BACK_COLOR, IMG, STT_MENU, CONTROLS,ISNULL(MENU_LINE,0) AS MENU_LINE, T1.MENU_PARAMETER,T1.HOT_KEY FROM dbo.MENU_OEE T1	WHERE (ISNULL(MENU_PARENT,'') = N'" + bsiRoot.Name + "' ) 	ORDER BY STT_MENU ";


            sSql = "	SELECT DISTINCT T1.MENU_ID AS ID_MENU,T1.MENU_ID AS KEY_MENU, CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN T1.MENU_TEXT WHEN 1 THEN ISNULL(NULLIF(T1.MENU_ENGLISH,''),T1.MENU_TEXT) ELSE ISNULL(NULLIF(T1.MENU_CHINESE,''),T1.MENU_TEXT) END AS TEN_MENU,T1.MENU_PARENT,T1.AN_HIEN,T1.MENU_INDEX AS STT_MENU, T1.CLASS_NAME AS CONTROLS, CONVERT(INT,ISNULL(T1.MENU_LINE, 0)) AS MENU_LINE, T1.FUNCTION_NAME AS MENU_PARAMETER,T1.SHORT_KEY AS HOT_KEY FROM dbo.MENU T1 INNER JOIN dbo.NHOM_MENU T2 ON T2.MENU_ID = T1.MENU_ID INNER JOIN dbo.USERS T3 ON T3.GROUP_ID = T2.GROUP_ID WHERE(ISNULL(T1.MENU_PARENT, '') = N'" + bsiRoot.Name + "' ) AND(T3.USERNAME = '" + Commons.Modules.UserName + "') AND(ISNULL(T1.AN_HIEN, 0) = 1) AND (ISNULL(T1.LOAI_MENU, 0) = 3)  ORDER BY STT_MENU";


            dtChild.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
            foreach (DataRow item in dtChild.Rows)
            {
                DataTable dt = new DataTable();
                //sSql = "	SELECT T1.ID_MENU, KEY_MENU,CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN T1.TEN_MENU WHEN 1 THEN ISNULL(NULLIF(T1.TEN_MENU_A,''),TEN_MENU) ELSE ISNULL(NULLIF(T1.TEN_MENU_H,''),T1.TEN_MENU) END AS TEN_MENU,T1.MENU_PARENT, HIDE, BACK_COLOR, IMG, STT_MENU, CONTROLS,ISNULL(MENU_LINE,0) AS MENU_LINE, T1.MENU_PARAMETER,T1.HOT_KEY FROM dbo.MENU_OEE T1 	INNER JOIN dbo.NHOM_MENU_OEE T2 ON T1.ID_MENU = T2.ID_MENU INNER JOIN dbo.USERS T3 ON T3.GROUP_ID = T2.ID_NHOM 	WHERE (ISNULL(MENU_PARENT,'') = N'" + item["KEY_MENU"].ToString() + "' ) AND (ISNULL(HIDE,0) = 0) AND INACTIVE = 0	AND (T3.USERNAME = '" + Commons.Modules.UserName + "') 	ORDER BY STT_MENU ";

                sSql = "	SELECT T1.ID_MENU, KEY_MENU,CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN T1.TEN_MENU WHEN 1 THEN ISNULL(NULLIF(T1.TEN_MENU_A,''),TEN_MENU) ELSE ISNULL(NULLIF(T1.TEN_MENU_H,''),T1.TEN_MENU) END AS TEN_MENU,T1.MENU_PARENT, HIDE, BACK_COLOR, IMG, STT_MENU, CONTROLS,ISNULL(MENU_LINE,0) AS MENU_LINE, T1.MENU_PARAMETER,T1.HOT_KEY FROM dbo.MENU_OEE T1 		WHERE (ISNULL(MENU_PARENT,'') = N'" + item["KEY_MENU"].ToString() + "' ) AND (ISNULL(HIDE,0) = 0) AND INACTIVE = 0	ORDER BY STT_MENU ";


                sSql = "	SELECT DISTINCT T1.MENU_ID AS ID_MENU, T1.MENU_ID AS KEY_MENU, CASE " + Commons.Modules.TypeLanguage.ToString() + " WHEN 0 THEN T1.MENU_TEXT WHEN 1 THEN ISNULL(NULLIF(T1.MENU_ENGLISH,''),T1.MENU_TEXT) ELSE ISNULL(NULLIF(T1.MENU_CHINESE,''),T1.MENU_TEXT) END AS TEN_MENU,T1.MENU_PARENT,T1.AN_HIEN,T1.MENU_INDEX AS STT_MENU, T1.CLASS_NAME AS CONTROLS,CONVERT(INT,ISNULL(T1.MENU_LINE, 0)) AS MENU_LINE, T1.FUNCTION_NAME AS MENU_PARAMETER,T1.SHORT_KEY AS HOT_KEY FROM dbo.MENU T1 INNER JOIN dbo.NHOM_MENU T2 ON T2.MENU_ID = T1.MENU_ID INNER JOIN dbo.USERS T3 ON T3.GROUP_ID = T2.GROUP_ID WHERE(ISNULL(T1.MENU_PARENT, '') = N'" + item["KEY_MENU"].ToString() + "' ) AND(T3.USERNAME = '" + Commons.Modules.UserName + "') AND(ISNULL(T1.AN_HIEN, 0) = 1) AND (ISNULL(T1.LOAI_MENU, 0) = 3)  ORDER BY STT_MENU";

                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                if (dt.Rows.Count == 0)
                {
                    //if (item["KEY_MENU"].ToString().ToUpper() == "mnuOEENNViet".ToUpper() || item["KEY_MENU"].ToString().ToUpper() == "mnuOEENNAnh".ToUpper() || item["KEY_MENU"].ToString().ToUpper() == "mnuOEENNHoa".ToUpper()) 
                    if (item["CONTROLS"].ToString().ToUpper() == "ShowNNgu".ToUpper() )
                    {
                        bool bCheck = false;
                        if (Commons.Modules.TypeLanguage == 0 && item["KEY_MENU"].ToString().ToUpper() == "mnuOEENNViet".ToUpper()) bCheck = true;
                        if (Commons.Modules.TypeLanguage == 1 && item["KEY_MENU"].ToString().ToUpper() == "mnuOEENNAnh".ToUpper()) bCheck = true;
                        if (Commons.Modules.TypeLanguage == 2 && item["KEY_MENU"].ToString().ToUpper() == "mnuOEENNHoa".ToUpper()) bCheck = true;

                        BarCheckItem bbiChild = new BarCheckItem(bm, bCheck);
                        bbiChild.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                        bbiChild.Name = item["KEY_MENU"].ToString();
                        bbiChild.Tag = item["CONTROLS"].ToString();
                        //bbiChild.Id = int.Parse(item["ID_MENU"].ToString());
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
                        //bbiChild.Id = int.Parse(item["ID_MENU"].ToString());
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
                    //bsRoot1.Id = int.Parse(item["ID_MENU"].ToString());
                    bsRoot1.Description = item["MENU_PARAMETER"].ToString() + "DASDA";
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
            List<Form> ListForm = new List<Form>();
            foreach (Form frmO in frmOpen)
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
                case "ShowThoiGianNgungMay": { ShowThoiGianNgungMay(); return; }
                case "ShowThoiGianChayMay": { ShowThoiGianChayMay(); return; }
                case "ShowNhanVien": { ShowNhanVien(); return; }
                case "ShowThoiGiamLamViec": { ShowThoiGiamLamViec(); return; }
                case "ShowCaLamViec": { ShowCaLamViec(); return; }
                case "ShowBaoCao": { ShowBaoCao(); return; }
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
                Form fc = Application.OpenForms[e.Item.Name.Replace("mnu", "frm")];
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

            //if (System.Windows.Forms.Application.MessageLoop)
            //{
            //    System.Windows.Forms.this.Close();
            //}
            //else
            //{
            //    System.Environment.Exit(1);
            //}
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
        private void ShowNgonNgu(  BarCheckItem  barItem, string NNgu)
        {
            try
            {
                FormCollection formCollection = Application.OpenForms;
                List<Form> ListFormToClose = new List<Form>();
                foreach (Form form in formCollection)
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
            List<Form> ListFormToClose = new List<Form>();
            foreach (Form form in formCollection)
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
            frmNhaXuong frm = new frmNhaXuong(Commons.Modules.ObjSystems.MGetPhanQuyen("frmBranch"));
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region frmDanhMucHeThong
        private void ShowDayChuyen()
        {
            this.Cursor = Cursors.WaitCursor;
            frmDanhMucHeThong frm = new frmDanhMucHeThong(Commons.Modules.ObjSystems.MGetPhanQuyen("frmDanhmuchethong"));
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
            frmThongTinThietBi frm = new frmThongTinThietBi(Commons.Modules.ObjSystems.MGetPhanQuyen("frmThongtinthietbi"));
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
            frmTarget frm = new frmTarget();
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
            frmItemGroup frm = new frmItemGroup();
            //frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowMatHang
        private void ShowMatHang()
        {
            this.Cursor = Cursors.WaitCursor;
            frmItemMay frm = new frmItemMay();
            //frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowLenhSanXuat
        private void ShowLenhSanXuat()
        {
            this.Cursor = Cursors.WaitCursor;
            frmProductOrder frm = new frmProductOrder();
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
            frmNhapHangLoi frm = new frmNhapHangLoi(1);
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
            frmProductRun frm = new frmProductRun();
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowThoiGianNgungMay
        private void ShowThoiGianNgungMay()
        {
            this.Cursor = Cursors.WaitCursor;
            frmThongTinThietBi frm = new frmThongTinThietBi(1);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowThoiGianChayMay
        private void ShowThoiGianChayMay()
        {
            this.Cursor = Cursors.WaitCursor;
            frmThongTinThietBi frm = new frmThongTinThietBi(1);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowNhanVien
        private void ShowNhanVien()
        {
            this.Cursor = Cursors.WaitCursor;
            frmNhanVien frm = new frmNhanVien(Commons.Modules.ObjSystems.MGetPhanQuyen("frmQuanlynhanvien"));
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowThoiGiamLamViec
        private void ShowThoiGiamLamViec()
        {
            this.Cursor = Cursors.WaitCursor;
            frmThongTinThietBi frm = new frmThongTinThietBi(1);
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region ShowCaLamViec
        private void ShowCaLamViec()
        {
            this.Cursor = Cursors.WaitCursor;
            frmThongTinThietBi frm = new frmThongTinThietBi(1);
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

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                try
                {
                    FormCollection formCollection = Application.OpenForms;
                    string sform = @"N@@frmChung@@ ";
                    foreach (Form form in formCollection)
                    {
                        //if (form.Name != "frmMain")
                        //{
                            sform = sform + @", N@@" +  form.Name.ToString() + "@@ ";
                        //}
                    }



                    frmNNgu frm = new frmNNgu(sform);
                    if (frm.ShowDialog() != DialogResult.OK) return;

                }
                catch { }
            }
        }
    }
}