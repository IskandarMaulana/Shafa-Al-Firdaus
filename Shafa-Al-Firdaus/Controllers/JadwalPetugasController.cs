using Microsoft.AspNetCore.Mvc;
using Shafa_Al_Firdaus.Models;
using System.Diagnostics;

namespace Shafa_Al_Firdaus.Controllers
{
    public class JadwalPetugasController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public JadwalPetugasController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("JwtToken");

            ViewData["Token"] = token;
            return View();
        }

        public IActionResult Privacy()
        {
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

            ViewData["Token"] = token;
            return View();
        }
        public IActionResult Update(string id_jadwal)
        {
            var token = HttpContext.Session.GetString("JwtToken");

            ViewData["Token"] = token;
            ViewBag.IdJadwal = id_jadwal;
            return View();
        }
    }
}
