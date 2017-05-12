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
            // Sjekke om modellen er valid. 
            if(ModelState.IsValid)
            {
                // Lage en ny melding, deretter finne den nåværende brukeren som er logget inn.
                // Deretter legge inn meldingen som ble sendt inn i viewet.
                // Finne dato og tid meldingen ble skrevet.
                // Legge meldingen inn i databasen deretter returnere til "ChatBox" action.
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
            // Vise alle meldingene som er i databasen når siden lastes.
            // TODO: Bare vise 20-30 meldinger om gangen.
            var messages = ApplicationDbContext.ChatMessages;
            return View("ChatBox", messages.ToList());
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            var messsageToUpdate = ApplicationDbContext.ChatMessages.Find(id);
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result.ToString();
            if(user == messsageToUpdate.User || User.IsInRole("Admin"))
            {
                return View("Edit", messsageToUpdate);
            }
            else
            {
                return RedirectToAction("ChatBox", ApplicationDbContext.ChatMessages.ToList());
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int? id, ChatMessage message)
        {
            var messsageToUpdate = ApplicationDbContext.ChatMessages.Find(id);
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result.ToString();
            if(ModelState.IsValid){

                if (id == null)
                {
                    return NotFound();
                }
                if (user == messsageToUpdate.User || User.IsInRole("Admin"))
                {
                    messsageToUpdate.Message = message.Message;
                    messsageToUpdate.Date = message.Date;
                    ApplicationDbContext.SaveChanges();
                    return RedirectToAction("ChatBox", ApplicationDbContext.ChatMessages.ToList());
                }
            }
            return RedirectToAction("ChatBox", ApplicationDbContext.ChatMessages.ToList());
        }
    }
}