using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.CollectionExtensions
{
    internal static class MainProgram
    {
        public static void Example1()
        {
            var customer = new List<Person>();
            var seller = new List<Person>();

            var somePerson = new Person { Age = 30, Name = "Peter Parker" };
            somePerson.AddTo(customer).AddTo(seller);
        }

        public static void Example2()
        {
            var role = "Customer";
            var result = role.IsOneOf("Customer", "Seller", "Admin");
        }

        public static void Code()
        {
            Example1();
            Example2();
        }
    }
}
