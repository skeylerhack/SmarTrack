namespace VS.OEE
{
    partial class frmThoiGianNgungMay_KTTD_View
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
            this.grdTGianNMayView = new DevExpress.XtraGrid.GridControl();
            this.grvTGianNMayView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel)).BeginInit();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTGianNMayView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTGianNMayView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
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
            this.tablePanel.Controls.Add(this.grdTGianNMayView);
            this.tablePanel.Controls.Add(this.panelControl1);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(0, 0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 37F)});
            this.tablePanel.Size = new System.Drawing.Size(1085, 568);
            this.tablePanel.TabIndex = 0;
            // 
            // grdTGianNMayView
            // 
            this.tablePanel.SetColumn(this.grdTGianNMayView, 0);
            this.tablePanel.SetColumnSpan(this.grdTGianNMayView, 8);
            this.grdTGianNMayView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTGianNMayView.Location = new System.Drawing.Point(3, 3);
            this.grdTGianNMayView.MainView = this.grvTGianNMayView;
            this.grdTGianNMayView.Name = "grdTGianNMayView";
            this.tablePanel.SetRow(this.grdTGianNMayView, 0);
            this.grdTGianNMayView.Size = new System.Drawing.Size(1079, 525);
            this.grdTGianNMayView.TabIndex = 1;
            this.grdTGianNMayView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTGianNMayView});
            // 
            // grvTGianNMayView
            // 
            this.grvTGianNMayView.GridControl = this.grdTGianNMayView;
            this.grvTGianNMayView.Name = "grvTGianNMayView";
            this.grvTGianNMayView.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.tablePanel.SetColumn(this.panelControl1, 0);
            this.tablePanel.SetColumnSpan(this.panelControl1, 8);
            this.panelControl1.Controls.Add(this.searchControl1);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Location = new System.Drawing.Point(3, 534);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel.SetRow(this.panelControl1, 1);
            this.panelControl1.Size = new System.Drawing.Size(1079, 31);
            this.panelControl1.TabIndex = 0;
            // 
            // searchControl1
            // 
            this.searchControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchControl1.Client = this.grdTGianNMayView;
            this.searchControl1.Location = new System.Drawing.Point(1, 10);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.grdTGianNMayView;
            this.searchControl1.Size = new System.Drawing.Size(201, 20);
            this.searchControl1.TabIndex = 11;
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
            // frmThoiGianNgungMay_KTTD_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 568);
            this.Controls.Add(this.tablePanel);
            this.Name = "frmThoiGianNgungMay_KTTD_View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThoiGianNgungMay_KTTD_View";
            this.Load += new System.EventHandler(this.frmThoiGianNgungMay_KTTD_View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel)).EndInit();
            this.tablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTGianNMayView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTGianNMayView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdTGianNMayView;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTGianNMayView;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SearchControl searchControl1;
    }
}