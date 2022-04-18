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
using Microsoft.ApplicationBlocks.Data;
using DevExpress.Utils;

namespace VS.OEE
{
    public partial class frmChooseQCDataDetails : DevExpress.XtraEditors.XtraForm
    {
        public string sBTChon = "frmChooseQCDataDetails" + Commons.Modules.UserName;
        public DataTable _dt;
        public int _ID_CA;
        public Int64 _CheckStep;
        public DateTime _ProductionDate;
        public frmChooseQCDataDetails(int ID_CA, Int64 CheckStep, DateTime ProductionDate, DataTable dt)
        {
            _ID_CA = ID_CA;
            _ProductionDate = ProductionDate;
            _CheckStep = CheckStep;
            _dt = dt;
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void frmChooseQCDataDetails_Load(object sender, EventArgs e)
        {
            LoadgrData();
        }
        private void LoadgrData()
        {
            try
            {
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTChon, _dt, "");
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListChooseQCDataDetails", Commons.Modules.UserName, Commons.Modules.TypeLanguage, _ID_CA, _CheckStep, _ProductionDate, sBTChon));
                //update data table những cái nào chọn ở dưới
                dt.Columns["CHON"].ReadOnly = false;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dt, false, false, true, true, true, this.Name);
                grvData.Columns["CHON"].Visible = false;
                grvData.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
                grvData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                grvData.OptionsSelection.CheckBoxSelectorField = "CHON";
                grvData.ExpandAllGroups();

                grvData.Columns["CheckQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                grvData.Columns["CheckQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLeSL;
            }
            catch { }
        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            //lấy các giá trị chọn trên lưới
            try
            {
                _dt = grdData.DataSource as DataTable;
            }
            catch 
            {
                _dt = ((DataTable)grdData.DataSource).Clone();
            }
            DialogResult = DialogResult.OK;
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvData);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvData);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}