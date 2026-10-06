namespace PatternsExamples.Algorithms.SortColors;

internal class SortTwoColors3MainProgram : IMainProgram
{
    // массив 1->n нужно вернуть массив из этих же чисел только значали чтобы шли только чётные а потом 
    public void RunCode()
    {
        int[] nums = [0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0];

        // при нахождении 
        int[] dest = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1];

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


        int? i_of_invalid = null;

        for (var i = 0; i < nums.Length; i++)
        {
            if (!i_of_invalid.HasValue && nums[i] == 1)
                i_of_invalid = i;

            if (nums[i] == 0 && i_of_invalid.HasValue)
            {
                (nums[i], nums[i_of_invalid.Value]) = (nums[i_of_invalid.Value], nums[i]);
                i = i_of_invalid.Value;
                i_of_invalid = null;
            }
        }
    }
}