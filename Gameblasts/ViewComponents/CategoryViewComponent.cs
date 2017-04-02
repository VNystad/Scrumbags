using System.Collections.Generic;
using System.Linq;
using CategoryModels;
using Gameblasts.Data;
using Microsoft.AspNetCore.Mvc;

namespace ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public CategoryViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(string topCatName)
        {

            TopCategoryModel topCat = await db.topCategories.FindAsync(topCatName);
            return View(topCat.children);
        }
    }
}