namespace PatternsExamples.Algorithms.TwoSum;

internal class TwoSum3MainProgram : IMainProgram
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
        var dictSuitablePartBToIndex = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var partA = nums[i];
            var suitablePartB = target - partA;
            if (!dictSuitablePartBToIndex.ContainsKey(suitablePartB))
                dictSuitablePartBToIndex[suitablePartB] = i;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            var partB = nums[i];

            if (!dictSuitablePartBToIndex.ContainsKey(partB))
                continue;

            var j = dictSuitablePartBToIndex[partB];
            if (i == j)
                continue;

            return [Math.Min(i, j), Math.Max(i, j)];

        }

        return [];
    }
}