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

        public async Task<IViewComponentResult> InvokeAsync(string topCatID)
        {
            var topCatList = await db.Categories.Where(s => s.name.Contains(topCatID)).Include("children").Distinct().ToListAsync();
            var topCat = topCatList.First();
            return View(topCat);
        }
    }
}