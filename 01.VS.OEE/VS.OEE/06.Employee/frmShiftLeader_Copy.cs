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
    public partial class frmShiftLeader_Copy : DevExpress.XtraEditors.XtraForm
    {
        public DateTime TuNgay;
        public DateTime DenNgay;
        public frmShiftLeader_Copy()
        {
            InitializeComponent();
        }
   
        private void frmShiftLeader_Copy_Load(object sender, EventArgs e)
        {
            try
            {
                datTU_NGAY.DateTime = DateTime.Now.Date;
                datDEN_NGAY.DateTime = DateTime.Now.Date;
                Commons.Modules.ObjSystems.ThayDoiNN(this);
            }
            catch { }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (datTU_NGAY.DateTime > datDEN_NGAY.DateTime)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTuNgayPhaiLonHonDenNgay"));
                    return;
                }

                TuNgay = datTU_NGAY.DateTime;
                DenNgay = datDEN_NGAY.DateTime;
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