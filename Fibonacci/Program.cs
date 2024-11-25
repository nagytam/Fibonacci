using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<Fibonacci>();

// var fibonacci = new Fibonacci();
// fibonacci.FibonacciRecursiveBenchmark();
// fibonacci.FibonacciWithoutRecursionBenchmark();
// fibonacci.FibonacciWithYieldBenchmark(); 
