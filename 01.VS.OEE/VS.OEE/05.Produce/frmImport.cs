using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Collections.Generic;
using DevExpress.XtraGrid;
using Microsoft.ApplicationBlocks.Data;
using System.Drawing;
using DevExpress.XtraGrid.Columns;
using System.Linq;

namespace VS.OEE
{
    public partial class frmImport : DevExpress.XtraEditors.XtraForm
    {
        string sSql = "";
        Point ptChung;
        DataTable _table = new DataTable();
        string fileName = null;
        public frmImport()
        {
            InitializeComponent();

        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (grvImport.RowCount > 0)
            {
                KeHoachSanXuat(_table);
                return;
            }
        }
        //#region 1. Import phieu xuat kho
        //private void KeHoachSanXuatOld(DataTable dtSource)
        //{
        //    string sKiemTra = "";
        //    int count = grvImport.RowCount;
        //    int col = 0;
        //    #region declare varian
        //    int POOK = 0;
        //    int MAYOK = 0;
        //    int MASPOK = 0;
        //    int BOMVEROK = 0;
        //    int SLKHOK = 0;
        //    int SOCASXOK = 0;
        //    int NGAYBDOK = 0;
        //    int CABDOK = 0;
        //    int NGAYKTOK = 0;
        //    int CAKTOK = 0;
        //    int idem;
        //    #endregion

        //    #region kiem tra import Lệnh sản xuất
        //    foreach (DataRow dr in dtSource.Rows)
        //    {
        //        dr["XOA"] = 0;
        //        #region Kiem Tra
        //        dr.ClearErrors();
        //        col = 0;
        //        #region Số phiếu PO
        //        sKiemTra = dr[grvImport.Columns[col].FieldName.ToString()].ToString();
        //        if (string.IsNullOrEmpty(sKiemTra))
        //        {
        //            dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Mã số PO không được để trống!");
        //            dr["XOA"] = 1;
        //        }
        //        else
        //        {
        //            //kiểm tra tồn tại mspo kho
        //            sSql = "SELECT COUNT(*) FROM dbo.ProductionOrder WHERE PrOrNumber = N'" + sKiemTra + "'";
        //            idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
        //            if (idem > 0)
        //            {
        //                dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Số phiếu PO này đã tồn tại trong CSDL!");
        //                dr["XOA"] = 1;
        //            }
        //            else
        //            {
        //                POOK = CheckLen(dr, col, POOK, 50, "Số phiếu PO");
        //            }
        //        }




        //        #endregion
        //        col = 1;
        //        #region Mã số máy
        //        sKiemTra = dr[grvImport.Columns[col].FieldName.ToString()].ToString();
        //        if (string.IsNullOrEmpty(sKiemTra))
        //        {
        //            dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Mã số máy không được để trống!");
        //            dr["XOA"] = 1;
        //        }
        //        else
        //        {
        //            //kiểm tra tồn tại của mã số máy trong itemmay theo mã loại sản phẩm
        //            sSql = "SELECT COUNT(*) FROM dbo.ItemMay WHERE ItemID = (SELECT ID FROM  dbo.Item WHERE ItemCode = N'" + dr[grvImport.Columns[col + 1].FieldName.ToString()].ToString() + "') AND MS_MAY  = N'" + sKiemTra + "'";
        //            idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
        //            if (idem == 0)
        //            {
        //                dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Máy này chưa có trong máy mặc hàng!");
        //                dr["XOA"] = 1;
        //            }
        //            else
        //            {
        //                MAYOK = CheckLen(dr, col, MAYOK, 30, "Mã số máy");
        //            }
        //        }
        //        #endregion
        //        col = 2;
        //        #region Kiểm tra mã sản phẩm
        //        sKiemTra = dr[grvImport.Columns[col].FieldName.ToString()].ToString();
        //        if (string.IsNullOrEmpty(sKiemTra))
        //        {
        //            dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Mã sản phẩm không được để trống!");
        //            dr["XOA"] = 1;
        //        }
        //        else
        //        {
        //            //kiểm tra tồn tại của mã sản phẩm trong itemmay
        //            sSql = "SELECT COUNT(*) FROM dbo.Item WHERE ItemCode = N'" + sKiemTra + "'";
        //            idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
        //            if (idem == 0)
        //            {
        //                dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Mã sản phẩm này chưa tồn tại trong CSDL!");
        //                dr["XOA"] = 1;
        //            }
        //            else
        //            {
        //                MASPOK = CheckLen(dr, col, MASPOK, 50, "Mã sản phẩm");
        //            }
        //        }




