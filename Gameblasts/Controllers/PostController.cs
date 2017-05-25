
using Gameblasts.Models.PostViewModels;
using Microsoft.AspNetCore.Mvc;
//using Gameblast.Models;
using System.Threading.Tasks;
using Gameblasts.Data;
using Microsoft.AspNetCore.Identity;
using Gameblasts.Models;
using Gameblasts.Controllers;
using Gameblasts.Models.CategoryModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Gameblasts.Controllers
{
    public class PostController : Controller
    {   
        
        private ApplicationDbContext ApplicationDbContext;
        private UserManager<ApplicationUser> UserManager { get; set; }
        private readonly SignInManager<ApplicationUser> SignInManager;
        
        
        public PostController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            
            this.ApplicationDbContext = db;
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(Post model)
        {   
            var user = await GetCurrentUserAsync();
            Post newpost = new Post(user, model.Title, model.Body, model.SubCategory);
            var subCat = ApplicationDbContext.Categories.Where(s => s.id == model.SubCategory).Include("threads").ToList().First();
            subCat.threads.Add(newpost);
            ApplicationDbContext.Posts.Add(newpost);
            user.PostCount++;
            ApplicationDbContext.SaveChanges();
            
            var catList = ApplicationDbContext.Categories.Where(s => s.parent == null).ToList();
            return View("../Category/Forum", catList);
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return UserManager.GetUserAsync(HttpContext.User);
        }
    }
}

