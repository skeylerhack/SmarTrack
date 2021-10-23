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
            this.grdChung = new DevExpress.XtraGrid.GridControl();
            this.grvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtTim = new DevExpress.XtraEditors.SearchControl();
            this.btnIN = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 68.98F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 31.02F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 111F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 111F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 111F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 111F)});
            this.tablePanel1.Controls.Add(this.grdChung);
            this.tablePanel1.Controls.Add(this.txtTim);
            this.tablePanel1.Controls.Add(this.btnIN);
            this.tablePanel1.Controls.Add(this.btnThoat);
            this.tablePanel1.Controls.Add(this.btnXoa);
            this.tablePanel1.Controls.Add(this.btnThem);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 36F)});
            this.tablePanel1.Size = new System.Drawing.Size(708, 444);
            this.tablePanel1.TabIndex = 0;
            // 
            // grdChung
            // 
            this.tablePanel1.SetColumn(this.grdChung, 0);
            this.tablePanel1.SetColumnSpan(this.grdChung, 6);
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.Location = new System.Drawing.Point(13, 13);
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Name = "grdChung";
            this.tablePanel1.SetRow(this.grdChung, 0);
            this.grdChung.Size = new System.Drawing.Size(682, 382);
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
            // txtTim
            // 
            this.txtTim.Client = this.grdChung;
            this.tablePanel1.SetColumn(this.txtTim, 0);
            this.txtTim.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTim.Location = new System.Drawing.Point(13, 411);
            this.txtTim.Name = "txtTim";
            this.txtTim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtTim.Properties.Client = this.grdChung;
            this.tablePanel1.SetRow(this.txtTim, 1);
            this.txtTim.Size = new System.Drawing.Size(162, 20);
            this.txtTim.TabIndex = 1;
            // 
            // btnIN
            // 
            this.tablePanel1.SetColumn(this.btnIN, 4);
            this.btnIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIN.Location = new System.Drawing.Point(479, 401);
            this.btnIN.Name = "btnIN";
            this.tablePanel1.SetRow(this.btnIN, 1);
            this.btnIN.Size = new System.Drawing.Size(105, 30);
            this.btnIN.TabIndex = 0;
            this.btnIN.Text = "btnIN";
            this.btnIN.Click += new System.EventHandler(this.btnIN_Click);
            // 
            // btnThoat
            // 
            this.tablePanel1.SetColumn(this.btnThoat, 5);
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Location = new System.Drawing.Point(590, 401);
            this.btnThoat.Name = "btnThoat";
            this.tablePanel1.SetRow(this.btnThoat, 1);
            this.btnThoat.Size = new System.Drawing.Size(105, 30);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.tablePanel1.SetColumn(this.btnXoa, 3);
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXoa.Location = new System.Drawing.Point(368, 401);
            this.btnXoa.Name = "btnXoa";
            this.tablePanel1.SetRow(this.btnXoa, 1);
            this.btnXoa.Size = new System.Drawing.Size(105, 30);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.tablePanel1.SetColumn(this.btnThem, 2);
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThem.Location = new System.Drawing.Point(257, 401);
            this.btnThem.Name = "btnThem";
            this.tablePanel1.SetRow(this.btnThem, 1);
            this.btnThem.Size = new System.Drawing.Size(105, 30);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).EndInit();
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
    }
}

