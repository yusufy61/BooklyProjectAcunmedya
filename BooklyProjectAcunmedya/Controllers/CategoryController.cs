using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooklyProjectAcunmedya.Data;
using BooklyProjectAcunmedya.Entities;

namespace BooklyProjectAcunmedya.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        BooklyContext _context = new BooklyContext();


        // GET: Category
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        public ActionResult CreateCategory(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Categories.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            var UpdatedCategory = _context.Categories.Find(category.CategoryId);
            UpdatedCategory.CategoryName = category.CategoryName;
            UpdatedCategory.ImageUrl = category.ImageUrl;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}