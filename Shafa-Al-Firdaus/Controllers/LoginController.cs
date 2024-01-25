using Microsoft.AspNetCore.Mvc;
using Shafa_Al_Firdaus.Models;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Shafa_Al_Firdaus.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            // Validate loginModel (username and password)

            // Call Web API for authentication
            var token = await GetJwtTokenFromWebApi(loginModel);

            if (token != null)
            {
                // For simplicity, just store in TempData and redirect
                //TempData
                //TempData["JwtToken"] = token;

                // Store the token or use it as needed (e.g., store in session or cookie)

                //Cookie
                /*HttpContext.Response.Cookies.Append("JwtToken", token, new CookieOptions
                {
                    HttpOnly = true, // Atribut ini mencegah akses langsung oleh JavaScript
                    Secure = true,   // Hanya mengizinkan pengiriman cookie melalui HTTPS
                    SameSite = SameSiteMode.Strict, // Mencegah penanganan cookie dari luar situs
                    Expires = DateTimeOffset.UtcNow.AddHours(1) // Sesuaikan dengan kebutuhan
                });*/
                
                //Session
                HttpContext.Session.SetString("JwtToken", token);

                return Json(new { success = true, message = "Berhasil Login" });
            }

            // If authentication fails, return to the login page with an error message
            TempData["ErrorMessage"] = "Nama Pengguna atau Kata Sandi salah";
            return Json(new { success = false, message = "Nama Pengguna atau Kata Sandi salah" });
        }

        private async Task<string> GetJwtTokenFromWebApi(LoginViewModel loginModel)
        {
            var apiBaseUrl = "http://10.5.0.123:9091";
            var endpoint = $"{apiBaseUrl}/api/token/submit";

            using var httpClient = _httpClientFactory.CreateClient();

            var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                return token;
            }

            return null;
        }
    }
}
