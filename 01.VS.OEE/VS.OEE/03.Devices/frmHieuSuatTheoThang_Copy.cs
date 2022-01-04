using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;
using DevExpress.Utils;
using System.Web.UI.WebControls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace VS.OEE
{
    public partial class frmHieuSuatTheoThang_Copy : DevExpress.XtraEditors.XtraForm
    {
        public DateTime Tu;
        public DateTime Den;
        public frmHieuSuatTheoThang_Copy()
        {
            InitializeComponent();
        }
   
        private void frmHieuSuatTheoThang_Copy_Load(object sender, EventArgs e)
        {
            try
            {
                datTU.DateTime = DateTime.Now.Date.AddDays(-(DateTime.Now.Day) + 1);
                datDEN.DateTime = DateTime.Now.Date.AddDays(-(DateTime.Now.Day) + 1);
                Commons.Modules.ObjSystems.ThayDoiNN(this);
            }
            catch { }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (datTU.DateTime > datDEN.DateTime)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTuThangPhaiLonHonDenThang"));
                    return;
                }
                Tu = datTU.DateTime;
                Den = datDEN.DateTime;
                this.DialogResult = DialogResult.OK;
            }
            catch { }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}