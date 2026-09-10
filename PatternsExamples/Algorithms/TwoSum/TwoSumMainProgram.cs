using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.TwoSum;

internal class TwoSumMainProgram : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();
        var result = solution.TwoSum([-1, -2, -3, -4, -5], -8);
        result = solution.TwoSum([4, 5, 6], 10);
    }
}


// use two pointers pattern left and right which go to the middle
// if sum of current pointer values is > target => move right element
// if sum of current pointer values is <= target => move left element
// O(n)
file class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        var orignialNums = nums;
        var sortedNums = nums.OrderBy(x => x).ToArray();

        while (left < right)
        {
            var sum = sortedNums[left] + sortedNums[right];
            if (sum == target)
            {
                return ReturnOriginalIndexes(orignialNums, sortedNums[left], sortedNums[right]);
            }

            if (sum < target)
                left++;
            else
                right--;
        }

        return [];
    }

    private static int[] ReturnOriginalIndexes(int[] orignialNums, int leftValue, int rightValue)
    {
        var left = 0;
        while (orignialNums[left] != leftValue)
            left++;

        var right = orignialNums.Length - 1;
        while (orignialNums[right] != rightValue)
            right--;

        return left < right ? [left, right] : [right, left];
    }
}