using GamesDataAccess;
using GamesDataAccess.DbItems;
using GamesDataWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GamesDataWeb.Controllers
{
    public class HomeController(GamesDao dao) : Controller
    {
        public IActionResult SearchGame(string name, string? tag)
        {
            var model = new GamesSearchModel
            {
                 GamesDbItems = dao.GetGamesByPartialName(name, tag),
                 SearchString = name
            };


            return View(model);
        }

        public IActionResult SearchPlatform(string name) 
        {
            var model = new PlatformsModel
            {
                PlatformDbItems = dao.GetPlatformsByPartialName(name)
            };

            return View(model);
        }

        public IActionResult SearchStore(string name)
        {
            var model = new StoresModel
            {
                StoresDbItems = dao.GetStoresByPartialName(name)
            };

            return View(model);
        }

        public IActionResult SearchTransaction()
        {
            var model = new TransactionInsertionModel
            {
                //GameDbItems = dao.
            };

            return View(model);
        }

        public IActionResult Index()
        {
            // Metodo imperativo
            /*
            List<string> tagsList = [];
            var games = dao.GetAllGames();
            foreach (var game in games)
            {
                tagsList.AddRange(game.GameTags.Split(';'));
            }

            var model = new HomeModel
            {
                Tags = tagsList.Distinct().ToArray()
            };
            */


            // Metodo dichiarativo

            var model = new HomeModel
            {
                Tags = dao
                    .GetAllGames()
                    .SelectMany(game => game.GameTags.Split(';'))
                    .Distinct()
                    .ToArray()
             };
           

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
