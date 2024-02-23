using GamesDataAccess.DbItems;

namespace GamesDataWeb.Models
{
    public class AjaxSearchResultsViewModel
    {
        public GameDbItem[] Games { get; set; } = [];
        public PlatformDbItem[] Platforms { get; set; } = [];
        public StoreDbItem[] Stores { get; set; } = [];
    }
}