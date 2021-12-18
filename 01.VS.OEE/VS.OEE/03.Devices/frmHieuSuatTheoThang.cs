using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;
using DevExpress.Utils;
using System.Web.UI.WebControls;

namespace VS.OEE
{
    public partial class frmHieuSuatTheoThang : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        public frmHieuSuatTheoThang(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
        }
        #region Event
        private void frmHieuSuatTheoThang_Load(object sender, EventArgs e)
        {
            if (iPQ != 1)
            {
                this.btnCopy.Visible = false;
                this.btnSua.Visible = false;
                this.btnXoa.Visible = false;
                this.btnGhi.Visible = false;
                this.btnKhong.Visible = false;
            }
            else
            {
                LockControl(true);
            }
            Commons.Modules.sId = "0Load";
            datThang.DateTime = DateTime.Now;
            LoadgrdTarget();
            Commons.Modules.sId = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                frmHieuSuatTheoThang_Copy frm = new frmHieuSuatTheoThang_Copy();

                if (frm.ShowDialog() != DialogResult.OK) return;
                DateTime TuThang = frm.Tu;
                DateTime DenThang = frm.Den;
                if (TuThang == null || DenThang == null) return;

                string sBT = "sBT_HieuSuatTheoThang" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, Commons.Modules.ObjSystems.ConvertDatatable(grdTarget), "");

                if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spCopyHieuSuatTheoThang", TuThang, DenThang, sBT)) == 1)
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgCopySuccessful"));
                Commons.Modules.ObjSystems.XoaTable(sBT);
            }
            catch { }
        }
        //sửa target KPI
        private void btnSua_Click(object sender, EventArgs e)
        {
            LockControl(false);
            Commons.Modules.ObjSystems.AddnewRow(grvTarget, false);
        }
        //xóa target
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvTarget.RowCount <= 1)
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, "");
                return;
            }
            DeleteData();
            LoadgrdTarget();
        }
        //thoát form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //lưu dữ liệu
        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (!SaveData())
            {
                //Commons.Modules.msgChung(Commons.ThongBao.msgCapNhatThatBai);
                return;
            }
            LockControl(true);
            Commons.Modules.ObjSystems.DeleteAddRow(grvTarget);
            LoadgrdTarget();

        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            LockControl(true);
            Commons.Modules.ObjSystems.DeleteAddRow(grvTarget);
            if (datThang.Text == "")
            {
                datThang.DateTime = DateTime.Now;
            }
            else
            {
                LoadgrdTarget();
            }
        }
        private void grvTarget_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle != grvTarget.RowCount - 1)
                return;
            e.Appearance.BackColor = Color.FromArgb(255, 204, 255);
        }
        private void datThang_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadgrdTarget();
        }
        private void grdTarget_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && btnGhi.Visible == false)
            {
                DeleteData();
                LoadgrdTarget();
            }
        }
        #endregion
        #region Function
        private void LockControl(Boolean bLock)
        {
            this.btnCopy.Visible = bLock;
            this.btnSua.Visible = bLock;
            this.btnXoa.Visible = bLock;
            this.btnThoat.Visible = bLock;
            this.btnGhi.Visible = !bLock;
            this.btnKhong.Visible = !bLock;
            txtSearch.ReadOnly = !bLock;
            datThang.Properties.ReadOnly = !bLock;
        }
        //load griddata
        private void LoadgrdTarget()
        {
            Commons.Modules.sId = "";
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListTarget", datThang.DateTime, Commons.Modules.UserName, Commons.Modules.TypeLanguage));

                for (int i = 0; i < dtmp.Columns.Count; i++)
                {
                    if (i > 1)
                    {
                        dtmp.Columns[i].ReadOnly = false;
                    }
                }
                if (grvTarget.DataSource == null)
                {
                    //OEE,PE,EL,SpeedVar
                    Modules.ObjSystems.MLoadXtraGrid(grdTarget, grvTarget, dtmp, false, false, true, true, true, this.Name);
                    grvTarget.Columns["OEE"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTarget.Columns["OEE"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;


                    grvTarget.Columns["PE"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTarget.Columns["PE"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;


                    grvTarget.Columns["EL"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTarget.Columns["EL"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;


                    grvTarget.Columns["SpeedVar"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTarget.Columns["SpeedVar"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;



                }
                else
                    grdTarget.DataSource = dtmp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteData()
        {
            if (Modules.msgHoiThayThe(ThongBao.msgXoa, groDanhSachHieuXuatKPI.Text) == DialogResult.No) return;
            try
            {
                if (!Commons.Modules.ObjSystems.IsnullorEmpty(grvTarget.GetFocusedRowCellValue("MS_MAY")))
                {
                    
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.Target WHERE CONVERT(CHAR(6), [MONTH], 112) = CONVERT(CHAR(6), '" + datThang.DateTime.ToString("yyyyMM") + "', 112) AND MS_MAY = '" + grvTarget.GetFocusedRowCellValue("MS_MAY") + "'");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool SaveData()
        {
            try
            {
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "BTtarget" + Commons.Modules.UserName, Commons.Modules.ObjSystems.ConvertDatatable(grdTarget), "");
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spSaveTarget", datThang.DateTime.AddDays(-(datThang.DateTime.Day) + 1), "BTtarget" + Commons.Modules.UserName);
                Commons.Modules.ObjSystems.XoaTable("BTtarget" + Commons.Modules.UserName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}