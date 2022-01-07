using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Commons;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using System.Drawing;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VS.OEE
{
    public partial class frmThoiGianNgungMay_KTTD : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        Int64 iThem = 0;
        public frmThoiGianNgungMay_KTTD(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
        }
        #region Event
        private void frmThoiGianNgungMay_KTTD_Load(object sender, EventArgs e)
        {
            try
            {
                if (iPQ != 1)
                {
                    this.btnThem.Visible = false;
                    this.btnSua.Visible = false;
                    this.btnXoa.Visible = false;
                    this.btnGhi.Visible = false;
                    this.btnKhong.Visible = false;
                }
                else
                {
                    VisibleButon(true);
                }
                
                ReadonlyControl(true);
                Commons.Modules.sId = "0Load";
                Loaddatacombo();
                Loadngay();
                LoadgrdTHOI_GIAN_DUNG_MAY(-1);
                LoadgrdTHOI_GIAN_DUNG_MAY2();
                chkTiepTuc.ToolTip = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "tolTiepTuc");
                Commons.Modules.sId = "";
                Commons.Modules.ObjSystems.DoiNNTooltip(contextMenuStrip1,this);
                Commons.Modules.ObjSystems.ThayDoiNN(this);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                iThem = -1;
                ResetControl();
                cboMS_MAY.Focus();
                ReadonlyControl(false);
                VisibleButon(false);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID") == null)
                {
                    Modules.msgThayThe(ThongBao.msgBanChuaChonDuLieu, "");
                    return;
                }
                iThem = Convert.ToInt64(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID"));
                VisibleButon(false);
                ReadonlyControl(false);
                cboMS_MAY.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvTHOI_GIAN_DUNG_MAY2.RowCount == 0) return;
                Int64 iId = -1;
                try { iId = Modules.ToInt64(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID").ToString()); } catch { }
                if (iId == -1)
                {
                    Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, groTHOI_GIAN_DUNG_MAY2.Text);
                    return;
                }
                DeleteData_THOI_GIAN_DUNG_MAY2();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                Validate();

                if (KiemTra_TiepTuc(Convert.ToInt64(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID"))))
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgNgungMayTiepTucKhongTheSua"));
                    return;
                }
               
                SaveData();
                VisibleButon(true);
                ReadonlyControl(true);
                grvTHOI_GIAN_DUNG_MAY2.OptionsBehavior.Editable = false;
                LoadgrdTHOI_GIAN_DUNG_MAY(-1);
                LoadgrdTHOI_GIAN_DUNG_MAY2();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            try
            {
                VisibleButon(true);
                ReadonlyControl(true);
                iThem = Convert.ToInt64(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID"));
                grvTHOI_GIAN_DUNG_MAY2.OptionsBehavior.Editable = false;
                LoadgrdTHOI_GIAN_DUNG_MAY(iThem);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mnuHistory_Click(object sender, EventArgs e)
        {
            try
            {
                frmHistoryThoiGianNgungMay_KTTD frm = new frmHistoryThoiGianNgungMay_KTTD();
                frm.ID = Convert.ToInt64(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID"));
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void datTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Commons.Modules.sId == "0Load") return;
                LoadgrdTHOI_GIAN_DUNG_MAY(-1);
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }
        private void datTU_GIO_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Tinh_THOI_GIAN_SUA();
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }
        private void datDEN_GIO_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Tinh_THOI_GIAN_SUA();
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }
        private void cboID_CA_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Commons.Modules.sId == "0Load") return;
                LoadgrdTHOI_GIAN_DUNG_MAY(-1);
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }
        private void cboID_DownTime_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCboMS_NGUYEN_NHAN();
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }
        private void grvTHOI_GIAN_DUNG_MAY_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (Commons.Modules.sId == "0Load") return;
                LoadgrdTHOI_GIAN_DUNG_MAY2();
                grvTHOI_GIAN_DUNG_MAY2_FocusedRowChanged(null, null);
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }
        private void grdTHOI_GIAN_DUNG_MAY2_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Delete)
                {
                    if (btnGhi.Visible == false)
                        DeleteData_THOI_GIAN_DUNG_MAY2();
                    else
                    {
                        grvTHOI_GIAN_DUNG_MAY2.DeleteSelectedRows();
                        ((DataTable)grdTHOI_GIAN_DUNG_MAY2.DataSource).AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void grvTHOI_GIAN_DUNG_MAY2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                Commons.Modules.sId = "0Load";
                BingDingData();
                Commons.Modules.sId = "";

                if (KiemTra_TiepTuc(Convert.ToInt64(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID"))))
                    btnSua.Enabled = false;
                else
                    btnSua.Enabled = true;
            }
            catch (Exception ex) { Commons.Modules.sId = ""; XtraMessageBox.Show(ex.Message); }
        }
        private void grvTHOI_GIAN_DUNG_MAY2_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.HitInfo.InDataRow)
                {
                    contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                }
                else
                {
                    contextMenuStrip1.Hide();
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            frmChooseTGianNMay frm = new frmChooseTGianNMay(Convert.ToInt64(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID")), (string.IsNullOrEmpty(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID_CHA").ToString()) ? 0 : Convert.ToInt64(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID_CHA"))), datTU_GIO.DateTime);
            if (frm.ShowDialog() != DialogResult.OK) return;

            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "	UPDATE dbo.THOI_GIAN_DUNG_MAY SET ID_CHA = CASE " + frm.iID + " WHEN 0 THEN NULL ELSE " + frm.iID + " END WHERE ID = " + grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID"));
            LoadgrdTHOI_GIAN_DUNG_MAY2();

        }
        private void mnuTiepTuc_Click(object sender, EventArgs e)
        {
            frmThoiGianNgungMay_KTTD_View frm = new frmThoiGianNgungMay_KTTD_View(Convert.ToInt64(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID")));
            frm.ShowDialog();
        }
        #endregion

        #region Function
        private void Loadngay()
        {
            try
            {
                datTuNgay.DateTime = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
                datDenNgay.DateTime = DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Date.Day);
            }
            catch { }
        }
        private void Loaddatacombo()
        {
            try
            {
                //load combo may
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMS_MAY, Commons.Modules.ObjSystems.DataMay(false), "MS_MAY", "TEN_MAY", this.Name);
                //load combo ca
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboCaID, Commons.Modules.ObjSystems.DataCa(false), "STT", "CA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "Ca"), false);
                //Load combo ID_Operator
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboID_Operator, Commons.Modules.ObjSystems.DataOpetator(false), "ID", "OperatorName", this.Name);
                //load combo Loai nguyen nhan dung may
                string str = "SELECT ID_DownTime, CASE " + Commons.Modules.TypeLanguage + " WHEN 1 THEN ISNULL(NULLIF(DownTimeTypeNameA, ''), DownTimeTypeName) ELSE ISNULL(NULLIF(DownTimeTypeNameH, ''), DownTimeTypeName) END AS DownTimeTypeName FROM dbo.DownTimeType ORDER BY SORT, DownTimeTypeName";
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, str));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboID_DownTime, dt, "ID_DownTime", "DownTimeTypeName", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "ID_DownTime"), false);
            }
            catch { }
        }
        private void LoadCboMS_NGUYEN_NHAN()
        {
            try
            {
                //load combo Nguyen nhan dung may
                string str1 = "SELECT MS_NGUYEN_NHAN, TEN_NGUYEN_NHAN FROM dbo.NGUYEN_NHAN_DUNG_MAY WHERE DownTimeTypeID = " + cboID_DownTime.EditValue + " ORDER BY MAC_DINH DESC, SORT";
                DataTable dt1 = new DataTable();
                dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, str1));
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMS_NGUYEN_NHAN, dt1, "MS_NGUYEN_NHAN", "TEN_NGUYEN_NHAN", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "MS_NGUYEN_NHAN"), false);
            }
            catch { }
        }
        private void VisibleButon(bool flag)
        {
            try
            {
                btnThem.Visible = flag;
                btnThoat.Visible = flag;
                btnXoa.Visible = flag;
                btnSua.Visible = flag;
                btnChon.Visible = flag;
                btnGhi.Visible = !flag;
                btnKhong.Visible = !flag;
            }
            catch { }
        }
        private void ReadonlyControl(bool flag)
        {
            try
            {
                cboMS_MAY.Properties.ReadOnly = flag;
                cboCaID.Properties.ReadOnly = true;
                cboID_Operator.Properties.ReadOnly = flag;
                cboID_DownTime.Properties.ReadOnly = flag;
                cboMS_NGUYEN_NHAN.Properties.ReadOnly = flag;
                txtNGUYEN_NHAN.Properties.ReadOnly = flag;
                txtHIEN_TUONG.Properties.ReadOnly = flag;
                txtTHOI_GIAN_SUA.Properties.ReadOnly = true;
                txtTHOI_GIAN_SUA_CHUA.Properties.ReadOnly = flag;
                datTU_GIO.Properties.ReadOnly = flag;
                datDEN_GIO.Properties.ReadOnly = flag;
                datTuNgay.Properties.ReadOnly = !flag;
                datDenNgay.Properties.ReadOnly = !flag;
                chkTiepTuc.ReadOnly = true;
                grdTHOI_GIAN_DUNG_MAY.Enabled = flag;
                grdTHOI_GIAN_DUNG_MAY2.Enabled = flag;

            }
            catch { }
        }
        private void LoadgrdTHOI_GIAN_DUNG_MAY(Int64 id)
        {
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListDownTimeByDate", Commons.Modules.UserName, Commons.Modules.TypeLanguage, datTuNgay.DateTime.Date, datDenNgay.DateTime.Date));
                if (grdTHOI_GIAN_DUNG_MAY.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdTHOI_GIAN_DUNG_MAY, grvTHOI_GIAN_DUNG_MAY, dtmp, false, true, false, false, true,
                        this.Name);
                }
                else
                    grdTHOI_GIAN_DUNG_MAY.DataSource = dtmp;

                if (grvTHOI_GIAN_DUNG_MAY.FocusedRowHandle < 1)
                {
                    grvTHOI_GIAN_DUNG_MAY_FocusedRowChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadgrdTHOI_GIAN_DUNG_MAY2()
        {
            // if (grvTHOI_GIAN_DUNG_MAY2.RowCount == 0) return;
            string MS_MAY = "";
            DateTime Ngay = new DateTime();
            try { MS_MAY = grvTHOI_GIAN_DUNG_MAY.GetFocusedRowCellValue("MS_MAY").ToString(); } catch { }
            try { Ngay = Convert.ToDateTime(grvTHOI_GIAN_DUNG_MAY.GetFocusedRowCellValue("NGAY")); } catch { }
            

            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListDownTime", Commons.Modules.UserName, Commons.Modules.TypeLanguage, MS_MAY, Ngay));
                if (grdTHOI_GIAN_DUNG_MAY2.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdTHOI_GIAN_DUNG_MAY2, grvTHOI_GIAN_DUNG_MAY2, dtmp, false, false, false, true,
                        this.Name);

                    grvTHOI_GIAN_DUNG_MAY2.Columns["ID"].Visible = false;
                    grvTHOI_GIAN_DUNG_MAY2.Columns["ID_DownTime"].Visible = false;
                    grvTHOI_GIAN_DUNG_MAY2.Columns["ID_Operator"].Visible = false;
                    grvTHOI_GIAN_DUNG_MAY2.Columns["MS_NGUYEN_NHAN"].Visible = false;
                    grvTHOI_GIAN_DUNG_MAY2.Columns["NGUYEN_NHAN_CU_THE"].Visible = false;
                    grvTHOI_GIAN_DUNG_MAY2.Columns["CaID"].Visible = false;
                    grvTHOI_GIAN_DUNG_MAY2.Columns["ID_CHA"].Visible = false;
                    grvTHOI_GIAN_DUNG_MAY2.Columns["ProductionRunDetailsID"].Visible = false;

                    grvTHOI_GIAN_DUNG_MAY2.Columns["TU_GIO"].DisplayFormat.FormatType = FormatType.DateTime;
                    grvTHOI_GIAN_DUNG_MAY2.Columns["TU_GIO"].DisplayFormat.FormatString = "G";
                    grvTHOI_GIAN_DUNG_MAY2.Columns["DEN_GIO"].DisplayFormat.FormatType = FormatType.DateTime;
                    grvTHOI_GIAN_DUNG_MAY2.Columns["DEN_GIO"].DisplayFormat.FormatString = "G";

                    grvTHOI_GIAN_DUNG_MAY2.Columns["THOI_GIAN_SUA_CHUA"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTHOI_GIAN_DUNG_MAY2.Columns["THOI_GIAN_SUA_CHUA"].DisplayFormat.FormatString = Commons.Modules.sSoLeTT;
                    grvTHOI_GIAN_DUNG_MAY2.Columns["THOI_GIAN_SUA"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvTHOI_GIAN_DUNG_MAY2.Columns["THOI_GIAN_SUA"].DisplayFormat.FormatString = Commons.Modules.sSoLeTT;

                }
                else
                    grdTHOI_GIAN_DUNG_MAY2.DataSource = dtmp;
            }
            catch 
            {
                grdTHOI_GIAN_DUNG_MAY2.DataSource = null;
            }
        }
        private void ResetControl()
        {
            try
            {
                cboMS_MAY.EditValue = null;
                cboCaID.EditValue = null;
                cboID_DownTime.EditValue = null;
                cboMS_NGUYEN_NHAN.EditValue = null;
                cboMS_NGUYEN_NHAN.Properties.DataSource = null;
                cboID_Operator.EditValue = null;
                txtNGUYEN_NHAN.Text = "";
                txtHIEN_TUONG.Text = "";
                txtTHOI_GIAN_SUA.EditValue = 0;
                txtTHOI_GIAN_SUA_CHUA.EditValue = 0;
                datTU_GIO.EditValue = DateTime.Now;
                datDEN_GIO.EditValue = DateTime.Now;
                chkTiepTuc.Checked = false;
            }
            catch { }
        }
        private void SaveData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = BocTach_TheoCa(datTU_GIO.DateTime, datDEN_GIO.DateTime);

                string sBT = "sBTTGDM" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, dt, "");
                iThem = Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spSaveTGDM", sBT, Commons.Modules.UserName, iThem, cboMS_MAY.EditValue, datTU_GIO.EditValue, datDEN_GIO.EditValue, cboMS_NGUYEN_NHAN.EditValue, null, cboID_Operator.EditValue, txtTHOI_GIAN_SUA_CHUA.EditValue, txtTHOI_GIAN_SUA.EditValue, txtNGUYEN_NHAN.Text, null, txtHIEN_TUONG.Text, cboCaID.EditValue, null, null));
                LoadgrdTHOI_GIAN_DUNG_MAY(iThem);
            }
            catch {}
        }
        private void BingDingData()
        {
            try
            {
                cboMS_MAY.EditValue = string.IsNullOrEmpty(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("MS_MAY").ToString()) ? null : grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("MS_MAY");
                cboCaID.EditValue = string.IsNullOrEmpty(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("CaID").ToString()) ? null : grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("CaID");
                cboID_DownTime.EditValue = string.IsNullOrEmpty(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID_DownTime").ToString()) ? null : grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID_DownTime");
                cboMS_NGUYEN_NHAN.EditValue = string.IsNullOrEmpty(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("MS_NGUYEN_NHAN").ToString()) ? null : grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("MS_NGUYEN_NHAN");
                cboID_Operator.EditValue = string.IsNullOrEmpty(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID_Operator").ToString()) ? null : grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID_Operator");
                txtNGUYEN_NHAN.Text = string.IsNullOrEmpty(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("NGUYEN_NHAN").ToString()) ? null : grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("NGUYEN_NHAN").ToString();
                txtHIEN_TUONG.Text = string.IsNullOrEmpty(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("HIEN_TUONG").ToString()) ? null : grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("HIEN_TUONG").ToString();
                txtTHOI_GIAN_SUA_CHUA.EditValue = string.IsNullOrEmpty(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("THOI_GIAN_SUA_CHUA").ToString()) ? null : grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("THOI_GIAN_SUA_CHUA");
                txtTHOI_GIAN_SUA.EditValue = string.IsNullOrEmpty(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("THOI_GIAN_SUA").ToString()) ? null : grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("THOI_GIAN_SUA");
                datTU_GIO.EditValue = string.IsNullOrEmpty(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("TU_GIO").ToString()) ? null : grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("TU_GIO");
                datDEN_GIO.EditValue = string.IsNullOrEmpty(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("DEN_GIO").ToString()) ? null : grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("DEN_GIO");

                //Kiem tra co
               
                chkTiepTuc.Checked = KiemTra_TiepTuc(Convert.ToInt64(grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID")));
            }
            catch
            {
                ResetControl();
            }
        }
        private void DeleteData_THOI_GIAN_DUNG_MAY2()
        {
            try
            {
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groTHOI_GIAN_DUNG_MAY2.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "UPDATE dbo.THOI_GIAN_DUNG_MAY SET UserEdit = '" + Commons.Modules.UserName + "'	WHERE ID = " + grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID") + " DELETE dbo.THOI_GIAN_DUNG_MAY WHERE ID = " + grvTHOI_GIAN_DUNG_MAY2.GetFocusedRowCellValue("ID"));
                grvTHOI_GIAN_DUNG_MAY2.DeleteSelectedRows();
                ((DataTable)grdTHOI_GIAN_DUNG_MAY2.DataSource).AcceptChanges();
                LoadgrdTHOI_GIAN_DUNG_MAY(-1);
                LoadgrdTHOI_GIAN_DUNG_MAY2();
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }
        private void Tinh_THOI_GIAN_SUA()
        {
            try
            {
                if (Commons.Modules.sId == "0Load") return;
                TimeSpan THOI_GIAN_SUA = datDEN_GIO.DateTime - datTU_GIO.DateTime;
                txtTHOI_GIAN_SUA.EditValue = Math.Round(THOI_GIAN_SUA.TotalMinutes, 3);
            }
            catch { }
        }
        private bool KiemTra_TiepTuc(Int64 ID)
        {
            bool Tiep_Tuc = false;
            try
            {
                Tiep_Tuc = Convert.ToBoolean(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 1 FROM (SELECT 1 AS TIEP_TUC FROM dbo.THOI_GIAN_DUNG_MAY WHERE ID = " + ID + " AND ISNULL(ID_CHA, 0) <> 0 UNION SELECT 1 AS TIEP_TUC FROM dbo.THOI_GIAN_DUNG_MAY WHERE ID_CHA = " + ID + ") A"));
            }
            catch { return false; }
            return Tiep_Tuc;
        }
        public class CapNhatCa
        {
            public int ID_CA { get; set; }
            public DateTime NGAY_BD { get; set; }
            public DateTime NGAY_KT { get; set; }
        }
        private DataTable BocTach_TheoCa(DateTime TN, DateTime DN)
        {
            DateTime TNgay = TN;
            DateTime DNgay = DN;
            List<DateTime> ListNgay = new List<DateTime>();
            //lấy tất cả các ngày có trong list
            do
            {
                ListNgay.Add(TN);
                TN = TN.AddDays(1);
            } while (TN <= DN);
            //List<CapNhatCa> listResulst = new List<CapNhatCa>();
            DataTable dt_Result = new DataTable();
            for (int i = 0; i < ListNgay.Count; i++)
            {
                //lấy các ca của ngày hôm đó
                List<CapNhatCa> listCA = new List<CapNhatCa>();
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spAPIGet_CA", ListNgay[i]));
                if (dt_Result == null || dt_Result.Rows.Count == 0)
                    dt_Result = dt.Clone().Copy();
                //ngày bắc đầu nằm trong ca
                foreach (var row in dt.AsEnumerable().Where(x => x.Field<DateTime>("NGAY_BD") <= DNgay))
                {
                    //kiểm tra từ ngày có nằm trong item không
                    DataRow r = dt_Result.NewRow();

                    if (TNgay > Convert.ToDateTime(row["NGAY_BD"]) && DNgay < Convert.ToDateTime(row["NGAY_KT"]))
                    {
                        r["NGAY_KT"] = DNgay;
                        r["NGAY_BD"] = TNgay;
                        r["ID_CA"] = row["ID_CA"];
                        dt_Result.Rows.Add(r);
                        dt_Result.AcceptChanges();
                        //item.NGAY_BD = TNgay;
                    }
                    else
                    {
                        if (DNgay <= Convert.ToDateTime(row["NGAY_KT"]))
                        {
                            DataRow r1 = dt_Result.NewRow();
                            r1["NGAY_BD"] = row["NGAY_BD"];
                            r1["NGAY_KT"] = DN;
                            r1["ID_CA"] = row["ID_CA"];
                            dt_Result.Rows.Add(r1);
                            dt_Result.AcceptChanges();
                            //listResulst.Add(item);
                            break;
                        }

                        if (TNgay >= Convert.ToDateTime(row["NGAY_BD"]))
                        {
                            r["NGAY_BD"] = TNgay;
                            r["NGAY_KT"] = row["NGAY_KT"];
                            r["ID_CA"] = row["ID_CA"];
                            dt_Result.Rows.Add(r);
                            dt_Result.AcceptChanges();
                            //listResulst.Add(item);
                            TNgay = Convert.ToDateTime(row["NGAY_KT"]);
                        }
                    }
                }
            }
            return dt_Result;
        }
        #endregion
    
    }
}
