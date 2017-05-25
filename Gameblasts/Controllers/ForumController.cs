using Microsoft.AspNetCore.Mvc;

namespace Gameblasts.Controllers
{
    public class ForumController : Controller
    {

        //------------------------------------------------------
        //      
        //
        //
        // CsGo Forum controller for all of the sub categories
        //  
        //
        // 
        //-------------------------------------------------------
            public IActionResult CsGo()
        {
            return View("CsGo/CsGo");
        }

            public IActionResult CsGoForumPostGeneral(string id)
        {
            return View("CsGo/CsGoCategories/General/CsGoForumPostGeneral");
        }

            public IActionResult CsGoGeneral(string id)
        {
            return View("CsGo/CsGoCategories/General/CsGoGeneral");
        }

            public IActionResult CsGoForumPostLTP(string id)
        {
            return View("CsGo/CsGoCategories/LTP/CsGoForumPostLTP");
        }

            public IActionResult CsGoLTP(string id)
        {
            return View("CsGo/CsGoCategories/LTP/CsGoLTP");
        }

            public IActionResult CsGoForumPostMedia(string id)
        {
            return View("CsGo/CsGoCategories/Media/CsGoForumPostMedia");
        }

            public IActionResult CsGoMedia(string id)
        { 
            return View("CsGo/CsGoCategories/Media/CsGoMedia");
        }

            public IActionResult CsGoForumPostNews(string id)
        {
            return View("CsGo/CsGoCategories/News/CsGoForumPostNews");
        }

            public IActionResult CsGoNews(string id)
        { 
            return View("CsGo/CsGoCategories/News/CsGoNews");
        }

            public IActionResult CsGoForumPostSupport(string id)
        {  
            return View("CsGo/CsGoCategories/Support/CsGoForumPostSupport");  
        }

            public IActionResult CsGoSupport(string id)
        {   
            return View("CsGo/CsGoCategories/Support/CsGoSupport");
        }
        //------------------------------------------------------
        //      
        //
        //
        // Dota2 Forum controller for all of the sub categories
        //  
        //
        // 
        //-------------------------------------------------------
            public IActionResult Dota2()
        {
            return View("Dota2/Dota2");
        }

            public IActionResult Dota2ForumPostGeneral(string id)
        {
            return View("Dota2/Dota2Categories/General/Dota2ForumPostGeneral");
        }

            public IActionResult Dota2General(string id)
        {
            return View("Dota2/Dota2Categories/General/Dota2General");
        }

            public IActionResult Dota2ForumPostLTP(string id)
        { 
            return View("Dota2/Dota2Categories/LTP/Dota2ForumPostLTP");
        }

            public IActionResult Dota2LTP(string id)
        {
            return View("Dota2/Dota2Categories/LTP/Dota2LTP");
        }

            public IActionResult Dota2ForumPostMedia(string id)
        { 
            return View("Dota2/Dota2Categories/Media/Dota2ForumPostMedia");
        }

            public IActionResult Dota2Media(string id)
        {
            return View("Dota2/Dota2Categories/Media/Dota2Media");
        }

            public IActionResult Dota2ForumPostNews(string id)
        { 
            return View("Dota2/Dota2Categories/News/Dota2ForumPostNews");
        }

            public IActionResult Dota2News(string id)
        {
            return View("Dota2/Dota2Categories/News/Dota2News");
        }

            public IActionResult Dota2ForumPostSupport(string id)
        {
            return View("Dota2/Dota2Categories/Support/Dota2ForumPostSupport");
        }

            public IActionResult Dota2Support(string id)
        {
            return View("Dota2/Dota2Categories/Support/Dota2Support");
        }
        //------------------------------------------------------
        //      
        //
        //
        // Hearthston Forum controller for all of the sub categories
        //  
        //
        // 
        //-------------------------------------------------------
            public IActionResult Hearthstone()
        {
            return View("Hearthstone/Hearthstone");
        }
            public IActionResult HearthStoneForumPostGeneral(string id)
        {
            return View("HearthStone/HearthStoneCategories/General/HearthStoneForumPostGeneral");
        }
        
            public IActionResult HearthStoneGeneral(string id)
        {
            return View("HearthStone/HearthStoneCategories/General/HearthStoneGeneral");
        }

            public IActionResult HearthStoneForumPostLTP(string id)
        {
            return View("HearthStone/HearthStoneCategories/LTP/HearthStoneForumPostLTP");
        }

            public IActionResult HearthStoneLTP(string id)
        {
            return View("HearthStone/HearthStoneCategories/LTP/HearthStoneLTP");
        }

