using PatternsExamples._Core;

namespace PatternsExamples.Algorithms.MergeSort;

//main idea: дробим массив на атомарные, потом попарно сливаем отсортированные снизу вверх, пока не останется один
// code quality 7
//hint: рекурсия удерживает все слои сразу, а Concat/ToArray копирует на каждом слиянии — отсюда O(n log n) памяти вместо O(n)
// time  O(n log n)
// mem O(n log n)
internal class MergeSort1MainProgram : IMainProgram
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
        var atomicArrays = SplitArrayOnAtomicArrays(arr);
        return SortArrayTreeUntilThereIsOneElement(atomicArrays)[0];
    }

    List<int[]> SortArrayTreeUntilThereIsOneElement(List<int[]> arrLeavs)
    {
        List<int[]> arrRoot = new();

        if (arrLeavs.Count == 1)
            return arrLeavs;

        for (var index = 0; index < arrLeavs.Count; index += 2)
        {
            if (index + 1 < arrLeavs.Count)
            {
                var mergedArray = MergeTwoSortedArraysIntoOne(arrLeavs[index], arrLeavs[index + 1]);
                arrRoot.Add(mergedArray);
            }
            else
            {
                arrRoot.Add(arrLeavs[index]);
            }

        }
        return SortArrayTreeUntilThereIsOneElement(arrRoot);
    }

    int[] MergeTwoSortedArraysIntoOne(int[] leftArray, int[] rightArray)
    {
        var mergedArray = new List<int>();
        var leftIndex = 0;
        var rightIndex = 0;

        while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
        {
            if (leftArray[leftIndex] <= rightArray[rightIndex])
            {
                mergedArray.Add(leftArray[leftIndex++]);
            }
            else
            {
                mergedArray.Add(rightArray[rightIndex++]);
            }
        }

        if (leftIndex < leftArray.Length)
        {
            return mergedArray.Concat(leftArray.Skip(leftIndex)).ToArray();
        }

        return mergedArray.Concat(rightArray.Skip(rightIndex)).ToArray();
    }

    List<int[]> SplitArrayOnAtomicArrays(int[] arr)
    {
        List<int[]> atomicArrays = new(arr.Length);

        for (var index = 0; index < arr.Length; index += 2)
        {
            atomicArrays.Add([arr[index]]);

            if (index + 1 < arr.Length)
                atomicArrays.Add([arr[index + 1]]);
        }

        return atomicArrays;
    }
}
