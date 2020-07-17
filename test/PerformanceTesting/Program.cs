using System;
using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Running;
using PerformanceTesting.Routing.ContextActionUrlHelperTests;

namespace PerformanceTesting
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var summary = BenchmarkRunner.Run<CleanControllerNameTests>(); 
        }
    }
}