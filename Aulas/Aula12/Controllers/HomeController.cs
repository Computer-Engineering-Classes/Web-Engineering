using Aula12.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace Aula12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            #region Data preparation
            List<string> tags = new()
            {
                "Porto",
                "Lisboa",
                "Coimbra",
                "Madrid",
                "Valencia",
                "Sevilla",
                "Paris",
                "Lille",
                "Marseille"
            };
            #endregion

            ViewBag.Tags = new HtmlString(
                JsonConvert.SerializeObject(tags.ToArray())
                );

            return View();
        }

        public string TestAjax(string id)
        {
            #region Data preparation
            // this section replaces a hypothetical access to a data repository
            // i.e., a database, for consulting information
            Dictionary<string, List<string>> allCities = new()
            {
                { "PT", new List<string> { "Porto", "Lisboa", "Coimbra" } },
                { "ES", new List<string> { "Madrid", "Valencia", "Sevilla" } },
                { "FR", new List<string> { "Paris", "Lille", "Marseille" } }
            };
            #endregion

            List<string> cities = new();

            if (id != null && allCities.ContainsKey(id))
            {
                cities = allCities[id];
            }

            return JsonConvert.SerializeObject(cities);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
