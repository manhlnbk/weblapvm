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
    public class ProductsController : Controller
    {
        private LaptopVMDbContext db = new LaptopVMDbContext();

        // GET: admin/Products
        public ActionResult Index(string sort)
        {
            var products = db.Products.Include(p => p.Category1).Include(p => p.StatusProduct);
            ViewBag.SapXep = String.IsNullOrEmpty(sort) ? "desc" : "";
            switch (sort)
            {
                case "desc":
                    products = products.OrderByDescending(x => x.Category);
                    break;
                default:
                    products = products.OrderBy(x => x.Category);
                    break;
            }
            return View(products.ToList());
        }

        // GET: admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Status = new SelectList(db.StatusProducts, "Id", "Name");
            return View();
        }

        // POST: admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Name,Price,Cost,Describe,Color,Weight,Made_of,RAM,CPU,Pin,Screen_size,Card,Hard_drive,Status,Image")] Product product)
        {
            try
            {
                product.Image = "";
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/Images/Product/" + FileName);
                    f.SaveAs(UploadPath);
                    product.Image = FileName;
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Category = new SelectList(db.Categories, "Id", "Name", product.Category);
                ViewBag.Status = new SelectList(db.StatusProducts, "Id", "Name", product.Status);
                return View(product);
            }
        }

        // GET: admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = new SelectList(db.Categories, "Id", "Name", product.Category);
            ViewBag.Status = new SelectList(db.StatusProducts, "Id", "Name", product.Status);
            return View(product);
        }

        // POST: admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Name,Price,Cost,Describe,Color,Weight,Made_of,RAM,CPU,Pin,Screen_size,Card,Hard_drive,Status,Image")] Product product)
        {
            try
            {
                product.Image = "";
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/Images/Product/" + FileName);
                    f.SaveAs(UploadPath);
                    product.Image = FileName;
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Category = new SelectList(db.Categories, "Id", "Name", product.Category);
                ViewBag.Status = new SelectList(db.StatusProducts, "Id", "Name", product.Status);
                return View(product);
            }
        }

        // GET: admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
