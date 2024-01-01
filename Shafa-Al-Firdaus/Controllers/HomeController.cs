using Microsoft.AspNetCore.Mvc;
using Shafa_Al_Firdaus.Models;
using System.Diagnostics;

namespace Shafa_Al_Firdaus.Controllers
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
            var token = HttpContext.Session.GetString("JwtToken");
            if (token == null) { return RedirectToAction("Index", "Login"); }

            return View();
        }

        public IActionResult Privacy()
        {
            var token = HttpContext.Session.GetString("JwtToken");
            if (token == null) { return RedirectToAction("Index", "Login"); }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}