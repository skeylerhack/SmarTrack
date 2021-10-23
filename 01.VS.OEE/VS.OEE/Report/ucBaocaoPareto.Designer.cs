namespace VS.OEE
{
    partial class ucBaocaoPareto
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
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.grdPareto = new DevExpress.XtraGrid.GridControl();
            this.grvPareto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.cboNhaXuong = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.groDanhSachPareto = new DevExpress.XtraEditors.GroupControl();
            this.groChonNguyenNhan = new DevExpress.XtraEditors.GroupControl();
            this.grdNguyenNhanPar = new DevExpress.XtraGrid.GridControl();
            this.grvNguyenNhanPar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groChonMay = new DevExpress.XtraEditors.GroupControl();
            this.grdMayPar = new DevExpress.XtraGrid.GridControl();
            this.grvMayPar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboDacDiem = new DevExpress.XtraEditors.LookUpEdit();
            this.datTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblTuNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblDenNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblDacDiem = new DevExpress.XtraEditors.LabelControl();
            this.lblLoaiNguyenNhan = new DevExpress.XtraEditors.LabelControl();
            this.datDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.cboLoaiNguyenNhan = new DevExpress.XtraEditors.LookUpEdit();
            this.cboLoaiMay = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLoaiMay = new DevExpress.XtraEditors.LabelControl();
            this.lblDiaDiem = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPareto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPareto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhaXuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groDanhSachPareto)).BeginInit();
            this.groDanhSachPareto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groChonNguyenNhan)).BeginInit();
            this.groChonNguyenNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNguyenNhanPar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNguyenNhanPar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groChonMay)).BeginInit();
            this.groChonMay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMayPar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMayPar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDacDiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiNguyenNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNN
            // 
            this.panelNN.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelNN.Appearance.Options.UseBackColor = true;
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelChung.SetColumn(this.panelNN, 3);
            this.panelChung.SetColumnSpan(this.panelNN, 6);
            this.panelNN.Controls.Add(this.btnXem);
            this.panelNN.Controls.Add(this.btnIn);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNN.Location = new System.Drawing.Point(364, 440);
            this.panelNN.Name = "panelNN";
            this.panelChung.SetRow(this.panelNN, 6);
            this.panelNN.Size = new System.Drawing.Size(596, 31);
            this.panelNN.TabIndex = 6;
            // 
            // btnXem
            // 
            this.btnXem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXem.Location = new System.Drawing.Point(284, 0);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(104, 31);
            this.btnXem.TabIndex = 5;
            this.btnXem.Text = "btnXem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnIn
            // 
            this.btnIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIn.Location = new System.Drawing.Point(388, 0);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(104, 31);
            this.btnIn.TabIndex = 5;
            this.btnIn.Text = "btnIn";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.Location = new System.Drawing.Point(492, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 31);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // grdPareto
            // 
            this.grdPareto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPareto.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdPareto.Location = new System.Drawing.Point(2, 23);
            this.grdPareto.MainView = this.grvPareto;
            this.grdPareto.Margin = new System.Windows.Forms.Padding(2);
            this.grdPareto.Name = "grdPareto";
            this.grdPareto.Size = new System.Drawing.Size(953, 153);
            this.grdPareto.TabIndex = 7;
            this.grdPareto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPareto});
            // 
            // grvPareto
            // 
            this.grvPareto.ColumnPanelRowHeight = 1;
            this.grvPareto.DetailHeight = 227;
            this.grvPareto.FixedLineWidth = 1;
            this.grvPareto.GridControl = this.grdPareto;
            this.grvPareto.Name = "grvPareto";
            this.grvPareto.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvPareto.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvPareto.OptionsCustomization.AllowRowSizing = true;
            this.grvPareto.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel;
            this.grvPareto.OptionsFind.FindDelay = 100;
            this.grvPareto.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvPareto.OptionsPrint.AllowMultilineHeaders = true;
            this.grvPareto.OptionsScrollAnnotations.ShowCustomAnnotations = DevExpress.Utils.DefaultBoolean.True;
            this.grvPareto.OptionsScrollAnnotations.ShowErrors = DevExpress.Utils.DefaultBoolean.True;
            this.grvPareto.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvPareto.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvPareto.OptionsView.RowAutoHeight = true;
            this.grvPareto.RowHeight = 1;
            // 
            // panelChung
            // 
            this.panelChung.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.panelChung.Controls.Add(this.cboNhaXuong);
            this.panelChung.Controls.Add(this.groDanhSachPareto);
            this.panelChung.Controls.Add(this.groChonNguyenNhan);
            this.panelChung.Controls.Add(this.groChonMay);
            this.panelChung.Controls.Add(this.cboDacDiem);
            this.panelChung.Controls.Add(this.datTuNgay);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.lblTuNgay);
            this.panelChung.Controls.Add(this.lblDenNgay);
            this.panelChung.Controls.Add(this.lblDacDiem);
            this.panelChung.Controls.Add(this.lblLoaiNguyenNhan);
            this.panelChung.Controls.Add(this.datDenNgay);
            this.panelChung.Controls.Add(this.cboLoaiNguyenNhan);
            this.panelChung.Controls.Add(this.cboLoaiMay);
            this.panelChung.Controls.Add(this.lblLoaiMay);
            this.panelChung.Controls.Add(this.lblDiaDiem);
            this.panelChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChung.Location = new System.Drawing.Point(0, 0);
            this.panelChung.Name = "panelChung";
            this.panelChung.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 27F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 37F)});
            this.panelChung.Size = new System.Drawing.Size(963, 474);
            this.panelChung.TabIndex = 2;
            // 
            // cboNhaXuong
            // 
            this.panelChung.SetColumn(this.cboNhaXuong, 1);
            this.cboNhaXuong.EditValue = "";
            this.cboNhaXuong.Location = new System.Drawing.Point(123, 37);
            this.cboNhaXuong.Name = "cboNhaXuong";
            this.cboNhaXuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhaXuong.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.panelChung.SetRow(this.cboNhaXuong, 2);
            this.cboNhaXuong.Size = new System.Drawing.Size(115, 20);
            this.cboNhaXuong.TabIndex = 14;
            this.cboNhaXuong.EditValueChanged += new System.EventHandler(this.cboNhaXuong_EditValueChanged);
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(281, 137);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // groDanhSachPareto
            // 
            this.panelChung.SetColumn(this.groDanhSachPareto, 0);
            this.panelChung.SetColumnSpan(this.groDanhSachPareto, 8);
            this.groDanhSachPareto.Controls.Add(this.grdPareto);
            this.groDanhSachPareto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groDanhSachPareto.Location = new System.Drawing.Point(3, 256);
            this.groDanhSachPareto.Name = "groDanhSachPareto";
            this.panelChung.SetRow(this.groDanhSachPareto, 5);
            this.groDanhSachPareto.Size = new System.Drawing.Size(957, 178);
            this.groDanhSachPareto.TabIndex = 13;
            this.groDanhSachPareto.Text = "groDanhSachPareto";
            // 
            // groChonNguyenNhan
            // 
            this.panelChung.SetColumn(this.groChonNguyenNhan, 4);
            this.panelChung.SetColumnSpan(this.groChonNguyenNhan, 4);
            this.groChonNguyenNhan.Controls.Add(this.grdNguyenNhanPar);
            this.groChonNguyenNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groChonNguyenNhan.Location = new System.Drawing.Point(485, 72);
            this.groChonNguyenNhan.Name = "groChonNguyenNhan";
            this.panelChung.SetRow(this.groChonNguyenNhan, 4);
            this.groChonNguyenNhan.Size = new System.Drawing.Size(475, 178);
            this.groChonNguyenNhan.TabIndex = 12;
            this.groChonNguyenNhan.Text = "groChonNguyenNhan";
            // 
            // grdNguyenNhanPar
            // 
            this.grdNguyenNhanPar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNguyenNhanPar.Location = new System.Drawing.Point(2, 23);
            this.grdNguyenNhanPar.MainView = this.grvNguyenNhanPar;
            this.grdNguyenNhanPar.Name = "grdNguyenNhanPar";
            this.grdNguyenNhanPar.Size = new System.Drawing.Size(471, 153);
            this.grdNguyenNhanPar.TabIndex = 2;
            this.grdNguyenNhanPar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNguyenNhanPar});
            // 
            // grvNguyenNhanPar
            // 
            this.grvNguyenNhanPar.GridControl = this.grdNguyenNhanPar;
            this.grvNguyenNhanPar.Name = "grvNguyenNhanPar";
            this.grvNguyenNhanPar.OptionsSelection.MultiSelect = true;
            this.grvNguyenNhanPar.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvNguyenNhanPar.OptionsView.ShowGroupPanel = false;
            // 
            // groChonMay
            // 
            this.panelChung.SetColumn(this.groChonMay, 0);
            this.panelChung.SetColumnSpan(this.groChonMay, 4);
            this.groChonMay.Controls.Add(this.grdMayPar);
            this.groChonMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groChonMay.Location = new System.Drawing.Point(3, 72);
            this.groChonMay.Name = "groChonMay";
            this.panelChung.SetRow(this.groChonMay, 4);
            this.groChonMay.Size = new System.Drawing.Size(476, 178);
            this.groChonMay.TabIndex = 11;
            this.groChonMay.Text = "groChonMay";
            // 
            // grdMayPar
            // 
            this.grdMayPar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMayPar.Location = new System.Drawing.Point(2, 23);
            this.grdMayPar.MainView = this.grvMayPar;
            this.grdMayPar.Name = "grdMayPar";
            this.grdMayPar.Size = new System.Drawing.Size(472, 153);
            this.grdMayPar.TabIndex = 2;
            this.grdMayPar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMayPar});
            // 
            // grvMayPar
            // 
            this.grvMayPar.GridControl = this.grdMayPar;
            this.grvMayPar.Name = "grvMayPar";
            this.grvMayPar.OptionsSelection.MultiSelect = true;
            this.grvMayPar.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvMayPar.OptionsView.ShowGroupPanel = false;
            // 
            // cboDacDiem
            // 
            this.panelChung.SetColumn(this.cboDacDiem, 7);
            this.cboDacDiem.Location = new System.Drawing.Point(845, 37);
            this.cboDacDiem.Name = "cboDacDiem";
            this.cboDacDiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDacDiem.Properties.NullText = "";
            this.panelChung.SetRow(this.cboDacDiem, 2);
            this.cboDacDiem.Size = new System.Drawing.Size(115, 20);
            this.cboDacDiem.TabIndex = 10;
            this.cboDacDiem.EditValueChanged += new System.EventHandler(this.cboLoaiNguyenNhan_EditValueChanged);
            // 
            // datTuNgay
            // 
            this.panelChung.SetColumn(this.datTuNgay, 3);
            this.datTuNgay.EditValue = null;
            this.datTuNgay.Location = new System.Drawing.Point(364, 11);
            this.datTuNgay.Name = "datTuNgay";
            this.datTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.panelChung.SetRow(this.datTuNgay, 1);
            this.datTuNgay.Size = new System.Drawing.Size(115, 20);
            this.datTuNgay.TabIndex = 9;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblTuNgay, 2);
            this.lblTuNgay.Location = new System.Drawing.Point(244, 11);
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
            this.lblDenNgay.Location = new System.Drawing.Point(485, 11);
            this.lblDenNgay.Name = "lblDenNgay";
            this.panelChung.SetRow(this.lblDenNgay, 1);
            this.lblDenNgay.Size = new System.Drawing.Size(114, 19);
            this.lblDenNgay.TabIndex = 1;
            this.lblDenNgay.Text = "lblDenNgay";
            // 
            // lblDacDiem
            // 
            this.lblDacDiem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblDacDiem, 6);
            this.lblDacDiem.Location = new System.Drawing.Point(725, 37);
            this.lblDacDiem.Name = "lblDacDiem";
            this.panelChung.SetRow(this.lblDacDiem, 2);
            this.lblDacDiem.Size = new System.Drawing.Size(114, 19);
            this.lblDacDiem.TabIndex = 1;
            this.lblDacDiem.Text = "lblDacDiem";
            // 
            // lblLoaiNguyenNhan
            // 
            this.lblLoaiNguyenNhan.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblLoaiNguyenNhan, 4);
            this.lblLoaiNguyenNhan.Location = new System.Drawing.Point(485, 37);
            this.lblLoaiNguyenNhan.Name = "lblLoaiNguyenNhan";
            this.panelChung.SetRow(this.lblLoaiNguyenNhan, 2);
            this.lblLoaiNguyenNhan.Size = new System.Drawing.Size(114, 19);
            this.lblLoaiNguyenNhan.TabIndex = 1;
            this.lblLoaiNguyenNhan.Text = "lblLoaiNguyenNhan";
            // 
            // datDenNgay
            // 
            this.panelChung.SetColumn(this.datDenNgay, 5);
            this.datDenNgay.EditValue = null;
            this.datDenNgay.Location = new System.Drawing.Point(605, 11);
            this.datDenNgay.Name = "datDenNgay";
            this.datDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.panelChung.SetRow(this.datDenNgay, 1);
            this.datDenNgay.Size = new System.Drawing.Size(115, 20);
            this.datDenNgay.TabIndex = 9;
            // 
            // cboLoaiNguyenNhan
            // 
            this.panelChung.SetColumn(this.cboLoaiNguyenNhan, 5);
            this.cboLoaiNguyenNhan.Location = new System.Drawing.Point(605, 37);
            this.cboLoaiNguyenNhan.Name = "cboLoaiNguyenNhan";
            this.cboLoaiNguyenNhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiNguyenNhan.Properties.NullText = "";
            this.panelChung.SetRow(this.cboLoaiNguyenNhan, 2);
            this.cboLoaiNguyenNhan.Size = new System.Drawing.Size(115, 20);
            this.cboLoaiNguyenNhan.TabIndex = 10;
            this.cboLoaiNguyenNhan.EditValueChanged += new System.EventHandler(this.cboLoaiNguyenNhan_EditValueChanged);
            // 
            // cboLoaiMay
            // 
            this.panelChung.SetColumn(this.cboLoaiMay, 3);
            this.cboLoaiMay.Location = new System.Drawing.Point(364, 37);
            this.cboLoaiMay.Name = "cboLoaiMay";
            this.cboLoaiMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiMay.Properties.NullText = "";
            this.panelChung.SetRow(this.cboLoaiMay, 2);
            this.cboLoaiMay.Size = new System.Drawing.Size(115, 20);
            this.cboLoaiMay.TabIndex = 10;
            this.cboLoaiMay.EditValueChanged += new System.EventHandler(this.cboNhaXuong_EditValueChanged);
            // 
            // lblLoaiMay
            // 
            this.lblLoaiMay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblLoaiMay, 2);
            this.lblLoaiMay.Location = new System.Drawing.Point(244, 37);
            this.lblLoaiMay.Name = "lblLoaiMay";
            this.panelChung.SetRow(this.lblLoaiMay, 2);
            this.lblLoaiMay.Size = new System.Drawing.Size(114, 19);
            this.lblLoaiMay.TabIndex = 1;
            this.lblLoaiMay.Text = "lblLoaiMay";
            // 
            // lblDiaDiem
            // 
            this.lblDiaDiem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblDiaDiem, 0);
            this.lblDiaDiem.Location = new System.Drawing.Point(3, 37);
            this.lblDiaDiem.Name = "lblDiaDiem";
            this.panelChung.SetRow(this.lblDiaDiem, 2);
            this.lblDiaDiem.Size = new System.Drawing.Size(114, 19);
            this.lblDiaDiem.TabIndex = 1;
            this.lblDiaDiem.Text = "lblDiaDiem";
            // 
            // ucBaocaoPareto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelChung);
            this.Name = "ucBaocaoPareto";
            this.Size = new System.Drawing.Size(963, 474);
            this.Load += new System.EventHandler(this.ucBaocaoPareto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPareto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPareto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboNhaXuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groDanhSachPareto)).EndInit();
            this.groDanhSachPareto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groChonNguyenNhan)).EndInit();
            this.groChonNguyenNhan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNguyenNhanPar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNguyenNhanPar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groChonMay)).EndInit();
            this.groChonMay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMayPar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMayPar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDacDiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiNguyenNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraGrid.GridControl grdPareto;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPareto;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.LabelControl lblTuNgay;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.LookUpEdit cboDacDiem;
        private DevExpress.XtraEditors.DateEdit datTuNgay;
        private DevExpress.XtraEditors.LabelControl lblDenNgay;
        private DevExpress.XtraEditors.LabelControl lblDacDiem;
        private DevExpress.XtraEditors.LabelControl lblLoaiNguyenNhan;
        private DevExpress.XtraEditors.DateEdit datDenNgay;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiNguyenNhan;
        private DevExpress.XtraEditors.GroupControl groChonNguyenNhan;
        private DevExpress.XtraEditors.GroupControl groChonMay;
        private DevExpress.XtraEditors.GroupControl groDanhSachPareto;
        private DevExpress.XtraGrid.GridControl grdNguyenNhanPar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNguyenNhanPar;
        private DevExpress.XtraGrid.GridControl grdMayPar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMayPar;
        private DevExpress.XtraEditors.TreeListLookUpEdit cboNhaXuong;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiMay;
        private DevExpress.XtraEditors.LabelControl lblLoaiMay;
        private DevExpress.XtraEditors.LabelControl lblDiaDiem;
        private DevExpress.XtraEditors.SimpleButton btnXem;
    }
}
