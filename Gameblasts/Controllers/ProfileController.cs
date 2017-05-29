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

        public ProfileController(ApplicationDbContext applicationdbcontext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            db = applicationdbcontext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Profile(string id)
        {
            if(id == null) return Content("Something went horribly wrong! Report issue to Martin Bråten and blame him");
            ApplicationUser user = await _userManager.FindByNameAsync(id);
            if(user == null) return Content("Something went horribly wrong! Report issue to Martin Bråten and blame him");

            ProfileViewModel model = new ProfileViewModel();

            model.Username = user.UserName;
            model.ImgAdress = user.ImgAdress;
            model.PostCount = user.PostCount;
            model.MemberTitle = user.MemberTitle;
            model.SocialMediaNames = user.SocialMediaNames;
            model.Age = user.Age;
            model.Gender = user.Gender;
            model.Location = user.Location;
            model.About = user.About;
            model.RegisterDate = user.RegisterDate;

            return View("Profile", model);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(string id)
        {
            if(id == null) return Content("Something went horribly wrong! Report issue to Martin Bråten and blame him");
            var user = await _userManager.FindByNameAsync(id);
            if (user == null) return Content("Something went horribly wrong! Report issue to Martin Bråten and blame him");

            EditProfileViewModel model = new EditProfileViewModel();

            model.Username = id;
            model.ImgAdress = user.ImgAdress;
            model.SocialMediaNames = user.SocialMediaNames;
            model.Age = user.Age;
            model.Gender = user.Gender;
            model.Location = user.Location;
            model.About = user.About;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel m)
        {
            var user = await _userManager.FindByNameAsync(m.Username);
            if (user == null) return Content("Something went horribly wrong! Report issue to Martin Bråten and blame him");

            user.SocialMediaNames = m.SocialMediaNames;
            user.ImgAdress = m.ImgAdress;
            user.Age = m.Age;
            user.Gender = m.Gender;
            user.Location = m.Location;
            user.About = m.About;

            db.SaveChanges();

            return RedirectToAction(m.Username, "Profile");
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        
    }
}