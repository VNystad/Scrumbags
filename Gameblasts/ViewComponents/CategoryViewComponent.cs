using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gameblasts.Models.CategoryModels;
using Gameblasts.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            CategoryModel topCat = await db.topCategories.FindAsync(topCatName);
            return View(topCat.children);
        }
    }
}