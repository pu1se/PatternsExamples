using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleExample.Annotations;

namespace ConsoleExample.Templates.ObserverClassicEventChangeNotification
{
    public class Market
    {
        public List<decimal> PriceList = new List<decimal>();

        public event EventHandler<decimal> PriceListWasChanged; 

        public void AddNewPrice(decimal newPrice)
        {
            PriceList.Add(newPrice);
            PriceListWasChanged?.Invoke(this, newPrice);
        }
    }

    internal static class MainProgram
    {
        public static void Code()
        {
            var market = new Market();
            market.PriceListWasChanged += (sender, e) =>
            {
                Console.WriteLine("New price is " + e);
            };

            market.AddNewPrice(11);
            market.AddNewPrice(12);
            market.AddNewPrice(22);
            market.AddNewPrice(33);

        }
    }
}
