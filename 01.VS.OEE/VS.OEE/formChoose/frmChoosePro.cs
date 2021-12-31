using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace VS.OEE
{
    public partial class frmChoosePro : DevExpress.XtraEditors.XtraForm
    {
        public string sBTChon = "TMPProMayChoose" + Commons.Modules.UserName;
        public string sBTChonLuoi = "TMPChonLuoi" + Commons.Modules.UserName;
        public DataTable TabMayPro;
        public DateTime TN, DN;
        public frmChoosePro()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void frmChooseDevice_Load(object sender, EventArgs e)
        {

            Commons.Modules.sId = "0Load";
            datTNgay.DateTime = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
            datDNgay.DateTime = DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Date.Day);
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiMay, Commons.Modules.ObjSystems.DataLoaiTB(true), "MS_LOAI_MAY", "TEN_LOAI_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_LOAI_MAY"));
            Commons.Modules.ObjSystems.MLoadTreeLookUpEdit(cboDayChuyen, Commons.Modules.ObjSystems.DataHeThongTree(true), "MS_HE_THONG", "TEN_HE_THONG", "MS_CHA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_HE_THONG"));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboCaBD, Commons.Modules.ObjSystems.DataCa(true), "STT", "CA",  Commons.Modules.ObjLanguages.GetLanguage(this.Name, "CA"));
            LoadgrData();
            Commons.Modules.sId = "";
        }
        private void LoadgrData()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListChossePro",cboCaBD.EditValue, cboDayChuyen.EditValue, cboLoaiMay.EditValue, datTNgay.DateTime.Date, datDNgay.DateTime.Date, cheXemAll.Checked , Commons.Modules.UserName, Commons.Modules.TypeLanguage, sBTChon));
            //
            //update data table những cái nào chọn ở dưới
            dt.Columns["CHON"].ReadOnly = false;
            if (grdMayPro.DataSource == null)
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdMayPro, grvMayPro, dt, true, false, true, true, true, this.Name);
                grvMayPro.Columns["CHON"].Visible = false;
                grvMayPro.Columns["PrOID"].Visible = false;
                grvMayPro.Columns["ItemID"].Visible = false;
                grvMayPro.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
                grvMayPro.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                grvMayPro.OptionsSelection.CheckBoxSelectorField = "CHON";
                grvMayPro.ExpandAllGroups();
                for (int i = 1; i < grvMayPro.Columns.Count; i++)
                {
                    grvMayPro.Columns[i].OptionsColumn.ReadOnly = false;
                }
            }
            else
            {
                grdMayPro.DataSource = dt;
            }
        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            //lấy các giá trị chọn trên lưới
            try
            {
                //insert vào những tabl
                DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grdMayPro);
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTChonLuoi, dt, "");
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spChossePro", sBTChonLuoi, sBTChon,TN,DN);
            }
            catch
            {
                //TabMayPro = Commons.Modules.ObjSystems.ConvertDatatable(grdMayPro);
                //TabMayPro.Clear();
            }
            DialogResult = DialogResult.OK;
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvMayPro);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvMayPro);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboDayChuyen_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            try
            {
                DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grdMayPro);
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTChonLuoi, dt, "");
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spChossePro", sBTChonLuoi, sBTChon);
            }
            catch
            {

            }
            LoadgrData();
        }
    }
}