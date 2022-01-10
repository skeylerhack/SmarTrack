namespace VS.OEE
{
    partial class frmHistoryProRun
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
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panelNN = new DevExpress.XtraEditors.PanelControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.grdHistoryRun = new DevExpress.XtraGrid.GridControl();
            this.grvHistoryRun = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.rdoDK = new DevExpress.XtraEditors.RadioGroup();
            this.datTNgay = new DevExpress.XtraEditors.DateEdit();
            this.cboUser = new DevExpress.XtraEditors.LookUpEdit();
            this.lblUser = new DevExpress.XtraEditors.LabelControl();
            this.lblTuNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblDenNgay = new DevExpress.XtraEditors.LabelControl();
            this.datDNgay = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistoryRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHistoryRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 10F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F)});
            this.tablePanel1.Controls.Add(this.panelNN);
            this.tablePanel1.Controls.Add(this.grdHistoryRun);
            this.tablePanel1.Controls.Add(this.rdoDK);
            this.tablePanel1.Controls.Add(this.datTNgay);
            this.tablePanel1.Controls.Add(this.cboUser);
            this.tablePanel1.Controls.Add(this.lblUser);
            this.tablePanel1.Controls.Add(this.lblTuNgay);
            this.tablePanel1.Controls.Add(this.lblDenNgay);
            this.tablePanel1.Controls.Add(this.datDNgay);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.tablePanel1.Size = new System.Drawing.Size(894, 568);
            this.tablePanel1.TabIndex = 0;
            // 
            // panelNN
            // 
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelNN, 0);
            this.tablePanel1.SetColumnSpan(this.panelNN, 8);
            this.panelNN.Controls.Add(this.searchControl1);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNN.Location = new System.Drawing.Point(3, 536);
            this.panelNN.Name = "panelNN";
            this.tablePanel1.SetRow(this.panelNN, 5);
            this.panelNN.Size = new System.Drawing.Size(888, 29);
            this.panelNN.TabIndex = 8;
            // 
            // searchControl1
            // 
            this.searchControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchControl1.Client = this.grdHistoryRun;
            this.searchControl1.Location = new System.Drawing.Point(0, 7);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.grdHistoryRun;
            this.searchControl1.Size = new System.Drawing.Size(200, 20);
            this.searchControl1.TabIndex = 13;
            // 
            // grdHistoryRun
            // 
            this.tablePanel1.SetColumn(this.grdHistoryRun, 0);
            this.tablePanel1.SetColumnSpan(this.grdHistoryRun, 8);
            this.grdHistoryRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHistoryRun.Location = new System.Drawing.Point(3, 71);
            this.grdHistoryRun.MainView = this.grvHistoryRun;
            this.grdHistoryRun.Name = "grdHistoryRun";
            this.tablePanel1.SetRow(this.grdHistoryRun, 4);
            this.grdHistoryRun.Size = new System.Drawing.Size(888, 459);
            this.grdHistoryRun.TabIndex = 4;
            this.grdHistoryRun.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHistoryRun});
            // 
            // grvHistoryRun
            // 
            this.grvHistoryRun.GridControl = this.grdHistoryRun;
            this.grvHistoryRun.Name = "grvHistoryRun";
            this.grvHistoryRun.OptionsView.ShowGroupPanel = false;
            this.grvHistoryRun.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvHistoryRun_RowCellStyle);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(807, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // rdoDK
            // 
            this.tablePanel1.SetColumn(this.rdoDK, 2);
            this.tablePanel1.SetColumnSpan(this.rdoDK, 4);
            this.rdoDK.Location = new System.Drawing.Point(133, 11);
            this.rdoDK.Name = "rdoDK";
            this.rdoDK.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdoDK.Properties.Appearance.Options.UseBackColor = true;
            this.rdoDK.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rdoDK.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("rdoTheoPro", "rdoTheoPro", true, "rdoTheoPro", "rdoTheoPro"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("rdoTheoDK", "rdoTheoDK", true, "rdoTheoDK", "rdoTheoDK")});
            this.tablePanel1.SetRow(this.rdoDK, 1);
            this.rdoDK.Size = new System.Drawing.Size(562, 20);
            this.rdoDK.TabIndex = 3;
            this.rdoDK.SelectedIndexChanged += new System.EventHandler(this.rdoDK_SelectedIndexChanged);
            // 
            // datTNgay
            // 
            this.tablePanel1.SetColumn(this.datTNgay, 4);
            this.datTNgay.EditValue = null;
            this.datTNgay.Location = new System.Drawing.Point(417, 37);
            this.datTNgay.Name = "datTNgay";
            this.datTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.datTNgay, 2);
            this.datTNgay.Size = new System.Drawing.Size(158, 20);
            this.datTNgay.TabIndex = 2;
            this.datTNgay.EditValueChanged += new System.EventHandler(this.cboUser_EditValueChanged);
            // 
            // cboUser
            // 
            this.tablePanel1.SetColumn(this.cboUser, 2);
            this.cboUser.Location = new System.Drawing.Point(133, 37);
            this.cboUser.Name = "cboUser";
            this.cboUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUser.Properties.NullText = "";
            this.tablePanel1.SetRow(this.cboUser, 2);
            this.cboUser.Size = new System.Drawing.Size(158, 20);
            this.cboUser.TabIndex = 1;
            this.cboUser.EditValueChanged += new System.EventHandler(this.cboUser_EditValueChanged);
            // 
            // lblUser
            // 
            this.tablePanel1.SetColumn(this.lblUser, 1);
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Location = new System.Drawing.Point(13, 37);
            this.lblUser.Name = "lblUser";
            this.tablePanel1.SetRow(this.lblUser, 2);
            this.lblUser.Size = new System.Drawing.Size(114, 20);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "lblUser";
            // 
            // lblTuNgay
            // 
            this.tablePanel1.SetColumn(this.lblTuNgay, 3);
            this.lblTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTuNgay.Location = new System.Drawing.Point(297, 37);
            this.lblTuNgay.Name = "lblTuNgay";
            this.tablePanel1.SetRow(this.lblTuNgay, 2);
            this.lblTuNgay.Size = new System.Drawing.Size(114, 20);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "lblTuNgay";
            // 
            // lblDenNgay
            // 
            this.tablePanel1.SetColumn(this.lblDenNgay, 5);
            this.lblDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDenNgay.Location = new System.Drawing.Point(581, 37);
            this.lblDenNgay.Name = "lblDenNgay";
            this.tablePanel1.SetRow(this.lblDenNgay, 2);
            this.lblDenNgay.Size = new System.Drawing.Size(114, 20);
            this.lblDenNgay.TabIndex = 0;
            this.lblDenNgay.Text = "lblDenNgay";
            // 
            // datDNgay
            // 
            this.tablePanel1.SetColumn(this.datDNgay, 6);
            this.datDNgay.EditValue = null;
            this.datDNgay.Location = new System.Drawing.Point(701, 37);
            this.datDNgay.Name = "datDNgay";
            this.datDNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.datDNgay, 2);
            this.datDNgay.Size = new System.Drawing.Size(158, 20);
            this.datDNgay.TabIndex = 2;
            this.datDNgay.EditValueChanged += new System.EventHandler(this.cboUser_EditValueChanged);
            // 
            // frmHistoryProRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 568);
            this.Controls.Add(this.tablePanel1);
            this.Name = "frmHistoryProRun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHistoryProRun";
            this.Load += new System.EventHandler(this.frmHistoryProRun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistoryRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHistoryRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.RadioGroup rdoDK;
        private DevExpress.XtraEditors.DateEdit datTNgay;
        private DevExpress.XtraEditors.LookUpEdit cboUser;
        private DevExpress.XtraEditors.LabelControl lblUser;
        private DevExpress.XtraEditors.LabelControl lblTuNgay;
        private DevExpress.XtraEditors.LabelControl lblDenNgay;
        private DevExpress.XtraEditors.DateEdit datDNgay;
        private DevExpress.XtraGrid.GridControl grdHistoryRun;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHistoryRun;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SearchControl searchControl1;
    }
}