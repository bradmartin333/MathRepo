using BenchmarkDotNet.Running;
using System;

namespace MyMath
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<Benchmarks.CoordArrayBench>();
            //var summary = BenchmarkRunner.Run<Benchmarks.EntropyBench>();
            var summary = BenchmarkRunner.Run<Benchmarks.SDL800Bench>();
            Console.Write(summary);
            Console.ReadKey();
        }
    }
}
