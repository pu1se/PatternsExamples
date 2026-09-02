namespace ConsoleExample.Templates.Builder
{
    class Configuration
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string ComplexField { get; set; }

        public sealed class FinalBuilder : BuilderForComplexField<FinalBuilder>
        {
            internal FinalBuilder()
            {
            }
        }

        public static FinalBuilder New => new FinalBuilder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}, {nameof(ComplexField)}: {ComplexField}";
        }
    }
}
