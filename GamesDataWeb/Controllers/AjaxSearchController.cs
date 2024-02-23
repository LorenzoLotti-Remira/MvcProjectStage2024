using GamesDataAccess;
using GamesDataAccess.Criterias;
using GamesDataAccess.DbItems;
using GamesDataWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GamesDataWeb.Controllers
{
    public class AjaxSearchController(GamesDao gamesDao) : Controller
    {
        [HttpPost]
        public IActionResult Results(string search)
        {   
            //property init
            var model = new AjaxSearchResultsViewModel
            {   
                Games = gamesDao.GetGamesByPartialName(search, null),
                Platforms = gamesDao.GetPlatformsByPartialName(search),
                Stores = gamesDao.GetStoresByPartialName(search)
            };

            //metodo alternativo
            //var model2 = new PlatformsModel();
            //model2.PlatformDbItems = gamesDao.GetPlatformsByPartialName(search);
            
            return PartialView(model);
        }

        public IActionResult Index()
        {   
            return View();
        }
    }
}
