using System;
using System.Linq;
using System.Threading.Tasks;
using Gameblasts.Data;
using Gameblasts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ViewComponents
{
    public class Message : ViewComponent
    {
        private ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> um;

        public Message(ApplicationDbContext db, UserManager<ApplicationUser> UserManager)
        {
            this.db = db;
            this.um = UserManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ApplicationUser user = await um.FindByNameAsync(HttpContext.User.Identity.Name);

            var msgs = user.Messages;
            /*var msgs = db.Messages.Select
                            .Where(m => (m.Receiver.Equals(user.UserName))).ToList();
            if(msgs == null ||msgs.LongCount() == 0)*/
                return Content(string.Empty);
            //return View(msgs);
        }
        
    }
}