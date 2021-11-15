namespace VS.OEE
{
    partial class frmOperator
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
            this.txtOperatorName = new DevExpress.XtraEditors.TextEdit();
            this.txtOperatorCode = new DevExpress.XtraEditors.TextEdit();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.lblOperatorName = new DevExpress.XtraEditors.LabelControl();
            this.panelNN = new DevExpress.XtraEditors.PanelControl();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.grdOperator = new DevExpress.XtraGrid.GridControl();
            this.grvOperator = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSearch = new DevExpress.XtraEditors.SearchControl();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.lblOperatorCode = new DevExpress.XtraEditors.LabelControl();
            this.lblCardID = new DevExpress.XtraEditors.LabelControl();
            this.txtCardID = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOperatorName
            // 
            this.panelChung.SetColumn(this.txtOperatorName, 4);
            this.txtOperatorName.EnterMoveNextControl = true;
            this.txtOperatorName.Location = new System.Drawing.Point(465, 11);
            this.txtOperatorName.Name = "txtOperatorName";
            this.panelChung.SetRow(this.txtOperatorName, 1);
            this.txtOperatorName.Size = new System.Drawing.Size(153, 20);
            this.txtOperatorName.TabIndex = 1;
            // 
            // txtOperatorCode
            // 
            this.panelChung.SetColumn(this.txtOperatorCode, 2);
            this.txtOperatorCode.EnterMoveNextControl = true;
            this.txtOperatorCode.Location = new System.Drawing.Point(186, 11);
            this.txtOperatorCode.Name = "txtOperatorCode";
            this.panelChung.SetRow(this.txtOperatorCode, 1);
            this.txtOperatorCode.Size = new System.Drawing.Size(153, 20);
            this.txtOperatorCode.TabIndex = 0;
            // 
            // lblNote
            // 
            this.lblNote.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblNote, 1);
            this.lblNote.Location = new System.Drawing.Point(66, 37);
            this.lblNote.Name = "lblNote";
            this.panelChung.SetRow(this.lblNote, 2);
            this.lblNote.Size = new System.Drawing.Size(114, 19);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "lblNote";
            // 
            // txtNote
            // 
            this.panelChung.SetColumn(this.txtNote, 2);
            this.panelChung.SetColumnSpan(this.txtNote, 5);
            this.txtNote.EnterMoveNextControl = true;
            this.txtNote.Location = new System.Drawing.Point(186, 37);
            this.txtNote.Name = "txtNote";
            this.txtNote.Properties.MaxLength = 500;
            this.panelChung.SetRow(this.txtNote, 2);
            this.txtNote.Size = new System.Drawing.Size(711, 20);
            this.txtNote.TabIndex = 3;
            // 
            // lblOperatorName
            // 
            this.lblOperatorName.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorName.Appearance.Options.UseFont = true;
            this.lblOperatorName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblOperatorName, 3);
            this.lblOperatorName.Location = new System.Drawing.Point(345, 11);
            this.lblOperatorName.Name = "lblOperatorName";
            this.panelChung.SetRow(this.lblOperatorName, 1);
            this.lblOperatorName.Size = new System.Drawing.Size(114, 19);
            this.lblOperatorName.TabIndex = 1;
            this.lblOperatorName.Text = "lblOperatorName";
            // 
            // panelNN
            // 
            this.panelNN.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelNN.Appearance.Options.UseBackColor = true;
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelChung.SetColumn(this.panelNN, 0);
            this.panelChung.SetColumnSpan(this.panelNN, 8);
            this.panelNN.Controls.Add(this.btnSua);
            this.panelNN.Controls.Add(this.txtSearch);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Controls.Add(this.btnThem);
            this.panelNN.Controls.Add(this.btnXoa);
            this.panelNN.Controls.Add(this.btnGhi);
            this.panelNN.Controls.Add(this.btnKhong);
            this.panelNN.Location = new System.Drawing.Point(3, 442);
            this.panelNN.Name = "panelNN";
            this.panelChung.SetRow(this.panelNN, 5);
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
            // grdOperator
            // 
            this.panelChung.SetColumn(this.grdOperator, 0);
            this.panelChung.SetColumnSpan(this.grdOperator, 8);
            this.grdOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOperator.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdOperator.Location = new System.Drawing.Point(2, 70);
            this.grdOperator.MainView = this.grvOperator;
            this.grdOperator.Margin = new System.Windows.Forms.Padding(2);
            this.grdOperator.Name = "grdOperator";
            this.panelChung.SetRow(this.grdOperator, 4);
            this.grdOperator.Size = new System.Drawing.Size(959, 367);
            this.grdOperator.TabIndex = 7;
            this.grdOperator.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOperator,
            this.gridView1});
            this.grdOperator.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdChung_ProcessGridKey);
            // 
            // grvOperator
            // 
            this.grvOperator.ColumnPanelRowHeight = 1;
            this.grvOperator.DetailHeight = 227;
            this.grvOperator.FixedLineWidth = 1;
            this.grvOperator.GridControl = this.grdOperator;
            this.grvOperator.Name = "grvOperator";
            this.grvOperator.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvOperator.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvOperator.OptionsCustomization.AllowRowSizing = true;
            this.grvOperator.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel;
            this.grvOperator.OptionsFind.FindDelay = 100;
            this.grvOperator.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvOperator.OptionsPrint.AllowMultilineHeaders = true;
            this.grvOperator.OptionsScrollAnnotations.ShowCustomAnnotations = DevExpress.Utils.DefaultBoolean.True;
            this.grvOperator.OptionsScrollAnnotations.ShowErrors = DevExpress.Utils.DefaultBoolean.True;
            this.grvOperator.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvOperator.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvOperator.OptionsView.RowAutoHeight = true;
            this.grvOperator.OptionsView.ShowGroupPanel = false;
            this.grvOperator.RowHeight = 1;
            this.grvOperator.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvChung_FocusedRowChanged);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdOperator;
            this.gridView1.Name = "gridView1";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.Client = this.grdOperator;
            this.txtSearch.EnterMoveNextControl = true;
            this.txtSearch.Location = new System.Drawing.Point(2, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtSearch.Properties.Client = this.grdOperator;
            this.txtSearch.Properties.FindDelay = 100;
            this.txtSearch.Size = new System.Drawing.Size(150, 20);
            this.txtSearch.TabIndex = 3;
            // 
            // txtID
            // 
            this.panelChung.SetColumn(this.txtID, 0);
            this.txtID.Location = new System.Drawing.Point(3, 11);
            this.txtID.Name = "txtID";
            this.panelChung.SetRow(this.txtID, 1);
            this.txtID.Size = new System.Drawing.Size(57, 20);
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
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F)});
            this.panelChung.Controls.Add(this.txtID);
            this.panelChung.Controls.Add(this.grdOperator);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.txtOperatorName);
            this.panelChung.Controls.Add(this.lblOperatorName);
            this.panelChung.Controls.Add(this.txtNote);
            this.panelChung.Controls.Add(this.lblNote);
            this.panelChung.Controls.Add(this.lblOperatorCode);
            this.panelChung.Controls.Add(this.lblCardID);
            this.panelChung.Controls.Add(this.txtOperatorCode);
            this.panelChung.Controls.Add(this.txtCardID);
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
            this.panelChung.Size = new System.Drawing.Size(963, 474);
            this.panelChung.TabIndex = 2;
            // 
            // lblOperatorCode
            // 
            this.lblOperatorCode.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatorCode.Appearance.Options.UseFont = true;
            this.lblOperatorCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblOperatorCode, 1);
            this.lblOperatorCode.Location = new System.Drawing.Point(66, 11);
            this.lblOperatorCode.Name = "lblOperatorCode";
            this.panelChung.SetRow(this.lblOperatorCode, 1);
            this.lblOperatorCode.Size = new System.Drawing.Size(114, 19);
            this.lblOperatorCode.TabIndex = 1;
            this.lblOperatorCode.Text = "lblOperatorCode";
            // 
            // lblCardID
            // 
            this.lblCardID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblCardID, 5);
            this.lblCardID.Location = new System.Drawing.Point(624, 11);
            this.lblCardID.Name = "lblCardID";
            this.panelChung.SetRow(this.lblCardID, 1);
            this.lblCardID.Size = new System.Drawing.Size(114, 19);
            this.lblCardID.TabIndex = 1;
            this.lblCardID.Text = "lblCardID";
            // 
            // txtCardID
            // 
            this.panelChung.SetColumn(this.txtCardID, 6);
            this.txtCardID.Location = new System.Drawing.Point(744, 11);
            this.txtCardID.Name = "txtCardID";
            this.panelChung.SetRow(this.txtCardID, 1);
            this.txtCardID.Size = new System.Drawing.Size(153, 20);
            this.txtCardID.TabIndex = 2;
            // 
            // frmOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 474);
            this.Controls.Add(this.panelChung);
            this.Name = "frmOperator";
            this.Text = "frmOperator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmItemGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCardID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.SearchControl txtSearch;
        private DevExpress.XtraGrid.GridControl grdOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView grvOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.TextEdit txtOperatorName;
        private DevExpress.XtraEditors.LabelControl lblOperatorName;
        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraEditors.LabelControl lblOperatorCode;
        private DevExpress.XtraEditors.LabelControl lblCardID;
        private DevExpress.XtraEditors.TextEdit txtOperatorCode;
        private DevExpress.XtraEditors.TextEdit txtCardID;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
    }
}
