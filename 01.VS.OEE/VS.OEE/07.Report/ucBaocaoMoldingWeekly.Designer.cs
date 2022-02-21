namespace VS.OEE
{
    partial class ucBaocaoMoldingWeekly
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
            this.lblTuan = new DevExpress.XtraEditors.LabelControl();
            this.cboID_CA = new DevExpress.XtraEditors.LookUpEdit();
            this.cboShiftLeader = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.datNam = new DevExpress.XtraEditors.DateEdit();
            this.lblNam = new DevExpress.XtraEditors.LabelControl();
            this.cboTuan = new DevExpress.XtraEditors.LookUpEdit();
            this.grdBCMoldWeekly = new DevExpress.XtraGrid.GridControl();
            this.grvBCMoldWeekly = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ccbMS_MAY = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.lblMS_MAY = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_CA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShiftLeader.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTuan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBCMoldWeekly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBCMoldWeekly)).BeginInit();
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
            // lblTuan
            // 
            this.panelChung.SetColumn(this.lblTuan, 3);
            this.lblTuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTuan.Location = new System.Drawing.Point(373, 11);
            this.lblTuan.Name = "lblTuan";
            this.panelChung.SetRow(this.lblTuan, 1);
            this.lblTuan.Size = new System.Drawing.Size(114, 20);
            this.lblTuan.TabIndex = 16;
            this.lblTuan.Text = "lblTuan";
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
            this.panelChung.Controls.Add(this.datNam);
            this.panelChung.Controls.Add(this.lblNam);
            this.panelChung.Controls.Add(this.cboTuan);
            this.panelChung.Controls.Add(this.grdBCMoldWeekly);
            this.panelChung.Controls.Add(this.ccbMS_MAY);
            this.panelChung.Controls.Add(this.lblMS_MAY);
            this.panelChung.Controls.Add(this.cboShiftLeader);
            this.panelChung.Controls.Add(this.cboID_CA);
            this.panelChung.Controls.Add(this.lblTuan);
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
            // datNam
            // 
            this.panelChung.SetColumn(this.datNam, 2);
            this.datNam.EditValue = null;
            this.datNam.Location = new System.Drawing.Point(248, 11);
            this.datNam.Name = "datNam";
            this.datNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datNam.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datNam.Properties.DisplayFormat.FormatString = "yyyy";
            this.datNam.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datNam.Properties.EditFormat.FormatString = "yyyy";
            this.datNam.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datNam.Properties.Mask.EditMask = "yyyy";
            this.datNam.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.datNam.Properties.ShowWeekNumbers = true;
            this.datNam.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView;
            this.datNam.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            this.panelChung.SetRow(this.datNam, 1);
            this.datNam.Size = new System.Drawing.Size(119, 20);
            this.datNam.TabIndex = 28;
            this.datNam.EditValueChanged += new System.EventHandler(this.datNam_EditValueChanged);
            // 
            // lblNam
            // 
            this.panelChung.SetColumn(this.lblNam, 1);
            this.lblNam.Location = new System.Drawing.Point(128, 14);
            this.lblNam.Name = "lblNam";
            this.panelChung.SetRow(this.lblNam, 1);
            this.lblNam.Size = new System.Drawing.Size(36, 13);
            this.lblNam.TabIndex = 26;
            this.lblNam.Text = "lblNam";
            // 
            // cboTuan
            // 
            this.panelChung.SetColumn(this.cboTuan, 4);
            this.panelChung.SetColumnSpan(this.cboTuan, 3);
            this.cboTuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTuan.Location = new System.Drawing.Point(493, 11);
            this.cboTuan.Name = "cboTuan";
            this.cboTuan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTuan.Properties.NullText = "";
            this.panelChung.SetRow(this.cboTuan, 1);
            this.cboTuan.Size = new System.Drawing.Size(365, 20);
            this.cboTuan.TabIndex = 25;
            this.cboTuan.EditValueChanged += new System.EventHandler(this.cboTuan_EditValueChanged);
            // 
            // grdBCMoldWeekly
            // 
            this.panelChung.SetColumn(this.grdBCMoldWeekly, 0);
            this.panelChung.SetColumnSpan(this.grdBCMoldWeekly, 8);
            this.grdBCMoldWeekly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBCMoldWeekly.Location = new System.Drawing.Point(3, 71);
            this.grdBCMoldWeekly.MainView = this.grvBCMoldWeekly;
            this.grdBCMoldWeekly.Name = "grdBCMoldWeekly";
            this.panelChung.SetRow(this.grdBCMoldWeekly, 4);
            this.grdBCMoldWeekly.Size = new System.Drawing.Size(980, 407);
            this.grdBCMoldWeekly.TabIndex = 24;
            this.grdBCMoldWeekly.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBCMoldWeekly});
            // 
            // grvBCMoldWeekly
            // 
            this.grvBCMoldWeekly.GridControl = this.grdBCMoldWeekly;
            this.grvBCMoldWeekly.Name = "grvBCMoldWeekly";
            this.grvBCMoldWeekly.OptionsView.ShowGroupPanel = false;
            this.grvBCMoldWeekly.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvBCMoldWeekly_ShowingEditor);
            this.grvBCMoldWeekly.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvBCMoldWeekly_CellValueChanged);
            // 
            // ccbMS_MAY
            // 
            this.panelChung.SetColumn(this.ccbMS_MAY, 6);
            this.ccbMS_MAY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccbMS_MAY.Location = new System.Drawing.Point(739, 37);
            this.ccbMS_MAY.Name = "ccbMS_MAY";
            this.ccbMS_MAY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ccbMS_MAY.Properties.SelectAllItemVisible = false;
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
            // ucBaocaoMoldingWeekly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelChung);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucBaocaoMoldingWeekly";
            this.Size = new System.Drawing.Size(986, 516);
            this.Load += new System.EventHandler(this.ucBaocaoMoldingWeekly_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboID_CA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShiftLeader.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            this.panelChung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTuan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBCMoldWeekly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBCMoldWeekly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbMS_MAY.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblShiftLeader;
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.SearchLookUpEdit cboShiftLeader;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LookUpEdit cboID_CA;
        private DevExpress.XtraEditors.LabelControl lblTuan;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.LabelControl lblID_CA;
        private DevExpress.XtraGrid.GridControl grdBCMoldWeekly;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBCMoldWeekly;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ccbMS_MAY;
        private DevExpress.XtraEditors.LabelControl lblMS_MAY;
        private DevExpress.XtraEditors.LookUpEdit cboTuan;
        private DevExpress.XtraEditors.DateEdit datNam;
        private DevExpress.XtraEditors.LabelControl lblNam;
    }
}
