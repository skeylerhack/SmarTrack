namespace VS.OEE
{
    partial class frmPhanQuyenChucNang
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
            this.treeListMenu = new DevExpress.XtraTreeList.TreeList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.cboNhom = new System.Windows.Forms.ComboBox();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.lblNhom = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeListMenu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeListMenu
            // 
            this.tablePanel1.SetColumn(this.treeListMenu, 0);
            this.tablePanel1.SetColumnSpan(this.treeListMenu, 4);
            this.treeListMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListMenu.FixedLineWidth = 1;
            this.treeListMenu.HorzScrollStep = 2;
            this.treeListMenu.Location = new System.Drawing.Point(2, 44);
            this.treeListMenu.Margin = new System.Windows.Forms.Padding(2);
            this.treeListMenu.MinWidth = 16;
            this.treeListMenu.Name = "treeListMenu";
            this.treeListMenu.OptionsBehavior.AllowBoundCheckBoxesInVirtualMode = true;
            this.treeListMenu.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.tablePanel1.SetRow(this.treeListMenu, 3);
            this.treeListMenu.Size = new System.Drawing.Size(790, 406);
            this.treeListMenu.TabIndex = 3;
            this.treeListMenu.TreeLevelWidth = 13;
            this.treeListMenu.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeListMenu_CellValueChanged);
            // 
            // panel1
            // 
            this.tablePanel1.SetColumn(this.panel1, 0);
            this.tablePanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnGhi);
            this.panel1.Controls.Add(this.btnKhong);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Location = new System.Drawing.Point(2, 454);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.tablePanel1.SetRow(this.panel1, 4);
            this.panel1.Size = new System.Drawing.Size(790, 31);
            this.panel1.TabIndex = 4;
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(626, 2);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 26);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(708, 2);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(626, 2);
            this.btnGhi.Margin = new System.Windows.Forms.Padding(2);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 8;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Visible = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Location = new System.Drawing.Point(709, 2);
            this.btnKhong.Margin = new System.Windows.Forms.Padding(2);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnKhong.Size = new System.Drawing.Size(80, 26);
            this.btnKhong.TabIndex = 7;
            this.btnKhong.Text = "btnKhong";
            this.btnKhong.Visible = false;
            this.btnKhong.Click += new System.EventHandler(this.btnKhongGhi_Click);
            // 
            // cboNhom
            // 
            this.tablePanel1.SetColumn(this.cboNhom, 2);
            this.cboNhom.FormattingEnabled = true;
            this.cboNhom.Location = new System.Drawing.Point(347, 10);
            this.cboNhom.Margin = new System.Windows.Forms.Padding(2);
            this.cboNhom.Name = "cboNhom";
            this.tablePanel1.SetRow(this.cboNhom, 1);
            this.cboNhom.Size = new System.Drawing.Size(221, 21);
            this.cboNhom.TabIndex = 6;
            this.cboNhom.SelectedIndexChanged += new System.EventHandler(this.cboNhom_SelectedIndexChanged);
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel1.Controls.Add(this.lblNhom);
            this.tablePanel1.Controls.Add(this.cboNhom);
            this.tablePanel1.Controls.Add(this.panel1);
            this.tablePanel1.Controls.Add(this.treeListMenu);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.tablePanel1.Size = new System.Drawing.Size(794, 487);
            this.tablePanel1.TabIndex = 6;
            // 
            // lblNhom
            // 
            this.tablePanel1.SetColumn(this.lblNhom, 1);
            this.lblNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhom.Location = new System.Drawing.Point(228, 11);
            this.lblNhom.Name = "lblNhom";
            this.tablePanel1.SetRow(this.lblNhom, 1);
            this.lblNhom.Size = new System.Drawing.Size(114, 20);
            this.lblNhom.TabIndex = 7;
            this.lblNhom.Text = "lblNhom";
            // 
            // frmPhanQuyenChucNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 487);
            this.Controls.Add(this.tablePanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPhanQuyenChucNang";
            this.Load += new System.EventHandler(this.frmPhanQuyenChucNang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListMenu)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListMenu;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl lblNhom;
        private System.Windows.Forms.ComboBox cboNhom;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
    }
}
