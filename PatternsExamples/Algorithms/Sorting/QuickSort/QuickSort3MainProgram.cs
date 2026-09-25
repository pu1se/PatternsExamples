namespace PatternsExamples.Algorithms.QuickSort;

// time  O(n log n) в среднем, O(n^2) в худшем

internal class QuickSort3MainProgram : IMainProgram
{
    public void RunCode()
    {
        var sort = new Solution();

        int[] inputArray = [5, 10, 2, 1, 3];
        var outputArray = sort.SortArray(inputArray);

        Console.WriteLine(outputArray.Length);
    }
}

file class Solution
{
    public int[] SortArray(int[] arr)
    {
        if (arr == null || arr.Length < 2)
            return arr;

        var pivote = arr[0];

        var left = arr.Skip(1).Where(x => x <= pivote).ToArray();
        var right = arr.Skip(1).Where(x => x > pivote).ToArray();

        left = SortArray(left);
        right = SortArray(right);

        return [.. left, pivote, .. right];
    }
}