using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Commons;
using System.Web.UI.WebControls;
using System.Drawing;
using DevExpress.XtraEditors;

namespace VS.OEE
{
    public partial class frmHistoryThoiGianNgungMay_KTTD : DevExpress.XtraEditors.XtraForm
    {
        public Int64 ID = 0;
        public frmHistoryThoiGianNgungMay_KTTD()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        #region Event
        private void frmHistoryThoiGianNgungMay_KTTD_Load(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.sId = "0Load";
                Loaddatacombo();
                datTNgay.DateTime = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
                datDNgay.DateTime = DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Date.Day);
                Commons.Modules.ObjSystems.MLoadLookUpEditNoRemove(cboUser, Commons.Modules.ObjSystems.DataUser(true), "USERNAME", "FULL_NAME", this.Name);
                VisibleControl(false);
                Commons.Modules.sId = "";
                LoadgrdThoiGianNgungMay();
            }
            catch(Exception ex)
            {
                Commons.Modules.sId = "";
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void rdoDK_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoDK.SelectedIndex == 0)
                {
                    VisibleControl(false);
                }
                else
                {
                    VisibleControl(true);
                }
                LoadgrdThoiGianNgungMay();
            }
            catch { }
        }
        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            LoadgrdThoiGianNgungMay();
        }
        private void grvHistoryRun_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (Convert.ToInt32(grvHistoryTGDM.GetRowCellValue(e.RowHandle, "ID_HANH_DONG")) == 2)
                {
                    e.Appearance.BackColor = Color.FromArgb(204, 236, 255);
                    e.Appearance.ForeColor = Color.Black;
                }
                if (Convert.ToInt32(grvHistoryTGDM.GetRowCellValue(e.RowHandle, "ID_HANH_DONG")) == 3)
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 204, 255);
                    e.Appearance.ForeColor = Color.Black;
                }
            }
            catch
            {
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboMS_MAY_EditValueChanged(object sender, EventArgs e)
        {
            LoadgrdThoiGianNgungMay();
        }
        private void cboID_CA_EditValueChanged(object sender, EventArgs e)
        {
            LoadgrdThoiGianNgungMay();

        }
        private void datDNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadgrdThoiGianNgungMay();
        }
        #endregion

        #region Function
        private void LoadgrdThoiGianNgungMay()
        {
            if (Commons.Modules.sId == "0Load") return;
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetHistoryThoiGianNgungMay_KTTD", rdoDK.SelectedIndex, ID, datTNgay.DateTime, datDNgay.DateTime, cboMS_MAY.EditValue, cboID_CA.EditValue, cboUser.EditValue, Commons.Modules.TypeLanguage));
                if (grdHistoryTGDM.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdHistoryTGDM, grvHistoryTGDM, dtmp, false, false, false, true, true, this.Name);
                    Commons.Modules.ObjSystems.AddCombDateTimeEdit("DateEdit", grvHistoryTGDM);
                    grvHistoryTGDM.Columns["ID_HANH_DONG"].Visible = false;
                    grvHistoryTGDM.Columns["ID"].Visible = false;
                    grvHistoryTGDM.Columns["NGUYEN_NHAN_CU_THE"].Visible = false;

                    grvHistoryTGDM.Columns["DateEdit"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvHistoryTGDM.Columns["DateEdit"].DisplayFormat.FormatString = "G";
                    grvHistoryTGDM.Columns["TU_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvHistoryTGDM.Columns["TU_GIO"].DisplayFormat.FormatString = "G";
                    grvHistoryTGDM.Columns["DEN_GIO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; ;
                    grvHistoryTGDM.Columns["DEN_GIO"].DisplayFormat.FormatString = "G";

                    grvHistoryTGDM.Columns["THOI_GIAN_SUA_CHUA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    grvHistoryTGDM.Columns["THOI_GIAN_SUA_CHUA"].DisplayFormat.FormatString = Commons.Modules.sSoLeTT;
                    grvHistoryTGDM.Columns["THOI_GIAN_SUA"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; ;
                    grvHistoryTGDM.Columns["THOI_GIAN_SUA"].DisplayFormat.FormatString = Commons.Modules.sSoLeTT;
                }
                else
                    grdHistoryTGDM.DataSource = dtmp;
            }
            catch
            {
                grdHistoryTGDM.DataSource = null;
            }
        }
        private void VisibleControl(bool Visible)
        {
            try
            {
                lblUser.Visible = Visible;
                lblTuNgay.Visible = Visible;
                lblDenNgay.Visible = Visible;
                lblMS_MAY.Visible = Visible;
                lblID_CA.Visible = Visible;
                cboUser.Visible = Visible;
                datTNgay.Visible = Visible;
                datDNgay.Visible = Visible;
                cboMS_MAY.Visible = Visible;
                cboID_CA.Visible = Visible;
                tableChung.Rows[2].Visible = Visible;
                tableChung.Rows[3].Visible = Visible;
            }
            catch { }
        }
        private void Loaddatacombo()
        {
            try
            {
                //load combo may
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMS_MAY, Commons.Modules.ObjSystems.DataMay(true), "MS_MAY", "TEN_MAY", this.Name);
                //load combo ca
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboID_CA, Commons.Modules.ObjSystems.DataCa(true), "STT", "CA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "Ca"), false);
            }
            catch { }
        }
        #endregion
    }
}