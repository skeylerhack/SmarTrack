namespace VS.OEE
{
    partial class frmChooseTGianNMay
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
            this.tablePanel = new DevExpress.Utils.Layout.TablePanel();
            this.datDGio = new DevExpress.XtraEditors.DateEdit();
            this.datTGio = new DevExpress.XtraEditors.DateEdit();
            this.lblTGio = new DevExpress.XtraEditors.LabelControl();
            this.grdTGianNMay = new DevExpress.XtraGrid.GridControl();
            this.grvTGianNMay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.lblDGio = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel)).BeginInit();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datDGio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDGio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTGio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTGio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTGianNMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTGianNMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel
            // 
            this.tablePanel.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25F)});
            this.tablePanel.Controls.Add(this.datDGio);
            this.tablePanel.Controls.Add(this.datTGio);
            this.tablePanel.Controls.Add(this.lblTGio);
            this.tablePanel.Controls.Add(this.grdTGianNMay);
            this.tablePanel.Controls.Add(this.panelControl1);
            this.tablePanel.Controls.Add(this.lblDGio);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(0, 0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 37F)});
            this.tablePanel.Size = new System.Drawing.Size(1085, 568);
            this.tablePanel.TabIndex = 0;
            // 
            // datDGio
            // 
            this.tablePanel.SetColumn(this.datDGio, 4);
            this.datDGio.EditValue = null;
            this.datDGio.Location = new System.Drawing.Point(497, 3);
            this.datDGio.Name = "datDGio";
            this.datDGio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDGio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel.SetRow(this.datDGio, 0);
            this.datDGio.Size = new System.Drawing.Size(190, 20);
            this.datDGio.TabIndex = 4;
            this.datDGio.EditValueChanged += new System.EventHandler(this.datDGio_EditValueChanged);
            // 
            // datTGio
            // 
            this.tablePanel.SetColumn(this.datTGio, 2);
            this.datTGio.EditValue = null;
            this.datTGio.Location = new System.Drawing.Point(201, 3);
            this.datTGio.Name = "datTGio";
            this.datTGio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTGio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel.SetRow(this.datTGio, 0);
            this.datTGio.Size = new System.Drawing.Size(190, 20);
            this.datTGio.TabIndex = 3;
            this.datTGio.EditValueChanged += new System.EventHandler(this.datTGio_EditValueChanged);
            // 
            // lblTGio
            // 
            this.tablePanel.SetColumn(this.lblTGio, 1);
            this.lblTGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTGio.Location = new System.Drawing.Point(101, 3);
            this.lblTGio.Name = "lblTGio";
            this.tablePanel.SetRow(this.lblTGio, 0);
            this.lblTGio.Size = new System.Drawing.Size(94, 20);
            this.lblTGio.TabIndex = 2;
            this.lblTGio.Text = "lblTGio";
            // 
            // grdTGianNMay
            // 
            this.tablePanel.SetColumn(this.grdTGianNMay, 0);
            this.tablePanel.SetColumnSpan(this.grdTGianNMay, 8);
            this.grdTGianNMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTGianNMay.Location = new System.Drawing.Point(3, 29);
            this.grdTGianNMay.MainView = this.grvTGianNMay;
            this.grdTGianNMay.Name = "grdTGianNMay";
            this.tablePanel.SetRow(this.grdTGianNMay, 1);
            this.grdTGianNMay.Size = new System.Drawing.Size(1079, 499);
            this.grdTGianNMay.TabIndex = 1;
            this.grdTGianNMay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTGianNMay});
            // 
            // grvTGianNMay
            // 
            this.grvTGianNMay.GridControl = this.grdTGianNMay;
            this.grvTGianNMay.Name = "grvTGianNMay";
            this.grvTGianNMay.OptionsView.ShowGroupPanel = false;
            this.grvTGianNMay.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTGianNMay_CellValueChanging);
            // 
            // panelControl1
            // 
            this.tablePanel.SetColumn(this.panelControl1, 0);
            this.tablePanel.SetColumnSpan(this.panelControl1, 8);
            this.panelControl1.Controls.Add(this.searchControl1);
            this.panelControl1.Controls.Add(this.btnThucHien);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Location = new System.Drawing.Point(3, 534);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel.SetRow(this.panelControl1, 2);
            this.panelControl1.Size = new System.Drawing.Size(1079, 31);
            this.panelControl1.TabIndex = 0;
            // 
            // searchControl1
            // 
            this.searchControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchControl1.Client = this.grdTGianNMay;
            this.searchControl1.Location = new System.Drawing.Point(1, 10);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.grdTGianNMay;
            this.searchControl1.Size = new System.Drawing.Size(201, 20);
            this.searchControl1.TabIndex = 11;
            // 
            // btnThucHien
            // 
            this.btnThucHien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThucHien.Location = new System.Drawing.Point(870, 1);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(104, 30);
            this.btnThucHien.TabIndex = 10;
            this.btnThucHien.Text = "btnThucHien";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(975, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblDGio
            // 
            this.tablePanel.SetColumn(this.lblDGio, 3);
            this.lblDGio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDGio.Location = new System.Drawing.Point(397, 3);
            this.lblDGio.Name = "lblDGio";
            this.tablePanel.SetRow(this.lblDGio, 0);
            this.lblDGio.Size = new System.Drawing.Size(94, 20);
            this.lblDGio.TabIndex = 2;
            this.lblDGio.Text = "lblDGio";
            // 
            // frmChooseTGianNMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 568);
            this.Controls.Add(this.tablePanel);
            this.Name = "frmChooseTGianNMay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChooseTGianNMay";
            this.Load += new System.EventHandler(this.frmChooseTGianNMay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel)).EndInit();
            this.tablePanel.ResumeLayout(false);
            this.tablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datDGio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDGio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTGio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTGio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTGianNMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTGianNMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdTGianNMay;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTGianNMay;
        private DevExpress.XtraEditors.SimpleButton btnThucHien;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.LabelControl lblTGio;
        private DevExpress.XtraEditors.LabelControl lblDGio;
        private DevExpress.XtraEditors.DateEdit datDGio;
        private DevExpress.XtraEditors.DateEdit datTGio;
    }
}