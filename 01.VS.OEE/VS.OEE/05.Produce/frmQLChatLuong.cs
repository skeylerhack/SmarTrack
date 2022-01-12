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
using System.IO;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;

namespace VS.OEE
{
    public partial class frmQLChatLuong : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        Int64 ithem = 0;
        public frmQLChatLuong(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
        }

        #region eventForm
        private void frmQLChatLuong_Load(object sender, EventArgs e)
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
        
            Commons.Modules.sId = "0Load";

            LoadCbo();
            LoadgrdQCData(-1);
            LoadgrdQCDataDetails();
            LoadgrdQCDataDefect();
            Commons.Modules.sId = "";
            grvQCData_FocusedRowChanged(grvQCData, null);

            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            ithem = -1;
            VisibleButon(false);
            BingdingControl(true);
            LoadgrdQCData(-1);
            Commons.Modules.sId = "";
          
            txtDocNum.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT dbo.AUTO_CREATE_SO_SLHL(GETDATE())").ToString();
         
            RowFilter(grdQCDataDetails, grvQCDataDetails.Columns["ID_QC"], -1);
            RowFilter(grdQCDataDefect, grvQCDataDefect.Columns["ID_TEMP"], -1);
            Commons.Modules.ObjSystems.AddnewRow(grvQCDataDefect, true);

