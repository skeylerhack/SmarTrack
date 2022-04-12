using Ecomaint.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
namespace CMMSApi.Controllers
{
    public class HMIController : Controller
    {
        public JsonResult GetDateNow(string MS_MAY, string HD)
        {
            try
            {
                DateNowViewModel now = new DateNowViewModel();
                now.DATE = DateTime.Now.Day;
                now.MONTH = DateTime.Now.Month;
                now.YEAR = DateTime.Now.Year;
                now.HOUR = DateTime.Now.Hour;
                now.MINUTE = DateTime.Now.Minute;
                now.SECOND = DateTime.Now.Second;
                return Json(now, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #region dowtimetype and dowtime cause
        //get dowtime theo loại
        public JsonResult GetDowTimeByType(string ID_DownTimeType, string MS_MAY, string HD)
        {
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<DowtimeViewModel> list = new List<DowtimeViewModel>();
                listParameter.Add(new SqlParameter("@DownTimeTypeID", Convert.ToInt64(ID_DownTimeType)));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<DowtimeViewModel>("spApiGETDowTime", listParameter);
                if (list.Count == 0)
                {
                    list.Add(new DowtimeViewModel { MS_NGUYEN_NHAN = -1, TEN_NGUYEN_NHAN = "NON", DINH_MUC = -1, AUTO_CYCLE = -1 });
                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new DowtimeViewModel { MS_NGUYEN_NHAN = -1, TEN_NGUYEN_NHAN = "NON", DINH_MUC = -1, AUTO_CYCLE = -1 }, JsonRequestBehavior.AllowGet);

            }
        }
        ////check login LCD
        //public bool CheckLoginLCD(string UserName, string Pass,string HD)
        //{
        //    return true;
        //}
        //get dowtime leader có thể sữa được
        public JsonResult GetDowTime(string MS_MAY, string HD)
        {
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<DowtimeViewModel> list = new List<DowtimeViewModel>();
                listParameter.Add(new SqlParameter("@DownTimeTypeID", Convert.ToInt64(32)));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<DowtimeViewModel>("spApiGETDowTime", listParameter);
                if (list.Count == 0)
                {
                    list.Add(new DowtimeViewModel { MS_NGUYEN_NHAN = -1, TEN_NGUYEN_NHAN = "NON", DINH_MUC = -1, AUTO_CYCLE = -1 });
                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new DowtimeViewModel { MS_NGUYEN_NHAN = -1, TEN_NGUYEN_NHAN = "NON", DINH_MUC = -1, AUTO_CYCLE = -1 }, JsonRequestBehavior.AllowGet);
            }
        }

        //getdepart ment
        public JsonResult GetDepartMent(string MS_MAY, string HD)
        {
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<DepartMentViewModel> list = new List<DepartMentViewModel>();
                list.Add(new DepartMentViewModel { ID_DepartMent = 1, Ten_DepartMent = "Bộ phận kỹ thuật" });
                list.Add(new DepartMentViewModel { ID_DepartMent = 2, Ten_DepartMent = "Bộ phận chất lượng" });
                list.Add(new DepartMentViewModel { ID_DepartMent = 3, Ten_DepartMent = "Bộ phận cung ứng" });
                if (list.Count == 0)
                {
                    list.Add(new DepartMentViewModel { ID_DepartMent = -1, Ten_DepartMent = "NON" });
                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new DepartMentViewModel { ID_DepartMent = -1, Ten_DepartMent = "NON" }, JsonRequestBehavior.AllowGet);
            }
        }

