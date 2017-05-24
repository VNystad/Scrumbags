using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gameblasts.Controllers
{
    public class SideNavController : Controller
    {
        [Authorize(Roles="Admin")]
        public IActionResult Adminpage()
        {
            return View();
        }
    }
}