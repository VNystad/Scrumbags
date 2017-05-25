using System.Collections.Generic;
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
            if (model.topCat)
            {
                var cats = await db.Categories.Where(s => s.parent.id == model.parentID).Include("threads").ToListAsync();
                List<Gameblasts.Models.Post> posts = new List<Gameblasts.Models.Post>();

                foreach (var cat in cats)
                {
                    if (cat.threads.Count != 0)
                        posts.Add(cat.threads.First());
                }
                if (!(posts.Count == 0))
                    return View(posts.FindAll(t => t.Date == posts.Max(e => e.Date)).ToList());
            }

            /*This takes "count" of posts from database */
            var subCat = await db.Categories.Where(s => s.id == model.parentID).Include("threads").FirstAsync();
            return View(subCat.threads.Take(model.count).ToList());
            
        }
        
    }
}