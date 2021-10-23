namespace VS.OEE
{
    partial class frmDanhMucHeThong
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
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.txtTim = new DevExpress.XtraEditors.SearchControl();
            this.TreeList = new DevExpress.XtraTreeList.TreeList();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.txtSTT = new DevExpress.XtraEditors.SpinEdit();
            this.txtTAI_LIEU = new DevExpress.XtraEditors.ButtonEdit();
            this.txtGHI_CHU = new DevExpress.XtraEditors.MemoEdit();
            this.chkNO_LINE = new DevExpress.XtraEditors.CheckEdit();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.txtTEN_HE_THONG_HOA = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_HE_THONG_ANH = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_HE_THONG = new DevExpress.XtraEditors.TextEdit();
            this.txtMA_HE_THONG = new DevExpress.XtraEditors.TextEdit();
            this.lblGHI_CHU = new DevExpress.XtraEditors.LabelControl();
            this.lblTAI_LIEU = new DevExpress.XtraEditors.LabelControl();
            this.lblTEN_HE_THONG_HOA = new DevExpress.XtraEditors.LabelControl();
            this.lblTEN_HE_THONG_ANH = new DevExpress.XtraEditors.LabelControl();
            this.lblTEN_HE_THONG = new DevExpress.XtraEditors.LabelControl();
            this.lblSTT = new DevExpress.XtraEditors.LabelControl();
            this.lblNO_LINE = new DevExpress.XtraEditors.LabelControl();
            this.lblMA_HE_THONG = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTAI_LIEU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGHI_CHU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNO_LINE.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_HE_THONG_HOA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_HE_THONG_ANH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_HE_THONG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMA_HE_THONG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.LookAndFeel.SkinName = "Blue";
            this.splitContainer1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.tablePanel1);
            this.splitContainer1.Panel2.Controls.Add(this.tablePanel2);
            this.splitContainer1.Size = new System.Drawing.Size(894, 517);
            this.splitContainer1.SplitterPosition = 322;
            this.splitContainer1.TabIndex = 0;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.tablePanel1.Controls.Add(this.txtTim);
            this.tablePanel1.Controls.Add(this.TreeList);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F)});
            this.tablePanel1.Size = new System.Drawing.Size(322, 517);
            this.tablePanel1.TabIndex = 0;
            // 
            // txtTim
            // 
            this.txtTim.Client = this.TreeList;
            this.tablePanel1.SetColumn(this.txtTim, 0);
            this.txtTim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTim.Location = new System.Drawing.Point(8, 493);
            this.txtTim.Name = "txtTim";
            this.txtTim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtTim.Properties.Client = this.TreeList;
            this.tablePanel1.SetRow(this.txtTim, 1);
            this.txtTim.Size = new System.Drawing.Size(306, 20);
            this.txtTim.TabIndex = 1;
            // 
            // TreeList
            // 
            this.tablePanel1.SetColumn(this.TreeList, 0);
            this.TreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeList.Location = new System.Drawing.Point(8, 8);
            this.TreeList.MinWidth = 17;
            this.TreeList.Name = "TreeList";
            this.tablePanel1.SetRow(this.TreeList, 0);
            this.TreeList.Size = new System.Drawing.Size(306, 479);
            this.TreeList.TabIndex = 0;
            this.TreeList.TreeLevelWidth = 15;
            this.TreeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreeList_FocusedNodeChanged);
            // 
            // tablePanel2
            // 
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26.8F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 27.38F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 13.29F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 6.71F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10.82F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 15F)});
            this.tablePanel2.Controls.Add(this.txtSTT);
            this.tablePanel2.Controls.Add(this.txtTAI_LIEU);
            this.tablePanel2.Controls.Add(this.txtGHI_CHU);
            this.tablePanel2.Controls.Add(this.chkNO_LINE);
            this.tablePanel2.Controls.Add(this.flowLayoutPanel1);
            this.tablePanel2.Controls.Add(this.txtTEN_HE_THONG_HOA);
            this.tablePanel2.Controls.Add(this.txtTEN_HE_THONG_ANH);
            this.tablePanel2.Controls.Add(this.txtTEN_HE_THONG);
            this.tablePanel2.Controls.Add(this.txtMA_HE_THONG);
            this.tablePanel2.Controls.Add(this.lblGHI_CHU);
            this.tablePanel2.Controls.Add(this.lblTAI_LIEU);
            this.tablePanel2.Controls.Add(this.lblTEN_HE_THONG_HOA);
            this.tablePanel2.Controls.Add(this.lblTEN_HE_THONG_ANH);
            this.tablePanel2.Controls.Add(this.lblTEN_HE_THONG);
            this.tablePanel2.Controls.Add(this.lblSTT);
            this.tablePanel2.Controls.Add(this.lblNO_LINE);
            this.tablePanel2.Controls.Add(this.lblMA_HE_THONG);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel2.Location = new System.Drawing.Point(0, 0);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 62F)});
            this.tablePanel2.Size = new System.Drawing.Size(566, 517);
            this.tablePanel2.TabIndex = 0;
            // 
            // txtSTT
            // 
            this.tablePanel2.SetColumn(this.txtSTT, 5);
            this.txtSTT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSTT.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSTT.Location = new System.Drawing.Point(481, 8);
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSTT.Properties.DisplayFormat.FormatString = "n0";
            this.txtSTT.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSTT.Properties.EditFormat.FormatString = "n0";
            this.txtSTT.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSTT.Properties.Mask.EditMask = "n0";
            this.tablePanel2.SetRow(this.txtSTT, 0);
            this.txtSTT.Size = new System.Drawing.Size(77, 20);
            this.txtSTT.TabIndex = 19;
            // 
            // txtTAI_LIEU
            // 
            this.tablePanel2.SetColumn(this.txtTAI_LIEU, 1);
            this.tablePanel2.SetColumnSpan(this.txtTAI_LIEU, 5);
            this.txtTAI_LIEU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTAI_LIEU.Location = new System.Drawing.Point(157, 96);
            this.txtTAI_LIEU.Name = "txtTAI_LIEU";
            this.txtTAI_LIEU.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tablePanel2.SetRow(this.txtTAI_LIEU, 4);
            this.txtTAI_LIEU.Size = new System.Drawing.Size(401, 20);
            this.txtTAI_LIEU.TabIndex = 18;
            this.txtTAI_LIEU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtTAI_LIEU_ButtonClick);
            // 
            // txtGHI_CHU
            // 
            this.tablePanel2.SetColumn(this.txtGHI_CHU, 1);
            this.tablePanel2.SetColumnSpan(this.txtGHI_CHU, 5);
            this.txtGHI_CHU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGHI_CHU.Location = new System.Drawing.Point(157, 118);
            this.txtGHI_CHU.Name = "txtGHI_CHU";
            this.tablePanel2.SetRow(this.txtGHI_CHU, 5);
            this.tablePanel2.SetRowSpan(this.txtGHI_CHU, 3);
            this.txtGHI_CHU.Size = new System.Drawing.Size(401, 60);
            this.txtGHI_CHU.TabIndex = 17;
            // 
            // chkNO_LINE
            // 
            this.tablePanel2.SetColumn(this.chkNO_LINE, 3);
            this.chkNO_LINE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkNO_LINE.Location = new System.Drawing.Point(383, 8);
            this.chkNO_LINE.Name = "chkNO_LINE";
            this.chkNO_LINE.Properties.Caption = "";
            this.tablePanel2.SetRow(this.chkNO_LINE, 0);
            this.chkNO_LINE.Size = new System.Drawing.Size(31, 16);
            this.chkNO_LINE.TabIndex = 16;
            // 
            // flowLayoutPanel1
            // 
            this.tablePanel2.SetColumn(this.flowLayoutPanel1, 0);
            this.tablePanel2.SetColumnSpan(this.flowLayoutPanel1, 6);
            this.flowLayoutPanel1.Controls.Add(this.btnThoat);
            this.flowLayoutPanel1.Controls.Add(this.btnKhongGhi);
            this.flowLayoutPanel1.Controls.Add(this.btnGhi);
            this.flowLayoutPanel1.Controls.Add(this.btnXoa);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 473);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tablePanel2.SetRow(this.flowLayoutPanel1, 9);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(550, 36);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(442, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(105, 29);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnKhongGhi
            // 
            this.btnKhongGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhongGhi.Location = new System.Drawing.Point(331, 3);
            this.btnKhongGhi.Name = "btnKhongGhi";
            this.btnKhongGhi.Size = new System.Drawing.Size(105, 29);
            this.btnKhongGhi.TabIndex = 2;
            this.btnKhongGhi.Text = "btnKhongGhi";
            this.btnKhongGhi.Click += new System.EventHandler(this.btnKhongGhi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(220, 3);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(105, 29);
            this.btnGhi.TabIndex = 3;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(109, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(105, 29);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtTEN_HE_THONG_HOA
            // 
            this.tablePanel2.SetColumn(this.txtTEN_HE_THONG_HOA, 1);
            this.tablePanel2.SetColumnSpan(this.txtTEN_HE_THONG_HOA, 5);
            this.txtTEN_HE_THONG_HOA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEN_HE_THONG_HOA.Location = new System.Drawing.Point(157, 74);
            this.txtTEN_HE_THONG_HOA.Name = "txtTEN_HE_THONG_HOA";
            this.tablePanel2.SetRow(this.txtTEN_HE_THONG_HOA, 3);
            this.txtTEN_HE_THONG_HOA.Size = new System.Drawing.Size(401, 20);
            this.txtTEN_HE_THONG_HOA.TabIndex = 12;
            // 
            // txtTEN_HE_THONG_ANH
            // 
            this.tablePanel2.SetColumn(this.txtTEN_HE_THONG_ANH, 1);
            this.tablePanel2.SetColumnSpan(this.txtTEN_HE_THONG_ANH, 5);
            this.txtTEN_HE_THONG_ANH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEN_HE_THONG_ANH.Location = new System.Drawing.Point(157, 52);
            this.txtTEN_HE_THONG_ANH.Name = "txtTEN_HE_THONG_ANH";
            this.tablePanel2.SetRow(this.txtTEN_HE_THONG_ANH, 2);
            this.txtTEN_HE_THONG_ANH.Size = new System.Drawing.Size(401, 20);
            this.txtTEN_HE_THONG_ANH.TabIndex = 11;
            // 
            // txtTEN_HE_THONG
            // 
            this.tablePanel2.SetColumn(this.txtTEN_HE_THONG, 1);
            this.tablePanel2.SetColumnSpan(this.txtTEN_HE_THONG, 5);
            this.txtTEN_HE_THONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEN_HE_THONG.Location = new System.Drawing.Point(157, 30);
            this.txtTEN_HE_THONG.Name = "txtTEN_HE_THONG";
            this.tablePanel2.SetRow(this.txtTEN_HE_THONG, 1);
            this.txtTEN_HE_THONG.Size = new System.Drawing.Size(401, 20);
            this.txtTEN_HE_THONG.TabIndex = 10;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtTEN_HE_THONG, conditionValidationRule1);
            // 
            // txtMA_HE_THONG
            // 
            this.tablePanel2.SetColumn(this.txtMA_HE_THONG, 1);
            this.txtMA_HE_THONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMA_HE_THONG.Location = new System.Drawing.Point(157, 8);
            this.txtMA_HE_THONG.Name = "txtMA_HE_THONG";
            this.txtMA_HE_THONG.Properties.DisplayFormat.FormatString = "n0";
            this.txtMA_HE_THONG.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMA_HE_THONG.Properties.EditFormat.FormatString = "n0";
            this.txtMA_HE_THONG.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMA_HE_THONG.Properties.Mask.EditMask = "n0";
            this.txtMA_HE_THONG.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tablePanel2.SetRow(this.txtMA_HE_THONG, 0);
            this.txtMA_HE_THONG.Size = new System.Drawing.Size(146, 20);
            this.txtMA_HE_THONG.TabIndex = 8;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtMA_HE_THONG, conditionValidationRule2);
            // 
            // lblGHI_CHU
            // 
            this.tablePanel2.SetColumn(this.lblGHI_CHU, 0);
            this.lblGHI_CHU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGHI_CHU.Location = new System.Drawing.Point(8, 118);
            this.lblGHI_CHU.Name = "lblGHI_CHU";
            this.tablePanel2.SetRow(this.lblGHI_CHU, 5);
            this.tablePanel2.SetRowSpan(this.lblGHI_CHU, 3);
            this.lblGHI_CHU.Size = new System.Drawing.Size(143, 60);
            this.lblGHI_CHU.TabIndex = 7;
            this.lblGHI_CHU.Text = "lblGHI_CHU";
            // 
            // lblTAI_LIEU
            // 
            this.tablePanel2.SetColumn(this.lblTAI_LIEU, 0);
            this.lblTAI_LIEU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTAI_LIEU.Location = new System.Drawing.Point(8, 96);
            this.lblTAI_LIEU.Name = "lblTAI_LIEU";
            this.tablePanel2.SetRow(this.lblTAI_LIEU, 4);
            this.lblTAI_LIEU.Size = new System.Drawing.Size(143, 16);
            this.lblTAI_LIEU.TabIndex = 6;
            this.lblTAI_LIEU.Text = "lblTAI_LIEU";
            // 
            // lblTEN_HE_THONG_HOA
            // 
            this.tablePanel2.SetColumn(this.lblTEN_HE_THONG_HOA, 0);
            this.lblTEN_HE_THONG_HOA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTEN_HE_THONG_HOA.Location = new System.Drawing.Point(8, 74);
            this.lblTEN_HE_THONG_HOA.Name = "lblTEN_HE_THONG_HOA";
            this.tablePanel2.SetRow(this.lblTEN_HE_THONG_HOA, 3);
            this.lblTEN_HE_THONG_HOA.Size = new System.Drawing.Size(143, 16);
            this.lblTEN_HE_THONG_HOA.TabIndex = 5;
            this.lblTEN_HE_THONG_HOA.Text = "lblTEN_HE_THONG_HOA";
            // 
            // lblTEN_HE_THONG_ANH
            // 
            this.tablePanel2.SetColumn(this.lblTEN_HE_THONG_ANH, 0);
            this.lblTEN_HE_THONG_ANH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTEN_HE_THONG_ANH.Location = new System.Drawing.Point(8, 52);
            this.lblTEN_HE_THONG_ANH.Name = "lblTEN_HE_THONG_ANH";
            this.tablePanel2.SetRow(this.lblTEN_HE_THONG_ANH, 2);
            this.lblTEN_HE_THONG_ANH.Size = new System.Drawing.Size(143, 16);
            this.lblTEN_HE_THONG_ANH.TabIndex = 4;
            this.lblTEN_HE_THONG_ANH.Text = "lblTEN_HE_THONG_ANH";
            // 
            // lblTEN_HE_THONG
            // 
            this.tablePanel2.SetColumn(this.lblTEN_HE_THONG, 0);
            this.lblTEN_HE_THONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTEN_HE_THONG.Location = new System.Drawing.Point(8, 30);
            this.lblTEN_HE_THONG.Name = "lblTEN_HE_THONG";
            this.tablePanel2.SetRow(this.lblTEN_HE_THONG, 1);
            this.lblTEN_HE_THONG.Size = new System.Drawing.Size(143, 16);
            this.lblTEN_HE_THONG.TabIndex = 3;
            this.lblTEN_HE_THONG.Text = "lblTEN_HE_THONG";
            // 
            // lblSTT
            // 
            this.tablePanel2.SetColumn(this.lblSTT, 4);
            this.lblSTT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSTT.Location = new System.Drawing.Point(420, 8);
            this.lblSTT.Name = "lblSTT";
            this.tablePanel2.SetRow(this.lblSTT, 0);
            this.lblSTT.Size = new System.Drawing.Size(54, 16);
            this.lblSTT.TabIndex = 2;
            this.lblSTT.Text = "lblSTT";
            // 
            // lblNO_LINE
            // 
            this.tablePanel2.SetColumn(this.lblNO_LINE, 2);
            this.lblNO_LINE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNO_LINE.Location = new System.Drawing.Point(309, 8);
            this.lblNO_LINE.Name = "lblNO_LINE";
            this.tablePanel2.SetRow(this.lblNO_LINE, 0);
            this.lblNO_LINE.Size = new System.Drawing.Size(68, 16);
            this.lblNO_LINE.TabIndex = 1;
            this.lblNO_LINE.Text = "lblNO_LINE";
            // 
            // lblMA_HE_THONG
            // 
            this.tablePanel2.SetColumn(this.lblMA_HE_THONG, 0);
            this.lblMA_HE_THONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMA_HE_THONG.Location = new System.Drawing.Point(8, 8);
            this.lblMA_HE_THONG.Name = "lblMA_HE_THONG";
            this.tablePanel2.SetRow(this.lblMA_HE_THONG, 0);
            this.lblMA_HE_THONG.Size = new System.Drawing.Size(143, 16);
            this.lblMA_HE_THONG.TabIndex = 0;
            this.lblMA_HE_THONG.Text = "lblMA_HE_THONG";
            // 
            // frmDanhMucHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 517);
            this.Controls.Add(this.splitContainer1);
            this.IconOptions.Image = global::VS.OEE.Properties.Resources.OEE;
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmDanhMucHeThong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDanhMucHeThong";
            this.Load += new System.EventHandler(this.frmLoaiBaoTri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            this.tablePanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTAI_LIEU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGHI_CHU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNO_LINE.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_HE_THONG_HOA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_HE_THONG_ANH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_HE_THONG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMA_HE_THONG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SearchControl txtTim;
        private DevExpress.XtraTreeList.TreeList TreeList;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private DevExpress.XtraEditors.LabelControl lblGHI_CHU;
        private DevExpress.XtraEditors.LabelControl lblTAI_LIEU;
        private DevExpress.XtraEditors.LabelControl lblTEN_HE_THONG_HOA;
        private DevExpress.XtraEditors.LabelControl lblTEN_HE_THONG_ANH;
        private DevExpress.XtraEditors.LabelControl lblTEN_HE_THONG;
        private DevExpress.XtraEditors.LabelControl lblSTT;
        private DevExpress.XtraEditors.LabelControl lblNO_LINE;
        private DevExpress.XtraEditors.LabelControl lblMA_HE_THONG;
        private DevExpress.XtraEditors.MemoEdit txtGHI_CHU;
        private DevExpress.XtraEditors.CheckEdit chkNO_LINE;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.TextEdit txtTEN_HE_THONG_HOA;
        private DevExpress.XtraEditors.TextEdit txtTEN_HE_THONG_ANH;
        private DevExpress.XtraEditors.TextEdit txtTEN_HE_THONG;
        private DevExpress.XtraEditors.TextEdit txtMA_HE_THONG;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnKhongGhi;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.ButtonEdit txtTAI_LIEU;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.SpinEdit txtSTT;
    }
}