            public IActionResult HearthStoneForumPostMedia(string id)
        { 
            return View("HearthStone/HearthStoneCategories/Media/HearthStoneForumPostMedia");
        }

            public IActionResult HearthStoneMedia(string id)
        {
            return View("HearthStone/HearthStoneCategories/Media/HearthStoneMedia");
        }

            public IActionResult HearthStoneForumPostNews(string id)
        {    
            return View("HearthStone/HearthStoneCategories/News/HearthStoneForumPostNews");
        }

            public IActionResult HearthStoneNews(string id)
        {
            return View("HearthStone/HearthStoneCategories/News/HearthStoneNews");
        }

            public IActionResult HearthStoneForumPostSupport(string id)
        { 
            return View("HearthStone/HearthStoneCategories/Support/HearthStoneForumPostSupport");
        }

            public IActionResult HearthStoneSupport(string id)
        {
            return View("HearthStone/HearthStoneCategories/Support/HearthStoneSupport");
        }
        //------------------------------------------------------
        //      
        //
        //
        // LeaugeOfLegends Forum controller for all of the sub categories
        //  
        //
        // 
        //-------------------------------------------------------
            public IActionResult LeaugeOfLegends()
        {
            return View("LeaugeOfLegends/LeaugeOfLegends");
        }

            public IActionResult LeaugeOfLegendsForumPostGeneral(string id)
        {  
            return View("LeaugeOfLegends/LeaugeOfLegendsCategories/General/LeaugeOfLegendsForumPostGeneral");
        }
    
            public IActionResult LeaugeOfLegendsGeneral(string id)
        {
            return View("LeaugeOfLegends/LeaugeOfLegendsCategories/General/LeaugeOfLegendsGeneral");
        }

            public IActionResult LeaugeOfLegendsForumPostLTP(string id)
        { 
            return View("LeaugeOfLegends/LeaugeOfLegendsCategories/LTP/LeaugeOfLegendsForumPostLTP");
        }

            public IActionResult LeaugeOfLegendsLTP(string id)
        {
            return View("LeaugeOfLegends/LeaugeOfLegendsCategories/LTP/LeaugeOfLegendsLTP");
        }

            public IActionResult LeaugeOfLegendsForumPostMedia(string id)
        {
            return View("LeaugeOfLegends/LeaugeOfLegendsCategories/Media/LeaugeOfLegendsForumPostMedia");
        }

            public IActionResult LeaugeOfLegendsMedia(string id)
        {
            return View("LeaugeOfLegends/LeaugeOfLegendsCategories/Media/LeaugeOfLegendsMedia");
        }

            public IActionResult LeaugeOfLegendsForumPostNews(string id)
        { 
            return View("LeaugeOfLegends/LeaugeOfLegendsCategories/News/LeaugeOfLegendsForumPostNews");
        }

            public IActionResult LeaugeOfLegendsNews(string id)
        {
            return View("LeaugeOfLegends/LeaugeOfLegendsCategories/News/LeaugeOfLegendsNews");
        }

            public IActionResult LeaugeOfLegendsForumPostSupport(string id)
        {
            return View("LeaugeOfLegends/LeaugeOfLegendsCategories/Support/LeaugeOfLegendsForumPostSupport");
        }

            public IActionResult LeaugeOfLegendsSupport(string id)
        {
            return View("LeaugeOfLegends/LeaugeOfLegendsCategories/Support/LeaugeOfLegendsSupport");
        }
        //------------------------------------------------------
        //      
        //
        //
        // Overwatch Forum controller for all of the sub categories
        //  
        //
        // 
        //-------------------------------------------------------
            public IActionResult Overwatch()
        {
            return View("Overwatch/Overwatch");
        }

            public IActionResult OverwatchForumPostGeneral(string id)
        {   
            return View("Overwatch/OverwatchCategories/General/OverwatchForumPostGeneral");
        }

            public IActionResult OverwatchGeneral(string id)
        {
            return View("Overwatch/OverwatchCategories/General/OverwatchGeneral");
        }

            public IActionResult OverwatchForumPostLTP(string id)
        {    
            return View("Overwatch/OverwatchCategories/LTP/OverwatchForumPostLTP");
        }

            public IActionResult OverwatchLTP(string id)
        {
            return View("Overwatch/OverwatchCategories/LTP/OverwatchLTP");
        }

            public IActionResult OverwatchForumPostMedia(string id)
        {
            return View("Overwatch/OverwatchCategories/Media/OverwatchForumPostMedia");
        }

