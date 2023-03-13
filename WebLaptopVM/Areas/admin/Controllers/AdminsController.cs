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
    public class AdminsController : Controller
    {
        private LaptopVMDbContext db = new LaptopVMDbContext();

        // GET: admin/Admins
        public ActionResult Index(string sort)
        {
            var admins = db.Admins.Include(a => a.Level1).Include(a => a.Sex1);
            ViewBag.SapXep = String.IsNullOrEmpty(sort) ? "desc" : ""; 
            switch (sort)
            {
                case "desc":
                    admins = admins.OrderByDescending(x => x.Level);
                    break;
                default:
                    admins = admins.OrderBy(x => x.Level);
                    break;
            }
            return View(admins.ToList());
        }

        // GET: admin/Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: admin/Admins/Create
        public ActionResult Create()
        {
            ViewBag.Level = new SelectList(db.Levels, "Id", "Name");
            ViewBag.Sex = new SelectList(db.Sexes, "Id", "Name");
            return View();
        }

        // POST: admin/Admins/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Account,Password,Email,Phone_number,Address,Sex,Level,Image")] Admin admin)
        {
            try
            {
                admin.Image = "";
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/Images/Admin/" + FileName);
                    f.SaveAs(UploadPath);
                    admin.Image = FileName;
                }
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Level = new SelectList(db.Levels, "Id", "Name", admin.Level);
                ViewBag.Sex = new SelectList(db.Sexes, "Id", "Name", admin.Sex);
                return View(admin);
            }
        }

        // GET: admin/Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            ViewBag.Level = new SelectList(db.Levels, "Id", "Name", admin.Level);
            ViewBag.Sex = new SelectList(db.Sexes, "Id", "Name", admin.Sex);
            return View(admin);
        }

        // POST: admin/Admins/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Account,Password,Email,Phone_number,Address,Sex,Level,Image")] Admin admin)
        {
            try
            {
                admin.Image = "";
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/Images/Admin/" + FileName);
                    f.SaveAs(UploadPath);
                    admin.Image = FileName;
                }
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Level = new SelectList(db.Levels, "Id", "Name", admin.Level);
                ViewBag.Sex = new SelectList(db.Sexes, "Id", "Name", admin.Sex);
                return View(admin);
            }
        }

        // GET: admin/Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: admin/Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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
