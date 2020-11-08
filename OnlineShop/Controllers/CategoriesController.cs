using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CategoriesController : Controller
    {
        private Models.AppContext db = new Models.AppContext();

        public ActionResult Index()
        {
            var categories = db.Categories;
            ViewBag.Categories = categories;
            return View();
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Show(int id)
        {
            Category category = db.Categories.Find(id);
            ViewBag.Category = category;
            return View();
        }
    }
}