            public IActionResult OverwatchMedia(string id)
        {
            return View("Overwatch/OverwatchCategories/Media/OverwatchMedia");
        }

            public IActionResult OverwatchForumPostNews(string id)
        {            
            return View("Overwatch/OverwatchCategories/News/OverwatchForumPostNews");
        }

            public IActionResult OverwatchNews(string id)
        {
            return View("Overwatch/OverwatchCategories/News/OverwatchNews");
        }

            public IActionResult OverwatchForumPostSupport(string id)
        {
            return View("Overwatch/OverwatchCategories/Support/OverwatchForumPostSupport");
        }

            public IActionResult OverwatchSupport(string id)
        {
            return View("Overwatch/OverwatchCategories/Support/OverwatchSupport");
        }
        //------------------------------------------------------
        //      
        //
        //
        // QuakeChampions Forum controller for all of the sub categories
        //  
        //
        // 
        //-------------------------------------------------------
            public IActionResult QuakeChampions()
        {
            return View("QuakeChampions/QuakeChampions");
        }

            public IActionResult QuakeChampionsForumPostGeneral(string id)
        {
            return View("QuakeChampions/QuakeChampionsCategories/General/QuakeChampionsForumPostGeneral");
        }

            public IActionResult QuakeChampionsGeneral(string id)
        {
            return View("QuakeChampions/QuakeChampionsCategories/General/QuakeChampionsGeneral");
        }

            public IActionResult QuakeChampionsForumPostLTP(string id)
        {
            return View("QuakeChampions/QuakeChampionsCategories/LTP/QuakeChampionsForumPostLTP");
        }
        
            public IActionResult QuakeChampionsLTP(string id)
        {
            return View("QuakeChampions/QuakeChampionsCategories/LTP/QuakeChampionsLTP");
        }

            public IActionResult QuakeChampionsForumPostMedia(string id)
        {
            return View("QuakeChampions/QuakeChampionsCategories/Media/QuakeChampionsForumPostMedia");
        }

            public IActionResult QuakeChampionsMedia(string id)
        {
            return View("QuakeChampions/QuakeChampionsCategories/Media/QuakeChampionsMedia");
        }

            public IActionResult QuakeChampionsForumPostNews(string id)
        {
            return View("QuakeChampions/QuakeChampionsCategories/News/QuakeChampionsForumPostNews");
        }

            public IActionResult QuakeChampionsNews(string id)
        {
            return View("QuakeChampions/QuakeChampionsCategories/News/QuakeChampionsNews");
        }

            public IActionResult QuakeChampionsForumPostSupport(string id)
        {
            return View("QuakeChampions/QuakeChampionsCategories/Support/QuakeChampionsForumPostSupport");
        }

            public IActionResult QuakeChampionsSupport(string id)
        {
            return View("QuakeChampions/QuakeChampionsCategories/Support/QuakeChampionsSupport");
        }
        //------------------------------------------------------
        //      
        //
        //
        // StarcraftII Forum controller for all of the sub categories
        //  
        //
        // 
        //-------------------------------------------------------
            public IActionResult StarCraftII()
        {
            return View("StarCraftII/StarCraftII");
        }

            public IActionResult StarCraftIIForumPostGeneral(string id)
        {
            return View("StarCraftII/StarCraftIICategories/General/StarCraftIIForumPostGeneral");
        }

            public IActionResult StarCraftIIGeneral(string id)
        {
            return View("StarCraftII/StarCraftIICategories/General/StarCraftIIGeneral");
        }

            public IActionResult StarCraftIIForumPostLTP(string id)
        {
            return View("StarCraftII/StarCraftIICategories/LTP/StarCraftIIForumPostLTP");
        }

            public IActionResult StarCraftIILTP(string id)
        {
            return View("StarCraftII/StarCraftIICategories/LTP/StarCraftIILTP");
        }

            public IActionResult StarCraftIIForumPostMedia(string id)
        {
            return View("StarCraftII/StarCraftIICategories/Media/StarCraftIIForumPostMedia");
        }

            public IActionResult StarCraftIIMedia(string id)
        {
            return View("StarCraftII/StarCraftIICategories/Media/StarCraftIIMedia");
        }

            public IActionResult StarCraftIIForumPostNews(string id)
        {            
            return View("StarCraftII/StarCraftIICategories/News/StarCraftIIForumPostNews");
        }

            public IActionResult StarCraftIINews(string id)
        {
            return View("StarCraftII/StarCraftIICategories/News/StarCraftIINews");
        }

            public IActionResult StarCraftIIForumPostSupport(string id)
        {           
            return View("StarCraftII/StarCraftIICategories/Support/StarCraftIIForumPostSupport");
        }

