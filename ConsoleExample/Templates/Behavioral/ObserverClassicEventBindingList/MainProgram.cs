using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.ObserverClassicEventBindingList
{
    class Market
    {
        public BindingList<decimal> PriceList = new BindingList<decimal>();

        public void AddNewPrice(decimal newPrice)
        {
            PriceList.Add(newPrice);
        }
    }

    internal static class MainProgram
    {
        public static void Code()
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
