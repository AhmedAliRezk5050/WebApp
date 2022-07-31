using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

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
            return Content("This is a <h3><i>string</i></h3>");
        }
    }
}