namespace VS.OEE
{
    partial class frmNhapHangLoi
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.grdQCDataDetails = new DevExpress.XtraGrid.GridControl();
            this.grvQCDataDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dedQCDate = new DevExpress.XtraEditors.DateEdit();
            this.txtQCName = new DevExpress.XtraEditors.TextEdit();
            this.lblQCName = new DevExpress.XtraEditors.LabelControl();
            this.lblQCDate = new DevExpress.XtraEditors.LabelControl();
            this.lblDocNum = new DevExpress.XtraEditors.LabelControl();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.groHangLoi = new DevExpress.XtraEditors.GroupControl();
            this.grdQCData = new DevExpress.XtraGrid.GridControl();
            this.grvQCData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.txtDocNum = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQCDataDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQCDataDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dedQCDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dedQCDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQCName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groHangLoi)).BeginInit();
            this.groHangLoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQCData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQCData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocNum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F)});
            this.tablePanel1.Controls.Add(this.txtDocNum);
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.grdQCDataDetails);
            this.tablePanel1.Controls.Add(this.dedQCDate);
            this.tablePanel1.Controls.Add(this.txtQCName);
            this.tablePanel1.Controls.Add(this.lblQCName);
            this.tablePanel1.Controls.Add(this.lblQCDate);
            this.tablePanel1.Controls.Add(this.lblDocNum);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.tablePanel1.Size = new System.Drawing.Size(662, 452);
            this.tablePanel1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.tablePanel1.SetColumnSpan(this.panelControl1, 4);
            this.panelControl1.Controls.Add(this.btnXoa);
            this.panelControl1.Controls.Add(this.btnSua);
            this.panelControl1.Controls.Add(this.btnThem);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Controls.Add(this.btnKhongGhi);
            this.panelControl1.Controls.Add(this.btnGhi);
            this.panelControl1.Location = new System.Drawing.Point(3, 420);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 3);
            this.panelControl1.Size = new System.Drawing.Size(656, 29);
            this.panelControl1.TabIndex = 9;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(492, 1);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 26);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(410, 1);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 26);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(329, 1);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 26);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(573, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnKhongGhi
            // 
            this.btnKhongGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhongGhi.Location = new System.Drawing.Point(573, 0);
            this.btnKhongGhi.Name = "btnKhongGhi";
            this.btnKhongGhi.Size = new System.Drawing.Size(80, 26);
            this.btnKhongGhi.TabIndex = 3;
            this.btnKhongGhi.Text = "btnKhongGhi";
            this.btnKhongGhi.Click += new System.EventHandler(this.btnKhongGhi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(491, 0);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 4;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // grdQCDataDetails
            // 
            this.tablePanel1.SetColumn(this.grdQCDataDetails, 0);
            this.tablePanel1.SetColumnSpan(this.grdQCDataDetails, 4);
            this.grdQCDataDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdQCDataDetails.Location = new System.Drawing.Point(3, 55);
            this.grdQCDataDetails.MainView = this.grvQCDataDetails;
            this.grdQCDataDetails.Name = "grdQCDataDetails";
            this.tablePanel1.SetRow(this.grdQCDataDetails, 2);
            this.grdQCDataDetails.Size = new System.Drawing.Size(656, 359);
            this.grdQCDataDetails.TabIndex = 6;
            this.grdQCDataDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvQCDataDetails});
            this.grdQCDataDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdQCDataDetails_KeyDown);
            // 
            // grvQCDataDetails
            // 
            this.grvQCDataDetails.DetailHeight = 303;
            this.grvQCDataDetails.GridControl = this.grdQCDataDetails;
            this.grvQCDataDetails.Name = "grvQCDataDetails";
            this.grvQCDataDetails.OptionsView.ShowGroupPanel = false;
            this.grvQCDataDetails.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvQCDataDetails_InitNewRow);
            this.grvQCDataDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvQCDataDetails_CellValueChanged);
            this.grvQCDataDetails.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grvQCDataDetails_InvalidRowException_1);
            this.grvQCDataDetails.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvQCDataDetails_ValidateRow);
            this.grvQCDataDetails.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.grvQCDataDetails_InvalidValueException);
            // 
            // dedQCDate
            // 
            this.tablePanel1.SetColumn(this.dedQCDate, 3);
            this.dedQCDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dedQCDate.EditValue = null;
            this.dedQCDate.Location = new System.Drawing.Point(466, 29);
            this.dedQCDate.Name = "dedQCDate";
            this.dedQCDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dedQCDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.dedQCDate, 1);
            this.dedQCDate.Size = new System.Drawing.Size(193, 20);
            this.dedQCDate.TabIndex = 5;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.dedQCDate, conditionValidationRule3);
            // 
            // txtQCName
            // 
            this.tablePanel1.SetColumn(this.txtQCName, 3);
            this.txtQCName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQCName.Location = new System.Drawing.Point(466, 3);
            this.txtQCName.Name = "txtQCName";
            this.tablePanel1.SetRow(this.txtQCName, 0);
            this.txtQCName.Size = new System.Drawing.Size(193, 20);
            this.txtQCName.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.txtQCName, conditionValidationRule1);
            // 
            // lblQCName
            // 
            this.tablePanel1.SetColumn(this.lblQCName, 2);
            this.lblQCName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQCName.Location = new System.Drawing.Point(334, 3);
            this.lblQCName.Name = "lblQCName";
            this.tablePanel1.SetRow(this.lblQCName, 0);
            this.lblQCName.Size = new System.Drawing.Size(126, 20);
            this.lblQCName.TabIndex = 2;
            this.lblQCName.Text = "lblQCName";
            // 
            // lblQCDate
            // 
            this.tablePanel1.SetColumn(this.lblQCDate, 2);
            this.lblQCDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQCDate.Location = new System.Drawing.Point(334, 29);
            this.lblQCDate.Name = "lblQCDate";
            this.tablePanel1.SetRow(this.lblQCDate, 1);
            this.lblQCDate.Size = new System.Drawing.Size(126, 20);
            this.lblQCDate.TabIndex = 1;
            this.lblQCDate.Text = "lblQCDate";
            // 
            // lblDocNum
            // 
            this.tablePanel1.SetColumn(this.lblDocNum, 0);
            this.lblDocNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDocNum.Location = new System.Drawing.Point(3, 3);
            this.lblDocNum.Name = "lblDocNum";
            this.tablePanel1.SetRow(this.lblDocNum, 0);
            this.lblDocNum.Size = new System.Drawing.Size(126, 20);
            this.lblDocNum.TabIndex = 0;
            this.lblDocNum.Text = "lblID";
            // 
            // tablePanel2
            // 
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tablePanel2.Controls.Add(this.searchControl1);
            this.tablePanel2.Controls.Add(this.groHangLoi);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel2.Location = new System.Drawing.Point(0, 0);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F)});
            this.tablePanel2.Size = new System.Drawing.Size(267, 452);
            this.tablePanel2.TabIndex = 10;
            // 
            // searchControl1
            // 
            this.tablePanel2.SetColumn(this.searchControl1, 0);
            this.searchControl1.Location = new System.Drawing.Point(3, 426);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.tablePanel2.SetRow(this.searchControl1, 1);
            this.searchControl1.Size = new System.Drawing.Size(261, 20);
            this.searchControl1.TabIndex = 1;
            // 
            // groHangLoi
            // 
            this.tablePanel2.SetColumn(this.groHangLoi, 0);
            this.groHangLoi.Controls.Add(this.grdQCData);
            this.groHangLoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groHangLoi.Location = new System.Drawing.Point(3, 3);
            this.groHangLoi.Name = "groHangLoi";
            this.tablePanel2.SetRow(this.groHangLoi, 0);
            this.groHangLoi.Size = new System.Drawing.Size(261, 414);
            this.groHangLoi.TabIndex = 0;
            this.groHangLoi.Text = "groHangLoi";
            // 
            // grdQCData
            // 
            this.grdQCData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdQCData.Location = new System.Drawing.Point(2, 22);
            this.grdQCData.MainView = this.grvQCData;
            this.grdQCData.Name = "grdQCData";
            this.grdQCData.Size = new System.Drawing.Size(257, 390);
            this.grdQCData.TabIndex = 6;
            this.grdQCData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvQCData});
            this.grdQCData.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdQCData_ProcessGridKey);
            // 
            // grvQCData
            // 
            this.grvQCData.GridControl = this.grdQCData;
            this.grvQCData.Name = "grvQCData";
            this.grvQCData.OptionsView.ShowGroupPanel = false;
            this.grvQCData.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvQCData_FocusedRowChanged);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tablePanel2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tablePanel1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(935, 452);
            this.splitContainerControl1.SplitterPosition = 267;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // txtDocNum
            // 
            this.tablePanel1.SetColumn(this.txtDocNum, 1);
            this.txtDocNum.Location = new System.Drawing.Point(135, 3);
            this.txtDocNum.Name = "txtDocNum";
            this.tablePanel1.SetRow(this.txtDocNum, 0);
            this.txtDocNum.Size = new System.Drawing.Size(193, 20);
            this.txtDocNum.TabIndex = 10;
            // 
            // frmNhapHangLoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 452);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.Image = global::VS.OEE.Properties.Resources.OEE;
            this.Name = "frmNhapHangLoi";
            this.Text = "frmNhapHangLoi";
            this.Load += new System.EventHandler(this.frmNhapHangLoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQCDataDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQCDataDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dedQCDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dedQCDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQCName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groHangLoi)).EndInit();
            this.groHangLoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQCData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQCData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDocNum.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraGrid.GridControl grdQCDataDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQCDataDetails;
        private DevExpress.XtraEditors.DateEdit dedQCDate;
        private DevExpress.XtraEditors.TextEdit txtQCName;
        private DevExpress.XtraEditors.LabelControl lblQCName;
        private DevExpress.XtraEditors.LabelControl lblQCDate;
        private DevExpress.XtraEditors.LabelControl lblDocNum;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnKhongGhi;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private DevExpress.XtraEditors.GroupControl groHangLoi;
        private DevExpress.XtraGrid.GridControl grdQCData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQCData;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.TextEdit txtDocNum;
    }
}