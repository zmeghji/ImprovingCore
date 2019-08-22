using Globomantics.Core.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.TagHelpers
{
    [HtmlTargetElement("cdrate")]
    public class CDRateTagHelper: TagHelper
    {
        private readonly IRateService RateService;
        public CDTermLength TermLength { get; set; }
        public string Title { get; set; }
        public string MeterPercent { get; set; }
        public CDRateTagHelper(IRateService rateService)
        {
            RateService = rateService;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var rate = RateService.GetCDRateByTerm(TermLength);
            output.Content.SetHtmlContent($@"<div class=""meter"">
                    <p>{Title}</p>
                    <div class=""progress"">
                        <div class=""progress-bar bg-info"" style=""width: {MeterPercent}%"">{Title}</div>
                    </div>
                </div>");
        }
    }
}
