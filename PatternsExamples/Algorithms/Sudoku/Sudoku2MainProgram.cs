using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.Sudoku;

// code quality 7 — без аллокаций, но ключи на магических числах
// time  O(n^2), n — сторона доски
// mem O(n^2)
internal class Sudoku2MainProgram : IMainProgram
{
    public void RunCode()
    {
        char[][] board =
        [
            ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
            ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
            ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
            ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
            ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
            ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
            ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
            ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
            ['.', '.', '.', '.', '8', '.', '.', '7', '9'],
        ];

        var solution = new Solution();
        var isValid = solution.IsValidSudoku(board);

        Console.WriteLine(isValid);
    }
}

file class Solution
{
    // Integer keys instead of interpolated strings: no allocation per cell.
    public bool IsValidSudoku(char[][] board)
    {
        var uniqueSudocuElements = new HashSet<int>();

        for (var row_i = 0; row_i < 9; row_i++)
        {
            for (var col_i = 0; col_i < 9; col_i++)
            {
                var val = board[row_i][col_i];
                var cellIsEmpty = val == '.';

                if (cellIsEmpty)
                {
                    continue;
                }

                // $"row_{row_i}_{val}"
                var rowHashKey = 100 + row_i * 10 + val;
                var colHashKey = 200 + col_i * 10 + val;
                var boxHashKey = 300 + (col_i / 3 + row_i / 3 * 3) * 10 + val;

                var valueIsUnique = uniqueSudocuElements.Add(rowHashKey)
                                    &&
                                    uniqueSudocuElements.Add(colHashKey)
                                    &&
                                    uniqueSudocuElements.Add(boxHashKey);

                if (valueIsUnique == false)
                    return false;
            }
        }

        return true;
    }
}