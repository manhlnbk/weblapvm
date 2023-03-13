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
    public class HomeController : Controller
    {
        LaptopVMDbContext db = new LaptopVMDbContext();
        public ActionResult Index(string search)
        {
            var pr = db.Products.Select(x => x);
            if(search != null)
            {
                pr = pr.Where(x => x.Name.Contains(search));
            }
            return View(pr.ToList());
        }
        [ChildActionOnly]
        public PartialViewResult CateMenu()
        {
            var li = db.Categories.ToList();
            return PartialView(li);
        }
        [Route("LocTheoHang/{id}")]
        public ActionResult PrFromCate(int id)
        {
            var ca = db.Categories.Find(id);
            Session["Cate"] = ca.Name;
            var li = db.Products.Where(x => x.Category == id);
            return View(li.ToList());
        }
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
        public ActionResult Logout()
        {
            Session["Account"] = null;
            return RedirectToAction("Index");
        }
        public ActionResult CreateC(int id)
        {
            Cart cart = new Cart();
            Product pr = db.Products.Find(id);
            string acc = Convert.ToString(Session["Account"]);
            var us = db.Users.FirstOrDefault(x => x.Account == acc);
            cart.Image = pr.Image;
            cart.Price = pr.Price;
            cart.Product = pr.Id;
            cart.User = us.Id;
            cart.Quantity = 1;
            db.Carts.Add(cart);
            db.SaveChanges();
            ViewBag.cart = "Thêm giỏ hàng thành công!";
            return RedirectToAction("Details", new {id = pr.Id});
        }
        public ActionResult CreateO(int id, int quantity)
        {
            Order order = new Order();
            Product pr = db.Products.Find(id);
            string acc = Convert.ToString(Session["Account"]);
            var us = db.Users.FirstOrDefault(x => x.Account == acc);
            order.Product = pr.Id;
            order.User = us.Id;
            order.Phone_number = us.Phone_number;
            order.Profit = pr.Price - pr.Cost;
            order.Quantity = quantity;
            order.Stutus = 1;
            order.Time_order = DateTime.Now;
            order.Address = us.Address;
            db.Orders.Add(order);
            db.SaveChanges();
            ViewBag.cart = "Thêm đơn hàng thành công!";
            return RedirectToAction("Details", new { id = pr.Id });
        }
    }
}