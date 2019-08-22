using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.TagHelpers
{
    [HtmlTargetElement("a", Attributes ="active-url")]
    public class ActiveTagHelper: TagHelper
    {
        public string ActiveUrl { get; set; }
        private readonly IHttpContextAccessor HttpContextAccessor;

        public ActiveTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (HttpContextAccessor.HttpContext.Request.Path.ToString().Contains(ActiveUrl))
            {
                var existingAttrs = output.Attributes["class"]?.Value;
                output.Attributes.SetAttribute("class", "active " + existingAttrs);
            }
        }
    }
}
