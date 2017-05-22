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

        public async Task<IActionResult> IndexAsync(string UserName)
        {
            ApplicationUser temp = await _userManager.FindByNameAsync(UserName);
            ProfileViewModel tempmodel = new ProfileViewModel();
            tempmodel.Username = temp.UserName;
            return View("../Profile/Index",tempmodel);
        }

        public async Task<IActionResult> YourProfileAsync()
        {
            ProfileViewModel tempmodel = new ProfileViewModel();
            ApplicationUser temp = await GetCurrentUserAsync();
            tempmodel.Username = temp.UserName;
            return View(tempmodel);
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}