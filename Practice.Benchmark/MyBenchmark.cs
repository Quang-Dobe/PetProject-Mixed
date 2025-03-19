using BenchmarkDotNet.Attributes;

namespace SelfLearning.Benchmark
{
    [MemoryDiagnoser]
    public class MyBenchmark
    {
        [Benchmark]
        public void FirstFunc()
        {
            var a = 1;
            var b = a % 2 == 0;
        }

        [Benchmark]
        public void SecondFunc()
        {
            var a = 1;
            var b = int.IsEvenInteger(a);
        }
    }
}
