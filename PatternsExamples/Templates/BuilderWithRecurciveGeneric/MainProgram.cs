using PatternsExamples.Templates.Builder;

namespace PatternsExamples.Templates.BuilderWithRecurciveGeneric
{
    static class MainProgram
    {
        public static void Code()
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
