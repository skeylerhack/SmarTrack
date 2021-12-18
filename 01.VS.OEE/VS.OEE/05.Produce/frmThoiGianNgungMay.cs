using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;
using DevExpress.Utils;
using System.Web.UI.WebControls;
using System.Drawing;

namespace VS.OEE
{
    public partial class frmThoiGianNgungMay : DevExpress.XtraEditors.XtraForm
    {
        private Int64 ID = -1;
        public frmThoiGianNgungMay()
        {
            InitializeComponent();
        }
        public string msMay;
        public string tenMatHang;
        public int msHT;
        public int msCa;
        public Int64 msProRunDetails;
        public DateTime datTNgay;
        public DateTime datDNgay;
        public Int64 iIDMatHang;
        public Int64 ID_Operator;
        #region Event button
        private void frmThoiGianNgungMay_Load(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            datTuNgay.DateTime = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
            datDenNgay.DateTime = DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Date.Day);
            VisibleControl(true);
            LoadData();
            cboCa.EditValue = msCa;
            cboMsMay.EditValue = msMay;
            treeHeThong.EditValue = msHT;
            LoadgrdNgungMay(-1);
            tenMatHang = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT ItemName FROM dbo.Item WHERE ID = " + iIDMatHang + "").ToString();
            BingDingData(false);
            Commons.Modules.sId = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            txtMsMay.EditValue = cboMsMay.EditValue;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            SimpleButton a = sender as SimpleButton;
            VisibleControl(false);
            ID = -1 ;
            BingDingData(true);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvNgungMay.RowCount == 0) return;
            DeleteData();
        }
        private void DeleteData()
        {
            if (Modules.msgHoiThayThe(ThongBao.msgXoa,Commons.Modules.ObjLanguages.GetLanguage(this.Name,"msgDowtinme")) == DialogResult.No) return;
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spDeleteThoiGianNgungMay",Convert.ToInt64(grvNgungMay.GetFocusedRowCellValue("ID")));
                LoadgrdNgungMay(-1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            VisibleControl(false);
            ID = Convert.ToInt64(grvNgungMay.GetFocusedRowCellValue("ID"));
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                //save data
                try
                {
                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spSaveThoiGianNgungMay", ID, msProRunDetails,cboCa.EditValue, ID_Operator, msMay, datBD.DateTime, datKT.DateTime, cboNguyenNhan.EditValue, txtSoPhutSua.EditValue, txtTongSoPhut.EditValue);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }

                VisibleControl(true);
                LoadgrdNgungMay(-1);
                BingDingData(false);
            }
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            VisibleControl(true);
            LoadgrdNgungMay(-1);
            BingDingData(false);
        }
        #endregion

        #region funtion chung
        private void LoadData()
        {
            //load data máy
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMsMay, Commons.Modules.ObjSystems.DataMay(false), "MS_MAY", "TEN_MAY", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_MAY"), false);

            //load hệ Thống
            Commons.Modules.ObjSystems.MLoadTreeLookUpEdit(treeHeThong, Commons.Modules.ObjSystems.DataHeThongTree(false), "MS_HE_THONG", "TEN_HE_THONG", "MS_CHA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_HE_THONG"));

            //Load nguyên nhân 
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboNguyenNhan, Commons.Modules.ObjSystems.DataNguyenNhan(), "MS_NGUYEN_NHAN", "TEN_NGUYEN_NHAN", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_NGUYEN_NHAN"), true);

            //Load Ca
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboCa, Commons.Modules.ObjSystems.DataCa(true), "STT", "CA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "Ca"), false);

        }

        private void LoadgrdNgungMay(Int64 ID)
        {
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spNguyenNhanNgungMayByProDetails", msProRunDetails, cboMsMay.EditValue, datTuNgay.DateTime, datDenNgay.DateTime, Commons.Modules.TypeLanguage));
                dtmp.PrimaryKey = new DataColumn[] { dtmp.Columns["ID"] };
                if (grdNgungMay.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdNgungMay, grvNgungMay, dtmp, false, false, true, true, true,
                        this.Name);
                    Commons.Modules.ObjSystems.AddCombDateTimeEdit("TU_NGAY", grvNgungMay);
                    Commons.Modules.ObjSystems.AddCombDateTimeEdit("DEN_NGAY", grvNgungMay);
                    grvNgungMay.Columns["ID"].Visible = false;

                    grvNgungMay.Columns["THOI_GIAN_SUA"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvNgungMay.Columns["THOI_GIAN_SUA"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvNgungMay.Columns["THOI_GIAN_SUA_CHUA"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvNgungMay.Columns["THOI_GIAN_SUA_CHUA"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                }
                else
                    grdNgungMay.DataSource = dtmp;
                if (ID != -1)
                {
                    int index = dtmp.Rows.IndexOf(dtmp.Rows.Find(ID));
                    grvNgungMay.FocusedRowHandle = grvNgungMay.GetRowHandle(index);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool SaveData()
        {
            try
            {
                int n = 0;
                DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grvNgungMay);
                if (datBD.Text.Trim() == "")
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblNgungMayTuGio.Text, datBD);
                    return false;
                }
                if (datKT.Text.Trim() == "")
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblDenGio.Text, datKT);
                    return false;
                }
                //kiểm tra đến ngày hợp lệ
                if (datBD.DateTime >= datKT.DateTime)
                {
                    Modules.msgThayThe(ThongBao.msgKhongHopLe, lblNgungMayTuGio.Text, datBD);
                    return false;
                }
                //kiểm tra lớn hơn 24 h
                if ((datKT.DateTime - datBD.DateTime).TotalHours >= 24)
                {
                    Modules.msgThayThe("msgThoiGiangKhongVuocQua24h", lblNgungMayTuGio.Text, datBD);
                    return false;
                }
                //kiểm tra từ ngày đến ngày năm trong một ca hiện tại
                DataTable dtCa = new DataTable();
                dtCa.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetCaTuNgayDenNgay", datBD.DateTime.Date == datTNgay.Date ? Convert.ToDateTime("1900/01/01 " + datBD.DateTime.TimeOfDay) : Convert.ToDateTime("1900/01/02 " + datBD.DateTime.TimeOfDay), datKT.DateTime.Date == datTNgay.Date ? Convert.ToDateTime("1900/01/01 " + datKT.DateTime.TimeOfDay) : Convert.ToDateTime("1900/01/02 " + datKT.DateTime.TimeOfDay), cboCa.EditValue));
                if (dtCa.Rows.Count == 0)
                {
                    Modules.msgThayThe("MsgThoiGianKhongNamTrongCa", lblNgungMayTuGio.Text, datBD);
                    return false;
                }
                //kiểm tra ngày bắc đầu nằm giữa từ ngày đến ngày
                n = dt.AsEnumerable().Where(x => (x.Field<DateTime>("TU_NGAY") < datBD.DateTime && x.Field<DateTime>("DEN_NGAY") > datBD.DateTime) && Convert.ToInt64(x["ID"]) !=ID).Count();
                if (n > 0)
                {
                    Modules.msgThayThe(ThongBao.msgDaTonTai, lblNgungMayTuGio.Text, datBD);
                    return false;
                }
                //kiểm tra ngày kết thúc nằm giữa từ ngày đến ngày
                n = dt.AsEnumerable().Where(x => (x.Field<DateTime>("TU_NGAY") < datKT.DateTime && x.Field<DateTime>("DEN_NGAY") > datKT.DateTime) && Convert.ToInt64(x["ID"]) != ID).Count();
                if (n > 0)
                {
                    Modules.msgThayThe(ThongBao.msgDaTonTai, lblNgungMayTuGio.Text, datBD);
                    return false;
                }

                //kiểm dữ liệu nằm ở 2 mé ngoài
                n = dt.AsEnumerable().Where(x => x.Field<DateTime>("TU_NGAY") > datBD.DateTime && x.Field<DateTime>("DEN_NGAY") < datKT.DateTime && Convert.ToInt64(x["ID"]) != ID).Count();
                if (n > 0)
                {
                    Modules.msgThayThe(ThongBao.msgDaTonTai, lblDenGio.Text, datKT);
                    return false;
                }
               
            
                //n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spKiemTraNgayTrung", datBD.DateTime, datKT.DateTime, msProRunDetails, ID));
                ////nếu thêm thì đếm được không sữa thì không lớn hơn 2
                //if ( n > 0)
                //{
                //    Modules.msgThayThe(ThongBao.msgDaTonTai, lblDenGio.Text, datKT);
                //    return false;
                //}
                //kiểm tra nguyên nhân không được trể trống
                if (cboNguyenNhan.Text.Trim() == "")
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblNguyenNhan.Text, cboNguyenNhan);
                    return false;
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
        private void BingDingData(bool flag)
        {
            //
            try
            {
                if (flag == true)
                {
                    //reset test
                    //nếu trong lưới hiện tại không có thì lấy từ productionrun
                    if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM THOI_GIAN_NGUNG_MAY 	WHERE ProductionRunDetailsID = " + msProRunDetails + " ")) == 0)
                    {
                        datBD.DateTime = datTNgay;
                    }
                    else
                    {
                        datBD.DateTime = Convert.ToDateTime(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, " SELECT MAX(CONVERT(DATETIME, CONVERT(NVARCHAR(20), DEN_NGAY, 23) + ' ' + CONVERT(NVARCHAR(20), DEN_GIO, 24))) FROM dbo.THOI_GIAN_NGUNG_MAY WHERE ProductionRunDetailsID =  " + msProRunDetails + "  ")).AddMinutes(1);
                    }
                    datKT.DateTime = datDNgay;
                    //nếu trong lưới có thì lấy ngày lớn nhất
                    cboNguyenNhan.EditValue = -1;
                    txtTongSoPhut.EditValue = (datDNgay - datTNgay).TotalMinutes;
                    txtSoPhutSua.EditValue = txtTongSoPhut.EditValue;
                }
                else
                {
                    //Load từ lưới lên
                    datBD.DateTime = Convert.ToDateTime(grvNgungMay.GetFocusedRowCellValue("TU_NGAY"));
                    datKT.DateTime = Convert.ToDateTime(grvNgungMay.GetFocusedRowCellValue("DEN_NGAY"));
                    txtSoPhutSua.EditValue = grvNgungMay.GetFocusedRowCellValue("THOI_GIAN_SUA_CHUA");
                    txtTongSoPhut.EditValue = grvNgungMay.GetFocusedRowCellValue("THOI_GIAN_SUA");
                    cboNguyenNhan.EditValue = grvNgungMay.GetFocusedRowCellValue("MS_NGUYEN_NHAN");

                }

            }
            catch (Exception)
            {
            }

        }
        private void VisibleControl(bool bLock)
        {
            txtSoPhutSua.Properties.ReadOnly = bLock;
            txtTongSoPhut.Properties.ReadOnly = bLock;
            datBD.Properties.ReadOnly = bLock;
            datKT.Properties.ReadOnly = bLock;
            cboNguyenNhan.ReadOnly = bLock;
            grdNgungMay.Enabled = bLock;

            this.btnThem.Visible = bLock;
            this.btnThoat.Visible = bLock;
            this.btnSua.Visible = bLock;
            this.btnXoa.Visible = bLock;
            this.btnThoat.Visible = bLock;
            this.btnGhi.Visible = !bLock;
            this.btnKhong.Visible = !bLock;

            //nếu mà không có dòng nào thì visible button

        }
        #endregion
        private void grvNgungMay_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BingDingData(false);
        }



        private void datBD_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            txtTongSoPhut.EditValue = (datKT.DateTime - datBD.DateTime).TotalMinutes;
            txtSoPhutSua.EditValue = txtTongSoPhut.EditValue;
        }

        private void grdNgungMay_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && btnGhi.Visible == false)
            {
                DeleteData();
            }
        }

        private void datTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadgrdNgungMay(-1);
        }

        private void grvNgungMay_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (Convert.ToInt32(grvNgungMay.GetRowCellValue(e.RowHandle, "Planned")) == 1)
                    e.Appearance.BackColor = Color.LightPink;
                if (Convert.ToInt64(grvNgungMay.GetRowCellValue(e.RowHandle, "Planned")) == 3)
                    e.Appearance.BackColor = Color.LightYellow;
            }
            catch
            {
            }
        }
    }
}