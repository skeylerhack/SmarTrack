namespace VS.OEE
{
    partial class frmNNgu
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
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
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
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 155F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 155F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 155F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 155F)});
            this.tablePanel1.Controls.Add(this.grdChung);
            this.tablePanel1.Controls.Add(this.txtTim);
            this.tablePanel1.Controls.Add(this.btnGhi);
            this.tablePanel1.Controls.Add(this.btnThoat);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 49.33333F)});
            this.tablePanel1.Size = new System.Drawing.Size(1062, 649);
            this.tablePanel1.TabIndex = 1;
            // 
            // grdChung
            // 
            this.tablePanel1.SetColumn(this.grdChung, 0);
            this.tablePanel1.SetColumnSpan(this.grdChung, 6);
            this.grdChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChung.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdChung.Location = new System.Drawing.Point(14, 14);
            this.grdChung.MainView = this.grvChung;
            this.grdChung.Margin = new System.Windows.Forms.Padding(4);
            this.grdChung.Name = "grdChung";
            this.tablePanel1.SetRow(this.grdChung, 0);
            this.grdChung.Size = new System.Drawing.Size(1034, 572);
            this.grdChung.TabIndex = 2;
            this.grdChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChung});
            // 
            // grvChung
            // 
            this.grvChung.DetailHeight = 861;
            this.grvChung.FixedLineWidth = 4;
            this.grvChung.GridControl = this.grdChung;
            this.grvChung.Name = "grvChung";
            this.grvChung.OptionsView.ShowGroupPanel = false;
            // 
            // txtTim
            // 
            this.txtTim.Client = this.grdChung;
            this.tablePanel1.SetColumn(this.txtTim, 0);
            this.txtTim.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTim.Location = new System.Drawing.Point(14, 608);
            this.txtTim.Margin = new System.Windows.Forms.Padding(4);
            this.txtTim.Name = "txtTim";
            this.txtTim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtTim.Properties.Client = this.grdChung;
            this.tablePanel1.SetRow(this.txtTim, 1);
            this.txtTim.Size = new System.Drawing.Size(283, 27);
            this.txtTim.TabIndex = 1;
            // 
            // btnGhi
            // 
            this.tablePanel1.SetColumn(this.btnGhi, 4);
            this.btnGhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGhi.Location = new System.Drawing.Point(745, 593);
            this.btnGhi.Name = "btnGhi";
            this.tablePanel1.SetRow(this.btnGhi, 1);
            this.btnGhi.Size = new System.Drawing.Size(149, 43);
            this.btnGhi.TabIndex = 0;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThoat
            // 
            this.tablePanel1.SetColumn(this.btnThoat, 5);
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.Location = new System.Drawing.Point(900, 593);
            this.btnThoat.Name = "btnThoat";
            this.tablePanel1.SetRow(this.btnThoat, 1);
            this.btnThoat.Size = new System.Drawing.Size(149, 43);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmNNgu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 649);
            this.Controls.Add(this.tablePanel1);
            this.IconOptions.Image = global::VS.OEE.Properties.Resources.OEE;
            this.Name = "frmNNgu";
            this.Text = "frmNNgu";
            this.Load += new System.EventHandler(this.frmNNgu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTim.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraGrid.GridControl grdChung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChung;
        private DevExpress.XtraEditors.SearchControl txtTim;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
    }
}