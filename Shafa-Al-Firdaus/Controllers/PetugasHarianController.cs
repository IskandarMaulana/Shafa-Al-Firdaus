using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shafa_Al_Firdaus.Models;
using System.Diagnostics;

namespace Shafa_Al_Firdaus.Controllers
{
    public class PetugasHarianController : Controller
    {
        private List<SelectListItem> _list;

        private readonly ILogger<HomeController> _logger;


        public PetugasHarianController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
            return View();
        }
        public IActionResult Update(string Name)
        {
            ViewBag.Name = Name;
            return View();
        }
    }
}

