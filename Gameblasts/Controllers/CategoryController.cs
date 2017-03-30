using System.Collections.Generic;
using CategoryModels;
using Gameblasts.Data;
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
        
        [HttpGet]
        public IActionResult ForumCategoryDemo()

        {
            return View();
        }

        [HttpPost]
        public IActionResult ForumCategoryDemo(string topCatName)
        {
            TopCategoryModel topCat = db.topCategories.Find(topCatName);
            return View(topCat.children);
        }

        [HttpPost]
        public IActionResult ForumCategoryDemo(string SubCatName, string parentName)
        {
            TopCategoryModel topCat = db.topCategories.Find(parentName);
            SubCategoryModel SubCat = db.subCategories.Find(SubCatName, parentName);
            return View(SubCat.threads);
        }
    }
}
