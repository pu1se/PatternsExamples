using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.Sudoku;

//main idea: один проход по доске, каждую цифру кладём в HashSet тремя ключами — строка, столбец, квадрат
// code quality 7
//hint: 3 интерполированные строки на каждую заполненную клетку — лишние аллокации на ровном месте
// time  O(n^2), n — сторона доски
// mem O(n^2)
internal class Sudoku1MainProgram : IMainProgram
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
    public bool IsValidSudoku(char[][] board)
    {
        var _hashSet = new HashSet<string>();

        for (var row = 0; row < 9; row++)
        {
            for (var col = 0; col < 9; col++)
            {
                var val = board[row][col];

                if (val != '.')
                {
                    if (_hashSet.Add($"row_{row}_{val}") == false)
                        return false;
                    if (_hashSet.Add($"col_{col}_{val}") == false)
                        return false;
                    if (_hashSet.Add($"box_{row/3}_{col/3}_{val}") == false)
                        return false;
                }
            }
        }

        return true;
    }
}