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
// code quality 0 — не реализовано, только разбор
// time  O(n^2) — цель
// mem O(n) — цель
internal class ThreeSum1MainProgram : IMainProgram
{
    public void RunCode()
    {
        int[] nums = [-5, -4, -2, -1, 0, 1, 2, 3];

        var solution = new Solution();
        var triplets = solution.ThreeSum(nums);

        Console.WriteLine(triplets.Count);
    }
}

file class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        throw new NotImplementedException();
    }
}