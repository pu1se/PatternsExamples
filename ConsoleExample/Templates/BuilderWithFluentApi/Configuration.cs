using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.BuilderWithFluentApi
{
    class Configuration
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Tmp ComplexTmpField { get; set; }
        

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}, {nameof(ComplexTmpField)}: {ComplexTmpField}";
        }
    }
}
