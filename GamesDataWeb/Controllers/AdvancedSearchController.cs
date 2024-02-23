using GamesDataAccess;
using GamesDataAccess.Criterias;
using GamesDataAccess.DbItems;
using GamesDataWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GamesDataWeb.Controllers
{
    public class AdvancedSearchController(GamesDao gamesDao) : Controller
    {
        [HttpPost]
        public IActionResult Query
        (
            DateOnly? dateFrom,
            DateOnly? dateTo,
            bool? isVirtual,
            string? storeId,
            string? storeName,
            string? storeDescription,
            string? platformId,
            string? platformName,
            string? platformDescription,
            string? gameId,
            string? gameName,
            string? gameDescription,
            string? gameTags,
            decimal? priceFrom,
            decimal? priceTo
        )
        {
            var criteria = 
                new GamesCriteria
                (
                    dateFrom, 
                    dateTo, 
                    isVirtual, 
                    storeId, 
                    storeName, 
                    storeDescription, 
                    platformId, 
                    platformName, 
                    platformDescription,
                    gameId,
                    gameName,
                    gameDescription,
                    gameTags,
                    priceFrom,
                    priceTo
                );

            var model = new OwnedGamesModel
            {
                OwnedGames = gamesDao.GetOwnedGamesByCriteria(criteria) 
            };

            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
