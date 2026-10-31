namespace PatternsExamples.Algorithms.TopKFrequentElements;

/*
 так как массив отсортирован мы сразу знаем частоту, 
 то мы можем сделать dict c key => частота val => bucket with nums, 
 заполнить за один проход и хронить макс частату и потом посчитать топ k начиная от max частоты по бакетам
 */
internal class TopKFrequentElements1 : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();
        solution.TopKFrequent([1, 2, 2, 3, 3, 3], 2);
    }
}

file class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var frequencyToElemBucket = new Dictionary<int, List<int>>();
        var frequencyList = new List<int>();

        var frequencyCounter = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            var currentElement = nums[i];

            if (i + 1 != nums.Length)
            {
                var nextElement = nums[i + 1];
                if (currentElement == nextElement)
                {
                    frequencyCounter++;
                    continue;
                }
            }

            if (frequencyToElemBucket.TryGetValue(frequencyCounter, out var bucket))
            {
                bucket.Add(currentElement);
            }
            else
            {
                frequencyToElemBucket[frequencyCounter] = new List<int>([currentElement]);
                frequencyList.Add(frequencyCounter);
            }

            frequencyCounter = 1;
        }

        var topKMostFrequentElements = new int[k];
        // убрать сортировку, посчитать макс frequency при первом прогоне и начинать второй обход с max freq c шагом -1
        frequencyList = frequencyList.OrderByDescending(x => x).ToList();
        for (var i = 0; i < frequencyList.Count; i++)
        {
            var currentFrequency = frequencyList[i];
            var bucket = frequencyToElemBucket[currentFrequency];
            foreach (var element in bucket)
            {
                if (k == 0)
                    return topKMostFrequentElements;

                topKMostFrequentElements[--k] = element;
            }
        }

        return topKMostFrequentElements;
    }
}