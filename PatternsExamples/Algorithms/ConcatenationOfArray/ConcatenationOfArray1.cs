namespace PatternsExamples.Algorithms.ConcatenationOfArray;

internal class ConcatenationOfArray1 : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();
        var arr = solution.GetConcatenation([1, 4, 1, 2]);

        Console.WriteLine(arr);
    }
}

file class Solution
{
    public int[] GetConcatenation(int[] nums)
    {
        if (nums == null)
            return nums;

        var nums_ext = new int[nums.Length * 2];
        var n = nums.Length;
        for (var i = 0; i < nums.Length; i++)
        {
            nums_ext[i] = nums[i];
            nums_ext[i + n] = nums[i];
        }

        return nums_ext;
    }
}