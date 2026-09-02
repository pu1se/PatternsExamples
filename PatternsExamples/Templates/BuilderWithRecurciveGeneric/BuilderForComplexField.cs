namespace PatternsExamples.Templates.Builder
{
    class BuilderForComplexField<TSelf> : BuilderForSimpleFields<TSelf>
        where TSelf : BuilderForComplexField<TSelf>
    {
        public TSelf ComplexField(string complexField)
        {
            configuration.ComplexField = complexField;
            return (TSelf)this;
        }
    }
}
