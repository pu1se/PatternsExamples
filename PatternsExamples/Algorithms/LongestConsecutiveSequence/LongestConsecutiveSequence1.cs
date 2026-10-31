namespace PatternsExamples.Algorithms.LongestConsecutiveSequence;

/*
 Longest Consecutive Sequence: идея - меняем структуру данных чтобы решить задачу.
за первый проход засовываем массив в Хеш сет, считаем мин и макс значение.
второй проход идёт по Хеш сет от мин значения для макс значения с шагом 1 
и при этом счётчик считает последовательность. 
при разрыве последовательности сравниваем счётчик с максимальной найденной последовательность.
 */
internal class LongestConsecutiveSequence1 : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();
        var result = solution.LongestConsecutive([0]);

        Console.WriteLine(result);
    }
}

file class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return 0;

        var numsHashSet = new HashSet<int>(nums);
        var minNum = int.MaxValue;
        var maxNum = int.MinValue;

        foreach (var num in nums)
        {
            minNum = Math.Min(minNum, num);
            maxNum = Math.Max(maxNum, num);
            numsHashSet.Add(num);
        }


        var maxLength = 0;
        var currentLength = 0;

        // переделать на for
        while (true)
        {
            if (numsHashSet.Contains(minNum))
            {
                currentLength++;
            }
            else
            {
                maxLength = Math.Max(maxLength, currentLength);
                currentLength = 0;
            }

            if (minNum == maxNum + 1)
            {
                break;
            }

            minNum++;
        }

        return maxLength;
    }
}