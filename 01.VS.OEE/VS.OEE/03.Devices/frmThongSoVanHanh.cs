using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;
using Commons;
using System.Data.SqlClient;

namespace VS.OEE
{
    public partial class frmThongSoVanHanh : DevExpress.XtraEditors.XtraForm
    {
        private static int iPQ = 1;
        public frmThongSoVanHanh(int iPQCN)
        {
            iPQ = iPQCN;
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void frmThongSoVanHanh_Load(object sender, EventArgs e)
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

            if (iPQ != 1)
            {
                btnThemSua.Visible = false;
                btnGhi.Visible = false;
                btnKhong.Visible = false;
            }
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
                var comd = new SqlCommand();
                comd.CommandType = CommandType.StoredProcedure;
                comd.CommandText = "spMayThongSoVanHanh";
                comd.Parameters.Add(new SqlParameter("@Loai", "Grd"));
                comd.Parameters.Add(new SqlParameter("@UserName", Commons.Modules.UserName));
                comd.Parameters.Add(new SqlParameter("@MsNXuong", treDiaDiem.EditValue.ToString()));
                comd.Parameters.Add(new SqlParameter("@NHeThong", treHeThong.EditValue));
                comd.Parameters.Add(new SqlParameter("@MsLoaiMay", cboLoaiMay.EditValue));
                comd.Parameters.Add(new SqlParameter("@MsNhomMay", cboNhomMay.EditValue));
                comd.Parameters.Add(new SqlParameter("@NNGU", Commons.Modules.TypeLanguage));
                dt = IConnections.MGetDataTable(comd);
                if (grdMayThongSo.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdMayThongSo, grvMayThongSo, dt, false, true, true, false, true, this.Name);
                    grvMayThongSo.Columns["IsUpdate"].Visible = false;
                }
                else
                    grdMayThongSo.DataSource = dt;
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
        }
        private void VisibleButon(bool flag)
        {
            btnThoat.Visible = flag;
            btnThemSua.Visible = flag;
            btnGhi.Visible = !flag;
            btnKhong.Visible = !flag;

            treDiaDiem.ReadOnly = !flag;
            treHeThong.ReadOnly = !flag;
            cboLoaiMay.ReadOnly = !flag;
            cboNhomMay.ReadOnly = !flag;
            grvMayThongSo.OptionsBehavior.Editable = !flag;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "BTTSVH" + Commons.Modules.UserName, Commons.Modules.ObjSystems.ConvertDatatable(grdMayThongSo), "");
                var comd = new SqlCommand();
                comd.CommandType = CommandType.StoredProcedure;
                comd.CommandText = "spMayThongSoVanHanh";
                comd.Parameters.Add(new SqlParameter("@Loai", "Save"));
                comd.Parameters.Add(new SqlParameter("@sBT", "BTTSVH" + Commons.Modules.UserName));
                IConnections.MExecuteNonQuery(comd);
                VisibleButon(true);
                LoadgrdMay();
            }
            catch
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgCapNhatThatBai);
            }
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            VisibleButon(true);
            LoadgrdMay();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvMayThongSo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //kiểm tra
                if (Convert.ToBoolean(grvMayThongSo.GetRowCellValue(e.RowHandle, grvMayThongSo.Columns["IsUpdate"])) == true) return;
                grvMayThongSo.SetRowCellValue(e.RowHandle, grvMayThongSo.Columns["IsUpdate"], true);
            }
            catch { }
        }
    }
}