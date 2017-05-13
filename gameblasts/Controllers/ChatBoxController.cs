using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Gameblasts.Data;
using Microsoft.AspNetCore.Identity;
using Gameblasts.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.ComponentModel.DataAnnotations;

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
        public IActionResult ChatBox(string message, int count)
        {
            // Hvis databasen har mer enn 20 elementer i chatbox melding tabellen,
            // Returner bare 20 av dem. Ellers returner alle som er i tabellen.
            if (ApplicationDbContext.ChatMessages.Count() < 20)
                count = ApplicationDbContext.ChatMessages.Count();
            else
                count = 20;
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

                var context = new ValidationContext(newMessage, null, null);
                Validator.ValidateObject(newMessage, context, true);

                ApplicationDbContext.ChatMessages.Add(newMessage);
                ApplicationDbContext.SaveChanges();
                // Returner i descending order med hensyn på id. Sånn at de nyeste meldingene kommer på toppen av chatboxen.
                return RedirectToAction("ChatBox",ApplicationDbContext.ChatMessages.OrderByDescending(x => x.Id).Take(count).ToList());
            }
            return RedirectToAction("ChatBox",ApplicationDbContext.ChatMessages.OrderByDescending(x => x.Id).Take(count).ToList());
        }

        [HttpGet]
        [Authorize]
        public IActionResult ChatBox(int count)
        {
            // Hvis databasen har mer enn 20 elementer i chatbox melding tabellen,
            // Returner bare 20 av dem. Ellers returner alle som er i tabellen.
            if (ApplicationDbContext.ChatMessages.Count() < 20)
                count = ApplicationDbContext.ChatMessages.Count();
            else
                count = 20;
            // Vise alle meldingene som er i databasen når siden lastes.
            // TODO: Bare vise 20-30 meldinger om gangen.
            var messages = ApplicationDbContext.ChatMessages;
            // Returner i descending order med hensyn på id. Sånn at de nyeste meldingene kommer på toppen av chatboxen.
            return View("ChatBox", messages.OrderByDescending(x => x.Id).Take(count).ToList());
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit()
        {
            // Finner ut hvilken bruker som er logget inn nå
            // Sjekker om den har rollen Admin. 
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result.ToString();
            if(User.IsInRole("Admin") || User.IsInRole("Moderator"))
            {
                // Hvis brukeren har rollen admin eller moderator, sende til edit siden. 
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
            // Få tak i den nåværende brukeren, og gjøre sjekk som i Get kontrolleren.
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result.ToString();
            // Sjekke om modelstaten er valid, hvis ikke returner tilbake til chatbox siden.
            if(ModelState.IsValid)
            {
                // Hvis id'en ikke finnes returner NotFound() funksjonen.
                if (id == null)
                    return NotFound();

                if (User.IsInRole("Admin") || User.IsInRole("Moderator"))
                {
                    // Endre meldingen deretter lagre endringen til databasen.
                    // Sende brukeren tilbake til chatbox siden.
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
            // Få tak i den nåværende brukeren, og gjøre sjekk som i Get kontrolleren.
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result.ToString();
            // Sjekke om modelstaten er valid, hvis ikke returner tilbake til chatbox siden.
            if(ModelState.IsValid)
            {
                // Hvis id'en ikke finnes returner NotFound() funksjonen.
                if (id == null)
                    return NotFound();
                
                if (User.IsInRole("Admin") || User.IsInRole("Moderator"))
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