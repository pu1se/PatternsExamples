using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.Builder
{
    class BuilderForSimpleFields<TSelf> where TSelf : BuilderForSimpleFields<TSelf>
    {
        protected Configuration configuration = new Configuration();

        public Configuration Build()
        {
            return configuration;
        }

        public TSelf Name(string name)
        {
            configuration.Name = name;
            return (TSelf) this;
        }

        public TSelf Age(int age)
        {
            configuration.Age = age;
            return (TSelf)this;
        }
    }
}
