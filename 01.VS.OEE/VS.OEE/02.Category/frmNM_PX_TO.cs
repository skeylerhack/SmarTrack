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
    public partial class frmNM_PX_TO : DevExpress.XtraEditors.XtraForm
    {
        static int iPQ = 1;
        Int64 ithem = 0;
        public frmNM_PX_TO(int PQ)
        {
            iPQ = PQ;
            InitializeComponent();
        }

        #region eventForm
        private void frmNM_PX_TO_Load(object sender, EventArgs e)
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
       
            LoadgrdNhaMay(-1);
            LoadgrdPhanXuong();
            LoadgrdTo();
            Commons.Modules.sId = "";
            grvNhaMay_FocusedRowChanged(grvNhaMay, null);

            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Commons.Modules.sId = "0Load";
            ithem = -1;
            VisibleButon(false);
            LoadgrdNhaMay(-1);
            Commons.Modules.sId = "";
            Commons.Modules.ObjSystems.AddnewRow(grvNhaMay, true);
            Commons.Modules.ObjSystems.AddnewRow(grvPhanXuong, true);
            Commons.Modules.ObjSystems.AddnewRow(grvTo, true);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvNhaMay.GetFocusedRowCellValue("ID_NHA_MAY") == null)
            {
                return;
            }
            ithem = Convert.ToInt64(grvNhaMay.GetFocusedRowCellValue("ID_NHA_MAY"));
            VisibleButon(false);
            Commons.Modules.ObjSystems.AddnewRow(grvPhanXuong, true);
            Commons.Modules.ObjSystems.AddnewRow(grvTo, true);
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

                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTNhaMay, Commons.Modules.ObjSystems.ConvertDatatable(grdNhaMay), "");
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTPhanXuong, Commons.Modules.ObjSystems.ConvertDatatable(grdPhanXuong), "");
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTTo, Commons.Modules.ObjSystems.ConvertDatatable(grdTo), "");

                if (Convert.ToInt64(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spEditNM_PX_TO", sBTNhaMay, sBTPhanXuong, sBTTo)) == 1)
                {
                    LoadgrdNhaMay(-1);
                    LoadgrdPhanXuong();
                    LoadgrdTo();
                    grvNhaMay_FocusedRowChanged(grvNhaMay, null);
                }

                Commons.Modules.ObjSystems.DeleteAddRow(grvNhaMay);
                Commons.Modules.ObjSystems.DeleteAddRow(grvPhanXuong);
                Commons.Modules.ObjSystems.DeleteAddRow(grvTo);
                VisibleButon(true);
            }
            catch { }
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.DeleteAddRow(grvNhaMay);
            Commons.Modules.ObjSystems.DeleteAddRow(grvPhanXuong);
            Commons.Modules.ObjSystems.DeleteAddRow(grvTo);
            VisibleButon(true);
            ithem = Convert.ToInt64(grvNhaMay.GetFocusedRowCellValue("ID_NHA_MAY"));
            LoadgrdNhaMay(ithem);
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

            grvNhaMay.OptionsBehavior.Editable = flag;
            grvPhanXuong.OptionsBehavior.Editable = flag;
            grvTo.OptionsBehavior.Editable = flag;
        }
        private void LoadgrdNhaMay(Int64 id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetNhaMay", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                if (grdNhaMay.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdNhaMay, grvNhaMay, dt, false, true, false, false, true, this.Name);

                    grvNhaMay.Columns["ID_NHA_MAY"].OptionsColumn.AllowEdit = false;
                    grvNhaMay.Columns["ID_TEMP"].OptionsColumn.AllowEdit = false;

                    grvNhaMay.Columns["ID_NHA_MAY"].Visible = false;
                    grvNhaMay.Columns["ID_TEMP"].Visible = false;
                }
                else
                    grdNhaMay.DataSource = dt;

                if (id != -1)
                {
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["ID_NHA_MAY"] };
                    int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                    grvNhaMay.FocusedRowHandle = grvNhaMay.GetRowHandle(index);
                }
                else { }
                if (grvNhaMay.FocusedRowHandle < 1)
                {
                    grvNhaMay_FocusedRowChanged(null, null);
                }
            }
            catch
            {
            }
        }
        private void LoadgrdPhanXuong()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetPhanXuong", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                if (grdPhanXuong.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdPhanXuong, grvPhanXuong, dt, false, true, false, false, true, this.Name);


                    grvPhanXuong.Columns["ID_PHAN_XUONG"].OptionsColumn.AllowEdit = false;
                    grvPhanXuong.Columns["ID_NHA_MAY"].OptionsColumn.AllowEdit = false;
                    grvPhanXuong.Columns["ID_TEMP"].OptionsColumn.AllowEdit = false;

                    grvPhanXuong.Columns["ID_PHAN_XUONG"].Visible = false;
                    grvPhanXuong.Columns["ID_NHA_MAY"].Visible = false;
                    grvPhanXuong.Columns["ID_TEMP"].Visible = false;
                }
                else
                    grdPhanXuong.DataSource = dt;
            
                if (grvPhanXuong.FocusedRowHandle < 1)
                {
                    grvPhanXuong_FocusedRowChanged(null, null);
                }
            }
            catch 
            {
            }
        }
        private void LoadgrdTo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetTo", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                if (grdTo.DataSource == null)
                {
                    Modules.ObjSystems.MLoadXtraGrid(grdTo, grvTo, dt, false, true, false, false, true, this.Name);

                    grvTo.Columns["ID_TO"].OptionsColumn.AllowEdit = false;
                    grvTo.Columns["ID_PHAN_XUONG"].OptionsColumn.AllowEdit = false;
                    grvTo.Columns["ID_TEMP"].OptionsColumn.AllowEdit = false;

                    grvTo.Columns["ID_TO"].Visible = false;
                    grvTo.Columns["ID_PHAN_XUONG"].Visible = false;
                    grvTo.Columns["ID_TEMP"].Visible = false;
                }
                else
                    grdTo.DataSource = dt;
            }
            catch
            {

            }
        }
        private void DeleteDataNhaMay()
        {
            if (grvNhaMay.RowCount == 0) return;
            Int64 iId = -1;
            try { iId = Modules.ToInt64(grvNhaMay.GetFocusedRowCellValue("ID_NHA_MAY").ToString()); } catch { }
            try
            {
                if (iId == -1)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                    return;
                }
                else
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groPhanXuong.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.TO_Operator WHERE ID_PHAN_XUONG IN (SELECT ID_PHAN_XUONG FROM dbo.PHAN_XUONG WHERE ID_NHA_MAY = " + iId + ") DELETE dbo.PHAN_XUONG WHERE ID_NHA_MAY = " + iId + " DELETE dbo.NHA_MAY WHERE ID_NHA_MAY = " + iId + "");
                grvNhaMay.DeleteSelectedRows();
                grvNhaMay_FocusedRowChanged(grvNhaMay, null);
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

                if (grvPhanXuong.RowCount == 0) return;
                Int64 iId = -1;
                //kiểm tra proid này đã tồn tại 
                try { iId = Modules.ToInt64(grvPhanXuong.GetFocusedRowCellValue("ID_PHAN_XUONG").ToString()); } catch { }
                if (iId == -1 && btnThem.Visible == true)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                    return;
                }
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groPhanXuong.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.TO_Operator WHERE ID_PHAN_XUONG = " + iId + " DELETE dbo.PHAN_XUONG WHERE ID_PHAN_XUONG = " + iId + "");
                grvPhanXuong.DeleteSelectedRows();
                grvPhanXuong_FocusedRowChanged(grvPhanXuong, null);
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
                if (grvTo.RowCount == 0) return;
                Int64 iId = -1;
                try { iId = Modules.ToInt64(grvTo.GetFocusedRowCellValue("ID_TO").ToString()); } catch { }
                if (iId == -1)
                {
                    Modules.msgChung(ThongBao.msgKhongCoDuLieuXoa);
                    return;
                }
                if (Modules.msgHoiThayThe(ThongBao.msgXoa, groTo.Text) == DialogResult.No) return;
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.TO_Operator WHERE ID_TO = '" + (grvTo.GetFocusedRowCellValue("ID_TO") + "'"));
                grvTo.DeleteSelectedRows();
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
        private void grvNhaMay_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Commons.Modules.sId == "0Load") return;
            GridView view = sender as GridView;
            //LoadgrdPhanXuong();
            RowFilter(grdPhanXuong, grvPhanXuong.Columns["ID_NHA_MAY"], Convert.ToInt64(view.GetFocusedRowCellValue("ID_NHA_MAY")));
            RowFilter(grdTo, grvTo.Columns["ID_PHAN_XUONG"], Convert.ToInt64(grvPhanXuong.GetFocusedRowCellValue("ID_PHAN_XUONG")));
            if (grvNhaMay.GetFocusedRowCellValue("ID_NHA_MAY") == null)
            {
                grdPhanXuong.Enabled = false;
            }
            else
            {
                grdPhanXuong.Enabled = true;
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
                    grdPhanXuong.Enabled = false;
                }
                else
                {
                    grdPhanXuong.Enabled = true;
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
            RowFilter(grdTo, grvTo.Columns["ID_PHAN_XUONG"], Convert.ToInt64(view.GetFocusedRowCellValue("ID_PHAN_XUONG")));
            if (grvPhanXuong.GetFocusedRowCellValue("ID_PHAN_XUONG") == null)
            {
                grdTo.Enabled = false;
            }
            else
            {
                grdTo.Enabled = true;
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
                view.SetFocusedRowCellValue("ID_NHA_MAY", grvNhaMay.GetFocusedRowCellValue("ID_NHA_MAY"));
                view.SetFocusedRowCellValue("ID_TEMP", -1);

                if (view.GetFocusedRowCellValue("ID_PHAN_XUONG") == null)
                {
                    grdTo.Enabled = false;
                }
                else
                {
                    grdTo.Enabled = true;
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
                view.SetFocusedRowCellValue("ID_PHAN_XUONG", grvPhanXuong.GetFocusedRowCellValue("ID_PHAN_XUONG"));
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