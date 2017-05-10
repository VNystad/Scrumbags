using System.Collections.Generic;
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
        public IActionResult Forum(string topCatName)
        {
            CategoryModel topCat = db.topCategories.Find(topCatName);
            return View(topCat.children);
        }

        [HttpPost]
        public IActionResult Forum(string SubCatName, string parentName)
        {
            CategoryModel topCat = db.topCategories.Find(parentName);
            CategoryModel SubCat = db.subCategories.Find(SubCatName, parentName);
            return View(SubCat.threads);
        }

    
    }
}
