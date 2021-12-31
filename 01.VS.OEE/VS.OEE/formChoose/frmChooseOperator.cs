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

namespace VS.OEE
{
    public partial class frmChooseOperator : DevExpress.XtraEditors.XtraForm
    {
        public string sBTChon = "TMPOperatorChoose" + Commons.Modules.UserName;
        public DataTable dt_Operator;
        public frmChooseOperator()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void frmChooseOperator_Load(object sender, EventArgs e)
        {
            LoadgrData();
        }
        private void LoadgrData()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListChooseOperator", Commons.Modules.UserName, Commons.Modules.TypeLanguage,  sBTChon));
            //update data table những cái nào chọn ở dưới
            dt.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvData, dt,false, false, true, true, true, this.Name);
            grvData.Columns["CHON"].Visible = false;
            grvData.Columns["ID_TO"].Visible = false;
            grvData.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            grvData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            grvData.OptionsSelection.CheckBoxSelectorField = "CHON";
            grvData.ExpandAllGroups();
        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            //lấy các giá trị chọn trên lưới
            try
            {
                dt_Operator = Commons.Modules.ObjSystems.ConvertDatatable(grdData).AsEnumerable().Where(x => x.Field<bool>("CHON") == true).CopyToDataTable();
            }
            catch 
            {
                dt_Operator = ((DataTable)grdData.DataSource).Clone();
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