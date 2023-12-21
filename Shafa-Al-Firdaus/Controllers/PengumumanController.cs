using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shafa_Al_Firdaus.Models;
using System.Diagnostics;

namespace Shafa_Al_Firdaus.Controllers
{
    public class PengumumanController : Controller
    {
        private List<SelectListItem> _list;

        private readonly ILogger<HomeController> _logger;


        public PengumumanController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("JwtToken");
            if (token == null) { return RedirectToAction("Index", "Login"); }

            ViewData["Token"] = token;
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.DisplayName ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Create()
        {
            var token = HttpContext.Session.GetString("JwtToken");
            if (token == null) { return RedirectToAction("Index", "Login"); }

            ViewData["Token"] = token;
            return View();
        }
        public IActionResult Update(string id)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            if (token == null) { return RedirectToAction("Index", "Login"); }

            ViewData["Token"] = token;
            ViewBag.IdPengumuman = id;
            return View();
        }
    }
}

