namespace PatternsExamples.Algorithms.MergeSortedArray;

internal class MergeSortedArray1 : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();
        int[] nums = [10, 20, 20, 40, 0, 0];
        solution.Merge(nums, 4, [1, 2], 2);

        Console.WriteLine(string.Join(", ", nums));
    }
}

file record Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var i_1 = 0;
        var i_2 = 0;

        for (var i = 0; i < n; i++)
        {
            nums1[m + i] = nums2[i];
        }

        QuickSort(nums1, 0, nums1.Length - 1);
    }

    void QuickSort(int[] arr, int left_i, int right_i)
    {
        if (right_i - left_i < 1)
            return;

        var pivot = arr[right_i];
        var pivot_i = Partition(arr, pivot, left_i, right_i);

        QuickSort(arr, left_i, pivot_i - 1);
        QuickSort(arr, pivot_i + 1, right_i);
    }

    int Partition(int[] arr, int pivot, int left_i, int right_i)
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