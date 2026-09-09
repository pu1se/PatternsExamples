using PatternsExamples.Templates.Builder;
using PatternsExamples._Core;

namespace PatternsExamples.Templates.BuilderWithRecurciveGeneric
{
    class MainProgram : IMainProgram
    {
        public void RunCode()
        {
            var configuration = Configuration
                .New
                .ComplexField("some complex field")
                .Name("SubscriptionEntity")
                .Age(12)
                .Build();

            Console.WriteLine(configuration.ToJson());
        }
    }
}
