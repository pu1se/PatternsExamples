using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.BuilderFacetedOne
{
    class Builder
    {
        protected readonly Configuration configuration = new Configuration();

        public Builder Name(string name)
        {
            configuration.Name = name;
            return this;
        }

        public Builder Age(int age)
        {
            configuration.Age = age;
            return this;
        }

        public ComplexFieldBuilder ComplexTmpField()
        {
            return new ComplexFieldBuilder(this);
        }

        public Configuration Build()
        {
            return configuration;
        }
    }
}
