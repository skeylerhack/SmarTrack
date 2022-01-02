using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OEE.Models;

namespace OEE.Controllers
{
    public class HomeController : Controller
    {
        private OEEDataContext db = new OEEDataContext();
        public ActionResult Index()
        {
            var lst = db.spGetData().ToList();
            if (lst.Count == 0)
            {
                return RedirectToAction("Detail", "Home");
            }
            return View(lst);
        }

        public ActionResult Detail()
        {
            var lst1 = db.spLCDFull().ToList();
            if (lst1.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(lst1);
        }
        public ActionResult getData()
        {
            var query = db.spLCDFull().ToList()
                .GroupBy(t => t.COT1)
                .Select(g => new
                {
                    name = g.Key,
                    count = g.Sum(a => Convert.ToInt32(a.COT9BD)),
                    text = g.Sum(b => Convert.ToInt32(b.COT10BD)),
                    color = g.FirstOrDefault().MAUBD,
                    namedn9 = g.Single().DNCOT9BD,
                    namedn10 = g.Single().DNCOT10BD

                }).ToList();
            query.RemoveAll(r => r.count == 0);
            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }
}