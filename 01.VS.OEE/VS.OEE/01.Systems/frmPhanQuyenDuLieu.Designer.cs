
using DevExpress.XtraEditors;

namespace VS.OEE
{
    partial class frmPhanQuyenDuLieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.lblNhom = new DevExpress.XtraEditors.LabelControl();
            this.tabPhanQuyen = new DevExpress.XtraTab.XtraTabControl();
            this.tabDiaDiemDayChuyen = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpQuyenTrenKhuVuc = new DevExpress.XtraEditors.GroupControl();
            this.grdDiaDiem = new DevExpress.XtraGrid.GridControl();
            this.grvDiaDiem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.grpQuyenTrenDayTruyen = new DevExpress.XtraEditors.GroupControl();
            this.grdDayChuyen = new DevExpress.XtraGrid.GridControl();
            this.grvDayChuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.searchControl2 = new DevExpress.XtraEditors.SearchControl();
            this.tabLoaiMayBPCP = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpQuyenTrenLoaiMay = new DevExpress.XtraEditors.GroupControl();
            this.grdLoaiMay = new DevExpress.XtraGrid.GridControl();
            this.grvLoaiMay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.searchControl3 = new DevExpress.XtraEditors.SearchControl();
            this.grpBoPhanChiuPhi = new DevExpress.XtraEditors.GroupControl();
            this.grdBPCP = new DevExpress.XtraGrid.GridControl();
            this.grvBPCP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.searchControl4 = new DevExpress.XtraEditors.SearchControl();
            this.cboNhom = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPhanQuyen)).BeginInit();
            this.tabPhanQuyen.SuspendLayout();
            this.tabDiaDiemDayChuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpQuyenTrenKhuVuc)).BeginInit();
            this.grpQuyenTrenKhuVuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDiaDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDiaDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpQuyenTrenDayTruyen)).BeginInit();
            this.grpQuyenTrenDayTruyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayChuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDayChuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl2.Properties)).BeginInit();
            this.tabLoaiMayBPCP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpQuyenTrenLoaiMay)).BeginInit();
            this.grpQuyenTrenLoaiMay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLoaiMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBoPhanChiuPhi)).BeginInit();
            this.grpBoPhanChiuPhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBPCP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBPCP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl4.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel1.Controls.Add(this.lblNhom);
            this.tablePanel1.Controls.Add(this.tabPhanQuyen);
            this.tablePanel1.Controls.Add(this.cboNhom);
            this.tablePanel1.Controls.Add(this.panel1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.tablePanel1.Size = new System.Drawing.Size(1048, 491);
            this.tablePanel1.TabIndex = 7;
            // 
            // lblNhom
            // 
            this.tablePanel1.SetColumn(this.lblNhom, 1);
            this.lblNhom.Location = new System.Drawing.Point(312, 14);
            this.lblNhom.Name = "lblNhom";
            this.tablePanel1.SetRow(this.lblNhom, 1);
            this.lblNhom.Size = new System.Drawing.Size(44, 13);
            this.lblNhom.TabIndex = 8;
            this.lblNhom.Text = "lblNhom";
            // 
            // tabPhanQuyen
            // 
            this.tablePanel1.SetColumn(this.tabPhanQuyen, 0);
            this.tablePanel1.SetColumnSpan(this.tabPhanQuyen, 4);
            this.tabPhanQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPhanQuyen.Location = new System.Drawing.Point(3, 45);
            this.tabPhanQuyen.Name = "tabPhanQuyen";
            this.tablePanel1.SetRow(this.tabPhanQuyen, 3);
            this.tabPhanQuyen.SelectedTabPage = this.tabDiaDiemDayChuyen;
            this.tabPhanQuyen.Size = new System.Drawing.Size(1042, 408);
            this.tabPhanQuyen.TabIndex = 7;
            this.tabPhanQuyen.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDiaDiemDayChuyen,
            this.tabLoaiMayBPCP});
            this.tabPhanQuyen.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabPhanQuyen_SelectedPageChanged);
            this.tabPhanQuyen.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.tabPhanQuyen_SelectedPageChanging);
            // 
            // tabDiaDiemDayChuyen
            // 
            this.tabDiaDiemDayChuyen.Controls.Add(this.splitContainerControl1);
            this.tabDiaDiemDayChuyen.Name = "tabDiaDiemDayChuyen";
            this.tabDiaDiemDayChuyen.Size = new System.Drawing.Size(1037, 382);
            this.tabDiaDiemDayChuyen.Text = "tabDiaDiemDayChuyen";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grpQuyenTrenKhuVuc);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grpQuyenTrenDayTruyen);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1037, 382);
            this.splitContainerControl1.SplitterPosition = 509;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // grpQuyenTrenKhuVuc
            // 
            this.grpQuyenTrenKhuVuc.Controls.Add(this.grdDiaDiem);
            this.grpQuyenTrenKhuVuc.Controls.Add(this.searchControl1);
            this.grpQuyenTrenKhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQuyenTrenKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.grpQuyenTrenKhuVuc.Name = "grpQuyenTrenKhuVuc";
            this.grpQuyenTrenKhuVuc.Size = new System.Drawing.Size(509, 382);
            this.grpQuyenTrenKhuVuc.TabIndex = 0;
            this.grpQuyenTrenKhuVuc.Text = "grpQuyenTrenKhuVuc";
            // 
            // grdDiaDiem
            // 
            this.grdDiaDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDiaDiem.Location = new System.Drawing.Point(2, 42);
            this.grdDiaDiem.MainView = this.grvDiaDiem;
            this.grdDiaDiem.Name = "grdDiaDiem";
            this.grdDiaDiem.Size = new System.Drawing.Size(505, 338);
            this.grdDiaDiem.TabIndex = 2;
            this.grdDiaDiem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDiaDiem});
            // 
            // grvDiaDiem
            // 
            this.grvDiaDiem.GridControl = this.grdDiaDiem;
            this.grvDiaDiem.Name = "grvDiaDiem";
            this.grvDiaDiem.OptionsSelection.MultiSelect = true;
            this.grvDiaDiem.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvDiaDiem.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDiaDiem.OptionsView.ShowGroupPanel = false;
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.grdDiaDiem;
            this.searchControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControl1.Location = new System.Drawing.Point(2, 22);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.grdDiaDiem;
            this.searchControl1.Properties.FindDelay = 100;
            this.searchControl1.Size = new System.Drawing.Size(505, 20);
            this.searchControl1.TabIndex = 0;
            // 
            // grpQuyenTrenDayTruyen
            // 
            this.grpQuyenTrenDayTruyen.Controls.Add(this.grdDayChuyen);
            this.grpQuyenTrenDayTruyen.Controls.Add(this.searchControl2);
            this.grpQuyenTrenDayTruyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQuyenTrenDayTruyen.Location = new System.Drawing.Point(0, 0);
            this.grpQuyenTrenDayTruyen.Name = "grpQuyenTrenDayTruyen";
            this.grpQuyenTrenDayTruyen.Size = new System.Drawing.Size(522, 382);
            this.grpQuyenTrenDayTruyen.TabIndex = 0;
            this.grpQuyenTrenDayTruyen.Text = "grpQuyenTrenDayTruyen";
            // 
            // grdDayChuyen
            // 
            this.grdDayChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDayChuyen.Location = new System.Drawing.Point(2, 42);
            this.grdDayChuyen.MainView = this.grvDayChuyen;
            this.grdDayChuyen.Name = "grdDayChuyen";
            this.grdDayChuyen.Size = new System.Drawing.Size(518, 338);
            this.grdDayChuyen.TabIndex = 2;
            this.grdDayChuyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDayChuyen});
            // 
            // grvDayChuyen
            // 
            this.grvDayChuyen.GridControl = this.grdDayChuyen;
            this.grvDayChuyen.Name = "grvDayChuyen";
            this.grvDayChuyen.OptionsSelection.MultiSelect = true;
            this.grvDayChuyen.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvDayChuyen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDayChuyen.OptionsView.ShowGroupPanel = false;
            // 
            // searchControl2
            // 
            this.searchControl2.Client = this.grdDayChuyen;
            this.searchControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControl2.Location = new System.Drawing.Point(2, 22);
            this.searchControl2.Name = "searchControl2";
            this.searchControl2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl2.Properties.Client = this.grdDayChuyen;
            this.searchControl2.Properties.FindDelay = 100;
            this.searchControl2.Size = new System.Drawing.Size(518, 20);
            this.searchControl2.TabIndex = 1;
            // 
            // tabLoaiMayBPCP
            // 
            this.tabLoaiMayBPCP.Controls.Add(this.splitContainerControl2);
            this.tabLoaiMayBPCP.Name = "tabLoaiMayBPCP";
            this.tabLoaiMayBPCP.Size = new System.Drawing.Size(973, 273);
            this.tabLoaiMayBPCP.Text = "tabLoaiMayBPCP";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.grpQuyenTrenLoaiMay);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.grpBoPhanChiuPhi);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(973, 273);
            this.splitContainerControl2.SplitterPosition = 400;
            this.splitContainerControl2.TabIndex = 2;
            // 
            // grpQuyenTrenLoaiMay
            // 
            this.grpQuyenTrenLoaiMay.Controls.Add(this.grdLoaiMay);
            this.grpQuyenTrenLoaiMay.Controls.Add(this.searchControl3);
            this.grpQuyenTrenLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQuyenTrenLoaiMay.Location = new System.Drawing.Point(0, 0);
            this.grpQuyenTrenLoaiMay.Name = "grpQuyenTrenLoaiMay";
            this.grpQuyenTrenLoaiMay.Size = new System.Drawing.Size(400, 273);
            this.grpQuyenTrenLoaiMay.TabIndex = 0;
            this.grpQuyenTrenLoaiMay.Text = "grpQuyenTrenLoaiMay";
            // 
            // grdLoaiMay
            // 
            this.grdLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLoaiMay.Location = new System.Drawing.Point(2, 42);
            this.grdLoaiMay.MainView = this.grvLoaiMay;
            this.grdLoaiMay.Name = "grdLoaiMay";
            this.grdLoaiMay.Size = new System.Drawing.Size(396, 229);
            this.grdLoaiMay.TabIndex = 2;
            this.grdLoaiMay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLoaiMay});
            // 
            // grvLoaiMay
            // 
            this.grvLoaiMay.GridControl = this.grdLoaiMay;
            this.grvLoaiMay.Name = "grvLoaiMay";
            this.grvLoaiMay.OptionsSelection.MultiSelect = true;
            this.grvLoaiMay.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvLoaiMay.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvLoaiMay.OptionsView.ShowGroupPanel = false;
            // 
            // searchControl3
            // 
            this.searchControl3.Client = this.grdLoaiMay;
            this.searchControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControl3.Location = new System.Drawing.Point(2, 22);
            this.searchControl3.Name = "searchControl3";
            this.searchControl3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl3.Properties.Client = this.grdLoaiMay;
            this.searchControl3.Properties.FindDelay = 100;
            this.searchControl3.Size = new System.Drawing.Size(396, 20);
            this.searchControl3.TabIndex = 0;
            // 
            // grpBoPhanChiuPhi
            // 
            this.grpBoPhanChiuPhi.Controls.Add(this.grdBPCP);
            this.grpBoPhanChiuPhi.Controls.Add(this.searchControl4);
            this.grpBoPhanChiuPhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoPhanChiuPhi.Location = new System.Drawing.Point(0, 0);
            this.grpBoPhanChiuPhi.Name = "grpBoPhanChiuPhi";
            this.grpBoPhanChiuPhi.Size = new System.Drawing.Size(567, 273);
            this.grpBoPhanChiuPhi.TabIndex = 0;
            this.grpBoPhanChiuPhi.Text = "grpBoPhanChiuPhi";
            // 
            // grdBPCP
            // 
            this.grdBPCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBPCP.Location = new System.Drawing.Point(2, 42);
            this.grdBPCP.MainView = this.grvBPCP;
            this.grdBPCP.Name = "grdBPCP";
            this.grdBPCP.Size = new System.Drawing.Size(563, 229);
            this.grdBPCP.TabIndex = 2;
            this.grdBPCP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBPCP});
            // 
            // grvBPCP
            // 
            this.grvBPCP.GridControl = this.grdBPCP;
            this.grvBPCP.Name = "grvBPCP";
            this.grvBPCP.OptionsSelection.MultiSelect = true;
            this.grvBPCP.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvBPCP.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBPCP.OptionsView.ShowGroupPanel = false;
            // 
            // searchControl4
            // 
            this.searchControl4.Client = this.grdBPCP;
            this.searchControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControl4.Location = new System.Drawing.Point(2, 22);
            this.searchControl4.Name = "searchControl4";
            this.searchControl4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl4.Properties.Client = this.grdBPCP;
            this.searchControl4.Properties.FindDelay = 100;
            this.searchControl4.Size = new System.Drawing.Size(563, 20);
            this.searchControl4.TabIndex = 1;
            // 
            // cboNhom
            // 
            this.tablePanel1.SetColumn(this.cboNhom, 2);
            this.cboNhom.FormattingEnabled = true;
            this.cboNhom.Location = new System.Drawing.Point(431, 10);
            this.cboNhom.Margin = new System.Windows.Forms.Padding(2);
            this.cboNhom.Name = "cboNhom";
            this.tablePanel1.SetRow(this.cboNhom, 1);
            this.cboNhom.Size = new System.Drawing.Size(305, 21);
            this.cboNhom.TabIndex = 6;
            this.cboNhom.SelectedValueChanged += new System.EventHandler(this.cboNhom_SelectedValueChanged);
            // 
            // panel1
            // 
            this.tablePanel1.SetColumn(this.panel1, 0);
            this.tablePanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnKhong);
            this.panel1.Controls.Add(this.btnGhi);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Location = new System.Drawing.Point(2, 458);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.tablePanel1.SetRow(this.panel1, 4);
            this.panel1.Size = new System.Drawing.Size(1044, 31);
            this.panel1.TabIndex = 4;
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(882, 3);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 26);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Location = new System.Drawing.Point(963, 3);
            this.btnKhong.Margin = new System.Windows.Forms.Padding(2);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnKhong.Size = new System.Drawing.Size(80, 26);
            this.btnKhong.TabIndex = 7;
            this.btnKhong.Text = "btnKhong";
            this.btnKhong.Visible = false;
            this.btnKhong.Click += new System.EventHandler(this.btnKhongGhi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(882, 3);
            this.btnGhi.Margin = new System.Windows.Forms.Padding(2);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 8;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Visible = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(963, 3);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // gridView4
            // 
            this.gridView4.Name = "gridView4";
            // 
            // frmPhanQuyenDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 491);
            this.Controls.Add(this.tablePanel1);
            this.Name = "frmPhanQuyenDuLieu";
            this.Text = "frmPhanQuyenDuLieu";
            this.Load += new System.EventHandler(this.frmPhanQuyenDuLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPhanQuyen)).EndInit();
            this.tabPhanQuyen.ResumeLayout(false);
            this.tabDiaDiemDayChuyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpQuyenTrenKhuVuc)).EndInit();
            this.grpQuyenTrenKhuVuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDiaDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDiaDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpQuyenTrenDayTruyen)).EndInit();
            this.grpQuyenTrenDayTruyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDayChuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDayChuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl2.Properties)).EndInit();
            this.tabLoaiMayBPCP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpQuyenTrenLoaiMay)).EndInit();
            this.grpQuyenTrenLoaiMay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLoaiMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLoaiMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBoPhanChiuPhi)).EndInit();
            this.grpBoPhanChiuPhi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBPCP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBPCP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl4.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private System.Windows.Forms.ComboBox cboNhom;
        private System.Windows.Forms.Panel panel1;
        private SimpleButton btnSua;
        private SimpleButton btnThoat;
        private SimpleButton btnGhi;
        private SimpleButton btnKhong;
        private DevExpress.XtraTab.XtraTabControl tabPhanQuyen;
        private DevExpress.XtraTab.XtraTabPage tabDiaDiemDayChuyen;
        private DevExpress.XtraTab.XtraTabPage tabLoaiMayBPCP;
        private SplitContainerControl splitContainerControl1;
        private GroupControl grpQuyenTrenKhuVuc;
        private DevExpress.XtraGrid.GridControl grdDiaDiem;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDiaDiem;
        private SearchControl searchControl1;
        private GroupControl grpQuyenTrenDayTruyen;
        private DevExpress.XtraGrid.GridControl grdDayChuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDayChuyen;
        private SearchControl searchControl2;
        private SplitContainerControl splitContainerControl2;
        private GroupControl grpQuyenTrenLoaiMay;
        private DevExpress.XtraGrid.GridControl grdLoaiMay;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLoaiMay;
        private SearchControl searchControl3;
        private GroupControl grpBoPhanChiuPhi;
        private DevExpress.XtraGrid.GridControl grdBPCP;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBPCP;
        private SearchControl searchControl4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private LabelControl lblNhom;
    }
}