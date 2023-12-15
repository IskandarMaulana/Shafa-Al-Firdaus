﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
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
            return View();
        }
        public IActionResult Update(string id)
        {
            ViewBag.Name = id;
            return View();
        }
    }
}

