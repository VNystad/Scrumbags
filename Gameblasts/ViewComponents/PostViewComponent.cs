using System;
using System.Linq;
using System.Threading.Tasks;
using Gameblasts.Data;
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

        public async Task<IViewComponentResult> InvokeAsync(int count = 0)
        {
            /*This takes "count" of posts from database */
            return View(db.Posts.Include(p => p.User).Take(count).ToList());
            
        }
        
    }
}