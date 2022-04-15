using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Commons;
using System.Reflection;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using Spire.Xls;

namespace VS.OEE
{
    public partial class frmProductOrder : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        Int64 ithem = 0;
        string sBTDetail = "TMPProDucDetails" + Commons.Modules.UserName;
        string sBTSchedule = "TMPProSchedule" + Commons.Modules.UserName;
        DataTable tbProSchedule = new DataTable();
        public frmProductOrder(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
        }

        #region eventForm
        private void frmItemMay_Load(object sender, EventArgs e)
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
            Commons.Modules.ObjSystems.MLoadLookUpEdit(cboTinhTrang, Commons.Modules.ObjSystems.DataSatusProDuct(false), "ID", "NAME_STATUS", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "NAME_STATUS"));
            Commons.Modules.sId = "0Load";
            datTuNgay.DateTime = DateTime.Now.Date.AddDays(-DateTime.Now.Date.Day + 1);
            datDenNgay.DateTime = datTuNgay.DateTime.AddMonths(1).AddDays(-1);
            LoadgrdProDuctOrDer(-1);
            LoadgrdPrODetails();
            LoadgrdSchedule();
            Commons.Modules.sId = "";
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            ithem = -1;
            VisibleButon(false);
            BingdingControl(true);
            LoadgrdPrODetails();
            Commons.Modules.sId = "";
            txtSoLSX.Focus();
            Commons.Modules.ObjSystems.AddnewRow(grvPrODetails, true);
            Commons.Modules.ObjSystems.AddnewRow(grvSchedule, true);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvProDuctOD.GetFocusedRowCellValue("ID") == null)
            {
                return;
            }
            ithem = Convert.ToInt64(grvProDuctOD.GetFocusedRowCellValue("ID"));
            VisibleButon(false);
            Commons.Modules.ObjSystems.AddnewRow(grvPrODetails, true);
            Commons.Modules.ObjSystems.AddnewRow(grvSchedule, true);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnThem.Visible = btnXoa.Visible = btnSua.Visible = btnThoat.Visible = false;
            btnDelSche.Visible = btnDelPro.Visible = btnDelDetails.Visible = btnTroVe.Visible = true;
        }

        //kiểm tra cân
        private string CheckSoLuong()
        {
            string ItemName = "";
            try
            {
                //kiểm tra dòng hiện tại thì so với lưới
                if (Convert.ToDecimal(grvPrODetails.GetFocusedRowCellValue("PlannedQuantity")) != Commons.Modules.ObjSystems.ConvertDatatable(grvSchedule).AsEnumerable().Sum(x => x.Field<decimal>("PlannedQuantity")))
                {
                    ItemName += grvPrODetails.GetFocusedRowCellValue("ItemName") + ";";
                }
                else
                {
                    //lấy table trừ trừ item hiện tại ra
                    DataTable dt = tbProSchedule.AsEnumerable().Where(x => x.Field<Int64>("DetailsID") != Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("DetailsID"))).CopyToDataTable();
                    if (dt.Rows.Count == 0)
                    {
                    }
                    else
                    {
                        //lấy data table trên lưới
                        DataTable tbdetails = Commons.Modules.ObjSystems.ConvertDatatable(grdPrODetails);
                        for (int i = 0; i < tbdetails.Rows.Count; i++)
                        {
                            //kiểu tra details khác details hiện tại và có trong lưới tạm
                            if (Convert.ToInt64(tbdetails.Rows[i]["DetailsID"]) != Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("DetailsID")) && tbProSchedule.AsEnumerable().Where(x => x.Field<Int64>("DetailsID").Equals(Convert.ToInt64(tbdetails.Rows[i]["DetailsID"]))).Count() > 0)
                            {
                                //lấy giá trị của của details so với 
                                Decimal tongdetails = tbProSchedule.AsEnumerable().Where(x => x.Field<Int64>("DetailsID").Equals(Convert.ToInt64(tbdetails.Rows[i]["DetailsID"]))).Sum(x => x.Field<Decimal>("PlannedQuantity"));
                                if (Convert.ToDecimal(tbdetails.Rows[i]["PlannedQuantity"]) != tongdetails)
                                {
                                    ItemName += tbdetails.Rows[i]["ItemName"] + ";";
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                ItemName = "";
            }
            return ItemName;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu
            try
            {
                #region Kiem du lieu của mã item 
                if (txtSoLSX.Text.Trim() == "")
                {
                    Modules.msgThayThe(ThongBao.msgKhongDuocTrong, lblSoLSX.Text, txtSoLSX);
                    return;
                }
                object rs = IConnections.MExecuteScalar("SELECT COUNT(*) FROM dbo.ProductionOrder WHERE PrOrNumber ='" + txtSoLSX.Text.Trim() + "'  " + (ithem == -1 ? "" : "AND ID <> " + ithem + "") + "  ");
                if (rs != null && (Int32)rs > 0)
                {
                    Modules.msgThayThe(ThongBao.msgDaTonTai, lblSoLSX.Text, txtSoLSX);
                    return;
                }
                //kiểm tra dữ liệu cân
                string sItemName = CheckSoLuong();
                if (sItemName != "")
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgSoLuongKhongCan") + " " + sItemName + " )", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgThongBao"));
                    return;
                }
                if (!dxValidationProvider1.Validate()) return;
                Validate();
                #endregion
                try
                {
                    AddbtProSchedule();
                    if (tbProSchedule.Rows.Count == 0)
                    {
                        tbProSchedule = Commons.Modules.ObjSystems.ConvertDatatable(grdSchedule);
                    }
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTDetail, Commons.Modules.ObjSystems.ConvertDatatable(grdPrODetails), "");
                    Commons.Modules.ObjSystems.XoaTable(sBTSchedule);
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTSchedule, tbProSchedule, "");
                    ithem = Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditProDucOrDer", ithem, txtSoLSX.EditValue
