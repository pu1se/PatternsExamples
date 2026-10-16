namespace PatternsExamples.Algorithms.QuickSort;

// time  O(n log n) в среднем, O(n^2) в худшем

internal class QuickSort5MainProgram : IMainProgram
{
    public void RunCode()
    {
        var sort = new Solution();

        int[] inputArray = [4, 5, 6, 1, 2, 3, 7, 0];
        var outputArray = sort.SortArray(inputArray);

        Console.WriteLine(outputArray.Length);
    }
}

file class Solution
{
    public int[] SortArray(int[] arr)
    {
        if (arr is { Length: > 1 })
            QuickSort(arr, 0, arr.Length - 1);

        return arr;
    }

    void QuickSort(int[] arr, int left_i, int right_i)
    {
        if (right_i - left_i < 1)
            return;

        var pivot = arr[right_i];
        var pivot_i = Partition(pivot, arr, left_i, right_i);

        QuickSort(arr, left_i, pivot_i - 1);
        QuickSort(arr, pivot_i + 1, right_i);
    }

    int Partition(int pivot, int[] arr, int left_i, int right_i)
    {
        var boundary_i = left_i;

        for (var search_i = left_i; search_i < right_i; search_i++)
        {
            if (arr[search_i] < pivot)
            {
                (arr[search_i], arr[boundary_i]) = (arr[boundary_i], arr[search_i]);
                boundary_i++;
            }
        }

        (arr[boundary_i], arr[right_i]) = (arr[right_i], arr[boundary_i]);

        return boundary_i;
    }
}