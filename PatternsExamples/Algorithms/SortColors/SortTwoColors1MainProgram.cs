namespace PatternsExamples.Algorithms.SortColors;

internal class SortTwoColors1MainProgram : IMainProgram
{
    public void RunCode()
    {
        int[] nums = [1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0];

        var solution = new Solution();
        solution.SortColors(nums);

        Console.WriteLine(string.Join(", ", nums));
    }
}

file class Solution
{
    public void SortColors(int[] nums)
    {
        if (nums == null)
            return;

        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            if (nums[left] > nums[right])
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
            }


            if (nums[left] == 0)
                left++;

            if (nums[right] == 1)
                right--;
        }
    }
}