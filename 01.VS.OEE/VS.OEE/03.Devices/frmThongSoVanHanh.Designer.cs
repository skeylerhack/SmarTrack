namespace VS.OEE
{
    partial class frmThongSoVanHanh
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
            this.groMayThongSo = new DevExpress.XtraEditors.GroupControl();
            this.grdMayThongSo = new DevExpress.XtraGrid.GridControl();
            this.grvMayThongSo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tablecontrol = new DevExpress.Utils.Layout.TablePanel();
            this.cboLoaiMay = new DevExpress.XtraEditors.LookUpEdit();
            this.treHeThong = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit2TreeList = new DevExpress.XtraTreeList.TreeList();
            this.treDiaDiem = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.lblDiaDiem = new DevExpress.XtraEditors.LabelControl();
            this.panelNN = new DevExpress.XtraEditors.PanelControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.btnThemSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.lblHeThong = new DevExpress.XtraEditors.LabelControl();
            this.lblLoaiMay = new DevExpress.XtraEditors.LabelControl();
            this.lblNhomMay = new DevExpress.XtraEditors.LabelControl();
            this.cboNhomMay = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groMayThongSo)).BeginInit();
            this.groMayThongSo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMayThongSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMayThongSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablecontrol)).BeginInit();
            this.tablecontrol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treHeThong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit2TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treDiaDiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomMay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groMayThongSo
            // 
            this.tablecontrol.SetColumn(this.groMayThongSo, 0);
            this.tablecontrol.SetColumnSpan(this.groMayThongSo, 8);
            this.groMayThongSo.Controls.Add(this.grdMayThongSo);
            this.groMayThongSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groMayThongSo.Location = new System.Drawing.Point(3, 45);
            this.groMayThongSo.Name = "groMayThongSo";
            this.tablecontrol.SetRow(this.groMayThongSo, 3);
            this.groMayThongSo.Size = new System.Drawing.Size(821, 303);
            this.groMayThongSo.TabIndex = 7;
            this.groMayThongSo.Text = "groMay";
            // 
            // grdMayThongSo
            // 
            this.grdMayThongSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMayThongSo.Location = new System.Drawing.Point(2, 22);
            this.grdMayThongSo.MainView = this.grvMayThongSo;
            this.grdMayThongSo.Name = "grdMayThongSo";
            this.grdMayThongSo.Size = new System.Drawing.Size(817, 279);
            this.grdMayThongSo.TabIndex = 5;
            this.grdMayThongSo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMayThongSo});
            // 
            // grvMayThongSo
            // 
            this.grvMayThongSo.GridControl = this.grdMayThongSo;
            this.grvMayThongSo.Name = "grvMayThongSo";
            this.grvMayThongSo.OptionsView.ShowGroupPanel = false;
            this.grvMayThongSo.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvMayThongSo_CellValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // tablecontrol
            // 
            this.tablecontrol.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablecontrol.Controls.Add(this.groMayThongSo);
            this.tablecontrol.Controls.Add(this.cboLoaiMay);
            this.tablecontrol.Controls.Add(this.treHeThong);
            this.tablecontrol.Controls.Add(this.treDiaDiem);
            this.tablecontrol.Controls.Add(this.lblDiaDiem);
            this.tablecontrol.Controls.Add(this.panelNN);
            this.tablecontrol.Controls.Add(this.lblHeThong);
            this.tablecontrol.Controls.Add(this.lblLoaiMay);
            this.tablecontrol.Controls.Add(this.lblNhomMay);
            this.tablecontrol.Controls.Add(this.cboNhomMay);
            this.tablecontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablecontrol.Location = new System.Drawing.Point(0, 0);
            this.tablecontrol.Name = "tablecontrol";
            this.tablecontrol.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.tablecontrol.Size = new System.Drawing.Size(827, 386);
            this.tablecontrol.TabIndex = 3;
            // 
            // cboLoaiMay
            // 
            this.tablecontrol.SetColumn(this.cboLoaiMay, 5);
            this.cboLoaiMay.Location = new System.Drawing.Point(537, 11);
            this.cboLoaiMay.Name = "cboLoaiMay";
            this.cboLoaiMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiMay.Properties.NullText = "";
            this.tablecontrol.SetRow(this.cboLoaiMay, 1);
            this.cboLoaiMay.Size = new System.Drawing.Size(81, 20);
            this.cboLoaiMay.TabIndex = 10;
            this.cboLoaiMay.EditValueChanged += new System.EventHandler(this.cboLoaiMay_EditValueChanged);
            // 
            // treHeThong
            // 
            this.tablecontrol.SetColumn(this.treHeThong, 3);
            this.treHeThong.Location = new System.Drawing.Point(330, 11);
            this.treHeThong.Name = "treHeThong";
            this.treHeThong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treHeThong.Properties.NullText = "";
            this.treHeThong.Properties.TreeList = this.treeListLookUpEdit2TreeList;
            this.tablecontrol.SetRow(this.treHeThong, 1);
            this.treHeThong.Size = new System.Drawing.Size(81, 20);
            this.treHeThong.TabIndex = 9;
            this.treHeThong.EditValueChanged += new System.EventHandler(this.cboNhomMay_EditValueChanged);
            // 
            // treeListLookUpEdit2TreeList
            // 
            this.treeListLookUpEdit2TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit2TreeList.Name = "treeListLookUpEdit2TreeList";
            this.treeListLookUpEdit2TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit2TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit2TreeList.TabIndex = 0;
            // 
            // treDiaDiem
            // 
            this.tablecontrol.SetColumn(this.treDiaDiem, 1);
            this.treDiaDiem.Location = new System.Drawing.Point(123, 11);
            this.treDiaDiem.Name = "treDiaDiem";
            this.treDiaDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treDiaDiem.Properties.NullText = "";
            this.treDiaDiem.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.tablecontrol.SetRow(this.treDiaDiem, 1);
            this.treDiaDiem.Size = new System.Drawing.Size(81, 20);
            this.treDiaDiem.TabIndex = 8;
            this.treDiaDiem.EditValueChanged += new System.EventHandler(this.cboNhomMay_EditValueChanged);
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // lblDiaDiem
            // 
            this.tablecontrol.SetColumn(this.lblDiaDiem, 0);
            this.lblDiaDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiaDiem.Location = new System.Drawing.Point(3, 11);
            this.lblDiaDiem.Name = "lblDiaDiem";
            this.tablecontrol.SetRow(this.lblDiaDiem, 1);
            this.lblDiaDiem.Size = new System.Drawing.Size(114, 20);
            this.lblDiaDiem.TabIndex = 7;
            this.lblDiaDiem.Text = "lblDiaDiem";
            // 
            // panelNN
            // 
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablecontrol.SetColumn(this.panelNN, 0);
            this.tablecontrol.SetColumnSpan(this.panelNN, 8);
            this.panelNN.Controls.Add(this.searchControl1);
            this.panelNN.Controls.Add(this.btnThemSua);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Controls.Add(this.btnGhi);
            this.panelNN.Controls.Add(this.btnKhong);
            this.panelNN.Location = new System.Drawing.Point(3, 354);
            this.panelNN.Name = "panelNN";
            this.tablecontrol.SetRow(this.panelNN, 4);
            this.panelNN.Size = new System.Drawing.Size(821, 29);
            this.panelNN.TabIndex = 6;
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.grdMayThongSo;
            this.searchControl1.Location = new System.Drawing.Point(0, 3);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.grdMayThongSo;
            this.searchControl1.Properties.FindDelay = 100;
            this.searchControl1.Size = new System.Drawing.Size(200, 20);
            this.searchControl1.TabIndex = 6;
            // 
            // btnThemSua
            // 
            this.btnThemSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemSua.Location = new System.Drawing.Point(657, 1);
            this.btnThemSua.Name = "btnThemSua";
            this.btnThemSua.Size = new System.Drawing.Size(80, 26);
            this.btnThemSua.TabIndex = 9;
            this.btnThemSua.Text = "btnThemSua";
            this.btnThemSua.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(738, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(657, 1);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 11;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Location = new System.Drawing.Point(738, 1);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(80, 26);
            this.btnKhong.TabIndex = 12;
            this.btnKhong.Text = "btnKhong";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // lblHeThong
            // 
            this.tablecontrol.SetColumn(this.lblHeThong, 2);
            this.lblHeThong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeThong.Location = new System.Drawing.Point(210, 11);
            this.lblHeThong.Name = "lblHeThong";
            this.tablecontrol.SetRow(this.lblHeThong, 1);
            this.lblHeThong.Size = new System.Drawing.Size(114, 20);
            this.lblHeThong.TabIndex = 7;
            this.lblHeThong.Text = "lblHeThong";
            // 
            // lblLoaiMay
            // 
            this.tablecontrol.SetColumn(this.lblLoaiMay, 4);
            this.lblLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiMay.Location = new System.Drawing.Point(417, 11);
            this.lblLoaiMay.Name = "lblLoaiMay";
            this.tablecontrol.SetRow(this.lblLoaiMay, 1);
            this.lblLoaiMay.Size = new System.Drawing.Size(114, 20);
            this.lblLoaiMay.TabIndex = 7;
            this.lblLoaiMay.Text = "lblLoaiMay";
            // 
            // lblNhomMay
            // 
            this.tablecontrol.SetColumn(this.lblNhomMay, 6);
            this.lblNhomMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhomMay.Location = new System.Drawing.Point(623, 11);
            this.lblNhomMay.Name = "lblNhomMay";
            this.tablecontrol.SetRow(this.lblNhomMay, 1);
            this.lblNhomMay.Size = new System.Drawing.Size(114, 20);
            this.lblNhomMay.TabIndex = 7;
            this.lblNhomMay.Text = "lblNhomMay";
            // 
            // cboNhomMay
            // 
            this.tablecontrol.SetColumn(this.cboNhomMay, 7);
            this.cboNhomMay.Location = new System.Drawing.Point(743, 11);
            this.cboNhomMay.Name = "cboNhomMay";
            this.cboNhomMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhomMay.Properties.NullText = "";
            this.tablecontrol.SetRow(this.cboNhomMay, 1);
            this.cboNhomMay.Size = new System.Drawing.Size(81, 20);
            this.cboNhomMay.TabIndex = 10;
            this.cboNhomMay.EditValueChanged += new System.EventHandler(this.cboNhomMay_EditValueChanged);
            // 
            // frmThongSoVanHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 386);
            this.Controls.Add(this.tablecontrol);
            this.Name = "frmThongSoVanHanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThongSoVanHanh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThongSoVanHanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groMayThongSo)).EndInit();
            this.groMayThongSo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMayThongSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMayThongSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablecontrol)).EndInit();
            this.tablecontrol.ResumeLayout(false);
            this.tablecontrol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treHeThong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit2TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treDiaDiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomMay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.Layout.TablePanel tablecontrol;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraGrid.GridControl grdMayThongSo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMayThongSo;
        private DevExpress.XtraEditors.SimpleButton btnThemSua;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.GroupControl groMayThongSo;
        private DevExpress.XtraEditors.LabelControl lblDiaDiem;
        private DevExpress.XtraEditors.LabelControl lblHeThong;
        private DevExpress.XtraEditors.LabelControl lblLoaiMay;
        private DevExpress.XtraEditors.LabelControl lblNhomMay;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiMay;
        private DevExpress.XtraEditors.TreeListLookUpEdit treHeThong;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit2TreeList;
        private DevExpress.XtraEditors.TreeListLookUpEdit treDiaDiem;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraEditors.LookUpEdit cboNhomMay;
    }
}