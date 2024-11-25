using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<Fibonacci>();

//Fibonacci.FibonacciRecursiveBenchmark();
//Fibonacci.FibonacciWithoutRecursionBenchmark();
//Fibonacci.FibonacciWithYieldBenchmark(); 
