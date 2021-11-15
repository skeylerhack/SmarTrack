namespace VS.OEE
{
    partial class frmDeviceCause
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groMay = new DevExpress.XtraEditors.GroupControl();
            this.grdMay = new DevExpress.XtraGrid.GridControl();
            this.grvMay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groDeviceCause = new DevExpress.XtraEditors.GroupControl();
            this.grdDeviceCause = new DevExpress.XtraGrid.GridControl();
            this.grvDeviceCause = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.lblHeThong = new DevExpress.XtraEditors.LabelControl();
            this.lblLoaiMay = new DevExpress.XtraEditors.LabelControl();
            this.lblNhomMay = new DevExpress.XtraEditors.LabelControl();
            this.cboNhomMay = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groMay)).BeginInit();
            this.groMay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groDeviceCause)).BeginInit();
            this.groDeviceCause.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDeviceCause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDeviceCause)).BeginInit();
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
            // splitContainerControl1
            // 
            this.tablecontrol.SetColumn(this.splitContainerControl1, 0);
            this.tablecontrol.SetColumnSpan(this.splitContainerControl1, 8);
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(3, 27);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groMay);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groDeviceCause);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.tablecontrol.SetRow(this.splitContainerControl1, 1);
            this.splitContainerControl1.Size = new System.Drawing.Size(1170, 478);
            this.splitContainerControl1.SplitterPosition = 577;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // groMay
            // 
            this.groMay.Controls.Add(this.grdMay);
            this.groMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groMay.Location = new System.Drawing.Point(0, 0);
            this.groMay.Name = "groMay";
            this.groMay.Size = new System.Drawing.Size(577, 478);
            this.groMay.TabIndex = 7;
            this.groMay.Text = "groMay";
            // 
            // grdMay
            // 
            this.grdMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMay.Location = new System.Drawing.Point(2, 22);
            this.grdMay.MainView = this.grvMay;
            this.grdMay.Name = "grdMay";
            this.grdMay.Size = new System.Drawing.Size(573, 454);
            this.grdMay.TabIndex = 5;
            this.grdMay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMay});
            // 
            // grvMay
            // 
            this.grvMay.GridControl = this.grdMay;
            this.grvMay.Name = "grvMay";
            this.grvMay.OptionsView.ShowGroupPanel = false;
            this.grvMay.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvMay_FocusedRowChanged);
            // 
            // groDeviceCause
            // 
            this.groDeviceCause.Controls.Add(this.grdDeviceCause);
            this.groDeviceCause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groDeviceCause.Location = new System.Drawing.Point(0, 0);
            this.groDeviceCause.Name = "groDeviceCause";
            this.groDeviceCause.Size = new System.Drawing.Size(587, 478);
            this.groDeviceCause.TabIndex = 7;
            this.groDeviceCause.Text = "groDeviceCause";
            // 
            // grdDeviceCause
            // 
            this.grdDeviceCause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDeviceCause.Location = new System.Drawing.Point(2, 22);
            this.grdDeviceCause.MainView = this.grvDeviceCause;
            this.grdDeviceCause.Name = "grdDeviceCause";
            this.grdDeviceCause.Size = new System.Drawing.Size(583, 454);
            this.grdDeviceCause.TabIndex = 5;
            this.grdDeviceCause.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDeviceCause});
            this.grdDeviceCause.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdDeviceCause_ProcessGridKey);
            // 
            // grvDeviceCause
            // 
            this.grvDeviceCause.GridControl = this.grdDeviceCause;
            this.grvDeviceCause.Name = "grvDeviceCause";
            this.grvDeviceCause.OptionsView.ShowGroupPanel = false;
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
            this.tablecontrol.Controls.Add(this.cboLoaiMay);
            this.tablecontrol.Controls.Add(this.treHeThong);
            this.tablecontrol.Controls.Add(this.treDiaDiem);
            this.tablecontrol.Controls.Add(this.lblDiaDiem);
            this.tablecontrol.Controls.Add(this.splitContainerControl1);
            this.tablecontrol.Controls.Add(this.panelNN);
            this.tablecontrol.Controls.Add(this.lblHeThong);
            this.tablecontrol.Controls.Add(this.lblLoaiMay);
            this.tablecontrol.Controls.Add(this.lblNhomMay);
            this.tablecontrol.Controls.Add(this.cboNhomMay);
            this.tablecontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablecontrol.Location = new System.Drawing.Point(0, 0);
            this.tablecontrol.Name = "tablecontrol";
            this.tablecontrol.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 24F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 37F)});
            this.tablecontrol.Size = new System.Drawing.Size(1176, 545);
            this.tablecontrol.TabIndex = 3;
            // 
            // cboLoaiMay
            // 
            this.tablecontrol.SetColumn(this.cboLoaiMay, 5);
            this.cboLoaiMay.Location = new System.Drawing.Point(711, 3);
            this.cboLoaiMay.Name = "cboLoaiMay";
            this.cboLoaiMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiMay.Properties.NullText = "";
            this.tablecontrol.SetRow(this.cboLoaiMay, 0);
            this.cboLoaiMay.Size = new System.Drawing.Size(168, 20);
            this.cboLoaiMay.TabIndex = 10;
            this.cboLoaiMay.EditValueChanged += new System.EventHandler(this.cboLoaiMay_EditValueChanged);
            // 
            // treHeThong
            // 
            this.tablecontrol.SetColumn(this.treHeThong, 3);
            this.treHeThong.Location = new System.Drawing.Point(417, 3);
            this.treHeThong.Name = "treHeThong";
            this.treHeThong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treHeThong.Properties.NullText = "";
            this.treHeThong.Properties.TreeList = this.treeListLookUpEdit2TreeList;
            this.tablecontrol.SetRow(this.treHeThong, 0);
            this.treHeThong.Size = new System.Drawing.Size(168, 20);
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
            this.treDiaDiem.Location = new System.Drawing.Point(123, 3);
            this.treDiaDiem.Name = "treDiaDiem";
            this.treDiaDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treDiaDiem.Properties.NullText = "";
            this.treDiaDiem.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.tablecontrol.SetRow(this.treDiaDiem, 0);
            this.treDiaDiem.Size = new System.Drawing.Size(168, 20);
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
            this.lblDiaDiem.Location = new System.Drawing.Point(3, 3);
            this.lblDiaDiem.Name = "lblDiaDiem";
            this.tablecontrol.SetRow(this.lblDiaDiem, 0);
            this.lblDiaDiem.Size = new System.Drawing.Size(114, 18);
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
            this.panelNN.Controls.Add(this.btnXoa);
            this.panelNN.Controls.Add(this.btnGhi);
            this.panelNN.Controls.Add(this.btnKhong);
            this.panelNN.Location = new System.Drawing.Point(3, 511);
            this.panelNN.Name = "panelNN";
            this.tablecontrol.SetRow(this.panelNN, 2);
            this.panelNN.Size = new System.Drawing.Size(1170, 31);
            this.panelNN.TabIndex = 6;
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.grdMay;
            this.searchControl1.Location = new System.Drawing.Point(0, 3);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.grdMay;
            this.searchControl1.Properties.FindDelay = 100;
            this.searchControl1.Size = new System.Drawing.Size(200, 20);
            this.searchControl1.TabIndex = 6;
            // 
            // btnThemSua
            // 
            this.btnThemSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemSua.Location = new System.Drawing.Point(925, 3);
            this.btnThemSua.Name = "btnThemSua";
            this.btnThemSua.Size = new System.Drawing.Size(80, 26);
            this.btnThemSua.TabIndex = 9;
            this.btnThemSua.Text = "btnThemSua";
            this.btnThemSua.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(1087, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(1006, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 26);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(1006, 3);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 11;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Location = new System.Drawing.Point(1087, 3);
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
            this.lblHeThong.Location = new System.Drawing.Point(297, 3);
            this.lblHeThong.Name = "lblHeThong";
            this.tablecontrol.SetRow(this.lblHeThong, 0);
            this.lblHeThong.Size = new System.Drawing.Size(114, 18);
            this.lblHeThong.TabIndex = 7;
            this.lblHeThong.Text = "lblHeThong";
            // 
            // lblLoaiMay
            // 
            this.tablecontrol.SetColumn(this.lblLoaiMay, 4);
            this.lblLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiMay.Location = new System.Drawing.Point(591, 3);
            this.lblLoaiMay.Name = "lblLoaiMay";
            this.tablecontrol.SetRow(this.lblLoaiMay, 0);
            this.lblLoaiMay.Size = new System.Drawing.Size(114, 18);
            this.lblLoaiMay.TabIndex = 7;
            this.lblLoaiMay.Text = "lblLoaiMay";
            // 
            // lblNhomMay
            // 
            this.tablecontrol.SetColumn(this.lblNhomMay, 6);
            this.lblNhomMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhomMay.Location = new System.Drawing.Point(885, 3);
            this.lblNhomMay.Name = "lblNhomMay";
            this.tablecontrol.SetRow(this.lblNhomMay, 0);
            this.lblNhomMay.Size = new System.Drawing.Size(114, 18);
            this.lblNhomMay.TabIndex = 7;
            this.lblNhomMay.Text = "lblNhomMay";
            // 
            // cboNhomMay
            // 
            this.tablecontrol.SetColumn(this.cboNhomMay, 7);
            this.cboNhomMay.Location = new System.Drawing.Point(1005, 3);
            this.cboNhomMay.Name = "cboNhomMay";
            this.cboNhomMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhomMay.Properties.NullText = "";
            this.tablecontrol.SetRow(this.cboNhomMay, 0);
            this.cboNhomMay.Size = new System.Drawing.Size(168, 20);
            this.cboNhomMay.TabIndex = 10;
            this.cboNhomMay.EditValueChanged += new System.EventHandler(this.cboNhomMay_EditValueChanged);
            // 
            // frmDeviceCause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 545);
            this.Controls.Add(this.tablecontrol);
            this.Name = "frmDeviceCause";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDeviceCause";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDeviceCause_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groMay)).EndInit();
            this.groMay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groDeviceCause)).EndInit();
            this.groDeviceCause.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDeviceCause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDeviceCause)).EndInit();
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
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.Layout.TablePanel tablecontrol;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraGrid.GridControl grdMay;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMay;
        private DevExpress.XtraEditors.SimpleButton btnThemSua;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.GroupControl groMay;
        private DevExpress.XtraEditors.GroupControl groDeviceCause;
        private DevExpress.XtraGrid.GridControl grdDeviceCause;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDeviceCause;
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