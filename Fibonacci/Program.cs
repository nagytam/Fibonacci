﻿long Fibonacci(long n)
{
    switch (n)
    {
        case 0: return 0;
        case 1: return 1;
        default:
            {
                return Fibonacci(n-2) + Fibonacci(n-1);
            }
    }
}

long Fibonacci2(long n)
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

Console.WriteLine(Fibonacci(50));
Console.WriteLine(Fibonacci2(50));
