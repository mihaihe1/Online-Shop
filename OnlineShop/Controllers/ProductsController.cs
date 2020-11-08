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
        private Models.AppContext db = new Models.AppContext();

        public ActionResult Index()
        {
            var products = db.Products.Include("Category");
            ViewBag.Products = products;
            return View();
        }
        public ActionResult New()
        {
            var categories = from cat in db.Categories
                             orderby cat.CategoryName
                             select cat;
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult New(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Show(int id)
        {
            Product product = db.Products.Find(id);
            ViewBag.Product = product;
            ViewBag.Category = product.Category;
            return View();
        }



    }
}