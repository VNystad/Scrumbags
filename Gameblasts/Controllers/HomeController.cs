using Microsoft.AspNetCore.Mvc;

namespace Gameblasts.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Discord()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            return View();
        }

/* Here are the IActionResults for The forum itself with subcategories. */
         public IActionResult CsGo()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Forum()
        {
            ViewData["Message"] = "Your contact page.";

        public IActionResult Adminpage()
        {
            return View();
        }
    }
}
