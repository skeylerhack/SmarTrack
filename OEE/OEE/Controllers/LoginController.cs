using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OEE.Models;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Web.Security;

namespace OEE.Controllers
{
    public class LoginController : Controller
    {

        private OEEDataContext db = new OEEDataContext();
        // GET: Login
        public ActionResult Login()
        {
            ViewBag.MS_N_XUONG = new SelectList(db.NHA_XUONG.ToList().OrderBy(n => n.Ten_N_XUONG), "MS_N_XUONG", "Ten_N_XUONG");       
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc, Login loginDetails)
        {
            ViewBag.MS_N_XUONG = new SelectList(db.NHA_XUONG.ToList().OrderBy(n => n.Ten_N_XUONG), "MS_N_XUONG", "Ten_N_XUONG");
            var username = fc["txtUSERNAME"];
            var pass = fc["txtPASS"];
            var NNgu = fc["txtNgonNgu"];
            var NX = fc["txtNX"];
            if (string.IsNullOrEmpty(username))
            {
                ViewBag.ThongBao = "Phải nhập tên đăng nhập";
            }
            else if (string.IsNullOrEmpty(pass))
            {
                ViewBag.ThongBao = "Phải nhập mật khẩu";
            }
            else
            {
                USER dn = db.USERS.SingleOrDefault(n => n.USERNAME == username);
                if (dn != null)
                {
                    if (GiaiMaDL(dn.PASS) == pass)
                    {
                        //Session["Taikhoan"] = dn;
                        //Session["Username"] = fc["txtUSERNAME"];
                        //Session["NgonNgu"] = NNgu;
                        //Session["NXuong"] = NX;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                        return View();
                    }
                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return View();
                }
            }
            return View();
        }


        private string GiaiMaDL(string str)
        {
            double dLen = str.Length;
            string sTam = "";
            for (int i = 1; i <= dLen; i++)
                sTam += Strings.ChrW((Strings.AscW(Strings.Mid(str, i, 1)) / 2) - 354).ToString();
            return sTam;
        }    

    }
}