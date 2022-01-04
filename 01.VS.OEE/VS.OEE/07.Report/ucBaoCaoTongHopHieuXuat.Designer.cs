namespace VS.OEE
{
    partial class ucBaoCaoTongHopHieuXuat
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
            this.cboNhaXuong = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.datTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblTuNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblDenNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblDiaDiem = new DevExpress.XtraEditors.LabelControl();
            this.lblLoaiMay = new DevExpress.XtraEditors.LabelControl();
            this.datDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.cboLoaiMay = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTongHopHieuXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTongHopHieuXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhaXuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).BeginInit();
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
            this.panelNN.Location = new System.Drawing.Point(188, 503);
            this.panelNN.Name = "panelNN";
            this.panelChung.SetRow(this.panelNN, 5);
            this.panelNN.Size = new System.Drawing.Size(1034, 29);
            this.panelNN.TabIndex = 6;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(953, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Location = new System.Drawing.Point(872, 1);
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
            this.panelChung.Controls.Add(this.cboNhaXuong);
            this.panelChung.Controls.Add(this.datTuNgay);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.lblTuNgay);
            this.panelChung.Controls.Add(this.lblDenNgay);
            this.panelChung.Controls.Add(this.lblDiaDiem);
            this.panelChung.Controls.Add(this.lblLoaiMay);
            this.panelChung.Controls.Add(this.datDenNgay);
            this.panelChung.Controls.Add(this.cboLoaiMay);
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
            this.panelChung.Size = new System.Drawing.Size(1225, 535);
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
            this.grdTongHopHieuXuat.Size = new System.Drawing.Size(1219, 426);
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
            // cboNhaXuong
            // 
            this.panelChung.SetColumn(this.cboNhaXuong, 2);
            this.cboNhaXuong.EditValue = "";
            this.cboNhaXuong.Location = new System.Drawing.Point(308, 37);
            this.cboNhaXuong.Name = "cboNhaXuong";
            this.cboNhaXuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhaXuong.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.panelChung.SetRow(this.cboNhaXuong, 2);
            this.cboNhaXuong.Size = new System.Drawing.Size(302, 20);
            this.cboNhaXuong.TabIndex = 11;
            this.cboNhaXuong.EditValueChanged += new System.EventHandler(this.datTuNgay_EditValueChanged);
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // datTuNgay
            // 
            this.panelChung.SetColumn(this.datTuNgay, 2);
            this.datTuNgay.EditValue = null;
            this.datTuNgay.Location = new System.Drawing.Point(308, 11);
            this.datTuNgay.Name = "datTuNgay";
            this.datTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.panelChung.SetRow(this.datTuNgay, 1);
            this.datTuNgay.Size = new System.Drawing.Size(302, 20);
            this.datTuNgay.TabIndex = 9;
            this.datTuNgay.EditValueChanged += new System.EventHandler(this.datTuNgay_EditValueChanged);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblTuNgay, 1);
            this.lblTuNgay.Location = new System.Drawing.Point(188, 11);
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
            this.lblDenNgay.Location = new System.Drawing.Point(616, 11);
            this.lblDenNgay.Name = "lblDenNgay";
            this.panelChung.SetRow(this.lblDenNgay, 1);
            this.lblDenNgay.Size = new System.Drawing.Size(114, 19);
            this.lblDenNgay.TabIndex = 1;
            this.lblDenNgay.Text = "lblDenNgay";
            // 
            // lblDiaDiem
            // 
            this.lblDiaDiem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblDiaDiem, 1);
            this.lblDiaDiem.Location = new System.Drawing.Point(188, 37);
            this.lblDiaDiem.Name = "lblDiaDiem";
            this.panelChung.SetRow(this.lblDiaDiem, 2);
            this.lblDiaDiem.Size = new System.Drawing.Size(114, 19);
            this.lblDiaDiem.TabIndex = 1;
            this.lblDiaDiem.Text = "lblDiaDiem";
            // 
            // lblLoaiMay
            // 
            this.lblLoaiMay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblLoaiMay, 3);
            this.lblLoaiMay.Location = new System.Drawing.Point(616, 37);
            this.lblLoaiMay.Name = "lblLoaiMay";
            this.panelChung.SetRow(this.lblLoaiMay, 2);
            this.lblLoaiMay.Size = new System.Drawing.Size(114, 19);
            this.lblLoaiMay.TabIndex = 1;
            this.lblLoaiMay.Text = "lblLoaiMay";
            // 
            // datDenNgay
            // 
            this.panelChung.SetColumn(this.datDenNgay, 4);
            this.datDenNgay.EditValue = null;
            this.datDenNgay.Location = new System.Drawing.Point(736, 11);
            this.datDenNgay.Name = "datDenNgay";
            this.datDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.panelChung.SetRow(this.datDenNgay, 1);
            this.datDenNgay.Size = new System.Drawing.Size(302, 20);
            this.datDenNgay.TabIndex = 9;
            this.datDenNgay.EditValueChanged += new System.EventHandler(this.datTuNgay_EditValueChanged);
            // 
            // cboLoaiMay
            // 
            this.panelChung.SetColumn(this.cboLoaiMay, 4);
            this.cboLoaiMay.Location = new System.Drawing.Point(736, 37);
            this.cboLoaiMay.Name = "cboLoaiMay";
            this.cboLoaiMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiMay.Properties.NullText = "";
            this.panelChung.SetRow(this.cboLoaiMay, 2);
            this.cboLoaiMay.Size = new System.Drawing.Size(302, 20);
            this.cboLoaiMay.TabIndex = 10;
            this.cboLoaiMay.EditValueChanged += new System.EventHandler(this.datTuNgay_EditValueChanged);
            // 
            // ucBaoCaoTongHopHieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelChung);
            this.Name = "ucBaoCaoTongHopHieuXuat";
            this.Size = new System.Drawing.Size(1225, 535);
            this.Load += new System.EventHandler(this.ucBaoCaoTongHopHieuXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTongHopHieuXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTongHopHieuXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhaXuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblDiaDiem;
        private DevExpress.XtraEditors.LabelControl lblLoaiMay;
        private DevExpress.XtraEditors.DateEdit datDenNgay;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiMay;
        private DevExpress.XtraEditors.TreeListLookUpEdit cboNhaXuong;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraGrid.GridControl grdTongHopHieuXuat;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTongHopHieuXuat;
    }
}
