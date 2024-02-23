namespace GamesDataWeb.Models
{
    public class InsertPopupViewComponentModel
    {
        public string Text { get; set; } = string.Empty;
        public bool IsSuccessful { get; set; }
        public string Color { get; set; } = string.Empty;
        public bool UseBootstrap { get; set; } 
    }
}
