using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Shafa_Al_Firdaus.Models;
using System.Diagnostics;
using System.Net.Http;

namespace Shafa_Al_Firdaus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("JwtToken");
            if (token == null) { return RedirectToAction("Index", "Login"); }

            var jadwal = GetJadwalFromWebApi();

            ViewBag.Jadwal = jadwal;

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

        [HttpGet]
        public async Task<string> GetJadwalFromWebApi()
        {
            var endpoint = $"https://api.aladhan.com/v1/calendar/{DateTime.Now.Year}/{DateTime.Now.Month}?latitude=-6.3488574&longitude=107.14689&method=20";

            using var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var jsonObject = await response.Content.ReadAsStringAsync();
                return jsonObject;
            }

            return null;
        }
    }
}