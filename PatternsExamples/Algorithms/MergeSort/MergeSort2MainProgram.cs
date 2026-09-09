using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.MergeSort;

//main idea: очередь атомарных очередей, на каждом шаге сливаем две головные и результат кладём в хвост
// code quality 8
//hint: на каждое слияние аллоцируется новая Queue — на массиве с индексами слияние шло бы без копий
// time  O(n log n)
// mem O(n)
internal class MergeSort2MainProgram : IMainProgram
{
    public void RunCode()
    {
        var sort = new Solution();

        int[] inputArray = [10, 9, 1, 1, 1, 2, 4, 3, 1];
        var outputArray = sort.SortArray(inputArray);
    }
}

file class Solution
{
    public int[] SortArray(int[] arr)
    {
        var atomicArrays = MapOnAtoms(arr);
        return ReduceTree(atomicArrays);
    }

    int[] ReduceTree(Queue<Queue<int>> arrQueue)
    {
        while (arrQueue.Count > 1)
        {
            var mergedArray = MergeTwoSortedArrays(arrQueue.Dequeue(), arrQueue.Dequeue());
            arrQueue.Enqueue(mergedArray);
        }

        return arrQueue.Dequeue().ToArray();
    }

    Queue<int> MergeTwoSortedArrays(Queue<int> arrQueue1, Queue<int> arrQueue2)
    {
        var mergedArray = new Queue<int>();

        while (arrQueue1.Count != 0 && arrQueue2.Count != 0)
        {
            var queueWithMin = arrQueue1.Peek() < arrQueue2.Peek()
                               ? arrQueue1 : arrQueue2;

            mergedArray.Enqueue(queueWithMin.Dequeue());
        }

        return new([.. mergedArray, .. arrQueue1, .. arrQueue2]);
    }

    Queue<Queue<int>> MapOnAtoms(int[] arr)
    {
        Queue<Queue<int>> atomics = new(arr.Length);

        for (var i = 0; i < arr.Length; i++)
        {
            atomics.Enqueue(new Queue<int>([arr[i]]));
        }

        return atomics;
    }
}