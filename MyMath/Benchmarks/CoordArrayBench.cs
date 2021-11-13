using BenchmarkDotNet.Attributes;

namespace MyMath.Benchmarks
{
    public class CoordArrayBench
    {
        private readonly CoordArray coordArray = new CoordArray();

        [Benchmark]
        public void BruteForceBenchmark()
        {
            coordArray.BruteForceFindIndex(CoordArray.SingleIndex);
        }

        [Benchmark]
        public void OptimizedBenchmark()
        {
            coordArray.OptimizedFindIndex(CoordArray.SingleIndex);
        }
    }
}
