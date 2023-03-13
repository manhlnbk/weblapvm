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
    public class OrderController : Controller
    {
        private LaptopVMDbContext db = new LaptopVMDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            string acc = Convert.ToString(Session["Account"]);
            var us = db.Users.FirstOrDefault(x => x.Account == acc);
            var orders = db.Orders.Include(o => o.Product1).Include(o => o.StatusOrder).Include(o => o.User1).Where(x => x.User == us.Id);
            return View(orders.ToList());
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
