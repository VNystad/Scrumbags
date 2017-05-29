using Gameblasts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Gameblasts.Controllers.ManageController;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gameblasts.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminPageController(UserManager<ApplicationUser> um) 
        {
            _userManager = um;
        }
/*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(Microsoft.AspNetCore.Identity.UserLoginInfo user, string role)
        {
            if (ModelState.IsValid)
            {
                // THIS LINE IS IMPORTANT
                var oldUser = Microsoft.AspNetCore.Identity.UserManager.FindById(user);
                var oldRoleId = oldUser.Roles.SingleOrDefault().RoleId;
                var oldRoleName = DB.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;

                if (oldRoleName != role)
                {
                    Manager.RemoveFromRole(user.Id, oldRoleName);
                    Manager.AddToRole(user.Id, role);
                }
                DB.Entry(user).State = EntityState.Modified;

                return RedirectToAction(MVC.User.Index());
            }
            return View(user);
        }
*/

/*        [HttpPost]
        [ValidateAntiForgeryToken] */

        [Authorize(Roles="Admin")]
        public IActionResult AdminPage()
        {
            return View();
        }

        //Burde vært bool check, men får ike dette til per nå.
        public async void AddUserToRole(string email, string rolename)
        {
            //var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return;
            }
            else
            {
                await _userManager.AddToRoleAsync(user, rolename);
                return;
            }
        }


/*
                    var user = await userManager.FindByNameAsync("admin@uia.no");
            if(user == null)
            {
                // Then add one admin user if it doesn't already exists.
                var adminUser = new ApplicationUser( "admin@uia.no", "admin@uia.no" );
                await userManager.CreateAsync(adminUser, "Password1.");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
*/
/* 
        public bool AddUserToRole(string userId, string roleName)
        {
            var idResult = _userManager.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }
*/
    }
}