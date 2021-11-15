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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.tablePanel1.Controls.Add(this.panelControl1);
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
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F)});
            this.tablePanel1.Size = new System.Drawing.Size(594, 368);
            this.tablePanel1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.tablePanel1.SetColumnSpan(this.panelControl1, 4);
            this.panelControl1.Controls.Add(this.btnGhi);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Location = new System.Drawing.Point(3, 339);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 6);
            this.panelControl1.Size = new System.Drawing.Size(588, 26);
            this.panelControl1.TabIndex = 14;
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(427, 0);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 4;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(508, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtNote
            // 
            this.tablePanel1.SetColumn(this.txtNote, 1);
            this.tablePanel1.SetColumnSpan(this.txtNote, 3);
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNote.Location = new System.Drawing.Point(122, 89);
            this.txtNote.Name = "txtNote";
            this.tablePanel1.SetRow(this.txtNote, 4);
            this.tablePanel1.SetRowSpan(this.txtNote, 2);
            this.txtNote.Size = new System.Drawing.Size(469, 244);
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
            this.txtTHU_TU.Location = new System.Drawing.Point(508, 11);
            this.txtTHU_TU.Name = "txtTHU_TU";
            this.txtTHU_TU.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.txtTHU_TU, 1);
            this.txtTHU_TU.Size = new System.Drawing.Size(83, 20);
            this.txtTHU_TU.TabIndex = 8;
            // 
            // txtDefectGroupName_C
            // 
            this.tablePanel1.SetColumn(this.txtDefectGroupName_C, 1);
            this.tablePanel1.SetColumnSpan(this.txtDefectGroupName_C, 3);
            this.txtDefectGroupName_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDefectGroupName_C.Location = new System.Drawing.Point(122, 63);
            this.txtDefectGroupName_C.Name = "txtDefectGroupName_C";
            this.tablePanel1.SetRow(this.txtDefectGroupName_C, 3);
            this.txtDefectGroupName_C.Size = new System.Drawing.Size(469, 20);
            this.txtDefectGroupName_C.TabIndex = 7;
            // 
            // txtDefectGroupName_E
            // 
            this.tablePanel1.SetColumn(this.txtDefectGroupName_E, 1);
            this.tablePanel1.SetColumnSpan(this.txtDefectGroupName_E, 3);
            this.txtDefectGroupName_E.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDefectGroupName_E.Location = new System.Drawing.Point(122, 37);
            this.txtDefectGroupName_E.Name = "txtDefectGroupName_E";
            this.tablePanel1.SetRow(this.txtDefectGroupName_E, 2);
            this.txtDefectGroupName_E.Size = new System.Drawing.Size(469, 20);
            this.txtDefectGroupName_E.TabIndex = 6;
            // 
            // txtDefectGroupName
            // 
            this.tablePanel1.SetColumn(this.txtDefectGroupName, 1);
            this.txtDefectGroupName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDefectGroupName.Location = new System.Drawing.Point(122, 11);
            this.txtDefectGroupName.Name = "txtDefectGroupName";
            this.tablePanel1.SetRow(this.txtDefectGroupName, 1);
            this.txtDefectGroupName.Size = new System.Drawing.Size(321, 20);
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
            this.lblNote.Location = new System.Drawing.Point(3, 89);
            this.lblNote.Name = "lblNote";
            this.tablePanel1.SetRow(this.lblNote, 4);
            this.lblNote.Size = new System.Drawing.Size(113, 20);
            this.lblNote.TabIndex = 4;
            this.lblNote.Text = "lblNote";
            // 
            // lblDefectGroupName_C
            // 
            this.tablePanel1.SetColumn(this.lblDefectGroupName_C, 0);
            this.lblDefectGroupName_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectGroupName_C.Location = new System.Drawing.Point(3, 63);
            this.lblDefectGroupName_C.Name = "lblDefectGroupName_C";
            this.tablePanel1.SetRow(this.lblDefectGroupName_C, 3);
            this.lblDefectGroupName_C.Size = new System.Drawing.Size(113, 20);
            this.lblDefectGroupName_C.TabIndex = 3;
            this.lblDefectGroupName_C.Text = "lblDefectGroupName_C";
            // 
            // lblDefectGroupName_E
            // 
            this.tablePanel1.SetColumn(this.lblDefectGroupName_E, 0);
            this.lblDefectGroupName_E.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectGroupName_E.Location = new System.Drawing.Point(3, 37);
            this.lblDefectGroupName_E.Name = "lblDefectGroupName_E";
            this.tablePanel1.SetRow(this.lblDefectGroupName_E, 2);
            this.lblDefectGroupName_E.Size = new System.Drawing.Size(113, 20);
            this.lblDefectGroupName_E.TabIndex = 2;
            this.lblDefectGroupName_E.Text = "lblDefectGroupName_E";
            // 
            // lblTHU_TU
            // 
            this.tablePanel1.SetColumn(this.lblTHU_TU, 2);
            this.lblTHU_TU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTHU_TU.Location = new System.Drawing.Point(449, 11);
            this.lblTHU_TU.Name = "lblTHU_TU";
            this.tablePanel1.SetRow(this.lblTHU_TU, 1);
            this.lblTHU_TU.Size = new System.Drawing.Size(53, 20);
            this.lblTHU_TU.TabIndex = 1;
            this.lblTHU_TU.Text = "lblTHU_TU";
            // 
            // lblDefectGroupName
            // 
            this.tablePanel1.SetColumn(this.lblDefectGroupName, 0);
            this.lblDefectGroupName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectGroupName.Location = new System.Drawing.Point(3, 11);
            this.lblDefectGroupName.Name = "lblDefectGroupName";
            this.tablePanel1.SetRow(this.lblDefectGroupName, 1);
            this.lblDefectGroupName.Size = new System.Drawing.Size(113, 20);
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
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
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}