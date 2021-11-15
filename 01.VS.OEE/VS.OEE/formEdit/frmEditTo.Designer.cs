namespace VS.OEE
{
    partial class frmEditTo
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.txtTEN_TO = new DevExpress.XtraEditors.TextEdit();
            this.cboMS_TO = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboMS_DON_VI = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTEN_TO = new DevExpress.XtraEditors.LabelControl();
            this.lblMS_TO = new DevExpress.XtraEditors.LabelControl();
            this.lblMS_DON_VI = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_TO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMS_TO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMS_DON_VI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
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
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.txtTEN_TO);
            this.tablePanel1.Controls.Add(this.cboMS_TO);
            this.tablePanel1.Controls.Add(this.cboMS_DON_VI);
            this.tablePanel1.Controls.Add(this.lblTEN_TO);
            this.tablePanel1.Controls.Add(this.lblMS_TO);
            this.tablePanel1.Controls.Add(this.lblMS_DON_VI);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
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
            this.panelControl1.Location = new System.Drawing.Point(8, 334);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 3);
            this.panelControl1.Size = new System.Drawing.Size(578, 26);
            this.panelControl1.TabIndex = 25;
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(416, 0);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 1;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(497, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtTEN_TO
            // 
            this.tablePanel1.SetColumn(this.txtTEN_TO, 1);
            this.tablePanel1.SetColumnSpan(this.txtTEN_TO, 3);
            this.txtTEN_TO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEN_TO.Location = new System.Drawing.Point(125, 48);
            this.txtTEN_TO.Name = "txtTEN_TO";
            this.tablePanel1.SetRow(this.txtTEN_TO, 2);
            this.txtTEN_TO.Size = new System.Drawing.Size(461, 20);
            this.txtTEN_TO.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtTEN_TO, conditionValidationRule1);
            // 
            // cboMS_TO
            // 
            this.tablePanel1.SetColumn(this.cboMS_TO, 3);
            this.cboMS_TO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMS_TO.Location = new System.Drawing.Point(417, 16);
            this.cboMS_TO.Name = "cboMS_TO";
            this.cboMS_TO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMS_TO.Properties.NullText = "";
            this.cboMS_TO.Properties.PopupView = this.searchLookUpEdit2View;
            this.tablePanel1.SetRow(this.cboMS_TO, 1);
            this.cboMS_TO.Size = new System.Drawing.Size(169, 20);
            this.cboMS_TO.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.cboMS_TO, conditionValidationRule2);
            // 
            // searchLookUpEdit2View
            // 
            this.searchLookUpEdit2View.DetailHeight = 303;
            this.searchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // cboMS_DON_VI
            // 
            this.tablePanel1.SetColumn(this.cboMS_DON_VI, 1);
            this.cboMS_DON_VI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMS_DON_VI.Location = new System.Drawing.Point(125, 16);
            this.cboMS_DON_VI.Name = "cboMS_DON_VI";
            this.cboMS_DON_VI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMS_DON_VI.Properties.NullText = "";
            this.cboMS_DON_VI.Properties.PopupView = this.searchLookUpEdit1View;
            this.tablePanel1.SetRow(this.cboMS_DON_VI, 1);
            this.cboMS_DON_VI.Size = new System.Drawing.Size(169, 20);
            this.cboMS_DON_VI.TabIndex = 3;
            this.cboMS_DON_VI.EditValueChanged += new System.EventHandler(this.cboMS_DON_VI_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.DetailHeight = 303;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lblTEN_TO
            // 
            this.tablePanel1.SetColumn(this.lblTEN_TO, 0);
            this.lblTEN_TO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTEN_TO.Location = new System.Drawing.Point(8, 48);
            this.lblTEN_TO.Name = "lblTEN_TO";
            this.tablePanel1.SetRow(this.lblTEN_TO, 2);
            this.lblTEN_TO.Size = new System.Drawing.Size(111, 280);
            this.lblTEN_TO.TabIndex = 2;
            this.lblTEN_TO.Text = "lblTEN_TO";
            // 
            // lblMS_TO
            // 
            this.tablePanel1.SetColumn(this.lblMS_TO, 2);
            this.lblMS_TO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMS_TO.Location = new System.Drawing.Point(300, 16);
            this.lblMS_TO.Name = "lblMS_TO";
            this.tablePanel1.SetRow(this.lblMS_TO, 1);
            this.lblMS_TO.Size = new System.Drawing.Size(111, 26);
            this.lblMS_TO.TabIndex = 1;
            this.lblMS_TO.Text = "lblMS_TO";
            // 
            // lblMS_DON_VI
            // 
            this.tablePanel1.SetColumn(this.lblMS_DON_VI, 0);
            this.lblMS_DON_VI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMS_DON_VI.Location = new System.Drawing.Point(8, 16);
            this.lblMS_DON_VI.Name = "lblMS_DON_VI";
            this.tablePanel1.SetRow(this.lblMS_DON_VI, 1);
            this.lblMS_DON_VI.Size = new System.Drawing.Size(111, 26);
            this.lblMS_DON_VI.TabIndex = 0;
            this.lblMS_DON_VI.Text = "lblMS_DON_VI";
            // 
            // frmEditTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 368);
            this.Controls.Add(this.tablePanel1);
            this.IconOptions.Image = global::VS.OEE.Properties.Resources.OEE;
            this.Name = "frmEditTo";
            this.Text = "frmTo";
            this.Load += new System.EventHandler(this.frmTo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN_TO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMS_TO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMS_DON_VI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.TextEdit txtTEN_TO;
        private DevExpress.XtraEditors.SearchLookUpEdit cboMS_TO;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit2View;
        private DevExpress.XtraEditors.SearchLookUpEdit cboMS_DON_VI;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl lblTEN_TO;
        private DevExpress.XtraEditors.LabelControl lblMS_TO;
        private DevExpress.XtraEditors.LabelControl lblMS_DON_VI;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}