using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Sirups.Essentials.Mvc.Routing;

namespace TestWebApplication.Controllers
{
    [ExcludeFromCodeCoverage]
    public class TestController : ControllerBase
    {
        private readonly IActionUrlHelper _actionUrlHelper;

        public TestController(IActionUrlHelper actionUrlHelper)
        {
            _actionUrlHelper = actionUrlHelper;
        }

        [HttpGet("test/urls")]
        public async Task<IActionResult> TestUrls()
        {
            return Ok(new {Url = _actionUrlHelper.GetUrl(nameof(TestController), nameof(OtherUrl), null, new LinkOptions
            {
                AppendTrailingSlash = true
            })});
        }
        
        [HttpGet("test/otherurl")]
        public async Task<IActionResult> OtherUrl()
        {
            return Ok();
        }
    }
}