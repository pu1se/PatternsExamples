namespace PatternsExamples.Algorithms.SortColors;

internal class SortTwoColors2MainProgram : IMainProgram
{
    // массив 1->n нужно вернуть массив из этих же чисел только значали чтобы шли только чётные а потом 
    public void RunCode()
    {
        int[] nums = [1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0];

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

        var first_one_i = 0;
        var last_zero_i = 1;

        while (first_one_i < nums.Length && nums[first_one_i] != 1)
            first_one_i++;

        while (true)
        {
            while (last_zero_i < nums.Length && nums[last_zero_i] != 0)
                last_zero_i++;

            if (last_zero_i == nums.Length)
                break;

            (nums[first_one_i], nums[last_zero_i]) = (nums[last_zero_i], nums[first_one_i]);
            first_one_i++;
        }
    }
}