using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using Sirups.Essentials.Mvc.Routing;

namespace PerformanceTesting.Routing.ContextActionUrlHelperTests
{
    [ExcludeFromCodeCoverage]
    public class CleanControllerNameTests
    {
        [Benchmark] 
        public void EndsWith() => ContextActionUrlHelper.CleanControllerName("TestController");
    }
}