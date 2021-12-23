using BenchmarkDotNet.Attributes;

namespace MyMath.Benchmarks
{
    public class SpatialGeometryBench
    {
        [Benchmark]
        public void CalculateThetasBenchmark()
        {
            SpatialGeometry.GenerateLevelingInfo();
        }
    }
}
