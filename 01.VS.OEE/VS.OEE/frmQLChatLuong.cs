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
            LoadgrdQCData(-1);
            Commons.Modules.sId = "";
            Commons.Modules.ObjSystems.AddnewRow(grvQCDataDetails, true);
            Commons.Modules.ObjSystems.AddnewRow(grvQCDataDefect, true);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvQCData.GetFocusedRowCellValue("ID_NHA_MAY") == null)
            {
                return;
            }
            ithem = Convert.ToInt64(grvQCData.GetFocusedRowCellValue("ID_NHA_MAY"));
            VisibleButon(false);
            Commons.Modules.ObjSystems.AddnewRow(grvQCDataDetails, true);
            Commons.Modules.ObjSystems.AddnewRow(grvQCDataDefect, true);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnThem.Visible = btnXoa.Visible = btnSua.Visible = btnThoat.Visible = false;
            btnDelTo.Visible = btnDelNhaMay.Visible = btnDelPhanXuong.Visible = btnTroVe.Visible = true;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                string sBTNhaMay = "TMPNhaMay" + Commons.Modules.UserName;
                string sBTPhanXuong = "TMPPhanXuong" + Commons.Modules.UserName;
                string sBTTo = "TMPTo" + Commons.Modules.UserName;

                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTNhaMay, Commons.Modules.ObjSystems.ConvertDatatable(grdQCData), "");
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTPhanXuong, Commons.Modules.ObjSystems.ConvertDatatable(grdQCDataDetails), "");
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTTo, Commons.Modules.ObjSystems.ConvertDatatable(grdQCDataDefect), "");

                if (Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditNM_PX_TO", sBTNhaMay, sBTPhanXuong, sBTTo)) == 1)
                {
                    LoadgrdQCData(-1);
                    LoadgrdQCDataDetails();
                    LoadgrdQCDataDefect();
                    grvQCData_FocusedRowChanged(grvQCData, null);
                }

                Commons.Modules.ObjSystems.DeleteAddRow(grvQCData);
                Commons.Modules.ObjSystems.DeleteAddRow(grvQCDataDetails);
                Commons.Modules.ObjSystems.DeleteAddRow(grvQCDataDefect);
                VisibleButon(true);
            }
            catch { }
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.DeleteAddRow(grvQCData);
            Commons.Modules.ObjSystems.DeleteAddRow(grvQCDataDetails);
            Commons.Modules.ObjSystems.DeleteAddRow(grvQCDataDefect);
            VisibleButon(true);
            ithem = Convert.ToInt64(grvQCData.GetFocusedRowCellValue("ID_NHA_MAY"));
            LoadgrdQCData(ithem);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            btnThem.Visible = btnXoa.Visible = btnSua.Visible = btnThoat.Visible = true;
            btnDelTo.Visible = btnDelNhaMay.Visible = btnDelPhanXuong.Visible = btnTroVe.Visible = false;
        }
        private void btnDelNhaMay_Click(object sender, EventArgs e)
        {
            DeleteDataNhaMay();
        }
        private void btnDelPhanXuong_Click(object sender, EventArgs e)
        {
            DeleteDataPhanXuong();
        }
        private void btnDelTo_Click(object sender, EventArgs e)
        {
            DeleteDataTo();
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

            grvQCData.OptionsBehavior.Editable = flag;
            grvQCDataDetails.OptionsBehavior.Editable = flag;
            grvQCDataDefect.OptionsBehavior.Editable = flag;
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

                    grvQCData.Columns["ID"].OptionsColumn.AllowEdit = false;

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


                }
                else
                    grdQCDataDetails.DataSource = dt;
            
                if (grvQCDataDetails.FocusedRowHandle < 1)
                {
                    grvPhanXuong_FocusedRowChanged(null, null);
                }
            }
            catch 
            {
            }
        }
        private void LoadgrdQCDataDefect()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetTo", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                if (grdQCDataDefect.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdQCDataDefect, grvQCDataDefect, dt, false, true, false, false, true, this.Name);
                }
                else
                    grdQCDataDefect.DataSource = dt;
            }
            catch
            {

            }
        }
        private void DeleteDataNhaMay()
        {
            if (grvQCData.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvQCData.GetFocusedRowCellValue("ID_NHA_MAY").ToString()); } catch { }
            try
            {
                if (iId == -1)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                    return;
                }
                else
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groQCDataDetails.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.TO_Operator WHERE ID_PHAN_XUONG IN (SELECT ID_PHAN_XUONG FROM dbo.PHAN_XUONG WHERE ID_NHA_MAY = " + iId + ") DELETE dbo.PHAN_XUONG WHERE ID_NHA_MAY = " + iId + " DELETE dbo.NHA_MAY WHERE ID_NHA_MAY = " + iId + "");
                grvQCData.DeleteSelectedRows();
                grvQCData_FocusedRowChanged(grvQCData, null);
            }
            
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }
        private void DeleteDataPhanXuong()
        {
            try
            {

                if (grvQCDataDetails.RowCount == 0) return;
                Int64 iId = -1;
                //kiểm tra proid này đã tồn tại 
                try { iId = Modules.ToInt64(grvQCDataDetails.GetFocusedRowCellValue("ID_PHAN_XUONG").ToString()); } catch { }
                if (iId == -1 && btnThem.Visible == true)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                    return;
                }
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groQCDataDetails.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.TO_Operator WHERE ID_PHAN_XUONG = " + iId + " DELETE dbo.PHAN_XUONG WHERE ID_PHAN_XUONG = " + iId + "");
                grvQCDataDetails.DeleteSelectedRows();
                grvPhanXuong_FocusedRowChanged(grvQCDataDetails, null);
            }
            catch (Exception)
            {
                Commons.Modules.msgChung(Commons.ThongBao.msgDuLieuDaPhatSinh);
            }
        }
        private void DeleteDataTo()
        {
            try
            {
                if (grvQCDataDefect.RowCount == 0) return;
                Int64 iId = -1;
                try { iId = Modules.ToInt64(grvQCDataDefect.GetFocusedRowCellValue("ID_TO").ToString()); } catch { }
                if (iId == -1)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                    return;
                }
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groQCDataDefect.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.TO_Operator WHERE ID_TO = '" + (grvQCDataDefect.GetFocusedRowCellValue("ID_TO") + "'"));
                grvQCDataDefect.DeleteSelectedRows();
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
        #endregion

        #region Event lưới 
        private void grvQCData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            GridView view = sender as GridView;
            //LoadgrdPhanXuong();
            RowFilter(grdQCDataDetails, grvQCDataDetails.Columns["ID_NHA_MAY"], Convert.ToInt64(view.GetFocusedRowCellValue("ID_NHA_MAY")));
            RowFilter(grdQCDataDefect, grvQCDataDefect.Columns["ID_PHAN_XUONG"], Convert.ToInt64(grvQCDataDetails.GetFocusedRowCellValue("ID_PHAN_XUONG")));
            if (grvQCData.GetFocusedRowCellValue("ID_NHA_MAY") == null)
            {
                grdQCDataDetails.Enabled = false;
            }
            else
            {
                grdQCDataDetails.Enabled = true;
            }
        }
        private void grvNhaMay_InitNewRow(object sender, InitNewRowEventArgs e)
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
                    if ((string.IsNullOrEmpty(dt.Rows[i]["ID_NHA_MAY"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["ID_NHA_MAY"])) > max)
                    {
                        max = (string.IsNullOrEmpty(dt.Rows[i]["ID_NHA_MAY"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["ID_NHA_MAY"]));
                    }
                }

                view.SetFocusedRowCellValue("ID_NHA_MAY", max + 1);
                view.SetFocusedRowCellValue("ID_TEMP", -1);

                if (view.GetFocusedRowCellValue("ID_NHA_MAY") == null)
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
        private void grdNhaMay_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && btnGhi.Visible == false)
            {
                DeleteDataNhaMay();
            }
        }
        private void grvNhaMay_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                //Kiem trong + Kiem trung
                GridView view = sender as GridView;
                GridControl grid = view.GridControl;
                DataTable dt = new DataTable();
                dt = (DataTable)grid.DataSource;

                DevExpress.XtraGrid.Columns.GridColumn ID = view.Columns["ID_NHA_MAY"];
                DevExpress.XtraGrid.Columns.GridColumn MS = view.Columns["MS_NHA_MAY"];
                DevExpress.XtraGrid.Columns.GridColumn TEN = view.Columns["TEN_NHA_MAY"];
                DevExpress.XtraGrid.Columns.GridColumn TEN_A = view.Columns["TEN_NHA_MAY_A"];
                Int64 iID = Convert.ToInt64(view.GetFocusedRowCellValue("ID_NHA_MAY"));
                string sMS = view.GetFocusedRowCellValue("MS_NHA_MAY").ToString();
                string sTEN = view.GetFocusedRowCellValue("TEN_NHA_MAY").ToString();
                string sTEN_A = view.GetFocusedRowCellValue("TEN_NHA_MAY_A").ToString();


                if (Commons.Modules.ObjSystems.IsnullorEmpty(view.GetRowCellValue(e.RowHandle, MS)))
                {
                    e.Valid = false;
                    view.SetColumnError(MS, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrong", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = MS;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((string.IsNullOrEmpty(dt.Rows[i][ID.FieldName].ToString()) ? -1 : Convert.ToInt64(dt.Rows[i][ID.FieldName])) != iID && (string.IsNullOrEmpty(dt.Rows[i][MS.FieldName].ToString()) ? "" : dt.Rows[i][MS.FieldName].ToString()) == sMS)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(MS.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                        view.SetColumnError(MS, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                        view.FocusedColumn = MS;
                        return;
                    }
                }

                if (Commons.Modules.ObjSystems.IsnullorEmpty(view.GetRowCellValue(e.RowHandle, TEN)))
                {
                    e.Valid = false;
                    view.SetColumnError(TEN, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrong", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = TEN;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((string.IsNullOrEmpty(dt.Rows[i][ID.FieldName].ToString()) ? -1 : Convert.ToInt64(dt.Rows[i][ID.FieldName])) != iID && (string.IsNullOrEmpty(dt.Rows[i][TEN.FieldName].ToString()) ? "" : dt.Rows[i][TEN.FieldName].ToString()) == sTEN)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(TEN.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                        view.SetColumnError(TEN, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                        view.FocusedColumn = TEN;
                        return;
                    }
                }

                if (Commons.Modules.ObjSystems.IsnullorEmpty(view.GetRowCellValue(e.RowHandle, TEN_A)))
                {
                    e.Valid = false;
                    view.SetColumnError(TEN_A, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrong", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = TEN_A;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if ((string.IsNullOrEmpty(dt.Rows[i][ID.FieldName].ToString()) ? -1 : Convert.ToInt64(dt.Rows[i][ID.FieldName])) != iID && (string.IsNullOrEmpty(dt.Rows[i][TEN_A.FieldName].ToString()) ? "" : dt.Rows[i][TEN_A.FieldName].ToString()) == sTEN_A)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(TEN_A.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                        view.SetColumnError(TEN_A, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                        view.FocusedColumn = TEN_A;
                        return;
                    }
                }

            }
            catch { }
        }
        private void grvNhaMay_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        private void grvPhanXuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            GridView view = sender as GridView;
            //LoadgrdTo();
            RowFilter(grdQCDataDefect, grvQCDataDefect.Columns["ID_PHAN_XUONG"], Convert.ToInt64(view.GetFocusedRowCellValue("ID_PHAN_XUONG")));
            if (grvQCDataDetails.GetFocusedRowCellValue("ID_PHAN_XUONG") == null)
            {
                grdQCDataDefect.Enabled = false;
            }
            else
            {
                grdQCDataDefect.Enabled = true;
            }
        }
        private void grdPhanXuong_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteDataPhanXuong();
            }
        }
        private void grvPhanXuong_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                //Kiem trong + Kiem trung
                GridView view = sender as GridView;
                GridControl grid = view.GridControl;
                DataTable dt = new DataTable();
                dt = (DataTable)grid.DataSource;

                DevExpress.XtraGrid.Columns.GridColumn ID = view.Columns["ID_PHAN_XUONG"];
                DevExpress.XtraGrid.Columns.GridColumn MS = view.Columns["MS_PHAN_XUONG"];
                DevExpress.XtraGrid.Columns.GridColumn TEN = view.Columns["TEN_PHAN_XUONG"];
                DevExpress.XtraGrid.Columns.GridColumn TEN_A = view.Columns["TEN_PHAN_XUONG_A"];
                Int64 iID = Convert.ToInt64(view.GetFocusedRowCellValue("ID_PHAN_XUONG"));
                string sMS = view.GetFocusedRowCellValue("MS_PHAN_XUONG").ToString();
                string sTEN = view.GetFocusedRowCellValue("TEN_PHAN_XUONG").ToString();
                string sTEN_A = view.GetFocusedRowCellValue("TEN_PHAN_XUONG_A").ToString();


                if (Commons.Modules.ObjSystems.IsnullorEmpty(view.GetRowCellValue(e.RowHandle, MS)))
                {
                    e.Valid = false;
                    view.SetColumnError(MS, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrong", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = MS;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((string.IsNullOrEmpty(dt.Rows[i][ID.FieldName].ToString()) ? -1 : Convert.ToInt64(dt.Rows[i][ID.FieldName])) != iID && (string.IsNullOrEmpty(dt.Rows[i][MS.FieldName].ToString()) ? "" : dt.Rows[i][MS.FieldName].ToString()) == sMS)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(MS.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                        view.SetColumnError(MS, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                        view.FocusedColumn = MS;
                        return;
                    }
                }

                if (Commons.Modules.ObjSystems.IsnullorEmpty(view.GetRowCellValue(e.RowHandle, TEN)))
                {
                    e.Valid = false;
                    view.SetColumnError(TEN, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrong", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = TEN;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((string.IsNullOrEmpty(dt.Rows[i][ID.FieldName].ToString()) ? -1 : Convert.ToInt64(dt.Rows[i][ID.FieldName])) != iID && (string.IsNullOrEmpty(dt.Rows[i][TEN.FieldName].ToString()) ? "" : dt.Rows[i][TEN.FieldName].ToString()) == sTEN)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(TEN.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                        view.SetColumnError(TEN, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                        view.FocusedColumn = TEN;
                        return;
                    }
                }

                if (Commons.Modules.ObjSystems.IsnullorEmpty(view.GetRowCellValue(e.RowHandle, TEN_A)))
                {
                    e.Valid = false;
                    view.SetColumnError(TEN_A, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrong", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = TEN_A;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if ((string.IsNullOrEmpty(dt.Rows[i][ID.FieldName].ToString()) ? -1 : Convert.ToInt64(dt.Rows[i][ID.FieldName])) != iID && (string.IsNullOrEmpty(dt.Rows[i][TEN_A.FieldName].ToString()) ? "" : dt.Rows[i][TEN_A.FieldName].ToString()) == sTEN_A)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(TEN_A.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                        view.SetColumnError(TEN_A, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                        view.FocusedColumn = TEN_A;
                        return;
                    }
                }

            }
            catch { }
        }
        private void grvPhanXuong_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;

        }
        private void grvPhanXuong_InitNewRow(object sender, InitNewRowEventArgs e)
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
                    if ((string.IsNullOrEmpty(dt.Rows[i]["ID_PHAN_XUONG"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["ID_PHAN_XUONG"])) > max)
                    {
                        max = (string.IsNullOrEmpty(dt.Rows[i]["ID_PHAN_XUONG"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["ID_PHAN_XUONG"]));
                    }
                }

                view.SetFocusedRowCellValue("ID_PHAN_XUONG", max + 1);
                view.SetFocusedRowCellValue("ID_NHA_MAY", grvQCData.GetFocusedRowCellValue("ID_NHA_MAY"));
                view.SetFocusedRowCellValue("ID_TEMP", -1);

                if (view.GetFocusedRowCellValue("ID_PHAN_XUONG") == null)
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
        private void grvTo_InitNewRow(object sender, InitNewRowEventArgs e)
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
                    if ((string.IsNullOrEmpty(dt.Rows[i]["ID_TO"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["ID_TO"])) > max)
                    {
                        max = (string.IsNullOrEmpty(dt.Rows[i]["ID_TO"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["ID_TO"]));
                    }
                }

                view.SetFocusedRowCellValue("ID_TO", max + 1);
                view.SetFocusedRowCellValue("ID_PHAN_XUONG", grvQCDataDetails.GetFocusedRowCellValue("ID_PHAN_XUONG"));
                view.SetFocusedRowCellValue("ID_TEMP", -1);

            }
            catch { }

        }
        private void grdTo_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteDataTo();
            }
        }
        private void grvTo_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                //Kiem trong + Kiem trung
                GridView view = sender as GridView;
                GridControl grid = view.GridControl;
                DataTable dt = new DataTable();
                dt = (DataTable)grid.DataSource;

                DevExpress.XtraGrid.Columns.GridColumn ID = view.Columns["ID_TO"];
                DevExpress.XtraGrid.Columns.GridColumn MS = view.Columns["MS_TO"];
                DevExpress.XtraGrid.Columns.GridColumn TEN = view.Columns["TEN_TO"];
                DevExpress.XtraGrid.Columns.GridColumn TEN_A = view.Columns["TEN_TO_ANH"];
                Int64 iID = Convert.ToInt64(view.GetFocusedRowCellValue("ID_TO"));
                string sMS = view.GetFocusedRowCellValue("MS_TO").ToString();
                string sTEN = view.GetFocusedRowCellValue("TEN_TO").ToString();
                string sTEN_A = view.GetFocusedRowCellValue("TEN_TO_ANH").ToString();


                if (Commons.Modules.ObjSystems.IsnullorEmpty(view.GetRowCellValue(e.RowHandle, MS)))
                {
                    e.Valid = false;
                    view.SetColumnError(MS, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrong", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = MS;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((string.IsNullOrEmpty(dt.Rows[i][ID.FieldName].ToString()) ? -1 : Convert.ToInt64(dt.Rows[i][ID.FieldName])) != iID && (string.IsNullOrEmpty(dt.Rows[i][MS.FieldName].ToString()) ? "" : dt.Rows[i][MS.FieldName].ToString()) == sMS)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(MS.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                        view.SetColumnError(MS, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                        view.FocusedColumn = MS;
                        return;
                    }
                }

                if (Commons.Modules.ObjSystems.IsnullorEmpty(view.GetRowCellValue(e.RowHandle, TEN)))
                {
                    e.Valid = false;
                    view.SetColumnError(TEN, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrong", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = TEN;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((string.IsNullOrEmpty(dt.Rows[i][ID.FieldName].ToString()) ? -1 : Convert.ToInt64(dt.Rows[i][ID.FieldName])) != iID && (string.IsNullOrEmpty(dt.Rows[i][TEN.FieldName].ToString()) ? "" : dt.Rows[i][TEN.FieldName].ToString()) == sTEN)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(TEN.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                        view.SetColumnError(TEN, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                        view.FocusedColumn = TEN;
                        return;
                    }
                }

                if (Commons.Modules.ObjSystems.IsnullorEmpty(view.GetRowCellValue(e.RowHandle, TEN_A)))
                {
                    e.Valid = false;
                    view.SetColumnError(TEN_A, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrong", Commons.Modules.TypeLanguage));
                    view.FocusedColumn = TEN_A;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if ((string.IsNullOrEmpty(dt.Rows[i][ID.FieldName].ToString()) ? -1 : Convert.ToInt64(dt.Rows[i][ID.FieldName])) != iID && (string.IsNullOrEmpty(dt.Rows[i][TEN_A.FieldName].ToString()) ? "" : dt.Rows[i][TEN_A.FieldName].ToString()) == sTEN_A)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(TEN_A.Caption.Trim() + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                        view.SetColumnError(TEN_A, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "msgKhongDuocTrung", Commons.Modules.TypeLanguage));
                        view.FocusedColumn = TEN_A;
                        return;
                    }
                }

            }
            catch { }
        }
        private void grvTo_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;

        }
        #endregion
    }
}