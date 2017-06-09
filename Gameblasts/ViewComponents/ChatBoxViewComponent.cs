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
    public class ChatBox : ViewComponent
    {
        private ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> um;

        public ChatBox(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            return View(db.ChatMessages.OrderByDescending(x => x.Id).Take(count).ToList());
        }
        
    }
}