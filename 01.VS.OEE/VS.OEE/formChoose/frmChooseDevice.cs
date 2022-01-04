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
    public partial class frmChooseDevice : DevExpress.XtraEditors.XtraForm
    {
        public string sBTChon = "TMPItemMayChoose" + Commons.Modules.UserName;
        public DataTable TabMayItem;
        public frmChooseDevice()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void frmChooseDevice_Load(object sender, EventArgs e)
        {
            LoadgrData();
        }
        private void LoadgrData()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListChosseMay", Commons.Modules.UserName, Commons.Modules.TypeLanguage,sBTChon));
            //update data table những cái nào chọn ở dưới
            dt.Columns["CHON"].ReadOnly = false;
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdChooseDevice, grvChooseDevice, dt,false, false, false, false, true, this.Name);
            grvChooseDevice.Columns["CHON"].Visible = false;
            grvChooseDevice.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            grvChooseDevice.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            grvChooseDevice.OptionsSelection.CheckBoxSelectorField = "CHON";
            grvChooseDevice.ExpandAllGroups();
        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            //lấy các giá trị chọn trên lưới
            try
            {
                TabMayItem = Commons.Modules.ObjSystems.ConvertDatatable(grdChooseDevice).AsEnumerable().Where(x => x.Field<bool>("CHON") == true).CopyToDataTable();
            }
            catch 
            {
                TabMayItem = Commons.Modules.ObjSystems.ConvertDatatable(grdChooseDevice);
                TabMayItem.Clear();
            }
            DialogResult = DialogResult.OK;
        }
        private void btnALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(true, "CHON", grvChooseDevice);
        }

        private void btnNotALL_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.MChooseGrid(false, "CHON", grvChooseDevice);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}