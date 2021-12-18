using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Commons;
using System.Web.UI.WebControls;
using System.Drawing;

namespace VS.OEE
{
    public partial class frmHistoryProRun : DevExpress.XtraEditors.XtraForm
    {
        public Int64 ProRunDetailID = 0;
        public frmHistoryProRun()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void frmHistoryProRun_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            datTNgay.DateTime = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
            datDNgay.DateTime = DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Date.Day);
            Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboUser, Commons.Modules.ObjSystems.DataUser(true), "USERNAME", "FULL_NAME", this.Name);
            VisibleControl(false);
            Commons.Modules.sId = "";
            LoadgrdEquiment();
        }
        private void LoadgrdEquiment()
        {
            if (Commons.Modules.sId == "0Load") return;
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetHistoryProDuctionRun", rdoDK.SelectedIndex,ProRunDetailID,datTNgay.DateTime,datDNgay.DateTime,Commons.Modules.UserName,Commons.Modules.TypeLanguage));
                if (grdHistoryRun.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdHistoryRun, grvHistoryRun, dtmp, false, false,false, true, true, this.Name);
                    grvHistoryRun.Columns["ID_HANH_DONG"].Visible = false;
                    Commons.Modules.ObjSystems.AddCombDateTimeEdit("DateEdit", grvHistoryRun);
                }
                else
                    grdHistoryRun.DataSource = dtmp;
            }
            catch
            {
                grdHistoryRun.DataSource = null;
            }
        }
        private void rdoDK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoDK.SelectedIndex == 0)
            {
                VisibleControl(false);
            }
            else
            {
                VisibleControl(true);
            }
            LoadgrdEquiment();
        }
        private void VisibleControl(bool Visible)
        {
            lblUser.Visible = Visible;
            lblTuNgay.Visible = Visible;
            lblDenNgay.Visible = Visible;
            cboUser.Visible = Visible;
            datTNgay.Visible = Visible;
            datDNgay.Visible = Visible;
        }

        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            LoadgrdEquiment();
        }

        private void grvHistoryRun_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (Convert.ToInt32(grvHistoryRun.GetRowCellValue(e.RowHandle, "ID_HANH_DONG")) == 2)
                    e.Appearance.BackColor = Color.FromArgb(204, 236, 255);
                if (Convert.ToInt32(grvHistoryRun.GetRowCellValue(e.RowHandle, "ID_HANH_DONG")) == 3)
                    e.Appearance.BackColor = Color.FromArgb(255, 204, 255);
            }
            catch
            {
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}