, datNgayLap.DateTime, datNgayBD.DateTime, datNgayHTKH.DateTime, cboTinhTrang.EditValue, txtNote.EditValue, sBTDetail, sBTSchedule));
                    Commons.Modules.ObjSystems.DeleteAddRow(grvPrODetails);
                    Commons.Modules.ObjSystems.DeleteAddRow(grvSchedule);
                    VisibleButon(true);
                    LoadgrdProDuctOrDer(ithem);
                }
                catch
                {
                    //XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbProSchedule.Clear();
                }
                tbProSchedule.Clear();
            }
            catch
            {

            }
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.DeleteAddRow(grvPrODetails);
            Commons.Modules.ObjSystems.DeleteAddRow(grvSchedule);
            VisibleButon(true);
            tbProSchedule.Clear();
            ithem = Convert.ToInt64(grvProDuctOD.GetFocusedRowCellValue("ID"));
            LoadgrdProDuctOrDer(ithem);
            tbProSchedule.Clear();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grvPrODetails_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (view.FocusedColumn.Name == "colItemID")
            {
                if (Commons.Modules.ObjSystems.ConvertDatatable(grdSchedule).Rows.Count == 0)
                    grvPrODetails.Columns["ItemID"].OptionsColumn.ReadOnly = false;
                else
                    grvPrODetails.Columns["ItemID"].OptionsColumn.ReadOnly = true;
            }
        }
        private void btnDelSche_Click(object sender, EventArgs e)
        {
            DeleteDataSchedule();
        }
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            btnThem.Visible = btnXoa.Visible = btnSua.Visible = btnThoat.Visible = true;
            btnDelSche.Visible = btnDelPro.Visible = btnDelDetails.Visible = btnTroVe.Visible = false;
        }
        private void btnDelPro_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void btnDelDetails_Click(object sender, EventArgs e)
        {
            DeleteDataDetail();
        }
        private void cboMSMay_MouseHover(object sender, EventArgs e)
        {
            try
            {
                if (sender is LookUpEdit cbo)
                {
                    cbo.Properties.DataSource = null;
                    cbo.Properties.DataSource = Commons.Modules.ObjSystems.DataMay(Convert.ToInt32(grvPrODetails.GetFocusedRowCellValue("ItemID")), Convert.ToInt32(grvSchedule.GetFocusedRowCellValue("MS_HE_THONG")), -1, -1);
                }
            }
            catch
            {
            }
        }
        private void grvProDuctOD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BingdingControl(false);
            if (Commons.Modules.sId == "0Load") return;
            LoadgrdPrODetails();
        }

        private void rdoStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";
            try
            {
                dtTmp = (DataTable)grdProDuctOD.DataSource;
                sdkien = "(Status = " + (Convert.ToInt32(rdoStatus.SelectedIndex) + 1) + ")";
                dtTmp.DefaultView.RowFilter = sdkien;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
            if (grvProDuctOD.FocusedRowHandle == 0)
            {
                grvProDuctOD_FocusedRowChanged(null, null);
            }
        }
        #endregion

        #region function 
        private void VisibleButon(bool flag)
        {
            btnThem.Visible = flag;
            btnThoat.Visible = flag;
            btnXoa.Visible = flag;
            btnSua.Visible = flag;
            btnImport.Visible = flag;
            btnExport.Visible = flag;
            btnLayMay.Visible = !flag;
            btnGhi.Visible = !flag;
            btnKhong.Visible = !flag;
            ReadonlyControl(flag);
            grdProDuctOD.Enabled = flag;
            rdoStatus.Enabled = flag;
            LoadcboOriginPrO();
        }
        private void BingdingControl(bool them)
        {
            if (them == true)
            {
                txtSoLSX.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT dbo.AUTO_CREATE_SO_KHSX(GETDATE())").ToString();
                txtNote.ResetText();
                cboTinhTrang.EditValue = Convert.ToInt16(1);
                try
                {
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT CONVERT(DATE,GETDATE()) + MIN(TU_GIO) AS TU_GIO, CONVERT(DATE,GETDATE()) + MAX(TU_GIO) AS DEN_GIO FROM dbo.CA"));
                    datNgayBD.DateTime = Convert.ToDateTime(dt.Rows[0]["TU_GIO"]);
                    datNgayHTKH.DateTime = Convert.ToDateTime(dt.Rows[0]["DEN_GIO"]);
                    datNgayLap.DateTime = Convert.ToDateTime(dt.Rows[0]["TU_GIO"]);
                }
                catch
                {
                    datNgayBD.DateTime = DateTime.Now;
                    datNgayHTKH.DateTime = DateTime.Now.AddHours(8);
                    datNgayLap.DateTime = DateTime.Now;
                }
            }
            else
            {
                txtSoLSX.EditValue = grvProDuctOD.GetFocusedRowCellValue("PrOrNumber");
                txtNote.EditValue = grvProDuctOD.GetFocusedRowCellValue("Note");
                cboTinhTrang.EditValue = Convert.ToInt16(grvProDuctOD.GetFocusedRowCellValue("Status"));
                datNgayBD.EditValue = Convert.ToDateTime(grvProDuctOD.GetFocusedRowCellValue("StartDate"));
                datNgayLap.EditValue = Convert.ToDateTime(grvProDuctOD.GetFocusedRowCellValue("OrderDate"));
                datNgayHTKH.EditValue = Convert.ToDateTime(grvProDuctOD.GetFocusedRowCellValue("DueDate"));
            }
        }
        private void ReadonlyControl(bool flag)
        {
            txtSoLSX.Properties.ReadOnly = flag;
            txtNote.Properties.ReadOnly = flag;
            datNgayBD.Properties.ReadOnly = flag;
            datNgayLap.Properties.ReadOnly = flag;
            datNgayHTKH.Properties.ReadOnly = flag;
            cboTinhTrang.Properties.ReadOnly = flag;
        }
        private void LoadcboOriginPrO()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID, PrOrNumber FROM dbo.ProductionOrder UNION SELECT -1 ,'' ORDER BY PrOrNumber"));
            if (dt.Rows.Count < 1) return;
            if (ithem != -1)
            {
                if (dt.Rows.Count < 2) return;
                dt = dt.AsEnumerable().Where(x => !x.Field<Int64>("ID").Equals(grvProDuctOD.GetFocusedRowCellValue("ID"))).CopyToDataTable();
            }
        }
        private void LoadgrdProDuctOrDer(Int64 id)
        {
            if (rdoStatus.SelectedIndex != Convert.ToInt16(cboTinhTrang.EditValue) - 1 && Convert.ToInt16(cboTinhTrang.EditValue) != 0)
            {
                rdoStatus.SelectedIndex = Convert.ToInt16(cboTinhTrang.EditValue) - 1;
            }
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListProductionOrder", datTuNgay.DateTime.Date, datDenNgay.DateTime.Date, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                if (grdProDuctOD.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdProDuctOD, grvProDuctOD, dt, false, true, false, false, true, this.Name);
                }
                else
                    Modules.ObjSystems.MLoadXtraGrid(grdProDuctOD, grvProDuctOD, dt, false, false, false, false, false, this.Name);
                rdoStatus_SelectedIndexChanged(null, null);
                if (id != -1)
                {
                    DataTable tmp = new DataTable();
                    tmp = dt.AsEnumerable().Where(x => x.Field<Int64>("Status").Equals(rdoStatus.SelectedIndex + 1)).CopyToDataTable();
                    tmp.PrimaryKey = new DataColumn[] { tmp.Columns["ID"] };
                    int index = tmp.Rows.IndexOf(tmp.Rows.Find(id));
                    grvProDuctOD.FocusedRowHandle = grvProDuctOD.GetRowHandle(index);
                }
                else { }
                if (grvProDuctOD.FocusedRowHandle < 1)
                {
                    grvProDuctOD_FocusedRowChanged(null, null);
                }
            }
            catch
            {
            }
        }
        private void LoadgrdPrODetails()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListPrODetails", (ithem == -1 ? -1 : Convert.ToInt64(grvProDuctOD.GetFocusedRowCellValue("ID"))), Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                if (grdPrODetails.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdPrODetails, grvPrODetails, dt, false, true, true, false, true, this.Name);
                    //load combo Item
                    try
                    {
                        Commons.Modules.ObjSystems.AddCombXtra("ID", "ItemCode", "ItemID", grvPrODetails, Commons.Modules.ObjSystems.DataItem(0, "-1"), false, this.Name);
                        Commons.Modules.ObjSystems.AddCombXtra("ID", "UOMName", "UOMID", grvPrODetails, Commons.Modules.ObjSystems.DataUOMShortName(true), false, this.Name);

                        grvPrODetails.Columns["PlannedQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                        grvPrODetails.Columns["PlannedQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                        grvPrODetails.Columns["ModerQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                        grvPrODetails.Columns["ModerQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                        grvPrODetails.Columns["AllocatedQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                        grvPrODetails.Columns["AllocatedQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    }
                    catch { }
                }
                else
                {
                    grdPrODetails.DataSource = dt;
                }
                if (grvPrODetails.FocusedRowHandle < 1)
                {
                    grvPrODetails_FocusedRowChanged(null, null);
                }
            }
            catch
            {
            }
        }
        private void LoadgrdSchedule()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListProSchedule", Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("ItemID")), Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("PrOID")), Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("DetailsID")), Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                dt.Columns["NumberPerCycle"].ReadOnly = false;
                if (grdSchedule.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdSchedule, grvSchedule, dt, false, false, false, false, true, this.Name);
                    grvSchedule.Columns["PlannedQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvSchedule.Columns["PlannedQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    grvSchedule.Columns["StandardSpeed"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvSchedule.Columns["StandardSpeed"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    grvSchedule.Columns["StandardOutput"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvSchedule.Columns["StandardOutput"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    grvSchedule.Columns["NumberPerCycle"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvSchedule.Columns["NumberPerCycle"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    grvSchedule.Columns["DownTimeRecord"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvSchedule.Columns["DownTimeRecord"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;
                    grvSchedule.Columns["ActualQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvSchedule.Columns["ActualQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLeDG;

                    Commons.Modules.ObjSystems.AddCombXtra("ID", "UOMName", "UOMID", grvSchedule, Commons.Modules.ObjSystems.DataUOM(true), false, this.Name);
                    //add to //MS_TO, TEN_TO
                    Commons.Modules.ObjSystems.AddCombXtra("ID", "OperatorName", "MS_TO", grvSchedule, Commons.Modules.ObjSystems.DataOpetator(false), false, this.Name);
                    // add Ca
                    Commons.Modules.ObjSystems.AddCombXtra("STT", "CA", "CaID", grvSchedule, Commons.Modules.ObjSystems.DataCa(false), false, this.Name);
                    //CAKT
                    Commons.Modules.ObjSystems.AddCombXtra("STT", "CA", "CaIDKT", grvSchedule, Commons.Modules.ObjSystems.DataCa(false), false, this.Name);
                    //add HT
                    Commons.Modules.ObjSystems.AddCombXtra("MS_HE_THONG", "TEN_HE_THONG", "MS_HE_THONG", grvSchedule, Commons.Modules.ObjSystems.DataHeThong(), false, this.Name);
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
                    grvSchedule.Columns["MS_MAY"].ColumnEdit = cboMSMay;
                    cboMSMay.BeforePopup += CboMSMay_BeforePopup;
                    Commons.Modules.ObjSystems.AddCombXtra("MS_DVT_RT", "TEN_DVT_RT", "MS_DV_TG_Output", grvSchedule, Commons.Modules.ObjSystems.DataDonViTinhRunTime(), false, this.Name);
                    Commons.Modules.ObjSystems.AddCombXtra("MS_DVT_TD", "TEN_DVT_TD", "MS_DV_TG_Speed", grvSchedule, Commons.Modules.ObjSystems.DataDonViTinhTocDo(), false, this.Name);
                    Commons.Modules.ObjSystems.AddCombDateTimeEdit("PlannedStartTime", grvSchedule);
                    Commons.Modules.ObjSystems.AddCombDateTimeEdit("DueTime", grvSchedule);
                }
                else
                {
                    //for (int i = 0; i < dt.Columns.Count; i++)
                    //{
                    //    dt.Columns[i].ReadOnly = false;
                    //}
                    dt.Columns["ActualQuantity"].ReadOnly = true;
                    if (btnGhi.Visible == false)
                    {
                        grdSchedule.DataSource = dt; return;
                    }
                    DataTable tmp = new DataTable();
                    try
                    {
                        //lấy dữ liệu từ bảng tạm
                        tmp = tbProSchedule.AsEnumerable().Where(x => x.Field<Int64>("DetailsID") == Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("DetailsID"))).CopyToDataTable();
                    }
                    catch
                    {
                        if (ithem == -1)
                        {
                            dt.Clear();
                            tmp = dt;
                        }
                    }
                    if (tmp.Rows.Count == 0 && ithem != -1)
                    {
                        grdSchedule.DataSource = dt;
                    }
                    else
                    {
                        if (grvPrODetails.FocusedRowHandle >= 0)
                        {
                            grdSchedule.DataSource = tmp;
                        }
                        else
                        {
                            tmp.Clear();
                            grdSchedule.DataSource = tmp;
                        }
                    }
                }

                grvSchedule.Columns["CapacityUOM"].OptionsColumn.ReadOnly = true;
                grvSchedule.Columns["ActualQuantity"].OptionsColumn.ReadOnly = true;
            }
            catch
            {

            }
        }

        private void CboMSMay_BeforePopup(object sender, EventArgs e)
        {
            try
            {
                if (sender is LookUpEdit cbo)
                {
                    int n = 0;
                    if (Commons.Modules.ObjSystems.IsnullorEmpty(grvSchedule.GetFocusedRowCellValue("MS_HE_THONG")))
                    {
                        n = -1;
                    }
                    else
                    {
                        n = Convert.ToInt32(grvSchedule.GetFocusedRowCellValue("MS_HE_THONG"));
                    }

                    cbo.Properties.DataSource = null;
                    cbo.Properties.DataSource = Commons.Modules.ObjSystems.DataMay(Convert.ToInt32(grvPrODetails.GetFocusedRowCellValue("ItemID")), n, -1, -1);
                }
            }
            catch
            {
            }
        }

        private void SaveItemMay()
        {
            //tạo bảng tạm
            try
            {
                //Commons.Modules.ObjSystems.XoaTable(sBT);
                //Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, Commons.Modules.ObjSystems.ConvertDatatable(grdPrODetails), "");
                //LoadgrdItem(Convert.ToInt64(
                //SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditItemMay", ithem, txtSoLSX.EditValue, txtMacHang.EditValue, datNgayLap.EditValue, datNgayBD.EditValue,
                //            txtSLSX.EditValue, txtMoTa.EditValue, cboDVT.EditValue,
                //            string.IsNullOrEmpty(datNgayHTKH.Text) ? 0 : datNgayHTKH.EditValue, sBT)));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteData()
        {
            if (grvProDuctOD.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvProDuctOD.GetFocusedRowCellValue("ID").ToString()); } catch { }
            if (iId == -1)
            {
                Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                return;
            }
            //kiểm tra proID có trong tiến độ sản xuất không

            if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.ProductionRunDetails WHERE PrOID = " + iId + "")) > 0)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
                return;
            }
            if (Modules.msgHoiThayThe(ThongBao.msgXoa, lblSoLSX.Text) == DialogResult.No) return;
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, " DELETE dbo.ProSchedule WHERE PrOID = " + Convert.ToInt64(grvProDuctOD.GetFocusedRowCellValue("ID")) + " DELETE dbo.PrODetails WHERE PrOID = " + Convert.ToInt64(grvProDuctOD.GetFocusedRowCellValue("ID")) + " DELETE dbo.ProductionOrder WHERE ID = " + Convert.ToInt64(grvProDuctOD.GetFocusedRowCellValue("ID")) + "");
                grvProDuctOD.DeleteSelectedRows();
                grvProDuctOD_FocusedRowChanged(null, null);
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }
        private void DeleteDataDetail()
        {
            try
            {

                if (grvPrODetails.RowCount == 0) return;
                Int64 iIdPro = -1;
                //kiểm tra proid này đã tồn tại 
                try { iIdPro = Modules.ToInt64(grvPrODetails.GetFocusedRowCellValue("PrOID").ToString()); } catch { }
                if (iIdPro == -1 && btnThem.Visible == true)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                    return;
                }
                else
                {
                    if (Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.ProductionRunDetails WHERE PrOID = " + iIdPro + " AND ItemID =  " + Modules.ToInt64(grvPrODetails.GetFocusedRowCellValue("ItemID")) + " ")) > 0)
                    {
                        Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
                        return;
                    }
                }
                Int64 iId = -1;
                try { iId = Modules.ToInt64(grvPrODetails.GetFocusedRowCellValue("DetailsID").ToString()); } catch { }
                if (iId == -1)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                    return;
                }
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groPrODetails.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.ProSchedule WHERE DetailsID = " + Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("DetailsID")) + " DELETE dbo.PrODetails WHERE DetailsID = " + Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("DetailsID") + ""));
                string DetailID = grvPrODetails.GetFocusedRowCellValue("DetailsID").ToString();
                grvPrODetails.DeleteSelectedRows();
                Commons.Modules.ObjSystems.ConvertDatatable(grdPrODetails).AcceptChanges();
                AddbtProSchedule();
                grvPrODetails_FocusedRowChanged(null, null);
                try
                {
                    tbProSchedule = tbProSchedule.AsEnumerable().Where(x => x["DetailsID"].ToString() != DetailID).CopyToDataTable();
                }
                catch
                {
                }
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }
        private void DeleteDataSchedule()
        {
            try
            {
                if (grvSchedule.RowCount == 0) return;
                Int64 iIdPro = -1;
                //kiểm tra proid này đã tồn tại 
                try { iIdPro = Modules.ToInt64(grvProDuctOD.GetFocusedRowCellValue("ID").ToString()); } catch { }
                if (iIdPro == -1)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                    return;
                }
                else
                {
                    if (Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT COUNT(*) FROM dbo.ProductionRunDetails WHERE PrOID = " + iIdPro + "  ")) > 0)
                    {
                        Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
                        return;
                    }
                }

                Int64 iId = -1;
                try { iId = Modules.ToInt64(grvSchedule.GetFocusedRowCellValue("ScheduleID").ToString()); } catch { }
                if (iId == -1)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                    return;
                }
                //kiểm tra nếu có số lượng thì không được xóa
                if (!Commons.Modules.ObjSystems.IsnullorEmpty(grvSchedule.GetFocusedRowCellValue("ActualQuantity")))
                {
                    Modules.msgChung(ThongBao.msgDaTonTai);
                    return;
                }
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groPrOSchedule.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.ProSchedule WHERE ScheduleID = '" + (grvSchedule.GetFocusedRowCellValue("ScheduleID") + "'"));
                grvSchedule.DeleteSelectedRows();
                //set lại số lượng của điều độ
                try
                {
                    double sldd = Convert.ToDouble(Commons.Modules.ObjSystems.ConvertDatatable(grvSchedule).AsEnumerable().Sum(x => x.Field<Decimal>("PlannedQuantity")));
                    grvPrODetails.SetFocusedRowCellValue("ModerQuantity", sldd);
                }
                catch
                {
                    grvPrODetails.SetFocusedRowCellValue("ModerQuantity", 0);
                }

            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
                //XtraMessageBox.Show(MethodBase.GetCurrentMethod().Name + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event lưới grvPrODetails
        private void grvPrODetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            try
            {
                DataTable dt = new DataTable();
                if (e.Column.Name == "colItemID")
                {
                    //khi change Item thì đổi tên với đơn vị tính với tên mặc hàng lấy từ item
                    dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT TOP 1 CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN ItemName WHEN 1 THEN ISNULL(NULLIF(ItemNameA,''),ItemName) ELSE ISNULL(NULLIF(ItemNameH,''),ItemName) END AS ItemName,B.UOMID FROM dbo.Item A INNER JOIN dbo.UOMConversionGroupDetails B ON B.ID = A.UOM WHERE A.ID = " + e.Value + " "));
                    view.SetFocusedRowCellValue(view.Columns["UOMID"], Convert.ToInt64(dt.Rows[0]["UOMID"]));
                    view.SetFocusedRowCellValue(view.Columns["ItemName"], dt.Rows[0]["ItemName"]);
                    //DetailsID, PrOID
                }
            }
            catch
            {
                view.SetFocusedRowCellValue(view.Columns["UOMID"], null);
                view.SetFocusedRowCellValue(view.Columns["ItemName"], "");

            }
        }
        private void grvPrODetails_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            grvPrODetails.ClearColumnErrors();
            GridView view = sender as GridView;
            if (view == null) return;
            if (view.FocusedColumn.Name == "colItemID")
            {
                DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grdPrODetails);
                if (dt.AsEnumerable().Count(x => x.Field<Int64>("ItemID").Equals(e.Value) && x.Field<Int64>("DetailsID") != Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("DetailsID"))) > 0)
                {
                    e.Valid = false;
                    e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "erTrungDuLieu");
                    view.SetColumnError(view.Columns["ItemID"], e.ErrorText);
                    return;
                }
                view.SetFocusedRowCellValue(view.Columns["ItemID"], e.Value);
            }
            //if (view.FocusedColumn.Name == "colPlannedStartTime")
            //{
            //    if (Convert.ToDateTime(e.Value) > Convert.ToDateTime(view.GetFocusedRowCellValue("DueDate")))
            //    {
            //        e.Valid = false;
            //        e.ErrorText = "This value is not valid";
            //        view.SetColumnError(view.Columns["DueTime"], e.ErrorText);

            //        return;
            //    }
            //}
            //if (view.FocusedColumn.Name == "colDueDate")
            //{
            //    if (Convert.ToDateTime(e.Value) < Convert.ToDateTime(view.GetFocusedRowCellValue("DueDate")))
            //    {
            //        e.Valid = false;
            //        e.ErrorText = "This value is not valid";
            //        view.SetColumnError(view.Columns["EndTime"], e.ErrorText);
            //        return;
            //    }
            //}
        }
        private void grvPrODetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            DevExpress.XtraGrid.Columns.GridColumn sMaMay = View.Columns["ItemID"];
            if (View.GetRowCellValue(e.RowHandle, sMaMay).ToString() == "")
            {
                e.Valid = false;
                View.SetColumnError(sMaMay, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtraItemNULL", Commons.Modules.TypeLanguage)); return;

            }
            DevExpress.XtraGrid.Columns.GridColumn colQUa = View.Columns["PlannedQuantity"];
            if (Commons.Modules.ObjSystems.IsnullorEmpty(View.GetRowCellValue(e.RowHandle, colQUa)))
            {
                e.Valid = false;
                View.SetColumnError(colQUa, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgSoLuongLonHonKhong", Commons.Modules.TypeLanguage)); return;
            }

        }
        private void grvPrODetails_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate())
                {
                    grvPrODetails.DeleteSelectedRows();
                    return;
                }

                Validate();
                GridView view = sender as GridView;
                view.SetFocusedRowCellValue(view.Columns["PROID"], Convert.ToInt64(grvProDuctOD.GetFocusedRowCellValue("ID")));
                view.SetFocusedRowCellValue(view.Columns["DueDate"], datNgayBD.DateTime.AddDays(1).AddMinutes(-1));
                view.SetFocusedRowCellValue(view.Columns["PlannedStartTime"], datNgayBD.DateTime);
                //nếu thêm thì set PrOID  = -1 ngược lại set bằng lưới pro
                if (ithem == -1)
                {
                    view.SetFocusedRowCellValue(view.Columns["PrOID"], -1);
                }
                else
                {
                    view.SetFocusedRowCellValue(view.Columns["PrOID"], grvProDuctOD.GetFocusedRowCellValue("ID"));
                }
            }
            catch
            {
            }
        }
        private void grvPrODetails_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        private void grvPrODetails_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        private void grvPrODetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            if (btnGhi.Visible)
            {
                AddbtProSchedule();
            }
            LoadgrdSchedule();
            if (grvPrODetails.GetFocusedRowCellValue("DetailsID") == null)
            {
                grdSchedule.Enabled = false;
            }
            else
            {
                grdSchedule.Enabled = true;
            }
        }
        private void AddbtProSchedule()
        {
            DataTable tmp = Commons.Modules.ObjSystems.ConvertDatatable(grdSchedule);
            try
            {
                if (tmp.Rows.Count == 0) return;
                if (tbProSchedule.Rows.Count == 0)
                {
                    tbProSchedule = tmp;
                    return;
                }
                else
                {
                    //xóa những dữ liệu với proID có trong bảng hiện tại
                    //lấy những table khác dòng hiện tại 
                    //xong mege dòng hiện tmp hi
                    tbProSchedule = tbProSchedule.AsEnumerable().Where(x => x.Field<Int64>("DetailsID") != Convert.ToInt64(tmp.Rows[0]["DetailsID"])).CopyToDataTable();
                    tbProSchedule.Merge(tmp);
                }
            }
            catch (Exception ex)
            {
                tbProSchedule = tmp;
            }

        }
        #endregion

        #region event lưới grvSchedule
        private decimal TinhKhoiLuong()
        {
            //lấy sl dòng trên trừ tổng số dòng dưới
            decimal resulst = 0;
            decimal khoiLuong = Convert.ToDecimal(grvPrODetails.GetFocusedRowCellValue("PlannedQuantity"));
            DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grdSchedule);
            decimal tong = 0;
            try
            {
                //tong = dt.AsEnumerable().Where(x => x.Field<Int64>("ScheduleID") != Convert.ToInt64(grvSchedule.GetFocusedRowCellValue("ScheduleID").ToString() == "" ? -1 : Convert.ToInt64(grvSchedule.GetFocusedRowCellValue("ScheduleID")))).Sum(x => (decimal)x["PlannedQuantity"]);
                tong = dt.AsEnumerable().Where(x => x.Field<string>("MS_MAY") != grvSchedule.GetFocusedRowCellValue("MS_MAY").ToString()).Sum(x => (decimal)x["PlannedQuantity"]);
            }
            catch
            {

                tong = 0;
            }
            resulst = khoiLuong - tong;
            return resulst < 0 ? 0 : resulst;
        }
        private void grvSchedule_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //thêm defaulst khi add một dòng mới
            try
            {
                GridView view = sender as GridView;
                view.SetFocusedRowCellValue("PlannedStartTime", Convert.ToDateTime(datNgayBD.DateTime));
                view.SetFocusedRowCellValue("DueTime", Convert.ToDateTime(grvPrODetails.GetFocusedRowCellValue("DueDate")));
                view.SetFocusedRowCellValue(view.Columns["DetailsID"], grvPrODetails.GetFocusedRowCellValue("DetailsID"));
                view.SetFocusedRowCellValue("PlannedQuantity", (TinhKhoiLuong()));
                //
                string sDVT = Convert.ToString(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT  [dbo].[fnGetDVTCongSuat](" + Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("ItemID")) + ")"));
                view.SetFocusedRowCellValue(view.Columns["CapacityUOM"], sDVT);
            }
            catch
            {
            }
        }
        private void grvSchedule_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            DevExpress.XtraGrid.Columns.GridColumn sMaMay = View.Columns["MS_MAY"];
            if (View.GetRowCellValue(e.RowHandle, sMaMay).ToString() == "")
            {
                e.Valid = false;
                View.SetColumnError(sMaMay, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtraMayNULL", Commons.Modules.TypeLanguage)); return;
            }
            //kiểm tra không cùng item mấy trong một ngày
            int icheck = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr,CommandType.Text, "SELECT COUNT(*) FROM dbo.PrODetails A INNER JOIN dbo.ProSchedule B ON B.DetailsID = A.DetailsID WHERE B.MS_MAY = '"+ View.GetRowCellValue(e.RowHandle, "MS_MAY") + "' AND CONVERT(DATE,B.PlannedStartTime) = '"+ Convert.ToDateTime(View.GetRowCellValue(e.RowHandle, "PlannedStartTime")).ToString("MM/dd/yyyy") + "' AND A.ItemID = "+ Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("ItemID")) + ""));
            if (icheck > 0 && ithem == -1 )
            {
                e.Valid = false;
                View.SetColumnError(View.Columns["MS_MAY"], Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgMayDaDuocPB", Commons.Modules.TypeLanguage)); return;
            }

            //kiểm tra xem số lượng phân bổ có đủ để xản xuất trong thời gian không
            int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spKiemTraSanLuong", View.GetRowCellValue(e.RowHandle, "MS_MAY"), Convert.ToDateTime(View.GetRowCellValue(e.RowHandle, "PlannedStartTime")), Convert.ToDateTime(View.GetRowCellValue(e.RowHandle, "DueTime")), View.GetRowCellValue(e.RowHandle, "PlannedQuantity"), View.GetRowCellValue(e.RowHandle, "StandardOutput")));
            if (n < 0)
            {
                e.Valid = false;
                View.SetColumnError(View.Columns["PlannedQuantity"], Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgPhanBoQuaTGSX", Commons.Modules.TypeLanguage)); return;
            }

            //@MS_MAY NVARCHAR(30),  
            //@TuNgay DATETIME,
            //@DenNgay DATETIME,
            //@Pland DECIMAL(18,2),
            //@Standard DECIMAL(18,2)

            //DevExpress.XtraGrid.Columns.GridColumn colQUa = View.Columns["PlannedQuantity"];
            //if (Commons.Modules.ObjSystems.IsnullorEmpty(View.GetRowCellValue(e.RowHandle, colQUa)))
            //{
            //    e.Valid = false;
            //    View.SetColumnError(colQUa, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgSoLuongLonHonKhong", Commons.Modules.TypeLanguage)); return;
            //}
            //DevExpress.XtraGrid.Columns.GridColumn colTN = View.Columns["PlannedStartTime"];
            //DevExpress.XtraGrid.Columns.GridColumn colDN = View.Columns["DueTime"];
            //lấy bản tạm hiện tại mege với lưới hiện t
            //DataTable dt = new DataTable();
            //try
            //{
            //    dt = tbProSchedule.Copy().AsEnumerable().Where(x => x.Field<Int64>("DetailsID") != Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("DetailsID"))).CopyToDataTable();
            //    dt.Merge(Commons.Modules.ObjSystems.ConvertDatatable(grvSchedule));
            //}
            //catch
            //{
            //    dt = Commons.Modules.ObjSystems.ConvertDatatable(grvSchedule);
            //}
            //tạo bảo tạm
            //Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "TMPKTTG" + Commons.Modules.UserName, dt, "");
            //kiểm tra ngày của dòng hiện tại hợp lệ
            //try
            //{
            //    int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spKiemTraGioHopLe", Convert.ToDateTime(View.GetRowCellValue(e.RowHandle,"PlannedStartTime")), Convert.ToDateTime(View.GetRowCellValue(e.RowHandle, "PlannedStartTime")), View.GetRowCellValue(e.RowHandle, "MS_MAY"), Convert.ToInt64(View.GetRowCellValue(e.RowHandle, "ScheduleID")), "TMPKTTG" + Commons.Modules.UserName));
            //    if (n > 0)
            //    {
            //        e.Valid = false;
            //        View.SetColumnError(colTN, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgNgayDaTonTaiTrongKhoang", Commons.Modules.TypeLanguage));
            //        View.SetColumnError(colDN, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgNgayDaTonTaiTrongKhoang", Commons.Modules.TypeLanguage));
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //}

        }
        private void grvSchedule_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            grvSchedule.ClearColumnErrors();
            try
            {
                DataTable dt = new DataTable();
                GridView view = sender as GridView;
                DevExpress.XtraGrid.Columns.GridColumn clMaMay = view.Columns["MS_MAY"];
                if (view == null) return;
                if (view.FocusedColumn.Name == "colMS_TO")
                {
                    view.SetFocusedRowCellValue("MS_TO", e.Value);
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
                        dt = Commons.Modules.ObjSystems.ConvertDatatable(grdSchedule);
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
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT StandardOutput,MS_DV_TG_Output,StandardSpeed,MS_DV_TG_Speed,DownTimeRecord,WorkingCycle,NumberPerCyle, (SELECT MS_HE_THONG FROM dbo.MAY_HE_THONG WHERE MS_MAY ='" + e.Value + "') AS MS_HE_THONG FROM dbo.ItemMay WHERE ItemID = " + Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("ItemID")) + " AND MS_MAY = '" + e.Value + "'"));
                        view.SetFocusedRowCellValue("StandardOutput", dt.Rows[0]["StandardOutput"]);
                        view.SetFocusedRowCellValue("MS_DV_TG_Output", dt.Rows[0]["MS_DV_TG_Output"]);
                        view.SetFocusedRowCellValue("StandardSpeed", dt.Rows[0]["StandardSpeed"]);
                        view.SetFocusedRowCellValue("MS_DV_TG_Speed", dt.Rows[0]["MS_DV_TG_Speed"]);
                        view.SetFocusedRowCellValue("DownTimeRecord", dt.Rows[0]["DownTimeRecord"]);
                        view.SetFocusedRowCellValue("UOMID", Convert.ToInt64(grvPrODetails.GetFocusedRowCellValue("UOMID")));
                        grvSchedule.SetFocusedRowCellValue("NumberPerCycle", dt.Rows[0]["NumberPerCyle"]);
                        view.SetFocusedRowCellValue("WorkingCycle", dt.Rows[0]["WorkingCycle"]);
                        view.SetFocusedRowCellValue("MS_HE_THONG", dt.Rows[0]["MS_HE_THONG"]);
                        view.SetFocusedRowCellValue("MS_MAY", e.Value);
                    }
                }
                if (view.FocusedColumn.Name == "colPlannedQuantity")
                {
                    try
                    {

                        if (Convert.ToDecimal(e.Value) > TinhKhoiLuong())
                        {
                            e.Valid = false;
                            e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "erKhongLuongVuotQua");
                            view.SetColumnError(view.Columns["PlannedQuantity"], e.ErrorText);
                            return;
                        }
                    }
                    catch
                    {
                        view.SetFocusedRowCellValue("PlannedQuantity", 0.00);
                    }

                }


                //view.Columns["UOMID"].OptionsColumn.ReadOnly = true;
                //view.Columns["MS_DV_TG_Output"].OptionsColumn.ReadOnly = true;
                //view.Columns["MS_DV_TG_Speed"].OptionsColumn.ReadOnly = true;

                //if (view.FocusedColumn.Name == "colPlannedStartTime")
                //{
                //    //Kiểm tra từ ngày không lớn hơn đến ngày
                //    if (DateTime.Compare(Convert.ToDateTime(e.Value), Convert.ToDateTime(view.GetFocusedRowCellValue("DueTime"))) != -1)
                //    {
                //        e.Valid = false;
                //        e.ErrorText = "This value is not valid";
                //        view.SetColumnError(view.Columns["PlannedStartTime"], e.ErrorText);
                //        return;
                //    }
                //}

                //kiểm tra ngày kết thúc không lớn hơn ngày mặt định

                if (view.FocusedColumn.Name == "colDueTime")
                {
                    //Kiểm tra từ ngày không lớn hơn đến ngày
                    if (DateTime.Compare(Convert.ToDateTime(e.Value), datNgayBD.DateTime.AddDays(1).AddSeconds(-1)) == 1)
                    {
                        e.Valid = false;
                        e.ErrorText = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKhongDuocQuaNgay", Commons.Modules.TypeLanguage);
                        view.SetColumnError(view.Columns["DueTime"], e.ErrorText);
                        return;
                    }

                }
                if (view.FocusedColumn.Name == "colWorkingCycle")
                {
                    view.SetFocusedRowCellValue(view.Columns["WorkingCycle"], e.Value);
                    view.SetFocusedRowCellValue(view.Columns["StandardOutput"], 3600 / (Convert.ToDecimal((e.Value))) * Convert.ToDecimal(grvSchedule.GetFocusedRowCellValue("NumberPerCycle")));
                }
                if (view.FocusedColumn.Name == "colNumberPerCycle")
                {
                    view.SetFocusedRowCellValue(view.Columns["NumberPerCycle"], e.Value);
                    view.SetFocusedRowCellValue(view.Columns["StandardOutput"], 3600 / Convert.ToDecimal(view.GetFocusedRowCellValue("WorkingCycle")) * Convert.ToDecimal(e.Value));
                }
            }
            catch { }


        }
        #endregion

        private void datTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            LoadgrdProDuctOrDer(-1);
        }

        private void grdSchedule_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteDataSchedule();
            }
        }

        private void grdPrODetails_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteDataDetail();
            }
            if(e.KeyData == Keys.F5 && btnGhi.Visible == false)
            {
                Cursor.Current = Cursors.WaitCursor;
                LoadgrdPrODetails();
                Cursor.Current = Cursors.Default;
            }
        }

        private void grdProDuctOD_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && btnGhi.Visible == false)
            {
                DeleteData();
            }
        }

        private void btnLayMay_Click(object sender, EventArgs e)
        {
            //kiểm tra có Item Chưa

            if (Commons.Modules.ObjSystems.IsnullorEmpty(grvPrODetails.GetFocusedRowCellValue("ItemID")))
            {
                Modules.msgThayThe(ThongBao.msgBanChuaChonDuLieu, Commons.Modules.ObjLanguages.GetLanguage(this.Name, "ItemName"));
                return;
            }
            //lấy dữ liệu của schule hiện tại add vào những máy từ Item máy
            DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grvSchedule);
            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "tabTMP" + Commons.Modules.UserName, dt, "");
            string sSql = " SELECT ScheduleID,PrOID,DetailsID,MS_TO,MS_HE_THONG,MS_MAY,CaID,CaIDKT,CONVERT(DECIMAL(18,2),PlannedQuantity) AS PlannedQuantity,UOMID,PlannedStartTime,DueTime,CONVERT(DECIMAL(18,2),ActualQuantity) AS ActualQuantity,CONVERT(DECIMAL(18,2),StandardOutput) AS StandardOutput,MS_DV_TG_Output,CONVERT(DECIMAL(18,2),StandardSpeed) AS  StandardSpeed,MS_DV_TG_Speed,WorkingCycle,CONVERT(DECIMAL(18,2),NumberPerCycle) AS NumberPerCycle,CONVERT(DECIMAL(18,2),DownTimeRecord) AS  DownTimeRecord,CONVERT(DECIMAL(18,2),SumStandardOutput) AS SumStandardOutput,CapacityUOM,BOMVersion,SoCaSX FROM " + "tabTMP" + Commons.Modules.UserName + " UNION SELECT ScheduleID, NULL AS PrOID, " + grvPrODetails.GetFocusedRowCellValue("DetailsID") + " AS DetailsID ,MS_TO,(SELECT TOP 1 MS_HE_THONG FROM dbo.MAY_HE_THONG WHERE MS_MAY =MS_MAY) as MS_HE_THONG,A.MS_MAY,CaID,CaIDKT,CONVERT(DECIMAL(18,2),0) as PlannedQuantity," + grvPrODetails.GetFocusedRowCellValue("UOMID") + " as UOMID,CONVERT(DATETIME, GETDATE()) PlannedStartTime,DATEADD(HOUR, 8, CONVERT(DATETIME, GETDATE())) DueTime,NULL as ActualQuantity,A.StandardOutput,A.MS_DV_TG_Output,A.StandardSpeed,A.MS_DV_TG_Speed,A.WorkingCycle,CONVERT(DECIMAL(18,2),NumberPerCycle) AS NumberPerCycle,CONVERT(DECIMAL(18,2),A.DownTimeRecord) AS DownTimeRecord,CONVERT(DECIMAL(18,2),SumStandardOutput) AS SumStandardOutput, [dbo].[fnGetDVTCongSuat](A.ItemID)AS CapacityUOM,BOMVersion,SoCaSX FROM dbo.ItemMay A LEFT JOIN  dbo." + "tabTMP" + Commons.Modules.UserName + " B ON A.MS_MAY = B.MS_MAY WHERE A.ItemID = " + grvPrODetails.GetFocusedRowCellValue("ItemID") + " AND NOT EXISTS(SELECT * FROM " + "tabTMP" + Commons.Modules.UserName + " C WHERE A.MS_MAY = C.MS_MAY)  ORDER BY PlannedQuantity DESC ";
            dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
            dt.Columns["PlannedQuantity"].ReadOnly = false;
            grdSchedule.DataSource = dt;
            Commons.Modules.ObjSystems.XoaTable("tabTMP" + Commons.Modules.UserName);
        }

        private void grvPrODetails_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column != view.Columns["PlannedQuantity"])
                return;
            e.Appearance.BackColor = Color.FromArgb(255, 227, 238);
            e.Appearance.ForeColor = Color.Black;
        }

        private void grvSchedule_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column != view.Columns["PlannedQuantity"])
                return;
            e.Appearance.BackColor = Color.FromArgb(204, 236, 255);
            e.Appearance.ForeColor = Color.Black;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //show form import
            frmImport frm = new frmImport();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadgrdProDuctOrDer(-1);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr;
                dr = XtraMessageBox.Show("Bạn muốn export template?", "Thông báo",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;
                //exprort mẫu templete
                string sPath = "";
                sPath = "";
                //sPath = Commons.Modules.MExcel.SaveFiles("Excel Files (*.xlsx;)|*.xlsx;|" + "All Files (*.*)|*.*");
                sPath = Commons.Modules.MExcel.SaveFiles("Excel Files (*.xls;)|*.xls;|Excel Files (*.Xlsx;)|*.Xlsx;|" + "All Files (*.*)|*.*");
                if (sPath == "") return;
                Workbook book = new Workbook();
                Worksheet sheet = book.Worksheets[0];
                DataTable dtTmp = new DataTable();
                //string sSql = "SELECT TOP 10 PrOrNumber AS PO,C.MS_MAY AS 'Máy',B.ItemID AS 'Mã sản phẩm',C.BOMVersion AS 'BOM Version',C.PlannedQuantity AS 'SL Kế Hoạch',C.SoCaSX AS 'Số ca sản xuất',C.PlannedStartTime AS 'Thời gian bắt đầu ',D.CA AS 'Ca bắt đầu',C.DueTime AS 'Thời gian kết thúc',D.CA AS 'Ca kết thúc 'FROM dbo.ProductionOrder A INNER JOIN  dbo.PrODetails B ON B.PrOID = A.ID INNER JOIN dbo.ProSchedule C ON C.DetailsID = B.DetailsID INNER JOIN dbo.CA D ON C.CaID = D.STT";

                string sSql = "SELECT TOP 0 B.MS_MAY AS 'MS Máy',A.ItemCode AS	 'Mã sản phẩm',B.PlannedQuantity AS 'SL Kế hoạch' ,B.PlannedStartTime AS 'Ngày' FROM dbo.Item A INNER JOIN dbo.ProSchedule B ON A.ID = B.ScheduleID";

                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                //export datatable to excel
                sheet.DefaultColumnWidth = 20;
                sheet.Range[1, 1, dtTmp.Rows.Count + 1, dtTmp.Columns.Count].Style.WrapText = true;
                sheet.Range[1, 1, 1, dtTmp.Columns.Count].Style.VerticalAlignment = VerticalAlignType.Center;
                sheet.Range[1, 1, 1, dtTmp.Columns.Count].Style.HorizontalAlignment = HorizontalAlignType.Center;

                //sheet.Range[1,2,1,2].Style.Font.Color = Color.Red;
                //sheet.Range[1, 3, 1, 3].Style.Font.Color = Color.Red;
                //sheet.Range[1, 5, 1, 5].Style.Font.Color = Color.Red;
                //sheet.Range[1, 7, 1, 7].Style.Font.Color = Color.Red;
                //sheet.Range[1, 9, 1, 9].Style.Font.Color = Color.Red;


                sheet.Range[1, 1, 1, dtTmp.Columns.Count].Style.Font.IsBold = true;
                sheet.InsertDataTable(dtTmp, true, 1, 1);
                book.SaveToFile(sPath);
                System.Diagnostics.Process.Start(sPath);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName,
                      "ucTongHopTinhHinhBaoTri", "XuatExcelKhongThanhCong", Commons.Modules.TypeLanguage) + "\n" +
                      ex.Message);
            }
        }


        private void datNgayLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ithem == -1)
                    txtSoLSX.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT dbo.AUTO_CREATE_SO_KHSX('" + datNgayLap.DateTime.ToString("yyyy-MM-dd") + "')").ToString();
            }
            catch { }
        }

        private void grvPrODetails_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (grvSchedule.HasColumnErrors == true)
                e.Allow = false;
        }
    }
}