using BenchmarkDotNet.Running;
using System;

namespace MyMath
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks.SpatialGeometryBench>();
            Console.Write(summary);
            Console.ReadKey();
        }
    }
}
