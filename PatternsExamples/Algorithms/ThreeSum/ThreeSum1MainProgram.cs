using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.ThreeSum;

/*
Разбор задачи (решения ещё нет, только анализ).

 0  1  2  3 4 5 6 7
-5 -4 -2 -1 0 1 2 3
-10 -9 -8 -7 0 1 2 3

-10 -9 -8 -7 0 4 6 7
 k=>           <=i,j
 i,j=>           <=k

классы триплетов
все нули
0 и зеркальные положительный и отрицательный
2 отриц и один полож
2 полож и один отрицательный

как оптимально составить триплеты
берём кейс 0 и зеркальные положительный и отрицательный

сортировка добавляет дополнительную информацию об элементе, как дополнительную зацепку

-2 0 2
-1 0 1

-5 3 2
-4 3 1

Func(-5 -4 -2 -1 0 1 2 3) - - +
преобразуем входные и выходные данные
Func(revers arr * -1) result * -1 + + -

k=n/2 i,j=n/2

O(n*n)<O(n*n*n)

надо найти все триплеты которые состоят из 2ух полож и одного отрицательного быстрее чем за o(n^3)
подсказка можно разбить пул положительных на две части
 */
//main idea: отсортировать, зафиксировать один элемент и свести задачу к two sum двумя указателями
// code quality 0
//hint: не реализовано, есть только разбор
// time  O(n^2) — цель
// mem O(n) — цель
internal class ThreeSum1MainProgram : IMainProgram
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
        var orignialNums = nums;
        nums = nums.OrderBy(x => x).ToArray();
        var treeplets = new List<List<int>>();
        var hasSet = new HashSet<string>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            var left = i + 1;
            var right = nums.Length - 1;

            while (nums[left] + nums[right] + nums[i] != 0 && left < right)
            {
                if (0 < nums[left] + nums[right] + nums[i])
                    right--;

                if (nums[left] + nums[right] + nums[i] < 0)
                    left++;
            }

            if (left == right)
                continue;

            if (hasSet.Add(GetHashSetKey(i, left, right)))
                treeplets.Add([i, left, right]);
        }

        return treeplets;
    }

    string GetHashSetKey(int first, int second, int theard) => $"{first}_{second}_{theard}";
}