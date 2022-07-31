using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Html;

namespace WebApp.Components
{
    public class CitySummary : ViewComponent
    {
        private CitiesData data;

        public CitySummary(CitiesData cdata)
        {
            data = cdata;
        }

        public IViewComponentResult Invoke()
        {
            return new HtmlContentViewComponentResult(
                    new HtmlString("This is a <h3><i>string</i></h3>"));
        }
    }
}