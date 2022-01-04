namespace VS.OEE
{
    partial class frmShiftLeader
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
            this.lblNGAY = new DevExpress.XtraEditors.LabelControl();
            this.panelNN = new DevExpress.XtraEditors.PanelControl();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearch = new DevExpress.XtraEditors.SearchControl();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.groShiftLeader = new DevExpress.XtraEditors.GroupControl();
            this.grdShiftLeader = new DevExpress.XtraGrid.GridControl();
            this.grvShiftLeader = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.datNGAY = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groShiftLeader)).BeginInit();
            this.groShiftLeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdShiftLeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShiftLeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNGAY.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNGAY.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNGAY
            // 
            this.lblNGAY.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNGAY.Appearance.Options.UseFont = true;
            this.lblNGAY.Appearance.Options.UseTextOptions = true;
            this.lblNGAY.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblNGAY.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblNGAY, 2);
            this.panelChung.SetColumnSpan(this.lblNGAY, 2);
            this.lblNGAY.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNGAY.Location = new System.Drawing.Point(179, 11);
            this.lblNGAY.Name = "lblNGAY";
            this.panelChung.SetRow(this.lblNGAY, 1);
            this.lblNGAY.Size = new System.Drawing.Size(255, 19);
            this.lblNGAY.TabIndex = 1;
            this.lblNGAY.Text = "lblNGAY";
            // 
            // panelNN
            // 
            this.panelNN.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelNN.Appearance.Options.UseBackColor = true;
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelChung.SetColumn(this.panelNN, 0);
            this.panelChung.SetColumnSpan(this.panelNN, 8);
            this.panelNN.Controls.Add(this.btnCopy);
            this.panelNN.Controls.Add(this.txtSearch);
            this.panelNN.Controls.Add(this.btnGhi);
            this.panelNN.Controls.Add(this.btnKhong);
            this.panelNN.Controls.Add(this.btnSua);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Controls.Add(this.btnXoa);
            this.panelNN.Location = new System.Drawing.Point(3, 415);
            this.panelNN.Name = "panelNN";
            this.panelChung.SetRow(this.panelNN, 4);
            this.panelNN.Size = new System.Drawing.Size(888, 29);
            this.panelNN.TabIndex = 6;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(563, 1);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(80, 26);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "btnCopy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.EnterMoveNextControl = true;
            this.txtSearch.Location = new System.Drawing.Point(1, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtSearch.Properties.FindDelay = 100;
            this.txtSearch.Properties.NullValuePrompt = " ";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 3;
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(725, 1);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 5;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Location = new System.Drawing.Point(806, 1);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(80, 26);
            this.btnKhong.TabIndex = 5;
            this.btnKhong.Text = "btnKhong";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(644, 1);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 26);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(806, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(725, 1);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 26);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
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
            this.panelChung.Controls.Add(this.groShiftLeader);
            this.panelChung.Controls.Add(this.datNGAY);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.lblNGAY);
            this.panelChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChung.Location = new System.Drawing.Point(0, 0);
            this.panelChung.Name = "panelChung";
            this.panelChung.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.panelChung.Size = new System.Drawing.Size(894, 447);
            this.panelChung.TabIndex = 3;
            // 
            // groShiftLeader
            // 
            this.panelChung.SetColumn(this.groShiftLeader, 0);
            this.panelChung.SetColumnSpan(this.groShiftLeader, 8);
            this.groShiftLeader.Controls.Add(this.grdShiftLeader);
            this.groShiftLeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groShiftLeader.Location = new System.Drawing.Point(3, 45);
            this.groShiftLeader.Name = "groShiftLeader";
            this.panelChung.SetRow(this.groShiftLeader, 3);
            this.groShiftLeader.Size = new System.Drawing.Size(888, 364);
            this.groShiftLeader.TabIndex = 9;
            this.groShiftLeader.Text = "groDanhSachHieuXuatKPI";
            // 
            // grdShiftLeader
            // 
            this.grdShiftLeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdShiftLeader.Location = new System.Drawing.Point(2, 22);
            this.grdShiftLeader.MainView = this.grvShiftLeader;
            this.grdShiftLeader.Name = "grdShiftLeader";
            this.grdShiftLeader.Size = new System.Drawing.Size(884, 340);
            this.grdShiftLeader.TabIndex = 0;
            this.grdShiftLeader.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvShiftLeader});
            this.grdShiftLeader.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdShiftLeader_ProcessGridKey);
            // 
            // grvShiftLeader
            // 
            this.grvShiftLeader.GridControl = this.grdShiftLeader;
            this.grvShiftLeader.Name = "grvShiftLeader";
            this.grvShiftLeader.OptionsView.ShowGroupPanel = false;
            this.grvShiftLeader.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvShiftLeader_CellValueChanged);
            // 
            // datNGAY
            // 
            this.panelChung.SetColumn(this.datNGAY, 4);
            this.datNGAY.EditValue = null;
            this.datNGAY.Location = new System.Drawing.Point(440, 11);
            this.datNGAY.Name = "datNGAY";
            this.datNGAY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datNGAY.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datNGAY.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.panelChung.SetRow(this.datNGAY, 1);
            this.datNGAY.Size = new System.Drawing.Size(135, 20);
            this.datNGAY.TabIndex = 8;
            this.datNGAY.EditValueChanged += new System.EventHandler(this.datNGAY_EditValueChanged);
            // 
            // frmShiftLeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 447);
            this.Controls.Add(this.panelChung);
            this.Name = "frmShiftLeader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShiftLeader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShiftLeader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groShiftLeader)).EndInit();
            this.groShiftLeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdShiftLeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShiftLeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNGAY.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datNGAY.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblNGAY;
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.SearchControl txtSearch;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.DateEdit datNGAY;
        private DevExpress.XtraEditors.GroupControl groShiftLeader;
        private DevExpress.XtraGrid.GridControl grdShiftLeader;
        private DevExpress.XtraGrid.Views.Grid.GridView grvShiftLeader;
    }
}