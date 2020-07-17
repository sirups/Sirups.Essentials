using Microsoft.AspNetCore.Routing;

namespace Sirups.Essentials.Mvc.Routing
{
    public interface IActionUrlHelper
    {
        string GetUrl(string controller, string action, object routeValues = null, LinkOptions options = null);
    }
}