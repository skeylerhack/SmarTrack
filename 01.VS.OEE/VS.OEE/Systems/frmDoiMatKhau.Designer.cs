namespace VS.OEE
{
    partial class frmDoiMatKhau
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.txtUSER_NAME = new DevExpress.XtraEditors.TextEdit();
            this.txtPASSWORD_OLD = new DevExpress.XtraEditors.TextEdit();
            this.txtPASSWORD_NEW = new DevExpress.XtraEditors.TextEdit();
            this.txtPASSWORD_NEW_RE = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblUSER_NAME = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPASSWORD_OLD = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPASSWORD_NEW = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPASSWORD_NEW_RE = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_OLD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_NEW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_NEW_RE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUSER_NAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD_OLD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD_NEW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD_NEW_RE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(386, 187);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(147, 37);
            this.btnThoat.StyleController = this.dataLayoutControl1;
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnThoat);
            this.dataLayoutControl1.Controls.Add(this.btnLuu);
            this.dataLayoutControl1.Controls.Add(this.txtUSER_NAME);
            this.dataLayoutControl1.Controls.Add(this.txtPASSWORD_OLD);
            this.dataLayoutControl1.Controls.Add(this.txtPASSWORD_NEW);
            this.dataLayoutControl1.Controls.Add(this.txtPASSWORD_NEW_RE);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(545, 237);
            this.dataLayoutControl1.TabIndex = 12;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(237, 187);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(145, 37);
            this.btnLuu.StyleController = this.dataLayoutControl1;
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "btnLuu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtUSER_NAME
            // 
            this.txtUSER_NAME.Location = new System.Drawing.Point(184, 13);
            this.txtUSER_NAME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUSER_NAME.Name = "txtUSER_NAME";
            this.txtUSER_NAME.Size = new System.Drawing.Size(349, 28);
            this.txtUSER_NAME.StyleController = this.dataLayoutControl1;
            this.txtUSER_NAME.TabIndex = 4;
            // 
            // txtPASSWORD_OLD
            // 
            this.txtPASSWORD_OLD.Location = new System.Drawing.Point(184, 45);
            this.txtPASSWORD_OLD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPASSWORD_OLD.Name = "txtPASSWORD_OLD";
            this.txtPASSWORD_OLD.Properties.PasswordChar = '*';
            this.txtPASSWORD_OLD.Properties.UseSystemPasswordChar = true;
            this.txtPASSWORD_OLD.Size = new System.Drawing.Size(349, 28);
            this.txtPASSWORD_OLD.StyleController = this.dataLayoutControl1;
            this.txtPASSWORD_OLD.TabIndex = 4;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "This value is not valid";
            conditionValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtPASSWORD_OLD, conditionValidationRule4);
            // 
            // txtPASSWORD_NEW
            // 
            this.txtPASSWORD_NEW.Location = new System.Drawing.Point(184, 77);
            this.txtPASSWORD_NEW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPASSWORD_NEW.Name = "txtPASSWORD_NEW";
            this.txtPASSWORD_NEW.Properties.PasswordChar = '*';
            this.txtPASSWORD_NEW.Properties.UseSystemPasswordChar = true;
            this.txtPASSWORD_NEW.Size = new System.Drawing.Size(349, 28);
            this.txtPASSWORD_NEW.StyleController = this.dataLayoutControl1;
            this.txtPASSWORD_NEW.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtPASSWORD_NEW, conditionValidationRule1);
            // 
            // txtPASSWORD_NEW_RE
            // 
            this.txtPASSWORD_NEW_RE.Location = new System.Drawing.Point(184, 109);
            this.txtPASSWORD_NEW_RE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPASSWORD_NEW_RE.Name = "txtPASSWORD_NEW_RE";
            this.txtPASSWORD_NEW_RE.Properties.PasswordChar = '*';
            this.txtPASSWORD_NEW_RE.Properties.UseSystemPasswordChar = true;
            this.txtPASSWORD_NEW_RE.Size = new System.Drawing.Size(349, 28);
            this.txtPASSWORD_NEW_RE.StyleController = this.dataLayoutControl1;
            this.txtPASSWORD_NEW_RE.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtPASSWORD_NEW_RE, conditionValidationRule2);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblUSER_NAME,
            this.lblPASSWORD_OLD,
            this.lblPASSWORD_NEW,
            this.lblPASSWORD_NEW_RE,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(545, 237);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lblUSER_NAME
            // 
            this.lblUSER_NAME.Control = this.txtUSER_NAME;
            this.lblUSER_NAME.Location = new System.Drawing.Point(0, 0);
            this.lblUSER_NAME.Name = "lblUSER_NAME";
            this.lblUSER_NAME.Size = new System.Drawing.Size(525, 32);
            this.lblUSER_NAME.TextSize = new System.Drawing.Size(169, 21);
            // 
            // lblPASSWORD_OLD
            // 
            this.lblPASSWORD_OLD.Control = this.txtPASSWORD_OLD;
            this.lblPASSWORD_OLD.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblPASSWORD_OLD.CustomizationFormText = "layoutControlItem3";
            this.lblPASSWORD_OLD.Location = new System.Drawing.Point(0, 32);
            this.lblPASSWORD_OLD.Name = "lblPASSWORD_OLD";
            this.lblPASSWORD_OLD.Size = new System.Drawing.Size(525, 32);
            this.lblPASSWORD_OLD.TextSize = new System.Drawing.Size(169, 21);
            // 
            // lblPASSWORD_NEW
            // 
            this.lblPASSWORD_NEW.Control = this.txtPASSWORD_NEW;
            this.lblPASSWORD_NEW.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblPASSWORD_NEW.CustomizationFormText = "layoutControlItem3";
            this.lblPASSWORD_NEW.Location = new System.Drawing.Point(0, 64);
            this.lblPASSWORD_NEW.Name = "lblPASSWORD_NEW";
            this.lblPASSWORD_NEW.Size = new System.Drawing.Size(525, 32);
            this.lblPASSWORD_NEW.TextSize = new System.Drawing.Size(169, 21);
            // 
            // lblPASSWORD_NEW_RE
            // 
            this.lblPASSWORD_NEW_RE.Control = this.txtPASSWORD_NEW_RE;
            this.lblPASSWORD_NEW_RE.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblPASSWORD_NEW_RE.CustomizationFormText = "layoutControlItem3";
            this.lblPASSWORD_NEW_RE.Location = new System.Drawing.Point(0, 96);
            this.lblPASSWORD_NEW_RE.Name = "lblPASSWORD_NEW_RE";
            this.lblPASSWORD_NEW_RE.Size = new System.Drawing.Size(525, 32);
            this.lblPASSWORD_NEW_RE.TextSize = new System.Drawing.Size(169, 21);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 174);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(225, 41);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 128);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(525, 46);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnLuu;
            this.layoutControlItem1.Location = new System.Drawing.Point(225, 174);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(149, 41);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(149, 41);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(149, 41);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnThoat;
            this.layoutControlItem2.Location = new System.Drawing.Point(374, 174);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(151, 41);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(151, 41);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(151, 41);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 237);
            this.Controls.Add(this.dataLayoutControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChangePassword";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChangePassword_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_OLD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_NEW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_NEW_RE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUSER_NAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD_OLD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD_NEW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPASSWORD_NEW_RE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit txtUSER_NAME;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lblUSER_NAME;
        private DevExpress.XtraEditors.TextEdit txtPASSWORD_OLD;
        private DevExpress.XtraEditors.TextEdit txtPASSWORD_NEW;
        private DevExpress.XtraEditors.TextEdit txtPASSWORD_NEW_RE;
        private DevExpress.XtraLayout.LayoutControlItem lblPASSWORD_OLD;
        private DevExpress.XtraLayout.LayoutControlItem lblPASSWORD_NEW;
        private DevExpress.XtraLayout.LayoutControlItem lblPASSWORD_NEW_RE;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}