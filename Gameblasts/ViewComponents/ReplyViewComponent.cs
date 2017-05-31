using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gameblasts.Data;
using Gameblasts.Models.CategoryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ViewComponents
{
    public class Reply : ViewComponent
    {
        private ApplicationDbContext db;

        public Reply(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(PostComponentFormModel model)
        {
            
            /*This takes "count" of posts from database */
            var subCat = await db.Posts.Where(s => s.Id == model.parentID).Include("replies").Include("User").Include("replies.User").FirstAsync();
            return View(subCat.replies.Take(model.count).ToList());
            
        }
        
    }
}