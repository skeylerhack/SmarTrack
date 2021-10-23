namespace VS.OEE
{
    partial class frmEditLoaiLoi
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.cboID_DG = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.txtTHU_TU = new DevExpress.XtraEditors.SpinEdit();
            this.txtDefectName_C = new DevExpress.XtraEditors.TextEdit();
            this.txtDefectName_E = new DevExpress.XtraEditors.TextEdit();
            this.txtDefectName = new DevExpress.XtraEditors.TextEdit();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.lblDefectName_C = new DevExpress.XtraEditors.LabelControl();
            this.lblDefectName_E = new DevExpress.XtraEditors.LabelControl();
            this.lblDefectName = new DevExpress.XtraEditors.LabelControl();
            this.lblTHU_TU = new DevExpress.XtraEditors.LabelControl();
            this.lblID_DG = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_DG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHU_TU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectName_C.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectName_E.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F)});
            this.tablePanel1.Controls.Add(this.cboID_DG);
            this.tablePanel1.Controls.Add(this.flowLayoutPanel1);
            this.tablePanel1.Controls.Add(this.txtNote);
            this.tablePanel1.Controls.Add(this.txtTHU_TU);
            this.tablePanel1.Controls.Add(this.txtDefectName_C);
            this.tablePanel1.Controls.Add(this.txtDefectName_E);
            this.tablePanel1.Controls.Add(this.txtDefectName);
            this.tablePanel1.Controls.Add(this.lblNote);
            this.tablePanel1.Controls.Add(this.lblDefectName_C);
            this.tablePanel1.Controls.Add(this.lblDefectName_E);
            this.tablePanel1.Controls.Add(this.lblDefectName);
            this.tablePanel1.Controls.Add(this.lblTHU_TU);
            this.tablePanel1.Controls.Add(this.lblID_DG);
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
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 50F)});
            this.tablePanel1.Size = new System.Drawing.Size(594, 368);
            this.tablePanel1.TabIndex = 0;
            // 
            // cboID_DG
            // 
            this.tablePanel1.SetColumn(this.cboID_DG, 1);
            this.cboID_DG.Location = new System.Drawing.Point(125, 8);
            this.cboID_DG.Name = "cboID_DG";
            this.cboID_DG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_DG.Properties.NullText = "";
            this.cboID_DG.Properties.PopupView = this.searchLookUpEdit1View;
            this.tablePanel1.SetRow(this.cboID_DG, 0);
            this.cboID_DG.Size = new System.Drawing.Size(169, 20);
            this.cboID_DG.TabIndex = 13;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.cboID_DG, conditionValidationRule1);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.DetailHeight = 303;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
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
            this.flowLayoutPanel1.TabIndex = 12;
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
            this.txtNote.Location = new System.Drawing.Point(125, 100);
            this.txtNote.Name = "txtNote";
            this.tablePanel1.SetRow(this.txtNote, 4);
            this.tablePanel1.SetRowSpan(this.txtNote, 2);
            this.txtNote.Size = new System.Drawing.Size(461, 40);
            this.txtNote.TabIndex = 11;
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
            this.txtTHU_TU.Location = new System.Drawing.Point(417, 8);
            this.txtTHU_TU.Name = "txtTHU_TU";
            this.txtTHU_TU.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTHU_TU.Properties.DisplayFormat.FormatString = "n0";
            this.txtTHU_TU.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTHU_TU.Properties.EditFormat.FormatString = "n0";
            this.txtTHU_TU.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTHU_TU.Properties.Mask.EditMask = "n0";
            this.tablePanel1.SetRow(this.txtTHU_TU, 0);
            this.txtTHU_TU.Size = new System.Drawing.Size(169, 20);
            this.txtTHU_TU.TabIndex = 10;
            // 
            // txtDefectName_C
            // 
            this.tablePanel1.SetColumn(this.txtDefectName_C, 1);
            this.tablePanel1.SetColumnSpan(this.txtDefectName_C, 3);
            this.txtDefectName_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDefectName_C.Location = new System.Drawing.Point(125, 77);
            this.txtDefectName_C.Name = "txtDefectName_C";
            this.tablePanel1.SetRow(this.txtDefectName_C, 3);
            this.txtDefectName_C.Size = new System.Drawing.Size(461, 20);
            this.txtDefectName_C.TabIndex = 9;
            // 
            // txtDefectName_E
            // 
            this.tablePanel1.SetColumn(this.txtDefectName_E, 1);
            this.tablePanel1.SetColumnSpan(this.txtDefectName_E, 3);
            this.txtDefectName_E.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDefectName_E.Location = new System.Drawing.Point(125, 54);
            this.txtDefectName_E.Name = "txtDefectName_E";
            this.tablePanel1.SetRow(this.txtDefectName_E, 2);
            this.txtDefectName_E.Size = new System.Drawing.Size(461, 20);
            this.txtDefectName_E.TabIndex = 8;
            // 
            // txtDefectName
            // 
            this.tablePanel1.SetColumn(this.txtDefectName, 1);
            this.tablePanel1.SetColumnSpan(this.txtDefectName, 3);
            this.txtDefectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDefectName.Location = new System.Drawing.Point(125, 31);
            this.txtDefectName.Name = "txtDefectName";
            this.tablePanel1.SetRow(this.txtDefectName, 1);
            this.txtDefectName.Size = new System.Drawing.Size(461, 20);
            this.txtDefectName.TabIndex = 7;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtDefectName, conditionValidationRule2);
            // 
            // lblNote
            // 
            this.tablePanel1.SetColumn(this.lblNote, 0);
            this.lblNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNote.Location = new System.Drawing.Point(8, 100);
            this.lblNote.Name = "lblNote";
            this.tablePanel1.SetRow(this.lblNote, 4);
            this.lblNote.Size = new System.Drawing.Size(111, 17);
            this.lblNote.TabIndex = 5;
            this.lblNote.Text = "lblNote";
            // 
            // lblDefectName_C
            // 
            this.tablePanel1.SetColumn(this.lblDefectName_C, 0);
            this.lblDefectName_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectName_C.Location = new System.Drawing.Point(8, 77);
            this.lblDefectName_C.Name = "lblDefectName_C";
            this.tablePanel1.SetRow(this.lblDefectName_C, 3);
            this.lblDefectName_C.Size = new System.Drawing.Size(111, 17);
            this.lblDefectName_C.TabIndex = 4;
            this.lblDefectName_C.Text = "lblDefectName_C";
            // 
            // lblDefectName_E
            // 
            this.tablePanel1.SetColumn(this.lblDefectName_E, 0);
            this.lblDefectName_E.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectName_E.Location = new System.Drawing.Point(8, 54);
            this.lblDefectName_E.Name = "lblDefectName_E";
            this.tablePanel1.SetRow(this.lblDefectName_E, 2);
            this.lblDefectName_E.Size = new System.Drawing.Size(111, 17);
            this.lblDefectName_E.TabIndex = 3;
            this.lblDefectName_E.Text = "lblDefectName_E";
            // 
            // lblDefectName
            // 
            this.tablePanel1.SetColumn(this.lblDefectName, 0);
            this.lblDefectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectName.Location = new System.Drawing.Point(8, 31);
            this.lblDefectName.Name = "lblDefectName";
            this.tablePanel1.SetRow(this.lblDefectName, 1);
            this.lblDefectName.Size = new System.Drawing.Size(111, 17);
            this.lblDefectName.TabIndex = 2;
            this.lblDefectName.Text = "lblDefectName";
            // 
            // lblTHU_TU
            // 
            this.tablePanel1.SetColumn(this.lblTHU_TU, 2);
            this.lblTHU_TU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTHU_TU.Location = new System.Drawing.Point(300, 8);
            this.lblTHU_TU.Name = "lblTHU_TU";
            this.tablePanel1.SetRow(this.lblTHU_TU, 0);
            this.lblTHU_TU.Size = new System.Drawing.Size(111, 17);
            this.lblTHU_TU.TabIndex = 1;
            this.lblTHU_TU.Text = "lblTHU_TU";
            // 
            // lblID_DG
            // 
            this.tablePanel1.SetColumn(this.lblID_DG, 0);
            this.lblID_DG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblID_DG.Location = new System.Drawing.Point(8, 8);
            this.lblID_DG.Name = "lblID_DG";
            this.tablePanel1.SetRow(this.lblID_DG, 0);
            this.lblID_DG.Size = new System.Drawing.Size(111, 17);
            this.lblID_DG.TabIndex = 0;
            this.lblID_DG.Text = "lblID_DG";
            // 
            // frmEditLoaiLoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 368);
            this.Controls.Add(this.tablePanel1);
            this.IconOptions.Image = global::VS.OEE.Properties.Resources.OEE;
            this.Name = "frmEditLoaiLoi";
            this.Text = "frmEditLoaiLoi";
            this.Load += new System.EventHandler(this.frmEditLoaiLoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_DG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHU_TU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectName_C.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectName_E.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.SpinEdit txtTHU_TU;
        private DevExpress.XtraEditors.TextEdit txtDefectName_C;
        private DevExpress.XtraEditors.TextEdit txtDefectName_E;
        private DevExpress.XtraEditors.TextEdit txtDefectName;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraEditors.LabelControl lblDefectName_C;
        private DevExpress.XtraEditors.LabelControl lblDefectName_E;
        private DevExpress.XtraEditors.LabelControl lblDefectName;
        private DevExpress.XtraEditors.LabelControl lblTHU_TU;
        private DevExpress.XtraEditors.LabelControl lblID_DG;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.SearchLookUpEdit cboID_DG;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}