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
        // todo: rename
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var partA = nums[i];
            var searchingPartB = target - partA;
            if (!dict.ContainsKey(searchingPartB))
                dict[searchingPartB] = i;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            // todo: rename
            var partB = nums[i];

            if (!dict.ContainsKey(partB))
                continue;

            var j = dict[partB];
            if (i == j)
                continue;

            // todo: how can I write this in a short form, for example sorted
            return j > i
                ? [i, j]
                : [j, i];

        }

        return [];
    }
}