using Microsoft.AspNetCore.Mvc;
using Shafa_Al_Firdaus.Models;
using System.Text;
using Newtonsoft.Json;
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
                // Store the token or use it as needed (e.g., store in session or cookie)
                // For simplicity, just store in TempData and redirect
                TempData["JwtToken"] = token;
                return RedirectToAction("Index", "Home"); // Redirect to a dashboard or any secure page
            }

            // If authentication fails, return to the login page with an error message
            TempData["ErrorMessage"] = "Invalid username or password";
            return RedirectToAction("Index");
        }

        private async Task<string> GetJwtTokenFromWebApi(LoginViewModel loginModel)
        {
            var apiBaseUrl = "https://localhost:44307";
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
