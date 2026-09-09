using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.SortColors;

/*
Sort colors за O(n). Разбор задачи (решения ещё нет, только анализ).

Нужно закинуть 0 влева а 2 вправо, 1 сами окажутся по середине.

Сразу подумал завести 4 указателя,

потом понял что лучше завести 3 указателя, первый ищет кандидата - 0 или 2,
второй указывает на место слева куда будет вставлятся кандидат 0 (должен указывать не на 0),
третий справа указывает на место куда будет вставлятся кандидат 2 (должен указывать не на 2)

L|       R
202110

  L|     R
002112

     L|R
001122
 */
// code quality 0 — не реализовано, только разбор
// time  O(n) — цель
// mem O(1) — цель
internal class SortColors1MainProgram : IMainProgram
{
    public void RunCode()
    {
        int[] nums = [2, 0, 2, 1, 1, 0];

        var solution = new Solution();
        solution.SortColors(nums);

        Console.WriteLine(string.Join(", ", nums));
    }
}

file class Solution
{
    public void SortColors(int[] nums)
    {
        throw new NotImplementedException();
    }
}