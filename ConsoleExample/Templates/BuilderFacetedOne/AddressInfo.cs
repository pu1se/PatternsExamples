namespace ConsoleExample.Templates.BuilderFacetedOne
{
    class AddressInfo
    {
        public string City {get; set;}
        public string Street {get; set;}

        public override string ToString()
        {
            return $"{nameof(City)}: {City}, {nameof(Street)}: {Street}";
        }
    }
}
