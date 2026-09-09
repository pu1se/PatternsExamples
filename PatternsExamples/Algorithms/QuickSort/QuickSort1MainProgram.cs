using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.QuickSort;

// code quality 3 — не сортирует: в Partition меняются границы вместо индексов
// time  O(n log n) в среднем, O(n^2) в худшем
// mem O(log n)
internal class QuickSort1MainProgram : IMainProgram
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

    // focus on pivotValue instead of pivotIndex
    void QuickSort(int[] arr, int left, int right)
    {
        if (left >= right)
            return;

        int pivotIndex = Partition(arr, left, right);

        QuickSort(arr, left, pivotIndex - 1);
        QuickSort(arr, pivotIndex + 1, right);
    }

    private int Partition(int[] arr, int left, int right)
    {
        var pivotIndex = GetMiddleIndex(arr, left, right);
        var pivotValue = arr[pivotIndex];
        var leftIndex = left - 1;
        var rightIndex = right + 1;

        while (true)
        {
            do
                leftIndex++;
            while (arr[leftIndex] < pivotValue);

            do
                rightIndex--;
            while (pivotValue < arr[rightIndex]);

            if (leftIndex >= rightIndex)
                break;

            SwapElements(arr, left, right);
        }

        return pivotIndex;
    }

    private static void SwapElements(int[] arr, int left, int right)
    {
        (arr[left], arr[right]) = (arr[right], arr[left]);
    }

    // try to use Min Max functions to make code more compact
    int GetMiddleIndex(int[] arr, int left, int right)
    {
        return left + (right - left) / 2;
        /*var middleIndex = left + (right - left) / 2;
        var middleValue = arr[middleIndex];
        var pivotIndex = left;

        if (arr[left] <= middleValue && middleValue <= arr[right])
        {
            pivotIndex = middleIndex;
        }
        else if (arr[right] <= middleValue && middleValue <= arr[left])
        {
            pivotIndex = middleIndex;
        }
        else if (arr[left] <= arr[right] && arr[right] <= middleValue)
        {
            pivotIndex = arr.Length - 1;
        }
        else if (middleValue <= arr[right] && arr[right] <= arr[left])
        {
            pivotIndex = arr.Length - 1;
        }

        return pivotIndex;*/
    }
}