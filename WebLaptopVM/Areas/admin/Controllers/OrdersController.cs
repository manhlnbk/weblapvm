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
    public class OrdersController : Controller
    {
        private LaptopVMDbContext db = new LaptopVMDbContext();

        // GET: admin/Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Product1).Include(o => o.StatusOrder).Include(o => o.User1);
            return View(orders.ToList());
        }

        // GET: admin/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Stutus = new SelectList(db.StatusOrders, "Id", "Name", order.Stutus);
            ViewBag.Product = new SelectList(db.Products, "Id", "Name", order.Product);
            ViewBag.User = new SelectList(db.Users, "Id", "Name", order.User);
            return View(order);
        }
        // POST: admin/Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int Stutus)
        {
            Order order = db.Orders.Find(id);
            order.Stutus = Stutus;
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
