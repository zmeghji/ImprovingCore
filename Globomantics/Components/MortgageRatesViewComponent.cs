using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Components
{
    public class MortgageRatesViewComponent : ViewComponent
    {
        private readonly IRateService RateService;

        public MortgageRatesViewComponent(IRateService rateService)
        {
            this.RateService = rateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(RateService.GetMortgageRates());
        }
    }
}
