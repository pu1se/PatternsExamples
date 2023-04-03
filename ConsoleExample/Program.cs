using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleExample.Templates.Builder;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Console;


namespace ConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        { 
            LanguageFeatures.MainProgram.Code();
            Templates.ObserverClassicEventBindingList.MainProgram.Code();
            //Templates.BuilderWithRecurciveGeneric.MainProgram.Code();
            //Templates.BuilderWithFluentApi.MainProgram.Code();
        }
    }
}