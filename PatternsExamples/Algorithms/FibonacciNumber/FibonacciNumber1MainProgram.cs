namespace PatternsExamples.Algorithms.FibonacciNumber;


internal class FibonacciNumber1MainProgram : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();
        var result = solution.Fib(7);
        Console.WriteLine(result);
    }


}

// 1, 2, 3, 4, 5, 6,  7,  8...
// 1, 1, 2, 3, 5, 8, 13, 21, 34, 55

file class Solution
{
    public int Fib(int num)
    {
        if (num <= 2)
            return 1;

        return Fib(num - 1) + Fib(num - 2);
    }
}