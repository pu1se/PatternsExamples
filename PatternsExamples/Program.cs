//var mainProgram = new TopKFrequentElements1();
//mainProgram.RunCode();

var solution = new NumArray([-2, 0, 3, -5, 2, -1]);
var result = solution.SumRange(0, 2);
Console.WriteLine(result);
result = solution.SumRange(2, 5);
Console.WriteLine(result);


class NumArray
{

    Dictionary<int, int> indexToSumOfElements = new();

    public NumArray(int[] nums)
    {
        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            indexToSumOfElements[i] = sum;
        }
    }

    public int SumRange(int left, int right)
    {
        if (left == 0)
            return indexToSumOfElements[right];

        return indexToSumOfElements[right] - indexToSumOfElements[left - 1];
    }
}
