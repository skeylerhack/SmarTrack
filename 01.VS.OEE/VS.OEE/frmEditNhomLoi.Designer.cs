namespace VS.OEE
{
    partial class frmEditNhomLoi
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
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.txtTHU_TU = new DevExpress.XtraEditors.SpinEdit();
            this.txtDefectGroupName_C = new DevExpress.XtraEditors.TextEdit();
            this.txtDefectGroupName_E = new DevExpress.XtraEditors.TextEdit();
            this.txtDefectGroupName = new DevExpress.XtraEditors.TextEdit();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.lblDefectGroupName_C = new DevExpress.XtraEditors.LabelControl();
            this.lblDefectGroupName_E = new DevExpress.XtraEditors.LabelControl();
            this.lblTHU_TU = new DevExpress.XtraEditors.LabelControl();
            this.lblDefectGroupName = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHU_TU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectGroupName_C.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectGroupName_E.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 15F)});
            this.tablePanel1.Controls.Add(this.flowLayoutPanel1);
            this.tablePanel1.Controls.Add(this.txtNote);
            this.tablePanel1.Controls.Add(this.txtTHU_TU);
            this.tablePanel1.Controls.Add(this.txtDefectGroupName_C);
            this.tablePanel1.Controls.Add(this.txtDefectGroupName_E);
            this.tablePanel1.Controls.Add(this.txtDefectGroupName);
            this.tablePanel1.Controls.Add(this.lblNote);
            this.tablePanel1.Controls.Add(this.lblDefectGroupName_C);
            this.tablePanel1.Controls.Add(this.lblDefectGroupName_E);
            this.tablePanel1.Controls.Add(this.lblTHU_TU);
            this.tablePanel1.Controls.Add(this.lblDefectGroupName);
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
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 50F)});
            this.tablePanel1.Size = new System.Drawing.Size(594, 368);
            this.tablePanel1.TabIndex = 0;
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
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(470, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(105, 30);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(359, 3);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(105, 30);
            this.btnGhi.TabIndex = 4;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // txtNote
            // 
            this.tablePanel1.SetColumn(this.txtNote, 1);
            this.tablePanel1.SetColumnSpan(this.txtNote, 3);
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNote.Location = new System.Drawing.Point(125, 77);
            this.txtNote.Name = "txtNote";
            this.tablePanel1.SetRow(this.txtNote, 3);
            this.tablePanel1.SetRowSpan(this.txtNote, 2);
            this.txtNote.Size = new System.Drawing.Size(461, 40);
            this.txtNote.TabIndex = 9;
            // 
            // txtTHU_TU
            // 
            this.tablePanel1.SetColumn(this.txtTHU_TU, 3);
            this.txtTHU_TU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTHU_TU.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTHU_TU.Location = new System.Drawing.Point(504, 8);
            this.txtTHU_TU.Name = "txtTHU_TU";
            this.txtTHU_TU.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.txtTHU_TU, 0);
            this.txtTHU_TU.Size = new System.Drawing.Size(82, 20);
            this.txtTHU_TU.TabIndex = 8;
            // 
            // txtDefectGroupName_C
            // 
            this.tablePanel1.SetColumn(this.txtDefectGroupName_C, 1);
            this.tablePanel1.SetColumnSpan(this.txtDefectGroupName_C, 3);
            this.txtDefectGroupName_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDefectGroupName_C.Location = new System.Drawing.Point(125, 54);
            this.txtDefectGroupName_C.Name = "txtDefectGroupName_C";
            this.tablePanel1.SetRow(this.txtDefectGroupName_C, 2);
            this.txtDefectGroupName_C.Size = new System.Drawing.Size(461, 20);
            this.txtDefectGroupName_C.TabIndex = 7;
            // 
            // txtDefectGroupName_E
            // 
            this.tablePanel1.SetColumn(this.txtDefectGroupName_E, 1);
            this.tablePanel1.SetColumnSpan(this.txtDefectGroupName_E, 3);
            this.txtDefectGroupName_E.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDefectGroupName_E.Location = new System.Drawing.Point(125, 31);
            this.txtDefectGroupName_E.Name = "txtDefectGroupName_E";
            this.tablePanel1.SetRow(this.txtDefectGroupName_E, 1);
            this.txtDefectGroupName_E.Size = new System.Drawing.Size(461, 20);
            this.txtDefectGroupName_E.TabIndex = 6;
            // 
            // txtDefectGroupName
            // 
            this.tablePanel1.SetColumn(this.txtDefectGroupName, 1);
            this.txtDefectGroupName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDefectGroupName.Location = new System.Drawing.Point(125, 8);
            this.txtDefectGroupName.Name = "txtDefectGroupName";
            this.tablePanel1.SetRow(this.txtDefectGroupName, 0);
            this.txtDefectGroupName.Size = new System.Drawing.Size(315, 20);
            this.txtDefectGroupName.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtDefectGroupName, conditionValidationRule1);
            // 
            // lblNote
            // 
            this.tablePanel1.SetColumn(this.lblNote, 0);
            this.lblNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNote.Location = new System.Drawing.Point(8, 77);
            this.lblNote.Name = "lblNote";
            this.tablePanel1.SetRow(this.lblNote, 3);
            this.lblNote.Size = new System.Drawing.Size(111, 17);
            this.lblNote.TabIndex = 4;
            this.lblNote.Text = "lblNote";
            // 
            // lblDefectGroupName_C
            // 
            this.tablePanel1.SetColumn(this.lblDefectGroupName_C, 0);
            this.lblDefectGroupName_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectGroupName_C.Location = new System.Drawing.Point(8, 54);
            this.lblDefectGroupName_C.Name = "lblDefectGroupName_C";
            this.tablePanel1.SetRow(this.lblDefectGroupName_C, 2);
            this.lblDefectGroupName_C.Size = new System.Drawing.Size(111, 17);
            this.lblDefectGroupName_C.TabIndex = 3;
            this.lblDefectGroupName_C.Text = "lblDefectGroupName_C";
            // 
            // lblDefectGroupName_E
            // 
            this.tablePanel1.SetColumn(this.lblDefectGroupName_E, 0);
            this.lblDefectGroupName_E.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectGroupName_E.Location = new System.Drawing.Point(8, 31);
            this.lblDefectGroupName_E.Name = "lblDefectGroupName_E";
            this.tablePanel1.SetRow(this.lblDefectGroupName_E, 1);
            this.lblDefectGroupName_E.Size = new System.Drawing.Size(111, 17);
            this.lblDefectGroupName_E.TabIndex = 2;
            this.lblDefectGroupName_E.Text = "lblDefectGroupName_E";
            // 
            // lblTHU_TU
            // 
            this.tablePanel1.SetColumn(this.lblTHU_TU, 2);
            this.lblTHU_TU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTHU_TU.Location = new System.Drawing.Point(446, 8);
            this.lblTHU_TU.Name = "lblTHU_TU";
            this.tablePanel1.SetRow(this.lblTHU_TU, 0);
            this.lblTHU_TU.Size = new System.Drawing.Size(52, 17);
            this.lblTHU_TU.TabIndex = 1;
            this.lblTHU_TU.Text = "lblTHU_TU";
            // 
            // lblDefectGroupName
            // 
            this.tablePanel1.SetColumn(this.lblDefectGroupName, 0);
            this.lblDefectGroupName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectGroupName.Location = new System.Drawing.Point(8, 8);
            this.lblDefectGroupName.Name = "lblDefectGroupName";
            this.tablePanel1.SetRow(this.lblDefectGroupName, 0);
            this.lblDefectGroupName.Size = new System.Drawing.Size(111, 17);
            this.lblDefectGroupName.TabIndex = 0;
            this.lblDefectGroupName.Text = "lblDefectGroupName";
            // 
            // frmEditNhomLoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 368);
            this.Controls.Add(this.tablePanel1);
            this.IconOptions.Image = global::VS.OEE.Properties.Resources.OEE;
            this.Name = "frmEditNhomLoi";
            this.Text = "frmEditNhomLoi";
            this.Load += new System.EventHandler(this.frmEditNhomLoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHU_TU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectGroupName_C.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectGroupName_E.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.SpinEdit txtTHU_TU;
        private DevExpress.XtraEditors.TextEdit txtDefectGroupName_C;
        private DevExpress.XtraEditors.TextEdit txtDefectGroupName_E;
        private DevExpress.XtraEditors.TextEdit txtDefectGroupName;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraEditors.LabelControl lblDefectGroupName_C;
        private DevExpress.XtraEditors.LabelControl lblDefectGroupName_E;
        private DevExpress.XtraEditors.LabelControl lblTHU_TU;
        private DevExpress.XtraEditors.LabelControl lblDefectGroupName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}