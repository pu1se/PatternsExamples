using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.MajorityElement;

// code quality 8 — чистый Бойер-Мур, один проход без доп. памяти
// time  O(n)
// mem O(1)
internal class MajorityElement1MainProgram : IMainProgram
{
    public void RunCode()
    {
        int[] nums = [5, 5, 1, 1, 1, 5, 5];

        Solution solution = new();
        var result = solution.MajorityElement(nums);

        Console.WriteLine(result);
    }
}

file class Solution
{
    // Boyer-Moore voting.
    public int MajorityElement(int[] nums)
    {
        var majorityElement = 0;
        var vote = 0;

        foreach (var num in nums)
        {
            if (num == majorityElement)
            {
                vote++;
            }
            else
            {
                vote--;
            }

            if (vote == -1)
            {
                majorityElement = num;
                vote = 1;
            }
        }

        return majorityElement;
    }
}