            EnableGridControl();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvQCData.GetFocusedRowCellValue("ID") == null)
            {
                return;
            }
            ithem = Convert.ToInt64(grvQCData.GetFocusedRowCellValue("ID"));
            VisibleButon(false);
            Commons.Modules.ObjSystems.AddnewRow(grvQCDataDefect, true);

            EnableGridControl();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnThem.Visible = btnXoa.Visible = btnSua.Visible = btnThoat.Visible = false;
            btnDelQCDefect.Visible = btnDelQCData.Visible = btnDelQCDetails.Visible = btnTroVe.Visible = true;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                if (!KiemTrung()) return;
                if (!Kiem_DefeactQuanity()) return;

                string sBTQCDataDetails = "TMPQCDataDetails" + Commons.Modules.UserName;
                string sBTQCDataDefect = "TMPQCDataDefect" + Commons.Modules.UserName;

                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTQCDataDetails, Commons.Modules.ObjSystems.ConvertDatatable(grdQCDataDetails), "");
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTQCDataDefect, Commons.Modules.ObjSystems.ConvertDatatable(grdQCDataDefect), "");

                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spEditQCData", conn);
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ithem;
                cmd.Parameters.Add("@DocNum", SqlDbType.NVarChar).Value = txtDocNum.Text;
                cmd.Parameters.Add("@QCName", SqlDbType.NVarChar).Value = txtQCName.Text;
                cmd.Parameters.Add("@QCDate", SqlDbType.DateTime).Value = datQCDate.DateTime;
                cmd.Parameters.Add("@ProductionDate", SqlDbType.DateTime).Value = datProductionDate.DateTime;
                cmd.Parameters.Add("@CheckStepID", SqlDbType.BigInt).Value = cboCheckStepID.EditValue;
                cmd.Parameters.Add("@ID_CA", SqlDbType.BigInt).Value = cboID_CA.EditValue;
                cmd.Parameters.Add("@sBTQCDataDetails", SqlDbType.NVarChar).Value = sBTQCDataDetails;
                cmd.Parameters.Add("@sBTQCDataDefect", SqlDbType.NVarChar).Value = sBTQCDataDefect;
                cmd.CommandType = CommandType.StoredProcedure;

                Int64 temp = Convert.ToInt64(cmd.ExecuteScalar());
                if (temp > 0)
                {
                    ithem = temp;
                    LoadgrdQCData(temp);
                    LoadgrdQCDataDetails();
                    LoadgrdQCDataDefect();
                    grvQCData_FocusedRowChanged(grvQCData, null);
                }

                if (conn.State == ConnectionState.Open)
                    conn.Close();

                VisibleButon(true);
                Commons.Modules.ObjSystems.DeleteAddRow(grvQCDataDefect);
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.DeleteAddRow(grvQCDataDefect);
            VisibleButon(true);
            ithem = Convert.ToInt64(grvQCData.GetFocusedRowCellValue("ID"));
            LoadgrdQCData(ithem);
            LoadgrdQCDataDetails();
            LoadgrdQCDataDefect();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            btnThem.Visible = btnXoa.Visible = btnSua.Visible = btnThoat.Visible = true;
            btnDelQCDefect.Visible = btnDelQCData.Visible = btnDelQCDetails.Visible = btnTroVe.Visible = false;
        }
        private void btnDelQCData_Click(object sender, EventArgs e)
        {
            DeleteDataQCData();
        }
        private void btnDelQCDataDetails_Click(object sender, EventArgs e)
        {
            DeleteDataQCDataDetails();
        }
        private void btnDelQCDataDefect_Click(object sender, EventArgs e)
        {
            DeleteDataQCDataDefect();
        }
        private void btnChonQCDataDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboID_CA.EditValue == null || Convert.ToInt32(cboID_CA.EditValue) < 1)
                {
                    XtraMessageBox.Show(lblID_CA.Text.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrong"));
                    return;
                }
                if (datProductionDate.Text == "")
                {
                    XtraMessageBox.Show(lblProductionDate.Text.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrong"));
                    return;
                }

                DataTable dt_temp = new DataTable();
                dt_temp = ((DataTable)grdQCDataDetails.DataSource).DefaultView.ToTable();
                frmChooseQCDataDetails frm = new frmChooseQCDataDetails(Convert.ToInt32(cboID_CA.EditValue), datProductionDate.DateTime, dt_temp);

                if (frm.ShowDialog() != DialogResult.OK) return;

                DataTable dt_chon = new DataTable();
                DataTable dt_kchon = new DataTable();

                try { dt_chon = frm._dt.AsEnumerable().Where(x => x["CHON"].Equals(true)).CopyToDataTable(); } catch { dt_chon = frm._dt.Clone(); }
                try { dt_kchon = frm._dt.AsEnumerable().Where(x => x["CHON"].Equals(false)).CopyToDataTable(); } catch { dt_kchon = frm._dt.Clone(); }


                DataTable dt_Details = new DataTable();
                dt_Details = (DataTable)grdQCDataDetails.DataSource;

                if (dt_temp.Rows.Count > 0)
                {
                    try
                    {

                        dt_Details = dt_Details.AsEnumerable().Where(row => !dt_kchon.AsEnumerable().Select(r => string.Concat(r.Field<Int64>("PrOID"), ";", r.Field<Int64>("ItemID"), ";", r.Field<string>("MS_MAY"), ";", ithem))
                                            .Any(x => x == string.Concat(row.Field<Int64>("PrOID"), ";", row.Field<Int64>("ItemID"), ";", row.Field<string>("MS_MAY"), ";", row.Field<Int64>("ID_QC")))).CopyToDataTable();


                    }
                    catch
                    {
                        dt_Details = dt_Details.Clone();
                    }
                }

                if (dt_chon == null || dt_chon.Rows.Count == 0)
                    dt_chon = dt_chon.Clone();
                else
                {
                    try
                    {
                        dt_chon = dt_chon.AsEnumerable().Where(row => !dt_Details.AsEnumerable()
                                                                .Select(r => string.Concat(r.Field<Int64>("PrOID"), ";", r.Field<Int64>("ItemID"), ";", r.Field<string>("MS_MAY"), ";", r.Field<Int64>("ID_QC")))
                                                                .Any(x => x == string.Concat(row.Field<Int64>("PrOID"), ";", row.Field<Int64>("ItemID"), ";", row.Field<string>("MS_MAY"), ";", ithem))).Where(x => x["CHON"].Equals(true)).CopyToDataTable();
                    }
                    catch { dt_chon = dt_chon.Clone(); }
                }


                int max = 0;
                try
                {
                    DataTable dt_max = new DataTable();
                    dt_max = (DataTable)grdQCDataDetails.DataSource;
                    for (int i = 0; i < dt_max.Rows.Count; i++)
                    {
                        if (Convert.ToInt16(string.IsNullOrEmpty(dt_max.Rows[i]["ID_TEMP"].ToString()) ? "-1" : dt_max.Rows[i]["ID_TEMP"].ToString()) > max)
                            max = Convert.ToInt16(string.IsNullOrEmpty(dt_max.Rows[i]["ID_TEMP"].ToString()) ? "-1" : dt_max.Rows[i]["ID_TEMP"].ToString());
                    }
                }
                catch { }

                if (dt_chon.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_chon.Rows.Count; i++)
                    {
                        DataRow r = dt_Details.NewRow();
                        r["ID"] = -1;
                        r["ID_QC"] = ithem;
                        r["PrOID"] = dt_chon.Rows[i]["PrOID"];
                        r["PrOrNumber"] = dt_chon.Rows[i]["PrOrNumber"];
                        r["ItemID"] = dt_chon.Rows[i]["ItemID"];
                        r["ItemCode"] = dt_chon.Rows[i]["ItemCode"];
                        r["ItemName"] = dt_chon.Rows[i]["ItemName"];
                        r["MS_MAY"] = dt_chon.Rows[i]["MS_MAY"];
                        r["CheckQuantity"] = dt_chon.Rows[i]["CheckQuantity"];
                        r["ID_TEMP"] = max + 1; max++;
                        dt_Details.Rows.Add(r);
                        dt_Details.AcceptChanges();
                    }
                }

                grdQCDataDetails.DataSource = dt_Details;
                RowFilter(grdQCDataDetails, grvQCDataDetails.Columns["ID_QC"], ithem);

                if (grvQCDataDetails.RowCount > 0 && (btnChonQCDataDetails.Visible == true || btnGhi.Visible == true || btnKhong.Visible == true))
                {
                    cboID_CA.ReadOnly = true;
                    datProductionDate.ReadOnly = true;
                }
            }
            catch { }
        }
        #endregion

        #region function 
        private void VisibleButon(bool flag)
        {
            btnThem.Visible = flag;
            btnThoat.Visible = flag;
            btnXoa.Visible = flag;
            btnSua.Visible = flag;
     
            btnGhi.Visible = !flag;
            btnKhong.Visible = !flag;
            ReadonlyControl(flag);
        }
        private void LoadgrdQCData(Int64 id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetQCData", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                if (grdQCData.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdQCData, grvQCData, dt, false, true, false, false, true, this.Name);

                    //Editable
                    grvQCData.OptionsBehavior.Editable = false;

                    //Format
                    grvQCData.Columns["DocNum"].Fixed = FixedStyle.Left;

                    //Visible
                    grvQCData.Columns["ID"].Visible = false;
                    grvQCData.Columns["QCDate"].Visible = false;
                    grvQCData.Columns["CheckStepID"].Visible = false;
                    grvQCData.Columns["ID_CA"].Visible = false;
                    grvQCData.Columns["ProductionDate"].Visible = false;
                }
                else
                    grdQCData.DataSource = dt;

                if (id != -1)
                {
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvQCData.FocusedRowHandle = grvQCData.GetRowHandle(index);
                }
                else { }
                if (grvQCData.FocusedRowHandle < 1)
                {
                    grvQCData_FocusedRowChanged(null, null);
                }
            }
            catch
            {
            }
        }
        private void LoadgrdQCDataDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetQCDataDetails", Commons.Modules.UserName, Commons.Modules.TypeLanguage));

                if (grdQCDataDetails.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdQCDataDetails, grvQCDataDetails, dt, false, true, false, false, true, this.Name);

                    //Editable
                    for (int i = 0; i <grvQCDataDetails.Columns.Count; i++)
                    {
                        grvQCDataDetails.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                    grvQCDataDetails.Columns["CheckQuantity"].OptionsColumn.AllowEdit = true;
                    grvQCDataDetails.Columns["Note"].OptionsColumn.AllowEdit = true;

                    //Visible
                    grvQCDataDetails.Columns["ID_TEMP"].Visible = false;
                    grvQCDataDetails.Columns["ID_QC"].Visible = false;
                    grvQCDataDetails.Columns["ID"].Visible = false;
                    grvQCDataDetails.Columns["PrOID"].Visible = false;
                    grvQCDataDetails.Columns["ItemID"].Visible = false;

                    //Format
                    grvQCDataDetails.Columns["CheckQuantity"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvQCDataDetails.Columns["CheckQuantity"].DisplayFormat.FormatString = Commons.Modules.sSoLeSL;
                }
                else
                    grdQCDataDetails.DataSource = dt;
            
                if (grvQCDataDetails.FocusedRowHandle < 1)
                {
                    grvQCDataDetails_FocusedRowChanged(null, null);
                }
            }
            catch  {}
        }
        private void LoadcboQCDataDefect()
        {
            try
            {
                if (grdQCDataDefect.DataSource == null) return;

                DataTable dt = new DataTable();
                string sql = "SELECT ID, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN DefectName WHEN 1 THEN ISNULL(NULLIF(DefectName_E, ''), DefectName) ELSE ISNULL(NULLIF(DefectName_C, ''), DefectName) END AS DefectName FROM  dbo.Defect ORDER BY THU_TU";
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sql));

                Commons.Modules.ObjSystems.AddCombXtra("ID", "DefectName", "ID_Defect", grvQCDataDefect, dt, false, this.Name);
            }
            catch { }
        }
        private void LoadgrdQCDataDefect()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetQCDataDefect", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                dt.Columns["ID_TEMP"].ReadOnly = false;
                if (grdQCDataDefect.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdQCDataDefect, grvQCDataDefect, dt, false, true, false, false, true, this.Name);

                    //Editable
                    for (int i = 0; i < grvQCDataDefect.Columns.Count; i++)
                    {
                        grvQCDataDefect.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                    grvQCDataDefect.Columns["ID_Defect"].OptionsColumn.AllowEdit = true;
                    grvQCDataDefect.Columns["DefeactQuanity"].OptionsColumn.AllowEdit = true;
                    grvQCDataDefect.Columns["Note"].OptionsColumn.AllowEdit = true;

                    //Visible
                    grvQCDataDefect.Columns["QCDataDetailsID"].Visible = false;
                    grvQCDataDefect.Columns["ID_TEMP"].Visible = false;

                    //Format
                    grvQCDataDefect.Columns["DefeactQuanity"].DisplayFormat.FormatType = FormatType.Numeric;
                    grvQCDataDefect.Columns["DefeactQuanity"].DisplayFormat.FormatString = Commons.Modules.sSoLeSL;

                    LoadcboQCDataDefect();
                }
                else
                    grdQCDataDefect.DataSource = dt;
            }
            catch
            {

            }
        }
        private void DeleteDataQCData()
        {
            if (grvQCData.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvQCData.GetFocusedRowCellValue("ID").ToString()); } catch { }
            try
            {
                if (iId == -1)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                    return;
                }
                else
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groQCData.Text) == DialogResult.No) return;

                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.QCDataDefect WHERE QCDataDetailsID IN (SELECT ID FROM dbo.QCDataDetails WHERE ID_QC = " + iId + ") DELETE dbo.QCDataDetails WHERE ID_QC = " + iId + " DELETE dbo.QCData WHERE ID =  " + iId);
                grvQCData.DeleteSelectedRows();
                ((DataTable)grdQCData.DataSource).AcceptChanges();
                LoadgrdQCDataDetails();
                LoadgrdQCDataDefect();
                grvQCData_FocusedRowChanged(grvQCData, null);

            }
            
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }
        private void DeleteDataQCDataDetails()
        {
            try
            {
                if (grvQCDataDetails.RowCount == 0) return;
                Int64 iId = -1;
                //kiểm tra proid này đã tồn tại 
                try { iId = Modules.ToInt64(grvQCDataDetails.GetFocusedRowCellValue("ID").ToString()); } catch { }
                if (iId == -1 && btnThem.Visible == true)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                    return;
                }
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groQCDataDetails.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.QCDataDefect WHERE QCDataDetailsID = " + iId + " DELETE dbo.QCDataDetails WHERE ID = " + iId);
                grvQCDataDetails.DeleteSelectedRows();
                ((DataTable)grdQCDataDetails.DataSource).AcceptChanges();
                LoadgrdQCDataDefect();
                 grvQCDataDetails_FocusedRowChanged(grvQCDataDetails, null);
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }
        private void DeleteDataQCDataDefect()
        {
            try
            {
                if (grvQCDataDefect.RowCount == 0) return;
                
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groQCDataDefect.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.QCDataDefect WHERE QCDataDetailsID = " + grvQCDataDefect.GetFocusedRowCellValue("QCDataDetailsID") + " AND ID_Defect = " + grvQCDataDefect.GetFocusedRowCellValue("ID_Defect"));
                grvQCDataDefect.DeleteSelectedRows();
                ((DataTable)grdQCDataDefect.DataSource).AcceptChanges();
                //Tinh_CheckQuanity();
                if (btnGhi.Visible == false || btnKhong.Visible == false || btnChonQCDataDetails.Visible == false)
                    btnGhi_Click(null, null);

            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }
        private void RowFilter(GridControl grid, GridColumn column, Int64 value)
        {
            GridControl _grid = grid;
            GridView _view = grid.MainView as GridView;
            GridColumn _column = column;
            Int64 _value = value;
            DataTable dt = new DataTable();
            dt = (DataTable)_grid.DataSource;

            if (dt == null) return;
            try
            {
                dt.DefaultView.RowFilter = column.FieldName + " = " + value;
                _view.SelectRow(0);
            }
            catch
            {
                dt.DefaultView.RowFilter = "1 = 0";
            }
        }
        private void BingdingControl(bool them)
        {
            if (them == true)
            {
                txtDocNum.ResetText();
                txtQCName.ResetText();
                datQCDate.EditValue = DateTime.Now.Date;
                datProductionDate.EditValue = DateTime.Now.Date;
                cboCheckStepID.EditValue = null;
                cboID_CA.EditValue = null;
            }
            else
            {
                txtDocNum.EditValue = grvQCData.GetFocusedRowCellValue("DocNum");
                txtQCName.EditValue = grvQCData.GetFocusedRowCellValue("QCName");
                datQCDate.EditValue = grvQCData.GetFocusedRowCellValue("QCDate");
                datProductionDate.EditValue = grvQCData.GetFocusedRowCellValue("ProductionDate");
                cboCheckStepID.EditValue = grvQCData.GetFocusedRowCellValue("CheckStepID");
                cboID_CA.EditValue = grvQCData.GetFocusedRowCellValue("ID_CA");
            }
        }
        private void LoadCbo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT STT, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN CA WHEN 1 THEN ISNULL(NULLIF(CA_ANH, '') , CA) ELSE ISNULL(NULLIF(CA_HOA, '') , CA) END AS CA FROM dbo.CA ORDER BY STT"));

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboID_CA, dt, "STT", "CA", "");

                DataTable dt1 = new DataTable();
                dt1.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT ID, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN CheckStepName WHEN 1 THEN ISNULL(NULLIF(CheckStepName_A, '') , CheckStepName) ELSE ISNULL(NULLIF(CheckStepName_H, '') , CheckStepName) END AS CheckStepName FROM dbo.CheckStep ORDER BY ID"));

                Commons.Modules.ObjSystems.MLoadLookUpEdit(cboCheckStepID, dt1, "ID", "CheckStepName", "");
            }
            catch { }
        }
        private bool Kiem_DefeactQuanity()
        {
            try
            {
                DataTable dt_Details = new DataTable();
                try
                {
                    dt_Details = ((DataTable)grdQCDataDetails.DataSource).AsEnumerable().Where(r => r["ID_QC"].Equals(ithem)).CopyToDataTable();
                }
                catch { return true; }

                DataTable dt_Defect = new DataTable();

                for (int i = 0; i < dt_Details.Rows.Count; i++)
                {
                    Int64 ID_TEMP = string.IsNullOrEmpty(dt_Details.Rows[i]["ID_TEMP"].ToString()) ? 0 : Convert.ToInt64(dt_Details.Rows[i]["ID_TEMP"]);

                    if ((string.IsNullOrEmpty(dt_Details.Rows[i]["CheckQuantity"].ToString()) ? 0 : Convert.ToDouble(dt_Details.Rows[i]["CheckQuantity"])) <= 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgSoLuongKiemPhaiLonHon0"));
                        grvQCDataDetails.FocusedRowHandle = grvQCDataDetails.LocateByValue("ID_TEMP", ID_TEMP);
                        grvQCDataDetails.FocusedColumn = grvQCDataDetails.Columns["CheckQuantity"];
                        return false;
                    }

                    double CheckQuantity = string.IsNullOrEmpty(dt_Details.Rows[i]["CheckQuantity"].ToString()) ? 0 : Convert.ToDouble(dt_Details.Rows[i]["CheckQuantity"]);
                    double DefeactQuanity = 0;
                    try
                    {
                        dt_Defect = ((DataTable)grdQCDataDefect.DataSource).AsEnumerable().Where(r => r["ID_TEMP"].Equals(ID_TEMP)).CopyToDataTable();
                        for (int j = 0; j < dt_Defect.Rows.Count; j++)
                        {
                            DefeactQuanity += (string.IsNullOrEmpty(dt_Defect.Rows[j]["DefeactQuanity"].ToString()) ? 0 : Convert.ToDouble(dt_Defect.Rows[j]["DefeactQuanity"]));
                          
                        }
                    }
                    catch 
                    {
                        
                            DefeactQuanity = 0;
                    }

                    if (DefeactQuanity > CheckQuantity)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name,"msgTongSoLuongHangLoiKhongDuocLonHonSoLuongKiem"));
                        grvQCDataDetails.FocusedRowHandle = grvQCDataDetails.LocateByValue("ID_TEMP", ID_TEMP);
                        grvQCDataDetails.FocusedColumn = grvQCDataDetails.Columns["CheckQuantity"];
                        return false;
                    }
                }
            }
            catch  { return false; }
            return true;
        }
        private void ReadonlyControl(bool flag)
        {
            try
            {
                txtDocNum.Properties.ReadOnly = flag;
                txtQCName.Properties.ReadOnly = flag;
                datQCDate.Properties.ReadOnly = flag;
                cboCheckStepID.Properties.ReadOnly = flag;
                grdQCData.Enabled = flag;
                grvQCDataDetails.OptionsBehavior.Editable = !flag;
                grvQCDataDefect.OptionsBehavior.Editable = !flag;
                if (grvQCDataDetails.RowCount > 0 && ithem != -1)
                {
                    cboID_CA.Properties.ReadOnly = true;
                    datProductionDate.Properties.ReadOnly = true;
                }
                else
                {
                    cboID_CA.Properties.ReadOnly = flag;
                    datProductionDate.Properties.ReadOnly = flag;
                    grdQCDataDetails.Enabled = !flag;
                }
            }
            catch { }
        }
        private void EnableGridControl()
        {
            try
            {
                if (grvQCDataDetails.GetFocusedRowCellValue("ID_TEMP") == null)
                    grdQCDataDefect.Enabled = false;
                else
                    grdQCDataDefect.Enabled = true;
            }
            catch { grdQCDataDefect.Enabled = false; }
        }
        private bool KiemTrung()
        {
            int KTrung = 0;
            string sql = "IF EXISTS (SELECT DocNum FROM dbo.QCData WHERE DocNum = '" + txtDocNum.Text + "' AND ID <> " + ithem + ") SELECT 1 ELSE SELECT 0";
            KTrung = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sql));
            if (KTrung == 1)
            {
                if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTrungSoPhieuQC"), this.Name, MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    txtDocNum.EditValue = SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT dbo.AUTO_CREATE_SO_SLHL(GETDATE())").ToString();
                    txtDocNum.Focus();
                }
                txtDocNum.ErrorText = Commons.Modules.ObjLanguages.GetLanguage("frmChung", ThongBao.msgDaTonTai).Replace("msgThayThe", lblDocNum.Text);
                return false;
            }
            return true;
        }

        #endregion

        #region Event lưới 
        private void grvQCData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (Commons.Modules.sId == "0Load") return;
                GridView view = sender as GridView;

                BingdingControl(false);
                RowFilter(grdQCDataDetails, grvQCDataDetails.Columns["ID_QC"], Convert.ToInt64(view.GetFocusedRowCellValue("ID")));
                RowFilter(grdQCDataDefect, grvQCDataDefect.Columns["ID_TEMP"], Convert.ToInt64(grvQCDataDetails.GetFocusedRowCellValue("ID")));
                if (grvQCData.GetFocusedRowCellValue("ID") == null)
                {
                    grdQCDataDetails.Enabled = false;
                }
                else
                {
                    grdQCDataDetails.Enabled = true;
                }
            }
            catch { }
           
        }
        private void grdQCData_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && btnGhi.Visible == false)
            {
                DeleteDataQCData();
            }
        }
        private void grvQCDataDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            GridView view = sender as GridView;
            //LoadgrdTo();
            RowFilter(grdQCDataDefect, grvQCDataDefect.Columns["ID_TEMP"], Convert.ToInt64(view.GetFocusedRowCellValue("ID_TEMP")));
            if (grvQCDataDetails.GetFocusedRowCellValue("ID_TEMP") == null)
            {
                grdQCDataDefect.Enabled = false;
            }
            else
            {
                grdQCDataDefect.Enabled = true;
            }
        }
        private void grvQCDataDetails_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteDataQCDataDetails();

                if (grvQCDataDetails.RowCount == 0 && (btnChonQCDataDetails.Visible == true || btnGhi.Visible == true || btnKhong.Visible == true))
                {
                    cboID_CA.ReadOnly = false;
                    datProductionDate.ReadOnly = false;
                }
            }
        }
        private void grvQCDataDetails_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                GridControl grid = view.GridControl;

                Int64 max = 0;
                DataTable dt = new DataTable();
                dt = (DataTable)grid.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((string.IsNullOrEmpty(dt.Rows[i]["ID_TEMP"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["ID_TEMP"])) > max)
                    {
                        max = (string.IsNullOrEmpty(dt.Rows[i]["ID_TEMP"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["ID_TEMP"]));
                    }
                }

                view.SetFocusedRowCellValue("ID_TEMP", max + 1);
                view.SetFocusedRowCellValue("ID", -1);

                if (view.GetFocusedRowCellValue("ID_TEMP") == null)
                {
                    grdQCDataDefect.Enabled = false;
                }
                else
                {
                    grdQCDataDefect.Enabled = true;
                }
            }
            catch { }
        }
        private void grvQCDataDefect_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                Int64 ID_TEMP = string.IsNullOrEmpty(grvQCDataDetails.GetFocusedRowCellValue("ID_TEMP").ToString()) ? 0 : Convert.ToInt64(grvQCDataDetails.GetFocusedRowCellValue("ID_TEMP"));
                grvQCDataDefect.SetRowCellValue(grvQCDataDefect.FocusedRowHandle,"ID_TEMP", ID_TEMP);
                grvQCDataDefect.SetRowCellValue(grvQCDataDefect.FocusedRowHandle, "QCDataDetailsID", -1);
            }
            catch { }
        }
        private void grdQCDataDefect_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteDataQCDataDefect();
            }
        }
        private void grvQCDataDefect_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                //Kiem trong + Kiem trung
                GridView view = sender as GridView;
                GridControl grid = view.GridControl;
                DataTable dt = new DataTable();
                dt = ((DataTable)grid.DataSource).AsEnumerable().Where(r => r["ID_TEMP"].Equals(grvQCDataDetails.GetFocusedRowCellValue("ID_TEMP"))).CopyToDataTable();

                DevExpress.XtraGrid.Columns.GridColumn QCDataDetailsID = view.Columns["QCDataDetailsID"];
                DevExpress.XtraGrid.Columns.GridColumn ID_Defect = view.Columns["ID_Defect"];
                DevExpress.XtraGrid.Columns.GridColumn DefeactQuanity = view.Columns["DefeactQuanity"];
                Int64 iQCDataDetailsID = string.IsNullOrEmpty(view.GetFocusedRowCellValue("QCDataDetailsID").ToString()) ? -1 : Convert.ToInt64(view.GetFocusedRowCellValue("QCDataDetailsID"));
                Int64 iID_Defect = string.IsNullOrEmpty(view.GetFocusedRowCellValue("ID_Defect").ToString()) ? -1 : Convert.ToInt64(view.GetFocusedRowCellValue("ID_Defect"));
                double nDefeactQuanity = string.IsNullOrEmpty(view.GetFocusedRowCellValue("DefeactQuanity").ToString()) ? 0 : Convert.ToDouble(view.GetFocusedRowCellValue("DefeactQuanity"));


                if (Commons.Modules.ObjSystems.IsnullorEmpty(view.GetRowCellValue(e.RowHandle, ID_Defect)))
                {
                    e.Valid = false;
                    view.SetColumnError(ID_Defect, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrong", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = ID_Defect;
                    return;
                }

                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((string.IsNullOrEmpty(dt.Rows[i][ID_Defect.FieldName].ToString()) ? -1 : Convert.ToInt64(dt.Rows[i][ID_Defect.FieldName])) == iID_Defect)
                    {
                        count++;
                    }
                }
                if ((count == 2 && !grvQCDataDefect.IsNewItemRow(grvQCDataDefect.FocusedRowHandle)) || (count == 1 && grvQCDataDefect.IsNewItemRow(grvQCDataDefect.FocusedRowHandle)))
                {
                    e.Valid = false;
                    XtraMessageBox.Show(ID_Defect.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                    view.SetColumnError(ID_Defect, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = ID_Defect;
                    return;
                }
               

                if (Commons.Modules.ObjSystems.IsnullorEmpty(view.GetRowCellValue(e.RowHandle, DefeactQuanity)))
                {
                    e.Valid = false;
                    view.SetColumnError(DefeactQuanity, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrong", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = DefeactQuanity;
                    return;
                }

                if (nDefeactQuanity <= 0)
                {
                    e.Valid = false;
                    view.SetColumnError(DefeactQuanity, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msPhaiLonHon0", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = DefeactQuanity;
                    return;
                }
            }
            catch { }
        }
        private void grvQCDataDefect_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        #endregion

        private void datQCDate_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}