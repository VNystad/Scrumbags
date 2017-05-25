using System;
using System.Linq;
using System.Threading.Tasks;
using Gameblasts.Data;
using Gameblasts.Models.CategoryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ViewComponents
{
    public class Post : ViewComponent
    {
        private ApplicationDbContext db;

        public Post(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(PostComponentFormModel model)
        {
            /*This takes "count" of posts from database */
            var subCat = await db.Categories.Where(s => s.id == model.parentID).Include("threads").FirstAsync();
            return View(subCat.threads.Take(model.count).ToList());
            
        }
        
    }
}