using System.ComponentModel;
using PatternsExamples._Core;

namespace PatternsExamples.Templates.ObserverClassicEventBindingList
{
    class Market
    {
        public BindingList<decimal> PriceList = new BindingList<decimal>();

        public void AddNewPrice(decimal newPrice)
        {
            PriceList.Add(newPrice);
        }
    }

    internal class MainProgram : IMainProgram
    {
        public void RunCode()
        {
            var market = new Market();
            market.PriceList.ListChanged += (sender, e) =>
            {
                if (e.ListChangedType == ListChangedType.ItemAdded)
                {
                    var newPrice = (sender as BindingList<decimal>)[e.NewIndex];
                    Console.WriteLine("New price is " + newPrice);
                }
            };

            market.AddNewPrice(11);
            market.AddNewPrice(12);
            market.AddNewPrice(22);
            market.AddNewPrice(33);
        }
    }
}
