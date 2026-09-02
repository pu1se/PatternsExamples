using System.ComponentModel;
using System.Runtime.CompilerServices;
using PatternsExamples.Annotations;

namespace PatternsExamples.Templates.ObserverClassicEvent
{
    public class Market : INotifyPropertyChanged
    {
        private float _volatility;

        public float Volatility
        {
            get => _volatility;
            set
            {
                if (value == _volatility)
                    return;

                _volatility = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    internal static class MainProgram
    {
        public static void Code()
        {
            var market = new Market();
            market.PropertyChanged += (sender, args) =>
            {
                Console.WriteLine("Market volatility is " + (sender as Market).Volatility);
            };

            market.Volatility = 1;
            market.Volatility = 3;
            market.Volatility = 5;
        }
    }
}
