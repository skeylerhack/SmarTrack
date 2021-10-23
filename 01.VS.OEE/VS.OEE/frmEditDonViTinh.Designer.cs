namespace VS.OEE
{
    partial class frmEditDonViTinh
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
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.lblDVT = new DevExpress.XtraEditors.LabelControl();
            this.lblSO_SO_LE = new DevExpress.XtraEditors.LabelControl();
            this.lblTEN_1 = new DevExpress.XtraEditors.LabelControl();
            this.lblTEN_2 = new DevExpress.XtraEditors.LabelControl();
            this.lblTEN_3 = new DevExpress.XtraEditors.LabelControl();
            this.lblGHI_CHU = new DevExpress.XtraEditors.LabelControl();
            this.txtSO_SO_LE = new DevExpress.XtraEditors.SpinEdit();
            this.txtGHI_CHU = new DevExpress.XtraEditors.MemoEdit();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.txtDVT = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_1 = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_2 = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_3 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSO_SO_LE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGHI_CHU.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDVT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F)});
            this.tablePanel1.Controls.Add(this.txtTEN_3);
            this.tablePanel1.Controls.Add(this.txtTEN_2);
            this.tablePanel1.Controls.Add(this.txtTEN_1);
            this.tablePanel1.Controls.Add(this.txtDVT);
            this.tablePanel1.Controls.Add(this.flowLayoutPanel1);
            this.tablePanel1.Controls.Add(this.txtGHI_CHU);
            this.tablePanel1.Controls.Add(this.txtSO_SO_LE);
            this.tablePanel1.Controls.Add(this.lblGHI_CHU);
            this.tablePanel1.Controls.Add(this.lblTEN_3);
            this.tablePanel1.Controls.Add(this.lblTEN_2);
            this.tablePanel1.Controls.Add(this.lblTEN_1);
            this.tablePanel1.Controls.Add(this.lblSO_SO_LE);
            this.tablePanel1.Controls.Add(this.lblDVT);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 43F)});
            this.tablePanel1.Size = new System.Drawing.Size(594, 368);
            this.tablePanel1.TabIndex = 0;
            // 
            // lblDVT
            // 
            this.tablePanel1.SetColumn(this.lblDVT, 0);
            this.lblDVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDVT.Location = new System.Drawing.Point(3, 3);
            this.lblDVT.Name = "lblDVT";
            this.tablePanel1.SetRow(this.lblDVT, 0);
            this.lblDVT.Size = new System.Drawing.Size(113, 20);
            this.lblDVT.TabIndex = 0;
            this.lblDVT.Text = "lblDVT";
            // 
            // lblSO_SO_LE
            // 
            this.tablePanel1.SetColumn(this.lblSO_SO_LE, 2);
            this.lblSO_SO_LE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSO_SO_LE.Location = new System.Drawing.Point(300, 3);
            this.lblSO_SO_LE.Name = "lblSO_SO_LE";
            this.tablePanel1.SetRow(this.lblSO_SO_LE, 0);
            this.lblSO_SO_LE.Size = new System.Drawing.Size(113, 20);
            this.lblSO_SO_LE.TabIndex = 1;
            this.lblSO_SO_LE.Text = "lblSO_SO_LE";
            // 
            // lblTEN_1
            // 
            this.tablePanel1.SetColumn(this.lblTEN_1, 0);
            this.lblTEN_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTEN_1.Location = new System.Drawing.Point(3, 29);
            this.lblTEN_1.Name = "lblTEN_1";
            this.tablePanel1.SetRow(this.lblTEN_1, 1);
            this.lblTEN_1.Size = new System.Drawing.Size(113, 20);
            this.lblTEN_1.TabIndex = 2;
            this.lblTEN_1.Text = "lblTEN_1";
            // 
            // lblTEN_2
            // 
            this.tablePanel1.SetColumn(this.lblTEN_2, 0);
            this.lblTEN_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTEN_2.Location = new System.Drawing.Point(3, 55);
            this.lblTEN_2.Name = "lblTEN_2";
            this.tablePanel1.SetRow(this.lblTEN_2, 2);
            this.lblTEN_2.Size = new System.Drawing.Size(113, 20);
            this.lblTEN_2.TabIndex = 3;
            this.lblTEN_2.Text = "lblTEN_2";
            // 
            // lblTEN_3
            // 
            this.tablePanel1.SetColumn(this.lblTEN_3, 0);
            this.lblTEN_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTEN_3.Location = new System.Drawing.Point(3, 81);
            this.lblTEN_3.Name = "lblTEN_3";
            this.tablePanel1.SetRow(this.lblTEN_3, 3);
            this.lblTEN_3.Size = new System.Drawing.Size(113, 20);
            this.lblTEN_3.TabIndex = 4;
            this.lblTEN_3.Text = "lblTEN_3";
            // 
            // lblGHI_CHU
            // 
            this.tablePanel1.SetColumn(this.lblGHI_CHU, 0);
            this.lblGHI_CHU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGHI_CHU.Location = new System.Drawing.Point(3, 107);
            this.lblGHI_CHU.Name = "lblGHI_CHU";
            this.tablePanel1.SetRow(this.lblGHI_CHU, 4);
            this.lblGHI_CHU.Size = new System.Drawing.Size(113, 20);
            this.lblGHI_CHU.TabIndex = 5;
            this.lblGHI_CHU.Text = "lblGHI_CHU";
            // 
            // txtSO_SO_LE
            // 
            this.tablePanel1.SetColumn(this.txtSO_SO_LE, 3);
            this.txtSO_SO_LE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSO_SO_LE.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSO_SO_LE.Location = new System.Drawing.Point(419, 3);
            this.txtSO_SO_LE.Name = "txtSO_SO_LE";
            this.txtSO_SO_LE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSO_SO_LE.Properties.EditFormat.FormatString = "n0";
            this.txtSO_SO_LE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSO_SO_LE.Properties.Mask.EditMask = "n0";
            this.tablePanel1.SetRow(this.txtSO_SO_LE, 0);
            this.txtSO_SO_LE.Size = new System.Drawing.Size(172, 20);
            this.txtSO_SO_LE.TabIndex = 10;
            // 
            // txtGHI_CHU
            // 
            this.tablePanel1.SetColumn(this.txtGHI_CHU, 1);
            this.tablePanel1.SetColumnSpan(this.txtGHI_CHU, 3);
            this.txtGHI_CHU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGHI_CHU.Location = new System.Drawing.Point(122, 107);
            this.txtGHI_CHU.Name = "txtGHI_CHU";
            this.tablePanel1.SetRow(this.txtGHI_CHU, 4);
            this.tablePanel1.SetRowSpan(this.txtGHI_CHU, 2);
            this.txtGHI_CHU.Size = new System.Drawing.Size(469, 46);
            this.txtGHI_CHU.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.tablePanel1.SetColumn(this.flowLayoutPanel1, 0);
            this.tablePanel1.SetColumnSpan(this.flowLayoutPanel1, 6);
            this.flowLayoutPanel1.Controls.Add(this.btnThoat);
            this.flowLayoutPanel1.Controls.Add(this.btnGhi);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 328);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tablePanel1.SetRow(this.flowLayoutPanel1, 8);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(588, 37);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(485, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 30);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(379, 3);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(100, 30);
            this.btnGhi.TabIndex = 1;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // txtDVT
            // 
            this.tablePanel1.SetColumn(this.txtDVT, 1);
            this.txtDVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDVT.Location = new System.Drawing.Point(122, 3);
            this.txtDVT.Name = "txtDVT";
            this.tablePanel1.SetRow(this.txtDVT, 0);
            this.txtDVT.Size = new System.Drawing.Size(172, 20);
            this.txtDVT.TabIndex = 24;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtDVT, conditionValidationRule2);
            // 
            // txtTEN_1
            // 
            this.tablePanel1.SetColumn(this.txtTEN_1, 1);
            this.tablePanel1.SetColumnSpan(this.txtTEN_1, 3);
            this.txtTEN_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEN_1.Location = new System.Drawing.Point(122, 29);
            this.txtTEN_1.Name = "txtTEN_1";
            this.tablePanel1.SetRow(this.txtTEN_1, 1);
            this.txtTEN_1.Size = new System.Drawing.Size(469, 20);
            this.txtTEN_1.TabIndex = 25;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtTEN_1, conditionValidationRule1);
            // 
            // txtTEN_2
            // 
            this.tablePanel1.SetColumn(this.txtTEN_2, 1);
            this.tablePanel1.SetColumnSpan(this.txtTEN_2, 3);
            this.txtTEN_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEN_2.Location = new System.Drawing.Point(122, 55);
            this.txtTEN_2.Name = "txtTEN_2";
            this.tablePanel1.SetRow(this.txtTEN_2, 2);
            this.txtTEN_2.Size = new System.Drawing.Size(469, 20);
            this.txtTEN_2.TabIndex = 26;
            // 
            // txtTEN_3
            // 
            this.tablePanel1.SetColumn(this.txtTEN_3, 1);
            this.tablePanel1.SetColumnSpan(this.txtTEN_3, 3);
            this.txtTEN_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEN_3.Location = new System.Drawing.Point(122, 81);
            this.txtTEN_3.Name = "txtTEN_3";
            this.tablePanel1.SetRow(this.txtTEN_3, 3);
            this.txtTEN_3.Size = new System.Drawing.Size(469, 20);
            this.txtTEN_3.TabIndex = 27;
            // 
            // frmEditDonViTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 368);
            this.Controls.Add(this.tablePanel1);
            this.Name = "frmEditDonViTinh";
            this.Text = "frmEditDonViTinh";
            this.Load += new System.EventHandler(this.frmEditDonViTinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSO_SO_LE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGHI_CHU.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDVT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_3.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl lblGHI_CHU;
        private DevExpress.XtraEditors.LabelControl lblTEN_3;
        private DevExpress.XtraEditors.LabelControl lblTEN_2;
        private DevExpress.XtraEditors.LabelControl lblTEN_1;
        private DevExpress.XtraEditors.LabelControl lblSO_SO_LE;
        private DevExpress.XtraEditors.LabelControl lblDVT;
        private DevExpress.XtraEditors.MemoEdit txtGHI_CHU;
        private DevExpress.XtraEditors.SpinEdit txtSO_SO_LE;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.TextEdit txtTEN_3;
        private DevExpress.XtraEditors.TextEdit txtTEN_2;
        private DevExpress.XtraEditors.TextEdit txtTEN_1;
        private DevExpress.XtraEditors.TextEdit txtDVT;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}