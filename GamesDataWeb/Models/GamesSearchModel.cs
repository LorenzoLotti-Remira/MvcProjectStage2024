using GamesDataAccess.DbItems;

namespace GamesDataWeb.Models
{
    public class GamesSearchModel
    {
        public GameDbItem[] GamesDbItems { get; set; } = [];
        public string SearchString { get; set; } = string.Empty;
    }
}
