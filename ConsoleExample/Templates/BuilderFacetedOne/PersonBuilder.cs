using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConsoleExample.Templates.BuilderFacetedOne
{
    class PersonBuilder
    {
        protected List<Action<Person>> mutations = new List<Action<Person>>();
        private Person person = new Person();

        public Person Build()
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
        public NameBuilder(List<Action<Person>> mutations)
        {
            this.mutations = mutations;
        }

        public NameBuilder Name(string personName, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = -1, [CallerFilePath] string filePath = null)
        {
            Console.WriteLine($"member name: {memberName}, line number: {lineNumber}, file path: {filePath}");
            mutations.Add(x => x.Name = personName);
            return this;
        }
    }

    class AddressBuilder : PersonBuilder
    {
        public AddressBuilder(List<Action<Person>> mutations)
        {
            this.mutations = mutations;
        }

        public AddressBuilder City(string cityName)
        {
            mutations.Add(x => x.Address.City = cityName);
            return this;
        }

        public AddressBuilder Street(string addressName)
        {
            mutations.Add(x => x.Address.Street = addressName);
            return this;
        }
    }

    class OrganizationBuilder : PersonBuilder
    {
        public OrganizationBuilder(List<Action<Person>> mutations)
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
