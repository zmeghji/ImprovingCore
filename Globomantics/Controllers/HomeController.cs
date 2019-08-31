using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;
using Globomantics.Core.Models;
using Globomantics.Constraints;
using Globomantics.Conventions;

namespace Globomantics.Controllers
{
    public class HomeController : Controller
    {
        private IRateService rateService;

        public HomeController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        [Route("home/promotion2/{token:tokenCheck}")]
        public IActionResult Promotion2([BindName(Name ="token")] string promoCode)
        {
            ViewBag.Token = promoCode;
            return View();
        }

        [Route("home/promotion/{token:tokenCheck}")]
        public IActionResult Promotion()
        {
            return View();
        }
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("")]
        [MobileSelector]
        public IActionResult MobileIndex()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
