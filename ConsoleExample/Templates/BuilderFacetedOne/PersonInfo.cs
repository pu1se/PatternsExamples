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

        public AddressInfo Address { get; set; } = new AddressInfo();

        public OrganizationInfo Organization { get; set; } = new OrganizationInfo();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}, {nameof(Organization)}: {Organization}";
        }

        public static PersonBuilder New => new PersonBuilder();
    }
}