        //        #endregion
        //        col = 3;
        //        #region BOM Version 
        //        try
        //        {
        //            if (string.IsNullOrEmpty(dr[col].ToString())) dr[col] = 0;
        //            if (KiemDuLieuSo(dr, col, "", 0, 0, true))
        //            {
        //                if (Convert.ToDecimal(dr[col]) < 0)
        //                {
        //                    dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Bom version phải lớn hơn 0!");
        //                    dr["XOA"] = 1;
        //                }
        //                else
        //                {
        //                    BOMVEROK++;
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Phải là số!");
        //            dr["XOA"] = 1;
        //        }

        //        #endregion
        //        col = 4;
        //        #region SL Kế Hoạch
        //        try
        //        {
        //            if (string.IsNullOrEmpty(dr[col].ToString())) dr[col] = 0;
        //            if (KiemDuLieuSo(dr, col, "", 0, 0, true))
        //            {
        //                if (Convert.ToDecimal(dr[col]) == 0)
        //                {
        //                    dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "SL Kế Hoạch phải lớn hơn 0!");
        //                    dr["XOA"] = 1;
        //                }
        //                else
        //                {
        //                    SLKHOK++;
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Phải là số!");
        //            dr["XOA"] = 1;
        //        }
        //        #endregion

        //        col = 5;
        //        #region Số ca sản xuất 
        //        try
        //        {
        //            if (string.IsNullOrEmpty(dr[col].ToString())) dr[col] = 0;
        //            if (KiemDuLieuSo(dr, col, "", 0, 0, true))
        //            {
        //                if (Convert.ToDecimal(dr[col]) < 0)
        //                {
        //                    dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Số ca sản xuất phải lớn hơn 0!");
        //                    dr["XOA"] = 1;
        //                }
        //                else
        //                {
        //                    SOCASXOK++;
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Phải là số!");
        //            dr["XOA"] = 1;
        //        }
        //        #endregion
        //        col = 6;
        //        #region Ngày bắc đầu
        //        sKiemTra = dr[grvImport.Columns[col].FieldName.ToString()].ToString();
        //        if (string.IsNullOrEmpty(sKiemTra))
        //        {
        //            dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Ngày không được để trống!");
        //            dr["XOA"] = 1;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                DateTime dt = Convert.ToDateTime(sKiemTra);
        //                NGAYBDOK++;
        //            }
        //            catch (Exception)
        //            {
        //                dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Kiểu ngày không hợp lệ!");
        //                dr["XOA"] = 1;
        //            }
        //        }
        //        #endregion

        //        col = 7;
        //        #region Ca bắt đầu 
        //        sKiemTra = dr[grvImport.Columns[col].FieldName.ToString()].ToString();
        //        //kiểm tra tồn tại ca trong bảng ca
        //        if (sKiemTra == "")
        //        {
        //            CABDOK++;
        //        }
        //        else
        //        {
        //            sSql = "SELECT COUNT(*) FROM dbo.CA WHERE CA = N'" + sKiemTra + "'";
        //            idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
        //            if (idem == 0)
        //            {
        //                dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Ca này chưa tồn tại trong CSDL!");
        //                dr["XOA"] = 1;
        //            }
        //            else
        //            {
        //                CABDOK = CheckLen(dr, col, CABDOK, 50, "Ca");
        //            }
        //        }
        //        #endregion

        //        col = 8;
        //        #region Ngày Kết thúc
        //        sKiemTra = dr[grvImport.Columns[col].FieldName.ToString()].ToString();
        //        if (string.IsNullOrEmpty(sKiemTra))
        //        {
        //            dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Ngày không được để trống!");
        //            dr["XOA"] = 1;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                DateTime dt = Convert.ToDateTime(sKiemTra);
        //                NGAYKTOK++;
        //            }
        //            catch (Exception)
        //            {
        //                dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Kiểu ngày không hợp lệ!");
        //                dr["XOA"] = 1;
        //            }
        //        }
        //        #endregion

