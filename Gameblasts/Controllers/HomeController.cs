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

        public IActionResult Forum()
        {

            return View();
        }
        
        public IActionResult Adminpage()
        {
            return View();
        }

        public IActionResult RulesAndGuidelinesForum()
        {

            return View();
        }

    }
}
