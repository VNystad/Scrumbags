using Gameblasts.Models.ChatBoxViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Gameblasts.Data;
using Microsoft.AspNetCore.Identity;
using Gameblasts.Models;

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

        public async Task<IActionResult> AddChat(AddEditChatBoxViewModel vm, string message)
        {   
            ChatMessage newmessage = new ChatMessage(await GetCurrentUserAsync(),message);
            ApplicationDbContext.ChatMessages.Add(newmessage);
            ApplicationDbContext.SaveChanges();
            return View("../Home/ChatBox");
        }

        public IActionResult ChatBox()
        {
            return View("../Home/ChatBox");
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return UserManager.GetUserAsync(HttpContext.User);
        }
    }
}