using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Filters
{
    public class FeatureAuthTypeFilter : IAuthorizationFilter
    {
        private readonly IFeatureService FeatureService;
        private readonly string FeatureName;

        public FeatureAuthTypeFilter(IFeatureService featureService, string featureName)
        {
            FeatureService = featureService;
            FeatureName = featureName;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!FeatureService.IsFeatureActive(FeatureName))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
