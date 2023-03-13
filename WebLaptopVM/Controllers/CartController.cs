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
    public class CartController : Controller
    {
        private LaptopVMDbContext db = new LaptopVMDbContext();

        public ActionResult Index()
        {
            string acc = Convert.ToString(Session["Account"]);
            var us = db.Users.FirstOrDefault(x => x.Account == acc);
            var carts = db.Carts.Include(c => c.Product1).Include(c => c.User1).Where(x => x.User == us.Id);
            var ca = carts.Select(x => x.Price);
            var price = ca.Sum();
            Session["Price"] = price;
            return View(carts.ToList());
        }
        public ActionResult Create(int id)
        {

            Cart cart = new Cart();
            string acc = Convert.ToString(Session["Account"]);
            if (acc == null)
            {
                ViewBag.cart = "Vui lòng đăng nhập để thêm giỏ hàng!";
            }
            else
            {
                Product pr = db.Products.Find(id);
                var us = db.Users.FirstOrDefault(x => x.Account == acc);
                cart.Image = pr.Image;
                cart.Price = pr.Price;
                cart.Product = pr.Id;
                cart.User = us.Id;
                cart.Quantity = 1;
                db.Carts.Add(cart);
                db.SaveChanges();
                ViewBag.cart = "Thêm giỏ hàng thành công!";
            }
            return View(cart);
        }
        public ActionResult CreateO()
        {
            Order order = new Order();
            string acc = Convert.ToString(Session["Account"]);
            var us = db.Users.FirstOrDefault(x => x.Account == acc);
            var cart = db.Carts.FirstOrDefault(x => x.User == us.Id);
            while (cart != null)
            {
                var pr = db.Products.FirstOrDefault(x => x.Id == cart.Product);
                order.Product = cart.Product;
                order.User = us.Id;
                order.Phone_number = us.Phone_number;
                order.Profit = cart.Price - (pr.Cost * cart.Quantity);
                order.Quantity = cart.Quantity;
                order.Stutus = 1;
                order.Time_order = DateTime.Now;
                order.Address = us.Address;
                db.Orders.Add(order);
                db.Carts.Remove(cart);
                db.SaveChanges();
                cart = db.Carts.FirstOrDefault(x => x.User == us.Id);
            }
            ViewBag.cart = "Thêm đơn hàng thành công!";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id, int quantity)
        {
            Cart cart = db.Carts.Find(id);
            cart.Quantity = quantity;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
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
