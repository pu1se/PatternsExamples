namespace PatternsExamples.Algorithms.ThreeSum;
//main idea: отсортировать, зафиксировать один элемент и свести задачу к two sum двумя указателями
// code quality 0
//hint: не реализовано, есть только разбор
// time  O(n^2) — цель
// mem O(n) — цель
internal class ThreeSum4MainProgram : IMainProgram
{
    public void RunCode()
    {
        int[] nums = [-1, 0, 1, 2, -1, -4];

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
        var uniqueTreepletsHashSet = new HashSet<(int, int, int)>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            var left = i + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];

                switch (sum)
                {
                    case var _ when 0 < sum:
                        right--;
                        break;

                    case var _ when sum < 0:
                        left++;
                        break;

                    case var _ when sum == 0:
                        uniqueTreepletsHashSet.Add((nums[i], nums[left], nums[right]));

                        left++;
                        right--;
                        break;
                }
            }
        }

        return uniqueTreepletsHashSet
            .Select(x => new List<int> { x.Item1, x.Item2, x.Item3 })
            .ToList();
    }
}