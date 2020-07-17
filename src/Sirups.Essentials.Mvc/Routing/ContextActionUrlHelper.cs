using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Sirups.Essentials.Mvc.Routing
{
    public class ContextActionUrlHelper : IActionUrlHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly LinkGenerator _linkGenerator;

        [ExcludeFromCodeCoverage]
        public ContextActionUrlHelper(IHttpContextAccessor contextAccessor, LinkGenerator linkGenerator)
        {
            _contextAccessor = contextAccessor;
            _linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Generates a URL for a controller action
        /// </summary>
        /// <param name="controller">The name of the controller. Works even if it ends on controller.</param>
        /// <param name="action">The name of the action</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="options">The link generator options</param>
        /// <returns>The url for the action</returns>
        [ExcludeFromCodeCoverage]
        public string GetUrl(string controller, string action, object routeValues, LinkOptions options)
        {
            return _linkGenerator.GetPathByAction(_contextAccessor.HttpContext, action, CleanControllerName(controller),
                routeValues, null, default(FragmentString), options);
        }

        public static string CleanControllerName(string controllerName)
        {
            if (!controllerName.EndsWith("Controller", StringComparison.InvariantCulture))
                return controllerName;

            return controllerName.Substring(0, controllerName.Length - 10);
        }
    }
}