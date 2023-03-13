using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptopVM.Models;

namespace WebLaptopVM.Controllers
{
    public class LoginController : Controller
    {
        LaptopVMDbContext db = new LaptopVMDbContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string account, string password)
        {
            if (account == "")
            {
                ViewBag.erLogin = "Vui lòng nhập tài khoản!";
                return View("Index");
            }
            if (password == "")
            {
                ViewBag.erLogin = "Vui lòng nhập mật khẩu!";
                return View("Index");
            }
            var user = db.Users.FirstOrDefault(x => x.Account == account && x.Password == password);
            if (user == null)
            {
                ViewBag.erLogin = "Sai tên đăng nhập hoặc mật khẩu!";
                return View("Index");
            }
            else
            {
                Session["Account"] = account;
                return RedirectToAction("Index", "Home");
            }
        }
        
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string fullname, string account, string password, string cfpassword)
        {
            var use = db.Users.FirstOrDefault(x => x.Account == account);
            if (use != null)
            {
                ViewBag.errCr = "Tài khoản đã tồn tại!";
                return View(use);
            }
            else
            {
                if(password != cfpassword)
                {
                    ViewBag.errCr = "Confirm Password không trùng khớp!";
                    return View(use);
                }  
                else
                {
                    User user = new User();
                    user.Name = fullname;
                    user.Account = account;
                    user.Password = password;
                    user.Email = "0";
                    user.Phone_number = "0";
                    user.Address = "0";
                    user.Image = "0";
                    user.Sex = true;
                    db.Users.Add(user);
                    db.SaveChanges();
                    ViewBag.errCr = "Tạo tài khoản thành công!";
                    return View(user);
                }    
            }
        }
    }
}