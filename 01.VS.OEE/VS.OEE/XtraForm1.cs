﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VS.OEE
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }
        private void XtraForm1_Load(object sender, EventArgs e)
        {
            ucBaoCaoTargetMoldID frm = new ucBaoCaoTargetMoldID();
            this.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
        }   
    }
}