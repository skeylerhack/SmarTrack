namespace VS.OEE
{
    partial class frmEditLoaiMay
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.lblMS_LOAI_MAY = new DevExpress.XtraEditors.LabelControl();
            this.txtMS_LOAI_MAY = new DevExpress.XtraEditors.TextEdit();
            this.lblSTT_MAY = new DevExpress.XtraEditors.LabelControl();
            this.lblTEN_LOAI_MAY = new DevExpress.XtraEditors.LabelControl();
            this.txtTEN_LOAI_MAY = new DevExpress.XtraEditors.TextEdit();
            this.lblTEN_LOAI_MAY_ANH = new DevExpress.XtraEditors.LabelControl();
            this.lblTEN_LOAI_MAY_HOA = new DevExpress.XtraEditors.LabelControl();
            this.txtTEN_LOAI_MAY_ANH = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN_LOAI_MAY_HOA = new DevExpress.XtraEditors.TextEdit();
            this.lblGHI_CHU = new DevExpress.XtraEditors.LabelControl();
            this.chkATTACHMENT = new DevExpress.XtraEditors.CheckEdit();
            this.txtGHI_CHU = new DevExpress.XtraEditors.MemoEdit();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.txtSTT_MAY = new DevExpress.XtraEditors.SpinEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtMS_LOAI_MAY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_LOAI_MAY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_LOAI_MAY_ANH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_LOAI_MAY_HOA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkATTACHMENT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGHI_CHU.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTT_MAY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMS_LOAI_MAY
            // 
            this.tablePanel1.SetColumn(this.lblMS_LOAI_MAY, 0);
            this.lblMS_LOAI_MAY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMS_LOAI_MAY.Location = new System.Drawing.Point(8, 8);
            this.lblMS_LOAI_MAY.Name = "lblMS_LOAI_MAY";
            this.tablePanel1.SetRow(this.lblMS_LOAI_MAY, 0);
            this.lblMS_LOAI_MAY.Size = new System.Drawing.Size(170, 20);
            this.lblMS_LOAI_MAY.TabIndex = 0;
            this.lblMS_LOAI_MAY.Text = "lblMS_LOAI_MAY";
            // 
            // txtMS_LOAI_MAY
            // 
            this.tablePanel1.SetColumn(this.txtMS_LOAI_MAY, 1);
            this.txtMS_LOAI_MAY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMS_LOAI_MAY.Location = new System.Drawing.Point(184, 8);
            this.txtMS_LOAI_MAY.Name = "txtMS_LOAI_MAY";
            this.tablePanel1.SetRow(this.txtMS_LOAI_MAY, 0);
            this.txtMS_LOAI_MAY.Size = new System.Drawing.Size(184, 20);
            this.txtMS_LOAI_MAY.TabIndex = 1;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtMS_LOAI_MAY, conditionValidationRule3);
            // 
            // lblSTT_MAY
            // 
            this.tablePanel1.SetColumn(this.lblSTT_MAY, 2);
            this.lblSTT_MAY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSTT_MAY.Location = new System.Drawing.Point(375, 8);
            this.lblSTT_MAY.Name = "lblSTT_MAY";
            this.tablePanel1.SetRow(this.lblSTT_MAY, 0);
            this.lblSTT_MAY.Size = new System.Drawing.Size(99, 20);
            this.lblSTT_MAY.TabIndex = 2;
            this.lblSTT_MAY.Text = "lblSTT_MAY";
            // 
            // lblTEN_LOAI_MAY
            // 
            this.tablePanel1.SetColumn(this.lblTEN_LOAI_MAY, 0);
            this.lblTEN_LOAI_MAY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTEN_LOAI_MAY.Location = new System.Drawing.Point(8, 34);
            this.lblTEN_LOAI_MAY.Name = "lblTEN_LOAI_MAY";
            this.tablePanel1.SetRow(this.lblTEN_LOAI_MAY, 1);
            this.lblTEN_LOAI_MAY.Size = new System.Drawing.Size(170, 20);
            this.lblTEN_LOAI_MAY.TabIndex = 3;
            this.lblTEN_LOAI_MAY.Text = "lblTEN_LOAI_MAY";
            // 
            // txtTEN_LOAI_MAY
            // 
            this.tablePanel1.SetColumn(this.txtTEN_LOAI_MAY, 1);
            this.tablePanel1.SetColumnSpan(this.txtTEN_LOAI_MAY, 3);
            this.txtTEN_LOAI_MAY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEN_LOAI_MAY.Location = new System.Drawing.Point(184, 34);
            this.txtTEN_LOAI_MAY.Name = "txtTEN_LOAI_MAY";
            this.tablePanel1.SetRow(this.txtTEN_LOAI_MAY, 1);
            this.txtTEN_LOAI_MAY.Size = new System.Drawing.Size(402, 20);
            this.txtTEN_LOAI_MAY.TabIndex = 5;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtTEN_LOAI_MAY, conditionValidationRule2);
            // 
            // lblTEN_LOAI_MAY_ANH
            // 
            this.tablePanel1.SetColumn(this.lblTEN_LOAI_MAY_ANH, 0);
            this.lblTEN_LOAI_MAY_ANH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTEN_LOAI_MAY_ANH.Location = new System.Drawing.Point(8, 60);
            this.lblTEN_LOAI_MAY_ANH.Name = "lblTEN_LOAI_MAY_ANH";
            this.tablePanel1.SetRow(this.lblTEN_LOAI_MAY_ANH, 2);
            this.lblTEN_LOAI_MAY_ANH.Size = new System.Drawing.Size(170, 20);
            this.lblTEN_LOAI_MAY_ANH.TabIndex = 6;
            this.lblTEN_LOAI_MAY_ANH.Text = "lblTEN_LOAI_MAY_ANH";
            // 
            // lblTEN_LOAI_MAY_HOA
            // 
            this.tablePanel1.SetColumn(this.lblTEN_LOAI_MAY_HOA, 0);
            this.lblTEN_LOAI_MAY_HOA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTEN_LOAI_MAY_HOA.Location = new System.Drawing.Point(8, 86);
            this.lblTEN_LOAI_MAY_HOA.Name = "lblTEN_LOAI_MAY_HOA";
            this.tablePanel1.SetRow(this.lblTEN_LOAI_MAY_HOA, 3);
            this.lblTEN_LOAI_MAY_HOA.Size = new System.Drawing.Size(170, 20);
            this.lblTEN_LOAI_MAY_HOA.TabIndex = 7;
            this.lblTEN_LOAI_MAY_HOA.Text = "lblTEN_LOAI_MAY_HOA";
            // 
            // txtTEN_LOAI_MAY_ANH
            // 
            this.tablePanel1.SetColumn(this.txtTEN_LOAI_MAY_ANH, 1);
            this.tablePanel1.SetColumnSpan(this.txtTEN_LOAI_MAY_ANH, 3);
            this.txtTEN_LOAI_MAY_ANH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEN_LOAI_MAY_ANH.Location = new System.Drawing.Point(184, 60);
            this.txtTEN_LOAI_MAY_ANH.Name = "txtTEN_LOAI_MAY_ANH";
            this.tablePanel1.SetRow(this.txtTEN_LOAI_MAY_ANH, 2);
            this.txtTEN_LOAI_MAY_ANH.Size = new System.Drawing.Size(402, 20);
            this.txtTEN_LOAI_MAY_ANH.TabIndex = 8;
            // 
            // txtTEN_LOAI_MAY_HOA
            // 
            this.tablePanel1.SetColumn(this.txtTEN_LOAI_MAY_HOA, 1);
            this.tablePanel1.SetColumnSpan(this.txtTEN_LOAI_MAY_HOA, 2);
            this.txtTEN_LOAI_MAY_HOA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEN_LOAI_MAY_HOA.Location = new System.Drawing.Point(184, 86);
            this.txtTEN_LOAI_MAY_HOA.Name = "txtTEN_LOAI_MAY_HOA";
            this.tablePanel1.SetRow(this.txtTEN_LOAI_MAY_HOA, 3);
            this.txtTEN_LOAI_MAY_HOA.Size = new System.Drawing.Size(290, 20);
            this.txtTEN_LOAI_MAY_HOA.TabIndex = 9;
            // 
            // lblGHI_CHU
            // 
            this.tablePanel1.SetColumn(this.lblGHI_CHU, 0);
            this.lblGHI_CHU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGHI_CHU.Location = new System.Drawing.Point(8, 112);
            this.lblGHI_CHU.Name = "lblGHI_CHU";
            this.tablePanel1.SetRow(this.lblGHI_CHU, 4);
            this.tablePanel1.SetRowSpan(this.lblGHI_CHU, 2);
            this.lblGHI_CHU.Size = new System.Drawing.Size(170, 46);
            this.lblGHI_CHU.TabIndex = 10;
            this.lblGHI_CHU.Text = "lblGHI_CHU";
            // 
            // chkATTACHMENT
            // 
            this.tablePanel1.SetColumn(this.chkATTACHMENT, 3);
            this.chkATTACHMENT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkATTACHMENT.Location = new System.Drawing.Point(480, 86);
            this.chkATTACHMENT.Name = "chkATTACHMENT";
            this.chkATTACHMENT.Properties.Caption = "";
            this.chkATTACHMENT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tablePanel1.SetRow(this.chkATTACHMENT, 3);
            this.chkATTACHMENT.Size = new System.Drawing.Size(106, 20);
            this.chkATTACHMENT.TabIndex = 12;
            // 
            // txtGHI_CHU
            // 
            this.tablePanel1.SetColumn(this.txtGHI_CHU, 1);
            this.tablePanel1.SetColumnSpan(this.txtGHI_CHU, 3);
            this.txtGHI_CHU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGHI_CHU.EditValue = "";
            this.txtGHI_CHU.Location = new System.Drawing.Point(184, 112);
            this.txtGHI_CHU.Name = "txtGHI_CHU";
            this.tablePanel1.SetRow(this.txtGHI_CHU, 4);
            this.tablePanel1.SetRowSpan(this.txtGHI_CHU, 2);
            this.txtGHI_CHU.Size = new System.Drawing.Size(402, 46);
            this.txtGHI_CHU.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            this.tablePanel1.SetColumn(this.flowLayoutPanel1, 0);
            this.tablePanel1.SetColumnSpan(this.flowLayoutPanel1, 4);
            this.flowLayoutPanel1.Controls.Add(this.btnThoat);
            this.flowLayoutPanel1.Controls.Add(this.btnGhi);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 325);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tablePanel1.SetRow(this.flowLayoutPanel1, 7);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(578, 35);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(470, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(105, 30);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(359, 3);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(105, 30);
            this.btnGhi.TabIndex = 1;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30.2F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 32.6F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 19.2F)});
            this.tablePanel1.Controls.Add(this.txtSTT_MAY);
            this.tablePanel1.Controls.Add(this.flowLayoutPanel1);
            this.tablePanel1.Controls.Add(this.txtGHI_CHU);
            this.tablePanel1.Controls.Add(this.chkATTACHMENT);
            this.tablePanel1.Controls.Add(this.lblGHI_CHU);
            this.tablePanel1.Controls.Add(this.txtTEN_LOAI_MAY_HOA);
            this.tablePanel1.Controls.Add(this.txtTEN_LOAI_MAY_ANH);
            this.tablePanel1.Controls.Add(this.lblTEN_LOAI_MAY_HOA);
            this.tablePanel1.Controls.Add(this.lblTEN_LOAI_MAY_ANH);
            this.tablePanel1.Controls.Add(this.txtTEN_LOAI_MAY);
            this.tablePanel1.Controls.Add(this.lblTEN_LOAI_MAY);
            this.tablePanel1.Controls.Add(this.lblSTT_MAY);
            this.tablePanel1.Controls.Add(this.txtMS_LOAI_MAY);
            this.tablePanel1.Controls.Add(this.lblMS_LOAI_MAY);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 41F)});
            this.tablePanel1.Size = new System.Drawing.Size(594, 368);
            this.tablePanel1.TabIndex = 0;
            // 
            // txtSTT_MAY
            // 
            this.tablePanel1.SetColumn(this.txtSTT_MAY, 3);
            this.txtSTT_MAY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSTT_MAY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSTT_MAY.Location = new System.Drawing.Point(480, 8);
            this.txtSTT_MAY.Name = "txtSTT_MAY";
            this.txtSTT_MAY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSTT_MAY.Properties.DisplayFormat.FormatString = "n0";
            this.txtSTT_MAY.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSTT_MAY.Properties.EditFormat.FormatString = "n0";
            this.txtSTT_MAY.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSTT_MAY.Properties.Mask.EditMask = "n0";
            this.tablePanel1.SetRow(this.txtSTT_MAY, 0);
            this.txtSTT_MAY.Size = new System.Drawing.Size(106, 20);
            this.txtSTT_MAY.TabIndex = 15;
            // 
            // frmEditLoaiMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 368);
            this.Controls.Add(this.tablePanel1);
            this.IconOptions.Image = global::VS.OEE.Properties.Resources.OEE;
            this.Name = "frmEditLoaiMay";
            this.Text = "frmEditLoaiMay";
            this.Load += new System.EventHandler(this.frmEditLoaiMay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMS_LOAI_MAY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_LOAI_MAY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_LOAI_MAY_ANH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_LOAI_MAY_HOA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkATTACHMENT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGHI_CHU.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTT_MAY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblMS_LOAI_MAY;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SpinEdit txtSTT_MAY;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.MemoEdit txtGHI_CHU;
        private DevExpress.XtraEditors.CheckEdit chkATTACHMENT;
        private DevExpress.XtraEditors.LabelControl lblGHI_CHU;
        private DevExpress.XtraEditors.TextEdit txtTEN_LOAI_MAY_HOA;
        private DevExpress.XtraEditors.TextEdit txtTEN_LOAI_MAY_ANH;
        private DevExpress.XtraEditors.LabelControl lblTEN_LOAI_MAY_HOA;
        private DevExpress.XtraEditors.LabelControl lblTEN_LOAI_MAY_ANH;
        private DevExpress.XtraEditors.TextEdit txtTEN_LOAI_MAY;
        private DevExpress.XtraEditors.LabelControl lblTEN_LOAI_MAY;
        private DevExpress.XtraEditors.LabelControl lblSTT_MAY;
        private DevExpress.XtraEditors.TextEdit txtMS_LOAI_MAY;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}