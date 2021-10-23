namespace VS.OEE
{
    partial class frmXacNhan
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.txtPASSWORD = new DevExpress.XtraEditors.TextEdit();
            this.txtUSER_NAME = new DevExpress.XtraEditors.TextEdit();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblUSER_NAME = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPASSWORD = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUSER_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txtPASSWORD);
            this.dataLayoutControl1.Controls.Add(this.txtUSER_NAME);
            this.dataLayoutControl1.Controls.Add(this.btnXacNhan);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(434, 131);
            this.dataLayoutControl1.TabIndex = 1;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // txtPASSWORD
            // 
            this.txtPASSWORD.Location = new System.Drawing.Point(131, 43);
            this.txtPASSWORD.Name = "txtPASSWORD";
            this.txtPASSWORD.Properties.UseSystemPasswordChar = true;
            this.txtPASSWORD.Size = new System.Drawing.Size(265, 27);
            this.txtPASSWORD.StyleController = this.dataLayoutControl1;
            this.txtPASSWORD.TabIndex = 7;
            // 
            // txtUSER_NAME
            // 
            this.txtUSER_NAME.Location = new System.Drawing.Point(131, 12);
            this.txtUSER_NAME.Name = "txtUSER_NAME";
            this.txtUSER_NAME.Size = new System.Drawing.Size(265, 27);
            this.txtUSER_NAME.StyleController = this.dataLayoutControl1;
            this.txtUSER_NAME.TabIndex = 5;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(250, 84);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(146, 36);
            this.btnXacNhan.StyleController = this.dataLayoutControl1;
            this.btnXacNhan.TabIndex = 13;
            this.btnXacNhan.Text = "btnXacNhan";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblUSER_NAME,
            this.lblPASSWORD,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem9});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(408, 132);
            this.Root.TextVisible = false;
            // 
            // lblUSER_NAME
            // 
            this.lblUSER_NAME.Control = this.txtUSER_NAME;
            this.lblUSER_NAME.Location = new System.Drawing.Point(0, 0);
            this.lblUSER_NAME.Name = "lblUSER_NAME";
            this.lblUSER_NAME.Size = new System.Drawing.Size(388, 31);
            this.lblUSER_NAME.TextSize = new System.Drawing.Size(116, 20);
            // 
            // lblPASSWORD
            // 
            this.lblPASSWORD.Control = this.txtPASSWORD;
            this.lblPASSWORD.Location = new System.Drawing.Point(0, 31);
            this.lblPASSWORD.Name = "lblPASSWORD";
            this.lblPASSWORD.Size = new System.Drawing.Size(388, 31);
            this.lblPASSWORD.TextSize = new System.Drawing.Size(116, 20);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 62);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(388, 10);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(238, 40);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnXacNhan;
            this.layoutControlItem9.Location = new System.Drawing.Point(238, 72);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(150, 40);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(150, 40);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(150, 40);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // frmXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 131);
            this.Controls.Add(this.dataLayoutControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "frmXacNhan";
            this.Text = "frmXacNhan";
            this.Load += new System.EventHandler(this.frmXacNhan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmXacNhan_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUSER_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit txtUSER_NAME;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lblUSER_NAME;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.TextEdit txtPASSWORD;
        private DevExpress.XtraLayout.LayoutControlItem lblPASSWORD;
    }
}