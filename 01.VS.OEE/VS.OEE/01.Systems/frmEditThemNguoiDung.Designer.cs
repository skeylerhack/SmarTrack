namespace VS.OEE
{
    partial class frmEditThemNguoiDung
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.cboID_NHOM = new DevExpress.XtraEditors.LookUpEdit();
            this.txtUSER_MAIL = new DevExpress.XtraEditors.TextEdit();
            this.txtPASSWORD = new DevExpress.XtraEditors.TextEdit();
            this.txtFULL_NAME = new DevExpress.XtraEditors.TextEdit();
            this.txtUSER_NAME = new DevExpress.XtraEditors.TextEdit();
            this.txtDESCRIPTION = new DevExpress.XtraEditors.MemoEdit();
            this.ckbACTIVE = new DevExpress.XtraEditors.CheckEdit();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblID_NHOM = new DevExpress.XtraEditors.LabelControl();
            this.lblUSER_NAME = new DevExpress.XtraEditors.LabelControl();
            this.lblPASSWORD = new DevExpress.XtraEditors.LabelControl();
            this.lblFULL_NAME = new DevExpress.XtraEditors.LabelControl();
            this.lblUSER_MAIL = new DevExpress.XtraEditors.LabelControl();
            this.lblDESCRIPTION = new DevExpress.XtraEditors.LabelControl();
            this.lblCongNhan = new DevExpress.XtraEditors.LabelControl();
            this.cboCongNhan = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_NHOM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_MAIL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFULL_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDESCRIPTION.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbACTIVE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCongNhan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboID_NHOM
            // 
            this.tablePanel1.SetColumn(this.cboID_NHOM, 1);
            this.cboID_NHOM.Location = new System.Drawing.Point(123, 11);
            this.cboID_NHOM.Name = "cboID_NHOM";
            this.cboID_NHOM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_NHOM.Properties.NullText = "";
            this.cboID_NHOM.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.tablePanel1.SetRow(this.cboID_NHOM, 1);
            this.cboID_NHOM.Size = new System.Drawing.Size(165, 20);
            this.cboID_NHOM.TabIndex = 15;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.cboID_NHOM, conditionValidationRule2);
            this.cboID_NHOM.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboID_NHOM_ButtonClick);
            // 
            // txtUSER_MAIL
            // 
            this.tablePanel1.SetColumn(this.txtUSER_MAIL, 1);
            this.tablePanel1.SetColumnSpan(this.txtUSER_MAIL, 3);
            this.txtUSER_MAIL.Location = new System.Drawing.Point(123, 89);
            this.txtUSER_MAIL.Name = "txtUSER_MAIL";
            this.tablePanel1.SetRow(this.txtUSER_MAIL, 4);
            this.txtUSER_MAIL.Size = new System.Drawing.Size(456, 20);
            this.txtUSER_MAIL.TabIndex = 8;
            // 
            // txtPASSWORD
            // 
            this.tablePanel1.SetColumn(this.txtPASSWORD, 3);
            this.txtPASSWORD.Location = new System.Drawing.Point(414, 37);
            this.txtPASSWORD.Name = "txtPASSWORD";
            this.txtPASSWORD.Properties.UseSystemPasswordChar = true;
            this.tablePanel1.SetRow(this.txtPASSWORD, 2);
            this.txtPASSWORD.Size = new System.Drawing.Size(165, 20);
            this.txtPASSWORD.TabIndex = 7;
            // 
            // txtFULL_NAME
            // 
            this.tablePanel1.SetColumn(this.txtFULL_NAME, 1);
            this.txtFULL_NAME.Location = new System.Drawing.Point(123, 63);
            this.txtFULL_NAME.Name = "txtFULL_NAME";
            this.tablePanel1.SetRow(this.txtFULL_NAME, 3);
            this.txtFULL_NAME.Size = new System.Drawing.Size(165, 20);
            this.txtFULL_NAME.TabIndex = 6;
            // 
            // txtUSER_NAME
            // 
            this.tablePanel1.SetColumn(this.txtUSER_NAME, 1);
            this.txtUSER_NAME.Location = new System.Drawing.Point(123, 37);
            this.txtUSER_NAME.Name = "txtUSER_NAME";
            this.tablePanel1.SetRow(this.txtUSER_NAME, 2);
            this.txtUSER_NAME.Size = new System.Drawing.Size(165, 20);
            this.txtUSER_NAME.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtUSER_NAME, conditionValidationRule1);
            // 
            // txtDESCRIPTION
            // 
            this.tablePanel1.SetColumn(this.txtDESCRIPTION, 1);
            this.tablePanel1.SetColumnSpan(this.txtDESCRIPTION, 3);
            this.txtDESCRIPTION.EditValue = "";
            this.txtDESCRIPTION.Location = new System.Drawing.Point(123, 115);
            this.txtDESCRIPTION.Name = "txtDESCRIPTION";
            this.tablePanel1.SetRow(this.txtDESCRIPTION, 5);
            this.txtDESCRIPTION.Size = new System.Drawing.Size(456, 46);
            this.txtDESCRIPTION.TabIndex = 9;
            // 
            // ckbACTIVE
            // 
            this.tablePanel1.SetColumn(this.ckbACTIVE, 3);
            this.ckbACTIVE.Location = new System.Drawing.Point(414, 11);
            this.ckbACTIVE.Name = "ckbACTIVE";
            this.ckbACTIVE.Properties.Caption = "ckbACTIVE";
            this.tablePanel1.SetRow(this.ckbACTIVE, 1);
            this.ckbACTIVE.Size = new System.Drawing.Size(165, 19);
            this.ckbACTIVE.TabIndex = 10;
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(414, 1);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 12;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhong.Location = new System.Drawing.Point(496, 1);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(80, 26);
            this.btnKhong.TabIndex = 13;
            this.btnKhong.Text = "btnKhong";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.lblID_NHOM);
            this.tablePanel1.Controls.Add(this.cboID_NHOM);
            this.tablePanel1.Controls.Add(this.ckbACTIVE);
            this.tablePanel1.Controls.Add(this.lblUSER_NAME);
            this.tablePanel1.Controls.Add(this.txtDESCRIPTION);
            this.tablePanel1.Controls.Add(this.txtUSER_MAIL);
            this.tablePanel1.Controls.Add(this.lblPASSWORD);
            this.tablePanel1.Controls.Add(this.txtFULL_NAME);
            this.tablePanel1.Controls.Add(this.txtPASSWORD);
            this.tablePanel1.Controls.Add(this.txtUSER_NAME);
            this.tablePanel1.Controls.Add(this.lblFULL_NAME);
            this.tablePanel1.Controls.Add(this.lblUSER_MAIL);
            this.tablePanel1.Controls.Add(this.lblDESCRIPTION);
            this.tablePanel1.Controls.Add(this.lblCongNhan);
            this.tablePanel1.Controls.Add(this.cboCongNhan);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 52F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.tablePanel1.Size = new System.Drawing.Size(582, 309);
            this.tablePanel1.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.tablePanel1.SetColumnSpan(this.panelControl1, 4);
            this.panelControl1.Controls.Add(this.btnKhong);
            this.panelControl1.Controls.Add(this.btnGhi);
            this.panelControl1.Location = new System.Drawing.Point(3, 277);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 7);
            this.panelControl1.Size = new System.Drawing.Size(576, 29);
            this.panelControl1.TabIndex = 17;
            // 
            // lblID_NHOM
            // 
            this.lblID_NHOM.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblID_NHOM.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.lblID_NHOM, 0);
            this.lblID_NHOM.Location = new System.Drawing.Point(3, 14);
            this.lblID_NHOM.Name = "lblID_NHOM";
            this.tablePanel1.SetRow(this.lblID_NHOM, 1);
            this.lblID_NHOM.Size = new System.Drawing.Size(65, 13);
            this.lblID_NHOM.TabIndex = 16;
            this.lblID_NHOM.Text = "lblID_NHOM";
            // 
            // lblUSER_NAME
            // 
            this.lblUSER_NAME.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblUSER_NAME.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.lblUSER_NAME, 0);
            this.lblUSER_NAME.Location = new System.Drawing.Point(3, 40);
            this.lblUSER_NAME.Name = "lblUSER_NAME";
            this.tablePanel1.SetRow(this.lblUSER_NAME, 2);
            this.lblUSER_NAME.Size = new System.Drawing.Size(79, 13);
            this.lblUSER_NAME.TabIndex = 16;
            this.lblUSER_NAME.Text = "lblUSER_NAME";
            // 
            // lblPASSWORD
            // 
            this.lblPASSWORD.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPASSWORD.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.lblPASSWORD, 2);
            this.lblPASSWORD.Location = new System.Drawing.Point(294, 40);
            this.lblPASSWORD.Name = "lblPASSWORD";
            this.tablePanel1.SetRow(this.lblPASSWORD, 2);
            this.lblPASSWORD.Size = new System.Drawing.Size(74, 13);
            this.lblPASSWORD.TabIndex = 16;
            this.lblPASSWORD.Text = "lblPASSWORD";
            // 
            // lblFULL_NAME
            // 
            this.tablePanel1.SetColumn(this.lblFULL_NAME, 0);
            this.lblFULL_NAME.Location = new System.Drawing.Point(3, 66);
            this.lblFULL_NAME.Name = "lblFULL_NAME";
            this.tablePanel1.SetRow(this.lblFULL_NAME, 3);
            this.lblFULL_NAME.Size = new System.Drawing.Size(73, 13);
            this.lblFULL_NAME.TabIndex = 16;
            this.lblFULL_NAME.Text = "lblFULL_NAME";
            // 
            // lblUSER_MAIL
            // 
            this.tablePanel1.SetColumn(this.lblUSER_MAIL, 0);
            this.lblUSER_MAIL.Location = new System.Drawing.Point(3, 92);
            this.lblUSER_MAIL.Name = "lblUSER_MAIL";
            this.tablePanel1.SetRow(this.lblUSER_MAIL, 4);
            this.lblUSER_MAIL.Size = new System.Drawing.Size(70, 13);
            this.lblUSER_MAIL.TabIndex = 16;
            this.lblUSER_MAIL.Text = "lblUSER_MAIL";
            // 
            // lblDESCRIPTION
            // 
            this.tablePanel1.SetColumn(this.lblDESCRIPTION, 0);
            this.lblDESCRIPTION.Location = new System.Drawing.Point(3, 116);
            this.lblDESCRIPTION.Name = "lblDESCRIPTION";
            this.tablePanel1.SetRow(this.lblDESCRIPTION, 5);
            this.lblDESCRIPTION.Size = new System.Drawing.Size(82, 13);
            this.lblDESCRIPTION.TabIndex = 16;
            this.lblDESCRIPTION.Text = "lblDESCRIPTION";
            // 
            // lblCongNhan
            // 
            this.tablePanel1.SetColumn(this.lblCongNhan, 2);
            this.lblCongNhan.Location = new System.Drawing.Point(294, 66);
            this.lblCongNhan.Name = "lblCongNhan";
            this.tablePanel1.SetRow(this.lblCongNhan, 3);
            this.lblCongNhan.Size = new System.Drawing.Size(69, 13);
            this.lblCongNhan.TabIndex = 16;
            this.lblCongNhan.Text = "lblCongNhan";
            // 
            // cboCongNhan
            // 
            this.tablePanel1.SetColumn(this.cboCongNhan, 3);
            this.cboCongNhan.Location = new System.Drawing.Point(414, 63);
            this.cboCongNhan.Name = "cboCongNhan";
            this.cboCongNhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCongNhan.Properties.NullText = "";
            this.cboCongNhan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.tablePanel1.SetRow(this.cboCongNhan, 3);
            this.cboCongNhan.Size = new System.Drawing.Size(165, 20);
            this.cboCongNhan.TabIndex = 15;
            this.cboCongNhan.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboID_NHOM_ButtonClick);
            // 
            // frmEditThemNguoiDung
            // 
            this.ClientSize = new System.Drawing.Size(582, 309);
            this.Controls.Add(this.tablePanel1);
            this.Name = "frmEditThemNguoiDung";
            this.Text = "frmEditThemNguoiDung";
            this.Load += new System.EventHandler(this.frmEditThemNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboID_NHOM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_MAIL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFULL_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDESCRIPTION.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbACTIVE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboCongNhan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtUSER_MAIL;
        private DevExpress.XtraEditors.TextEdit txtPASSWORD;
        private DevExpress.XtraEditors.TextEdit txtFULL_NAME;
        private DevExpress.XtraEditors.TextEdit txtUSER_NAME;
        private DevExpress.XtraEditors.MemoEdit txtDESCRIPTION;
        private DevExpress.XtraEditors.CheckEdit ckbACTIVE;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.LookUpEdit cboID_NHOM;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblID_NHOM;
        private DevExpress.XtraEditors.LabelControl lblUSER_NAME;
        private DevExpress.XtraEditors.LabelControl lblPASSWORD;
        private DevExpress.XtraEditors.LabelControl lblFULL_NAME;
        private DevExpress.XtraEditors.LabelControl lblUSER_MAIL;
        private DevExpress.XtraEditors.LabelControl lblDESCRIPTION;
        private DevExpress.XtraEditors.LabelControl lblCongNhan;
        private DevExpress.XtraEditors.LookUpEdit cboCongNhan;
    }
}