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
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;  // == 1  full; <> 1 la read only
        public frmNhanVien(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            ucQuanLyNhanVien uc = new ucQuanLyNhanVien(iPQ);
            this.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
    }
}