using Microsoft.AspNetCore.Mvc;

namespace Gameblasts.Controllers
{
    public class ForumController : Controller
    {
           public IActionResult CsGo()
        {
            return View("CsGo/CsGo");
        }
           public IActionResult CsGoForumPost(string id)
        {
            
            return View("CsGo/CsGoForumPost");
        }


           public IActionResult LeaugeOfLegends()
        {
            return View("LeaugeOfLegends/LeaugeOfLegends");
        }
          public IActionResult LeaugeOfLegendsForumPost()
        {
            return View("LeaugeOfLegends/LeaugeOfLegendsForumPost");
        }


             public IActionResult SuperSmashBros()
        {   
            return View("SuperSmashBros/SuperSmashBros");
        }
             public IActionResult SuperSmashBrosForumPost()
        {   
            return View("SuperSmashBros/SuperSmashBrosForumPost");
        }


           public IActionResult Dota2()
        {
            return View("Dota2/Dota2");
        }
             public IActionResult Dota2ForumPost()
        {
            return View("Dota2/Dota2ForumPost");
        }


           public IActionResult Overwatch()
        {
            return View("Overwatch/Overwatch");
        }
             public IActionResult OverwatchForumPost()
        {
            return View("Overwatch/OverwatchForumPost");
        }


           public IActionResult Hearthstone()
        {
            return View("Hearthstone/Hearthstone");
        }
          public IActionResult HearthstoneForumPost()
        {
            return View("Hearthstone/HearthstoneForumPost");
        }


            public IActionResult StarCraftII()
        {
            return View("StarCraftII/StarCraftII");
        }
             public IActionResult StarCraftIIForumPost()
        {
            return View("StarCraftII/StarCraftIIForumPost");
        }


              public IActionResult QuakeChampions()
        {
            return View("QuakeChampions/QuakeChampions");
        }
                public IActionResult QuakeChampionsForumPost()
        {
            return View("QuakeChampions/QuakeChampionsForumPost");
        }


              public IActionResult UnrealTournament()
        {
            return View("UnrealTournament/UnrealTournament");
        }
                 public IActionResult UnrealTournamentForumPost()
        {
            return View("UnrealTournament/UnrealTournamentForumPost");
        }
    
    }
}