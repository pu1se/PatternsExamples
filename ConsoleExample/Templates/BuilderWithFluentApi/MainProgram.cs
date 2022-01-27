using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.BuilderWithFluentApi
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
