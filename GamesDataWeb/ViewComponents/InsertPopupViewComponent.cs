using GamesDataWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesDataWeb.ViewComponents
{
    public class InsertPopupViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string text, bool isSuccessful, string? color = null, bool useBootstrap = false)
        {
            if (string.IsNullOrWhiteSpace(color))
            {
                color = useBootstrap ? "primary" : "blue";
            }

            var model = new InsertPopupViewComponentModel
            {
                Text = text,
                IsSuccessful = isSuccessful,
                Color = color,
                UseBootstrap = useBootstrap
            };

            return View(model);
        }
    }
}