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

        //getdepart ment
        public JsonResult GetDepartMent()
        {
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<DepartMentViewModel> list = new List<DepartMentViewModel>();
                list.Add(new DepartMentViewModel { ID_DepartMent = 1, Ten_DepartMent = "Sự cố máy"});
                list.Add(new DepartMentViewModel { ID_DepartMent = 2, Ten_DepartMent = "Sự cố chất lượng"});
                list.Add(new DepartMentViewModel { ID_DepartMent = 3, Ten_DepartMent = "Sự cố logistic"});
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
        public JsonResult UpdateProDuction(string Ngay, string Data, string MS_MAY, string ID_NV)
        {
            try
            {
                //list chứa dữ liệu từ HMI
                List<ProductionViewModel> lstRequest = JsonConvert.DeserializeObject<List<ProductionViewModel>>(Data);
                List<SqlParameter> listParameter = new List<SqlParameter>();
                DateTime dNgay = DateTime.ParseExact(Ngay,"dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                //insert dữ liệu  vào productionRun
                foreach (var item in lstRequest)
                {
                    if (item.RUN == 1)
                    {
                        listParameter = new List<SqlParameter>();
                        //insert dữ liệu vào productionRundetails
                        listParameter.Add(new SqlParameter("@Ngay", dNgay));
                        listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                        listParameter.Add(new SqlParameter("@ID_Operator", Convert.ToInt64(ID_NV)));
                        listParameter.Add(new SqlParameter("@ItemID", item.ItemID));
                        listParameter.Add(new SqlParameter("@PrOID", item.PROID));
                        listParameter.Add(new SqlParameter("@ActualQuantity", item.Actual));
                        Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiCreateProDuctionRun", listParameter);
                    }
                    else
                    {
                        listParameter = new List<SqlParameter>();
                        listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                        Ecomaint.Api.DBUtils.ExecNonQuerySP("spApiUnselectProduction", listParameter);
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
        public JsonResult UpdateSoLuong(string Ngay,string Data, string MS_MAY, string ID_NV)
        {
            int i = 1;
            try
            {
                //list chứa dữ liệu từ HMI
                List<ProductionViewModel> lstRequest = JsonConvert.DeserializeObject<List<ProductionViewModel>>(Data);
                DateTime dNgay = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                i = 2;
                foreach (var item in lstRequest)
                {
                    if (item.RUN == 1)
                    {
                        List<SqlParameter> listParameter = new List<SqlParameter>();
                        //insert dữ liệu vào productionRundetails
                        listParameter.Add(new SqlParameter("@Ngay", dNgay));
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
                        listParameter.Add(new SqlParameter("@DEN_GIO", DN));
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

        public JsonResult SendTechnician(string Ngay, string MS_MAY, string ID_DepartMent)
        {
            int i = 1;
            try
            {
                DateTime TNgay = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                i = 2;
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<PhoneMailViewModel> list = new List<PhoneMailViewModel>();
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                listParameter.Add(new SqlParameter("@VaiTro", 10));
                list = Ecomaint.Api.DBUtils.ExecuteSPList<PhoneMailViewModel>("spApiSendSupervisor", listParameter);
                SendMail(list,TNgay);
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

        public JsonResult SendDepartMent(string Ngay, string MS_MAY, string ID_DepartMent)
        {
            int i = 1;
            try
            {
                DateTime TNgay = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                i = 2;
                List<SqlParameter> listParameter = new List<SqlParameter>();
                List<PhoneMailViewModel> list = new List<PhoneMailViewModel>();
                listParameter.Add(new SqlParameter("@MS_MAY", MS_MAY));
                listParameter.Add(new SqlParameter("@VaiTro", 10));
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

        public JsonResult SendCeo(string Ngay, string MS_MAY)
        {
            int i = 1;
            try
            {
                DateTime TNgay = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
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
        private Boolean SendMail(List<PhoneMailViewModel> lstPhoneMail,DateTime Ngay)
        {
            try
            {
                string mailto = "";
                foreach (var item in lstPhoneMail)
                {
                    mailto += item.MAIL;
                    SendSMS(item.PHONE, "Máy :" + lstPhoneMail[0].MS_MAY + "hien tai dang bi ngung luc: " + Ngay.ToShortDateString()+ "");
                }
                string Mes = "<p>Máy :" + lstPhoneMail[0].MS_MAY + "hiện tại" +
                    " đang bị ngừng lúc: " + Ngay.ToShortDateString()+ "</p>";
                Ecomaint.Api.DBUtils.SendEmailCC(mailto,"WAHL-WON",Mes);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        private void SendSMS(string Phone,string Mes)
        {
            SerialPort sp = new SerialPort();
            try
            {
                sp.PortName = ConfigurationManager.AppSettings["sPort"].ToString();
                sp.Open();
                sp.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGS=\"" + Phone + "\"" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine(Mes + Environment.NewLine);
                Thread.Sleep(100);
                sp.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);
                var response = sp.ReadExisting();
                sp.Close();

            }
            catch
            {
                sp.Close();
            }
        }

        #endregion

        public JsonResult UpdatreConsumption(string Ngay,string MS_MAY, string I1, string I2, string I3, string U1, string U2,string U3,string W)
        {
            int i = 1;
            try
            {
                DateTime THOI_GIAN = DateTime.ParseExact(Ngay, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture);
                int iI1 = Convert.ToInt32(I1);
                int iI2 = Convert.ToInt32(I2);
                int iI3 = Convert.ToInt32(I3);
                int iU1 = Convert.ToInt32(U1);
                int iU2 = Convert.ToInt32(U2);
                int iU3 = Convert.ToInt32(U3);
                int iW = Convert.ToInt32(W);
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
    }
}
