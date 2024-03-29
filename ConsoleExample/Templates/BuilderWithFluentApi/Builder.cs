﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.BuilderWithFluentApi
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

        public ComplexFieldBuilder Organization()
        {
            return new ComplexFieldBuilder(this);
        }

        public Configuration Build()
        {
            return configuration;
        }
    }
}
