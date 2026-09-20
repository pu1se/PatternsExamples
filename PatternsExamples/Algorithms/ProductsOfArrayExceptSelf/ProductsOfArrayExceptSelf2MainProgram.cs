namespace PatternsExamples.Algorithms.ProductsOfArrayExceptSelf;


// O(n) without division. With the first pass throw array I input left multiplier. 
// With the second pass I input right multiplier.
internal class ProductsOfArrayExceptSelf2MainProgram : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();
        var output = solution.ProductExceptSelf([1, 2, 4, 6]);// [48,24,12,8] => left[1, 1, 2, 8] and right[48,24,6,1]
        output = solution.ProductExceptSelf([-1, 0, 1, 2, 3]);// [0,-6,0,0,0] => left[1, 0, 0, 0, 0] and right[0, 0, 0, 1]
    }
}

file class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        if (nums.Length < 2)
            return nums;


        var leftArrayWithProduct = Enumerable.Repeat(1, nums.Length).ToArray();
        for (var i = 1; i < nums.Length; i++)
            leftArrayWithProduct[i] = nums[i - 1] * leftArrayWithProduct[i - 1];

        var rightArrayWithProduct = Enumerable.Repeat(1, nums.Length).ToArray();
        for (var i = nums.Length - 2; i >= 0; i--)
            rightArrayWithProduct[i] = nums[i + 1] * rightArrayWithProduct[i + 1];

        for (var i = 0; i < nums.Length; i++)
            nums[i] = leftArrayWithProduct[i] * rightArrayWithProduct[i];

        return nums;
    }
}
