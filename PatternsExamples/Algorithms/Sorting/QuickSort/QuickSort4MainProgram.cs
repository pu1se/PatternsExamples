namespace PatternsExamples.Algorithms.QuickSort;

// time  O(n log n) в среднем, O(n^2) в худшем

internal class QuickSort4MainProgram : IMainProgram
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
        if (arr == null || arr.Length < 2)
            return arr;

        return QuickSort(arr, 0, arr.Length - 1);
    }

    int[] QuickSort(int[] arr, int left_i, int right_i)
    {
        if (right_i - left_i < 1)
            return arr;

        var pivot_i = GetPivotIndex(arr, left_i, right_i);
        var pivot = arr[pivot_i];

        pivot_i = Partition(arr, pivot, left_i, right_i);

        Console.WriteLine($"pivot: {pivot} and arr[pivot_i]: {arr[pivot_i]}");

        QuickSort(arr, left_i, pivot_i - 1);
        QuickSort(arr, pivot_i, right_i);

        return arr;
    }

    int Partition(int[] arr, int pivot, int left_i, int right_i)
    {
        while (left_i <= right_i)
        {
            while (arr[left_i] < pivot)
                left_i++;

            while (arr[right_i] > pivot)
                right_i--;

            if (left_i <= right_i)
            {
                (arr[left_i], arr[right_i]) = (arr[right_i], arr[left_i]);

                left_i++;
                right_i--;
            }
        }

        return left_i;
    }

    int GetPivotIndex(int[] arr, int left_i, int right_i)
    {
        var middle_i = left_i + (right_i - left_i) / 2;

        var pivotCandidates = new List<(int Value, int Index)>
        {
            (arr[left_i], left_i ),
            (arr[right_i], right_i ),
            (arr[middle_i], middle_i ),
        };

        var min_value = pivotCandidates.Min(x => x.Value);
        var min_i = pivotCandidates.FirstOrDefault(x => x.Value == min_value);
        pivotCandidates.Remove(min_i);

        var max_value = pivotCandidates.Max(x => x.Value);
        var max_i = pivotCandidates.FirstOrDefault(x => x.Value == max_value);
        pivotCandidates.Remove(max_i);

        return pivotCandidates.First().Index;
    }
}