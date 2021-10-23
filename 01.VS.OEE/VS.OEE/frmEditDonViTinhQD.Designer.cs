namespace VS.OEE
{
    partial class frmEditDonViTinhQD
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.txtHE_SO_QD = new DevExpress.XtraEditors.SpinEdit();
            this.cboDVT1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboDVT = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblHE_SO_QD = new DevExpress.XtraEditors.LabelControl();
            this.lblDVT1 = new DevExpress.XtraEditors.LabelControl();
            this.lblDVT = new DevExpress.XtraEditors.LabelControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHE_SO_QD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDVT1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDVT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 75F)});
            this.tablePanel1.Controls.Add(this.txtHE_SO_QD);
            this.tablePanel1.Controls.Add(this.cboDVT1);
            this.tablePanel1.Controls.Add(this.cboDVT);
            this.tablePanel1.Controls.Add(this.lblHE_SO_QD);
            this.tablePanel1.Controls.Add(this.lblDVT1);
            this.tablePanel1.Controls.Add(this.lblDVT);
            this.tablePanel1.Controls.Add(this.flowLayoutPanel1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 43F)});
            this.tablePanel1.Size = new System.Drawing.Size(594, 368);
            this.tablePanel1.TabIndex = 0;
            // 
            // txtHE_SO_QD
            // 
            this.tablePanel1.SetColumn(this.txtHE_SO_QD, 1);
            this.txtHE_SO_QD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtHE_SO_QD.Location = new System.Drawing.Point(152, 55);
            this.txtHE_SO_QD.Name = "txtHE_SO_QD";
            this.txtHE_SO_QD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtHE_SO_QD.Properties.DisplayFormat.FormatString = "n4";
            this.txtHE_SO_QD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHE_SO_QD.Properties.EditFormat.FormatString = "n4";
            this.txtHE_SO_QD.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHE_SO_QD.Properties.Mask.EditMask = "n4";
            this.tablePanel1.SetRow(this.txtHE_SO_QD, 2);
            this.txtHE_SO_QD.Size = new System.Drawing.Size(440, 20);
            this.txtHE_SO_QD.TabIndex = 30;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtHE_SO_QD, conditionValidationRule1);
            // 
            // cboDVT1
            // 
            this.tablePanel1.SetColumn(this.cboDVT1, 1);
            this.cboDVT1.Location = new System.Drawing.Point(152, 29);
            this.cboDVT1.Name = "cboDVT1";
            this.cboDVT1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDVT1.Properties.NullText = "";
            this.cboDVT1.Properties.PopupView = this.searchLookUpEdit2View;
            this.tablePanel1.SetRow(this.cboDVT1, 1);
            this.cboDVT1.Size = new System.Drawing.Size(440, 20);
            this.cboDVT1.TabIndex = 29;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.cboDVT1, conditionValidationRule2);
            // 
            // searchLookUpEdit2View
            // 
            this.searchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // cboDVT
            // 
            this.tablePanel1.SetColumn(this.cboDVT, 1);
            this.cboDVT.Location = new System.Drawing.Point(152, 3);
            this.cboDVT.Name = "cboDVT";
            this.cboDVT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDVT.Properties.NullText = "";
            this.cboDVT.Properties.PopupView = this.searchLookUpEdit1View;
            this.tablePanel1.SetRow(this.cboDVT, 0);
            this.cboDVT.Size = new System.Drawing.Size(440, 20);
            this.cboDVT.TabIndex = 28;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.cboDVT, conditionValidationRule3);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lblHE_SO_QD
            // 
            this.tablePanel1.SetColumn(this.lblHE_SO_QD, 0);
            this.lblHE_SO_QD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHE_SO_QD.Location = new System.Drawing.Point(3, 55);
            this.lblHE_SO_QD.Name = "lblHE_SO_QD";
            this.tablePanel1.SetRow(this.lblHE_SO_QD, 2);
            this.lblHE_SO_QD.Size = new System.Drawing.Size(143, 20);
            this.lblHE_SO_QD.TabIndex = 27;
            this.lblHE_SO_QD.Text = "lblHE_SO_QD";
            // 
            // lblDVT1
            // 
            this.tablePanel1.SetColumn(this.lblDVT1, 0);
            this.lblDVT1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDVT1.Location = new System.Drawing.Point(3, 29);
            this.lblDVT1.Name = "lblDVT1";
            this.tablePanel1.SetRow(this.lblDVT1, 1);
            this.lblDVT1.Size = new System.Drawing.Size(143, 20);
            this.lblDVT1.TabIndex = 26;
            this.lblDVT1.Text = "lblDVT1";
            // 
            // lblDVT
            // 
            this.tablePanel1.SetColumn(this.lblDVT, 0);
            this.lblDVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDVT.Location = new System.Drawing.Point(3, 3);
            this.lblDVT.Name = "lblDVT";
            this.tablePanel1.SetRow(this.lblDVT, 0);
            this.lblDVT.Size = new System.Drawing.Size(143, 20);
            this.lblDVT.TabIndex = 25;
            this.lblDVT.Text = "lblDVT";
            // 
            // flowLayoutPanel1
            // 
            this.tablePanel1.SetColumn(this.flowLayoutPanel1, 0);
            this.tablePanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.btnThoat);
            this.flowLayoutPanel1.Controls.Add(this.btnGhi);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 328);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tablePanel1.SetRow(this.flowLayoutPanel1, 4);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(589, 37);
            this.flowLayoutPanel1.TabIndex = 24;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(486, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 30);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(380, 3);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(100, 30);
            this.btnGhi.TabIndex = 1;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // frmEditDonViTinhQD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 368);
            this.Controls.Add(this.tablePanel1);
            this.Name = "frmEditDonViTinhQD";
            this.Text = "frmEditDonViTinhQD";
            this.Load += new System.EventHandler(this.frmEditDonViTinhQD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHE_SO_QD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDVT1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDVT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.LabelControl lblDVT1;
        private DevExpress.XtraEditors.LabelControl lblDVT;
        private DevExpress.XtraEditors.SpinEdit txtHE_SO_QD;
        private DevExpress.XtraEditors.SearchLookUpEdit cboDVT1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit2View;
        private DevExpress.XtraEditors.SearchLookUpEdit cboDVT;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl lblHE_SO_QD;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}