using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;
using Commons;

namespace VS.OEE
{
    public partial class ucDeviceCause : DevExpress.XtraEditors.XtraForm
    {
        public ucDeviceCause()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void ucDeviceCause_Load(object sender, EventArgs e)
        {
            VisibleButon(true);
            Commons.Modules.sId = "0Load";
            Commons.Modules.ObjSystems.MLoadTreeLookUpEdit(treHeThong, Commons.Modules.ObjSystems.DataHeThongTree(true), "MS_HE_THONG", "TEN_HE_THONG", "MS_CHA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_HE_THONG"));
            Commons.Modules.ObjSystems.MLoadTreeLookUpEdit(treDiaDiem, Commons.Modules.ObjSystems.DataNhaXuongTree(true), "MS_N_XUONG", "TEN_N_XUONG", "MS_CHA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "Ten_N_XUONG"));
            treDiaDiem.EditValue = "-1";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboLoaiMay, Commons.Modules.ObjSystems.DataLoaiMay(true), "MS_LOAI_MAY", "TEN_LOAI_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_LOAI_MAY"));
            LoadNhomMay();
            treDiaDiem.EditValue = "-1";
            LoadgrdMay();
            Commons.Modules.sId = "";
        }
        private void LoadNhomMay()
        {
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNhomMay, Commons.Modules.ObjSystems.DataNhomMay(true, cboLoaiMay.EditValue.ToString()), "MS_NHOM_MAY", "TEN_NHOM_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_NHOM_MAY"));
        }
        private void LoadgrdMay()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListMay", Commons.Modules.UserName, treDiaDiem.EditValue.ToString(), treHeThong.EditValue, cboLoaiMay.EditValue, cboNhomMay.EditValue, Commons.Modules.TypeLanguage));
                if (grdMay.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdMay, grvMay, dt, false, true, true, false, true, this.Name);
                }
                else
                    grdMay.DataSource = dt;
                if (grvMay.FocusedRowHandle <= 0)
                {
                    LoadgrdDeviceCause(false);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadgrdDeviceCause(bool bLoai)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListMayNguyenNhan", bLoai,grvMay.GetFocusedRowCellValue("MS_MAY"),Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                dt.Columns["TEN_NGUYEN_NHAN"].ReadOnly = true;
                dt.Columns["CauseCode"].ReadOnly = true;
                dt.Columns["DVT"].ReadOnly = false;
                if (grdDeviceCause.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdDeviceCause, grvDeviceCause, dt, false, true, true,false, true, this.Name);
                    Commons.Modules.ObjSystems.AddCombXtra("MS_DVT_GIO", "TEN_DVT_GO","DVT", grvDeviceCause, Commons.Modules.ObjSystems.DataDonViTinhGio(), false, this.Name);
                }
                else
                    grdDeviceCause.DataSource = dt;
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboNhomMay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadgrdMay();
        }
        private void cboLoaiMay_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhomMay();
            cboNhomMay_EditValueChanged(null, null);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            VisibleButon(false);
            LoadgrdDeviceCause(true);
            grvDeviceCause.OptionsBehavior.Editable = true;
            grvDeviceCause.Columns["DVT"].OptionsColumn.ReadOnly = false;
        }

        private void VisibleButon(bool flag)
        {
            btnThoat.Visible = flag;
            btnThemSua.Visible = flag;
            btnXoa.Visible = flag;
            btnGhi.Visible = !flag;
            btnKhong.Visible = !flag;
            grdMay.Enabled = flag;

            treDiaDiem.ReadOnly = !flag;
            treHeThong.ReadOnly = !flag;
            cboLoaiMay.ReadOnly = !flag;
            cboNhomMay.ReadOnly = !flag;
        }

        private void SaveData()
        {
            //láy từ lưới những định mức lớn hơn không
            DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grdDeviceCause);
            dt = dt.AsEnumerable().Where(x => x.Field<int?>("DINH_MUC") > 0).CopyToDataTable();
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "TMPDevicesCause" + Commons.Modules.UserName, dt, "");
            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spSaveDevicesCause", grvMay.GetFocusedRowCellValue("MS_MAY"), "TMPDevicesCause" + Commons.Modules.UserName);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            VisibleButon(true);
            SaveData();
            LoadgrdDeviceCause(false);
            grvDeviceCause.OptionsBehavior.Editable = false;
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            VisibleButon(true);
            LoadgrdDeviceCause(false);
            grvDeviceCause.OptionsBehavior.Editable = false;
        }

        private void grvMay_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return ;
            LoadgrdDeviceCause(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void DeleteData()
        {
            if (grvDeviceCause.RowCount == 0) return;
            if (Modules.msgHoiThayThe(ThongBao.msgXoa, grvDeviceCause.Columns[1].Caption) == DialogResult.No) return;
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE  FROM dbo.MAY_NGUYEN_NHAN WHERE MS_MAY = '" + grvMay.GetFocusedRowCellValue("MS_MAY") + "' AND MS_NGUYEN_NHAN = " + grvDeviceCause.GetFocusedRowCellValue("MS_NGUYEN_NHAN") + "");
                grvDeviceCause.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void grdDeviceCause_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteData();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}