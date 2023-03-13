using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebLaptopVM.Models;

namespace WebLaptopVM.Controllers
{
    public class UserController : Controller
    {
        private LaptopVMDbContext db = new LaptopVMDbContext();

        // GET: Users/Details/5
        public ActionResult Details()
        {
            string acc = Convert.ToString(Session["Account"]);
            User user = db.Users.FirstOrDefault(x => x.Account == acc);
            return View(user);
        }


        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            User user = db.Users.Find(id);
            ViewBag.Sex = new SelectList(db.Sexes, "Id", "Name", user.Sex);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Account,Password,Email,Phone_number,Address,Sex,Image")] User user)
        {
            try 
            {
                user.Image = "";
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/Images/User/" + FileName);
                    f.SaveAs(UploadPath);
                    user.Image = FileName;
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            catch
            {
                ViewBag.Sex = new SelectList(db.Sexes, "Id", "Name", user.Sex);
                return View(user);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
