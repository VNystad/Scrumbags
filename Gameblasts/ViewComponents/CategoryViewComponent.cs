using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gameblasts.Models.CategoryModels;
using Gameblasts.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public CategoryViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }
/*
        public async Task<IViewComponentResult> InvokeAsync(string topCatID)
        {
            var topCatList = await db.Categories.Where(s => s.name.Contains(topCatID)).
            Where(s => s.parent == null).Include("children").Include("threads").Distinct().ToListAsync();

            var topCat = topCatList.First();
            return View(topCat);
        }*/

        public async Task<IViewComponentResult> InvokeAsync(CategoryFormModel model)
        {
            List<CategoryModel> topCatList;
            Console.WriteLine("Please");
            if (model.parentID != -1){
                topCatList = await db.Categories.Where(s => s.name.Equals(model.name)).
                Where(s => s.parent.id == model.parentID).Include("children").Include("threads").Distinct().ToListAsync();
            } else
            {
                Console.Write("null");
                topCatList = await db.Categories.Where(s => s.name.Equals(model.name)).
                Where(s => s.parent == null).Include("children").Include("threads").Distinct().ToListAsync();
            }

            var topCat = topCatList.First();
            return View(topCat);
        }
    }
}