        //        col = 9;
        //        #region Ca Kết thúc 
        //        sKiemTra = dr[grvImport.Columns[col].FieldName.ToString()].ToString();
        //        if (sKiemTra == "")
        //        {
        //            CAKTOK++;
        //        }
        //        else
        //        {
        //            sKiemTra = dr[grvImport.Columns[col].FieldName.ToString()].ToString();
        //            //kiểm tra tồn tại ca trong bảng ca
        //            sSql = "SELECT COUNT(*) FROM dbo.CA WHERE CA = N'" + sKiemTra + "'";
        //            idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
        //            if (idem == 0)
        //            {
        //                dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Ca này chưa tồn tại trong CSDL!");
        //                dr["XOA"] = 1;
        //            }
        //            else
        //            {
        //                CAKTOK = CheckLen(dr, col, CAKTOK, 50, "Ca");
        //            }
        //        }
        //        #endregion
        //        #endregion
        //        #region prb
        //        try
        //        {

        //        }
        //        catch { }
        //        #endregion
        //    }
        //    #endregion
        //    #region check success
        //    if (CheckSuccess(POOK, count) && CheckSuccess(MAYOK, count) && CheckSuccess(MASPOK, count) && CheckSuccess(BOMVEROK, count) && CheckSuccess(SLKHOK, count)
        //        && CheckSuccess(SOCASXOK, count) && CheckSuccess(NGAYBDOK, count) && CheckSuccess(CABDOK, count) && CheckSuccess(NGAYKTOK, count) && CheckSuccess(CAKTOK, count))
        //    {
        //        DialogResult res = XtraMessageBox.Show("Dữ liệu sẵn sàng import vào, bạn có import không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (res == DialogResult.Yes)
        //        {
        //            try
        //            {

        //                DataTable dt = _table.Copy();
        //                dt.Columns[0].ColumnName = "PrOrNumber";
        //                dt.Columns[1].ColumnName = "MS_MAY";
        //                dt.Columns[2].ColumnName = "ItemCode";
        //                dt.Columns[3].ColumnName = "BOMVersion";   
        //                dt.Columns[4].ColumnName = "PlannedQuantity";
        //                dt.Columns[5].ColumnName = "SoCaSX";
        //                dt.Columns[6].ColumnName = "PlannedStartTime";
        //                dt.Columns[7].ColumnName = "CABD";
        //                dt.Columns[8].ColumnName = "DueTime";
        //                dt.Columns[9].ColumnName = "CAKT";
        //                dt.AcceptChanges();
        //                //var columnNames = dt.Columns.OfType<DataColumn>().Where(c => c.DataType == typeof(string)).Select(c => c.ColumnName).ToList();
        //                dt.AsEnumerable().ToList().ForEach(r => r.SetField<string>("PlannedQuantity", r.Field<string>("PlannedQuantity").Replace(',','.')));
        //                //tạo bảng tạm
        //                string sBt = "sBTKHSX" + Commons.Modules.UserName;
        //                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr,sBt, dt, "");
        //                 string []a = dt.AsEnumerable().Select(x => x.Field<string>("PrOrNumber")).Distinct().ToArray();
        //                for (int i = 0; i < a.Length; i++)
        //                {
        //                    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spGetKeHoachSanXuat", a[i].ToString(), sBt);
        //                }
        //                XtraMessageBox.Show("Import dữ liệu thành công!", "Thông báo");
        //                DialogResult = DialogResult.OK;
        //                this.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                XtraMessageBox.Show("Không thể Import dữ liệu này " + ex.ToString() + "", "Thông báo");
        //            }

        //        }
        //    }
        //    #endregion
        //    else
        //    {
        //        XtraMessageBox.Show("Một số dữ liệu chưa hợp lệ, bạn vui lòng kiểm tra và sửa lại trước khi import!");
        //    }
        //    Commons.Modules.ObjSystems.XoaTable("sBTKHSX" + Commons.Modules.UserName);
        //}
        //#endregion

