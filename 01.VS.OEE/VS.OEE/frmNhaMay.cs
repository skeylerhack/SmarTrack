using System;
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
    public partial class frmNhaMay : DevExpress.XtraEditors.XtraForm
    {
        private static int iPQ = 1;
        public frmNhaMay(int iPQCN)
        {
            iPQ = iPQCN;
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void frmNhaMay_Load(object sender, EventArgs e)
        {
           
        }

    }
}