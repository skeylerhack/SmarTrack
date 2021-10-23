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
            this.lblNhom = new System.Windows.Forms.Label();
            this.cboNhom = new System.Windows.Forms.ComboBox();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiResetPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiKick = new System.Windows.Forms.ToolStripMenuItem();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtTim = new DevExpress.XtraEditors.SearchControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 150F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 150F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 150F)});
            this.tablePanel1.Controls.Add(this.lblNhom);
            this.tablePanel1.Controls.Add(this.cboNhom);
            this.tablePanel1.Controls.Add(this.grdChung);
            this.tablePanel1.Controls.Add(this.txtTim);
            this.tablePanel1.Controls.Add(this.btnThoat);
            this.tablePanel1.Controls.Add(this.btnXoa);
            this.tablePanel1.Controls.Add(this.btnThem);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 45F)});
            this.tablePanel1.Size = new System.Drawing.Size(994, 668);
            this.tablePanel1.TabIndex = 1;
            // 
            // lblNhom
            // 
            this.lblNhom.AutoSize = true;
            this.tablePanel1.SetColumn(this.lblNhom, 1);
            this.lblNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhom.Location = new System.Drawing.Point(203, 0);
            this.lblNhom.Name = "lblNhom";
            this.tablePanel1.SetRow(this.lblNhom, 0);
            this.lblNhom.Size = new System.Drawing.Size(238, 35);
            this.lblNhom.TabIndex = 4;
            this.lblNhom.Text = "lblNhom";
            this.lblNhom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboNhom
            // 
            this.tablePanel1.SetColumn(this.cboNhom, 2);
            this.tablePanel1.SetColumnSpan(this.cboNhom, 2);
            this.cboNhom.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboNhom.FormattingEnabled = true;
            this.cboNhom.Location = new System.Drawing.Point(447, 3);
            this.cboNhom.Name = "cboNhom";
            this.tablePanel1.SetRow(this.cboNhom, 0);
            this.cboNhom.Size = new System.Drawing.Size(150, 29);
            this.cboNhom.TabIndex = 3;
            this.cboNhom.SelectedIndexChanged += new System.EventHandler(this.cboNhom_SelectedIndexChanged);
            // 
            // grdChung
            // 
            this.tablePanel1.SetColumn(this.grdChung, 0);
            this.tablePanel1.SetColumnSpan(this.grdChung, 6);
            this.grdChung.ContextMenuStrip = this.contextMenuStrip;
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.Location = new System.Drawing.Point(3, 38);
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.tablePanel1.SetRow(this.grdChung, 1);
            this.grdChung.Size = new System.Drawing.Size(988, 582);
            this.grdChung.TabIndex = 2;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            this.grdChung.DoubleClick += new System.EventHandler(this.grdChung_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiResetPassword,
            this.tsmiKick});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(254, 76);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            this.contextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ItemClicked);
            // 
            // tsmiResetPassword
            // 
            this.tsmiResetPassword.Name = "tsmiResetPassword";
            this.tsmiResetPassword.Size = new System.Drawing.Size(253, 36);
            this.tsmiResetPassword.Text = "Reset password";
            // 
            // tsmiKick
            // 
            this.tsmiKick.Name = "tsmiKick";
            this.tsmiKick.Size = new System.Drawing.Size(253, 36);
            this.tsmiKick.Text = "Kick";
            // 
            // grvChung
            // 
            this.grvChung.DetailHeight = 565;
            this.grvChung.FixedLineWidth = 3;
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsView.ShowGroupPanel = false;
            // 
            // txtTim
            // 
            this.txtTim.Client = this.grdChung;
            this.tablePanel1.SetColumn(this.txtTim, 0);
            this.txtTim.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTim.Location = new System.Drawing.Point(3, 637);
            this.txtTim.Name = "txtTim";
            this.txtTim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtTim.Properties.Client = this.grdChung;
            this.tablePanel1.SetRow(this.txtTim, 2);
            this.txtTim.Size = new System.Drawing.Size(194, 28);
            this.txtTim.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.tablePanel1.SetColumn(this.btnThoat, 5);
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Location = new System.Drawing.Point(847, 626);
            this.btnThoat.Name = "btnThoat";
            this.tablePanel1.SetRow(this.btnThoat, 2);
            this.btnThoat.Size = new System.Drawing.Size(144, 39);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.tablePanel1.SetColumn(this.btnXoa, 4);
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXoa.Location = new System.Drawing.Point(697, 626);
            this.btnXoa.Name = "btnXoa";
            this.tablePanel1.SetRow(this.btnXoa, 2);
            this.btnXoa.Size = new System.Drawing.Size(144, 39);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.tablePanel1.SetColumn(this.btnThem, 3);
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThem.Location = new System.Drawing.Point(547, 626);
            this.btnThem.Name = "btnThem";
            this.tablePanel1.SetRow(this.btnThem, 2);
            this.btnThem.Size = new System.Drawing.Size(144, 39);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // frmNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 668);
            this.Controls.Add(this.tablePanel1);
            this.Name = "frmNguoiDung";
            this.Text = "frmQuanLyNguoiDung";
            this.Load += new System.EventHandler(this.frmNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).EndInit();
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
        private System.Windows.Forms.Label lblNhom;
        private System.Windows.Forms.ComboBox cboNhom;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
    }
}