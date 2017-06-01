using Gameblasts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Gameblasts.Controllers.ManageController;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Gameblasts.Models.AdminPageViewModels;

namespace Gameblasts.Controllers
{
    public class AdminPageController : Controller
    {
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;        
        
/**This is the controller of the AdminPage. Its task is to actually perform the action in the AdminPage.
*The link to the AdminPage is only shown for users in the Admin role (done in _LoginPartial.cshtml) and other users are also blocked from accessing this page and posting to it.
*The way the AdminPageController works is that it receives the email-address and new role of the user whom should have a change of role.
*Then the controller finds the id of the user based on its email-address, removes any roles it may have and then assigns it the new role sent fromt the View/ViewModel.
*/
        public AdminPageController(UserManager<ApplicationUser> um /*, SignInManager<ApplicationUser> im*/) 
        {
            _userManager = um;
            //_signInManager = im;
        }
        [Authorize(Roles="Admin")]
        public IActionResult AdminPage()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> AddUserToRole(AdminPageChangeRoleViewModel Info)
        {
            var user = await _userManager.FindByNameAsync(Info.Name);
            if(user == null)
            {
                return View("AdminPage");
            }
            else
            {
                if(await _userManager.IsInRoleAsync(user, "Banned"))
                {
                    await _userManager.RemoveFromRoleAsync(user, "Banned");
                }
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
                //await _signInManager.RefreshSignInAsync(user);
                return View("AdminPage");
            }
        }
    }
}