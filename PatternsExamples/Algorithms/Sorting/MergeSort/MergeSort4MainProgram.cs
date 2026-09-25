namespace PatternsExamples.Algorithms.Sorting.MergeSort;


internal class MergeSort4MainProgram : IMainProgram
{
    public void RunCode()
    {
        var sort = new Solution();

        int[] inputArray = [10, 9, 1, 2, 4, 3, 1];
        var outputArray = sort.SortArray(inputArray);

        Console.WriteLine(outputArray);
    }
}

file class Solution
{
    public int[] SortArray(int[] arr)
    {
        return Sort(arr, 0, arr.Length);
    }

    int[] Sort(int[] arr, int start, int end)
    {
        if (end - start <= 1)
            return [arr[start]];

        var middle = start + (end - start) / 2;

        var left = Sort(arr, start, middle);
        var right = Sort(arr, middle, end);

        return MergeTwoArrays(new(left), new(right));
    }

    int[] MergeTwoArrays(Queue<int> left, Queue<int> right)
    {
        var merged = new Queue<int>();

        while (left.Count > 0 && right.Count > 0)
        {
            var arrayWithMin = left.Peek() < right.Peek() ? left : right;
            merged.Enqueue(arrayWithMin.Dequeue());
        }

        return [.. merged, .. left, .. right];
    }
}