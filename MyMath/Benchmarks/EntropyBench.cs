using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Drawing;

namespace MyMath.Benchmarks
{
    public class EntropyBench
    {
        private Bitmap bitmap = Properties.Resources.cube;

        [Benchmark]
        public void NugetBenchmark()
        {
            List<double> redPixels = Entropy.DeconstructImage(bitmap);
            Entropy.NugetCalc(redPixels);
        }

        [Benchmark]
        public void SpyBenchmark()
        {
            List<double> redPixels = Entropy.DeconstructImage(bitmap);
            Entropy.SpyCalc(redPixels);
        }
    }
}
