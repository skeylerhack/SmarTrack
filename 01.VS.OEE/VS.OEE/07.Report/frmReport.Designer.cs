namespace VS.OEE
{
    partial class frmReport
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
            this.fluentMain = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accorMenuleft = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlSeparator1 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accorMenuleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentMain
            // 
            this.fluentMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentMain.Location = new System.Drawing.Point(40, 0);
            this.fluentMain.Margin = new System.Windows.Forms.Padding(2);
            this.fluentMain.Name = "fluentMain";
            this.fluentMain.Padding = new System.Windows.Forms.Padding(10);
            this.fluentMain.Size = new System.Drawing.Size(995, 461);
            this.fluentMain.TabIndex = 0;
            // 
            // accorMenuleft
            // 
            this.accorMenuleft.AllowItemSelection = true;
            this.accorMenuleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.accorMenuleft.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlSeparator1});
            this.accorMenuleft.Location = new System.Drawing.Point(0, 0);
            this.accorMenuleft.Margin = new System.Windows.Forms.Padding(2);
            this.accorMenuleft.Name = "accorMenuleft";
            this.accorMenuleft.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            this.accorMenuleft.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.accorMenuleft.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            this.accorMenuleft.ShowItemExpandButtons = false;
            this.accorMenuleft.Size = new System.Drawing.Size(40, 461);
            this.accorMenuleft.TabIndex = 1;
            this.accorMenuleft.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlSeparator1
            // 
            this.accordionControlSeparator1.Name = "accordionControlSeparator1";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(2);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1035, 0);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.DockingEnabled = false;
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.MaxItemId = 85;
            // 
            // frmReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 461);
            this.Controls.Add(this.fluentMain);
            this.Controls.Add(this.accorMenuleft);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IconOptions.ShowIcon = false;
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accorMenuleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentMain;
        private DevExpress.XtraBars.Navigation.AccordionControl accorMenuleft;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator1;

        
    }
}

