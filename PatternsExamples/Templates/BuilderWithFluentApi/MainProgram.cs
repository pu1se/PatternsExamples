namespace PatternsExamples.Templates.BuilderWithFluentApi
{
    static class MainProgram
    {
        public static void Code()
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
