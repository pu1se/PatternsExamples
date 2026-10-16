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
        ];

        var solution = new NumMatrix(matrix);
        var output = solution.SumRegion(2, 1, 4, 3);

        Console.WriteLine(output);
    }
}

file class NumMatrix
{
    public NumMatrix(int[][] matrix)
    {
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        throw new NotImplementedException();
    }
}