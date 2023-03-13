using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptopVM.Models;

namespace WebLaptopVM.Areas.admin.Controllers
{
    public class LoginsController : Controller
    {
        LaptopVMDbContext db = new LaptopVMDbContext();
        // GET: admin/Logins
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string account, string password)
        {
            if(account == "")
            {
                ViewBag.errLogin = "Vui lòng nhập tài khoản!";
                return View("Index");
            }
            if(password == "")
            {
                ViewBag.errLogin = "Vui lòng nhập mật khẩu!";
                return View("Index");
            }
            var ad = db.Admins.FirstOrDefault(x => x.Account == account && x.Password == password);
            if(ad == null)
            {
                ViewBag.errLogin = "Sai tên đăng nhập hoặc mật khẩu!";
                return View("Index");
            }
            else
            {
                Session["Account"] = account;
                return RedirectToAction("Index", "Homes");
            }
        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            return RedirectToAction("Index");
        }
    }
}