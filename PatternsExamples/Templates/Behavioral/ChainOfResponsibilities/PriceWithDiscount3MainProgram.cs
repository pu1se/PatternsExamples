namespace PatternsExamples.Algorithms.PriceWithDiscount;

internal class PriceWithDiscount3MainProgram : IMainProgram
{
    public void RunCode()
    {
        var chain = new ChainOfPriceModifier();
        chain.Add(new PriceDiscound((new DateTime(2026, 10, 01), new DateTime(2026, 10, 10), 10)));
        chain.Add(new PriceDiscound((new DateTime(2026, 10, 05), new DateTime(2026, 10, 15), 20)));
        chain.Add(new PriceDiscound((new DateTime(2026, 10, 20), new DateTime(2026, 10, 25), 15)));


        var basePrice = 1000;
        var priceWithDiscount = chain.ApplyTo(basePrice, DateTime.UtcNow);

        Console.WriteLine($"basePrice: {basePrice}, priceWithDiscound: {priceWithDiscount}");
    }
}

file class ChainOfPriceModifier
{
    List<PriceDiscound> listOfModifications = new();

    public void Add(PriceDiscound priceModifier)
    {
        listOfModifications.Add(priceModifier);
    }

    public decimal ApplyTo(decimal price, DateTime currentDate)
    {
        foreach (var modifier in listOfModifications)
        {
            price = modifier.ApplyTo(price, currentDate);
        }

        return price;
    }
}

file class PriceDiscound
{
    (DateTime startDate, DateTime endDate, decimal discountPercent) priceDiscount;

    public PriceDiscound((DateTime startDate, DateTime endDate, decimal discountPercent) priceDiscount)
    {
        this.priceDiscount = priceDiscount;
    }

    public decimal ApplyTo(decimal price, DateTime currentDate)
    {
        if (priceDiscount.startDate <= currentDate && currentDate <= priceDiscount.endDate)
        {
            price *= 1 - priceDiscount.discountPercent / 100;
        }

        return price;
    }
}
