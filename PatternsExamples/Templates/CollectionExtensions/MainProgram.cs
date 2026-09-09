using PatternsExamples._Core;

namespace PatternsExamples.Templates.CollectionExtensions
{
    internal class MainProgram : IMainProgram
    {
        public static void Example1()
        {
            var customers = new List<Person>();
            var sellers = new List<Person>();

            var somePerson = new Person { Age = 30, Name = "Peter Parker" };
            somePerson.AddTo(customers).AddTo(sellers);
        }

        public static void Example2()
        {
            var role = "Customer";
            var result = role.IsOneOf("Customer", "Seller");
        }

        public void RunCode()
        {
            Example1();
            Example2();
        }
    }
}
