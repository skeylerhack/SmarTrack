namespace VS.OEE
{
    partial class frmTarget
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
            this.lblNam = new DevExpress.XtraEditors.LabelControl();
            this.panelNN = new DevExpress.XtraEditors.PanelControl();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.btnLayMay = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.grdTarget = new DevExpress.XtraGrid.GridControl();
            this.grvTarget = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSearch = new DevExpress.XtraEditors.SearchControl();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.groDanhSachHieuXuatKPI = new DevExpress.XtraEditors.GroupControl();
            this.datNam = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groDanhSachHieuXuatKPI)).BeginInit();
            this.groDanhSachHieuXuatKPI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNam
            // 
            this.lblNam.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNam.Appearance.Options.UseFont = true;
            this.lblNam.Appearance.Options.UseTextOptions = true;
            this.lblNam.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblNam.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblNam, 2);
            this.panelChung.SetColumnSpan(this.lblNam, 2);
            this.lblNam.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNam.Location = new System.Drawing.Point(179, 11);
            this.lblNam.Name = "lblNam";
            this.panelChung.SetRow(this.lblNam, 1);
            this.lblNam.Size = new System.Drawing.Size(255, 19);
            this.lblNam.TabIndex = 1;
            this.lblNam.Text = "lblNam";
            // 
            // panelNN
            // 
            this.panelNN.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelNN.Appearance.Options.UseBackColor = true;
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelChung.SetColumn(this.panelNN, 2);
            this.panelChung.SetColumnSpan(this.panelNN, 6);
            this.panelNN.Controls.Add(this.btnCopy);
            this.panelNN.Controls.Add(this.btnLayMay);
            this.panelNN.Controls.Add(this.btnGhi);
            this.panelNN.Controls.Add(this.btnKhong);
            this.panelNN.Controls.Add(this.btnSua);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Controls.Add(this.btnXoa);
            this.panelNN.Location = new System.Drawing.Point(179, 518);
            this.panelNN.Name = "panelNN";
            this.panelChung.SetRow(this.panelNN, 4);
            this.panelNN.Size = new System.Drawing.Size(712, 31);
            this.panelNN.TabIndex = 6;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(292, 0);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(104, 30);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "btnCopy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnLayMay
            // 
            this.btnLayMay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLayMay.Location = new System.Drawing.Point(397, 0);
            this.btnLayMay.Name = "btnLayMay";
            this.btnLayMay.Size = new System.Drawing.Size(104, 30);
            this.btnLayMay.TabIndex = 5;
            this.btnLayMay.Text = "btnbtnLayMay";
            this.btnLayMay.Click += new System.EventHandler(this.btnbtnLayMay_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(503, 0);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(104, 30);
            this.btnGhi.TabIndex = 5;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Location = new System.Drawing.Point(608, 0);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(104, 30);
            this.btnKhong.TabIndex = 5;
            this.btnKhong.Text = "btnKhong";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(397, 0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(104, 30);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(608, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 30);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(502, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(104, 30);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // grdTarget
            // 
            this.grdTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTarget.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdTarget.Location = new System.Drawing.Point(2, 23);
            this.grdTarget.MainView = this.grvTarget;
            this.grdTarget.Margin = new System.Windows.Forms.Padding(2);
            this.grdTarget.Name = "grdTarget";
            this.grdTarget.Size = new System.Drawing.Size(884, 442);
            this.grdTarget.TabIndex = 7;
            this.grdTarget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTarget});
            this.grdTarget.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdTarget_ProcessGridKey);
            // 
            // grvTarget
            // 
            this.grvTarget.ColumnPanelRowHeight = 1;
            this.grvTarget.DetailHeight = 227;
            this.grvTarget.FixedLineWidth = 1;
            this.grvTarget.GridControl = this.grdTarget;
            this.grvTarget.Name = "grvTarget";
            this.grvTarget.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvTarget.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvTarget.OptionsCustomization.AllowFilter = false;
            this.grvTarget.OptionsCustomization.AllowRowSizing = true;
            this.grvTarget.OptionsCustomization.AllowSort = false;
            this.grvTarget.OptionsFind.FindDelay = 100;
            this.grvTarget.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvTarget.OptionsPrint.AllowMultilineHeaders = true;
            this.grvTarget.OptionsScrollAnnotations.ShowCustomAnnotations = DevExpress.Utils.DefaultBoolean.True;
            this.grvTarget.OptionsScrollAnnotations.ShowErrors = DevExpress.Utils.DefaultBoolean.True;
            this.grvTarget.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvTarget.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvTarget.OptionsView.RowAutoHeight = true;
            this.grvTarget.OptionsView.ShowGroupPanel = false;
            this.grvTarget.RowHeight = 1;
            this.grvTarget.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvTarget_RowStyle);
            // 
            // txtSearch
            // 
            this.txtSearch.Client = this.grdTarget;
            this.panelChung.SetColumn(this.txtSearch, 0);
            this.panelChung.SetColumnSpan(this.txtSearch, 2);
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSearch.EnterMoveNextControl = true;
            this.txtSearch.Location = new System.Drawing.Point(3, 529);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtSearch.Properties.Client = this.grdTarget;
            this.txtSearch.Properties.FindDelay = 100;
            this.panelChung.SetRow(this.txtSearch, 4);
            this.txtSearch.Size = new System.Drawing.Size(170, 20);
            this.txtSearch.TabIndex = 3;
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
            this.panelChung.Controls.Add(this.groDanhSachHieuXuatKPI);
            this.panelChung.Controls.Add(this.datNam);
            this.panelChung.Controls.Add(this.txtSearch);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.lblNam);
            this.panelChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChung.Location = new System.Drawing.Point(0, 0);
            this.panelChung.Name = "panelChung";
            this.panelChung.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 37F)});
            this.panelChung.Size = new System.Drawing.Size(894, 552);
            this.panelChung.TabIndex = 3;
            // 
            // groDanhSachHieuXuatKPI
            // 
            this.panelChung.SetColumn(this.groDanhSachHieuXuatKPI, 0);
            this.panelChung.SetColumnSpan(this.groDanhSachHieuXuatKPI, 8);
            this.groDanhSachHieuXuatKPI.Controls.Add(this.grdTarget);
            this.groDanhSachHieuXuatKPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groDanhSachHieuXuatKPI.Location = new System.Drawing.Point(3, 45);
            this.groDanhSachHieuXuatKPI.Name = "groDanhSachHieuXuatKPI";
            this.panelChung.SetRow(this.groDanhSachHieuXuatKPI, 3);
            this.groDanhSachHieuXuatKPI.Size = new System.Drawing.Size(888, 467);
            this.groDanhSachHieuXuatKPI.TabIndex = 9;
            this.groDanhSachHieuXuatKPI.Text = "groDanhSachHieuXuatKPI";
            // 
            // datNam
            // 
            this.panelChung.SetColumn(this.datNam, 4);
            this.datNam.EditValue = null;
            this.datNam.Location = new System.Drawing.Point(440, 11);
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
            this.datNam.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.datNam.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView;
            this.datNam.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            this.panelChung.SetRow(this.datNam, 1);
            this.datNam.Size = new System.Drawing.Size(135, 20);
            this.datNam.TabIndex = 8;
            this.datNam.EditValueChanged += new System.EventHandler(this.datNam_EditValueChanged);
            // 
            // frmTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 552);
            this.Controls.Add(this.panelChung);
            this.Name = "frmTarget";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTarget";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTarget_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groDanhSachHieuXuatKPI)).EndInit();
            this.groDanhSachHieuXuatKPI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNam.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblNam;
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.SearchControl txtSearch;
        private DevExpress.XtraGrid.GridControl grdTarget;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTarget;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.DateEdit datNam;
        private DevExpress.XtraEditors.SimpleButton btnLayMay;
        private DevExpress.XtraEditors.GroupControl groDanhSachHieuXuatKPI;
    }
}