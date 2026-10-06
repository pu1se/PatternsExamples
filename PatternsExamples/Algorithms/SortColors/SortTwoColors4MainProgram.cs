namespace PatternsExamples.Algorithms.SortColors;

internal class SortTwoColors4MainProgram : IMainProgram
{
    // массив 1->n нужно вернуть массив из этих же чисел только значали чтобы шли только чётные а потом 
    public void RunCode()
    {
        int[] nums = [0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0];

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


        int j = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                j++;
            }
        }
    }
}