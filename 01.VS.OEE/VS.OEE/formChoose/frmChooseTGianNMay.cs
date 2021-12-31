using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using Microsoft.ApplicationBlocks.Data;

namespace VS.OEE
{
    public partial class frmChooseTGianNMay : DevExpress.XtraEditors.XtraForm
    {
        public Int64 iID = 0;
        public Int64 iID_CHA = 0;
        private DateTime dTuGio;
        public frmChooseTGianNMay(Int64 ID, Int64 ID_CHA, DateTime TuGio)
        {
            iID = ID;
            iID_CHA = ID_CHA;
            dTuGio = TuGio;
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        #region Event
        private void frmChooseTGianNMay_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            datTGio.DateTime = dTuGio;
            datDGio.DateTime = dTuGio.AddDays(2);
            Commons.Modules.sId = "";
            LoadgrdData();

        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)grdTGianNMay.DataSource;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((string.IsNullOrEmpty(dt.Rows[i]["CHON"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["CHON"])) == 1)
                        iID = string.IsNullOrEmpty(dt.Rows[i]["ID"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["ID"]);
                }
                DialogResult = DialogResult.OK;
            }
            catch
            {

            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void datTGio_EditValueChanged(object sender, EventArgs e)
        {
            LoadgrdData();
        }
        private void datDGio_EditValueChanged(object sender, EventArgs e)
        {
            LoadgrdData();
        }
        private void grvTGianNMay_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)grdTGianNMay.DataSource;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["CHON"] = 0;
                }
                dt.AcceptChanges();
            }
            catch { }
        }
        #endregion
        #region Function
        private void LoadgrdData()
        {
            if (Commons.Modules.sId == "0Load") return;
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListChooseTGianNMay", Commons.Modules.TypeLanguage, iID, iID_CHA, datTGio.DateTime, datDGio.DateTime));
            dt.Columns["CHON"].ReadOnly = false;
            if (grdTGianNMay.DataSource == null)
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdTGianNMay, grvTGianNMay, dt, true, true, false, false, true, this.Name);
                grvTGianNMay.Columns["ID"].Visible = false;
                for (int i = 0; i < grvTGianNMay.Columns.Count; i++)
                    grvTGianNMay.Columns[i].OptionsColumn.AllowEdit = false;
                grvTGianNMay.Columns["CHON"].OptionsColumn.AllowEdit = true;
                grvTGianNMay.Columns["TU_GIO"].DisplayFormat.FormatType = FormatType.DateTime;
                grvTGianNMay.Columns["TU_GIO"].DisplayFormat.FormatString = "G";
                grvTGianNMay.Columns["DEN_GIO"].DisplayFormat.FormatType = FormatType.DateTime;
                grvTGianNMay.Columns["DEN_GIO"].DisplayFormat.FormatString = "G";

                grvTGianNMay.Columns["THOI_GIAN_SUA_CHUA"].DisplayFormat.FormatType = FormatType.Numeric;
                grvTGianNMay.Columns["THOI_GIAN_SUA_CHUA"].DisplayFormat.FormatString = Commons.Modules.sSoLeTT;
                grvTGianNMay.Columns["THOI_GIAN_SUA"].DisplayFormat.FormatType = FormatType.Numeric;
                grvTGianNMay.Columns["THOI_GIAN_SUA"].DisplayFormat.FormatString = Commons.Modules.sSoLeTT;

            }
            else
            {
                grdTGianNMay.DataSource = dt;
            }
        }
        #endregion

    }
}