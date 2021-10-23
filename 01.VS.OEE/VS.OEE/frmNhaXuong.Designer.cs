namespace VS.OEE
{
    partial class frmNhaXuong
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.TreeList = new DevExpress.XtraTreeList.TreeList();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.pieHINH_ANH = new DevExpress.XtraEditors.PictureEdit();
            this.txtGHI_CHU = new DevExpress.XtraEditors.MemoEdit();
            this.txtKHOANG_CACH = new DevExpress.XtraEditors.SpinEdit();
            this.txtDIEN_TICH = new DevExpress.XtraEditors.SpinEdit();
            this.cboMS_DON_VI = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDIEN_THOAI = new DevExpress.XtraEditors.TextEdit();
            this.txtTRU_SO = new DevExpress.XtraEditors.TextEdit();
            this.txtNGUOI_DAI_DIEN = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_N_XUONG_H = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_N_XUONG_A = new DevExpress.XtraEditors.TextEdit();
            this.txtTen_N_XUONG = new DevExpress.XtraEditors.TextEdit();
            this.txtMS_N_XUONG = new DevExpress.XtraEditors.TextEdit();
            this.lblHINH_ANH = new DevExpress.XtraEditors.LabelControl();
            this.lblGHI_CHU = new DevExpress.XtraEditors.LabelControl();
            this.lblKHOANG_CACH = new DevExpress.XtraEditors.LabelControl();
            this.lblDIEN_TICH = new DevExpress.XtraEditors.LabelControl();
            this.lblDIEN_THOAI = new DevExpress.XtraEditors.LabelControl();
            this.lblNGUOI_DAI_DIEN = new DevExpress.XtraEditors.LabelControl();
            this.lblTRU_SO = new DevExpress.XtraEditors.LabelControl();
            this.lblMS_DON_VI = new DevExpress.XtraEditors.LabelControl();
            this.lblTen_N_XUONG = new DevExpress.XtraEditors.LabelControl();
            this.lblMS_N_XUONG = new DevExpress.XtraEditors.LabelControl();
            this.lblTEN_N_XUONG_H = new DevExpress.XtraEditors.LabelControl();
            this.lblTEN_N_XUONG_A = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.txtTim = new DevExpress.XtraEditors.SearchControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pieHINH_ANH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGHI_CHU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKHOANG_CACH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIEN_TICH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMS_DON_VI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIEN_THOAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTRU_SO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNGUOI_DAI_DIEN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_N_XUONG_H.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_N_XUONG_A.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_N_XUONG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMS_N_XUONG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeList
            // 
            this.tablePanel2.SetColumn(this.TreeList, 0);
            this.TreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeList.Location = new System.Drawing.Point(8, 8);
            this.TreeList.MinWidth = 17;
            this.TreeList.Name = "TreeList";
            this.tablePanel2.SetRow(this.TreeList, 0);
            this.TreeList.Size = new System.Drawing.Size(300, 520);
            this.TreeList.TabIndex = 0;
            this.TreeList.TreeLevelWidth = 15;
            this.TreeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreeList_FocusedNodeChanged);
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F)});
            this.tablePanel1.Controls.Add(this.flowLayoutPanel1);
            this.tablePanel1.Controls.Add(this.pieHINH_ANH);
            this.tablePanel1.Controls.Add(this.txtGHI_CHU);
            this.tablePanel1.Controls.Add(this.txtKHOANG_CACH);
            this.tablePanel1.Controls.Add(this.txtDIEN_TICH);
            this.tablePanel1.Controls.Add(this.cboMS_DON_VI);
            this.tablePanel1.Controls.Add(this.txtDIEN_THOAI);
            this.tablePanel1.Controls.Add(this.txtTRU_SO);
            this.tablePanel1.Controls.Add(this.txtNGUOI_DAI_DIEN);
            this.tablePanel1.Controls.Add(this.txtTEN_N_XUONG_H);
            this.tablePanel1.Controls.Add(this.txtTEN_N_XUONG_A);
            this.tablePanel1.Controls.Add(this.txtTen_N_XUONG);
            this.tablePanel1.Controls.Add(this.txtMS_N_XUONG);
            this.tablePanel1.Controls.Add(this.lblHINH_ANH);
            this.tablePanel1.Controls.Add(this.lblGHI_CHU);
            this.tablePanel1.Controls.Add(this.lblKHOANG_CACH);
            this.tablePanel1.Controls.Add(this.lblDIEN_TICH);
            this.tablePanel1.Controls.Add(this.lblDIEN_THOAI);
            this.tablePanel1.Controls.Add(this.lblNGUOI_DAI_DIEN);
            this.tablePanel1.Controls.Add(this.lblTRU_SO);
            this.tablePanel1.Controls.Add(this.lblMS_DON_VI);
            this.tablePanel1.Controls.Add(this.lblTen_N_XUONG);
            this.tablePanel1.Controls.Add(this.lblMS_N_XUONG);
            this.tablePanel1.Controls.Add(this.lblTEN_N_XUONG_H);
            this.tablePanel1.Controls.Add(this.lblTEN_N_XUONG_A);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 25F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 27F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 42F)});
            this.tablePanel1.Size = new System.Drawing.Size(572, 568);
            this.tablePanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.tablePanel1.SetColumn(this.flowLayoutPanel1, 0);
            this.tablePanel1.SetColumnSpan(this.flowLayoutPanel1, 4);
            this.flowLayoutPanel1.Controls.Add(this.btnThoat);
            this.flowLayoutPanel1.Controls.Add(this.btnKhongGhi);
            this.flowLayoutPanel1.Controls.Add(this.btnGhi);
            this.flowLayoutPanel1.Controls.Add(this.btnXoa);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 521);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tablePanel1.SetRow(this.flowLayoutPanel1, 9);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(562, 42);
            this.flowLayoutPanel1.TabIndex = 28;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(460, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(99, 30);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnKhongGhi
            // 
            this.btnKhongGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhongGhi.Location = new System.Drawing.Point(355, 3);
            this.btnKhongGhi.Name = "btnKhongGhi";
            this.btnKhongGhi.Size = new System.Drawing.Size(99, 30);
            this.btnKhongGhi.TabIndex = 1;
            this.btnKhongGhi.Text = "btnKhongGhi";
            this.btnKhongGhi.Click += new System.EventHandler(this.btnKhongGhi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(250, 3);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(99, 30);
            this.btnGhi.TabIndex = 2;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(145, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(99, 30);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // pieHINH_ANH
            // 
            this.tablePanel1.SetColumn(this.pieHINH_ANH, 3);
            this.pieHINH_ANH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieHINH_ANH.Location = new System.Drawing.Point(401, 156);
            this.pieHINH_ANH.Name = "pieHINH_ANH";
            this.pieHINH_ANH.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.tablePanel1.SetRow(this.pieHINH_ANH, 5);
            this.tablePanel1.SetRowSpan(this.pieHINH_ANH, 3);
            this.pieHINH_ANH.Size = new System.Drawing.Size(163, 90);
            this.pieHINH_ANH.TabIndex = 27;
            // 
            // txtGHI_CHU
            // 
            this.tablePanel1.SetColumn(this.txtGHI_CHU, 1);
            this.txtGHI_CHU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGHI_CHU.Location = new System.Drawing.Point(120, 156);
            this.txtGHI_CHU.Name = "txtGHI_CHU";
            this.tablePanel1.SetRow(this.txtGHI_CHU, 5);
            this.tablePanel1.SetRowSpan(this.txtGHI_CHU, 3);
            this.txtGHI_CHU.Size = new System.Drawing.Size(163, 90);
            this.txtGHI_CHU.TabIndex = 26;
            // 
            // txtKHOANG_CACH
            // 
            this.tablePanel1.SetColumn(this.txtKHOANG_CACH, 3);
            this.txtKHOANG_CACH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKHOANG_CACH.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtKHOANG_CACH.Location = new System.Drawing.Point(401, 124);
            this.txtKHOANG_CACH.Name = "txtKHOANG_CACH";
            this.txtKHOANG_CACH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.txtKHOANG_CACH, 4);
            this.txtKHOANG_CACH.Size = new System.Drawing.Size(163, 20);
            this.txtKHOANG_CACH.TabIndex = 25;
            // 
            // txtDIEN_TICH
            // 
            this.tablePanel1.SetColumn(this.txtDIEN_TICH, 1);
            this.txtDIEN_TICH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDIEN_TICH.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDIEN_TICH.Location = new System.Drawing.Point(120, 124);
            this.txtDIEN_TICH.Name = "txtDIEN_TICH";
            this.txtDIEN_TICH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.txtDIEN_TICH, 4);
            this.txtDIEN_TICH.Size = new System.Drawing.Size(163, 20);
            this.txtDIEN_TICH.TabIndex = 24;
            // 
            // cboMS_DON_VI
            // 
            this.tablePanel1.SetColumn(this.cboMS_DON_VI, 1);
            this.cboMS_DON_VI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMS_DON_VI.EditValue = "";
            this.cboMS_DON_VI.Location = new System.Drawing.Point(120, 60);
            this.cboMS_DON_VI.Name = "cboMS_DON_VI";
            this.cboMS_DON_VI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMS_DON_VI.Properties.NullText = "";
            this.cboMS_DON_VI.Properties.PopupView = this.searchLookUpEdit1View;
            this.tablePanel1.SetRow(this.cboMS_DON_VI, 2);
            this.cboMS_DON_VI.Size = new System.Drawing.Size(163, 20);
            this.cboMS_DON_VI.TabIndex = 23;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.DetailHeight = 304;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtDIEN_THOAI
            // 
            this.tablePanel1.SetColumn(this.txtDIEN_THOAI, 3);
            this.txtDIEN_THOAI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDIEN_THOAI.Location = new System.Drawing.Point(401, 92);
            this.txtDIEN_THOAI.Name = "txtDIEN_THOAI";
            this.tablePanel1.SetRow(this.txtDIEN_THOAI, 3);
            this.txtDIEN_THOAI.Size = new System.Drawing.Size(163, 20);
            this.txtDIEN_THOAI.TabIndex = 22;
            // 
            // txtTRU_SO
            // 
            this.tablePanel1.SetColumn(this.txtTRU_SO, 3);
            this.txtTRU_SO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTRU_SO.Location = new System.Drawing.Point(401, 60);
            this.txtTRU_SO.Name = "txtTRU_SO";
            this.tablePanel1.SetRow(this.txtTRU_SO, 2);
            this.txtTRU_SO.Size = new System.Drawing.Size(163, 20);
            this.txtTRU_SO.TabIndex = 21;
            // 
            // txtNGUOI_DAI_DIEN
            // 
            this.tablePanel1.SetColumn(this.txtNGUOI_DAI_DIEN, 1);
            this.txtNGUOI_DAI_DIEN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNGUOI_DAI_DIEN.Location = new System.Drawing.Point(120, 92);
            this.txtNGUOI_DAI_DIEN.Name = "txtNGUOI_DAI_DIEN";
            this.tablePanel1.SetRow(this.txtNGUOI_DAI_DIEN, 3);
            this.txtNGUOI_DAI_DIEN.Size = new System.Drawing.Size(163, 20);
            this.txtNGUOI_DAI_DIEN.TabIndex = 20;
            // 
            // txtTEN_N_XUONG_H
            // 
            this.tablePanel1.SetColumn(this.txtTEN_N_XUONG_H, 3);
            this.txtTEN_N_XUONG_H.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEN_N_XUONG_H.Location = new System.Drawing.Point(401, 33);
            this.txtTEN_N_XUONG_H.Name = "txtTEN_N_XUONG_H";
            this.tablePanel1.SetRow(this.txtTEN_N_XUONG_H, 1);
            this.txtTEN_N_XUONG_H.Size = new System.Drawing.Size(163, 20);
            this.txtTEN_N_XUONG_H.TabIndex = 18;
            // 
            // txtTEN_N_XUONG_A
            // 
            this.tablePanel1.SetColumn(this.txtTEN_N_XUONG_A, 1);
            this.txtTEN_N_XUONG_A.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEN_N_XUONG_A.Location = new System.Drawing.Point(120, 33);
            this.txtTEN_N_XUONG_A.Name = "txtTEN_N_XUONG_A";
            this.tablePanel1.SetRow(this.txtTEN_N_XUONG_A, 1);
            this.txtTEN_N_XUONG_A.Size = new System.Drawing.Size(163, 20);
            this.txtTEN_N_XUONG_A.TabIndex = 17;
            // 
            // txtTen_N_XUONG
            // 
            this.tablePanel1.SetColumn(this.txtTen_N_XUONG, 3);
            this.txtTen_N_XUONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen_N_XUONG.Location = new System.Drawing.Point(401, 8);
            this.txtTen_N_XUONG.Name = "txtTen_N_XUONG";
            this.tablePanel1.SetRow(this.txtTen_N_XUONG, 0);
            this.txtTen_N_XUONG.Size = new System.Drawing.Size(163, 20);
            this.txtTen_N_XUONG.TabIndex = 16;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtTen_N_XUONG, conditionValidationRule1);
            // 
            // txtMS_N_XUONG
            // 
            this.tablePanel1.SetColumn(this.txtMS_N_XUONG, 1);
            this.txtMS_N_XUONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMS_N_XUONG.Location = new System.Drawing.Point(120, 7);
            this.txtMS_N_XUONG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMS_N_XUONG.Name = "txtMS_N_XUONG";
            this.tablePanel1.SetRow(this.txtMS_N_XUONG, 0);
            this.txtMS_N_XUONG.Size = new System.Drawing.Size(163, 20);
            this.txtMS_N_XUONG.TabIndex = 15;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtMS_N_XUONG, conditionValidationRule2);
            // 
            // lblHINH_ANH
            // 
            this.tablePanel1.SetColumn(this.lblHINH_ANH, 2);
            this.lblHINH_ANH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHINH_ANH.Location = new System.Drawing.Point(289, 156);
            this.lblHINH_ANH.Name = "lblHINH_ANH";
            this.tablePanel1.SetRow(this.lblHINH_ANH, 5);
            this.tablePanel1.SetRowSpan(this.lblHINH_ANH, 3);
            this.lblHINH_ANH.Size = new System.Drawing.Size(106, 90);
            this.lblHINH_ANH.TabIndex = 14;
            this.lblHINH_ANH.Text = "lblHINH_ANH";
            // 
            // lblGHI_CHU
            // 
            this.tablePanel1.SetColumn(this.lblGHI_CHU, 0);
            this.lblGHI_CHU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGHI_CHU.Location = new System.Drawing.Point(8, 156);
            this.lblGHI_CHU.Name = "lblGHI_CHU";
            this.tablePanel1.SetRow(this.lblGHI_CHU, 5);
            this.tablePanel1.SetRowSpan(this.lblGHI_CHU, 3);
            this.lblGHI_CHU.Size = new System.Drawing.Size(106, 90);
            this.lblGHI_CHU.TabIndex = 13;
            this.lblGHI_CHU.Text = "txtGHI_CHU";
            // 
            // lblKHOANG_CACH
            // 
            this.tablePanel1.SetColumn(this.lblKHOANG_CACH, 2);
            this.lblKHOANG_CACH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKHOANG_CACH.Location = new System.Drawing.Point(289, 124);
            this.lblKHOANG_CACH.Name = "lblKHOANG_CACH";
            this.tablePanel1.SetRow(this.lblKHOANG_CACH, 4);
            this.lblKHOANG_CACH.Size = new System.Drawing.Size(106, 26);
            this.lblKHOANG_CACH.TabIndex = 12;
            this.lblKHOANG_CACH.Text = "lblKHOANG_CACH";
            // 
            // lblDIEN_TICH
            // 
            this.tablePanel1.SetColumn(this.lblDIEN_TICH, 0);
            this.lblDIEN_TICH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDIEN_TICH.Location = new System.Drawing.Point(8, 124);
            this.lblDIEN_TICH.Name = "lblDIEN_TICH";
            this.tablePanel1.SetRow(this.lblDIEN_TICH, 4);
            this.lblDIEN_TICH.Size = new System.Drawing.Size(106, 26);
            this.lblDIEN_TICH.TabIndex = 11;
            this.lblDIEN_TICH.Text = "lblDIEN_TICH";
            // 
            // lblDIEN_THOAI
            // 
            this.tablePanel1.SetColumn(this.lblDIEN_THOAI, 2);
            this.lblDIEN_THOAI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDIEN_THOAI.Location = new System.Drawing.Point(289, 92);
            this.lblDIEN_THOAI.Name = "lblDIEN_THOAI";
            this.tablePanel1.SetRow(this.lblDIEN_THOAI, 3);
            this.lblDIEN_THOAI.Size = new System.Drawing.Size(106, 26);
            this.lblDIEN_THOAI.TabIndex = 10;
            this.lblDIEN_THOAI.Text = "lblDIEN_THOAI";
            // 
            // lblNGUOI_DAI_DIEN
            // 
            this.tablePanel1.SetColumn(this.lblNGUOI_DAI_DIEN, 0);
            this.lblNGUOI_DAI_DIEN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNGUOI_DAI_DIEN.Location = new System.Drawing.Point(8, 92);
            this.lblNGUOI_DAI_DIEN.Name = "lblNGUOI_DAI_DIEN";
            this.tablePanel1.SetRow(this.lblNGUOI_DAI_DIEN, 3);
            this.lblNGUOI_DAI_DIEN.Size = new System.Drawing.Size(106, 26);
            this.lblNGUOI_DAI_DIEN.TabIndex = 9;
            this.lblNGUOI_DAI_DIEN.Text = "lblNGUOI_DAI_DIEN";
            // 
            // lblTRU_SO
            // 
            this.tablePanel1.SetColumn(this.lblTRU_SO, 2);
            this.lblTRU_SO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTRU_SO.Location = new System.Drawing.Point(289, 60);
            this.lblTRU_SO.Name = "lblTRU_SO";
            this.tablePanel1.SetRow(this.lblTRU_SO, 2);
            this.lblTRU_SO.Size = new System.Drawing.Size(106, 26);
            this.lblTRU_SO.TabIndex = 8;
            this.lblTRU_SO.Text = "lblTRU_SO";
            // 
            // lblMS_DON_VI
            // 
            this.tablePanel1.SetColumn(this.lblMS_DON_VI, 0);
            this.lblMS_DON_VI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMS_DON_VI.Location = new System.Drawing.Point(8, 60);
            this.lblMS_DON_VI.Name = "lblMS_DON_VI";
            this.tablePanel1.SetRow(this.lblMS_DON_VI, 2);
            this.lblMS_DON_VI.Size = new System.Drawing.Size(106, 26);
            this.lblMS_DON_VI.TabIndex = 7;
            this.lblMS_DON_VI.Text = "lblMS_DON_VI";
            // 
            // lblTen_N_XUONG
            // 
            this.tablePanel1.SetColumn(this.lblTen_N_XUONG, 2);
            this.lblTen_N_XUONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTen_N_XUONG.Location = new System.Drawing.Point(289, 8);
            this.lblTen_N_XUONG.Name = "lblTen_N_XUONG";
            this.tablePanel1.SetRow(this.lblTen_N_XUONG, 0);
            this.lblTen_N_XUONG.Size = new System.Drawing.Size(106, 19);
            this.lblTen_N_XUONG.TabIndex = 6;
            this.lblTen_N_XUONG.Text = "lblTen_N_XUONG";
            // 
            // lblMS_N_XUONG
            // 
            this.tablePanel1.SetColumn(this.lblMS_N_XUONG, 0);
            this.lblMS_N_XUONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMS_N_XUONG.Location = new System.Drawing.Point(8, 8);
            this.lblMS_N_XUONG.Name = "lblMS_N_XUONG";
            this.tablePanel1.SetRow(this.lblMS_N_XUONG, 0);
            this.lblMS_N_XUONG.Size = new System.Drawing.Size(106, 19);
            this.lblMS_N_XUONG.TabIndex = 5;
            this.lblMS_N_XUONG.Text = "lblMS_N_XUONG";
            // 
            // lblTEN_N_XUONG_H
            // 
            this.tablePanel1.SetColumn(this.lblTEN_N_XUONG_H, 2);
            this.lblTEN_N_XUONG_H.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTEN_N_XUONG_H.Location = new System.Drawing.Point(289, 33);
            this.lblTEN_N_XUONG_H.Name = "lblTEN_N_XUONG_H";
            this.tablePanel1.SetRow(this.lblTEN_N_XUONG_H, 1);
            this.lblTEN_N_XUONG_H.Size = new System.Drawing.Size(106, 21);
            this.lblTEN_N_XUONG_H.TabIndex = 3;
            this.lblTEN_N_XUONG_H.Text = "lblTEN_N_XUONG_H";
            // 
            // lblTEN_N_XUONG_A
            // 
            this.tablePanel1.SetColumn(this.lblTEN_N_XUONG_A, 0);
            this.lblTEN_N_XUONG_A.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTEN_N_XUONG_A.Location = new System.Drawing.Point(8, 33);
            this.lblTEN_N_XUONG_A.Name = "lblTEN_N_XUONG_A";
            this.tablePanel1.SetRow(this.lblTEN_N_XUONG_A, 1);
            this.lblTEN_N_XUONG_A.Size = new System.Drawing.Size(106, 21);
            this.lblTEN_N_XUONG_A.TabIndex = 2;
            this.lblTEN_N_XUONG_A.Text = "lblTEN_N_XUONG_A";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tablePanel2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tablePanel1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(894, 568);
            this.splitContainerControl1.SplitterPosition = 316;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // tablePanel2
            // 
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.tablePanel2.Controls.Add(this.txtTim);
            this.tablePanel2.Controls.Add(this.TreeList);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel2.Location = new System.Drawing.Point(0, 0);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Padding = new System.Windows.Forms.Padding(5);
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F)});
            this.tablePanel2.Size = new System.Drawing.Size(316, 568);
            this.tablePanel2.TabIndex = 1;
            // 
            // txtTim
            // 
            this.txtTim.Client = this.TreeList;
            this.tablePanel2.SetColumn(this.txtTim, 0);
            this.txtTim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTim.Location = new System.Drawing.Point(8, 534);
            this.txtTim.Name = "txtTim";
            this.txtTim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtTim.Properties.Client = this.TreeList;
            this.tablePanel2.SetRow(this.txtTim, 1);
            this.txtTim.Size = new System.Drawing.Size(300, 20);
            this.txtTim.TabIndex = 1;
            // 
            // frmNhaXuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 568);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.Image = global::VS.OEE.Properties.Resources.OEE;
            this.Name = "frmNhaXuong";
            this.Text = "frmNhaXuong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNhaXuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pieHINH_ANH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGHI_CHU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKHOANG_CACH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIEN_TICH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMS_DON_VI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIEN_THOAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTRU_SO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNGUOI_DAI_DIEN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_N_XUONG_H.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_N_XUONG_A.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_N_XUONG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMS_N_XUONG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTreeList.TreeList TreeList;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl lblTen_N_XUONG;
        private DevExpress.XtraEditors.LabelControl lblMS_N_XUONG;
        private DevExpress.XtraEditors.LabelControl lblTEN_N_XUONG_H;
        private DevExpress.XtraEditors.LabelControl lblTEN_N_XUONG_A;
        private DevExpress.XtraEditors.MemoEdit txtGHI_CHU;
        private DevExpress.XtraEditors.SpinEdit txtKHOANG_CACH;
        private DevExpress.XtraEditors.SpinEdit txtDIEN_TICH;
        private DevExpress.XtraEditors.SearchLookUpEdit cboMS_DON_VI;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.TextEdit txtDIEN_THOAI;
        private DevExpress.XtraEditors.TextEdit txtTRU_SO;
        private DevExpress.XtraEditors.TextEdit txtNGUOI_DAI_DIEN;
        private DevExpress.XtraEditors.TextEdit txtTEN_N_XUONG_H;
        private DevExpress.XtraEditors.TextEdit txtTEN_N_XUONG_A;
        private DevExpress.XtraEditors.TextEdit txtTen_N_XUONG;
        private DevExpress.XtraEditors.TextEdit txtMS_N_XUONG;
        private DevExpress.XtraEditors.LabelControl lblHINH_ANH;
        private DevExpress.XtraEditors.LabelControl lblGHI_CHU;
        private DevExpress.XtraEditors.LabelControl lblKHOANG_CACH;
        private DevExpress.XtraEditors.LabelControl lblDIEN_TICH;
        private DevExpress.XtraEditors.LabelControl lblDIEN_THOAI;
        private DevExpress.XtraEditors.LabelControl lblNGUOI_DAI_DIEN;
        private DevExpress.XtraEditors.LabelControl lblTRU_SO;
        private DevExpress.XtraEditors.LabelControl lblMS_DON_VI;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PictureEdit pieHINH_ANH;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private DevExpress.XtraEditors.SearchControl txtTim;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnKhongGhi;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}