using System.Collections.Generic;
using System.Linq;
using Gameblasts.Data;
using Gameblasts.Models.CategoryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var cats = db.Categories.Where(s =>  s.parent == null).Include("children").ToList();
            return View(cats);
        }

        /*[HttpPost]
        public IActionResult ForumCategoryDemo(string SubCatName, string parentName)
        {
            var parent = db.Categories.Where(s => s.parent.name.Equals(parentName)).First();
            var SubCat = new CategoryModel(SubCatName, parent, null, null);
            db.Categories.Add(SubCat);
            parent.children.Add(SubCat);
            return View(SubCat.threads);
        }*/

        [HttpPost]
        public IActionResult AddCategoryDemo(CategoryModel newCat)
        {
            db.Categories.Add(newCat);
            db.SaveChanges();
            return View("ForumCategoryDemo", db.Categories.Where(s =>  s.parent == null).Include("children").ToList());
        }

        [HttpGet]
        public IActionResult AddCategoryDemo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSubCategoryDemo(CategoryFormModel model)
        {
            var parentCatList = db.Categories.Where(s => s.id == model.parentID).Include("children").Distinct().ToList();
            var parentCat = parentCatList.First();            
            var newCat = new CategoryModel(model.name, parentCat);
            parentCat.children.Add(newCat);
            db.Categories.Add(newCat);
            db.SaveChanges();
            return View("ForumCategoryDemo", db.Categories.Where(s =>  s.parent == null).Include("children").ToList());
        }
    }
}

