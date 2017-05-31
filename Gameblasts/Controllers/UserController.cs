using System;
using System.Threading.Tasks;
using Gameblasts.Data;
using Gameblasts.Models;
using Gameblasts.Models.MessageViewModels;
using Gameblasts.Models.ProfileViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gameblasts.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(ApplicationDbContext applicationdbcontext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            db = applicationdbcontext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        ///Profile returns the userprofile of id(username), returns with viewmodel
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

        ///Returns a model to a view to edit userprofile
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (user == null) return Content("Something went horribly wrong! Report issue to Martin Bråten and blame him");

            EditProfileViewModel model = new EditProfileViewModel();

            model.Username = user.UserName;
            model.ImgAdress = user.ImgAdress;
            model.SocialMediaNames = user.SocialMediaNames;
            model.Age = user.Age;
            model.Gender = user.Gender;
            model.Location = user.Location;
            model.About = user.About;

            return View(model);
        }

        ///Updates the userprofile, takes in a viewmodel with variables to update. Returns to userprofile.
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
            return Redirect(user.UserName);
        }

        ///Parameter: username of the receiver, returns view for newmessage with viewmodel including the username. (Messages not working!)
        [HttpGet]
        public async Task<IActionResult> NewMessage(string id)
        {
            if(id == null)
            {
                var model1 = new MessageViewModel();
                model1.Subject = "";
                model1.Msg = "";
                model1.Date = DateTime.Now;

                return View("NewMessage", model1);
            }
            
            var temp = await _userManager.FindByNameAsync(id);
            if (temp == null) return Content("User doesnt excist");
            
            var model = new MessageViewModel();
            model.Receiver = id;
            model.Sender = temp.UserName;
            return View("NewMessage", model);
        }

        ///Parameter: viewmodel for the message, returns to homepage. (Messages not working!)
        [HttpPost]
        public async Task<IActionResult> NewMessage(MessageViewModel model)
        {
            model.Sender = HttpContext.User.Identity.Name;
            ApplicationUser user = await _userManager.FindByNameAsync(model.Receiver);
            
            Message msg = new Message(
                model.Subject, model.Msg,
                model.Sender, user);
            
            db.Add(msg);
            ApplicationUser sender = await _userManager.FindByNameAsync(model.Sender);
            sender.MsgSent++;

            user.UnreadMsg = true;

            db.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }

        /// Returns view of inbox. (Doesnt work properly, need to get messages from db.)
        public async Task<IActionResult> Inbox()
        {

            
            return View();
        }
    }
}