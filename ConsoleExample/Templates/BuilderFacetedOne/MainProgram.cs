using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.BuilderFacetedOne
{
    static class MainProgram
    {
        public static void Code()
        {
            var configuration = Configuration
                .New
                .Name("SubscriptionEntity")
                .Age(12)
                .ComplexTmpField()
                    .Name("complex field name")
                    .Count(5)
                    .End()
                .Build();

            Console.WriteLine(configuration.ToJson());
        }
    }
}
