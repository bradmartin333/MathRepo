using BenchmarkDotNet.Attributes;

namespace MyMath
{
    public class Benchmarks
    {
        #region CoordArray

        private readonly CoordArray coordArray = new CoordArray();

        [Benchmark(Baseline = true)]
        public void BruteForceBenchmark()
        {
            coordArray.BruteForceFindIndex(CoordArray.SingleIndex);
        }

        [Benchmark]
        public void OptimizedBenchmark()
        {
            coordArray.OptimizedFindIndex(CoordArray.SingleIndex);
        }

        #endregion
    }
}
