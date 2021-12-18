namespace VS.OEE
{
    partial class frmShiftLeader_Copy
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
            this.lblTU_NGAY = new DevExpress.XtraEditors.LabelControl();
            this.panelNN = new DevExpress.XtraEditors.PanelControl();
            this.btnGhi = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.panelChung = new DevExpress.Utils.Layout.TablePanel();
            this.datDEN_NGAY = new DevExpress.XtraEditors.DateEdit();
            this.lblDEN_NGAY = new DevExpress.XtraEditors.LabelControl();
            this.datTU_NGAY = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).BeginInit();
            this.panelNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).BeginInit();
            this.panelChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datDEN_NGAY.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDEN_NGAY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTU_NGAY.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTU_NGAY.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTU_NGAY
            // 
            this.lblTU_NGAY.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTU_NGAY.Appearance.Options.UseFont = true;
            this.lblTU_NGAY.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblTU_NGAY, 0);
            this.lblTU_NGAY.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTU_NGAY.Location = new System.Drawing.Point(3, 11);
            this.lblTU_NGAY.Name = "lblTU_NGAY";
            this.panelChung.SetRow(this.lblTU_NGAY, 1);
            this.lblTU_NGAY.Size = new System.Drawing.Size(74, 19);
            this.lblTU_NGAY.TabIndex = 1;
            this.lblTU_NGAY.Text = "lblTU_NGAY";
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
            this.panelChung.Controls.Add(this.datDEN_NGAY);
            this.panelChung.Controls.Add(this.lblDEN_NGAY);
            this.panelChung.Controls.Add(this.datTU_NGAY);
            this.panelChung.Controls.Add(this.panelNN);
            this.panelChung.Controls.Add(this.lblTU_NGAY);
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
            // datDEN_NGAY
            // 
            this.panelChung.SetColumn(this.datDEN_NGAY, 1);
            this.datDEN_NGAY.EditValue = null;
            this.datDEN_NGAY.Location = new System.Drawing.Point(83, 45);
            this.datDEN_NGAY.Name = "datDEN_NGAY";
            this.datDEN_NGAY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDEN_NGAY.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDEN_NGAY.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.panelChung.SetRow(this.datDEN_NGAY, 3);
            this.datDEN_NGAY.Size = new System.Drawing.Size(168, 20);
            this.datDEN_NGAY.TabIndex = 10;
            // 
            // lblDEN_NGAY
            // 
            this.lblDEN_NGAY.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEN_NGAY.Appearance.Options.UseFont = true;
            this.lblDEN_NGAY.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.panelChung.SetColumn(this.lblDEN_NGAY, 0);
            this.lblDEN_NGAY.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDEN_NGAY.Location = new System.Drawing.Point(3, 45);
            this.lblDEN_NGAY.Name = "lblDEN_NGAY";
            this.panelChung.SetRow(this.lblDEN_NGAY, 3);
            this.lblDEN_NGAY.Size = new System.Drawing.Size(74, 19);
            this.lblDEN_NGAY.TabIndex = 9;
            this.lblDEN_NGAY.Text = "lblDEN_NGAY";
            // 
            // datTU_NGAY
            // 
            this.panelChung.SetColumn(this.datTU_NGAY, 1);
            this.datTU_NGAY.EditValue = null;
            this.datTU_NGAY.Location = new System.Drawing.Point(83, 11);
            this.datTU_NGAY.Name = "datTU_NGAY";
            this.datTU_NGAY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTU_NGAY.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTU_NGAY.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.panelChung.SetRow(this.datTU_NGAY, 1);
            this.datTU_NGAY.Size = new System.Drawing.Size(168, 20);
            this.datTU_NGAY.TabIndex = 8;
            // 
            // frmShiftLeader_Copy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 118);
            this.Controls.Add(this.panelChung);
            this.Name = "frmShiftLeader_Copy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShiftLeader_Copy";
            this.Load += new System.EventHandler(this.frmShiftLeader_Copy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelNN)).EndInit();
            this.panelNN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelChung)).EndInit();
            this.panelChung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datDEN_NGAY.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDEN_NGAY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTU_NGAY.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTU_NGAY.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTU_NGAY;
        private DevExpress.Utils.Layout.TablePanel panelChung;
        private DevExpress.XtraEditors.PanelControl panelNN;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnGhi;
        private DevExpress.XtraEditors.DateEdit datTU_NGAY;
        private DevExpress.XtraEditors.DateEdit datDEN_NGAY;
        private DevExpress.XtraEditors.LabelControl lblDEN_NGAY;
    }
}