        #region 1. Import phieu xuat kho
        private void KeHoachSanXuat(DataTable dtSource)
        {
            string sKiemTra = "";
            int count = grvImport.RowCount;
            int col = 0;

            #region declare varian
            int MASPOK = 0;
            int SLKHOK = 0;
            int NGAYKTOK = 0;
            int MAYOK = 0;
            int TrungOK = 0;

            int idem;
            #endregion

            #region kiem tra import Lệnh sản xuất
            foreach (DataRow dr in dtSource.Rows)
            {
                dr["XOA"] = 0;
                #region Kiem Tra
                dr.ClearErrors();

                col = 0;
                #region Kiểm tra mã sản phẩm
                sKiemTra = dr[grvImport.Columns[col].FieldName.ToString()].ToString();
                if (string.IsNullOrEmpty(sKiemTra))
                {
                    dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Mã sản phẩm không được để trống!");
                    dr["XOA"] = 1;
                }
                else
                {
                    //kiểm tra tồn tại của mã sản phẩm trong itemmay
                    sSql = "SELECT COUNT(*) FROM dbo.Item WHERE ItemCode = N'" + sKiemTra + "'";
                    idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    if (idem == 0)
                    {
                        dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Mã sản phẩm này chưa tồn tại trong CSDL!");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        MASPOK = CheckLen(dr, col, MASPOK, 50, "Mã sản phẩm");
                    }
                }

                #endregion

                col = 2;
                #region SL Kế Hoạch
                try
                {
                    if (string.IsNullOrEmpty(dr[col].ToString())) dr[col] = 0;
                    if (KiemDuLieuSo(dr, col, "", 0, 0, true))
                    {
                        if (Convert.ToDecimal(dr[col]) == 0)
                        {
                            dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "SL Kế Hoạch phải lớn hơn 0!");
                            dr["XOA"] = 1;
                        }
                        else
                        {
                            SLKHOK++;
                        }
                    }
                }
                catch
                {
                    dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Phải là số!");
                    dr["XOA"] = 1;
                }
                #endregion

                col = 3;
                #region Ngày Kết thúc
                sKiemTra = dr[grvImport.Columns[col].FieldName.ToString()].ToString();
                if (string.IsNullOrEmpty(sKiemTra))
                {
                    dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Ngày không được để trống!");
                    dr["XOA"] = 1;
                }
                else
                {
                    try
                    {
                        DateTime Ngay = Convert.ToDateTime(sKiemTra);
                        if(Ngay < DateTime.Today)
                        {
                            dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Ngày không nhỏ hơn ngày hiện tại!");
                            dr["XOA"] = 1;
                        }    
                        else
                        {
                            NGAYKTOK++;
                        }    
                    }
                    catch (Exception)
                    {
                        dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Kiểu ngày không hợp lệ!");
                        dr["XOA"] = 1;
                    }
                }
                #endregion

                col = 4;
                #region Mã số máy
                sKiemTra = dr[grvImport.Columns[col].FieldName.ToString()].ToString();
                if (string.IsNullOrEmpty(sKiemTra))
                {
                    dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Mã số máy không được để trống!");
                    dr["XOA"] = 1;
                }
                else
                {
                    //kiểm tra tồn tại của mã số máy trong itemmay theo mã loại sản phẩm
                    sSql = "SELECT COUNT(*) FROM dbo.ItemMay WHERE ItemID = (SELECT ID FROM  dbo.Item WHERE ItemCode = N'" + dr[grvImport.Columns[0].FieldName.ToString()].ToString() + "') AND MS_MAY  = N'" + sKiemTra + "'";
                    idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    if (idem == 0)
                    {
                        dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), "Máy này chưa có trong máy mặc hàng!");
                        dr["XOA"] = 1;
                    }
                    else
                    {
                        MAYOK = CheckLen(dr, col, MAYOK, 30, "Mã số máy");
                    }
                }
                #endregion

                #region kiểm tra trùng dữ liệu giữa máy và ngày đưa vào
                //kiển tra trên lưới

                int idem1 = dtSource.AsEnumerable().Count(x=>x[0].ToString().Equals(dr[0].ToString()) && x[3].ToString().Equals(dr[3].ToString()) && x[4].ToString().Equals(dr[4].ToString()));

