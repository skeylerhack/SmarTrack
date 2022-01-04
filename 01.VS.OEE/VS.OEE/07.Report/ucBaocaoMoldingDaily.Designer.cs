namespace VS.OEE
{
    partial class ucBaocaoMoldingDaily
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
            this.lblShiftLeader = new DevExpress.XtraEditors.LabelControl();
            this.lblID_CA = new DevExpress.XtraEditors.LabelControl();
            this.panelNN = new DevExpress.XtraEditors.PanelControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.lblTNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblDNgay = new DevExpress.XtraEditors.LabelControl();
            this.datTNgay = new DevExpress.XtraEditors.DateEdit();
            this.datDNgay = new DevExpress.XtraEditors.DateEdit();
            this.cboID_CA = new DevExpress.XtraEditors.LookUpEdit();
            this.cboShiftLeader = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.grdBCMoldDaily = new DevExpress.XtraGrid.GridControl();
            this.grvBCMoldDaily = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ccbMS_MAY = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lblMS_MAY = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_CA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShiftLeader.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBCMoldDaily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBCMoldDaily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbMS_MAY.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblShiftLeader
            // 
            this.lblShiftLeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblShiftLeader, 3);
            this.lblShiftLeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShiftLeader.Location = new System.Drawing.Point(373, 38);
            this.lblShiftLeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblShiftLeader.Name = "lblShiftLeader";
            this.panelChung.SetRow(this.lblShiftLeader, 2);
            this.lblShiftLeader.Size = new System.Drawing.Size(114, 18);
            this.lblShiftLeader.TabIndex = 1;
            this.lblShiftLeader.Text = "lblShiftLeader";
            // 
            // lblID_CA
            // 
            this.lblID_CA.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblID_CA, 1);
            this.lblID_CA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblID_CA.Location = new System.Drawing.Point(128, 38);
            this.lblID_CA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblID_CA.Name = "lblID_CA";
            this.panelChung.SetRow(this.lblID_CA, 2);
            this.lblID_CA.Size = new System.Drawing.Size(114, 18);
            this.lblID_CA.TabIndex = 1;
            this.lblID_CA.Text = "lblID_CA";
            // 
            // panelNN
            // 
            this.panelNN.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelNN.Appearance.Options.UseBackColor = true;
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelChung.SetColumn(this.panelNN, 0);
            this.panelChung.SetColumnSpan(this.panelNN, 8);
            this.panelNN.Controls.Add(this.btnIn);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNN.Location = new System.Drawing.Point(3, 485);
            this.panelNN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelNN.Name = "panelNN";
            this.panelChung.SetRow(this.panelNN, 5);
            this.panelNN.Size = new System.Drawing.Size(980, 27);
            this.panelNN.TabIndex = 6;
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Location = new System.Drawing.Point(817, 0);
            this.btnIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(80, 26);
            this.btnIn.TabIndex = 5;
            this.btnIn.Text = "btnIn";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(898, 0);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblTNgay
            // 
            this.panelChung.SetColumn(this.lblTNgay, 1);
            this.lblTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTNgay.Location = new System.Drawing.Point(128, 11);
            this.lblTNgay.Name = "lblTNgay";
            this.panelChung.SetRow(this.lblTNgay, 1);
            this.lblTNgay.Size = new System.Drawing.Size(114, 20);
            this.lblTNgay.TabIndex = 16;
            this.lblTNgay.Text = "lblTNgay";
            // 
            // lblDNgay
            // 
            this.panelChung.SetColumn(this.lblDNgay, 3);
            this.lblDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDNgay.Location = new System.Drawing.Point(373, 11);
            this.lblDNgay.Name = "lblDNgay";
            this.panelChung.SetRow(this.lblDNgay, 1);
            this.lblDNgay.Size = new System.Drawing.Size(114, 20);
            this.lblDNgay.TabIndex = 17;
            this.lblDNgay.Text = "lblDNgay";
            // 
            // datTNgay
            // 
            this.panelChung.SetColumn(this.datTNgay, 2);
            this.datTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datTNgay.EditValue = null;
            this.datTNgay.Location = new System.Drawing.Point(248, 11);
            this.datTNgay.Name = "datTNgay";
            this.datTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.panelChung.SetRow(this.datTNgay, 1);
            this.datTNgay.Size = new System.Drawing.Size(119, 20);
            this.datTNgay.TabIndex = 18;
            this.datTNgay.EditValueChanged += new System.EventHandler(this.datTNgay_EditValueChanged);
            // 
            // datDNgay
            // 
            this.panelChung.SetColumn(this.datDNgay, 4);
            this.datDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datDNgay.EditValue = null;
            this.datDNgay.Location = new System.Drawing.Point(493, 11);
            this.datDNgay.Name = "datDNgay";
            this.datDNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.panelChung.SetRow(this.datDNgay, 1);
            this.datDNgay.Size = new System.Drawing.Size(119, 20);
            this.datDNgay.TabIndex = 19;
            this.datDNgay.EditValueChanged += new System.EventHandler(this.datDNgay_EditValueChanged);
            // 
            // cboID_CA
            // 
            this.panelChung.SetColumn(this.cboID_CA, 2);
            this.cboID_CA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboID_CA.Location = new System.Drawing.Point(248, 37);
            this.cboID_CA.Name = "cboID_CA";
            this.cboID_CA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_CA.Properties.NullText = "";
            this.panelChung.SetRow(this.cboID_CA, 2);
            this.cboID_CA.Size = new System.Drawing.Size(119, 20);
            this.cboID_CA.TabIndex = 20;
            this.cboID_CA.EditValueChanged += new System.EventHandler(this.cboID_CA_EditValueChanged);
            // 
            // cboShiftLeader
            // 
            this.panelChung.SetColumn(this.cboShiftLeader, 4);
            this.cboShiftLeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboShiftLeader.EditValue = "";
            this.cboShiftLeader.Location = new System.Drawing.Point(493, 37);
            this.cboShiftLeader.Name = "cboShiftLeader";
            this.cboShiftLeader.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboShiftLeader.Properties.NullText = "";
            this.cboShiftLeader.Properties.PopupView = this.searchLookUpEdit1View;
            this.panelChung.SetRow(this.cboShiftLeader, 2);
            this.cboShiftLeader.Size = new System.Drawing.Size(119, 20);
            this.cboShiftLeader.TabIndex = 21;
            this.cboShiftLeader.EditValueChanged += new System.EventHandler(this.cboShiftLeader_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // panelChung
            // 
            this.panelChung.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.panelChung.Controls.Add(this.grdBCMoldDaily);
            this.panelChung.Controls.Add(this.ccbMS_MAY);
            this.panelChung.Controls.Add(this.lblMS_MAY);
            this.panelChung.Controls.Add(this.cboShiftLeader);
            this.panelChung.Controls.Add(this.cboID_CA);
            this.panelChung.Controls.Add(this.datDNgay);
            this.panelChung.Controls.Add(this.datTNgay);
            this.panelChung.Controls.Add(this.lblDNgay);
            this.panelChung.Controls.Add(this.lblTNgay);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.lblID_CA);
            this.panelChung.Controls.Add(this.lblShiftLeader);
            this.panelChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChung.Location = new System.Drawing.Point(0, 0);
            this.panelChung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelChung.Name = "panelChung";
            this.panelChung.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 70F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.panelChung.Size = new System.Drawing.Size(986, 516);
            this.panelChung.TabIndex = 2;
            // 
            // grdBCMoldDaily
            // 
            this.panelChung.SetColumn(this.grdBCMoldDaily, 0);
            this.panelChung.SetColumnSpan(this.grdBCMoldDaily, 8);
            this.grdBCMoldDaily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBCMoldDaily.Location = new System.Drawing.Point(3, 71);
            this.grdBCMoldDaily.MainView = this.grvBCMoldDaily;
            this.grdBCMoldDaily.Name = "grdBCMoldDaily";
            this.panelChung.SetRow(this.grdBCMoldDaily, 4);
            this.grdBCMoldDaily.Size = new System.Drawing.Size(980, 407);
            this.grdBCMoldDaily.TabIndex = 24;
            this.grdBCMoldDaily.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBCMoldDaily});
            // 
            // grvBCMoldDaily
            // 
            this.grvBCMoldDaily.GridControl = this.grdBCMoldDaily;
            this.grvBCMoldDaily.Name = "grvBCMoldDaily";
            this.grvBCMoldDaily.OptionsView.ShowGroupPanel = false;
            // 
            // ccbMS_MAY
            // 
            this.panelChung.SetColumn(this.ccbMS_MAY, 6);
            this.ccbMS_MAY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccbMS_MAY.Location = new System.Drawing.Point(739, 37);
            this.ccbMS_MAY.Name = "ccbMS_MAY";
            this.ccbMS_MAY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.panelChung.SetRow(this.ccbMS_MAY, 2);
            this.ccbMS_MAY.Size = new System.Drawing.Size(119, 20);
            this.ccbMS_MAY.TabIndex = 23;
            this.ccbMS_MAY.EditValueChanged += new System.EventHandler(this.ccbMS_MAY_EditValueChanged);
            // 
            // lblMS_MAY
            // 
            this.panelChung.SetColumn(this.lblMS_MAY, 5);
            this.lblMS_MAY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMS_MAY.Location = new System.Drawing.Point(619, 37);
            this.lblMS_MAY.Name = "lblMS_MAY";
            this.panelChung.SetRow(this.lblMS_MAY, 2);
            this.lblMS_MAY.Size = new System.Drawing.Size(114, 20);
            this.lblMS_MAY.TabIndex = 22;
            this.lblMS_MAY.Text = "lblMS_MAY";
            // 
            // ucBaocaoMoldingDaily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelChung);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucBaocaoMoldingDaily";
            this.Size = new System.Drawing.Size(986, 516);
            this.Load += new System.EventHandler(this.ucBaocaoMoldingDaily_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_CA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShiftLeader.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            this.panelChung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBCMoldDaily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBCMoldDaily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbMS_MAY.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblShiftLeader;
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.SearchLookUpEdit cboShiftLeader;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LookUpEdit cboID_CA;
        private DevExpress.XtraEditors.DateEdit datDNgay;
        private DevExpress.XtraEditors.DateEdit datTNgay;
        private DevExpress.XtraEditors.LabelControl lblDNgay;
        private DevExpress.XtraEditors.LabelControl lblTNgay;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.LabelControl lblID_CA;
        private DevExpress.XtraGrid.GridControl grdBCMoldDaily;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBCMoldDaily;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ccbMS_MAY;
        private DevExpress.XtraEditors.LabelControl lblMS_MAY;
    }
}
