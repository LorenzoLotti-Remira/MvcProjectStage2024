using GamesDataAccess;
using GamesDataAccess.DbItems;
using GamesDataWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GamesDataWeb.Controllers
{
    public class InsertController(GamesDao dao) : Controller
    {
        public IActionResult NewGame(string id, string name, string description, [FromQuery(Name = "tags")] string[] tags)
        {
            var tagsString = string.Join(';', tags);
            var game = new GameDbItem(id, name, description, tagsString);

            var model = new InsertModel
            {
                IsCompleted = true
            };

            try
            {
                dao.AddNewGame(game);
            }
            catch
            {
                model.IsCompleted = false;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult NewPlatform(string id, string name, string description) 
        {
            var platform = new PlatformDbItem(id, name, description);

            var model = new InsertModel
            {
                IsCompleted = true
            };

            try
            {
                dao.AddNewPlatform(platform);
            }
            catch
            {
                model.IsCompleted = false;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult NewTransaction(string id, DateOnly date, bool isVirtual, string store, string platform, string game, decimal price, string? notes)
        {
            var transaction = new GameTransactionDbItem(id, date, isVirtual, store, platform, game, price, notes);

            var model = new InsertModel
            {
                IsCompleted = true
            };

            try
            {
                dao.AddNewGameTransaction(transaction);
            }
            catch
            {
                model.IsCompleted = false;
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult NewStore(string id, string name, string description, string link)
        {
            var store = new StoreDbItem(id, name, description, link);

            var model = new InsertModel
            {
                IsCompleted = true
            };

            try
            {
                dao.AddNewStore(store);
            }
            catch
            {
                model.IsCompleted = false;
            }

            return View(model);
        }

        public IActionResult Index()
        {
            var model = new TransactionInsertionModel
            {
                GameDbItems = dao.GetAllGames(),
                PlatformDbItems = dao.GetAllPlatforms(),
                StoreDbItems = dao.GetAllStores()
            };

            return View(model);
        }
    }
}