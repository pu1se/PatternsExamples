namespace ConsoleExample.Templates.BuilderWithFluentApi
{
    class ComplexFieldBuilder
    {
        protected readonly Tmp complexTmpField = new Tmp();
        protected readonly Builder mainContext;

        public ComplexFieldBuilder(Builder mainContext)
        {
            this.mainContext = mainContext;
        }

        public ComplexFieldBuilder Name(string name)
        {
            complexTmpField.Name = name;
            return this;
        }

        public ComplexFieldBuilder Salary(int count)
        {
            complexTmpField.Count = count;
            return this;
        }

        public Builder End()
        {
            mainContext.Build().ComplexTmpField = complexTmpField;
            return mainContext;
        }
    }
}
