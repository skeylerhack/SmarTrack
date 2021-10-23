using System.Windows.Forms;

namespace VS.OEE
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
            //ucBaoCaoTongHopHieuXuat a = new ucBaoCaoTongHopHieuXuat();
            //ucBaocaoPareto a = new ucBaocaoPareto();
            ucBaocaoDoThiOEE a = new ucBaocaoDoThiOEE();
            this.Controls.Add(a);
            a.Dock = DockStyle.Fill;
        }
        private void windowsUIButtonPanel1_Click(object sender, System.EventArgs e)
        {
        }
    }
}