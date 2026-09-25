namespace PatternsExamples.Algorithms.QuickSort;


internal class SortingMainProgram : IMainProgram
{
    public void RunCode()
    {
        var sort = new Solution();

        int[] inputArray = [10, 9, 1, 2, 4, 3, 1];
        var outputArray = sort.SortArray(inputArray);

        Console.WriteLine(outputArray.Length);
    }
}

// split array into atomic sorted arrays, merge atomic arrays with help of queue
file class Solution
{
    public int[] SortArray(int[] arr)
    {
        var sortedArrays = MapOnAtomicSortedArrays(arr);
        sortedArrays = ReduceArrays(sortedArrays);
        return sortedArrays.Dequeue().ToArray();
    }

    Queue<Queue<int>> ReduceArrays(Queue<Queue<int>> sortedArrays)
    {
        if (sortedArrays.Count == 1)
            return sortedArrays;

        var mergedArray = MergeTwoSortedArraysIntoOne(sortedArrays.Dequeue(), sortedArrays.Dequeue());
        sortedArrays.Enqueue(mergedArray);

        return ReduceArrays(sortedArrays);
    }

    Queue<int> MergeTwoSortedArraysIntoOne(Queue<int> part1, Queue<int> part2)
    {
        var mergedArray = new Queue<int>(part1.Count + part2.Count);

        while (part1.Count != 0 && part2.Count != 0)
        {
            var arrayWithMin = part1.Peek() < part2.Peek() ? part1 : part2;
            mergedArray.Enqueue(arrayWithMin.Dequeue());
        }

        return new([.. mergedArray, .. part1, .. part2]);
    }

    Queue<Queue<int>> MapOnAtomicSortedArrays(int[] arr)
    {
        var atomicArraysAsQueue = new Queue<Queue<int>>();
        for (var i = 0; i < arr.Length; i++)
        {
            var atom = new Queue<int>([arr[i]]);
            atomicArraysAsQueue.Enqueue(atom);
        }

        return atomicArraysAsQueue;
    }
}