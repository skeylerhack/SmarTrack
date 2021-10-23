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
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNhom = new System.Windows.Forms.Label();
            this.cboNhom = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.treeListMenu)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeListMenu
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.treeListMenu, 4);
            this.treeListMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListMenu.Location = new System.Drawing.Point(13, 47);
            this.treeListMenu.MinWidth = 22;
            this.treeListMenu.Name = "treeListMenu";
            this.treeListMenu.OptionsBehavior.AllowBoundCheckBoxesInVirtualMode = true;
            this.treeListMenu.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeListMenu.Size = new System.Drawing.Size(1165, 594);
            this.treeListMenu.TabIndex = 3;
            this.treeListMenu.TreeLevelWidth = 20;
            this.treeListMenu.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeListMenu_CellValueChanged);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(956, 3);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(104, 31);
            this.btnGhi.TabIndex = 8;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Visible = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnKhongGhi
            // 
            this.btnKhongGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhongGhi.Location = new System.Drawing.Point(1061, 3);
            this.btnKhongGhi.Name = "btnKhongGhi";
            this.btnKhongGhi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnKhongGhi.Size = new System.Drawing.Size(104, 31);
            this.btnKhongGhi.TabIndex = 7;
            this.btnKhongGhi.Text = "btnKhongGhi";
            this.btnKhongGhi.Visible = false;
            this.btnKhongGhi.Click += new System.EventHandler(this.btnKhongGhi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(1061, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 31);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(956, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(104, 31);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.treeListMenu, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNhom, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboNhom, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1191, 696);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnGhi);
            this.panel1.Controls.Add(this.btnKhongGhi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(13, 647);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1165, 36);
            this.panel1.TabIndex = 4;
            // 
            // lblNhom
            // 
            this.lblNhom.AutoSize = true;
            this.lblNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhom.Location = new System.Drawing.Point(433, 10);
            this.lblNhom.Name = "lblNhom";
            this.lblNhom.Size = new System.Drawing.Size(114, 34);
            this.lblNhom.TabIndex = 5;
            this.lblNhom.Text = "lblNhom";
            this.lblNhom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboNhom
            // 
            this.cboNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNhom.FormattingEnabled = true;
            this.cboNhom.Location = new System.Drawing.Point(553, 13);
            this.cboNhom.Name = "cboNhom";
            this.cboNhom.Size = new System.Drawing.Size(204, 29);
            this.cboNhom.TabIndex = 6;
            this.cboNhom.SelectedIndexChanged += new System.EventHandler(this.cboNhom_SelectedIndexChanged);
            // 
            // frmPhanQuyenChucNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 696);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPhanQuyenChucNang";
            this.Load += new System.EventHandler(this.frmPhanQuyenChucNang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListMenu)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTreeList.TreeList treeListMenu;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhongGhi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNhom;
        private System.Windows.Forms.ComboBox cboNhom;
    }
}
