using PatternsExamples._Core;

namespace PatternsExamples.Templates.BuilderFacetedOne
{
    class MainProgram : IMainProgram
    {
        public void RunCode()
        {
            // there are a lot of options in suggested list
            // pros are: smaller view, good for very abstract structure like html
            // cons are: when you use such builder it's not easy to understand what to write,
            // cause intelly sence suggest too much methods, you can forget to fill up a required field for example.
            var person = Person.New
                .PrivateInfo
                    .Name("Peter Parker")
                .Address
                    .City("New York")
                    .Street("Brukline")
                .Organization
                    .OrganizationName("Daily Bugele")
                    .PositionAtOrganization("jurnalist")
                .Build();

            Console.WriteLine(person.ToString());
        }
    }
}
