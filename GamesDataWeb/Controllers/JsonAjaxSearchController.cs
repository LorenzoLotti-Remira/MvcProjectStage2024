using Microsoft.AspNetCore.Mvc;
using GamesDataAccess;
using GamesDataAccess.Criterias;
using GamesDataAccess.DbItems;
using GamesDataWeb.Models;
using System.Diagnostics;

namespace GamesDataWeb.Controllers
{
    public class JsonAjaxSearchController(GamesDao gamesDao) : Controller
    {
        [HttpPost]
        public IActionResult Results([FromBody] SearchStringModel searchString)
        {
            var model = new AjaxSearchResultsViewModel
            {
                Games = gamesDao.GetGamesByPartialName(searchString.Search, null),
                Platforms = gamesDao.GetPlatformsByPartialName(searchString.Search),
                Stores = gamesDao.GetStoresByPartialName(searchString.Search)
            };

            return Json(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
