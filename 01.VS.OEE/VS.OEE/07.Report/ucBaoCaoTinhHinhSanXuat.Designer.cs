namespace VS.OEE
{
    partial class ucBaoCaoTinhHinhSanXuat
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
            this.panelNN = new DevExpress.XtraEditors.PanelControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.grdTinhHinhSanXuat = new DevExpress.XtraGrid.GridControl();
            this.grvTinhHinhSanXuat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rdoDK = new DevExpress.XtraEditors.RadioGroup();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.cboTo = new DevExpress.XtraEditors.LookUpEdit();
            this.datTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblTuNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblDenNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.lblMay = new DevExpress.XtraEditors.LabelControl();
            this.datDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.cboMay = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTinhHinhSanXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTinhHinhSanXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNN
            // 
            this.panelNN.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelNN.Appearance.Options.UseBackColor = true;
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelChung.SetColumn(this.panelNN, 3);
            this.panelChung.SetColumnSpan(this.panelNN, 6);
            this.panelNN.Controls.Add(this.btnIn);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNN.Location = new System.Drawing.Point(389, 442);
            this.panelNN.Name = "panelNN";
            this.panelChung.SetRow(this.panelNN, 5);
            this.panelNN.Size = new System.Drawing.Size(571, 29);
            this.panelNN.TabIndex = 6;
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Location = new System.Drawing.Point(409, 2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(80, 26);
            this.btnIn.TabIndex = 5;
            this.btnIn.Text = "btnIn";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(490, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // grdTinhHinhSanXuat
            // 
            this.panelChung.SetColumn(this.grdTinhHinhSanXuat, 0);
            this.panelChung.SetColumnSpan(this.grdTinhHinhSanXuat, 7);
            this.grdTinhHinhSanXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTinhHinhSanXuat.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdTinhHinhSanXuat.Location = new System.Drawing.Point(2, 70);
            this.grdTinhHinhSanXuat.MainView = this.grvTinhHinhSanXuat;
            this.grdTinhHinhSanXuat.Margin = new System.Windows.Forms.Padding(2);
            this.grdTinhHinhSanXuat.Name = "grdTinhHinhSanXuat";
            this.panelChung.SetRow(this.grdTinhHinhSanXuat, 4);
            this.grdTinhHinhSanXuat.Size = new System.Drawing.Size(959, 367);
            this.grdTinhHinhSanXuat.TabIndex = 7;
            this.grdTinhHinhSanXuat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTinhHinhSanXuat});
            // 
            // grvTinhHinhSanXuat
            // 
            this.grvTinhHinhSanXuat.ColumnPanelRowHeight = 1;
            this.grvTinhHinhSanXuat.DetailHeight = 227;
            this.grvTinhHinhSanXuat.FixedLineWidth = 1;
            this.grvTinhHinhSanXuat.GridControl = this.grdTinhHinhSanXuat;
            this.grvTinhHinhSanXuat.Name = "grvTinhHinhSanXuat";
            this.grvTinhHinhSanXuat.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvTinhHinhSanXuat.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvTinhHinhSanXuat.OptionsCustomization.AllowRowSizing = true;
            this.grvTinhHinhSanXuat.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel;
            this.grvTinhHinhSanXuat.OptionsFind.FindDelay = 100;
            this.grvTinhHinhSanXuat.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvTinhHinhSanXuat.OptionsPrint.AllowMultilineHeaders = true;
            this.grvTinhHinhSanXuat.OptionsScrollAnnotations.ShowCustomAnnotations = DevExpress.Utils.DefaultBoolean.True;
            this.grvTinhHinhSanXuat.OptionsScrollAnnotations.ShowErrors = DevExpress.Utils.DefaultBoolean.True;
            this.grvTinhHinhSanXuat.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvTinhHinhSanXuat.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvTinhHinhSanXuat.OptionsView.RowAutoHeight = true;
            this.grvTinhHinhSanXuat.RowHeight = 1;
            // 
            // rdoDK
            // 
            this.panelChung.SetColumn(this.rdoDK, 1);
            this.rdoDK.EditValue = "rdoBaoCaoGop";
            this.rdoDK.Location = new System.Drawing.Point(79, 9);
            this.rdoDK.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.rdoDK.Name = "rdoDK";
            this.rdoDK.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("rdoBaoCaoGop", "rdoBaoCaoGop", true, "rdoBaoCaoGop", "rdoBaoCaoGop"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("rdoBaoCaoGopChiTiet", "rdoBaoCaoGopChiTiet", true, "rdoBaoCaoGopChiTiet", "rdoBaoCaoGopChiTiet")});
            this.rdoDK.Properties.Padding = new System.Windows.Forms.Padding(4, 2, 4, 4);
            this.panelChung.SetRow(this.rdoDK, 1);
            this.panelChung.SetRowSpan(this.rdoDK, 2);
            this.rdoDK.Size = new System.Drawing.Size(184, 48);
            this.rdoDK.TabIndex = 8;
            this.rdoDK.SelectedIndexChanged += new System.EventHandler(this.rdoDK_SelectedIndexChanged);
            // 
            // panelChung
            // 
            this.panelChung.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F)});
            this.panelChung.Controls.Add(this.cboTo);
            this.panelChung.Controls.Add(this.datTuNgay);
            this.panelChung.Controls.Add(this.rdoDK);
            this.panelChung.Controls.Add(this.grdTinhHinhSanXuat);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.lblTuNgay);
            this.panelChung.Controls.Add(this.lblDenNgay);
            this.panelChung.Controls.Add(this.lblTo);
            this.panelChung.Controls.Add(this.lblMay);
            this.panelChung.Controls.Add(this.datDenNgay);
            this.panelChung.Controls.Add(this.cboMay);
            this.panelChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChung.Location = new System.Drawing.Point(0, 0);
            this.panelChung.Name = "panelChung";
            this.panelChung.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.panelChung.Size = new System.Drawing.Size(963, 474);
            this.panelChung.TabIndex = 2;
            // 
            // cboTo
            // 
            this.panelChung.SetColumn(this.cboTo, 3);
            this.cboTo.Location = new System.Drawing.Point(389, 37);
            this.cboTo.Name = "cboTo";
            this.cboTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTo.Properties.NullText = "";
            this.panelChung.SetRow(this.cboTo, 2);
            this.cboTo.Size = new System.Drawing.Size(184, 20);
            this.cboTo.TabIndex = 10;
            this.cboTo.EditValueChanged += new System.EventHandler(this.datTuNgay_EditValueChanged);
            // 
            // datTuNgay
            // 
            this.panelChung.SetColumn(this.datTuNgay, 3);
            this.datTuNgay.EditValue = null;
            this.datTuNgay.Location = new System.Drawing.Point(389, 11);
            this.datTuNgay.Name = "datTuNgay";
            this.datTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.panelChung.SetRow(this.datTuNgay, 1);
            this.datTuNgay.Size = new System.Drawing.Size(184, 20);
            this.datTuNgay.TabIndex = 9;
            this.datTuNgay.EditValueChanged += new System.EventHandler(this.datTuNgay_EditValueChanged);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblTuNgay, 2);
            this.lblTuNgay.Location = new System.Drawing.Point(269, 11);
            this.lblTuNgay.Name = "lblTuNgay";
            this.panelChung.SetRow(this.lblTuNgay, 1);
            this.lblTuNgay.Size = new System.Drawing.Size(114, 19);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "lblTuNgay";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblDenNgay, 4);
            this.lblDenNgay.Location = new System.Drawing.Point(580, 11);
            this.lblDenNgay.Name = "lblDenNgay";
            this.panelChung.SetRow(this.lblDenNgay, 1);
            this.lblDenNgay.Size = new System.Drawing.Size(114, 19);
            this.lblDenNgay.TabIndex = 1;
            this.lblDenNgay.Text = "lblDenNgay";
            // 
            // lblTo
            // 
            this.lblTo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblTo, 2);
            this.lblTo.Location = new System.Drawing.Point(269, 37);
            this.lblTo.Name = "lblTo";
            this.panelChung.SetRow(this.lblTo, 2);
            this.lblTo.Size = new System.Drawing.Size(114, 19);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "lblTo";
            // 
            // lblMay
            // 
            this.lblMay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblMay, 4);
            this.lblMay.Location = new System.Drawing.Point(580, 37);
            this.lblMay.Name = "lblMay";
            this.panelChung.SetRow(this.lblMay, 2);
            this.lblMay.Size = new System.Drawing.Size(114, 19);
            this.lblMay.TabIndex = 1;
            this.lblMay.Text = "lblMay";
            // 
            // datDenNgay
            // 
            this.panelChung.SetColumn(this.datDenNgay, 5);
            this.datDenNgay.EditValue = null;
            this.datDenNgay.Location = new System.Drawing.Point(700, 11);
            this.datDenNgay.Name = "datDenNgay";
            this.datDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.panelChung.SetRow(this.datDenNgay, 1);
            this.datDenNgay.Size = new System.Drawing.Size(184, 20);
            this.datDenNgay.TabIndex = 9;
            this.datDenNgay.EditValueChanged += new System.EventHandler(this.datTuNgay_EditValueChanged);
            // 
            // cboMay
            // 
            this.panelChung.SetColumn(this.cboMay, 5);
            this.cboMay.Location = new System.Drawing.Point(700, 37);
            this.cboMay.Name = "cboMay";
            this.cboMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMay.Properties.NullText = "";
            this.panelChung.SetRow(this.cboMay, 2);
            this.cboMay.Size = new System.Drawing.Size(184, 20);
            this.cboMay.TabIndex = 10;
            this.cboMay.EditValueChanged += new System.EventHandler(this.datTuNgay_EditValueChanged);
            // 
            // ucBaoCaoTinhHinhSanXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelChung);
            this.Name = "ucBaoCaoTinhHinhSanXuat";
            this.Size = new System.Drawing.Size(963, 474);
            this.Load += new System.EventHandler(this.ucBaoCaoTinhHinhSanXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTinhHinhSanXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTinhHinhSanXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.RadioGroup rdoDK;
        private DevExpress.XtraGrid.GridControl grdTinhHinhSanXuat;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTinhHinhSanXuat;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.LabelControl lblTuNgay;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.LookUpEdit cboTo;
        private DevExpress.XtraEditors.DateEdit datTuNgay;
        private DevExpress.XtraEditors.LabelControl lblDenNgay;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraEditors.LabelControl lblMay;
        private DevExpress.XtraEditors.DateEdit datDenNgay;
        private DevExpress.XtraEditors.LookUpEdit cboMay;
    }
}
