using GamesDataAccess.DbItems;

namespace GamesDataWeb.Models
{
    public class TransactionInsertionModel
    {
        public GameDbItem[] GameDbItems { get; set; } = [];
        public PlatformDbItem[] PlatformDbItems { get; set; } = [];
        public StoreDbItem[] StoreDbItems { get; set; } = [];
    }
}