        //lấy loại dowtime ứng với có kế hoạch hay không có kế hoạch
        public JsonResult GetDowtimeType(string Planned, string MS_MAY, string HD)
        {
            try
            {
                //1 : là có kế hoạch
                // lớn hơn 1 là không có kế hoạch

                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<DowtimeTypeViewModel> list = new List<DowtimeTypeViewModel>();
                listParameter.Add(new SqlParameter("@Planned", Convert.ToInt32(Planned)));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<DowtimeTypeViewModel>("spApiGETDowTimeType", listParameter);
                if (list.Count == 0)
                {
                    list.Add(new DowtimeTypeViewModel { MS_LOAI = -1, TEN_LOAI = "NON" });
                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new DowtimeTypeViewModel { MS_LOAI = -1, TEN_LOAI = "NON" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region kiểm tra khi quẹc thẻ
        public JsonResult GetOperator(string ID_HD, string CardID, string MS_MAY, string HD)
        {
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<OperatorViewModel> list = new List<OperatorViewModel>();
                listParameter.Add(new SqlParameter("@ID_HANH_DONG", Convert.ToInt64(ID_HD)));
                listParameter.Add(new SqlParameter("@CardID", CardID));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<OperatorViewModel>("spApiGETOperator", listParameter);
                if (list.Count == 0)
                {
                    list.Add(new OperatorViewModel { ID_NV = -1, TEN_NV = "NON" });
                }
                return Json(list, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return Json(new OperatorViewModel { ID_NV = -1, TEN_NV = "NON" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region produc
        //lấy danh sách số lượn sản xuất
        public JsonResult GetProDuction(string MS_MAY, string HD)
        {
            try
            {
                UpdateHanhDongHMI(MS_MAY, HD, "GetProDuction", DateTime.Now);
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<ProductionViewModel> list = new List<ProductionViewModel>();
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<ProductionViewModel>("spApiGetProDuction", listParameter);
                if (list.Count == 0)
                {
                    list.Add(new ProductionViewModel { ORDER = "NON", QTY = 0, PLAN = 0, Actual = 0, RUN = 0, DataCollectionCycle = 0, WorkingCycle = 0, ItemID = -1, PROID = -1 });
                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new ProductionViewModel { ORDER = "NON", QTY = 0, PLAN = 0, Actual = 0, RUN = 0, DataCollectionCycle = 0, WorkingCycle = 0, ItemID = -1, PROID = -1 }, JsonRequestBehavior.AllowGet);
            }
        }
        //hàm cập nhật dữ liệu và trả về dữ liệu mới ứng với nút resfet
        public JsonResult UpdateProDuction(string Ngay, string Data, string MS_MAY, string ID_NV, string HD)
        {
            try
            {
                //list chứa dữ liệu từ HMI
                List<ProductionViewModel> lstRequest = JsonConvert.DeserializeObject<List<ProductionViewModel>>(Data);
                List<SqlParameter> listParameter = new List<SqlParameter>();
                //DateTime dNgay = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                DateTime dNgay = DateTime.Now;
                //insert dữ liệu  vào productionRun
                foreach (var item in lstRequest)
                {
                    //if (item.RUN == 1)
                    //{
                    listParameter = new List<SqlParameter>();
                    //insert dữ liệu vào productionRundetails
                    listParameter.Add(new SqlParameter("@Ngay", dNgay));
                    listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                    listParameter.Add(new SqlParameter("@ID_Operator", Convert.ToInt64(ID_NV)));
                    listParameter.Add(new SqlParameter("@ItemID", item.ItemID));
                    listParameter.Add(new SqlParameter("@PrOID", item.PROID));
                    listParameter.Add(new SqlParameter("@ActualQuantity", item.Actual));
                    listParameter.Add(new SqlParameter("@Run", item.RUN));
                    listParameter.Add(new SqlParameter("@HD", HD));
                    Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiCreateProDuctionRun", listParameter);
                    //}
                }
                if (lstRequest.Count(x => x.RUN == 1) == 0)
                {
                    listParameter = new List<SqlParameter>(0);
                    listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                    listParameter.Add(new SqlParameter("@TTHMI", 0));
                    Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiUnselectProduction", listParameter);
                }
                else
                {
                    listParameter = new List<SqlParameter>();
                    listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                    listParameter.Add(new SqlParameter("@TTHMI", 1));
                    Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiUnselectProduction", listParameter);
                }
                listParameter = new List<SqlParameter>();
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                var lstnew = Ecomaint.Api.DBUtils.ExecuteSPList<ProductionViewModel>("spApiGetProDuction", listParameter);

                //Dữ liệu đang chọn HMI
                List<ProductionViewModel> lstResulst = new List<ProductionViewModel>();
                lstResulst = lstRequest.Where(x => x.RUN == 1).ToList();
                //lấy những thèn của
                foreach (var itemnew in lstnew)
                {
                    foreach (var item in lstResulst)
                    {
                        if (itemnew.ItemID == item.ItemID)
                        {
                            if (itemnew.PROID == item.PROID)
                            {
                                //nếu cùng order thì cập nhật thông tin vào củ
                                itemnew.RUN = 1;
                                itemnew.Actual = item.Actual;
                            }
                            else
                            {
                                itemnew.RUN = 1;
                            }
                        }
                    }
                }
                return Json(lstnew, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                //UpdateStatusMay(MS_MAY, "0");
                return Json(new ProductionViewModel { ORDER = "NON", QTY = 0, PLAN = 0, Actual = 0, RUN = 0, DataCollectionCycle = 0, WorkingCycle = 0, ItemID = -1, PROID = -1 }, JsonRequestBehavior.AllowGet);
            }
        }

        //cập nhật số lượng thực tế chỗ lấy 5p một lần
        //public JsonResult UpdateSoLuong(string Ngay, string Data, string MS_MAY, string ID_NV, string HD)
        //{
        //    int i = 1;
        //    try
        //    {
        //        //list chứa dữ liệu từ HMI
        //        List<ProductionViewModel> lstRequest = JsonConvert.DeserializeObject<List<ProductionViewModel>>(Data);
        //        List<SqlParameter> listParameter = new List<SqlParameter>();
        //        DateTime dNgay = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
        //        i = 2;
        //        foreach (var item in lstRequest)
        //        {
        //            if (item.RUN == 1)
        //            {
        //                listParameter = new List<SqlParameter>();
        //                //insert dữ liệu vào productionRundetails
        //                listParameter.Add(new SqlParameter("@Ngay", dNgay));
        //                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
        //                listParameter.Add(new SqlParameter("@ID_Operator", Convert.ToInt64(ID_NV)));
        //                listParameter.Add(new SqlParameter("@ItemID", item.ItemID));
        //                listParameter.Add(new SqlParameter("@PrOID", item.PROID));
        //                listParameter.Add(new SqlParameter("@ActualQuantity", item.Actual));
        //                Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiCreateProDuctionRun", listParameter);
        //            }
        //            else
        //            {
        //                listParameter = new List<SqlParameter>();
        //                listParameter.Add(new SqlParameter("@Ngay", dNgay));
        //                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
        //                listParameter.Add(new SqlParameter("@ID_Operator", Convert.ToInt64(ID_NV)));
        //                listParameter.Add(new SqlParameter("@ItemID", item.ItemID));
        //                listParameter.Add(new SqlParameter("@PrOID", item.PROID));
        //                listParameter.Add(new SqlParameter("@ActualQuantity", item.Actual));
        //                Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiUpdateSoLuong", listParameter);
        //            }
        //        }
        //        if (lstRequest.Count(x => x.RUN == 1) == 0)
        //        {

        //            listParameter = new List<SqlParameter>();
        //            listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
        //            listParameter.Add(new SqlParameter("@TTHMI", 0));
        //            Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiUnselectProduction", listParameter);
        //        }
        //        else
        //        {
        //            listParameter = new List<SqlParameter>();
        //            listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
        //            listParameter.Add(new SqlParameter("@TTHMI", 1));
        //            Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiUnselectProduction", listParameter);
        //        }
        //        return Json(new ResulstViewModel { MS_TRANG_THAI = 1, TEN_TRANG_THAI = "Thành công", SO_DONG = lstRequest.Count }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch
        //    {
        //        if (i == 2)
        //        {
        //            return Json(new ResulstViewModel { MS_TRANG_THAI = 0, TEN_TRANG_THAI = "Thất bại", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new ResulstViewModel { MS_TRANG_THAI = 2, TEN_TRANG_THAI = "Lỗi dữ liệu", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //}
        #endregion

        #region dowtime
        //cập nhật thời gian ngừng mấy
        public JsonResult UpdateNgungMay(string tungay, string denngay, string MS_NGUYEN_NHAN, string Data, string MS_MAY, string ID_NV, string HD)
        {
            int i = 1;
            try
            {

                //list chứa dữ liệu từ HMI
                List<ProductionViewModel> lstRequest = JsonConvert.DeserializeObject<List<ProductionViewModel>>(Data);
                List<SqlParameter> listParameter = new List<SqlParameter>();
                DateTime TN = DateTime.ParseExact(tungay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                DateTime DN = DateTime.ParseExact(denngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                Int64 ID_Operator = Convert.ToInt64(ID_NV);
                int MS_NguyenNhan = Convert.ToInt32(MS_NGUYEN_NHAN);

                UpdateHanhDongHMI(MS_MAY, HD, MS_NGUYEN_NHAN, TN);

                if (MS_NguyenNhan == 22)
                {
                    //với nguyên nhân đang chờ người đứng mấy thì update số lượng
                    foreach (var item in lstRequest)
                    {
                        //if (item.RUN == 1)
                        //{
                        listParameter = new List<SqlParameter>();
                        //insert dữ liệu vào productionRundetails
                        listParameter.Add(new SqlParameter("@Ngay", TN));
                        listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                        listParameter.Add(new SqlParameter("@ID_Operator", Convert.ToInt64(ID_NV)));
                        listParameter.Add(new SqlParameter("@ItemID", item.ItemID));
                        listParameter.Add(new SqlParameter("@PrOID", item.PROID));
                        listParameter.Add(new SqlParameter("@ActualQuantity", item.Actual));
                        listParameter.Add(new SqlParameter("@Run", item.RUN));
                        listParameter.Add(new SqlParameter("@HD", HD));
                        Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiCreateProDuctionRun", listParameter);
                        //}
                    }

                } else
                {
                    if (MS_NguyenNhan != 21 || MS_NguyenNhan != 23 || MS_NguyenNhan != 62)
                    {
                        foreach (var item1 in lstRequest)
                        {
                            //if (item.RUN == 1)
                            //{
                            listParameter = new List<SqlParameter>();
                            listParameter.Add(new SqlParameter("@Ngay", DN));
                            listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                            listParameter.Add(new SqlParameter("@ID_Operator", Convert.ToInt64(ID_NV)));
                            listParameter.Add(new SqlParameter("@ItemID", item1.ItemID));
                            listParameter.Add(new SqlParameter("@PrOID", item1.PROID));
                            listParameter.Add(new SqlParameter("@ActualQuantity", item1.Actual));
                            listParameter.Add(new SqlParameter("@Run", item1.RUN));
                            listParameter.Add(new SqlParameter("@HD", HD));
                            Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiCreateProDuctionRun", listParameter);
                            //}
                        }
                    }    
                }    
                i = 2;
                List<CapNhatCa> Resulst = CapNhatCa(TN, DN);
                //kiểm tra nếu không có item nào đang chọn thì update  theo mấy thôi
                if (lstRequest.Count(x => x.RUN == 1) == 0)
                {
                    foreach (var item1 in Resulst)
                    {
                        listParameter = new List<SqlParameter>();
                        //insert dữ liệu vào productionRundetails
                        listParameter.Add(new SqlParameter("@TU_GIO", item1.NGAY_BD));
                        listParameter.Add(new SqlParameter("@DEN_GIO", item1.NGAY_KT));
                        listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                        listParameter.Add(new SqlParameter("@ID_Operator", ID_Operator));
                        listParameter.Add(new SqlParameter("@ItemID", 1));
                        listParameter.Add(new SqlParameter("@PrOID", 1));
                        listParameter.Add(new SqlParameter("@MS_NGUYEN_NHAN", MS_NguyenNhan));
                        listParameter.Add(new SqlParameter("@Loai", 1));
                        Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiCapNhatDungMay", listParameter);
                    }
                }
                else
                {
                    foreach (var item in lstRequest)
                    {
                        if (item.RUN == 1)
                        {
                            foreach (var item1 in Resulst)
                            {
                                listParameter = new List<SqlParameter>();
                                //insert dữ liệu vào productionRundetails
                                listParameter.Add(new SqlParameter("@TU_GIO", item1.NGAY_BD));
                                listParameter.Add(new SqlParameter("@DEN_GIO", item1.NGAY_KT));
                                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                                listParameter.Add(new SqlParameter("@ID_Operator", ID_Operator));
                                listParameter.Add(new SqlParameter("@ItemID", item.ItemID));
                                listParameter.Add(new SqlParameter("@PrOID", item.PROID));
                                listParameter.Add(new SqlParameter("@MS_NGUYEN_NHAN", MS_NguyenNhan));
                                listParameter.Add(new SqlParameter("@Loai", 2));
                                Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiCapNhatDungMay", listParameter);
                            }
                        }
                    }
                }
                return Json(new ResulstViewModel { MS_TRANG_THAI = 1, TEN_TRANG_THAI = "Thành công", SO_DONG = lstRequest.Count }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exx)
            {
                if (i == 2)
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 0, TEN_TRANG_THAI = "Thất bại", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 2, TEN_TRANG_THAI = "Lỗi dữ liệu", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);

                }
            }
        }
        //nut back HMI chờ leader
        public JsonResult BackNgungMay(string MS_MAY, string ID_NV, string NGAY, string HD)
        {
            int i = 1;
            try
            {
                Int64 ID_Operator = Convert.ToInt64(ID_NV);
                DateTime TNgay = DateTime.ParseExact(NGAY, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                UpdateHanhDongHMI(MS_MAY, HD, "" + ID_NV + "", TNgay);
                i = 2;
                List<SqlParameter> listParameter = new List<SqlParameter>();
                listParameter.Add(new SqlParameter("@Ngay", TNgay));
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                listParameter.Add(new SqlParameter("@ID_Operator", ID_Operator));
                Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiXoaDungMay", listParameter);
                return Json(new ResulstViewModel { MS_TRANG_THAI = 1, TEN_TRANG_THAI = "Thành công", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                if (i == 2)
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 0, TEN_TRANG_THAI = "Thất bại", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 2, TEN_TRANG_THAI = "Lỗi dữ liệu", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        public List<CapNhatCa> CapNhatCa(DateTime TN, DateTime DN)
        {
            DateTime TNgay = TN;
            DateTime DNgay = DN;
            List<DateTime> ListNgay = new List<DateTime>();
            ListNgay.Add(TN.AddDays(-1));
            //lấy tất cả các ngày có trong list
            do
            {
                ListNgay.Add(TN);
                TN = TN.AddDays(1);
            } while (TN.Date <= DN.Date);
            List<CapNhatCa> listResulst = new List<CapNhatCa>();
            for (int i = 0; i < ListNgay.Count; i++)
            {
                //lấy các ca của ngày hôm đó
                List<CapNhatCa> listCA = new List<CapNhatCa>();
                List<SqlParameter> listParameter = new List<SqlParameter>();
                listParameter.Add(new SqlParameter("@TN", ListNgay[i]));
                listCA = Ecomaint.Api.DBUtils.ExecuteSPList<CapNhatCa>("spAPIGet_CA", listParameter);
                if (ListNgay.Count() == 2 && listCA.Where(x => TNgay >= x.NGAY_BD && DNgay <= x.NGAY_KT).ToList().Count() == 1)
                {
                    var item = listCA.Where(x => TNgay >= x.NGAY_BD && DNgay <= x.NGAY_KT).FirstOrDefault();
                    item.NGAY_KT = DNgay;
                    item.NGAY_BD = TNgay;
                    listResulst.Add(item);
                    return listResulst;
                }
                //listCA = listCA.Where(x => TNgay >= x.NGAY_BD && DNgay <= x.NGAY_KT).ToList();
                //ngày bắc đầu nằm trong ca
                foreach (var item in listCA.Where(x => x.NGAY_BD <= DNgay))
                {
                    //kiểm tra từ ngày có nằm trong item không
                    if (TNgay >= item.NGAY_BD && TNgay < item.NGAY_KT)
                    {
                        //kiểm tra đến ngày có nhỏ hơn ngày kết thúc không
                        if (DN > item.NGAY_KT)
                        {
                            // Đến ngày lớn hơn ngày kết thúc
                            item.NGAY_BD = TNgay;
                            listResulst.Add(item);
                            TNgay = item.NGAY_KT;
                        }
                        else
                        {
                            // Đến ngày nhỏ hơn ngày kết thúc
                            item.NGAY_KT = DN;
                            listResulst.Add(item);
                            break;
                        }
                    }
                }
            }
            return listResulst;
        }
        #endregion

        #region call department

        public JsonResult SendSupervisor(string Ngay, string MS_MAY, string HD)
        {
            int i = 1;
            try
            {

                DateTime TNgay = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                UpdateHanhDongHMI(MS_MAY, HD, "SendSupervisor", DateTime.Now);
                i = 2;
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<PhoneMailViewModel> list = new List<PhoneMailViewModel>();
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                listParameter.Add(new SqlParameter("@VaiTro", 10));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<PhoneMailViewModel>("spApiSendSupervisor", listParameter);
                SendMail(list, TNgay);
                return Json(new ResulstViewModel { MS_TRANG_THAI = 1, TEN_TRANG_THAI = "Thành công", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                if (i == 2)
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 0, TEN_TRANG_THAI = "Thất bại", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 2, TEN_TRANG_THAI = "Lỗi dữ liệu", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public JsonResult SendTechnician(string Ngay, string MS_MAY, string ID_DepartMent, string HD)
        {
            int i = 1;
            try
            {
                DateTime TNgay = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                UpdateHanhDongHMI(MS_MAY, HD, "SendTechnician", DateTime.Now);
                i = 2;
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<PhoneMailViewModel> list = new List<PhoneMailViewModel>();
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                listParameter.Add(new SqlParameter("@ID_DEPARTMENT", ID_DepartMent));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<PhoneMailViewModel>("spApiSendTechnician", listParameter);
                SendMail(list, TNgay);
                return Json(new ResulstViewModel { MS_TRANG_THAI = 1, TEN_TRANG_THAI = "Thành công", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                if (i == 2)
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 0, TEN_TRANG_THAI = "Thất bại", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 2, TEN_TRANG_THAI = "Lỗi dữ liệu", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public JsonResult SendDepartMent(string Ngay, string MS_MAY, string ID_DepartMent, string HD)
        {
            int i = 1;
            try
            {
                DateTime TNgay = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                UpdateHanhDongHMI(MS_MAY, HD, "SendDepartMent", DateTime.Now);
                i = 2;
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<PhoneMailViewModel> list = new List<PhoneMailViewModel>();
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                listParameter.Add(new SqlParameter("@ID_DEPARTMENT", ID_DepartMent));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<PhoneMailViewModel>("spApiSendDepartMent", listParameter);
                SendMail(list, TNgay);
                return Json(new ResulstViewModel { MS_TRANG_THAI = 1, TEN_TRANG_THAI = "Thành công", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                if (i == 2)
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 0, TEN_TRANG_THAI = "Thất bại", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 2, TEN_TRANG_THAI = "Lỗi dữ liệu", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public JsonResult SendCeo(string Ngay, string MS_MAY, string HD)
        {
            int i = 1;
            try
            {
                DateTime TNgay = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                UpdateHanhDongHMI(MS_MAY, HD, "SendCeo", DateTime.Now);
                i = 2;
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<PhoneMailViewModel> list = new List<PhoneMailViewModel>();
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                listParameter.Add(new SqlParameter("@VaiTro", 9));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<PhoneMailViewModel>("spApiSendCeo", listParameter);
                SendMail(list, TNgay);
                return Json(new ResulstViewModel { MS_TRANG_THAI = 1, TEN_TRANG_THAI = "Thành công", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                if (i == 2)
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 0, TEN_TRANG_THAI = "Thất bại", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 2, TEN_TRANG_THAI = "Lỗi dữ liệu", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        #endregion

        #region hàm gửi mail
        private Boolean SendMail(List<PhoneMailViewModel> lstPhoneMail, DateTime Ngay)
        {
            try
            {
                string mailto = "";
                List<string> phone = new List<string>();
                foreach (var item in lstPhoneMail)
                {
                    mailto += item.MAIL + ";";
                    phone.Add(item.PHONE.Trim());
                }
                //mailto = "bamboo2711@gmail.com;thanhduc66@gmail.com;";
                //phone = new List<string>();
                //phone.Add("0337785544");
                //phone.Add("0866054222");
                string Mes = "<p>Máy :" + lstPhoneMail[0].MS_MAY + ",gặp sự cố từ: " + Ngay.ToString("dd/MM/yyyy HH:mm:ss") + "</p>";
                Thread thread = new Thread(() =>
                {
                    SendSMS(phone, "May :" + lstPhoneMail[0].MS_MAY + ",gap su co tu: " + Ngay.ToString("dd/MM/yyyy HH:mm:ss") + "");
                }, 60000);
                thread.Start();
                Thread thread1 = new Thread(() =>
                {
                    Ecomaint.Api.DBUtils.SendEmailCC(mailto, "WAHL-VN", Mes);
                }, 5000);
                thread1.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string TestSMS()
        {
            string Phone = "0866054222";
            string Mes = "Thanh Cong";
            try
            {
                //string Port = ConfigurationManager.AppSettings["sPort"].ToString();
                using (SerialPort Seriport = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One))
                {
                    if (!Seriport.IsOpen)
                    {
                        Seriport.Open();
                    }
                    Thread.Sleep(1000);
                    Seriport.Write("AT+CMGF=1\r");
                    Thread.Sleep(1000);
                    Seriport.Write("AT+CMGS=\"" + Phone + "\"\r\n");
                    Thread.Sleep(1000);
                    Seriport.Write(Mes + "\x1A");
                    Thread.Sleep(1000);
                    if (Seriport.IsOpen)
                    {
                        Seriport.Close();
                    }
                }
                return "Succes";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        //private void SendSMS(string Phone, string Mes)
        //{
        //    try
        //    {
        //        //string Port = ConfigurationManager.AppSettings["sPort"].ToString();
        //        using (SerialPort Seriport = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One))
        //        {
        //            if (!Seriport.IsOpen)
        //            {
        //                Seriport.Open();
        //            }
        //            Thread.Sleep(100);
        //            Seriport.Write("AT+CMGF=1\r");
        //            Thread.Sleep(100);

        //            Seriport.Write("AT+CMGS=\"" + Phone + "\"\r\n");
        //            Thread.Sleep(100);
        //            Seriport.Write(Mes + "\x1A");
        //            Thread.Sleep(100);


        //            if (Seriport.IsOpen)
        //            {
        //                Seriport.Close();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        private void SendSMS(List<string> Phone, string Mes)
        {
            try
            {
                string Port = ConfigurationManager.AppSettings["sPort"].ToString();
                using (SerialPort Seriport = new SerialPort(Port, 115200, Parity.None, 8, StopBits.One))
                {
                    if (!Seriport.IsOpen)
                    {
                        Seriport.Open();
                    }
                    Thread.Sleep(2000);
                    Seriport.Write("AT+CMGF=1\r");
                    Thread.Sleep(2000);
                    foreach (var item in Phone)
                    {
                        Seriport.Write("AT+CMGS=\"" + item + "\"\r\n");
                        Thread.Sleep(2000);
                        Seriport.Write(Mes + "\x1A");
                        Thread.Sleep(7000);
                    }
                    if (Seriport.IsOpen)
                    {
                        Seriport.Close();
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

        public JsonResult UpdatreConsumption(string Ngay, string MS_MAY, string I1, string I2, string I3, string U1, string U2, string U3, string W, string HD)
        {
            int i = 1;
            try
            {
                DateTime THOI_GIAN = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                decimal iI1 = Convert.ToDecimal(I1);
                decimal iI2 = Convert.ToDecimal(I2);
                decimal iI3 = Convert.ToDecimal(I3);
                decimal iU1 = Convert.ToDecimal(U1);
                decimal iU2 = Convert.ToDecimal(U2);
                decimal iU3 = Convert.ToDecimal(U3);
                decimal iW = Convert.ToDecimal(W);
                i = 2;
                List<SqlParameter> listParameter = new List<SqlParameter>();
                listParameter.Add(new SqlParameter("@THOI_GIAN", THOI_GIAN));
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                listParameter.Add(new SqlParameter("@I1", iI1));
                listParameter.Add(new SqlParameter("@I2", iI2));
                listParameter.Add(new SqlParameter("@I3", iI3));
                listParameter.Add(new SqlParameter("@U1", iU1));
                listParameter.Add(new SqlParameter("@U2", iU2));
                listParameter.Add(new SqlParameter("@U3", iU3));
                listParameter.Add(new SqlParameter("@W", iW));
                Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiUpdatreConsumption", listParameter);
                return Json(new ResulstViewModel { MS_TRANG_THAI = 1, TEN_TRANG_THAI = "Thành công", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                if (i == 2)
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 0, TEN_TRANG_THAI = "Thất bại", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 2, TEN_TRANG_THAI = "Lỗi dữ liệu", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public JsonResult UpdateStatusMay(string MS_MAY, string TT, string HD)
        {
            int i = 1;
            try
            {

                int TinhTrang = Convert.ToInt32(TT);

                if (TinhTrang == 3)
                {
                    UpdateHanhDongHMI(MS_MAY, HD, "UpdateStatusMay: " + TT + "", DateTime.Now);
                }
                i = 2;
                Ecomaint.Api.DBUtils.ExecNonQueryText("UPDATE dbo.MAY SET TT_HMI = " + TinhTrang + " WHERE MS_MAY = '" + MS_MAY + "'");
                return Json(new ResulstViewModel { MS_TRANG_THAI = 1, TEN_TRANG_THAI = "Thành công", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                if (i == 2)
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 0, TEN_TRANG_THAI = "Thất bại", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new ResulstViewModel { MS_TRANG_THAI = 2, TEN_TRANG_THAI = "Lỗi dữ liệu", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public JsonResult UpdateHanhDongHMI(string MS_MAY, string HD, string GT, DateTime Ngay)
        {
            try
            {
                //Ecomaint.Api.DBUtils.ExecNonQueryText("INSERT INTO dbo.HMIAction(May,Date,ButtonCode,Value)VALUES('"+MS_MAY+"','"+ date.ToString() + "','"+ HD +"','"+ GT + "')");
                List<SqlParameter> listParameter = new List<SqlParameter>();
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                listParameter.Add(new SqlParameter("@HD", HD));
                listParameter.Add(new SqlParameter("@GT", GT));
                listParameter.Add(new SqlParameter("@Ngay", DateTime.Now));
                Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiUpdateHMIAction", listParameter);

                return Json(new ResulstViewModel { MS_TRANG_THAI = 1, TEN_TRANG_THAI = "Thành công", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new ResulstViewModel { MS_TRANG_THAI = 0, TEN_TRANG_THAI = "Thất bại", SO_DONG = 0 }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}


