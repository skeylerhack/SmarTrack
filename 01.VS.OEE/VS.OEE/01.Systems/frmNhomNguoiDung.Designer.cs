namespace VS.OEE
{
    partial class frmNhomNguoiDung 
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
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.lblGroupName = new DevExpress.XtraEditors.LabelControl();
            this.txtDownTimeType = new DevExpress.XtraEditors.TextEdit();
            this.panelNN = new DevExpress.XtraEditors.PanelControl();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearch = new DevExpress.XtraEditors.SearchControl();
            this.grdNhomNguoiDung = new DevExpress.XtraGrid.GridControl();
            this.grvNhomNguoiDung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDownTimeType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNhomNguoiDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhomNguoiDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNote
            // 
            this.lblNote.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblNote, 3);
            this.lblNote.Location = new System.Drawing.Point(389, 11);
            this.lblNote.Name = "lblNote";
            this.panelChung.SetRow(this.lblNote, 1);
            this.lblNote.Size = new System.Drawing.Size(114, 19);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "lblNote";
            // 
            // lblGroupName
            // 
            this.lblGroupName.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupName.Appearance.Options.UseFont = true;
            this.lblGroupName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblGroupName, 1);
            this.lblGroupName.Location = new System.Drawing.Point(79, 11);
            this.lblGroupName.Name = "lblGroupName";
            this.panelChung.SetRow(this.lblGroupName, 1);
            this.lblGroupName.Size = new System.Drawing.Size(114, 19);
            this.lblGroupName.TabIndex = 1;
            this.lblGroupName.Text = "lblGroupName";
            // 
            // txtDownTimeType
            // 
            this.panelChung.SetColumn(this.txtDownTimeType, 2);
            this.txtDownTimeType.EnterMoveNextControl = true;
            this.txtDownTimeType.Location = new System.Drawing.Point(199, 11);
            this.txtDownTimeType.Name = "txtDownTimeType";
            this.panelChung.SetRow(this.txtDownTimeType, 1);
            this.txtDownTimeType.Size = new System.Drawing.Size(184, 20);
            this.txtDownTimeType.TabIndex = 0;
            // 
            // panelNN
            // 
            this.panelNN.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelNN.Appearance.Options.UseBackColor = true;
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelChung.SetColumn(this.panelNN, 0);
            this.panelChung.SetColumnSpan(this.panelNN, 6);
            this.panelNN.Controls.Add(this.btnSua);
            this.panelNN.Controls.Add(this.txtSearch);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Controls.Add(this.btnThem);
            this.panelNN.Controls.Add(this.btnXoa);
            this.panelNN.Controls.Add(this.btnGhi);
            this.panelNN.Controls.Add(this.btnKhong);
            this.panelNN.Location = new System.Drawing.Point(3, 442);
            this.panelNN.Name = "panelNN";
            this.panelChung.SetRow(this.panelNN, 4);
            this.panelNN.Size = new System.Drawing.Size(957, 29);
            this.panelNN.TabIndex = 6;
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(715, 1);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 26);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.Client = this.grdNhomNguoiDung;
            this.txtSearch.EnterMoveNextControl = true;
            this.txtSearch.Location = new System.Drawing.Point(2, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtSearch.Properties.Client = this.grdNhomNguoiDung;
            this.txtSearch.Properties.FindDelay = 100;
            this.txtSearch.Size = new System.Drawing.Size(187, 20);
            this.txtSearch.TabIndex = 3;
            // 
            // grdNhomNguoiDung
            // 
            this.panelChung.SetColumn(this.grdNhomNguoiDung, 0);
            this.panelChung.SetColumnSpan(this.grdNhomNguoiDung, 6);
            this.grdNhomNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNhomNguoiDung.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdNhomNguoiDung.Location = new System.Drawing.Point(2, 44);
            this.grdNhomNguoiDung.MainView = this.grvNhomNguoiDung;
            this.grdNhomNguoiDung.Margin = new System.Windows.Forms.Padding(2);
            this.grdNhomNguoiDung.Name = "grdNhomNguoiDung";
            this.panelChung.SetRow(this.grdNhomNguoiDung, 3);
            this.grdNhomNguoiDung.Size = new System.Drawing.Size(959, 393);
            this.grdNhomNguoiDung.TabIndex = 7;
            this.grdNhomNguoiDung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNhomNguoiDung,
            this.gridView1});
            this.grdNhomNguoiDung.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdDownTimeType_ProcessGridKey);
            // 
            // grvNhomNguoiDung
            // 
            this.grvNhomNguoiDung.ColumnPanelRowHeight = 1;
            this.grvNhomNguoiDung.DetailHeight = 227;
            this.grvNhomNguoiDung.FixedLineWidth = 1;
            this.grvNhomNguoiDung.GridControl = this.grdNhomNguoiDung;
            this.grvNhomNguoiDung.Name = "grvNhomNguoiDung";
            this.grvNhomNguoiDung.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvNhomNguoiDung.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvNhomNguoiDung.OptionsCustomization.AllowRowSizing = true;
            this.grvNhomNguoiDung.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel;
            this.grvNhomNguoiDung.OptionsFind.FindDelay = 100;
            this.grvNhomNguoiDung.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvNhomNguoiDung.OptionsPrint.AllowMultilineHeaders = true;
            this.grvNhomNguoiDung.OptionsScrollAnnotations.ShowCustomAnnotations = DevExpress.Utils.DefaultBoolean.True;
            this.grvNhomNguoiDung.OptionsScrollAnnotations.ShowErrors = DevExpress.Utils.DefaultBoolean.True;
            this.grvNhomNguoiDung.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvNhomNguoiDung.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvNhomNguoiDung.OptionsView.RowAutoHeight = true;
            this.grvNhomNguoiDung.OptionsView.ShowGroupPanel = false;
            this.grvNhomNguoiDung.RowHeight = 1;
            this.grvNhomNguoiDung.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvChung_FocusedRowChanged);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdNhomNguoiDung;
            this.gridView1.Name = "gridView1";
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(877, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(634, 1);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 26);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(796, 1);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 26);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(796, 1);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 5;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Location = new System.Drawing.Point(877, 1);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(80, 26);
            this.btnKhong.TabIndex = 5;
            this.btnKhong.Text = "btnKhong";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // txtID
            // 
            this.panelChung.SetColumn(this.txtID, 0);
            this.txtID.Location = new System.Drawing.Point(3, 11);
            this.txtID.Name = "txtID";
            this.panelChung.SetRow(this.txtID, 1);
            this.txtID.Size = new System.Drawing.Size(70, 20);
            this.txtID.TabIndex = 0;
            this.txtID.Visible = false;
            // 
            // panelChung
            // 
            this.panelChung.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F)});
            this.panelChung.Controls.Add(this.txtID);
            this.panelChung.Controls.Add(this.grdNhomNguoiDung);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.txtDownTimeType);
            this.panelChung.Controls.Add(this.lblGroupName);
            this.panelChung.Controls.Add(this.lblNote);
            this.panelChung.Controls.Add(this.txtNote);
            this.panelChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChung.Location = new System.Drawing.Point(0, 0);
            this.panelChung.Name = "panelChung";
            this.panelChung.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.panelChung.Size = new System.Drawing.Size(963, 474);
            this.panelChung.TabIndex = 2;
            // 
            // txtNote
            // 
            this.panelChung.SetColumn(this.txtNote, 4);
            this.txtNote.EnterMoveNextControl = true;
            this.txtNote.Location = new System.Drawing.Point(509, 11);
            this.txtNote.Name = "txtNote";
            this.panelChung.SetRow(this.txtNote, 1);
            this.txtNote.Size = new System.Drawing.Size(375, 20);
            this.txtNote.TabIndex = 0;
            // 
            // frmNhomNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 474);
            this.Controls.Add(this.panelChung);
            this.Name = "frmNhomNguoiDung";
            this.Text = "frmDownTimeType";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDownTimeType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDownTimeType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNhomNguoiDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhomNguoiDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.SearchControl txtSearch;
        private DevExpress.XtraGrid.GridControl grdNhomNguoiDung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNhomNguoiDung;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.TextEdit txtDownTimeType;
        private DevExpress.XtraEditors.LabelControl lblGroupName;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.TextEdit txtNote;
    }
}
