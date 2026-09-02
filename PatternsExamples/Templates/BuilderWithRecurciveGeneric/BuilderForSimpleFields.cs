namespace PatternsExamples.Templates.Builder
{
    class BuilderForSimpleFields<TSelf> where TSelf : BuilderForSimpleFields<TSelf>
    {
        protected Configuration configuration = new Configuration();

        public Configuration Build()
        {
            return configuration;
        }

        public TSelf Name(string name)
        {
            configuration.Name = name;
            return (TSelf) this;
        }

        public TSelf Age(int age)
        {
            configuration.Age = age;
            return (TSelf)this;
        }
    }
}
