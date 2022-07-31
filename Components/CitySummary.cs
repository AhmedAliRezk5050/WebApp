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

        public string Invoke()
        {
            return $"{data.Cities.Count()} cities, "
            + $"{data.Cities.Sum(c => c.Population)} people";
        }
    }
}