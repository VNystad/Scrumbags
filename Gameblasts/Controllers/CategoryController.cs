using System.Collections.Generic;
using System.Linq;
using Gameblasts.Data;
using Gameblasts.Models.CategoryModels;
using Microsoft.AspNetCore.Mvc;

namespace Gameblasts.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }
        

        [HttpPost]
        public IActionResult ForumCategoryDemo()
        {
            var cats = db.Categories.Where(s =>  s.parent == null).ToList();
            return View(cats);
        }

        [HttpPost]
        public IActionResult ForumCategoryDemo(string SubCatName, string parentName)
        {
            CategoryModel topCat = db.Categories.Find(parentName);
            CategoryModel SubCat = db.Categories.Find(SubCatName, parentName);
            return View(SubCat.threads);
        }
    }
}
