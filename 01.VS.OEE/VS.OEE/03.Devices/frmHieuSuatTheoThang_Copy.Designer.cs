namespace VS.OEE
{
    partial class frmHieuSuatTheoThang_Copy
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
            this.lblTU = new DevExpress.XtraEditors.LabelControl();
            this.panelNN = new DevExpress.XtraEditors.PanelControl();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.datDEN = new DevExpress.XtraEditors.DateEdit();
            this.lblDEN = new DevExpress.XtraEditors.LabelControl();
            this.datTU = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datDEN.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDEN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTU.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTU.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTU
            // 
            this.lblTU.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTU.Appearance.Options.UseFont = true;
            this.lblTU.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblTU, 0);
            this.lblTU.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTU.Location = new System.Drawing.Point(3, 11);
            this.lblTU.Name = "lblTU";
            this.panelChung.SetRow(this.lblTU, 1);
            this.lblTU.Size = new System.Drawing.Size(74, 19);
            this.lblTU.TabIndex = 1;
            this.lblTU.Text = "lblTU";
            // 
            // panelNN
            // 
            this.panelNN.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelNN.Appearance.Options.UseBackColor = true;
            this.panelNN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelChung.SetColumn(this.panelNN, 0);
            this.panelChung.SetColumnSpan(this.panelNN, 2);
            this.panelNN.Controls.Add(this.btnGhi);
            this.panelNN.Controls.Add(this.btnThoat);
            this.panelNN.Location = new System.Drawing.Point(3, 86);
            this.panelNN.Name = "panelNN";
            this.panelChung.SetRow(this.panelNN, 5);
            this.panelNN.Size = new System.Drawing.Size(248, 29);
            this.panelNN.TabIndex = 6;
            // 
            // btnGhi
            // 
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.Location = new System.Drawing.Point(85, 1);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(80, 26);
            this.btnGhi.TabIndex = 5;
            this.btnGhi.Text = "btnGhi";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(166, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 26);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "btnThoat";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panelChung
            // 
            this.panelChung.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 80F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.panelChung.Controls.Add(this.datDEN);
            this.panelChung.Controls.Add(this.lblDEN);
            this.panelChung.Controls.Add(this.datTU);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.lblTU);
            this.panelChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChung.Location = new System.Drawing.Point(0, 0);
            this.panelChung.Name = "panelChung";
            this.panelChung.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.panelChung.Size = new System.Drawing.Size(254, 118);
            this.panelChung.TabIndex = 3;
            // 
            // datDEN
            // 
            this.panelChung.SetColumn(this.datDEN, 1);
            this.datDEN.EditValue = null;
            this.datDEN.Location = new System.Drawing.Point(83, 45);
            this.datDEN.Name = "datDEN";
            this.datDEN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDEN.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDEN.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.datDEN.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datDEN.Properties.EditFormat.FormatString = "MM/yyyy";
            this.datDEN.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datDEN.Properties.Mask.EditMask = "MM/yyyy";
            this.datDEN.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.datDEN.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.datDEN.Properties.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)((DevExpress.XtraEditors.VistaCalendarViewStyle.YearView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView)));
            this.panelChung.SetRow(this.datDEN, 3);
            this.datDEN.Size = new System.Drawing.Size(168, 20);
            this.datDEN.TabIndex = 10;
            // 
            // lblDEN
            // 
            this.lblDEN.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEN.Appearance.Options.UseFont = true;
            this.lblDEN.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblDEN, 0);
            this.lblDEN.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDEN.Location = new System.Drawing.Point(3, 45);
            this.lblDEN.Name = "lblDEN";
            this.panelChung.SetRow(this.lblDEN, 3);
            this.lblDEN.Size = new System.Drawing.Size(74, 19);
            this.lblDEN.TabIndex = 9;
            this.lblDEN.Text = "lblDEN";
            // 
            // datTU
            // 
            this.panelChung.SetColumn(this.datTU, 1);
            this.datTU.EditValue = null;
            this.datTU.Location = new System.Drawing.Point(83, 11);
            this.datTU.Name = "datTU";
            this.datTU.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTU.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTU.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.datTU.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTU.Properties.EditFormat.FormatString = "MM/yyyy";
            this.datTU.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTU.Properties.Mask.EditMask = "MM/yyyy";
            this.datTU.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.datTU.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.datTU.Properties.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)((DevExpress.XtraEditors.VistaCalendarViewStyle.YearView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView)));
            this.panelChung.SetRow(this.datTU, 1);
            this.datTU.Size = new System.Drawing.Size(168, 20);
            this.datTU.TabIndex = 8;
            // 
            // frmHieuSuatTheoThang_Copy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 118);
            this.Controls.Add(this.panelChung);
            this.Name = "frmHieuSuatTheoThang_Copy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHieuSuatTheoThang_Copy";
            this.Load += new System.EventHandler(this.frmHieuSuatTheoThang_Copy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datDEN.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDEN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTU.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTU.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTU;
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.DateEdit datTU;
        private DevExpress.XtraEditors.DateEdit datDEN;
        private DevExpress.XtraEditors.LabelControl lblDEN;
    }
}