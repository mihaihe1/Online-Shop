using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDBContext db = new ProductDBContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}