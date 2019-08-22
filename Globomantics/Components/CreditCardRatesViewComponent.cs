using Globomantics.Core.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Components
{
    public class CreditCardRatesViewComponent : ViewComponent
    {
        private readonly IRateService RateService;

        public CreditCardRatesViewComponent(IRateService rateService)
        {
            this.RateService = rateService;
        }
        public async Task<IViewComponentResult> InvokeAsync (string title, string subtitle)
        {
            var ratesVM = new CreditCardWidgetVM
            {
                Rates = RateService.GetCreditCardRates(),
                WidgetTitle = title,
                WidgetSubTitle = subtitle
            };
            return View(ratesVM);
        }
    }
    public class CreditCardWidgetVM
    {
        public List<Rate> Rates { get; set; }
        public string WidgetTitle { get; set; }
        public string WidgetSubTitle { get; set; }
    }
}
