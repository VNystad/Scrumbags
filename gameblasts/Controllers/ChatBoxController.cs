using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Gameblasts.Data;
using Microsoft.AspNetCore.Identity;
using Gameblasts.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Gameblasts.Controllers
{
    public class ChatBoxController : Controller
    {   
        private ApplicationDbContext ApplicationDbContext;
        private UserManager<ApplicationUser> UserManager { get; set; }
        private readonly SignInManager<ApplicationUser> SignInManager;
        
        public ChatBoxController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.ApplicationDbContext = db;
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        [HttpPost]
        [Authorize]
        public IActionResult ChatBox(string message)
        {
            if(ModelState.IsValid)
            {
                ChatMessage newMessage = new ChatMessage();
                newMessage.User = UserManager.FindByNameAsync(User.Identity.Name).Result.ToString();
                newMessage.Message = message;
                newMessage.Date = System.DateTime.Now;
                ApplicationDbContext.ChatMessages.Add(newMessage);
                ApplicationDbContext.SaveChanges();
                return RedirectToAction("ChatBox",ApplicationDbContext.ChatMessages.ToList());
            }
            return RedirectToAction("ChatBox",ApplicationDbContext.ChatMessages.ToList());
        }

        [HttpGet]
        [Authorize]
        public IActionResult ChatBox()
        {
            var messages = ApplicationDbContext.ChatMessages;
            return View("ChatBox", messages.ToList());
        }
    }
}