using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ReviewsController : Controller
    {
        private Models.AppContext db = new Models.AppContext();

        public ActionResult Index()
        {
            var reviews = db.Reviews.Include("Product");
            ViewBag.Reviews = reviews;
            return View();
        }
        public ActionResult New()
        {
            var products = from prod in db.Products
                           orderby prod.Title
                           select prod;
            ViewBag.products = products;
            return View();
        }
        [HttpPost]
        public ActionResult New(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Show(int id)
        {
            Review review = db.Reviews.Find(id);
            ViewBag.Review = review;
            ViewBag.Product = review.Product;
            return View();
        }
    }
}