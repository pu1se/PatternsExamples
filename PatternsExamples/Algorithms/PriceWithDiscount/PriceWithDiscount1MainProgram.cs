namespace PatternsExamples.Algorithms.PriceWithDiscount;

internal class PriceWithDiscount1MainProgram : IMainProgram
{
    public void RunCode()
    {
        // what to do if discount overlap? take the biggest or calculate all?
        var dicountList = new List<(DateTime startDate, DateTime endDate, decimal discountPercent)>
        {
            (new DateTime(2026, 10, 01), new DateTime(2026, 10, 10), 10),
            (new DateTime(2026, 10, 05), new DateTime(2026, 10, 15), 20),
            (new DateTime(2026, 10, 20), new DateTime(2026, 10, 25), 15),
        };

        var basePrice = 1000;
        var priceWithDiscound = CalculatePriceWithSumDiscount(basePrice, dicountList, DateTime.UtcNow);
        Console.WriteLine($"basePrice: {basePrice}, priceWithDiscound: {priceWithDiscound}");

        priceWithDiscound = CalculatePriceWithOneMaxDiscount(basePrice, dicountList, DateTime.UtcNow);
        Console.WriteLine($"basePrice: {basePrice}, priceWithDiscound: {priceWithDiscound}");
    }

    decimal CalculatePriceWithSumDiscount(decimal basePrice, List<(DateTime startDate, DateTime endDate, decimal discountPercent)> discountList, DateTime currentDate)
    {
        var availableDiscountsForCurrentDate = discountList.Where(x => x.startDate <= currentDate && currentDate <= x.endDate).ToList();
        var priceWithDiscount = basePrice;

        foreach (var discount in availableDiscountsForCurrentDate)
        {
            priceWithDiscount *= 1 - discount.discountPercent / 100;
        }


        return priceWithDiscount;
    }

    decimal CalculatePriceWithOneMaxDiscount(decimal basePrice, List<(DateTime startDate, DateTime endDate, decimal discountPercent)> discountList, DateTime currentDate)
    {
        decimal maxDiscount = default;


        foreach (var discount in discountList)
        {
            if (discount.startDate < currentDate && currentDate < discount.endDate)
            {
                if (discount.discountPercent > maxDiscount)
                {
                    maxDiscount = discount.discountPercent;
                }
            }
        }

        if (maxDiscount == default)
            return basePrice;

        var priceWithDiscount = basePrice;

        priceWithDiscount *= 1 - maxDiscount / 100;

        return priceWithDiscount;
    }
}

