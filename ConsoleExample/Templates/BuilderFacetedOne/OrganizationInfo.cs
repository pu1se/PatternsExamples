namespace ConsoleExample.Templates.BuilderFacetedOne
{
    class OrganizationInfo
    {
        public string OrganizationName { get; set; }

        public string Position { get; set; }

        public override string ToString()
        {
            return $"{nameof(OrganizationName)}: {OrganizationName}, {nameof(Position)}: {Position}";
        }
    }
}