                //kiểm tra dưới csdl
                sSql = "SELECT COUNT(*) FROM dbo.ProSchedule A INNER JOIN dbo.PrODetails B ON B.DetailsID = A.DetailsID INNER JOIN dbo.Item C ON B.ItemID = C.ID  WHERE MS_MAY = '"+ sKiemTra +"' AND CONVERT(DATE,EndTime) ='"+ Convert.ToDateTime(dr[3]).ToString("yyyy-MM-dd") + "' AND C.ItemCode ='" + dr[0].ToString()+ "'";
                idem = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql));
                if (idem > 0 || idem1 > 1)
                {
                    dr.SetColumnError(grvImport.Columns[0].FieldName.ToString(), "Dữ liệu trùng!");
                    dr.SetColumnError(grvImport.Columns[1].FieldName.ToString(), "Dữ liệu trùng!");
                    dr.SetColumnError(grvImport.Columns[2].FieldName.ToString(), "Dữ liệu trùng!");
                    dr.SetColumnError(grvImport.Columns[3].FieldName.ToString(), "Dữ liệu trùng!");
                    dr.SetColumnError(grvImport.Columns[4].FieldName.ToString(), "Dữ liệu trùng!");
                    dr["XOA"] = 1;
                }
                else
                {
                    TrungOK++;
                }
                #endregion


                #endregion
                #region prb
                try
                {

                }
                catch { }
                #endregion
            }
            #endregion
            
            #region check success
            if (CheckSuccess(MAYOK, count) && CheckSuccess(MASPOK, count) && CheckSuccess(SLKHOK, count)
               && CheckSuccess(NGAYKTOK, count) && CheckSuccess(TrungOK, count))
            {
                DialogResult res = XtraMessageBox.Show("Dữ liệu sẵn sàng import vào, bạn có import không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < _table.Rows.Count; i++)
                        {
                            //đi qua từng đòng lấy được số giờ và ngày bắc đầu cần thực hiện

                            DataTable dt = new DataTable();
                            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM dbo.fnGetNgaySanXuat('"+ _table.Rows[i][0] + "','"+ _table.Rows[i][4] + "',"+ _table.Rows[i][2] + ")"));

                            int SoPhut = Convert.ToInt32(dt.Rows[0][0]);
                            DateTime NgayBD = Convert.ToDateTime(dt.Rows[0][1]);

                            if (NgayBD.DayOfWeek == DayOfWeek.Sunday && (_table.Rows[i][5].ToString() != "" || _table.Rows[i][5].ToString() != "0"))
                            {
                                NgayBD = Convert.ToDateTime(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT DATEADD(DAY,1,(SELECT dbo.fnGetNgayTheoCa('" + NgayBD.ToString("yyyy-MM-dd HH:mm:ss") + "')) + MIN(TU_GIO)) FROM dbo.CA "));
                            }

                            XuLyNgay(_table.Rows[i][0].ToString(), _table.Rows[i][4].ToString(), Convert.ToDouble(_table.Rows[i][2]),NgayBD,SoPhut, Convert.ToDouble(_table.Rows[i][2]) / SoPhut,Convert.ToDateTime(_table.Rows[i][3]));
                        }

                        XtraMessageBox.Show("Import dữ liệu thành công!", "Thông báo");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Không thể Import dữ liệu này " + ex.ToString() + "", "Thông báo");
                    }

                }
            }
            #endregion
            else
            {
                XtraMessageBox.Show("Một số dữ liệu chưa hợp lệ, bạn vui lòng kiểm tra và sửa lại trước khi import!");
            }
        }
        #endregion

        private void XuLyNgay(string ItemCode, string MS_MAY, double SoLuong, DateTime NgayBD,int SoPhut, double SLPhut,DateTime EndTime)
        {
            //lấy giờ bắc đầu của ngày hôm sau.
            DateTime NgayKT = Convert.ToDateTime(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT DATEADD(DAY,1,(SELECT dbo.fnGetNgayTheoCa('" + NgayBD.ToString("yyyy-MM-dd HH:mm:ss") + "')) + MIN(TU_GIO)) FROM dbo.CA "));

            //kiểm tra số phút nhỏ hơn từ ngày đến ngày thì add vào production
            TimeSpan timspan = NgayKT - NgayBD;
            if (SoPhut <= timspan.TotalMinutes)
            {
                AddProduction(ItemCode, MS_MAY, SoLuong, NgayBD, NgayBD.AddMinutes(SoPhut),EndTime);
                return;
            }
            else
            {
                //nếu số phút lớn hơn khoản cách đến ngày hôm sau
                AddProduction(ItemCode, MS_MAY, timspan.TotalMinutes * SLPhut, NgayBD, NgayKT,EndTime);
                XuLyNgay(ItemCode, MS_MAY, SoLuong - (timspan.TotalMinutes * SLPhut), NgayKT, (SoPhut - Convert.ToInt32(timspan.TotalMinutes)),SLPhut,EndTime);
            }
        }

        private void AddProduction(string ItemCode,string MS_MAY,double SoLuong,DateTime NgayBD, DateTime NgayKT,DateTime EndTime)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spImportProDuction", ItemCode, MS_MAY, SoLuong, NgayBD, NgayKT, EndTime);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        private void MLoadExcel()
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "All Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|" + "All Files (*.*)|*.*";
                if (oFile.ShowDialog() != DialogResult.OK) return;
                fileName = oFile.FileName;
                if (!System.IO.File.Exists(fileName)) return;
                this.Cursor = Cursors.WaitCursor;
                var FileExt = Path.GetExtension(fileName);
                if (FileExt.ToLower() == ".xls")
                    _table = Commons.Modules.MExcel.MGetData2xls(fileName);
                else if (FileExt.ToLower() == ".xlsx")
                    _table = Commons.Modules.MExcel.MGetData2xlsx(fileName);
                this.grdImport.DataSource = null;
                grvImport.Columns.Clear();
                if (_table != null)
                {
                    try
                    {
                        _table.Columns.Add("XOA", System.Type.GetType("System.Boolean"));
                    }
                    catch { }
                    try
                    {
                        _table.DefaultView.Sort = "[" + _table.Columns[3].ColumnName.ToString() + "],[" + _table.Columns[5].ColumnName.ToString() + "]";
                    }
                    catch { }

                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdImport, grvImport, _table, true, true, true, true);
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    grdImport.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private bool KiemDuLieuSo(DataRow dr, int iCot, string sTenKTra, double GTSoSanh, double GTMacDinh, Boolean bKiemNull)
        {
            string sDLKiem;
            sDLKiem = dr[grvImport.Columns[iCot].FieldName.ToString()].ToString();
            double DLKiem;
            if (bKiemNull)
            {
                if (string.IsNullOrEmpty(sDLKiem))
                {
                    dr.SetColumnError(grvImport.Columns[iCot].FieldName.ToString(), sTenKTra + " không được để trống");
                    dr["XOA"] = 1;
                    return false;
                }
                else
                {
                    if (!double.TryParse(dr[grvImport.Columns[iCot].FieldName.ToString()].ToString(), out DLKiem))
                    {
                        dr.SetColumnError(grvImport.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là số");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh)
                            {
                                dr.SetColumnError(grvImport.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn " + GTSoSanh.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }
                            DLKiem = Math.Round(DLKiem, 8);
                            dr[grvImport.Columns[iCot].FieldName.ToString()] = DLKiem.ToString();

                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(sDLKiem) && GTMacDinh != -999999)
                {
                    dr[grvImport.Columns[iCot].FieldName.ToString()] = GTMacDinh;
                    DLKiem = GTMacDinh;
                    sDLKiem = GTMacDinh.ToString();
                }

                if (!string.IsNullOrEmpty(sDLKiem))
                {
                    if (!double.TryParse(dr[grvImport.Columns[iCot].FieldName.ToString()].ToString(), out DLKiem))
                    {
                        dr.SetColumnError(grvImport.Columns[iCot].FieldName.ToString(), sTenKTra + " phải là số");
                        dr["XOA"] = 1;
                        return false;
                    }
                    else
                    {
                        if (GTSoSanh != -999999)
                        {
                            if (DLKiem < GTSoSanh)
                            {
                                dr.SetColumnError(grvImport.Columns[iCot].FieldName.ToString(), sTenKTra + " không được nhỏ hơn " + GTSoSanh.ToString());
                                dr["XOA"] = 1;
                                return false;
                            }

                            DLKiem = Math.Round(DLKiem, 8);
                            dr[grvImport.Columns[iCot].FieldName.ToString()] = DLKiem.ToString();
                        }

                    }
                }


            }



            return true;
        }
        private bool CheckSuccess(int item, int count)
        {
            if (item == count)
                return true;
            return false;
        }
        private int CheckLen(DataRow dr, int col, int giatri, int chieudai, string thongbao)
        {
            try
            {
                if (dr[grvImport.Columns[col].FieldName.ToString()] == DBNull.Value || dr[grvImport.Columns[col].FieldName.ToString()].ToString() == String.Empty)
                { giatri += 1; }
                else
                    if (dr[grvImport.Columns[col].FieldName.ToString()].ToString().Length > chieudai)
                {
                    dr.SetColumnError(grvImport.Columns[col].FieldName.ToString(), thongbao + " dài hơn " + chieudai + " ký tự." + "(" + dr[grvImport.Columns[col].FieldName.ToString()].ToString().Length.ToString() + ")");
                    dr["XOA"] = 1;
                    dr["LOI"] = 1;
                }
                else
                    giatri += 1;
                return giatri;
            }
            catch { return giatri; }
        }


        private void btnChonFile_Click(object sender, EventArgs e)
        {
            MLoadExcel();
        }
        private void grvImport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Bạn có chắc xóa dòng dữ liệu này ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                //GridView view = sender as GridView;
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                //view.DeleteRow(view.FocusedRowHandle);
                if (view.SelectedRowsCount != 0)
                {
                    view.GridControl.BeginUpdate();
                    List<int> selectedLogItems = new List<int>(view.GetSelectedRows());
                    for (int i = selectedLogItems.Count - 1; i >= 0; i--)
                    {
                        view.DeleteRow(selectedLogItems[i]);
                    }
                    view.GridControl.EndUpdate();
                }
                else if (view.FocusedRowHandle != GridControl.InvalidRowHandle)
                {
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //xóa những dòng được check
            try
            {
                DialogResult res = XtraMessageBox.Show("Bạn có chắc xóa dữ liệu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) return;
                _table.AcceptChanges();
                foreach (DataRow dr in _table.Rows)
                {
                    if (dr["XOA"].ToString() == "True")
                    {
                        dr.Delete();
                    }
                }
                _table.AcceptChanges();
            }
            catch
            {
                XtraMessageBox.Show("Không xóa được. Bạn vui lòng kiểm tra lại dữ liệu !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _table.AcceptChanges();
            }
        }
        private void KiemData(string Table, string Field, int dong, int Cot, DataRow row, GridColumn colums)
        {
            try
            {
                frmPopUp frmPopUp = new frmPopUp();
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "select * from " + Table));
                frmPopUp.TableSource = dt;
                if (frmPopUp.ShowDialog() == DialogResult.OK)
                    row[Cot] = frmPopUp.RowSelected[Field].ToString();
                grvImport.SetFocusedRowCellValue(colums, row[Cot]);
            }
            catch { }
        }

        //private void grvImport_ShownEditor(object sender, EventArgs e)
        //{
        //    ptChung = grvImport.GridControl.PointToClient(Control.MousePosition);
        //    grvImport.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);
        //}

        //private void ActiveEditor_DoubleClick(object sender, System.EventArgs e)
        //{
        //    DoRowDoubleClick(ptChung);
        //    grvImport.RefreshData();
        //}

        //private void DoRowDoubleClick(Point pt)
        //{
        //    DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = grvImport.CalcHitInfo(pt);
        //    System.Data.DataRow row = grvImport.GetDataRow(info.RowHandle);
        //    if (info.Column.AbsoluteIndex == 7 || info.Column.AbsoluteIndex == 9)
        //    {
        //        KiemData("CA", "CA", info.RowHandle, info.Column.AbsoluteIndex, row, info.Column);
        //    }
        //}
        private void frmImport_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}