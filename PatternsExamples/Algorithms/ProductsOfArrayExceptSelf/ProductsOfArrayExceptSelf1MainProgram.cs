namespace PatternsExamples.Algorithms.ProductsOfArrayExceptSelf;


// O(n) with division
internal class ProductsOfArrayExceptSelf1MainProgram : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();
        var output = solution.ProductExceptSelf([1, 2, 4, 6]);
        output = solution.ProductExceptSelf([-1, 0, 1, 2, 3]);
    }
}

file class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var mult = 1;
        var multExceptZero = 1;
        var zeroNums = 0;

        foreach (var num in nums)
        {
            if (num == 0)
                zeroNums++;
            else
                multExceptZero *= num;

            mult *= num;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            nums[i] = zeroNums switch
            {
                0 => mult / nums[i],
                1 when nums[i] == 0 => multExceptZero,
                _ => 0
            };
        }

        return nums;
    }
}
