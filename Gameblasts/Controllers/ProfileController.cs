using System.Threading.Tasks;
using Gameblasts.Data;
using Gameblasts.Models;
using Gameblasts.Models.ProfileViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gameblasts.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly string _externalCookieScheme;

        public ProfileController(ApplicationDbContext applicationdbcontext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            db = applicationdbcontext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(string id)
        {
            if(id == null) return Content("Something went horribly wrong! Report issue to Martin Bråten and blame him");
            ApplicationUser user = /*HttpContext.Current.GetOwinContext()
            .GetUserManager<ApplicationUserManager>().FindById(ID).UserName;*/
            await _userManager.FindByNameAsync(id);
            if(user == null) return Content("Something went horribly wrong! Report issue to Martin Bråten and blame him");

            ProfileViewModel model = new ProfileViewModel();

            model.Username = user.UserName;
            model.PostCount = user.PostCount;
            model.MemberTitle = user.MemberTitle;
            model.SocialMediaNames = user.SocialMediaNames;
            model.Age = user.Age;
            model.Gender = user.Gender;
            model.Location = user.Location;
            model.AboutInfo = user.AboutInfo;
            model.RegisterDate = user.RegisterDate;

            return View("Index", model);
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        
    }
}