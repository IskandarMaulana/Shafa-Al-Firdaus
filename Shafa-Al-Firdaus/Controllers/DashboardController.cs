using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shafa_Al_Firdaus.Models;
using System.Net.Http;
using System.Text;

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

            // You might want to do something with jadwal here, for example, pass it to the view
            ViewBag.Jadwal = jadwal;

            Console.WriteLine(ViewBag.Jadwal);
            return View();
        }
        private async Task<JObject> GetJadwalFromWebApi()
        {
            //var apiBaseUrl = "https://localhost:44307";
            var endpoint = $"https://api.aladhan.com/v1/calendar/{DateTime.Now.Year}/{DateTime.Now.Month}?latitude=-6.348014&longitude=107.148479&method=2";

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
    }
}
