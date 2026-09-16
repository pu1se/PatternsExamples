namespace PatternsExamples.Algorithms.ThreeSum;
//main idea: отсортировать, зафиксировать один элемент и свести задачу к two sum двумя указателями
// code quality 0
//hint: не реализовано, есть только разбор
// time  O(n^2) — цель
// mem O(n) — цель
internal class ThreeSum2MainProgram : IMainProgram
{
    public void RunCode()
    {
        int[] nums = [-2, 1, 1];

        var solution = new Solution();
        var triplets = solution.ThreeSum(nums);

        Console.WriteLine(triplets.Count);
    }
}

file class Solution
{
    public List<List<int>> ThreeSum(int[] nums)
    {
        nums = nums.OrderBy(x => x).ToArray();
        var triplets = new List<List<int>>();

        for (var i = 0; i < nums.Length - 2; i++)
        {
            if (triplets.Any() && triplets.Last()[0] == nums[i])
                continue;

            var left = i + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];

                if (sum > 0)
                    right--;

                if (sum < 0)
                    left++;

                if (sum == 0)
                {
                    triplets.Add([nums[i], nums[left], nums[right]]);

                    left++;
                    right--;

                    while (left < right && triplets.Last()[1] == nums[left])
                        left++;

                    while (left < right && triplets.Last()[2] == nums[right])
                        right--;
                }
            }
        }

        return triplets;
    }
}