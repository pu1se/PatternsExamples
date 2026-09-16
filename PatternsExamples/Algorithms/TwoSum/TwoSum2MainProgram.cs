namespace PatternsExamples.Algorithms.TwoSum;

internal class TwoSum2MainProgram : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();
        var result = solution.TwoSum([-1, -2, -3, -4, -5], -8);
        result = solution.TwoSum([4, 5, 6], 10);
    }
}


// without sorting
// O(n)
// create dictionary O(n) + one pass throw array
file class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var currentValue = nums[i];
            var searchingElement = target - currentValue;
            if (!dict.ContainsKey(searchingElement))
                dict[searchingElement] = i;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            var searchingElement = nums[i];

            if (dict.ContainsKey(searchingElement))
            {
                var j = dict[searchingElement];

                if (i == j)
                    continue;

                return j > i
                    ? [i, j]
                    : [j, i];
            }

        }

        return [];
    }
}