using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.BuilderFacetedOne
{
    class AddressInfo
    {
        public string City {get; set;}
        public string Address {get; set;}

        public override string ToString()
        {
            return $"{nameof(City)}: {City}, {nameof(Address)}: {Address}";
        }
    }
}
