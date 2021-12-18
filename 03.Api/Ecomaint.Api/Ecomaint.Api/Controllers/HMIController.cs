﻿using Ecomaint.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
namespace CMMSApi.Controllers
{
    public class HMIController : Controller
    {
        public JsonResult GetDateNow()
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
        public JsonResult GetDowTimeByType(string ID_DownTimeType)
        {
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<DowtimeViewModel> list = new List<DowtimeViewModel>();
                listParameter.Add(new SqlParameter("@DownTimeTypeID", Convert.ToInt64(ID_DownTimeType)));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<DowtimeViewModel>("spApiGETDowTime", listParameter);
                if (list.Count == 0)
                {
                    list.Add(new DowtimeViewModel { MS_NGUYEN_NHAN = -1, TEN_NGUYEN_NHAN = "NON" });
                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new DowtimeViewModel { MS_NGUYEN_NHAN = -1, TEN_NGUYEN_NHAN = "NON" }, JsonRequestBehavior.AllowGet);

            }
        }
        //get dowtime leader có thể sữa được
        public JsonResult GetDowTime()
        {
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<DowtimeViewModel> list = new List<DowtimeViewModel>();
                listParameter.Add(new SqlParameter("@DownTimeTypeID", Convert.ToInt64(32)));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<DowtimeViewModel>("spApiGETDowTime", listParameter);
                if (list.Count == 0)
                {
                    list.Add(new DowtimeViewModel { MS_NGUYEN_NHAN = -1, TEN_NGUYEN_NHAN = "NON" });
                }
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new DowtimeViewModel { MS_NGUYEN_NHAN = -1, TEN_NGUYEN_NHAN = "NON" }, JsonRequestBehavior.AllowGet);
            }
        }
        //lấy loại dowtime ứng với có kế hoạch hay không có kế hoạch
        public JsonResult GetDowtimeType(string Planned)
        {
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<DowtimeTypeViewModel> list = new List<DowtimeTypeViewModel>();
                listParameter.Add(new SqlParameter("@Planned", Convert.ToBoolean(Convert.ToInt32(Planned))));
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
        public JsonResult GetOperator(string ID_HD, string CardID)
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
        public JsonResult GetProDuction(string MS_MAY)
        {
            try
            {
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
        //hàm cập nhật dữ liệu và trả về dữ liệu mới ứng với nút reset
        public JsonResult UpdateProDuction(string Data, string MS_MAY, string ID_NV)
        {
            try
            {
                //list chứa dữ liệu từ HMI
                List<ProductionViewModel> lstRequest = JsonConvert.DeserializeObject<List<ProductionViewModel>>(Data);
                List<SqlParameter> listParameter = new List<SqlParameter>();
                //insert dữ liệu  vào productionRun
                foreach (var item in lstRequest)
                {
                    if (item.RUN == 1)
                    {
                        listParameter = new List<SqlParameter>();
                        //insert dữ liệu vào productionRundetails
                        listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                        listParameter.Add(new SqlParameter("@ID_Operator", Convert.ToInt64(ID_NV)));
                        listParameter.Add(new SqlParameter("@ItemID", item.ItemID));
                        listParameter.Add(new SqlParameter("@PrOID", item.PROID));
                        listParameter.Add(new SqlParameter("@ActualQuantity", item.Actual));
                        Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiCreateProDuctionRun", listParameter);
                    }
                }
                listParameter = new List<SqlParameter>();
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                var lstnew = Ecomaint.Api.DBUtils.ExecuteSPList<ProductionViewModel>("spApiGetProDuction", listParameter);
                //add dữ liệu  của listnew không tồn tại vào lstRequest.
                foreach (var itemnew in lstnew)
                {
                    foreach (var item in lstRequest.Where(x => x.RUN == 1))
                    {
                        if (itemnew.ORDER == item.ORDER)
                        {
                            itemnew.Actual = item.Actual;
                            itemnew.RUN = item.RUN;
                        }
                    }
                }
                return Json(lstnew, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new ProductionViewModel { ORDER = "NON", QTY = 0, PLAN = 0, Actual = 0, RUN = 0, DataCollectionCycle = 0, WorkingCycle = 0, ItemID = -1, PROID = -1 }, JsonRequestBehavior.AllowGet);
            }
        }
        //cập nhật số lượn thực tế chỗ lấy 5p một lần
        public JsonResult UpdateSoLuong(string Data, string MS_MAY, string ID_NV)
        {
            int i = 1;
            try
            {
                //list chứa dữ liệu từ HMI
                List<ProductionViewModel> lstRequest = JsonConvert.DeserializeObject<List<ProductionViewModel>>(Data);
                i = 2;
                foreach (var item in lstRequest)
                {
                    if (item.RUN == 1)
                    {
                        List<SqlParameter> listParameter = new List<SqlParameter>();
                        //insert dữ liệu vào productionRundetails
                        listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                        listParameter.Add(new SqlParameter("@ID_Operator", Convert.ToInt64(ID_NV)));
                        listParameter.Add(new SqlParameter("@ItemID", item.ItemID));
                        listParameter.Add(new SqlParameter("@PrOID", item.PROID));
                        listParameter.Add(new SqlParameter("@ActualQuantity", item.Actual));
                        Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiCreateProDuctionRun", listParameter);
                    }
                }
                return Json(new ResulstViewModel { MS_TRANG_THAI = 1, TEN_TRANG_THAI = "Thành công", SO_DONG = lstRequest.Count }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
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

        #region dowtime
        //cập nhật thời gian ngừng mấy
        public JsonResult UpdateNgungMay(string tungay, string denngay, string MS_NGUYEN_NHAN, string Data, string MS_MAY, string ID_NV)
        {
            int i = 1;
            try
            {
                //list chứa dữ liệu từ HMI
                List<ProductionViewModel> lstRequest = JsonConvert.DeserializeObject<List<ProductionViewModel>>(Data);
                DateTime TN = DateTime.ParseExact(tungay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                DateTime DN = DateTime.ParseExact(denngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                Int64 ID_Operator = Convert.ToInt64(ID_NV);
                int MS_NguyenNhan = Convert.ToInt32(MS_NGUYEN_NHAN);
                i = 2;
                foreach (var item in lstRequest)
                {
                    if (item.RUN == 1)
                    {
                        List<SqlParameter> listParameter = new List<SqlParameter>();
                        //insert dữ liệu vào productionRundetails
                        listParameter.Add(new SqlParameter("@TU_GIO", TN));
                        listParameter.Add(new SqlParameter("@DEN_GIO",DN));
                        listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                        listParameter.Add(new SqlParameter("@ID_Operator", ID_Operator));
                        listParameter.Add(new SqlParameter("@ItemID", item.ItemID));
                        listParameter.Add(new SqlParameter("@PrOID", item.PROID));
                        listParameter.Add(new SqlParameter("@MS_NGUYEN_NHAN", MS_NguyenNhan));
                        Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiCapNhatDungMay", listParameter);
                    }
                }
                return Json(new ResulstViewModel {MS_TRANG_THAI = 1,TEN_TRANG_THAI ="Thành công",SO_DONG = lstRequest.Count }, JsonRequestBehavior.AllowGet);
            }
            catch
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
        public JsonResult BackNgungMay(string MS_MAY, string ID_NV,string NGAY)
        {
            int i = 1;
            try
            {
                Int64 ID_Operator = Convert.ToInt64(ID_NV);
                DateTime TNgay = DateTime.ParseExact(NGAY, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                i = 2;
                List<SqlParameter> listParameter = new List<SqlParameter>();
                listParameter.Add(new SqlParameter("@Ngay", TNgay));
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                listParameter.Add(new SqlParameter("@ID_Operator", ID_Operator));
                Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiXoaDungMay", listParameter);
                return Json(new ResulstViewModel { MS_TRANG_THAI = 1, TEN_TRANG_THAI = "Thành công", SO_DONG = 0}, JsonRequestBehavior.AllowGet);
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

        #region call department
        public JsonResult CallDepartMent(string Ngay,string MS_MAY,string MS_NGUYEN_NHAN, string ID_DepartMent)
        {
            int i = 1;
            try
            {
                //Int64 ID_Operator = Convert.ToInt64(ID_NV);
                //DateTime TNgay = DateTime.ParseExact(NGAY, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                //i = 2;
                //List<SqlParameter> listParameter = new List<SqlParameter>();
                //listParameter.Add(new SqlParameter("@Ngay", TNgay));
                //listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                //listParameter.Add(new SqlParameter("@ID_Operator", ID_Operator));
                //Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiXoaDungMay", listParameter);
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


        public JsonResult SendSupervisor(string Ngay, string MS_MAY)
        {
            int i = 1;
            try
            {
                DateTime TNgay = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                i = 2;
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<PhoneMailViewModel> list = new List<PhoneMailViewModel>();
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<PhoneMailViewModel>("spApiGETOperator", listParameter);
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
        private Boolean SendMail(List<PhoneMailViewModel> lstPhoneMail)
        {
            try
            {
                for (int i = 0; i < lstPhoneMail.Count; i++)
                {

                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
        #endregion
    }
}
