using Gameblasts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Gameblasts.Controllers.ManageController;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Gameblasts.Models.AdminPageViewModels;
namespace Gameblasts.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminPageController(UserManager<ApplicationUser> um) 
        {
            _userManager = um;
        }
        [Authorize(Roles="Admin")]
        public IActionResult AdminPage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(AdminPageChangeRoleViewModel Info)
        {
            var user = await _userManager.FindByEmailAsync(Info.Email);
            if(user == null)
            {
                return View("AdminPage");
            }
            else
            {
                if(await _userManager.IsInRoleAsync(user, "Member"))
                {
                    await _userManager.RemoveFromRoleAsync(user, "Member");
                }
                if(await _userManager.IsInRoleAsync(user, "Moderator"))
                {
                    await _userManager.RemoveFromRoleAsync(user, "Moderator");
                }
                if(await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    await _userManager.RemoveFromRoleAsync(user, "Admin");
                }
                await _userManager.AddToRoleAsync(user, Info.Role);
                return View("AdminPage");
            }
        }
    }
}