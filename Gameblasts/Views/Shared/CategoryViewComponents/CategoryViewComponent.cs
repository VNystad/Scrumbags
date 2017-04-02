using System.Threading.Tasks;
using CategoryModels;
using Gameblasts.Data;
using Microsoft.AspNetCore.Mvc;

namespace CategoryViewComponents
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