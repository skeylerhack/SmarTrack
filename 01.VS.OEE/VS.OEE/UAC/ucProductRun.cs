﻿using System;
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
    public partial class frmProductRun : DevExpress.XtraEditors.XtraForm
    {
        Int64 iThem = 0;
        string sBT = "TMPProDucRunDetails" + Commons.Modules.UserName;
        DataTable tbProRunDetails = new DataTable();
        public frmProductRun()
        {
            InitializeComponent();
        }
        private void frmProductRun_Load(object sender, EventArgs e)
        {
            if (Modules.iPermission != 1)
            {
                this.btnThem.Visible = false;
                this.btnSua.Visible = false;
                this.btnXoa.Visible = false;
                this.btnGhi.Visible = false;
                this.btnChonLSX.Visible = false;
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
            LoadgrdProDuctRun(-1);
            BingDingData();
            LoadgrdPrRunDetails();
            LoadgrdEquiment();
            Commons.Modules.sId = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void Loadngay()
        {
            datTuNgay.DateTime = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
            datDenNgay.DateTime = DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Date.Day);
        }
        private void Loaddatacombo()
        {
            //load combo may
            //Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMay, Commons.Modules.ObjSystems.DataMay(0), "MS_MAY", "TEN_MAY",this.Name);
            //load combo ca
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboCa, Commons.Modules.ObjSystems.DataCa(false), "STT", "CA", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "Ca"), false);
            //load combo DieuHanh
            //Commons.Modules.ObjSystems.MLoadLookUpEdit(cboDieuHanh, Commons.Modules.ObjSystems.DataOpetator(false), "ID", "OperatorName", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "OperatorName"), false);
        }
        private void VisibleButon(bool flag)
        {
            btnThem.Visible = flag;
            btnThoat.Visible = flag;
            btnXoa.Visible = flag;
            btnSua.Visible = flag;
            btnGhi.Visible = !flag;
            btnKhong.Visible = !flag;
            btnChonLSX.Visible = !flag;
            mnuCapNhatTo.Visible = !flag;
            mnuNhapTGNM.Visible = flag;
        }

        private void ReadonlyControl(bool flag)
        {
            txtCode.Properties.ReadOnly = flag;
            txtNote.Properties.ReadOnly = flag;
            grdProDuctRun.Enabled = flag;
            datTuNgay.Properties.ReadOnly = !flag;
            datDenNgay.Properties.ReadOnly = !flag;
            if (iThem == -1)
            {
                datBD.Properties.ReadOnly = flag;
                datKT.Properties.ReadOnly = flag;
            }
            else
            {
                datBD.Properties.ReadOnly = true;
                datKT.Properties.ReadOnly = true;
            }
            try
            {
                if (Commons.Modules.ObjSystems.ConvertDatatable(grvPrRunDetails).Rows.Count == 0)
                {
                    cboCa.Properties.ReadOnly = flag;
                }
                else
                {
                    cboCa.Properties.ReadOnly = true;
                }
            }
            catch
            {
                cboCa.Properties.ReadOnly = flag;
            }
        }
        private void LoadgrdProDuctRun(Int64 id)
        {
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListProductionRun", datTuNgay.DateTime.Date, datDenNgay.DateTime.Date, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                dtmp.PrimaryKey = new DataColumn[] { dtmp.Columns["ID"] };
                if (grdProDuctRun.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdProDuctRun, grvProDuctRun, dtmp, false, true, false, false, true,
                        this.Name);
                    grvProDuctRun.Columns["ID"].Visible = false;
                    grvProDuctRun.Columns["CaSTT"].Visible = false;
                    Commons.Modules.ObjSystems.AddCombDateTimeEdit("StartTime", grvProDuctRun);
                }
                else
                    grdProDuctRun.DataSource = dtmp;

                if (id != -1)
                {
                    int index = dtmp.Rows.IndexOf(dtmp.Rows.Find(id));
                    grvProDuctRun.FocusedRowHandle = grvProDuctRun.GetRowHandle(index);
                }
                if (grvProDuctRun.FocusedRowHandle < 1)
                {
                    grvProDuctRun_FocusedRowChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadgrdEquiment()
        {
            if (datBD.Text == "") return;
            DataTable dtmp = new DataTable();
            try
            {
                dtmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetProDuctionOEE", cboCa.EditValue, datBD.DateTime, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                if (grdEquipment.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdEquipment, grvEquipment, dtmp, false, false, true, true, true,
                        this.Name);
                    grvEquipment.Columns["CaSTT"].Visible = false;
                }
                else
                    grdEquipment.DataSource = dtmp;
            }
            catch (Exception ex)
            {
                grdEquipment.DataSource = null;
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadgrdPrRunDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListProductionRunDetails", iThem == -1 ? -1 : Convert.ToInt64(grvProDuctRun.GetFocusedRowCellValue("ID")), Commons.Modules.UserName, Commons.Modules.TypeLanguage));

                dt.Columns["SumMinute"].ReadOnly = false;
                dt.Columns["ConvertQuantity"].ReadOnly = false;
                if (grdPrRunDetails.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdPrRunDetails, grvPrRunDetails, dt, false, false, false, false, true, this.Name);
                    grvPrRunDetails.Columns["ActualQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvPrRunDetails.Columns["ActualQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvPrRunDetails.Columns["DefectQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvPrRunDetails.Columns["DefectQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvPrRunDetails.Columns["ActualSpeed"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvPrRunDetails.Columns["ActualSpeed"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvPrRunDetails.Columns["StandardSpeed"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvPrRunDetails.Columns["StandardSpeed"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvPrRunDetails.Columns["StandardOutput"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvPrRunDetails.Columns["StandardOutput"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    grvPrRunDetails.Columns["NumberPerCycle"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvPrRunDetails.Columns["NumberPerCycle"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    //grvPrRunDetails.Columns["ActualSpeed"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    //grvPrRunDetails.Columns["ActualSpeed"].SummaryItem.DisplayFormat = "Sum = {0:" + Commons.Modules.sSoLeDG + "}";

                    //add production
                    Commons.Modules.ObjSystems.AddCombXtra("ID", "PrOrNumber", "PrOID", grvPrRunDetails, Commons.Modules.ObjSystems.DataProductOrDer(), false, this.Name);
                    //addItem
                    RepositoryItemLookUpEdit cboItems = new RepositoryItemLookUpEdit();
                    cboItems.NullText = "";
                    cboItems.ValueMember = "ID";
                    cboItems.DisplayMember = "ItemName";
                    cboItems.DataSource = Commons.Modules.ObjSystems.DataItemByPro(-1);
                    cboItems.Columns.Clear();
                    cboItems.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemName"));
                    cboItems.Columns["ItemName"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "ItemName");
                    cboItems.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    cboItems.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    grvPrRunDetails.Columns["ItemID"].ColumnEdit = cboItems;
                    cboItems.BeforePopup += CboItems_BeforePopup;

                    //add Hệ Thống
                    Commons.Modules.ObjSystems.AddCombXtra("MS_HE_THONG", "TEN_HE_THONG", "MS_HE_THONG", grvPrRunDetails, Commons.Modules.ObjSystems.DataHeThongBySchedule(), false, this.Name);

                    // Add máy

                    //addMay
                    RepositoryItemLookUpEdit cboMSMay = new RepositoryItemLookUpEdit();
                    cboMSMay.NullText = "";
                    cboMSMay.ValueMember = "MS_MAY";
                    cboMSMay.DisplayMember = "TEN_MAY";
                    cboMSMay.DataSource = Commons.Modules.ObjSystems.DataMay(false);
                    cboMSMay.Columns.Clear();
                    cboMSMay.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_MAY"));
                    cboMSMay.Columns["TEN_MAY"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_MAY");
                    cboMSMay.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    cboMSMay.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    grvPrRunDetails.Columns["MS_MAY"].ColumnEdit = cboMSMay;
                    cboMSMay.BeforePopup += CboMSMay_BeforePopup;
                    //trung nguyên lấy từ tổ khác lấy từ người vận hành
                    //add người vận hành
                    // //ID,OperatorName
                    Commons.Modules.ObjSystems.AddCombXtra("ID", "OperatorName", "OperatorID", grvPrRunDetails, Commons.Modules.ObjSystems.DataOpetator(false), false, this.Name);
                    //add đơn vị tính
                    Commons.Modules.ObjSystems.AddCombXtra("ID", "UOMName", "UOM", grvPrRunDetails, Commons.Modules.ObjSystems.DataUOMShortName(true), false, this.Name);
                    //add ngày
                    Commons.Modules.ObjSystems.AddCombDateTimeEdit("StartTime", grvPrRunDetails);
                    Commons.Modules.ObjSystems.AddCombDateTimeEdit("EndTime", grvPrRunDetails);

                    grvPrRunDetails.Columns["UOM"].OptionsColumn.ReadOnly = true;
                    grvPrRunDetails.Columns["ActualSpeed"].OptionsColumn.ReadOnly = true;
                    grvPrRunDetails.Columns["ConvertQuantity"].OptionsColumn.ReadOnly = true;
                    grvPrRunDetails.Columns["SumMinute"].OptionsColumn.ReadOnly = true;
                    grvPrRunDetails.Columns["PrOID"].OptionsColumn.ReadOnly = true;

                }
                else
                    grdPrRunDetails.DataSource = dt;

                if (grvPrRunDetails.FocusedRowHandle < 1)
                {
                    grvPrRunDetails_FocusedRowChanged(null, null);
                }
            }
            catch
            {
            }
        }

        private void CboMSMay_BeforePopup(object sender, EventArgs e)
        {
            try
            {
                Int64 proID = Convert.ToInt64(grvPrRunDetails.GetFocusedRowCellValue("PrOID"));
                Int64 ItemID = Convert.ToInt64(grvPrRunDetails.GetFocusedRowCellValue("ItemID"));
                Int32 MS_HT = Convert.ToInt32(grvPrRunDetails.GetFocusedRowCellValue("MS_HE_THONG"));


                if (sender is LookUpEdit cbo)
                {
                    cbo.Properties.DataSource = null;
                    cbo.Properties.DataSource = Commons.Modules.ObjSystems.DataMay(0, MS_HT == 0 ? -1 : MS_HT, proID == 0 ? -1 : proID, ItemID == 0 ? -1 : ItemID);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void CboItems_BeforePopup(object sender, EventArgs e)
        {
            try
            {
                Int64 proID = Convert.ToInt64(grvPrRunDetails.GetFocusedRowCellValue("PrOID"));
                if (sender is LookUpEdit cbo)
                {
                    cbo.Properties.DataSource = null;
                    cbo.Properties.DataSource = Commons.Modules.ObjSystems.DataItemByPro(proID == 0 ? -1 : proID);
                }
            }
            catch
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            iThem = -1;
            InsertResetText();
            txtCode.Focus();
            Commons.Modules.ObjSystems.AddnewRow(grvPrRunDetails, false);
            ReadonlyControl(false);
            VisibleButon(false);
        }
        private void InsertResetText()
        {
            Commons.Modules.sId = "0Load";
            //cboCa.EditValue = 1;
            txtCode.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT dbo.AUTO_CREATE_SO_TDSX(GETDATE())").ToString();
            //set mac dinh gio theo ca

            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT CONVERT(NVARCHAR(20), GETDATE(), 103) + ' ' + CONVERT(NVARCHAR(20), TU_GIO, 108) AS TU_GIO,CONVERT(NVARCHAR(20), GETDATE(), 103) + ' ' + CONVERT(NVARCHAR(20), DEN_GIO, 108) AS DEN_GIO FROM dbo.CA WHERE STT = " + cboCa.EditValue + ""));
                datBD.DateTime = Convert.ToDateTime(dt.Rows[0]["TU_GIO"]);
                datKT.DateTime = Convert.ToDateTime(dt.Rows[0]["DEN_GIO"]);
            }
            catch (Exception)
            {
                datBD.DateTime = DateTime.Now;
                datKT.DateTime = DateTime.Now.AddHours(1);
            }
            txtNote.Text = "";
            Commons.Modules.sId = "";
            //txtTH.ResetText();
            //txtNPH.ResetText();
            //txtGPH.ResetText();
            //txtDT.ResetText();
            //txtPE.ResetText();
            //txtOEE.ResetText();
            //txtDTPT.ResetText();
            //txtEL.ResetText();
            //txtELVer.EditValue="";
            LoadgrdPrRunDetails();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvProDuctRun.GetFocusedRowCellValue("ID") == null)
            {
                Modules.msgThayThe(ThongBao.msgBanChuaChonDuLieu, "");
                return;
            }
            iThem = Convert.ToInt64(grvProDuctRun.GetFocusedRowCellValue("ID"));
            VisibleButon(false);
            ReadonlyControl(false);
            Commons.Modules.ObjSystems.AddnewRow(grvPrRunDetails, false);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvProDuctRun.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvProDuctRun.GetFocusedRowCellValue("ID").ToString()); } catch { }
            if (iId == -1)
            {
                Modules.msgThayThe(ThongBao.msgKhongCoDuLieuXoa, groProRunDetails.Text);
                return;
            }
            if (grvPrRunDetails.RowCount == 0)
            {
                DeleteData();
            }
            else
            {
                DeleteDatadetails();
            }
            DeleteData();
        }
        private void DeleteDatadetails()
        {
            try
            {
                //kiểm tra máy trong item của pro duction
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groProRunDetails.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, " DELETE  FROM dbo.ProductionRunDetails WHERE DetailID = " + grvPrRunDetails.GetFocusedRowCellValue("DetailID") + " ");
                grvPrRunDetails.DeleteSelectedRows();
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            //kiểm tra chưa nhập tổ
            if (Commons.Modules.ObjSystems.ConvertDatatable(grvPrRunDetails).AsEnumerable().Where(x => x.Field<Int64?>("OperatorID") == null).Count() > 0)
            {
                Commons.Modules.msgThayThe(Commons.ThongBao.msgBanChuaNhapDuDuLieu, Commons.Modules.ObjLanguages.GetLanguage(this.Name, "OperatorName"));
                return;
            }
            if (cboCa.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblCa.Text, cboCa);
                return;
            }
            //kiểm tra giờ  không trùng lặp
            //tạo bảo tạm
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "TMPPRORUN" + Commons.Modules.UserName, Commons.Modules.ObjSystems.ConvertDatatable(grvPrRunDetails), "");
            try
            {
                for (int i = 0; i <= grvPrRunDetails.RowCount; i++)
                {
                    int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spKiemTraGioHopLeRun",iThem,grvPrRunDetails.GetRowCellValue(i, "MS_MAY"), Convert.ToInt64(grvPrRunDetails.GetRowCellValue(i, "DetailID")), Convert.ToInt64(grvPrRunDetails.GetRowCellValue(i, "PrOID")), Convert.ToDateTime(grvPrRunDetails.GetRowCellValue(i, "StartTime")), Convert.ToDateTime(grvPrRunDetails.GetRowCellValue(i, "EndTime")), "TMPPRORUN" + Commons.Modules.UserName));
                    if (n > 1)
                    {
                        Modules.msgThayThe(ThongBao.msgNgayBiTrungDuLieu, grvPrRunDetails.GetRowCellValue(i, "MS_MAY").ToString());
                        return;
                    }
                }
            }
            catch (Exception)
            {
            }

            if (!dxValidationProvider1.Validate()) return;
            Validate();
            //lưu khi thêm
            SaveData();
            VisibleButon(true);
            ReadonlyControl(true);
            grvPrRunDetails.OptionsBehavior.Editable = false;
            tbProRunDetails.Clear();
            LoadgrdEquiment();
            Commons.Modules.ObjSystems.XoaTable("TMPProMayChoose" + Commons.Modules.UserName);
        }
        private void SaveData()
        {
            tbProRunDetails = Commons.Modules.ObjSystems.ConvertDatatable(grvPrRunDetails);
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, tbProRunDetails, "");
            iThem = Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spSaveProductionRun", iThem, txtCode.EditValue, datBD.DateTime, datKT.DateTime, cboCa.EditValue, txtNote.EditValue, sBT));
            LoadgrdProDuctRun(iThem);
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            VisibleButon(true);
            ReadonlyControl(true);
            iThem = Convert.ToInt64(grvProDuctRun.GetFocusedRowCellValue("ID"));
            grvPrRunDetails.OptionsBehavior.Editable = false;
            LoadgrdProDuctRun(iThem);
            tbProRunDetails.Clear();
            Commons.Modules.ObjSystems.XoaTable("TMPProMayChoose" + Commons.Modules.UserName);
        }
        private void datTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadgrdProDuctRun(-1);
        }
        private void grvProDuctRun_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            iThem = Convert.ToInt64(grvProDuctRun.GetFocusedRowCellValue("ID"));
            Commons.Modules.sId = "0Load";
            BingDingData();
            Commons.Modules.sId = "";
            LoadgrdPrRunDetails();
        }
        private void BingDingData()
        {
            if (grvProDuctRun.RowCount == 0) return;
            try
            {
                txtCode.EditValue = grvProDuctRun.GetFocusedRowCellValue("Code");
                cboCa.EditValue = grvProDuctRun.GetFocusedRowCellValue("CaSTT");
                datBD.DateTime = Convert.ToDateTime(grvProDuctRun.GetFocusedRowCellValue("StartTime"));
                datKT.DateTime = Convert.ToDateTime(grvProDuctRun.GetFocusedRowCellValue("EndTime"));
                txtNote.EditValue = grvProDuctRun.GetFocusedRowCellValue("Note");
            }
            catch
            {
            }
        }
        private void DeleteDataDetails()
        {
            try
            {
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groProRunDetails.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.ProductionRunDetails WHERE DetailID = '" + (grvPrRunDetails.GetFocusedRowCellValue("DetailID") + "'"));
                grvPrRunDetails.DeleteSelectedRows();
                LoadgrdEquiment();
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }

        private void grdPrRunDetails_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (btnGhi.Visible == false)
                    DeleteDataDetails();
                else
                    grvPrRunDetails.DeleteSelectedRows();
            }
            LoadgrdEquiment();
        }
        private void grdProDuctRun_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && btnGhi.Visible == false)
            {
                DeleteData();
            }
            LoadgrdEquiment();
        }
        private void DeleteData()
        {
            if (Modules.msgHoiThayThe(ThongBao.msgXoa, groProRun.Text) == DialogResult.No) return;
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.ProductionRunDetails WHERE ProductionRunID ='" + Convert.ToInt64(grvProDuctRun.GetFocusedRowCellValue("ID")) + "' DELETE dbo.ProductionRun WHERE ID = '" + Convert.ToInt64(grvProDuctRun.GetFocusedRowCellValue("ID")) + "'");
                grvProDuctRun.DeleteSelectedRows();
                grvProDuctRun_FocusedRowChanged(null, null);
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
                //XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void datBD_EditValueChanged(object sender, EventArgs e)
        {
            LoadgrdEquiment();
            if (Commons.Modules.sId == "0Load") return;
            //cboCa.EditValue = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text,
            //    "SELECT TOP 1 STT FROM dbo.CA WHERE CONVERT (TIME, '" + datBD.DateTime.TimeOfDay +
            //    "')  BETWEEN CONVERT (TIME,TU_GIO) AND CONVERT (TIME,DEN_GIO)"));
            if (Commons.Modules.ObjSystems.ConvertDatatable(grdPrRunDetails).Rows.Count == 0) return;
            if (Commons.Modules.msgHoi("msgBanCoMuonCapNhatLaiGio") == DialogResult.Yes)
            {
                if (!dxValidationProvider1.Validate()) return;
                Validate();
                for (int i = 0; i < grvPrRunDetails.RowCount; i++)
                {
                    grvPrRunDetails.SetRowCellValue(i, "StartTime", datBD.DateTime);
                    grvPrRunDetails.SetRowCellValue(i, "EndTime", datKT.DateTime);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvPrRunDetails_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //mặc định khi thêm dòng mới
            try
            {
                GridView view = sender as GridView;
                view.SetFocusedRowCellValue(view.Columns["StartTime"], datBD.DateTime);
                view.SetFocusedRowCellValue(view.Columns["EndTime"], datKT.DateTime);
                TimeSpan span = datKT.DateTime - datBD.DateTime;
                view.SetFocusedRowCellValue(view.Columns["SumMinute"], Convert.ToInt32(span.TotalMinutes));
                view.SetFocusedRowCellValue(view.Columns["DefectQuantity"], 0);
                //view.SetFocusedRowCellValue(view.Columns["SumMinute"],TimeSpan());
                //nếu thêm thì set PrOID  = -1 ngược lại set bằng lưới pro
                //if (iThem == -1)
                //{
                //    view.SetFocusedRowCellValue(view.Columns["PrOID"], -1);
                //}
                //else
                //{
                //    view.SetFocusedRowCellValue(view.Columns["PrOID"], grvProDuctOD.GetFocusedRowCellValue("ID"));
                //}
            }
            catch
            {
            }
        }

        private void grvPrRunDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                //kiểm tra null
                DevExpress.XtraGrid.Views.Grid.GridView View = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                DevExpress.XtraGrid.Columns.GridColumn sproID = View.Columns["PrOID"];
                if (Commons.Modules.ObjSystems.IsnullorEmpty(View.GetRowCellValue(e.RowHandle, sproID)))
                {
                    e.Valid = false;
                    View.SetColumnError(sproID, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtraProNULL", Commons.Modules.TypeLanguage)); return;
                }

                DevExpress.XtraGrid.Columns.GridColumn sproItem = View.Columns["ItemID"];
                if (Commons.Modules.ObjSystems.IsnullorEmpty(View.GetRowCellValue(e.RowHandle, sproItem)))
                {
                    e.Valid = false;
                    View.SetColumnError(sproItem, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtraItemNULL", Commons.Modules.TypeLanguage)); return;
                }
                DevExpress.XtraGrid.Columns.GridColumn sMaMay = View.Columns["MS_MAY"];
                if (Commons.Modules.ObjSystems.IsnullorEmpty(View.GetRowCellValue(e.RowHandle, sMaMay)))
                {
                    e.Valid = false;
                    View.SetColumnError(sMaMay, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtraMayNULL", Commons.Modules.TypeLanguage)); return;
                }

                DevExpress.XtraGrid.Columns.GridColumn sMaTo = View.Columns["OperatorID"];
                if (Commons.Modules.ObjSystems.IsnullorEmpty(View.GetRowCellValue(e.RowHandle, sMaTo)))
                {
                    e.Valid = false;
                    View.SetColumnError(sMaTo, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtraToNULL", Commons.Modules.TypeLanguage)); return;
                }
            }
            catch
            {
            }
        }

        private void grvPrRunDetails_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            //kiểm tra
            grvPrRunDetails.ClearColumnErrors();
            try
            {
                DataTable dt = new DataTable();
                GridView view = sender as GridView;
                DevExpress.XtraGrid.Columns.GridColumn clMaMay = view.Columns["MS_MAY"];
                if (view == null) return;

                if (view.FocusedColumn.Name == "colPrOID")
                {//kiểm tra máy không được để trống
                    view.SetFocusedRowCellValue(view.Columns["ItemID"], null);
                    view.SetFocusedRowCellValue(view.Columns["MS_MAY"], null);
                    view.SetFocusedRowCellValue(view.Columns["PrOID"], e.Value);
                }
                if (view.FocusedColumn.Name == "colItemID")
                {//kiểm tra máy không được để trống
                    view.SetFocusedRowCellValue(view.Columns["MS_MAY"], null);
                    view.SetFocusedRowCellValue(view.Columns["UOM"], Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 UOMID FROM dbo.PrODetails WHERE PrOID = " + Convert.ToInt64(grvPrRunDetails.GetFocusedRowCellValue("PrOID")) + " AND ItemID = " + e.Value + " ")));
                    view.SetFocusedRowCellValue(view.Columns["ItemID"], e.Value);
                }
                //
                if (view.FocusedColumn.Name == "colActualQuantity")
                {//kiểm tra máy không được để trống
                    if (!Commons.Modules.ObjSystems.IsnullorEmpty(e.Value))
                    {
                        string s = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT [dbo].[fnGetConvertQuantity](" + grvPrRunDetails.GetFocusedRowCellValue("ItemID") + "," + e.Value + ")").ToString();
                        view.SetFocusedRowCellValue(view.Columns["ConvertQuantity"], s);
                        view.SetFocusedRowCellValue(view.Columns["ActualQuantity"], e.Value);
                    }
                }
                //kiểm tra số lượng hàng lỗi không hớn hơn số lượng sản xuất
                if (view.FocusedColumn.Name == "colDefectQuantity")
                {
                    if (Convert.ToDecimal(view.GetFocusedRowCellValue("ActualQuantity")) < Convert.ToDecimal(e.Value))
                    {
                        e.Valid = false;
                        e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "erHangLoiKhongLonHonSanXuat");
                        view.SetColumnError(view.Columns["DefectQuantity"], e.ErrorText);
                    }
                }

                if (view.FocusedColumn.Name == "colMS_MAY")
                {//kiểm tra máy không được để trống
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.Valid = false;
                        e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "erMayKhongTrong");
                        view.SetColumnError(view.Columns["MS_MAY"], e.ErrorText);
                        return;
                    }
                    else
                    {
                        dt = new DataTable();
                        dt = Commons.Modules.ObjSystems.ConvertDatatable(grdPrRunDetails);
                        if (dt.AsEnumerable().Count(x => x.Field<string>("MS_MAY").Equals(e.Value)) > 0)
                        {
                            e.Valid = false;
                            e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "erTrungDuLieu");
                            view.SetColumnError(view.Columns["MS_MAY"], e.ErrorText);
                            return;
                        }
                        dt = new DataTable();
                        //lay cac gia tri mac dinh tu itemmay sang
                        //	StandardOutput,MS_DV_TG_Output,StandardSpeed,MS_DV_TG_Speed,DownTimeRecord,DownTimeRecord
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetSLProSchedule", Convert.ToInt64(grvPrRunDetails.GetFocusedRowCellValue("PrOID")), Convert.ToInt64(grvPrRunDetails.GetFocusedRowCellValue("ItemID")), e.Value.ToString()));
                        view.SetFocusedRowCellValue("ActualQuantity", dt.Rows[0]["ActualQuantity"]);
                        view.SetFocusedRowCellValue("StandardSpeed", dt.Rows[0]["StandardSpeed"]);
                        view.SetFocusedRowCellValue("StandardOutput", dt.Rows[0]["StandardOutput"]);
                        view.SetFocusedRowCellValue("WorkingCycle", dt.Rows[0]["WorkingCycle"]);
                        view.SetFocusedRowCellValue("NumberPerCycle", dt.Rows[0]["NumberPerCycle"]);
                        string s = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT [dbo].[fnGetConvertQuantity](" + grvPrRunDetails.GetFocusedRowCellValue("ItemID") + "," + dt.Rows[0]["ActualQuantity"] + ")").ToString();
                        view.SetFocusedRowCellValue(view.Columns["ConvertQuantity"], s);
                        view.SetFocusedRowCellValue(view.Columns["MS_MAY"], e.Value);
                    }
                }
                if (view.FocusedColumn.Name == "colStartTime")
                {
                    //Kiểm tra từ ngày không lớn hơn đến ngày
                    if (DateTime.Compare(Convert.ToDateTime(e.Value), Convert.ToDateTime(view.GetFocusedRowCellValue("EndTime"))) != -1)
                    {
                        e.Valid = false;
                        e.ErrorText = "This value is not valid";
                        view.SetColumnError(view.Columns["StartTime"], e.ErrorText);
                        return;
                    }
                    else
                    {
                        TimeSpan span = Convert.ToDateTime(grvPrRunDetails.GetFocusedRowCellValue("EndTime")) - Convert.ToDateTime(e.Value);
                        view.SetFocusedRowCellValue(view.Columns["SumMinute"], Convert.ToInt32(span.TotalMinutes));
                        view.SetFocusedRowCellValue(view.Columns["StartTime"], e.Value);

                    }
                }
                if (view.FocusedColumn.Name == "colEndTime")
                {
                    //Kiểm tra từ ngày không lớn hơn đến ngày
                    if (DateTime.Compare(Convert.ToDateTime(e.Value), Convert.ToDateTime(view.GetFocusedRowCellValue("StartTime"))) != 1)
                    {
                        e.Valid = false;
                        e.ErrorText = "This value is not valid";
                        view.SetColumnError(view.Columns["EndTime"], e.ErrorText);
                        return;
                    }
                    else
                    {
                        TimeSpan span = Convert.ToDateTime(e.Value) - Convert.ToDateTime(grvPrRunDetails.GetFocusedRowCellValue("StartTime"));
                        view.SetFocusedRowCellValue(view.Columns["SumMinute"], Convert.ToInt32(span.TotalMinutes));
                        view.SetFocusedRowCellValue(view.Columns["EndTime"], e.Value);
                    }
                }
            }
            catch { }
        }

        private void grvPrRunDetails_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                DevExpress.XtraGrid.Columns.GridColumn clMaMay = view.Columns["MS_MAY"];

                if (view == null) return;
                if (view.FocusedColumn.Name == "colItemID")
                {
                    if (Commons.Modules.ObjSystems.IsnullorEmpty(grvPrRunDetails.GetFocusedRowCellValue("PrOID")))
                    {
                        e.Cancel = true;
                        view.SetColumnError(view.Columns["colPrOID"], "chọn lệnh xản xuất trước!");
                    }
                }
                if (view.FocusedColumn.Name == "colMS_MAY")
                {
                    if (Commons.Modules.ObjSystems.IsnullorEmpty(grvPrRunDetails.GetFocusedRowCellValue("PrOID")) || Commons.Modules.ObjSystems.IsnullorEmpty(grvPrRunDetails.GetFocusedRowCellValue("ItemID")) || Commons.Modules.ObjSystems.IsnullorEmpty(grvPrRunDetails.GetFocusedRowCellValue("MS_HE_THONG")))
                    {
                        e.Cancel = true;
                        view.SetColumnError(view.Columns["colPrOID"], "Chưa chọn đủ dữ liệu!");
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grvPrRunDetails_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvPrRunDetails_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void btnChonMay_Click(object sender, EventArgs e)
        {
            if (cboCa.Text.Trim() == "")
            {
                Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblCa.Text, cboCa);
                return;
            }
            tbProRunDetails = Commons.Modules.ObjSystems.ConvertDatatable(grdPrRunDetails);
            frmChoosePro device = new frmChoosePro();
            device.TabMayPro = tbProRunDetails;
            device.TN = datBD.DateTime;
            device.DN = datKT.DateTime;
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "TMPProMayChoose" + Commons.Modules.UserName, tbProRunDetails, "");
            if (device.ShowDialog() == DialogResult.OK)
            {
                //load lại item máy
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, " SELECT * FROM  TMPProMayChoose" + Commons.Modules.UserName + " "));
                grdPrRunDetails.DataSource = dt;
            }
        }

        private void grvPrRunDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (btnGhi.Visible == true) return;
            //DataTable dt = new DataTable();
            //dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetProDuctionOEE", grvPrRunDetails.GetFocusedRowCellValue("DetailID")));
            //txtTH.EditValue = dt.Rows[0]["TH"];
            //txtNPH.EditValue = dt.Rows[0]["NPH"];
            //txtGPH.EditValue = dt.Rows[0]["GPH"];
            //txtDT.EditValue = dt.Rows[0]["DT"];
            //txtPE.EditValue = dt.Rows[0]["PE"];
            //txtOEE.EditValue = dt.Rows[0]["OEE"];
            //txtDTPT.EditValue = dt.Rows[0]["DTP"];
            //txtEL.EditValue = dt.Rows[0]["EL"];
            //txtELVer.EditValue = dt.Rows[0]["ELV"];
        }

        private void mnuNhapTGNM_Click(object sender, EventArgs e)
        {
            try
            {
                string msmay = grvPrRunDetails.GetFocusedRowCellValue("MS_MAY").ToString();
            }
            catch
            {
                Modules.msgThayThe(ThongBao.msgBanChuaChonDuLieu, "");
                return;
            }
            try
            {
                frmThoiGianNgungMay frmNM = new frmThoiGianNgungMay();
                frmNM.msMay = grvPrRunDetails.GetFocusedRowCellValue("MS_MAY").ToString();
                frmNM.msHT = Convert.ToInt32(grvPrRunDetails.GetFocusedRowCellValue("MS_HE_THONG"));
                frmNM.msCa = Convert.ToInt32(cboCa.EditValue);
                frmNM.msProRunDetails = Convert.ToInt64(grvPrRunDetails.GetFocusedRowCellValue("DetailID"));
                frmNM.datTNgay = Convert.ToDateTime(grvPrRunDetails.GetFocusedRowCellValue("StartTime"));
                frmNM.datDNgay = Convert.ToDateTime(grvPrRunDetails.GetFocusedRowCellValue("EndTime"));
                frmNM.ShowDialog();
                LoadgrdEquiment();
            }
            catch
            {
            }
        }

        private void cboCa_EditValueChanged(object sender, EventArgs e)
        {
            //if(Commons.Modules.sId == "0Load") return;
            DataTable dt = new DataTable();
            try
            {
                if (Commons.Modules.ObjSystems.ConvertDatatable(grvPrRunDetails).Rows.Count == 0)
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT CONVERT(NVARCHAR(20), GETDATE(), 103) + ' ' + CONVERT(NVARCHAR(20), TU_GIO, 108) AS TU_GIO,CONVERT(NVARCHAR(20), GETDATE(), 103) + ' ' + CONVERT(NVARCHAR(20), DEN_GIO, 108) AS DEN_GIO FROM dbo.CA WHERE STT = " + cboCa.EditValue + ""));
                    datBD.DateTime = Convert.ToDateTime(dt.Rows[0]["TU_GIO"]);
                    datKT.DateTime = Convert.ToDateTime(dt.Rows[0]["DEN_GIO"]);
                    if (datKT.DateTime.TimeOfDay < datBD.DateTime.TimeOfDay)
                    {
                        datKT.DateTime = datKT.DateTime.AddDays(1);
                    }
                }
            }
            catch
            {
                //datBD.DateTime = DateTime.Now;
                //datKT.DateTime = DateTime.Now.AddHours(1);
            }
            LoadgrdEquiment();
        }
        private void mnuReLoad_Click(object sender, EventArgs e)
        {
            LoadgrdEquiment();
        }

        private void grvPrRunDetails_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
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
            catch
            {
            }
        }

        private void mnuCapNhatTo_Click(object sender, EventArgs e)
        {
            //kiểm tra tổ hiện tại có dữ liệu không
            try
            {
                Int64 msToCN = Convert.ToInt64(grvPrRunDetails.GetFocusedRowCellValue("OperatorID"));
                //cập nhật trên lưới các dòng hiện tại
                for (int i = 0; i < grvPrRunDetails.DataRowCount; i++)
                {
                    if (Commons.Modules.ObjSystems.IsnullorEmpty(grvPrRunDetails.GetRowCellValue(i, "OperatorID")))
                    {
                        grvPrRunDetails.SetRowCellValue(i, "OperatorID", msToCN);
                    }
                    //do something  
                }

            }
            catch
            {

            }
        }

        private void grvPrRunDetails_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column != view.Columns["ActualQuantity"])
                return;
            e.Appearance.BackColor = Color.FromArgb(255, 204, 255);
        }
    }
}
