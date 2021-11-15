namespace VS.OEE
{
    partial class frmChoosePro
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
            this.cheXemAll = new DevExpress.XtraEditors.CheckEdit();
            this.cboDayChuyen = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.cboLoaiMay = new DevExpress.XtraEditors.LookUpEdit();
            this.datTNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblDayChuyen = new DevExpress.XtraEditors.LabelControl();
            this.grdMayPro = new DevExpress.XtraGrid.GridControl();
            this.grvMayPro = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.btnALL = new DevExpress.XtraEditors.SimpleButton();
            this.btnNotALL = new DevExpress.XtraEditors.SimpleButton();
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.lblLoaiMay = new DevExpress.XtraEditors.LabelControl();
            this.lblTuNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblDenNgay = new DevExpress.XtraEditors.LabelControl();
            this.datDNgay = new DevExpress.XtraEditors.DateEdit();
            this.cboCaBD = new DevExpress.XtraEditors.LookUpEdit();
            this.lblCaBD = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel)).BeginInit();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cheXemAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDayChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMayPro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMayPro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaBD.Properties)).BeginInit();
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
            this.tablePanel.Controls.Add(this.cheXemAll);
            this.tablePanel.Controls.Add(this.cboDayChuyen);
            this.tablePanel.Controls.Add(this.cboLoaiMay);
            this.tablePanel.Controls.Add(this.datTNgay);
            this.tablePanel.Controls.Add(this.lblDayChuyen);
            this.tablePanel.Controls.Add(this.grdMayPro);
            this.tablePanel.Controls.Add(this.panelControl1);
            this.tablePanel.Controls.Add(this.lblLoaiMay);
            this.tablePanel.Controls.Add(this.lblTuNgay);
            this.tablePanel.Controls.Add(this.lblDenNgay);
            this.tablePanel.Controls.Add(this.datDNgay);
            this.tablePanel.Controls.Add(this.cboCaBD);
            this.tablePanel.Controls.Add(this.lblCaBD);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(0, 0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 37F)});
            this.tablePanel.Size = new System.Drawing.Size(1085, 568);
            this.tablePanel.TabIndex = 0;
            // 
            // cheXemAll
            // 
            this.tablePanel.SetColumn(this.cheXemAll, 5);
            this.tablePanel.SetColumnSpan(this.cheXemAll, 2);
            this.cheXemAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cheXemAll.Location = new System.Drawing.Point(694, 35);
            this.cheXemAll.Name = "cheXemAll";
            this.cheXemAll.Properties.Caption = "cheXemAll";
            this.cheXemAll.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tablePanel.SetRow(this.cheXemAll, 1);
            this.cheXemAll.Size = new System.Drawing.Size(290, 26);
            this.cheXemAll.TabIndex = 6;
            this.cheXemAll.EditValueChanged += new System.EventHandler(this.cboDayChuyen_EditValueChanged);
            // 
            // cboDayChuyen
            // 
            this.tablePanel.SetColumn(this.cboDayChuyen, 2);
            this.cboDayChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDayChuyen.EditValue = "";
            this.cboDayChuyen.Location = new System.Drawing.Point(201, 3);
            this.cboDayChuyen.Name = "cboDayChuyen";
            this.cboDayChuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDayChuyen.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.tablePanel.SetRow(this.cboDayChuyen, 0);
            this.cboDayChuyen.Size = new System.Drawing.Size(190, 20);
            this.cboDayChuyen.TabIndex = 5;
            this.cboDayChuyen.EditValueChanged += new System.EventHandler(this.cboDayChuyen_EditValueChanged);
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // cboLoaiMay
            // 
            this.tablePanel.SetColumn(this.cboLoaiMay, 4);
            this.cboLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLoaiMay.Location = new System.Drawing.Point(497, 3);
            this.cboLoaiMay.Name = "cboLoaiMay";
            this.cboLoaiMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiMay.Properties.NullText = "";
            this.tablePanel.SetRow(this.cboLoaiMay, 0);
            this.cboLoaiMay.Size = new System.Drawing.Size(190, 20);
            this.cboLoaiMay.TabIndex = 4;
            this.cboLoaiMay.EditValueChanged += new System.EventHandler(this.cboDayChuyen_EditValueChanged);
            // 
            // datTNgay
            // 
            this.tablePanel.SetColumn(this.datTNgay, 2);
            this.datTNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datTNgay.EditValue = null;
            this.datTNgay.Location = new System.Drawing.Point(201, 35);
            this.datTNgay.Name = "datTNgay";
            this.datTNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel.SetRow(this.datTNgay, 1);
            this.datTNgay.Size = new System.Drawing.Size(190, 20);
            this.datTNgay.TabIndex = 3;
            this.datTNgay.EditValueChanged += new System.EventHandler(this.cboDayChuyen_EditValueChanged);
            // 
            // lblDayChuyen
            // 
            this.tablePanel.SetColumn(this.lblDayChuyen, 1);
            this.lblDayChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDayChuyen.Location = new System.Drawing.Point(101, 3);
            this.lblDayChuyen.Name = "lblDayChuyen";
            this.tablePanel.SetRow(this.lblDayChuyen, 0);
            this.lblDayChuyen.Size = new System.Drawing.Size(94, 26);
            this.lblDayChuyen.TabIndex = 2;
            this.lblDayChuyen.Text = "lblDayChuyen";
            // 
            // grdMayPro
            // 
            this.tablePanel.SetColumn(this.grdMayPro, 0);
            this.tablePanel.SetColumnSpan(this.grdMayPro, 8);
            this.grdMayPro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMayPro.Location = new System.Drawing.Point(3, 67);
            this.grdMayPro.MainView = this.grvMayPro;
            this.grdMayPro.Name = "grdMayPro";
            this.tablePanel.SetRow(this.grdMayPro, 2);
            this.grdMayPro.Size = new System.Drawing.Size(1079, 461);
            this.grdMayPro.TabIndex = 1;
            this.grdMayPro.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMayPro});
            // 
            // grvMayPro
            // 
            this.grvMayPro.GridControl = this.grdMayPro;
            this.grvMayPro.Name = "grvMayPro";
            this.grvMayPro.OptionsSelection.MultiSelect = true;
            this.grvMayPro.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvMayPro.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.tablePanel.SetColumn(this.panelControl1, 0);
            this.tablePanel.SetColumnSpan(this.panelControl1, 8);
            this.panelControl1.Controls.Add(this.searchControl1);
            this.panelControl1.Controls.Add(this.btnALL);
            this.panelControl1.Controls.Add(this.btnNotALL);
            this.panelControl1.Controls.Add(this.btnThucHien);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Location = new System.Drawing.Point(3, 534);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel.SetRow(this.panelControl1, 3);
            this.panelControl1.Size = new System.Drawing.Size(1079, 31);
            this.panelControl1.TabIndex = 0;
            // 
            // searchControl1
            // 
            this.searchControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchControl1.Client = this.grdMayPro;
            this.searchControl1.Location = new System.Drawing.Point(1, 10);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.grdMayPro;
            this.searchControl1.Size = new System.Drawing.Size(201, 20);
            this.searchControl1.TabIndex = 11;
            // 
            // btnALL
            // 
            this.btnALL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnALL.Location = new System.Drawing.Point(660, 1);
            this.btnALL.Name = "btnALL";
            this.btnALL.Size = new System.Drawing.Size(104, 30);
            this.btnALL.TabIndex = 10;
            this.btnALL.Text = "btnALL";
            this.btnALL.Click += new System.EventHandler(this.btnALL_Click);
            // 
            // btnNotALL
            // 
            this.btnNotALL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotALL.Location = new System.Drawing.Point(765, 1);
            this.btnNotALL.Name = "btnNotALL";
            this.btnNotALL.Size = new System.Drawing.Size(104, 30);
            this.btnNotALL.TabIndex = 10;
            this.btnNotALL.Text = "btnNotALL";
            this.btnNotALL.Click += new System.EventHandler(this.btnNotALL_Click);
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
            // lblLoaiMay
            // 
            this.tablePanel.SetColumn(this.lblLoaiMay, 3);
            this.lblLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiMay.Location = new System.Drawing.Point(397, 3);
            this.lblLoaiMay.Name = "lblLoaiMay";
            this.tablePanel.SetRow(this.lblLoaiMay, 0);
            this.lblLoaiMay.Size = new System.Drawing.Size(94, 26);
            this.lblLoaiMay.TabIndex = 2;
            this.lblLoaiMay.Text = "lblLoaiMay";
            // 
            // lblTuNgay
            // 
            this.tablePanel.SetColumn(this.lblTuNgay, 1);
            this.lblTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTuNgay.Location = new System.Drawing.Point(101, 35);
            this.lblTuNgay.Name = "lblTuNgay";
            this.tablePanel.SetRow(this.lblTuNgay, 1);
            this.lblTuNgay.Size = new System.Drawing.Size(94, 26);
            this.lblTuNgay.TabIndex = 2;
            this.lblTuNgay.Text = "lblTuNgay";
            // 
            // lblDenNgay
            // 
            this.tablePanel.SetColumn(this.lblDenNgay, 3);
            this.lblDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDenNgay.Location = new System.Drawing.Point(397, 35);
            this.lblDenNgay.Name = "lblDenNgay";
            this.tablePanel.SetRow(this.lblDenNgay, 1);
            this.lblDenNgay.Size = new System.Drawing.Size(94, 26);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "lblDenNgay";
            // 
            // datDNgay
            // 
            this.tablePanel.SetColumn(this.datDNgay, 4);
            this.datDNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datDNgay.EditValue = null;
            this.datDNgay.Location = new System.Drawing.Point(497, 35);
            this.datDNgay.Name = "datDNgay";
            this.datDNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel.SetRow(this.datDNgay, 1);
            this.datDNgay.Size = new System.Drawing.Size(190, 20);
            this.datDNgay.TabIndex = 3;
            this.datDNgay.EditValueChanged += new System.EventHandler(this.cboDayChuyen_EditValueChanged);
            // 
            // cboCaBD
            // 
            this.tablePanel.SetColumn(this.cboCaBD, 6);
            this.cboCaBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCaBD.Location = new System.Drawing.Point(794, 3);
            this.cboCaBD.Name = "cboCaBD";
            this.cboCaBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCaBD.Properties.NullText = "";
            this.tablePanel.SetRow(this.cboCaBD, 0);
            this.cboCaBD.Size = new System.Drawing.Size(190, 20);
            this.cboCaBD.TabIndex = 4;
            this.cboCaBD.EditValueChanged += new System.EventHandler(this.cboDayChuyen_EditValueChanged);
            // 
            // lblCaBD
            // 
            this.tablePanel.SetColumn(this.lblCaBD, 5);
            this.lblCaBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaBD.Location = new System.Drawing.Point(694, 3);
            this.lblCaBD.Name = "lblCaBD";
            this.tablePanel.SetRow(this.lblCaBD, 0);
            this.lblCaBD.Size = new System.Drawing.Size(94, 26);
            this.lblCaBD.TabIndex = 2;
            this.lblCaBD.Text = "lblCaBD";
            // 
            // frmChoosePro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 568);
            this.Controls.Add(this.tablePanel);
            this.IconOptions.Image = global::VS.OEE.Properties.Resources.OEE;
            this.Name = "frmChoosePro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChoosePro";
            this.Load += new System.EventHandler(this.frmChooseDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel)).EndInit();
            this.tablePanel.ResumeLayout(false);
            this.tablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cheXemAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDayChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMayPro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMayPro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaBD.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdMayPro;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMayPro;
        private DevExpress.XtraEditors.SimpleButton btnALL;
        private DevExpress.XtraEditors.SimpleButton btnNotALL;
        private DevExpress.XtraEditors.SimpleButton btnThucHien;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.LabelControl lblDayChuyen;
        private DevExpress.XtraEditors.LabelControl lblLoaiMay;
        private DevExpress.XtraEditors.LabelControl lblTuNgay;
        private DevExpress.XtraEditors.LabelControl lblDenNgay;
        private DevExpress.XtraEditors.DateEdit datTNgay;
        private DevExpress.XtraEditors.DateEdit datDNgay;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiMay;
        private DevExpress.XtraEditors.TreeListLookUpEdit cboDayChuyen;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraEditors.CheckEdit cheXemAll;
        private DevExpress.XtraEditors.LookUpEdit cboCaBD;
        private DevExpress.XtraEditors.LabelControl lblCaBD;
    }
}