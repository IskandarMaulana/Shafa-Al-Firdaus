using Microsoft.AspNetCore.Mvc;

namespace Shafa_Al_Firdaus.Controllers
{
    public class AkunController : Controller
    {
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("JwtToken");
            if (token == null) { return RedirectToAction("Index", "Login"); }

            ViewData["Token"] = token;
            return View();
        }
    }
}
