namespace PatternsExamples.Algorithms.PriceWithDiscount;

internal class PriceWithDiscount2MainProgram : IMainProgram
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
    ChainOfPriceModifier nextChain;

    public void Add(ChainOfPriceModifier priceModifier)
    {
        if (nextChain == null)
            nextChain = priceModifier;
        else
            nextChain.Add(priceModifier);
    }

    public virtual decimal ApplyTo(decimal price, DateTime currentDate) => nextChain?.ApplyTo(price, currentDate) ?? price;
}

file class PriceDiscound : ChainOfPriceModifier
{
    (DateTime startDate, DateTime endDate, decimal discountPercent) priceDiscount;

    public PriceDiscound((DateTime startDate, DateTime endDate, decimal discountPercent) priceDiscount)
    {
        this.priceDiscount = priceDiscount;
    }

    public override decimal ApplyTo(decimal price, DateTime currentDate)
    {
        if (priceDiscount.startDate <= currentDate && currentDate <= priceDiscount.endDate)
        {
            price *= 1 - priceDiscount.discountPercent / 100;
        }

        return base.ApplyTo(price, currentDate);
    }
}

file class NoBonuses : ChainOfPriceModifier
{
    public override decimal ApplyTo(decimal price, DateTime currentDate)
    {
        return price;
    }
}