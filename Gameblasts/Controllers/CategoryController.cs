using System.Collections.Generic;
using System.Linq;
using Gameblasts.Data;
using Gameblasts.Models;
using Gameblasts.Models.CategoryModels;
using Gameblasts.Models.PostViewModels;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Forum()
        {
            var catList = db.Categories.Where(s => s.parent == null).ToList();
            return View(catList);
        }

<<<<<<< 1daee231d288137c37d26704bfb3dcc93d3e5417
=======
        
        [Authorize(Roles = "admin")]
>>>>>>> Added view for adding categories
        [HttpPost]
        public IActionResult CreateCategory(CategoryFormModel model)
        {
            CategoryModel newCat;
            if (db.Categories.Find(model.parentID) != null)
            {
            var parentCatList = db.Categories.Where(s => s.id == model.parentID).Include("children").Distinct().ToList();
            var parentCat = parentCatList.First();           
                newCat = new CategoryModel(model.name, parentCat, model.imageURL);
                parentCat.children.Add(newCat);
            } else
                newCat = new CategoryModel(model.name, null, model.imageURL);

            db.Categories.Add(newCat);
            db.SaveChanges();
            return View("Forum", db.Categories.Where(s =>  s.parent == null).Include("children").ToList());
        }

        [Authorize(Roles = "admin")]
        public IActionResult AddCategory(CategoryFormModel formModel)
        {
            var model = new CategoryModel(null, db.Categories.Find(formModel.parentID), null);
            return View(model);
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

        [HttpPost]
        public IActionResult ForumPost(CategoryModel category)
        {
            if (category == null)
                return View("../Home/Forum");

            var model = new Post(null, null, null, category.id);
            return View(model);
        }

        public IActionResult OpenCategory(string name)
        {
            return ViewComponent("Category", new Gameblasts.Models.CategoryModels.CategoryFormModel(name, -1));
        }
    }
}

