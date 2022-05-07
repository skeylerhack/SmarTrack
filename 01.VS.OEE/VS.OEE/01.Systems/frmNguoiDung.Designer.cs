namespace VS.OEE
{
    partial class frmNguoiDung
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
            this.components = new System.ComponentModel.Container();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.lblNhom = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.txtTim = new DevExpress.XtraEditors.SearchControl();
            this.grdNguoiDung = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiResetPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiKick = new System.Windows.Forms.ToolStripMenuItem();
            this.grvNguoiDung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboNhom = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNguoiDung)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvNguoiDung)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel1.Controls.Add(this.lblNhom);
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.cboNhom);
            this.tablePanel1.Controls.Add(this.grdNguoiDung);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.tablePanel1.Size = new System.Drawing.Size(884, 471);
            this.tablePanel1.TabIndex = 1;
            // 
            // lblNhom
            // 
            this.tablePanel1.SetColumn(this.lblNhom, 1);
            this.lblNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhom.Location = new System.Drawing.Point(258, 11);
            this.lblNhom.Name = "lblNhom";
            this.tablePanel1.SetRow(this.lblNhom, 1);
            this.lblNhom.Size = new System.Drawing.Size(114, 20);
            this.lblNhom.TabIndex = 6;
            this.lblNhom.Text = "lblNhom";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.tablePanel1.SetColumnSpan(this.panelControl1, 4);
            this.panelControl1.Controls.Add(this.btnXoa);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Controls.Add(this.btnSua);
            this.panelControl1.Controls.Add(this.btnThem);
            this.panelControl1.Controls.Add(this.txtTim);
            this.panelControl1.Location = new System.Drawing.Point(3, 439);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 3);
            this.panelControl1.Size = new System.Drawing.Size(878, 29);
            this.panelControl1.TabIndex = 5;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(717, 1);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 26);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(798, 1);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(636, 1);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 26);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(555, 1);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 26);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTim
            // 
            this.txtTim.Client = this.grdNguoiDung;
            this.txtTim.Location = new System.Drawing.Point(0, 9);
            this.txtTim.Margin = new System.Windows.Forms.Padding(2);
            this.txtTim.Name = "txtTim";
            this.txtTim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtTim.Properties.Client = this.grdNguoiDung;
            this.txtTim.Properties.FindDelay = 100;
            this.txtTim.Size = new System.Drawing.Size(178, 20);
            this.txtTim.TabIndex = 1;
            // 
            // grdNguoiDung
            // 
            this.tablePanel1.SetColumn(this.grdNguoiDung, 0);
            this.tablePanel1.SetColumnSpan(this.grdNguoiDung, 4);
            this.grdNguoiDung.ContextMenuStrip = this.contextMenuStrip;
            this.grdNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNguoiDung.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdNguoiDung.Location = new System.Drawing.Point(2, 36);
            this.grdNguoiDung.MainView = this.grvNguoiDung;
            this.grdNguoiDung.Margin = new System.Windows.Forms.Padding(2);
            this.grdNguoiDung.Name = "grdNguoiDung";
            this.tablePanel1.SetRow(this.grdNguoiDung, 2);
            this.grdNguoiDung.Size = new System.Drawing.Size(880, 398);
            this.grdNguoiDung.TabIndex = 2;
            this.grdNguoiDung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNguoiDung});
            this.grdNguoiDung.DoubleClick += new System.EventHandler(this.grdChung_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiResetPassword,
            this.tsmiKick});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(190, 56);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            this.contextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ItemClicked);
            // 
            // tsmiResetPassword
            // 
            this.tsmiResetPassword.Name = "tsmiResetPassword";
            this.tsmiResetPassword.Size = new System.Drawing.Size(189, 26);
            this.tsmiResetPassword.Text = "Reset password";
            // 
            // tsmiKick
            // 
            this.tsmiKick.Name = "tsmiKick";
            this.tsmiKick.Size = new System.Drawing.Size(189, 26);
            this.tsmiKick.Text = "Kick";
            // 
            // grvNguoiDung
            // 
            this.grvNguoiDung.GridControl = this.grdNguoiDung;
            this.grvNguoiDung.Name = "grvNguoiDung";
            this.grvNguoiDung.OptionsView.ShowGroupPanel = false;
            this.grvNguoiDung.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvNguoiDung_RowCellStyle);
            // 
            // cboNhom
            // 
            this.tablePanel1.SetColumn(this.cboNhom, 2);
            this.cboNhom.FormattingEnabled = true;
            this.cboNhom.Location = new System.Drawing.Point(377, 10);
            this.cboNhom.Margin = new System.Windows.Forms.Padding(2);
            this.cboNhom.Name = "cboNhom";
            this.tablePanel1.SetRow(this.cboNhom, 1);
            this.cboNhom.Size = new System.Drawing.Size(251, 21);
            this.cboNhom.TabIndex = 3;
            this.cboNhom.SelectedIndexChanged += new System.EventHandler(this.cboNhom_SelectedIndexChanged);
            // 
            // frmNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 471);
            this.Controls.Add(this.tablePanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmNguoiDung";
            this.Text = "frmQuanLyNguoiDung";
            this.Load += new System.EventHandler(this.frmNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNguoiDung)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvNguoiDung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SearchControl txtTim;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiResetPassword;
        private System.Windows.Forms.ToolStripMenuItem tsmiKick;
        private System.Windows.Forms.ComboBox cboNhom;
        private DevExpress.XtraGrid.GridControl grdNguoiDung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNguoiDung;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblNhom;
        private DevExpress.XtraEditors.SimpleButton btnSua;
    }
}