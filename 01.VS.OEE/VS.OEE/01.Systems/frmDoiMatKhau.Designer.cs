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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.txtUSER_NAME = new DevExpress.XtraEditors.TextEdit();
            this.txtPASSWORD_OLD = new DevExpress.XtraEditors.TextEdit();
            this.txtPASSWORD_NEW = new DevExpress.XtraEditors.TextEdit();
            this.txtPASSWORD_NEW_RE = new DevExpress.XtraEditors.TextEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblUSER_NAME = new DevExpress.XtraEditors.LabelControl();
            this.lblPASSWORD_OLD = new DevExpress.XtraEditors.LabelControl();
            this.lblPASSWORD_NEW = new DevExpress.XtraEditors.LabelControl();
            this.lblPASSWORD_NEW_RE = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_OLD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_NEW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_NEW_RE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(262, 2);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(181, 2);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(80, 26);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "btnLuu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtUSER_NAME
            // 
            this.tablePanel1.SetColumn(this.txtUSER_NAME, 1);
            this.txtUSER_NAME.Location = new System.Drawing.Point(123, 12);
            this.txtUSER_NAME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUSER_NAME.Name = "txtUSER_NAME";
            this.tablePanel1.SetRow(this.txtUSER_NAME, 1);
            this.txtUSER_NAME.Size = new System.Drawing.Size(222, 20);
            this.txtUSER_NAME.TabIndex = 4;
            // 
            // txtPASSWORD_OLD
            // 
            this.tablePanel1.SetColumn(this.txtPASSWORD_OLD, 1);
            this.txtPASSWORD_OLD.Location = new System.Drawing.Point(123, 38);
            this.txtPASSWORD_OLD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPASSWORD_OLD.Name = "txtPASSWORD_OLD";
            this.txtPASSWORD_OLD.Properties.PasswordChar = '*';
            this.txtPASSWORD_OLD.Properties.UseSystemPasswordChar = true;
            this.tablePanel1.SetRow(this.txtPASSWORD_OLD, 2);
            this.txtPASSWORD_OLD.Size = new System.Drawing.Size(222, 20);
            this.txtPASSWORD_OLD.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtPASSWORD_OLD, conditionValidationRule1);
            // 
            // txtPASSWORD_NEW
            // 
            this.tablePanel1.SetColumn(this.txtPASSWORD_NEW, 1);
            this.txtPASSWORD_NEW.Location = new System.Drawing.Point(123, 64);
            this.txtPASSWORD_NEW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPASSWORD_NEW.Name = "txtPASSWORD_NEW";
            this.txtPASSWORD_NEW.Properties.PasswordChar = '*';
            this.txtPASSWORD_NEW.Properties.UseSystemPasswordChar = true;
            this.tablePanel1.SetRow(this.txtPASSWORD_NEW, 3);
            this.txtPASSWORD_NEW.Size = new System.Drawing.Size(222, 20);
            this.txtPASSWORD_NEW.TabIndex = 4;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtPASSWORD_NEW, conditionValidationRule3);
            // 
            // txtPASSWORD_NEW_RE
            // 
            this.tablePanel1.SetColumn(this.txtPASSWORD_NEW_RE, 1);
            this.txtPASSWORD_NEW_RE.Location = new System.Drawing.Point(123, 90);
            this.txtPASSWORD_NEW_RE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPASSWORD_NEW_RE.Name = "txtPASSWORD_NEW_RE";
            this.txtPASSWORD_NEW_RE.Properties.PasswordChar = '*';
            this.txtPASSWORD_NEW_RE.Properties.UseSystemPasswordChar = true;
            this.tablePanel1.SetRow(this.txtPASSWORD_NEW_RE, 4);
            this.txtPASSWORD_NEW_RE.Size = new System.Drawing.Size(222, 20);
            this.txtPASSWORD_NEW_RE.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtPASSWORD_NEW_RE, conditionValidationRule2);
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.lblUSER_NAME);
            this.tablePanel1.Controls.Add(this.lblPASSWORD_OLD);
            this.tablePanel1.Controls.Add(this.lblPASSWORD_NEW);
            this.tablePanel1.Controls.Add(this.lblPASSWORD_NEW_RE);
            this.tablePanel1.Controls.Add(this.txtUSER_NAME);
            this.tablePanel1.Controls.Add(this.txtPASSWORD_OLD);
            this.tablePanel1.Controls.Add(this.txtPASSWORD_NEW_RE);
            this.tablePanel1.Controls.Add(this.txtPASSWORD_NEW);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.tablePanel1.Size = new System.Drawing.Size(348, 155);
            this.tablePanel1.TabIndex = 13;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.tablePanel1.SetColumnSpan(this.panelControl1, 2);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Controls.Add(this.btnLuu);
            this.panelControl1.Location = new System.Drawing.Point(3, 123);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 6);
            this.panelControl1.Size = new System.Drawing.Size(342, 29);
            this.panelControl1.TabIndex = 5;
            // 
            // lblUSER_NAME
            // 
            this.tablePanel1.SetColumn(this.lblUSER_NAME, 0);
            this.lblUSER_NAME.Location = new System.Drawing.Point(3, 15);
            this.lblUSER_NAME.Name = "lblUSER_NAME";
            this.tablePanel1.SetRow(this.lblUSER_NAME, 1);
            this.lblUSER_NAME.Size = new System.Drawing.Size(76, 13);
            this.lblUSER_NAME.TabIndex = 0;
            this.lblUSER_NAME.Text = "lblUSER_NAME";
            // 
            // lblPASSWORD_OLD
            // 
            this.tablePanel1.SetColumn(this.lblPASSWORD_OLD, 0);
            this.lblPASSWORD_OLD.Location = new System.Drawing.Point(3, 41);
            this.lblPASSWORD_OLD.Name = "lblPASSWORD_OLD";
            this.tablePanel1.SetRow(this.lblPASSWORD_OLD, 2);
            this.lblPASSWORD_OLD.Size = new System.Drawing.Size(100, 13);
            this.lblPASSWORD_OLD.TabIndex = 0;
            this.lblPASSWORD_OLD.Text = "lblPASSWORD_OLD";
            // 
            // lblPASSWORD_NEW
            // 
            this.tablePanel1.SetColumn(this.lblPASSWORD_NEW, 0);
            this.lblPASSWORD_NEW.Location = new System.Drawing.Point(3, 67);
            this.lblPASSWORD_NEW.Name = "lblPASSWORD_NEW";
            this.tablePanel1.SetRow(this.lblPASSWORD_NEW, 3);
            this.lblPASSWORD_NEW.Size = new System.Drawing.Size(103, 13);
            this.lblPASSWORD_NEW.TabIndex = 0;
            this.lblPASSWORD_NEW.Text = "lblPASSWORD_NEW";
            // 
            // lblPASSWORD_NEW_RE
            // 
            this.tablePanel1.SetColumn(this.lblPASSWORD_NEW_RE, 0);
            this.lblPASSWORD_NEW_RE.Location = new System.Drawing.Point(3, 93);
            this.lblPASSWORD_NEW_RE.Name = "lblPASSWORD_NEW_RE";
            this.tablePanel1.SetRow(this.lblPASSWORD_NEW_RE, 4);
            this.lblPASSWORD_NEW_RE.Size = new System.Drawing.Size(121, 13);
            this.lblPASSWORD_NEW_RE.TabIndex = 0;
            this.lblPASSWORD_NEW_RE.Text = "lblPASSWORD_NEW_RE";
            // 
            // frmDoiMatKhau
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 155);
            this.Controls.Add(this.tablePanel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_OLD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_NEW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD_NEW_RE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.TextEdit txtUSER_NAME;
        private DevExpress.XtraEditors.TextEdit txtPASSWORD_OLD;
        private DevExpress.XtraEditors.TextEdit txtPASSWORD_NEW;
        private DevExpress.XtraEditors.TextEdit txtPASSWORD_NEW_RE;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblUSER_NAME;
        private DevExpress.XtraEditors.LabelControl lblPASSWORD_OLD;
        private DevExpress.XtraEditors.LabelControl lblPASSWORD_NEW;
        private DevExpress.XtraEditors.LabelControl lblPASSWORD_NEW_RE;
    }
}