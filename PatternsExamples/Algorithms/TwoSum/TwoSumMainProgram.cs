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
        var sortedNums = nums.OrderBy(x => x)
            .Select((value, index) => (value, index))
            .ToArray();

        while (left < right)
        {
            var sum = sortedNums[left].value + sortedNums[right].value;
            switch (sum)
            {
                case var _ when sum == target:
                    return sortedNums[left].index < sortedNums[right].index
                        ? [sortedNums[left].index, sortedNums[right].index]
                        : [sortedNums[right].index, sortedNums[left].index];

                case var _ when sum < target:
                    left++;
                    break;

                case var _ when sum > target:
                    right--;
                    break;
            }
        }

        return [];
    }
}