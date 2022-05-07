namespace VS.OEE
{
    partial class ucBaoCaoTieuThuDienNang
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
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.grdTongHopHieuXuat = new DevExpress.XtraGrid.GridControl();
            this.grvTongHopHieuXuat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.datTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblTuNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblDenNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblMay = new DevExpress.XtraEditors.LabelControl();
            this.datDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.cboMay = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTongHopHieuXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTongHopHieuXuat)).BeginInit();
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
            this.panelChung.SetColumn(this.panelNN, 1);
            this.panelChung.SetColumnSpan(this.panelNN, 5);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Controls.Add(this.btnIn);
            this.panelNN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNN.Location = new System.Drawing.Point(191, 677);
            this.panelNN.Name = "panelNN";
            this.panelChung.SetRow(this.panelNN, 5);
            this.panelNN.Size = new System.Drawing.Size(1049, 29);
            this.panelNN.TabIndex = 6;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(968, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Location = new System.Drawing.Point(887, 1);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(80, 26);
            this.btnIn.TabIndex = 5;
            this.btnIn.Text = "btnIn";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // panelChung
            // 
            this.panelChung.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F)});
            this.panelChung.Controls.Add(this.grdTongHopHieuXuat);
            this.panelChung.Controls.Add(this.datTuNgay);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.lblTuNgay);
            this.panelChung.Controls.Add(this.lblDenNgay);
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
            this.panelChung.Size = new System.Drawing.Size(1243, 709);
            this.panelChung.TabIndex = 2;
            // 
            // grdTongHopHieuXuat
            // 
            this.panelChung.SetColumn(this.grdTongHopHieuXuat, 0);
            this.panelChung.SetColumnSpan(this.grdTongHopHieuXuat, 6);
            this.grdTongHopHieuXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTongHopHieuXuat.Location = new System.Drawing.Point(3, 71);
            this.grdTongHopHieuXuat.MainView = this.grvTongHopHieuXuat;
            this.grdTongHopHieuXuat.Name = "grdTongHopHieuXuat";
            this.panelChung.SetRow(this.grdTongHopHieuXuat, 4);
            this.grdTongHopHieuXuat.Size = new System.Drawing.Size(1237, 600);
            this.grdTongHopHieuXuat.TabIndex = 12;
            this.grdTongHopHieuXuat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTongHopHieuXuat});
            // 
            // grvTongHopHieuXuat
            // 
            this.grvTongHopHieuXuat.GridControl = this.grdTongHopHieuXuat;
            this.grvTongHopHieuXuat.Name = "grvTongHopHieuXuat";
            this.grvTongHopHieuXuat.OptionsView.ShowGroupPanel = false;
            // 
            // datTuNgay
            // 
            this.panelChung.SetColumn(this.datTuNgay, 2);
            this.datTuNgay.EditValue = null;
            this.datTuNgay.Location = new System.Drawing.Point(311, 11);
            this.datTuNgay.Name = "datTuNgay";
            this.datTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.panelChung.SetRow(this.datTuNgay, 1);
            this.datTuNgay.Size = new System.Drawing.Size(307, 20);
            this.datTuNgay.TabIndex = 9;
            this.datTuNgay.EditValueChanged += new System.EventHandler(this.datTuNgay_EditValueChanged);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblTuNgay, 1);
            this.lblTuNgay.Location = new System.Drawing.Point(191, 11);
            this.lblTuNgay.Name = "lblTuNgay";
            this.panelChung.SetRow(this.lblTuNgay, 1);
            this.lblTuNgay.Size = new System.Drawing.Size(114, 19);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "lblTuNgay";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblDenNgay, 3);
            this.lblDenNgay.Location = new System.Drawing.Point(625, 11);
            this.lblDenNgay.Name = "lblDenNgay";
            this.panelChung.SetRow(this.lblDenNgay, 1);
            this.lblDenNgay.Size = new System.Drawing.Size(114, 19);
            this.lblDenNgay.TabIndex = 1;
            this.lblDenNgay.Text = "lblDenNgay";
            // 
            // lblMay
            // 
            this.lblMay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblMay, 1);
            this.lblMay.Location = new System.Drawing.Point(191, 37);
            this.lblMay.Name = "lblMay";
            this.panelChung.SetRow(this.lblMay, 2);
            this.lblMay.Size = new System.Drawing.Size(114, 19);
            this.lblMay.TabIndex = 1;
            this.lblMay.Text = "lblMay";
            // 
            // datDenNgay
            // 
            this.panelChung.SetColumn(this.datDenNgay, 4);
            this.datDenNgay.EditValue = null;
            this.datDenNgay.Location = new System.Drawing.Point(745, 11);
            this.datDenNgay.Name = "datDenNgay";
            this.datDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.panelChung.SetRow(this.datDenNgay, 1);
            this.datDenNgay.Size = new System.Drawing.Size(307, 20);
            this.datDenNgay.TabIndex = 9;
            this.datDenNgay.EditValueChanged += new System.EventHandler(this.datTuNgay_EditValueChanged);
            // 
            // cboMay
            // 
            this.panelChung.SetColumn(this.cboMay, 2);
            this.cboMay.Location = new System.Drawing.Point(311, 37);
            this.cboMay.Name = "cboMay";
            this.cboMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMay.Properties.NullText = "";
            this.panelChung.SetRow(this.cboMay, 2);
            this.cboMay.Size = new System.Drawing.Size(307, 20);
            this.cboMay.TabIndex = 10;
            this.cboMay.EditValueChanged += new System.EventHandler(this.datTuNgay_EditValueChanged);
            // 
            // ucBaoCaoTieuThuDienNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelChung);
            this.Name = "ucBaoCaoTieuThuDienNang";
            this.Size = new System.Drawing.Size(1243, 709);
            this.Load += new System.EventHandler(this.ucBaoCaoTieuThuDienNang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTongHopHieuXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTongHopHieuXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.LabelControl lblTuNgay;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.DateEdit datTuNgay;
        private DevExpress.XtraEditors.LabelControl lblDenNgay;
        private DevExpress.XtraEditors.LabelControl lblMay;
        private DevExpress.XtraEditors.DateEdit datDenNgay;
        private DevExpress.XtraEditors.LookUpEdit cboMay;
        private DevExpress.XtraGrid.GridControl grdTongHopHieuXuat;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTongHopHieuXuat;
    }
}
