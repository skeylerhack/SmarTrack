namespace VS.OEE
{
    partial class frmOperator
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.txtOperatorName = new DevExpress.XtraEditors.TextEdit();
            this.txtOperatorCode = new DevExpress.XtraEditors.TextEdit();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.lblOperatorName = new DevExpress.XtraEditors.LabelControl();
            this.panelNN = new DevExpress.XtraEditors.PanelControl();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearch = new DevExpress.XtraEditors.SearchControl();
            this.grdOperator = new DevExpress.XtraGrid.GridControl();
            this.grvOperator = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.chkNghiViec = new DevExpress.XtraEditors.CheckEdit();
            this.txtChucVu = new DevExpress.XtraEditors.TextEdit();
            this.cboTo = new DevExpress.XtraEditors.LookUpEdit();
            this.lblOperatorCode = new DevExpress.XtraEditors.LabelControl();
            this.lblCardID = new DevExpress.XtraEditors.LabelControl();
            this.txtCardID = new DevExpress.XtraEditors.TextEdit();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.lblGmail = new DevExpress.XtraEditors.LabelControl();
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtGmail = new DevExpress.XtraEditors.TextEdit();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.lblChucVu = new DevExpress.XtraEditors.LabelControl();
            this.lblNghiViec = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNghiViec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChucVu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOperatorName
            // 
            this.panelChung.SetColumn(this.txtOperatorName, 4);
            this.txtOperatorName.EnterMoveNextControl = true;
            this.txtOperatorName.Location = new System.Drawing.Point(465, 11);
            this.txtOperatorName.Name = "txtOperatorName";
            this.panelChung.SetRow(this.txtOperatorName, 1);
            this.txtOperatorName.Size = new System.Drawing.Size(153, 20);
            this.txtOperatorName.TabIndex = 1;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtOperatorName, conditionValidationRule3);
            // 
            // txtOperatorCode
            // 
            this.panelChung.SetColumn(this.txtOperatorCode, 2);
            this.txtOperatorCode.EnterMoveNextControl = true;
            this.txtOperatorCode.Location = new System.Drawing.Point(186, 11);
            this.txtOperatorCode.Name = "txtOperatorCode";
            this.panelChung.SetRow(this.txtOperatorCode, 1);
            this.txtOperatorCode.Size = new System.Drawing.Size(153, 20);
            this.txtOperatorCode.TabIndex = 0;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtOperatorCode, conditionValidationRule2);
            // 
            // lblNote
            // 
            this.lblNote.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblNote, 1);
            this.lblNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNote.Location = new System.Drawing.Point(66, 89);
            this.lblNote.Name = "lblNote";
            this.panelChung.SetRow(this.lblNote, 4);
            this.lblNote.Size = new System.Drawing.Size(114, 46);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "lblNote";
            this.lblNote.Click += new System.EventHandler(this.lblNote_Click);
            // 
            // lblOperatorName
            // 
            this.lblOperatorName.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorName.Appearance.Options.UseFont = true;
            this.lblOperatorName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblOperatorName, 3);
            this.lblOperatorName.Location = new System.Drawing.Point(345, 11);
            this.lblOperatorName.Name = "lblOperatorName";
            this.panelChung.SetRow(this.lblOperatorName, 1);
            this.lblOperatorName.Size = new System.Drawing.Size(114, 19);
            this.lblOperatorName.TabIndex = 1;
            this.lblOperatorName.Text = "lblOperatorName";
            // 
            // panelNN
            // 
            this.panelNN.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelNN.Appearance.Options.UseBackColor = true;
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelChung.SetColumn(this.panelNN, 0);
            this.panelChung.SetColumnSpan(this.panelNN, 8);
            this.panelNN.Controls.Add(this.btnSua);
            this.panelNN.Controls.Add(this.txtSearch);
            this.panelNN.Controls.Add(this.btnThem);
            this.panelNN.Controls.Add(this.btnGhi);
            this.panelNN.Controls.Add(this.btnKhong);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Controls.Add(this.btnXoa);
            this.panelNN.Location = new System.Drawing.Point(3, 442);
            this.panelNN.Name = "panelNN";
            this.panelChung.SetRow(this.panelNN, 7);
            this.panelNN.Size = new System.Drawing.Size(957, 29);
            this.panelNN.TabIndex = 6;
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(715, 1);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 26);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.Client = this.grdOperator;
            this.txtSearch.EnterMoveNextControl = true;
            this.txtSearch.Location = new System.Drawing.Point(2, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtSearch.Properties.Client = this.grdOperator;
            this.txtSearch.Properties.FindDelay = 100;
            this.txtSearch.Size = new System.Drawing.Size(150, 20);
            this.txtSearch.TabIndex = 3;
            // 
            // grdOperator
            // 
            this.panelChung.SetColumn(this.grdOperator, 0);
            this.panelChung.SetColumnSpan(this.grdOperator, 8);
            this.grdOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOperator.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdOperator.Location = new System.Drawing.Point(2, 148);
            this.grdOperator.MainView = this.grvOperator;
            this.grdOperator.Margin = new System.Windows.Forms.Padding(2);
            this.grdOperator.Name = "grdOperator";
            this.panelChung.SetRow(this.grdOperator, 6);
            this.grdOperator.Size = new System.Drawing.Size(959, 289);
            this.grdOperator.TabIndex = 7;
            this.grdOperator.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOperator,
            this.gridView1});
            this.grdOperator.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdChung_ProcessGridKey);
            // 
            // grvOperator
            // 
            this.grvOperator.ColumnPanelRowHeight = 1;
            this.grvOperator.DetailHeight = 227;
            this.grvOperator.FixedLineWidth = 1;
            this.grvOperator.GridControl = this.grdOperator;
            this.grvOperator.Name = "grvOperator";
            this.grvOperator.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvOperator.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvOperator.OptionsCustomization.AllowRowSizing = true;
            this.grvOperator.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel;
            this.grvOperator.OptionsFind.FindDelay = 100;
            this.grvOperator.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvOperator.OptionsPrint.AllowMultilineHeaders = true;
            this.grvOperator.OptionsScrollAnnotations.ShowCustomAnnotations = DevExpress.Utils.DefaultBoolean.True;
            this.grvOperator.OptionsScrollAnnotations.ShowErrors = DevExpress.Utils.DefaultBoolean.True;
            this.grvOperator.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvOperator.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvOperator.OptionsView.RowAutoHeight = true;
            this.grvOperator.OptionsView.ShowGroupPanel = false;
            this.grvOperator.RowHeight = 1;
            this.grvOperator.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvChung_FocusedRowChanged);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdOperator;
            this.gridView1.Name = "gridView1";
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(634, 1);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 26);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(796, 1);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 5;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Location = new System.Drawing.Point(877, 1);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(80, 26);
            this.btnKhong.TabIndex = 5;
            this.btnKhong.Text = "btnKhong";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(877, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(796, 1);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 26);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtID
            // 
            this.panelChung.SetColumn(this.txtID, 0);
            this.txtID.Location = new System.Drawing.Point(3, 11);
            this.txtID.Name = "txtID";
            this.panelChung.SetRow(this.txtID, 1);
            this.txtID.Size = new System.Drawing.Size(57, 20);
            this.txtID.TabIndex = 0;
            this.txtID.Visible = false;
            // 
            // panelChung
            // 
            this.panelChung.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F)});
            this.panelChung.Controls.Add(this.chkNghiViec);
            this.panelChung.Controls.Add(this.txtChucVu);
            this.panelChung.Controls.Add(this.cboTo);
            this.panelChung.Controls.Add(this.txtID);
            this.panelChung.Controls.Add(this.grdOperator);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.txtOperatorName);
            this.panelChung.Controls.Add(this.lblOperatorName);
            this.panelChung.Controls.Add(this.lblNote);
            this.panelChung.Controls.Add(this.lblOperatorCode);
            this.panelChung.Controls.Add(this.lblCardID);
            this.panelChung.Controls.Add(this.txtOperatorCode);
            this.panelChung.Controls.Add(this.txtCardID);
            this.panelChung.Controls.Add(this.lblPhone);
            this.panelChung.Controls.Add(this.lblGmail);
            this.panelChung.Controls.Add(this.lblTo);
            this.panelChung.Controls.Add(this.txtPhone);
            this.panelChung.Controls.Add(this.txtGmail);
            this.panelChung.Controls.Add(this.txtNote);
            this.panelChung.Controls.Add(this.lblChucVu);
            this.panelChung.Controls.Add(this.lblNghiViec);
            this.panelChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChung.Location = new System.Drawing.Point(0, 0);
            this.panelChung.Name = "panelChung";
            this.panelChung.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 52F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.panelChung.Size = new System.Drawing.Size(963, 474);
            this.panelChung.TabIndex = 2;
            // 
            // chkNghiViec
            // 
            this.panelChung.SetColumn(this.chkNghiViec, 6);
            this.chkNghiViec.Location = new System.Drawing.Point(744, 63);
            this.chkNghiViec.Name = "chkNghiViec";
            this.chkNghiViec.Properties.Caption = "checkEdit1";
            this.chkNghiViec.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.panelChung.SetRow(this.chkNghiViec, 3);
            this.chkNghiViec.Size = new System.Drawing.Size(153, 19);
            this.chkNghiViec.TabIndex = 10;
            // 
            // txtChucVu
            // 
            this.panelChung.SetColumn(this.txtChucVu, 2);
            this.panelChung.SetColumnSpan(this.txtChucVu, 3);
            this.txtChucVu.Location = new System.Drawing.Point(186, 63);
            this.txtChucVu.Name = "txtChucVu";
            this.panelChung.SetRow(this.txtChucVu, 3);
            this.txtChucVu.Size = new System.Drawing.Size(432, 20);
            this.txtChucVu.TabIndex = 9;
            // 
            // cboTo
            // 
            this.panelChung.SetColumn(this.cboTo, 6);
            this.cboTo.Location = new System.Drawing.Point(744, 37);
            this.cboTo.Name = "cboTo";
            this.cboTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTo.Properties.NullText = "";
            this.panelChung.SetRow(this.cboTo, 2);
            this.cboTo.Size = new System.Drawing.Size(153, 20);
            this.cboTo.TabIndex = 8;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.cboTo, conditionValidationRule1);
            // 
            // lblOperatorCode
            // 
            this.lblOperatorCode.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorCode.Appearance.Options.UseFont = true;
            this.lblOperatorCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblOperatorCode, 1);
            this.lblOperatorCode.Location = new System.Drawing.Point(66, 11);
            this.lblOperatorCode.Name = "lblOperatorCode";
            this.panelChung.SetRow(this.lblOperatorCode, 1);
            this.lblOperatorCode.Size = new System.Drawing.Size(114, 19);
            this.lblOperatorCode.TabIndex = 1;
            this.lblOperatorCode.Text = "lblOperatorCode";
            // 
            // lblCardID
            // 
            this.lblCardID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblCardID, 5);
            this.lblCardID.Location = new System.Drawing.Point(624, 11);
            this.lblCardID.Name = "lblCardID";
            this.panelChung.SetRow(this.lblCardID, 1);
            this.lblCardID.Size = new System.Drawing.Size(114, 19);
            this.lblCardID.TabIndex = 1;
            this.lblCardID.Text = "lblCardID";
            // 
            // txtCardID
            // 
            this.panelChung.SetColumn(this.txtCardID, 6);
            this.txtCardID.Location = new System.Drawing.Point(744, 11);
            this.txtCardID.Name = "txtCardID";
            this.panelChung.SetRow(this.txtCardID, 1);
            this.txtCardID.Size = new System.Drawing.Size(153, 20);
            this.txtCardID.TabIndex = 2;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblPhone, 1);
            this.lblPhone.Location = new System.Drawing.Point(66, 37);
            this.lblPhone.Name = "lblPhone";
            this.panelChung.SetRow(this.lblPhone, 2);
            this.lblPhone.Size = new System.Drawing.Size(114, 19);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "lblPhone";
            // 
            // lblGmail
            // 
            this.lblGmail.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblGmail, 3);
            this.lblGmail.Location = new System.Drawing.Point(345, 37);
            this.lblGmail.Name = "lblGmail";
            this.panelChung.SetRow(this.lblGmail, 2);
            this.lblGmail.Size = new System.Drawing.Size(114, 19);
            this.lblGmail.TabIndex = 1;
            this.lblGmail.Text = "lblGmail";
            // 
            // lblTo
            // 
            this.lblTo.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTo.Appearance.Options.UseFont = true;
            this.lblTo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblTo, 5);
            this.lblTo.Location = new System.Drawing.Point(624, 37);
            this.lblTo.Name = "lblTo";
            this.panelChung.SetRow(this.lblTo, 2);
            this.lblTo.Size = new System.Drawing.Size(114, 19);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "lblTo";
            // 
            // txtPhone
            // 
            this.panelChung.SetColumn(this.txtPhone, 2);
            this.txtPhone.EnterMoveNextControl = true;
            this.txtPhone.Location = new System.Drawing.Point(186, 37);
            this.txtPhone.Name = "txtPhone";
            this.panelChung.SetRow(this.txtPhone, 2);
            this.txtPhone.Size = new System.Drawing.Size(153, 20);
            this.txtPhone.TabIndex = 0;
            // 
            // txtGmail
            // 
            this.panelChung.SetColumn(this.txtGmail, 4);
            this.txtGmail.EnterMoveNextControl = true;
            this.txtGmail.Location = new System.Drawing.Point(465, 37);
            this.txtGmail.Name = "txtGmail";
            this.panelChung.SetRow(this.txtGmail, 2);
            this.txtGmail.Size = new System.Drawing.Size(153, 20);
            this.txtGmail.TabIndex = 0;
            // 
            // txtNote
            // 
            this.panelChung.SetColumn(this.txtNote, 2);
            this.panelChung.SetColumnSpan(this.txtNote, 5);
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNote.Location = new System.Drawing.Point(186, 89);
            this.txtNote.Name = "txtNote";
            this.txtNote.Properties.MaxLength = 500;
            this.panelChung.SetRow(this.txtNote, 4);
            this.txtNote.Size = new System.Drawing.Size(711, 46);
            this.txtNote.TabIndex = 3;
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblChucVu, 1);
            this.lblChucVu.Location = new System.Drawing.Point(66, 63);
            this.lblChucVu.Name = "lblChucVu";
            this.panelChung.SetRow(this.lblChucVu, 3);
            this.lblChucVu.Size = new System.Drawing.Size(114, 19);
            this.lblChucVu.TabIndex = 1;
            this.lblChucVu.Text = "lblChucVu";
            // 
            // lblNghiViec
            // 
            this.lblNghiViec.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblNghiViec, 5);
            this.lblNghiViec.Location = new System.Drawing.Point(624, 63);
            this.lblNghiViec.Name = "lblNghiViec";
            this.panelChung.SetRow(this.lblNghiViec, 3);
            this.lblNghiViec.Size = new System.Drawing.Size(114, 19);
            this.lblNghiViec.TabIndex = 1;
            this.lblNghiViec.Text = "lblNghiViec";
            // 
            // frmOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 474);
            this.Controls.Add(this.panelChung);
            this.Name = "frmOperator";
            this.Text = "frmOperator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmItemGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkNghiViec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChucVu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.SearchControl txtSearch;
        private DevExpress.XtraGrid.GridControl grdOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView grvOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.TextEdit txtOperatorName;
        private DevExpress.XtraEditors.LabelControl lblOperatorName;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraEditors.LabelControl lblOperatorCode;
        private DevExpress.XtraEditors.LabelControl lblCardID;
        private DevExpress.XtraEditors.TextEdit txtOperatorCode;
        private DevExpress.XtraEditors.TextEdit txtCardID;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.LabelControl lblPhone;
        private DevExpress.XtraEditors.LabelControl lblGmail;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LookUpEdit cboTo;
        private DevExpress.XtraEditors.TextEdit txtGmail;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.CheckEdit chkNghiViec;
        private DevExpress.XtraEditors.TextEdit txtChucVu;
        private DevExpress.XtraEditors.LabelControl lblChucVu;
        private DevExpress.XtraEditors.LabelControl lblNghiViec;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}
