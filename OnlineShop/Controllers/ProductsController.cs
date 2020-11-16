using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            return View(product);
        }
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            ViewBag.Product = product;
            ViewBag.Category = product.Category;
            var categories = from cat in db.Categories
                             select cat;
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPut]
        public ActionResult Edit(int id, Product requestProduct)
        {
            try
            {
                Product product = db.Products.Find(id);
                if(TryUpdateModel(product))
                {
                    product.Title = requestProduct.Title;
                    product.Description = requestProduct.Description;
                    product.Price = requestProduct.Price;
                    product.CategoryId = requestProduct.CategoryId;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch(AmbiguousMatchException)
            {
                return View();
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}