            public IActionResult StarCraftIISupport(string id)
        {
            return View("StarCraftII/StarCraftIICategories/Support/StarCraftIISupport");
        }
        //------------------------------------------------------
        //      
        //
        //
        // SuperSmashBros Forum controller for all of the sub categories
        //  
        //
        // 
        //-------------------------------------------------------
            public IActionResult SuperSmashBros()
        {   
            return View("SuperSmashBros/SuperSmashBros");
        }

            public IActionResult SuperSmashBrosForumPostGeneral(string id)
        {
            return View("SuperSmashBros/SuperSmashBrosCategories/General/SuperSmashBrosForumPostGeneral");
        }

            public IActionResult SuperSmashBrosGeneral(string id)
        {
            return View("SuperSmashBros/SuperSmashBrosCategories/General/SuperSmashBrosGeneral");
        }

            public IActionResult SuperSmashBrosForumPostLTP(string id)
        {
            return View("SuperSmashBros/SuperSmashBrosCategories/LTP/SuperSmashBrosForumPostLTP");
        }

            public IActionResult SuperSmashBrosLTP(string id)
        {
            return View("SuperSmashBros/SuperSmashBrosCategories/LTP/SuperSmashBrosLTP");
        }

            public IActionResult SuperSmashBrosForumPostMedia(string id)
        {
            return View("SuperSmashBros/SuperSmashBrosCategories/Media/SuperSmashBrosForumPostMedia");
        }

            public IActionResult SuperSmashBrosMedia(string id)
        {
            return View("SuperSmashBros/SuperSmashBrosCategories/Media/SuperSmashBrosMedia");
        }

            public IActionResult SuperSmashBrosForumPostNews(string id)
        {         
            return View("SuperSmashBros/SuperSmashBrosCategories/News/SuperSmashBrosForumPostNews");
        }

            public IActionResult SuperSmashBrosNews(string id)
        {
            return View("SuperSmashBros/SuperSmashBrosCategories/News/SuperSmashBrosNews");
        }

            public IActionResult SuperSmashBrosForumPostSupport(string id)
        {            
            return View("SuperSmashBros/SuperSmashBrosCategories/Support/SuperSmashBrosForumPostSupport");
        }

            public IActionResult SuperSmashBrosSupport(string id)
        {
            return View("SuperSmashBros/SuperSmashBrosCategories/Support/SuperSmashBrosSupport");
        }
        //------------------------------------------------------
        //      
        //
        //
        // UnrealTournament Forum controller for all of the sub categories
        //  
        //
        // 
        //-------------------------------------------------------
            public IActionResult UnrealTournament()
        {
            return View("UnrealTournament/UnrealTournament");
        }

            public IActionResult UnrealTournamentForumPostGeneral(string id)
        {
            return View("UnrealTournament/UnrealTournamentCategories/General/UnrealTournamentForumPostGeneral");
        }

            public IActionResult UnrealTournamentGeneral(string id)
        {
            return View("UnrealTournament/UnrealTournamentCategories/General/UnrealTournamentGeneral");
        }

            public IActionResult UnrealTournamentForumPostLTP(string id)
        {            
            return View("UnrealTournament/UnrealTournamentCategories/LTP/UnrealTournamentForumPostLTP");
        }

            public IActionResult UnrealTournamentLTP(string id)
        {
            return View("UnrealTournament/UnrealTournamentCategories/LTP/UnrealTournamentLTP");
        }

            public IActionResult UnrealTournamentForumPostMedia(string id)
        {         
            return View("UnrealTournament/UnrealTournamentCategories/Media/UnrealTournamentForumPostMedia");
        }

            public IActionResult UnrealTournamentMedia(string id)
        {
            return View("UnrealTournament/UnrealTournamentCategories/Media/UnrealTournamentMedia");
        }

            public IActionResult UnrealTournamentForumPostNews(string id)
        {
            return View("UnrealTournament/UnrealTournamentCategories/News/UnrealTournamentForumPostNews");
        }

            public IActionResult UnrealTournamentNews(string id)
        {
            return View("UnrealTournament/UnrealTournamentCategories/News/UnrealTournamentNews");
        }

            public IActionResult UnrealTournamentForumPostSupport(string id)
        {
            return View("UnrealTournament/UnrealTournamentCategories/Support/UnrealTournamentForumPostSupport");
        }

            public IActionResult UnrealTournamentSupport(string id)
        {
            return View("UnrealTournament/UnrealTournamentCategories/Support/UnrealTournamentSupport");
        }

    }
}