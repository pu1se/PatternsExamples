using PatternsExamples._Core;

namespace PatternsExamples.Templates.ObserverReactiveExtension
{
    internal class MainProgram : IMainProgram
    {
        public void RunCode()
        {
            // var market = new Market();
            // var marketObserver = new ObserveMarker();
            // market.Subscribe(marketObserver);
        }
    }

    /*public class Market : IObservable<decimal>
    {
        public IDisposable Subscribe(IObserver<decimal> observer)
        {
            return observer;
        }
    }

    public class ObserveMarker : IObserver<decimal>
    {
        public void OnNext(decimal value)
        {
            Console.WriteLine("New price is " + value);
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("The error: " + error.ToJson());
        }

        public void OnCompleted()
        {
            Console.WriteLine("Market is closed");
        }
    }*/
}
