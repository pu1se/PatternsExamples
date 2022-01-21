using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.BuilderFacetedOne
{
    class PersonInfo
    {
        public string Name { get; set; }

        public AddressInfo Address { get; set; }

        public OrganizationInfo Organization { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}, {nameof(Organization)}: {Organization}";
        }
    }
}
