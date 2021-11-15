namespace VS.OEE
{
    partial class frmXacNhan
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
            this.txtPASSWORD = new DevExpress.XtraEditors.TextEdit();
            this.txtUSER_NAME = new DevExpress.XtraEditors.TextEdit();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblPass = new DevExpress.XtraEditors.LabelControl();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPASSWORD
            // 
            this.tablePanel1.SetColumn(this.txtPASSWORD, 1);
            this.txtPASSWORD.Location = new System.Drawing.Point(123, 37);
            this.txtPASSWORD.Name = "txtPASSWORD";
            this.txtPASSWORD.Properties.UseSystemPasswordChar = true;
            this.tablePanel1.SetRow(this.txtPASSWORD, 2);
            this.txtPASSWORD.Size = new System.Drawing.Size(165, 20);
            this.txtPASSWORD.TabIndex = 7;
            // 
            // txtUSER_NAME
            // 
            this.tablePanel1.SetColumn(this.txtUSER_NAME, 1);
            this.txtUSER_NAME.Location = new System.Drawing.Point(123, 11);
            this.txtUSER_NAME.Name = "txtUSER_NAME";
            this.tablePanel1.SetRow(this.txtUSER_NAME, 1);
            this.txtUSER_NAME.Size = new System.Drawing.Size(165, 20);
            this.txtUSER_NAME.TabIndex = 5;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhan.Location = new System.Drawing.Point(205, 2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(80, 26);
            this.btnXacNhan.TabIndex = 13;
            this.btnXacNhan.Text = "btnXacNhan";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.lblPass);
            this.tablePanel1.Controls.Add(this.txtUSER_NAME);
            this.tablePanel1.Controls.Add(this.txtPASSWORD);
            this.tablePanel1.Controls.Add(this.lblUserName);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F)});
            this.tablePanel1.Size = new System.Drawing.Size(291, 100);
            this.tablePanel1.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.tablePanel1.SetColumnSpan(this.panelControl1, 2);
            this.panelControl1.Controls.Add(this.btnXacNhan);
            this.panelControl1.Location = new System.Drawing.Point(3, 68);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 4);
            this.panelControl1.Size = new System.Drawing.Size(285, 29);
            this.panelControl1.TabIndex = 15;
            // 
            // lblPass
            // 
            this.tablePanel1.SetColumn(this.lblPass, 0);
            this.lblPass.Location = new System.Drawing.Point(3, 40);
            this.lblPass.Name = "lblPass";
            this.tablePanel1.SetRow(this.lblPass, 2);
            this.lblPass.Size = new System.Drawing.Size(35, 13);
            this.lblPass.TabIndex = 14;
            this.lblPass.Text = "lblPass";
            // 
            // lblUserName
            // 
            this.tablePanel1.SetColumn(this.lblUserName, 0);
            this.lblUserName.Location = new System.Drawing.Point(3, 14);
            this.lblUserName.Name = "lblUserName";
            this.tablePanel1.SetRow(this.lblUserName, 1);
            this.lblUserName.Size = new System.Drawing.Size(65, 13);
            this.lblUserName.TabIndex = 14;
            this.lblUserName.Text = "lblUserName";
            // 
            // frmXacNhan
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 100);
            this.Controls.Add(this.tablePanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "frmXacNhan";
            this.Text = "frmXacNhan";
            this.Load += new System.EventHandler(this.frmXacNhan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmXacNhan_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtPASSWORD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSER_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPASSWORD;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private DevExpress.XtraEditors.TextEdit txtUSER_NAME;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblPass;
        private DevExpress.XtraEditors.LabelControl lblUserName;
    }
}