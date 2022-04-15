using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleExample.Templates.Builder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Console;

namespace ConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateSt = "01-01-22";
            if (DateTime.TryParse(dateSt, out DateTime date))
            {
                WriteLine(date.ToLongDateString());
            }

            Templates.BuilderFacetedOne.MainProgram.Code();

            //Templates.BuilderWithRecurciveGeneric.MainProgram.Code();

            //Templates.BuilderWithFluentApi.MainProgram.Code();
        }
    }
}