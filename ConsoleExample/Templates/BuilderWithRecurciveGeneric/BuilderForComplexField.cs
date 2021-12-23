using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.Builder
{
    class BuilderForComplexField<TSelf> : BuilderForSimpleFields<TSelf>
        where TSelf : BuilderForComplexField<TSelf>
    {
        public TSelf ComplexField(string complexField)
        {
            configuration.ComplexField = complexField;
            return (TSelf)this;
        }
    }
}
