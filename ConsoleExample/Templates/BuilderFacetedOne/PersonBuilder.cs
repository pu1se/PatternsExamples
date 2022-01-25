using System;
using System.Collections.Generic;

namespace ConsoleExample.Templates.BuilderFacetedOne
{
    class PersonBuilder
    {
        protected List<Action<PersonInfo>> mutations = new List<Action<PersonInfo>>();
        private PersonInfo person = new PersonInfo();

        public PersonInfo Build()
        {
            foreach (var action in mutations)
            {
                action(person);
            }

            return person;
        }

        public NameBuilder PrivateInfo => new NameBuilder(mutations);
        public AddressBuilder Address => new AddressBuilder(mutations);
        public OrganizationBuilder Organization => new OrganizationBuilder(mutations);
    }

    class NameBuilder : PersonBuilder
    {
        public NameBuilder(List<Action<PersonInfo>> mutations)
        {
            this.mutations = mutations;
        }

        public NameBuilder Name(string personName)
        {
            mutations.Add(x => x.Name = personName);
            return this;
        }
    }

    class AddressBuilder : PersonBuilder
    {
        public AddressBuilder(List<Action<PersonInfo>> mutations)
        {
            this.mutations = mutations;
        }

        public AddressBuilder City(string cityName)
        {
            mutations.Add(x => x.Address.City = cityName);
            return this;
        }

        public AddressBuilder Address(string addressName)
        {
            mutations.Add(x => x.Address.Address = addressName);
            return this;
        }
    }

    class OrganizationBuilder : PersonBuilder
    {
        public OrganizationBuilder(List<Action<PersonInfo>> mutations)
        {
            this.mutations = mutations;
        }

        public OrganizationBuilder OrganizationName(string organizationName)
        {
            mutations.Add(x => x.Organization.OrganizationName = organizationName);
            return this;
        }

        public OrganizationBuilder PositionAtOrganization(string position)
        {
            mutations.Add(x => x.Organization.Position = position);
            return this;
        }
    }
}
