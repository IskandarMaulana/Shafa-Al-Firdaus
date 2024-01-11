using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shafa_Al_Firdaus.Models;

namespace Shafa_Al_Firdaus.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var jadwal = await GetJadwalFromWebApi();

            ViewBag.Jadwal = jadwal;

            HttpContext.Session.Remove("JwtToken");

            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public async Task<IActionResult> Iqamah()
        {
            var jadwal = await GetJadwalFromWebApi();

            ViewBag.Jadwal = jadwal;

            HttpContext.Session.Remove("JwtToken");

            return View();
        }

        private async Task<JObject> GetJadwalFromWebApi()
        {
            var endpoint =
                $"https://api.aladhan.com/v1/calendar/{DateTime.Now.Year}/{DateTime.Now.Month}?latitude=-6.3392749&longitude=107.1601183&method=2&tune=-20,-20,-3,3,2,2,0,15";

            using var httpClient = _httpClientFactory.CreateClient();

            //var content = new StringContent(JsonConvert.SerializeObject(), Encoding.UTF8, "application/json");
            var response = await httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(jsonString);
                var jsonObject = JObject.Parse(jsonString);
                //Console.WriteLine(jsonObject.ToString());
                return jsonObject;
            }

            return null;
        }

        public async Task<IActionResult> BlackScreen()
        {
            var jadwal = await GetJadwalFromWebApi();

            ViewBag.Jadwal = jadwal;
            return View();
        }
    }
}
