namespace PatternsExamples.Algorithms.RangeSum;

// main idea: calculate approximately and discard the extra
// details: calculate sum for matrix and discard sum of left and sum of top matrix.
internal class RangeSum2dMainProgram : IMainProgram
{
    public void RunCode()
    {
        int[][] matrix =
        [
            [3, 0, 1, 4, 2],
            [5, 6, 3, 2, 1],
            [1, 2, 0, 1, 5],
            [4, 1, 0, 1, 7],
            [1, 0, 3, 0, 5],
            /*[2,2,2],
            [2,2,2]*/
        ];

        var solution = new NumMatrix(matrix);
        var output = solution.SumRegion(0, 0, 1, 2);

        Console.WriteLine(output);
    }
}

file class NumMatrix
{
    Dictionary<(int x, int y), int> _matrixPrefixSum;

    public NumMatrix(int[][] matrix)
    {
        _matrixPrefixSum = new(matrix.Length * matrix.First().Length);

        for (var y = 0; y < matrix.Length; y++)
        {
            var row = matrix[y];
            for (var x = 0; x < row.Length; x++)
            {
                _matrixPrefixSum.TryGetValue((x - 1, y), out var left_matrix_sum);
                _matrixPrefixSum.TryGetValue((x, y - 1), out var top_matrix_sum);
                _matrixPrefixSum.TryGetValue((x - 1, y - 1), out var cossing_matrix_sum);

                _matrixPrefixSum[(x, y)] = left_matrix_sum + top_matrix_sum - cossing_matrix_sum + matrix[y][x];
            }
        }
    }


    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        var x = col2;
        var y = row2;
        var big_matrix_sum = _matrixPrefixSum[(x, y)];

        x = col1 - 1;
        y = row2;
        var exclude_small_left_matrix_sum = 0;
        if (x >= 0)
            exclude_small_left_matrix_sum = _matrixPrefixSum[(x, y)];

        x = col2;
        y = row1 - 1;
        var exclude_small_top_matrix_sum = 0;
        if (y >= 0)
            exclude_small_top_matrix_sum = _matrixPrefixSum[(x, y)];

        x = col1 - 1;
        y = row1 - 1;
        var left_top_matrix_crossing = 0;
        if (x >= 0 && y >= 0)
            left_top_matrix_crossing = _matrixPrefixSum[(x, y)];


        return big_matrix_sum
            - exclude_small_left_matrix_sum
            - exclude_small_top_matrix_sum
            + left_top_matrix_crossing;
    }
}
