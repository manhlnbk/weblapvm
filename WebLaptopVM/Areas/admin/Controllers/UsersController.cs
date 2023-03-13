using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebLaptopVM.Models;

namespace WebLaptopVM.Areas.admin.Controllers
{
    public class UsersController : Controller
    {
        private LaptopVMDbContext db = new LaptopVMDbContext();

        // GET: admin/Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Sex1);
            return View(users.ToList());
        }

        // GET: admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.Sex = new SelectList(db.Sexes, "Id", "Name");
            return View();
        }

        // POST: admin/Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Account,Password,Email,Phone_number,Address,Sex,Image")] User user)
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
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Sex = new SelectList(db.Sexes, "Id", "Name", user.Sex);
                return View(user);
            }
        }

        // GET: admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sex = new SelectList(db.Sexes, "Id", "Name", user.Sex);
            return View(user);
        }

        // POST: admin/Users/Edit/5
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
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Sex = new SelectList(db.Sexes, "Id", "Name", user.Sex);
                return View(user);
            }
        }

        // GET: admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
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
