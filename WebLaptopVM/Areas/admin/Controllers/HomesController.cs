using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLaptopVM.Areas.admin.Controllers
{
    public class HomesController : Controller
    {
        // GET: admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}