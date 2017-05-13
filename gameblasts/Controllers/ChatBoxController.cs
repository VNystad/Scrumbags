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
        public IActionResult Edit()
        {
            // Finner ut hvilken bruker som er logget inn nå
            // Sjekker om den har rollen Admin. TODO: Legge til Moderator. 
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result.ToString();
            if(User.IsInRole("Admin"))
            {
                // Hvis brukeren har rollen admin, sende til edit siden. 
                return View("Edit");
            }
            // Ellers sende brukeren tilbake til chatbox siden.
            else
            {
                return RedirectToAction("ChatBox", ApplicationDbContext.ChatMessages.ToList());
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int? id, string message)
        {
            //Få tak i den nåværende brukeren, og gjøre sjekk som i Get kontrolleren.
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result.ToString();
            //Sjekke om modelstaten er valid, hvis ikke returner tilbake til chatbox siden.
            if(ModelState.IsValid)
            {
                // Hvis id'en ikke finnes returner NotFound() funksjonen.
                if (id == null)
                    return NotFound();

                if (User.IsInRole("Admin"))
                {
                    //Endre meldingen deretter lagre endringen til databasen.
                    //Sende brukeren tilbake til chatbox siden.
                    ApplicationDbContext.ChatMessages.Find(id).Message = message;
                    ApplicationDbContext.SaveChanges();
                    return RedirectToAction("ChatBox", ApplicationDbContext.ChatMessages.ToList());
                }
            }
            return RedirectToAction("ChatBox", ApplicationDbContext.ChatMessages.ToList());
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            //Få tak i den nåværende brukeren, og gjøre sjekk som i Get kontrolleren.
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result.ToString();
            //Sjekke om modelstaten er valid, hvis ikke returner tilbake til chatbox siden.
            if(ModelState.IsValid)
            {
                // Hvis id'en ikke finnes returner NotFound() funksjonen.
                if (id == null)
                    return NotFound();
                
                if (User.IsInRole("Admin"))
                {
                    // Finne meldingen i databasen som skal slettes. Deretter fjerne den fra databasen. 
                    // Så må endringene i databasen lagres, og videresende viewet til ChatBox.
                    ApplicationDbContext.ChatMessages.Remove(ApplicationDbContext.ChatMessages.Find(id));
                    ApplicationDbContext.SaveChanges();
                    return RedirectToAction("ChatBox", ApplicationDbContext.ChatMessages.ToList());
                }
            }
            return RedirectToAction("ChatBox", ApplicationDbContext.ChatMessages.ToList());
        }
    }
}