﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Core.Models;
using Globomantics.Filters;

namespace Globomantics.Controllers
{
    [FeatureAuthFilter(FeatureName ="Insurance")]
    public class InsuranceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            return RedirectToAction("Confirmation", "Insurance");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
