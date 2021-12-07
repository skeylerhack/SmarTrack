namespace VS.OEE
{
    partial class frmLogin
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbo_database = new DevExpress.XtraEditors.LookUpEdit();
            this.che_Repass = new System.Windows.Forms.CheckBox();
            this.che_Reuser = new System.Windows.Forms.CheckBox();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_login = new DevExpress.XtraEditors.SimpleButton();
            this.pan_pass = new System.Windows.Forms.Panel();
            this.pan_user = new System.Windows.Forms.Panel();
            this.pan_database = new System.Windows.Forms.Panel();
            this.pic_pass = new DevExpress.XtraEditors.PictureEdit();
            this.pic_user = new DevExpress.XtraEditors.PictureEdit();
            this.pic_database = new DevExpress.XtraEditors.PictureEdit();
            this.txt_pass = new DevExpress.XtraEditors.TextEdit();
            this.txt_user = new DevExpress.XtraEditors.TextEdit();
            this.labTitleLogin = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_database.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_database.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.cbo_database);
            this.panel2.Controls.Add(this.che_Repass);
            this.panel2.Controls.Add(this.che_Reuser);
            this.panel2.Controls.Add(this.btnThoat);
            this.panel2.Controls.Add(this.btn_login);
            this.panel2.Controls.Add(this.pan_pass);
            this.panel2.Controls.Add(this.pan_user);
            this.panel2.Controls.Add(this.pan_database);
            this.panel2.Controls.Add(this.pic_pass);
            this.panel2.Controls.Add(this.pic_user);
            this.panel2.Controls.Add(this.pic_database);
            this.panel2.Controls.Add(this.txt_pass);
            this.panel2.Controls.Add(this.txt_user);
            this.panel2.Controls.Add(this.labTitleLogin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 272);
            this.panel2.TabIndex = 1;
            // 
            // cbo_database
            // 
            this.cbo_database.Location = new System.Drawing.Point(33, 60);
            this.cbo_database.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_database.Name = "cbo_database";
            this.cbo_database.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbo_database.Properties.Appearance.Options.UseBackColor = true;
            this.cbo_database.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cbo_database.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_database.Properties.NullText = "Database";
            this.cbo_database.Size = new System.Drawing.Size(207, 18);
            this.cbo_database.TabIndex = 11;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Please choose Database!";
            this.dxValidationProvider1.SetValidationRule(this.cbo_database, conditionValidationRule1);
            this.cbo_database.Click += new System.EventHandler(this.Cbo_database_Click);
            this.cbo_database.Validated += new System.EventHandler(this.Cbo_database_Validated);
            // 
            // che_Repass
            // 
            this.che_Repass.AutoSize = true;
            this.che_Repass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.che_Repass.Location = new System.Drawing.Point(118, 162);
            this.che_Repass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.che_Repass.Name = "che_Repass";
            this.che_Repass.Size = new System.Drawing.Size(129, 17);
            this.che_Repass.TabIndex = 4;
            this.che_Repass.Text = "Remember Password";
            this.che_Repass.UseVisualStyleBackColor = true;
            // 
            // che_Reuser
            // 
            this.che_Reuser.AutoSize = true;
            this.che_Reuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.che_Reuser.Location = new System.Drawing.Point(14, 162);
            this.che_Reuser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.che_Reuser.Name = "che_Reuser";
            this.che_Reuser.Size = new System.Drawing.Size(102, 17);
            this.che_Reuser.TabIndex = 3;
            this.che_Reuser.Text = "Remember user";
            this.che_Reuser.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.BackColor = System.Drawing.Color.White;
            this.btnThoat.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnThoat.Appearance.BorderColor = System.Drawing.Color.White;
            this.btnThoat.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnThoat.Appearance.Options.UseBackColor = true;
            this.btnThoat.Appearance.Options.UseBorderColor = true;
            this.btnThoat.Appearance.Options.UseForeColor = true;
            this.btnThoat.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnThoat.AppearanceHovered.Options.UseForeColor = true;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Location = new System.Drawing.Point(12, 227);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(228, 35);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            // 
            // btn_login
            // 
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_login.ImageOptions.Image")));
            this.btn_login.Location = new System.Drawing.Point(12, 187);
            this.btn_login.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(228, 35);
            this.btn_login.TabIndex = 5;
            this.btn_login.Text = "Login";
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // pan_pass
            // 
            this.pan_pass.BackColor = System.Drawing.Color.Gray;
            this.pan_pass.Location = new System.Drawing.Point(14, 137);
            this.pan_pass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pan_pass.Name = "pan_pass";
            this.pan_pass.Size = new System.Drawing.Size(225, 1);
            this.pan_pass.TabIndex = 3;
            // 
            // pan_user
            // 
            this.pan_user.BackColor = System.Drawing.Color.Gray;
            this.pan_user.Location = new System.Drawing.Point(14, 106);
            this.pan_user.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pan_user.Name = "pan_user";
            this.pan_user.Size = new System.Drawing.Size(225, 1);
            this.pan_user.TabIndex = 3;
            // 
            // pan_database
            // 
            this.pan_database.BackColor = System.Drawing.Color.Gray;
            this.pan_database.Location = new System.Drawing.Point(14, 74);
            this.pan_database.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pan_database.Name = "pan_database";
            this.pan_database.Size = new System.Drawing.Size(225, 1);
            this.pan_database.TabIndex = 3;
            // 
            // pic_pass
            // 
            this.pic_pass.EditValue = global::VS.OEE.Properties.Resources.icon_pass;
            this.pic_pass.Location = new System.Drawing.Point(12, 117);
            this.pic_pass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pic_pass.Name = "pic_pass";
            this.pic_pass.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pic_pass.Properties.Appearance.Options.UseBackColor = true;
            this.pic_pass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pic_pass.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_pass.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_pass.Size = new System.Drawing.Size(23, 25);
            this.pic_pass.TabIndex = 2;
            // 
            // pic_user
            // 
            this.pic_user.EditValue = global::VS.OEE.Properties.Resources.icon_user;
            this.pic_user.Location = new System.Drawing.Point(11, 85);
            this.pic_user.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pic_user.Name = "pic_user";
            this.pic_user.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pic_user.Properties.Appearance.Options.UseBackColor = true;
            this.pic_user.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pic_user.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_user.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_user.Size = new System.Drawing.Size(23, 25);
            this.pic_user.TabIndex = 2;
            // 
            // pic_database
            // 
            this.pic_database.EditValue = global::VS.OEE.Properties.Resources.icon_data;
            this.pic_database.Location = new System.Drawing.Point(12, 53);
            this.pic_database.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pic_database.Name = "pic_database";
            this.pic_database.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pic_database.Properties.Appearance.Options.UseBackColor = true;
            this.pic_database.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pic_database.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_database.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_database.Size = new System.Drawing.Size(23, 25);
            this.pic_database.TabIndex = 2;
            // 
            // txt_pass
            // 
            this.txt_pass.EditValue = "Password";
            this.txt_pass.Location = new System.Drawing.Point(33, 122);
            this.txt_pass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_pass.Properties.Appearance.Options.UseBackColor = true;
            this.txt_pass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txt_pass.Properties.PasswordChar = '•';
            this.txt_pass.Size = new System.Drawing.Size(207, 18);
            this.txt_pass.TabIndex = 2;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Please choose Pass Word!";
            this.dxValidationProvider1.SetValidationRule(this.txt_pass, conditionValidationRule2);
            this.txt_pass.Click += new System.EventHandler(this.Txt_pass_Click);
            this.txt_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_pass_KeyDown);
            this.txt_pass.Validated += new System.EventHandler(this.Txt_pass_Validated);
            // 
            // txt_user
            // 
            this.txt_user.EditValue = "Username";
            this.txt_user.Location = new System.Drawing.Point(32, 91);
            this.txt_user.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_user.Name = "txt_user";
            this.txt_user.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_user.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txt_user.Properties.Appearance.Options.UseBackColor = true;
            this.txt_user.Properties.Appearance.Options.UseForeColor = true;
            this.txt_user.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txt_user.Size = new System.Drawing.Size(208, 18);
            this.txt_user.TabIndex = 1;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Please choose User Name!";
            this.dxValidationProvider1.SetValidationRule(this.txt_user, conditionValidationRule3);
            this.txt_user.Click += new System.EventHandler(this.Txt_user_Click);
            this.txt_user.Validated += new System.EventHandler(this.Txt_user_Validated);
            // 
            // labTitleLogin
            // 
            this.labTitleLogin.AllowHtmlString = true;
            this.labTitleLogin.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.labTitleLogin.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitleLogin.Appearance.Options.UseFont = true;
            this.labTitleLogin.Appearance.Options.UseTextOptions = true;
            this.labTitleLogin.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labTitleLogin.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.labTitleLogin.AppearancePressed.Options.UseTextOptions = true;
            this.labTitleLogin.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labTitleLogin.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labTitleLogin.AutoEllipsis = true;
            this.labTitleLogin.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labTitleLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.labTitleLogin.Location = new System.Drawing.Point(0, 0);
            this.labTitleLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labTitleLogin.Name = "labTitleLogin";
            this.labTitleLogin.Size = new System.Drawing.Size(251, 41);
            this.labTitleLogin.TabIndex = 0;
            this.labTitleLogin.Text = "Sign Up";
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // frmLogin
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 272);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.InactiveGlowColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_database.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_database.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl labTitleLogin;
        private DevExpress.XtraEditors.TextEdit txt_user;
        private DevExpress.XtraEditors.TextEdit txt_pass;
        private System.Windows.Forms.Panel pan_database;
        private DevExpress.XtraEditors.SimpleButton btn_login;
        private DevExpress.XtraEditors.PictureEdit pic_database;
        private System.Windows.Forms.CheckBox che_Repass;
        private System.Windows.Forms.CheckBox che_Reuser;
        private System.Windows.Forms.Panel pan_user;
        private System.Windows.Forms.Panel pan_pass;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.PictureEdit pic_pass;
        private DevExpress.XtraEditors.PictureEdit pic_user;
        private DevExpress.XtraEditors.LookUpEdit cbo_database;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}