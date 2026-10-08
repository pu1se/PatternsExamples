namespace PatternsExamples.Algorithms.BestTimeToBuyAndSellStock;

internal class BestTimeToBuyAndSellStock1 : IMainProgram
{
    public void RunCode()
    {
        var solution = new Solution();

        var profit = solution.MaxProfit([1, 2, 3, 4, 5]);

        Console.WriteLine(profit);
    }
}

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        if (prices is { Length: < 1 })
            return 0;

        var profit = 0;
        for (var i = 0; i < prices.Length - 1; i++)
        {
            if (prices[i + 1] > prices[i])
                profit += prices[i + 1] - prices[i];
        }

        return profit;
    }
}