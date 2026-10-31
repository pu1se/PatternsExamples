namespace PatternsExamples.Algorithms.SubarraySumEqualsK;

/*
 Subarray Sum Equals K: идея - создать prefix sum dict где 
 key => сумма до индекса, val => индекс. 
 и потом методом двух указателей идущих на встречу друг другу найти все подсуммы дающие сумму. 
 подсуммы складываем в массив и потом рекурсивно для найденных подсум ищем подсуммы 
 из которых она может состоять.
 */

internal class SubarraySumEquals_K1 : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();
        solution.SubarraySum([-1, 1, 2, 3, 4], 2);
    }
}

file class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        nums = nums.OrderBy(i => i).ToArray();
        var min_sum = nums.First();
        var prefixSum = new Dictionary<int, int>();
        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            prefixSum[sum] = i;
        }

        //var pref_sum2 = sum;
        var subarraySum = new List<(int, int)>(20);

        /*while (min_sum < pref_sum2)
        {
            
        }*/

        foreach (var pref_sum2 in prefixSum)
        {
            var pref_sum1_key = pref_sum2.Key - k;
            if (prefixSum.ContainsKey(pref_sum1_key))
            {
                var pref_sum1 = prefixSum[pref_sum1_key];
                subarraySum.Add((pref_sum1_key, pref_sum2.Key));
            }
        }

        return 0;
    }
}