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
using System.Reflection;
using Commons;
using DevExpress.XtraGrid.Columns;

namespace VS.OEE
{
    public partial class frmHanhDong : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        Int64 ithem = -1;
        public frmHanhDong(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void frmHanhDong_Load(object sender, EventArgs e)
        {
            if (iPQ != 1)
            {
                this.btnThem.Visible = false;
                this.btnSua.Visible = false;
                this.btnXoa.Visible = false;
                this.btnChooseMay.Visible = false;
                this.btnGhi.Visible = false;
                this.btnKhong.Visible = false;
            }
            else
            {
                VisibleButon(true);
            }
            LoadgrdHanhDong(-1);
            LoadgrdCongNhan();
        }
        private void VisibleButon(bool flag)
        {
            btnThoat.Visible = flag;
            btnThem.Visible = flag;
            btnXoa.Visible = flag;
            btnSua.Visible = flag;
            btnGhi.Visible = !flag;
            btnKhong.Visible = !flag;
            btnChooseMay.Visible = !flag;
            ReadonlyControl(flag);
            grdHanhDong.Enabled = flag;
        }
        private void BingdingControl(bool them)
        {
            if (them == true)
            {
                txtTenHD.ResetText();
                txtTenHDA.ResetText();
                txtTenHDH.ResetText();
                txtGhiChu.ResetText();
                chkTheoCa.Checked = false;
                chkTheoLoai.Checked = false;
                txtGhiChu.ResetText();
                numBuocTH.EditValue = Convert.ToInt32(Commons.Modules.ObjSystems.ConvertDatatable(grvHanhDong).AsEnumerable().Max(x=>x["BUOC"])) +1;
            }
            else
            {
                txtTenHD.EditValue = grvHanhDong.GetFocusedRowCellValue("TEN_HANH_DONG");
                txtTenHDA.EditValue = grvHanhDong.GetFocusedRowCellValue("TEN_HANH_DONG_A");
                txtTenHDH.EditValue = grvHanhDong.GetFocusedRowCellValue("TEN_HANH_DONG_H");
                txtGhiChu.EditValue = grvHanhDong.GetFocusedRowCellValue("ItemName");
                chkTheoCa.EditValue = Convert.ToBoolean(grvHanhDong.GetFocusedRowCellValue("THEO_CA"));
                chkTheoLoai.EditValue = Convert.ToBoolean(grvHanhDong.GetFocusedRowCellValue("THEO_LOAI_NM"));
                txtGhiChu.EditValue = grvHanhDong.GetFocusedRowCellValue("GHI_CHU");
                numBuocTH.EditValue = grvHanhDong.GetFocusedRowCellValue("BUOC");
            }
        }

        private void ReadonlyControl(bool flag)
        {
            txtTenHD.Properties.ReadOnly = flag;
            txtTenHDA.Properties.ReadOnly = flag;
            txtTenHDH.Properties.ReadOnly = flag;
            txtGhiChu.Properties.ReadOnly = flag;
            chkTheoCa.Properties.ReadOnly = flag;
            chkTheoLoai.Properties.ReadOnly = flag;
            txtGhiChu.Properties.ReadOnly = flag;
            numBuocTH.Properties.ReadOnly = flag;
        }
        private void LoadgrdHanhDong(Int64 id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID_HANH_DONG,CASE "+Commons.Modules.TypeLanguage+ " WHEN 0 THEN TEN_HANH_DONG WHEN 1 THEN ISNULL(NULLIF(TEN_HANH_DONG_A,''),TEN_HANH_DONG) ELSE ISNULL(NULLIF(TEN_HANH_DONG_H,''),TEN_HANH_DONG) END AS  TEN_HANH_DONG,TEN_HANH_DONG_A, TEN_HANH_DONG_H, BUOC,ISNULL(THEO_CA,0) AS THEO_CA,ISNULL(THEO_LOAI_NM,0) AS THEO_LOAI_NM , GHI_CHU    FROM dbo.HANH_DONG ORDER BY BUOC"));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
                if (grdHanhDong.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdHanhDong, grvHanhDong, dt, false, true, false, false, true, this.Name);
                    grvHanhDong.Columns["BUOC"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvHanhDong.Columns["TEN_HANH_DONG"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                }
                else
                    grdHanhDong.DataSource = dt;
                if (id != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvHanhDong.FocusedRowHandle = grvHanhDong.GetRowHandle(index);
                }
                else {}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadgrdCongNhan()
        {
            //lấy nhân viên gửi theo hành động
            if (Commons.Modules.sPS == "0Load") return;
            DataTable dtTmp = new DataTable();
            dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "GetOperatorHanhDong",grvHanhDong.GetFocusedRowCellValue("ID_HANH_DONG"), Commons.Modules.TypeLanguage));
            for (int i = 0; i < dtTmp.Columns.Count; i++)
            {
                if (i == 0)
                    dtTmp.Columns[i].ReadOnly = false;
                else
                    dtTmp.Columns[i].ReadOnly = false;
            }
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdNhanVienGui, grvNhanVienGui, dtTmp, false, false, true, true, true, Name);
            //grvNhanVienGui. OperatorID
            grvNhanVienGui.OptionsCustomization.AllowGroup = true;
            grvNhanVienGui.ClearGrouping();
            grvNhanVienGui.BeginSort();
            try
            {
                GridColumn col1 = grvNhanVienGui.Columns["TEN_TO"];
                grvNhanVienGui.ClearGrouping();
                col1.GroupIndex = 0;
            }
            finally
            {
                grvNhanVienGui.EndSort();
            }
            grvNhanVienGui.ExpandAllGroups();
            grvNhanVienGui.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            grvNhanVienGui.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grvNhanVienGui.OptionsSelection.CheckBoxSelectorField = "CHON";
            grvNhanVienGui.ActiveFilterString = "CHON =True";
            grvNhanVienGui.Columns["CHON"].Visible = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            ithem = Convert.ToInt64(grvHanhDong.GetFocusedRowCellValue("ID_HANH_DONG"));
            grvNhanVienGui.ActiveFilter.Clear();
            grvNhanVienGui.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            grvNhanVienGui.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            VisibleButon(false);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ithem = -1;
            VisibleButon(false);
            BingdingControl(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            Validate();
            try
            {
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "sBT" + Commons.Modules.UserName, Commons.Modules.ObjSystems.ConvertDatatable(grvNhanVienGui), "");
                LoadgrdHanhDong(Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditItemMay", ithem)));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadgrdCongNhan();
            VisibleButon(true);
        }


        private void btnKhong_Click(object sender, EventArgs e)
        {
            LoadgrdCongNhan();
            VisibleButon(true);
        }

        private void grvHanhDong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BingdingControl(false);
        }
      
    }
}