namespace VS.OEE
{
    partial class frmQLCa
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.groCa = new DevExpress.XtraEditors.GroupControl();
            this.grdCa = new DevExpress.XtraGrid.GridControl();
            this.grvCa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.tablecontrol = new DevExpress.Utils.Layout.TablePanel();
            this.datDEN_GIO = new DevExpress.XtraEditors.TimeEdit();
            this.datTU_GIO = new DevExpress.XtraEditors.TimeEdit();
            this.chkCA_DEM = new DevExpress.XtraEditors.CheckEdit();
            this.panelNN = new DevExpress.XtraEditors.PanelControl();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnChoose = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.txtCA = new DevExpress.XtraEditors.TextEdit();
            this.lblCA = new DevExpress.XtraEditors.LabelControl();
            this.lblDEN_GIO = new DevExpress.XtraEditors.LabelControl();
            this.lblCA_ANH = new DevExpress.XtraEditors.LabelControl();
            this.txtCA_ANH = new DevExpress.XtraEditors.TextEdit();
            this.txtCA_HOA = new DevExpress.XtraEditors.TextEdit();
            this.lblCA_HOA = new DevExpress.XtraEditors.LabelControl();
            this.lblTU_GIO = new DevExpress.XtraEditors.LabelControl();
            this.groOperator = new DevExpress.XtraEditors.GroupControl();
            this.grdOperator = new DevExpress.XtraGrid.GridControl();
            this.grvOperator = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groCa)).BeginInit();
            this.groCa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablecontrol)).BeginInit();
            this.tablecontrol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datDEN_GIO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTU_GIO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCA_DEM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCA_ANH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCA_HOA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groOperator)).BeginInit();
            this.groOperator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tablePanel2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tablecontrol);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(932, 452);
            this.splitContainerControl1.SplitterPosition = 251;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // tablePanel2
            // 
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tablePanel2.Controls.Add(this.groCa);
            this.tablePanel2.Controls.Add(this.searchControl1);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel2.Location = new System.Drawing.Point(0, 0);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F)});
            this.tablePanel2.Size = new System.Drawing.Size(251, 452);
            this.tablePanel2.TabIndex = 0;
            // 
            // groCa
            // 
            this.tablePanel2.SetColumn(this.groCa, 0);
            this.groCa.Controls.Add(this.grdCa);
            this.groCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groCa.Location = new System.Drawing.Point(3, 3);
            this.groCa.Name = "groCa";
            this.tablePanel2.SetRow(this.groCa, 0);
            this.groCa.Size = new System.Drawing.Size(245, 414);
            this.groCa.TabIndex = 7;
            this.groCa.Text = "groCa";
            // 
            // grdCa
            // 
            this.grdCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCa.Location = new System.Drawing.Point(2, 22);
            this.grdCa.MainView = this.grvCa;
            this.grdCa.Name = "grdCa";
            this.grdCa.Size = new System.Drawing.Size(241, 390);
            this.grdCa.TabIndex = 5;
            this.grdCa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCa});
            this.grdCa.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdCa_ProcessGridKey);
            // 
            // grvCa
            // 
            this.grvCa.GridControl = this.grdCa;
            this.grvCa.Name = "grvCa";
            this.grvCa.OptionsView.ShowGroupPanel = false;
            this.grvCa.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvCa_FocusedRowChanged);
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.grdCa;
            this.tablePanel2.SetColumn(this.searchControl1, 0);
            this.searchControl1.Location = new System.Drawing.Point(3, 426);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.grdCa;
            this.searchControl1.Properties.FindDelay = 100;
            this.tablePanel2.SetRow(this.searchControl1, 1);
            this.searchControl1.Size = new System.Drawing.Size(245, 20);
            this.searchControl1.TabIndex = 6;
            // 
            // tablecontrol
            // 
            this.tablecontrol.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablecontrol.Controls.Add(this.datDEN_GIO);
            this.tablecontrol.Controls.Add(this.datTU_GIO);
            this.tablecontrol.Controls.Add(this.chkCA_DEM);
            this.tablecontrol.Controls.Add(this.panelNN);
            this.tablecontrol.Controls.Add(this.txtCA);
            this.tablecontrol.Controls.Add(this.lblCA);
            this.tablecontrol.Controls.Add(this.lblDEN_GIO);
            this.tablecontrol.Controls.Add(this.lblCA_ANH);
            this.tablecontrol.Controls.Add(this.txtCA_ANH);
            this.tablecontrol.Controls.Add(this.txtCA_HOA);
            this.tablecontrol.Controls.Add(this.lblCA_HOA);
            this.tablecontrol.Controls.Add(this.lblTU_GIO);
            this.tablecontrol.Controls.Add(this.groOperator);
            this.tablecontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablecontrol.Location = new System.Drawing.Point(0, 0);
            this.tablecontrol.Name = "tablecontrol";
            this.tablecontrol.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.tablecontrol.Size = new System.Drawing.Size(675, 452);
            this.tablecontrol.TabIndex = 0;
            // 
            // datDEN_GIO
            // 
            this.tablecontrol.SetColumn(this.datDEN_GIO, 3);
            this.datDEN_GIO.EditValue = new System.DateTime(2021, 12, 7, 0, 0, 0, 0);
            this.datDEN_GIO.Location = new System.Drawing.Point(348, 37);
            this.datDEN_GIO.Name = "datDEN_GIO";
            this.datDEN_GIO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDEN_GIO.Properties.Mask.EditMask = "t";
            this.tablecontrol.SetRow(this.datDEN_GIO, 2);
            this.datDEN_GIO.Size = new System.Drawing.Size(99, 20);
            this.datDEN_GIO.TabIndex = 12;
            // 
            // datTU_GIO
            // 
            this.tablecontrol.SetColumn(this.datTU_GIO, 1);
            this.datTU_GIO.EditValue = new System.DateTime(2021, 12, 7, 0, 0, 0, 0);
            this.datTU_GIO.Location = new System.Drawing.Point(123, 37);
            this.datTU_GIO.Name = "datTU_GIO";
            this.datTU_GIO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTU_GIO.Properties.DisplayFormat.FormatString = "t";
            this.datTU_GIO.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTU_GIO.Properties.EditFormat.FormatString = "t";
            this.datTU_GIO.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTU_GIO.Properties.Mask.EditMask = "t";
            this.tablecontrol.SetRow(this.datTU_GIO, 2);
            this.datTU_GIO.Size = new System.Drawing.Size(99, 20);
            this.datTU_GIO.TabIndex = 11;
            // 
            // chkCA_DEM
            // 
            this.tablecontrol.SetColumn(this.chkCA_DEM, 4);
            this.chkCA_DEM.Location = new System.Drawing.Point(453, 37);
            this.chkCA_DEM.Name = "chkCA_DEM";
            this.chkCA_DEM.Properties.Caption = "chkCA_DEM";
            this.tablecontrol.SetRow(this.chkCA_DEM, 2);
            this.chkCA_DEM.Size = new System.Drawing.Size(114, 19);
            this.chkCA_DEM.TabIndex = 10;
            // 
            // panelNN
            // 
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablecontrol.SetColumn(this.panelNN, 0);
            this.tablecontrol.SetColumnSpan(this.panelNN, 6);
            this.panelNN.Controls.Add(this.btnThem);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Controls.Add(this.btnXoa);
            this.panelNN.Controls.Add(this.btnSua);
            this.panelNN.Controls.Add(this.btnChoose);
            this.panelNN.Controls.Add(this.btnGhi);
            this.panelNN.Controls.Add(this.btnKhong);
            this.panelNN.Location = new System.Drawing.Point(3, 420);
            this.panelNN.Name = "panelNN";
            this.tablecontrol.SetRow(this.panelNN, 5);
            this.panelNN.Size = new System.Drawing.Size(669, 29);
            this.panelNN.TabIndex = 6;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(344, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 26);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(587, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(506, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 26);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(425, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 26);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoose.Location = new System.Drawing.Point(425, 2);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(80, 26);
            this.btnChoose.TabIndex = 8;
            this.btnChoose.Text = "btnChoose";
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(506, 2);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 11;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Location = new System.Drawing.Point(587, 2);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(80, 26);
            this.btnKhong.TabIndex = 12;
            this.btnKhong.Text = "btnKhong";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // txtCA
            // 
            this.tablecontrol.SetColumn(this.txtCA, 1);
            this.txtCA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCA.Location = new System.Drawing.Point(123, 11);
            this.txtCA.Name = "txtCA";
            this.tablecontrol.SetRow(this.txtCA, 1);
            this.txtCA.Size = new System.Drawing.Size(99, 20);
            this.txtCA.TabIndex = 4;
            // 
            // lblCA
            // 
            this.lblCA.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCA.Appearance.Options.UseFont = true;
            this.tablecontrol.SetColumn(this.lblCA, 0);
            this.lblCA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCA.Location = new System.Drawing.Point(3, 11);
            this.lblCA.Name = "lblCA";
            this.tablecontrol.SetRow(this.lblCA, 1);
            this.lblCA.Size = new System.Drawing.Size(114, 20);
            this.lblCA.TabIndex = 2;
            this.lblCA.Text = "lblCA";
            // 
            // lblDEN_GIO
            // 
            this.tablecontrol.SetColumn(this.lblDEN_GIO, 2);
            this.lblDEN_GIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDEN_GIO.Location = new System.Drawing.Point(228, 37);
            this.lblDEN_GIO.Name = "lblDEN_GIO";
            this.tablecontrol.SetRow(this.lblDEN_GIO, 2);
            this.lblDEN_GIO.Size = new System.Drawing.Size(114, 20);
            this.lblDEN_GIO.TabIndex = 2;
            this.lblDEN_GIO.Text = "lblDEN_GIO";
            // 
            // lblCA_ANH
            // 
            this.lblCA_ANH.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCA_ANH.Appearance.Options.UseFont = true;
            this.tablecontrol.SetColumn(this.lblCA_ANH, 2);
            this.lblCA_ANH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCA_ANH.Location = new System.Drawing.Point(228, 11);
            this.lblCA_ANH.Name = "lblCA_ANH";
            this.tablecontrol.SetRow(this.lblCA_ANH, 1);
            this.lblCA_ANH.Size = new System.Drawing.Size(114, 20);
            this.lblCA_ANH.TabIndex = 2;
            this.lblCA_ANH.Text = "lblCA_ANH";
            // 
            // txtCA_ANH
            // 
            this.tablecontrol.SetColumn(this.txtCA_ANH, 3);
            this.txtCA_ANH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCA_ANH.Location = new System.Drawing.Point(348, 11);
            this.txtCA_ANH.Name = "txtCA_ANH";
            this.tablecontrol.SetRow(this.txtCA_ANH, 1);
            this.txtCA_ANH.Size = new System.Drawing.Size(99, 20);
            this.txtCA_ANH.TabIndex = 4;
            // 
            // txtCA_HOA
            // 
            this.tablecontrol.SetColumn(this.txtCA_HOA, 5);
            this.txtCA_HOA.Location = new System.Drawing.Point(573, 11);
            this.txtCA_HOA.Name = "txtCA_HOA";
            this.tablecontrol.SetRow(this.txtCA_HOA, 1);
            this.txtCA_HOA.Size = new System.Drawing.Size(99, 20);
            this.txtCA_HOA.TabIndex = 4;
            // 
            // lblCA_HOA
            // 
            this.tablecontrol.SetColumn(this.lblCA_HOA, 4);
            this.lblCA_HOA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCA_HOA.Location = new System.Drawing.Point(453, 11);
            this.lblCA_HOA.Name = "lblCA_HOA";
            this.tablecontrol.SetRow(this.lblCA_HOA, 1);
            this.lblCA_HOA.Size = new System.Drawing.Size(114, 20);
            this.lblCA_HOA.TabIndex = 2;
            this.lblCA_HOA.Text = "lblCA_HOA";
            // 
            // lblTU_GIO
            // 
            this.tablecontrol.SetColumn(this.lblTU_GIO, 0);
            this.lblTU_GIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTU_GIO.Location = new System.Drawing.Point(3, 37);
            this.lblTU_GIO.Name = "lblTU_GIO";
            this.tablecontrol.SetRow(this.lblTU_GIO, 2);
            this.lblTU_GIO.Size = new System.Drawing.Size(114, 20);
            this.lblTU_GIO.TabIndex = 2;
            this.lblTU_GIO.Text = "lblTU_GIO";
            // 
            // groOperator
            // 
            this.tablecontrol.SetColumn(this.groOperator, 0);
            this.tablecontrol.SetColumnSpan(this.groOperator, 6);
            this.groOperator.Controls.Add(this.grdOperator);
            this.groOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groOperator.Location = new System.Drawing.Point(3, 71);
            this.groOperator.Name = "groOperator";
            this.tablecontrol.SetRow(this.groOperator, 4);
            this.groOperator.Size = new System.Drawing.Size(669, 343);
            this.groOperator.TabIndex = 7;
            this.groOperator.Text = "groOperator";
            // 
            // grdOperator
            // 
            this.grdOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOperator.Location = new System.Drawing.Point(2, 22);
            this.grdOperator.MainView = this.grvOperator;
            this.grdOperator.Name = "grdOperator";
            this.grdOperator.Size = new System.Drawing.Size(665, 319);
            this.grdOperator.TabIndex = 5;
            this.grdOperator.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOperator,
            this.gridView1});
            this.grdOperator.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdOperator_ProcessGridKey);
            // 
            // grvOperator
            // 
            this.grvOperator.GridControl = this.grdOperator;
            this.grvOperator.Name = "grvOperator";
            this.grvOperator.OptionsView.ShowGroupPanel = false;
            this.grvOperator.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvOperator_InitNewRow);
            this.grvOperator.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvOperator_CellValueChanged);
            this.grvOperator.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvOperator_InvalidRowException);
            this.grvOperator.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvOperator_ValidateRow);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdOperator;
            this.gridView1.Name = "gridView1";
            // 
            // frmQLCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 452);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmQLCa";
            this.Text = "frmQLCa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQLCa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groCa)).EndInit();
            this.groCa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablecontrol)).EndInit();
            this.tablecontrol.ResumeLayout(false);
            this.tablecontrol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datDEN_GIO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTU_GIO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCA_DEM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCA_ANH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCA_HOA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groOperator)).EndInit();
            this.groOperator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private DevExpress.XtraGrid.GridControl grdCa;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCa;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.GroupControl groCa;
        private DevExpress.Utils.Layout.TablePanel tablecontrol;
        private DevExpress.XtraEditors.CheckEdit chkCA_DEM;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnChoose;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.TextEdit txtCA;
        private DevExpress.XtraEditors.LabelControl lblCA;
        private DevExpress.XtraEditors.LabelControl lblDEN_GIO;
        private DevExpress.XtraEditors.LabelControl lblCA_ANH;
        private DevExpress.XtraEditors.TextEdit txtCA_ANH;
        private DevExpress.XtraEditors.TextEdit txtCA_HOA;
        private DevExpress.XtraEditors.LabelControl lblCA_HOA;
        private DevExpress.XtraEditors.LabelControl lblTU_GIO;
        private DevExpress.XtraEditors.GroupControl groOperator;
        private DevExpress.XtraGrid.GridControl grdOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView grvOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TimeEdit datDEN_GIO;
        private DevExpress.XtraEditors.TimeEdit datTU_GIO;
    }
}
