using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptopVM.Models;

namespace WebLaptopVM.Areas.admin.Controllers
{
    public class RevenuesController : Controller
    {
        LaptopVMDbContext db = new LaptopVMDbContext();
        // GET: admin/Revenues
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Revenue(DateTime d1, DateTime d2)
        {
            var re = db.Orders.Where(x => x.Time_order > d1 && x.Time_order < d2);
            re = re.Where(x => x.Stutus == 5);
            var re1 = re.Select(x => x.Profit);
            var profit = re1.Sum();
            Session["profit"] = profit;
            return View(re.ToList());
        }
    }
}