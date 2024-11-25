using System.Text;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class Fibonacci
{
    public long N = 40;
    public long FibonacciRecursive(long n)
    {
        switch (n)
        {
            case 0: return 0;
            case 1: return 1;
            default:
                {
                    return FibonacciRecursive(n - 2) + FibonacciRecursive(n - 1);
                }
        }
    }

    public static long FibonacciWithoutRecursion(long n)
    {
        switch (n)
        {
            case 0: return 0;
            case 1: return 1;
            default:
                {
                    long last2 = 0;
                    long last1 = 1;
                    long fibonacci = 0;
                    for (int i = 2; i <= n; i++)
                    {
                        fibonacci = last2 + last1;
                        last2 = last1;
                        last1 = fibonacci;
                    }
                    return fibonacci;
                }
        }
    }

    public static IEnumerable<long> FibonacciWithYield()
    {
        yield return 0;
        yield return 1;

        long last2 = 0;
        long last1 = 1;
        while (true)
        {
            var sum = last2 + last1;
            last2 = last1;
            last1 = sum;
            yield return sum;
        }
    }

    [Benchmark]
    public void FibonacciRecursiveBenchmark()
    {
        StringBuilder sb = new();
        for (int i = 0; i < N; i++)
        {
            sb.Append(FibonacciRecursive(i).ToString());
            sb.Append(',');
        }
        Console.WriteLine(sb);
    }

    [Benchmark]
    public void FibonacciWithoutRecursionBenchmark()
    {
        StringBuilder sb = new();
        for (int i = 0; i < N; i++)
        {
            sb.Append((FibonacciWithoutRecursion(i).ToString()));
            sb.Append(',');
        }
        Console.WriteLine(sb);
    }

    [Benchmark(Baseline = true)]
    public void FibonacciWithYieldBenchmark()
    {
        StringBuilder sb = new();
        using var enumerator = FibonacciWithYield().GetEnumerator();
        for (int i = 0; i < N; i++)
        {
            enumerator.MoveNext();
            sb.Append(enumerator.Current.ToString());
            sb.Append(',');
        }
        Console.WriteLine(sb);
    }
}
