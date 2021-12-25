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
                Commons.Modules.sId = "";
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
                //lưu khi thêm
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
                BingDingData();
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
                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboID_CA, Commons.Modules.ObjSystems.DataCa(true), "STT", "CA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "Ca"), false);
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
                cboCaID.Properties.ReadOnly = flag;
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
                cboID_CA.Properties.ReadOnly = !flag;
                grdTHOI_GIAN_DUNG_MAY.Enabled = flag;
            }
            catch { }
        }
        private void LoadgrdTHOI_GIAN_DUNG_MAY(Int64 id)
        {
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListDownTimeByCa", Commons.Modules.UserName, Commons.Modules.TypeLanguage, datTuNgay.DateTime.Date, datDenNgay.DateTime.Date, cboID_CA.EditValue));
                if (grdTHOI_GIAN_DUNG_MAY.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdTHOI_GIAN_DUNG_MAY, grvTHOI_GIAN_DUNG_MAY, dtmp, false, true, false, false, true,
                        this.Name);
                    grvTHOI_GIAN_DUNG_MAY.Columns["CaID"].Visible = false;
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
            Int64 ID_CA = 0;
            try { MS_MAY = grvTHOI_GIAN_DUNG_MAY.GetFocusedRowCellValue("MS_MAY").ToString(); } catch { }
            try { Ngay = Convert.ToDateTime(grvTHOI_GIAN_DUNG_MAY.GetFocusedRowCellValue("NGAY")); } catch { }
            try { ID_CA = Convert.ToInt64(grvTHOI_GIAN_DUNG_MAY.GetFocusedRowCellValue("CaID")); } catch { }

            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListDownTime", Commons.Modules.UserName, Commons.Modules.TypeLanguage, MS_MAY, Ngay, ID_CA));
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
                cboID_Operator.EditValue = null;
                txtNGUYEN_NHAN.Text = "";
                txtHIEN_TUONG.Text = "";
                txtTHOI_GIAN_SUA.EditValue = 0;
                txtTHOI_GIAN_SUA_CHUA.EditValue = 0;
                datTU_GIO.EditValue = DateTime.Now;
                datDEN_GIO.EditValue = DateTime.Now;
            }
            catch { }
        }
        private void SaveData()
        {
            try
            {
                iThem = Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spSaveTGDM", Commons.Modules.UserName, iThem, cboMS_MAY.EditValue, datTU_GIO.EditValue, datDEN_GIO.EditValue, cboMS_NGUYEN_NHAN.EditValue, null, cboID_Operator.EditValue, txtTHOI_GIAN_SUA_CHUA.EditValue, txtTHOI_GIAN_SUA.EditValue, txtNGUYEN_NHAN.Text, null, txtHIEN_TUONG.Text, cboCaID.EditValue, null, null));
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
        #endregion

   
    }
}
