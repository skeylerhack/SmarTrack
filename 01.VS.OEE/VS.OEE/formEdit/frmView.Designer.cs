namespace VS.OEE
{
    partial class frmView
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
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnIN = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.txtTim = new DevExpress.XtraEditors.SearchControl();
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 68.98F)});
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.grdChung);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.tablePanel1.Size = new System.Drawing.Size(708, 444);
            this.tablePanel1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.panelControl1.Controls.Add(this.btnSua);
            this.panelControl1.Controls.Add(this.btnIN);
            this.panelControl1.Controls.Add(this.btnXoa);
            this.panelControl1.Controls.Add(this.txtTim);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Controls.Add(this.btnThem);
            this.panelControl1.Location = new System.Drawing.Point(3, 412);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 1);
            this.panelControl1.Size = new System.Drawing.Size(702, 29);
            this.panelControl1.TabIndex = 3;
            // 
            // btnIN
            // 
            this.btnIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIN.Location = new System.Drawing.Point(207, 2);
            this.btnIN.Name = "btnIN";
            this.btnIN.Size = new System.Drawing.Size(80, 26);
            this.btnIN.TabIndex = 0;
            this.btnIN.Text = "btnIN";
            this.btnIN.Visible = false;
            this.btnIN.Click += new System.EventHandler(this.btnIN_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(539, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 26);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtTim
            // 
            this.txtTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTim.Client = this.grdChung;
            this.txtTim.Location = new System.Drawing.Point(1, 7);
            this.txtTim.Name = "txtTim";
            this.txtTim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtTim.Properties.Client = this.grdChung;
            this.txtTim.Size = new System.Drawing.Size(200, 20);
            this.txtTim.TabIndex = 1;
            // 
            // grdChung
            // 
            this.tablePanel1.SetColumn(this.grdChung, 0);
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.Location = new System.Drawing.Point(3, 3);
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.tablePanel1.SetRow(this.grdChung, 0);
            this.grdChung.Size = new System.Drawing.Size(702, 403);
            this.grdChung.TabIndex = 2;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            // 
            // grvChung
            // 
            this.grvChung.DetailHeight = 574;
            this.grvChung.FixedLineWidth = 3;
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsView.ShowGroupPanel = false;
            this.grvChung.DoubleClick += new System.EventHandler(this.grvChung_DoubleClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(620, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(377, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 26);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(458, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 26);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(50, 50);
            this.AutoScrollMinSize = new System.Drawing.Size(50, 50);
            this.ClientSize = new System.Drawing.Size(708, 444);
            this.Controls.Add(this.tablePanel1);
            this.IconOptions.Image = global::VS.OEE.Properties.Resources.OEE;
            this.KeyPreview = true;
            this.Name = "frmView";
            this.Text = "frmView";
            this.Load += new System.EventHandler(this.frmView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SearchControl txtTim;
        private DevExpress.XtraEditors.SimpleButton btnIN;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSua;
    }
}

