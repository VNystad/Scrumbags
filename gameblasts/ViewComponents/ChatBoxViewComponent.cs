using System.Linq;
using System.Threading.Tasks;
using Gameblasts.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ViewComponents
{
    public class ChatMessage : ViewComponent
    {
        private ApplicationDbContext db;

        public ChatMessage(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count = 0)
        {
            /*This takes "count" of chat messages from database */
            return View(db.ChatMessages.Include(p => p.User).Take(count).ToList());
        }
    }
}