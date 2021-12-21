using BenchmarkDotNet.Attributes;

namespace MyMath.Benchmarks
{
    public class SDL800Bench
    {
        [Benchmark]
        public void StringReaderBenchmark()
        {
            SDL800 sDL800 = new SDL800();
        }
    }
}
