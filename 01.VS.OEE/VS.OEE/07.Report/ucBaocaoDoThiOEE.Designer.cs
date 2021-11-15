namespace VS.OEE
{
    partial class ucBaocaoDoThiOEE
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
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboNhaXuong = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.groDoThiOEE = new DevExpress.XtraEditors.GroupControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.groChonMay = new DevExpress.XtraEditors.GroupControl();
            this.grdMayDTOEE = new DevExpress.XtraGrid.GridControl();
            this.grvMayDTOEE = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.datNam = new DevExpress.XtraEditors.DateEdit();
            this.lblNam = new DevExpress.XtraEditors.LabelControl();
            this.cboLoaiMay = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLoaiMay = new DevExpress.XtraEditors.LabelControl();
            this.lblDiaDiem = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhaXuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groDoThiOEE)).BeginInit();
            this.groDoThiOEE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groChonMay)).BeginInit();
            this.groChonMay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMayDTOEE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMayDTOEE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.panelChung.Controls.Add(this.gridControl1);
            this.panelChung.Controls.Add(this.cboNhaXuong);
            this.panelChung.Controls.Add(this.groDoThiOEE);
            this.panelChung.Controls.Add(this.groChonMay);
            this.panelChung.Controls.Add(this.datNam);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.lblNam);
            this.panelChung.Controls.Add(this.cboLoaiMay);
            this.panelChung.Controls.Add(this.lblLoaiMay);
            this.panelChung.Controls.Add(this.lblDiaDiem);
            this.panelChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChung.Location = new System.Drawing.Point(0, 0);
            this.panelChung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelChung.Name = "panelChung";
            this.panelChung.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 70F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.panelChung.Size = new System.Drawing.Size(986, 516);
            this.panelChung.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.panelChung.SetColumn(this.gridControl1, 7);
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(864, 52);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.panelChung.SetRow(this.gridControl1, 3);
            this.gridControl1.Size = new System.Drawing.Size(119, 111);
            this.gridControl1.TabIndex = 15;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Visible = false;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // cboNhaXuong
            // 
            this.panelChung.SetColumn(this.cboNhaXuong, 4);
            this.cboNhaXuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNhaXuong.EditValue = "";
            this.cboNhaXuong.Location = new System.Drawing.Point(493, 12);
            this.cboNhaXuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboNhaXuong.Name = "cboNhaXuong";
            this.cboNhaXuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhaXuong.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.panelChung.SetRow(this.cboNhaXuong, 1);
            this.cboNhaXuong.Size = new System.Drawing.Size(119, 20);
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
            // groDoThiOEE
            // 
            this.panelChung.SetColumn(this.groDoThiOEE, 0);
            this.panelChung.SetColumnSpan(this.groDoThiOEE, 8);
            this.groDoThiOEE.Controls.Add(this.chartControl1);
            this.groDoThiOEE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groDoThiOEE.Location = new System.Drawing.Point(3, 178);
            this.groDoThiOEE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groDoThiOEE.Name = "groDoThiOEE";
            this.panelChung.SetRow(this.groDoThiOEE, 4);
            this.groDoThiOEE.Size = new System.Drawing.Size(980, 299);
            this.groDoThiOEE.TabIndex = 13;
            this.groDoThiOEE.Text = "groDoThiOEE";
            // 
            // chartControl1
            // 
            this.chartControl1.AutoLayout = false;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(2, 22);
            this.chartControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl1.Size = new System.Drawing.Size(976, 275);
            this.chartControl1.TabIndex = 0;
            // 
            // groChonMay
            // 
            this.panelChung.SetColumn(this.groChonMay, 1);
            this.panelChung.SetColumnSpan(this.groChonMay, 6);
            this.groChonMay.Controls.Add(this.grdMayDTOEE);
            this.groChonMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groChonMay.Location = new System.Drawing.Point(128, 46);
            this.groChonMay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groChonMay.Name = "groChonMay";
            this.panelChung.SetRow(this.groChonMay, 3);
            this.groChonMay.Size = new System.Drawing.Size(730, 124);
            this.groChonMay.TabIndex = 11;
            this.groChonMay.Text = "groChonMay";
            // 
            // grdMayDTOEE
            // 
            this.grdMayDTOEE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMayDTOEE.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdMayDTOEE.Location = new System.Drawing.Point(2, 22);
            this.grdMayDTOEE.MainView = this.grvMayDTOEE;
            this.grdMayDTOEE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdMayDTOEE.Name = "grdMayDTOEE";
            this.grdMayDTOEE.Size = new System.Drawing.Size(726, 100);
            this.grdMayDTOEE.TabIndex = 2;
            this.grdMayDTOEE.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMayDTOEE});
            // 
            // grvMayDTOEE
            // 
            this.grvMayDTOEE.GridControl = this.grdMayDTOEE;
            this.grvMayDTOEE.Name = "grvMayDTOEE";
            this.grvMayDTOEE.OptionsSelection.MultiSelect = true;
            this.grvMayDTOEE.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvMayDTOEE.OptionsView.ShowGroupPanel = false;
            this.grvMayDTOEE.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvMayDTOEE_SelectionChanged);
            this.grvMayDTOEE.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvMayDTOEE_CellValueChanged);
            // 
            // datNam
            // 
            this.panelChung.SetColumn(this.datNam, 2);
            this.datNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datNam.EditValue = null;
            this.datNam.Location = new System.Drawing.Point(248, 12);
            this.datNam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.datNam.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView;
            this.datNam.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            this.panelChung.SetRow(this.datNam, 1);
            this.datNam.Size = new System.Drawing.Size(119, 20);
            this.datNam.TabIndex = 9;
            this.datNam.EditValueChanged += new System.EventHandler(this.datNam_EditValueChanged);
            // 
            // lblNam
            // 
            this.lblNam.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblNam, 1);
            this.lblNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNam.Location = new System.Drawing.Point(128, 12);
            this.lblNam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblNam.Name = "lblNam";
            this.panelChung.SetRow(this.lblNam, 1);
            this.lblNam.Size = new System.Drawing.Size(114, 18);
            this.lblNam.TabIndex = 1;
            this.lblNam.Text = "lblNam";
            // 
            // cboLoaiMay
            // 
            this.panelChung.SetColumn(this.cboLoaiMay, 6);
            this.cboLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLoaiMay.Location = new System.Drawing.Point(739, 12);
            this.cboLoaiMay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboLoaiMay.Name = "cboLoaiMay";
            this.cboLoaiMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiMay.Properties.NullText = "";
            this.panelChung.SetRow(this.cboLoaiMay, 1);
            this.cboLoaiMay.Size = new System.Drawing.Size(119, 20);
            this.cboLoaiMay.TabIndex = 10;
            this.cboLoaiMay.EditValueChanged += new System.EventHandler(this.cboNhaXuong_EditValueChanged);
            // 
            // lblLoaiMay
            // 
            this.lblLoaiMay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblLoaiMay, 5);
            this.lblLoaiMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiMay.Location = new System.Drawing.Point(619, 12);
            this.lblLoaiMay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblLoaiMay.Name = "lblLoaiMay";
            this.panelChung.SetRow(this.lblLoaiMay, 1);
            this.lblLoaiMay.Size = new System.Drawing.Size(114, 18);
            this.lblLoaiMay.TabIndex = 1;
            this.lblLoaiMay.Text = "lblLoaiMay";
            // 
            // lblDiaDiem
            // 
            this.lblDiaDiem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblDiaDiem, 3);
            this.lblDiaDiem.Location = new System.Drawing.Point(373, 12);
            this.lblDiaDiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDiaDiem.Name = "lblDiaDiem";
            this.panelChung.SetRow(this.lblDiaDiem, 1);
            this.lblDiaDiem.Size = new System.Drawing.Size(114, 18);
            this.lblDiaDiem.TabIndex = 1;
            this.lblDiaDiem.Text = "lblDiaDiem";
            // 
            // ucBaocaoDoThiOEE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelChung);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucBaocaoDoThiOEE";
            this.Size = new System.Drawing.Size(986, 516);
            this.Load += new System.EventHandler(this.ucBaocaoDoThiOEE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhaXuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groDoThiOEE)).EndInit();
            this.groDoThiOEE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groChonMay)).EndInit();
            this.groChonMay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMayDTOEE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMayDTOEE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiMay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.LabelControl lblNam;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.DateEdit datNam;
        private DevExpress.XtraEditors.GroupControl groChonMay;
        private DevExpress.XtraEditors.GroupControl groDoThiOEE;
        private DevExpress.XtraGrid.GridControl grdMayDTOEE;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMayDTOEE;
        private DevExpress.XtraEditors.TreeListLookUpEdit cboNhaXuong;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiMay;
        private DevExpress.XtraEditors.LabelControl lblLoaiMay;
        private DevExpress.XtraEditors.LabelControl lblDiaDiem;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
