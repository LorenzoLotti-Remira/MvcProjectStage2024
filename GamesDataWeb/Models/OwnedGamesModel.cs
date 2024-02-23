using GamesDataAccess.Criterias;
using GamesDataAccess.DbItems;

namespace GamesDataWeb.Models
{
    public class OwnedGamesModel
    {
        public OwnedGameDbItem[] OwnedGames { get; set; } = [];
    }
}
