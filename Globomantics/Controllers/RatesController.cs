using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;

namespace Globomantics.Controllers
{
    public class RatesController : Controller
    {
        private IRateService rateService;

        public RatesController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        [HttpGet]
        [Route("api/rates/mortage")]
        [Route("api/{version:versionCheck(1)}/rates/mortage")]
        public IActionResult GetMortgageRates()
        {
            return Ok(rateService.GetMortgageRates());
        }

        [HttpGet]
        [Route("api/{version:versionCheck(2)}/rates/mortage")]
        public IActionResult GetMortgageRatesV2()
        {
            return Ok(rateService.GetMortgageRates());
        }
        [HttpGet]
        [Route("credit")]
        public IActionResult GetCreditCardRates()
        {
            return Ok(rateService.GetCreditCardRates());
        }


        [HttpGet]
        [Route("cd")]
        public IActionResult GetCDRates()
        {
            return Ok(rateService.GetCDRates());
        }
    }
}
