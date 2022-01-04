using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OEE.Models;

namespace OEE.Controllers
{
    public class HomeController : Controller
    {
        private OEEDataContext db = new OEEDataContext();
        string us = "Admin";
        int nn = 0;
        string nx = "PM";
        public ActionResult Index() // máy
        {
            if (Session["Taikhoan"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Session["Username"] != null)
            {
                us = Session["Username"].ToString();
            }
            if (Session["NgonNgu"] != null)
            {
                nn = Convert.ToInt32(Session["NgonNgu"]);
            }
            if (Session["NXuong"] != null)
            {
                nx = Session["NXuong"].ToString();
            }

            var param1 = new SqlParameter();
            param1.ParameterName = "@NNgu";
            param1.SqlDbType = SqlDbType.Int;
            param1.SqlValue = nn;

            var param2 = new SqlParameter();
            param2.ParameterName = "@USERNAME";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.SqlValue = us;

            var param3 = new SqlParameter();
            param3.ParameterName = "@NXuong";
            param3.SqlDbType = SqlDbType.NVarChar;
            param3.SqlValue = nx;

            var lst = db.Database.SqlQuery<spLCD_Result>("spLCD @NNgu,@USERNAME,@NXuong", param1, param2, param3).ToList();
            //var lst = db.spGetData().ToList();
            if (lst.Count == 0)
            {
                return RedirectToAction("Detail", "Home");
            }
            return View(lst);
        }

        public ActionResult Detail() // biểu đồ
        {
            if (Session["Taikhoan"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var lst1 = db.spLCDFull().ToList();
            if (lst1.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(lst1);
        }
        public ActionResult getData()
        {
            try
            {
                var query = db.spLCDFull().ToList()
                    .GroupBy(t => t.COT1)
                    .Select(g => new
                    {
                        name = g.Key,
                        count = g.Sum(a => Convert.ToDouble(a.COT9BD)),
                        text = g.Sum(b => Convert.ToDouble(b.COT10BD)),
                        color = g.FirstOrDefault().MAUBD,
                        namedn9 = g.Single().DNCOT9BD,
                        namedn10 = g.Single().DNCOT10BD
                    }).ToList();
                //var qr = from s in query
                //         where s.count == 0 where s.text == 0
                //         select s;
                // xoá giá trị COT9BD và COT10BD nếu giá trị = 0
                query.RemoveAll(t => t.count == 0 && t.text == 0);

                return Json(query, JsonRequestBehavior.AllowGet);
            }
            catch (Exception objEX)
            {
                return Json(new { iserror = true, message = objEX.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}