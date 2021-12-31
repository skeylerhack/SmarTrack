namespace VS.OEE
{
    partial class ucBaoCaoKeHoachSanXuat
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
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.cboTuan = new DevExpress.XtraEditors.LookUpEdit();
            this.grdKeHoachSanXuat = new DevExpress.XtraGrid.GridControl();
            this.grvKeHoachSanXuat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTuan = new DevExpress.XtraEditors.LabelControl();
            this.lblMay = new DevExpress.XtraEditors.LabelControl();
            this.cboMay = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTuan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKeHoachSanXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKeHoachSanXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNN
            // 
            this.panelNN.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelNN.Appearance.Options.UseBackColor = true;
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelChung.SetColumn(this.panelNN, 1);
            this.panelChung.SetColumnSpan(this.panelNN, 5);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Controls.Add(this.btnIn);
            this.panelNN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNN.Location = new System.Drawing.Point(139, 458);
            this.panelNN.Name = "panelNN";
            this.panelChung.SetRow(this.panelNN, 4);
            this.panelNN.Size = new System.Drawing.Size(821, 29);
            this.panelNN.TabIndex = 6;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(740, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Location = new System.Drawing.Point(659, 1);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(80, 26);
            this.btnIn.TabIndex = 5;
            this.btnIn.Text = "btnIn";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // panelChung
            // 
            this.panelChung.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F)});
            this.panelChung.Controls.Add(this.cboTuan);
            this.panelChung.Controls.Add(this.grdKeHoachSanXuat);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.lblTuan);
            this.panelChung.Controls.Add(this.lblMay);
            this.panelChung.Controls.Add(this.cboMay);
            this.panelChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChung.Location = new System.Drawing.Point(0, 0);
            this.panelChung.Name = "panelChung";
            this.panelChung.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.panelChung.Size = new System.Drawing.Size(963, 490);
            this.panelChung.TabIndex = 2;
            // 
            // cboTuan
            // 
            this.panelChung.SetColumn(this.cboTuan, 2);
            this.cboTuan.Location = new System.Drawing.Point(259, 11);
            this.cboTuan.Name = "cboTuan";
            this.cboTuan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTuan.Properties.NullText = "";
            this.panelChung.SetRow(this.cboTuan, 1);
            this.cboTuan.Size = new System.Drawing.Size(220, 20);
            this.cboTuan.TabIndex = 13;
            this.cboTuan.EditValueChanged += new System.EventHandler(this.cboTuan_EditValueChanged);
            // 
            // grdKeHoachSanXuat
            // 
            this.panelChung.SetColumn(this.grdKeHoachSanXuat, 0);
            this.panelChung.SetColumnSpan(this.grdKeHoachSanXuat, 6);
            this.grdKeHoachSanXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKeHoachSanXuat.Location = new System.Drawing.Point(3, 45);
            this.grdKeHoachSanXuat.MainView = this.grvKeHoachSanXuat;
            this.grdKeHoachSanXuat.Name = "grdKeHoachSanXuat";
            this.panelChung.SetRow(this.grdKeHoachSanXuat, 3);
            this.grdKeHoachSanXuat.Size = new System.Drawing.Size(957, 407);
            this.grdKeHoachSanXuat.TabIndex = 12;
            this.grdKeHoachSanXuat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKeHoachSanXuat});
            // 
            // grvKeHoachSanXuat
            // 
            this.grvKeHoachSanXuat.GridControl = this.grdKeHoachSanXuat;
            this.grvKeHoachSanXuat.Name = "grvKeHoachSanXuat";
            this.grvKeHoachSanXuat.OptionsCustomization.AllowSort = false;
            this.grvKeHoachSanXuat.OptionsView.AllowCellMerge = true;
            this.grvKeHoachSanXuat.OptionsView.ShowGroupPanel = false;
            this.grvKeHoachSanXuat.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.grvKeHoachSanXuat_CellMerge);
            this.grvKeHoachSanXuat.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grvKeHoachSanXuat_CustomColumnDisplayText);
            // 
            // lblTuan
            // 
            this.lblTuan.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblTuan, 1);
            this.lblTuan.Location = new System.Drawing.Point(139, 11);
            this.lblTuan.Name = "lblTuan";
            this.panelChung.SetRow(this.lblTuan, 1);
            this.lblTuan.Size = new System.Drawing.Size(114, 19);
            this.lblTuan.TabIndex = 1;
            this.lblTuan.Text = "lblTuan";
            // 
            // lblMay
            // 
            this.lblMay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblMay, 3);
            this.lblMay.Location = new System.Drawing.Point(485, 11);
            this.lblMay.Name = "lblMay";
            this.panelChung.SetRow(this.lblMay, 1);
            this.lblMay.Size = new System.Drawing.Size(114, 19);
            this.lblMay.TabIndex = 1;
            this.lblMay.Text = "lblMay";
            // 
            // cboMay
            // 
            this.panelChung.SetColumn(this.cboMay, 4);
            this.cboMay.Location = new System.Drawing.Point(605, 11);
            this.cboMay.Name = "cboMay";
            this.cboMay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMay.Properties.NullText = "";
            this.panelChung.SetRow(this.cboMay, 1);
            this.cboMay.Size = new System.Drawing.Size(220, 20);
            this.cboMay.TabIndex = 10;
            this.cboMay.EditValueChanged += new System.EventHandler(this.cboTuan_EditValueChanged);
            // 
            // ucBaoCaoKeHoachSanXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelChung);
            this.Name = "ucBaoCaoKeHoachSanXuat";
            this.Size = new System.Drawing.Size(963, 490);
            this.Load += new System.EventHandler(this.ucBaoCaoKeHoachSanXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboTuan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKeHoachSanXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKeHoachSanXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.LabelControl lblTuan;
        private DevExpress.XtraEditors.LabelControl lblMay;
        private DevExpress.XtraEditors.LookUpEdit cboMay;
        private DevExpress.XtraGrid.GridControl grdKeHoachSanXuat;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKeHoachSanXuat;
        private DevExpress.XtraEditors.LookUpEdit cboTuan;
    }
}
