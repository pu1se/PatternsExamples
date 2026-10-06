namespace PatternsExamples.Algorithms.Sorting.MergeSort;


// memory optimization - use only original array and buffer array and pointers
internal class MergeSort5MainProgram : IMainProgram
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
        var buffer = arr.ToArray();
        SortTo(arr, buffer, 0, arr.Length);
        return buffer;
    }

    void SortTo(int[] dst, int[] src, int start, int end)
    {
        if (end - start <= 1)
            return;

        var middle = start + (end - start) / 2;

        // put on stack left
        SortTo(src, dst, start, middle);

        // put on stack right
        SortTo(src, dst, middle, end);

        MergeTo(dst, src, start, middle, end);
    }

    void MergeTo(int[] dst, int[] src, int firstStart, int secondStart, int end)
    {
        var fst_i = firstStart;
        var snd_i = secondStart;
        var dst_i = firstStart;

        while (fst_i < secondStart && snd_i < end)
        {
            var src_i = src[fst_i] <= src[snd_i] ? fst_i++ : snd_i++;
            dst[dst_i++] = src[src_i];
        }

        while (fst_i < secondStart)
            dst[dst_i++] = src[fst_i++];

        while (snd_i < end)
            dst[dst_i++] = src[snd_i++];
    }
}