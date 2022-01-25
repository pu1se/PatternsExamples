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

        public IEnumerable<string> PropertyCollection
        {
            get
            {
                yield return $"{nameof(Name)}: {Name}";
                yield return $"{nameof(Address)} {{{Address}}}";
                yield return $"{nameof(Organization)}: {{{Organization}}}";
            }
        }
        public override string ToString()
        {
            return PropertyCollection.Join(",");
        }

        public static PersonBuilder New => new PersonBuilder();
    }
}
