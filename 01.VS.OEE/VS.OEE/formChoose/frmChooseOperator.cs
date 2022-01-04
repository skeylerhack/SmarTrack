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
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChooseOperator, grvChooseOperator, dt,false, false, false, true, true, this.Name);
            grvChooseOperator.Columns["CHON"].Visible = false;
            grvChooseOperator.Columns["ID_TO"].Visible = false;
            grvChooseOperator.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            grvChooseOperator.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            grvChooseOperator.OptionsSelection.CheckBoxSelectorField = "CHON";
            grvChooseOperator.ExpandAllGroups();
        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            //lấy các giá trị chọn trên lưới
            try
            {
                dt_Operator = Commons.Modules.ObjSystems.ConvertDatatable(grdChooseOperator).AsEnumerable().Where(x => x.Field<bool>("CHON") == true).CopyToDataTable();
            }
            catch 
            {
                dt_Operator = ((DataTable)grdChooseOperator.DataSource).Clone();
            }
            DialogResult = DialogResult.OK;
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvChooseOperator);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvChooseOperator);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}