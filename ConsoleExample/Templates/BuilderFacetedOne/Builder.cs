using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExample.Templates.BuilderFacetedOne
{
    class Builder
    {
        protected List<Action<PersonInfo>> actions = new List<Action<PersonInfo>>();
        protected PersonInfo person = new PersonInfo();

        public PersonInfo Build()
        {
            foreach (var action in actions)
            {
                action(person);
            }

            return person;
        }
    }

    class NameBuilder : Builder
    {
        public NameBuilder(PersonInfo person)
        {
            this.person = person;
        }

        public NameBuilder Name(string personName)
        {
            actions.Add(x => x.Name = personName);
            return this;
        }
    }

    class AddressBuilder : Builder
    {

    }
}
