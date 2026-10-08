namespace PatternsExamples.Algorithms.RemoveElement;

// падающий камень
internal class RemoveElement1 : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();
        int[] nums = [3, 2, 2, 3];
        var k = solution.RemoveElement(nums, 3);

        Console.WriteLine(nums.Join(", "));
    }
}

file class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        var boundary_i = nums.Length - 1;
        var num_of_valid = 0;

        for (var i = nums.Length - 1; i > -1; i--)
        {
            if (nums[i] == val)
            {
                var j = i;

                while (j < boundary_i)
                {
                    (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                    j++;
                }

                boundary_i--;
            }
            else
            {
                num_of_valid++;
            }
        }

        return num_of_valid;
    }
}