using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GroceryStore.Controllers
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
            var isAuthenticated = HttpContext.Session.GetString("Email");
            var username = HttpContext.Session.GetString("Name");
            ViewData["Email"] = isAuthenticated;
            ViewData["Name"] = username;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
