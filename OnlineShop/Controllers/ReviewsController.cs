using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public ActionResult New(int id)
        {
            ViewBag.ProductId = id;
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
        public ActionResult Edit(int id)
        {
            Review review = db.Reviews.Find(id);
            ViewBag.Review = review;
            return View();
        }
        [HttpPut]
        public ActionResult Edit(int id, Review requestReview)
        {
            try
            {
                Review review = db.Reviews.Find(id);
                if (TryUpdateModel(review))
                {
                    review.ReviewComment = requestReview.ReviewComment;
                    review.ReviewRating = requestReview.ReviewRating;
                    db.SaveChanges();
                }
                return Redirect("/Products/Show/" + review.ProductId);
            }
            catch(AmbiguousMatchException)
            {
                return View();
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}