using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.RangeSum;

// чтобы получить range sum нужно от суммы отнять сумму невходящую в range
// code quality 2 — падает: prefixSums объявлен пустым и не выделяется
// time  O(n) построение, O(1) запрос
// mem O(n)
internal class RangeSum1dMainProgram : IMainProgram
{
    public void RunCode()
    {
        var solution = new NumArray([-2, 0, 3, -5, 2, -1]);

        var output = solution.SumRange(0, 2);
        output = solution.SumRange(2, 5);
        output = solution.SumRange(0, 5);

        Console.WriteLine(output);
    }
}

file class NumArray
{
    int[] prefixSums = [];

    // store sum inplace instead of dictSum
    public NumArray(int[] nums)
    {
        var sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            prefixSums[i] = sum;
        }
    }

    public int SumRange(int left, int right)
    {
        // to avoid this "if" init prefixSum[0] = 0
        if (left == 0)
            return prefixSums[right];

        return prefixSums[right] - prefixSums[left - 1];
    }
}