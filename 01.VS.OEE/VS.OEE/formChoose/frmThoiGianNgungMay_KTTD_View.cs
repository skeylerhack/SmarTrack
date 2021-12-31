using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace VS.OEE
{
    public partial class frmThoiGianNgungMay_KTTD_View : DevExpress.XtraEditors.XtraForm
    {
        public Int64 iID = 0;
        public frmThoiGianNgungMay_KTTD_View(Int64 ID)
        {
            iID = ID;
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        #region Event
        private void frmThoiGianNgungMay_KTTD_View_Load(object sender, EventArgs e)
        {
            LoadgrdData();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Function
        private void LoadgrdData()
        {
            try
            {
                if (Commons.Modules.sId == "0Load") return;
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListTGianNMayView", Commons.Modules.TypeLanguage, iID));
                if (grdTGianNMayView.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdTGianNMayView, grvTGianNMayView, dt, false, true, false, false, true, this.Name);
                    grvTGianNMayView.Columns["ID"].Visible = false;
                    grvTGianNMayView.Columns["TU_GIO"].DisplayFormat.FormatType = FormatType.DateTime;
                    grvTGianNMayView.Columns["TU_GIO"].DisplayFormat.FormatString = "G";
                    grvTGianNMayView.Columns["DEN_GIO"].DisplayFormat.FormatType = FormatType.DateTime;
                    grvTGianNMayView.Columns["DEN_GIO"].DisplayFormat.FormatString = "G";

                    grvTGianNMayView.Columns["THOI_GIAN_SUA_CHUA"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTGianNMayView.Columns["THOI_GIAN_SUA_CHUA"].DisplayFormat.FormatString = Commons.Modules.sSoLeTT;
                    grvTGianNMayView.Columns["THOI_GIAN_SUA"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTGianNMayView.Columns["THOI_GIAN_SUA"].DisplayFormat.FormatString = Commons.Modules.sSoLeTT;
                }
                else
                {
                    grdTGianNMayView.DataSource = dt;
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }
        #endregion

      
    }
}