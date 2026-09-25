namespace PatternsExamples.Algorithms.QuickSort;

// time  O(n log n) в среднем, O(n^2) в худшем

internal class QuickSort2MainProgram : IMainProgram
{
    public void RunCode()
    {
        var sort = new Solution();

        int[] inputArray = [10, 9, 1, 2, 4, 3, 1];
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

        QuickSort(arr, 0, arr.Length - 1);

        return arr;
    }

    void QuickSort(int[] arr, int startIndex, int endIndex)
    {
        if (startIndex >= endIndex)
            return;

        var pivoteIndex = startIndex;
        var pivote = arr[pivoteIndex];

        for (var i = startIndex; i <= endIndex; i++)
        {
            if (i == pivoteIndex)
                continue;

            if (arr[i] < pivote)
            {
                (arr[pivoteIndex], arr[i]) = (arr[i], arr[pivoteIndex]);
                (pivoteIndex, i) = (i, pivoteIndex);
            }
        }

        QuickSort(arr, startIndex, pivoteIndex - 1);
        QuickSort(arr, pivoteIndex + 1, endIndex);
    }
}