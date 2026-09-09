using PatternsExamples._Core;

namespace PatternsExamples.Templates.BuilderWithFluentApi
{
    class MainProgram : IMainProgram
    {
        public void RunCode()
        {
            var configuration = Configuration
                .New
                .Name("SubscriptionEntity")
                .Age(12)
                .Organization()
                    .Name("complex field name")
                    .Salary(5)
                    .End()
                .Build();

            Console.WriteLine(configuration.ToJson());
        }
    }
}
