using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleExample.Templates.Builder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Templates.BuilderFacetedOne.MainProgram.Code();

            //Templates.BuilderWithRecurciveGeneric.MainProgram.Code();

            //Templates.BuilderWithFluentApi.MainProgram.Code();
        }
    }

    public static class CpqFieldType
    {
        public const string TextBox = "TextBox";
        public const string QuantityBox = "QuantityBox";
        public const string BillingCycle = "BillingCycle";
        public const string Panel = "Panel";
        public const string DropDown = "DropDown";
        public const string DropDownItem = "DropDownItem";
    }

    public class CpqField
    {
        public string FieldType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public JToken JToken { get; set; }
        public bool HasComplexValue { get; set; }
        public string Title { get; set; }
        public string LocalizationLanguage { get; set; }
    }

    public static class Extensions
    {
        public static T ToObject<T>(this string json) where T: class
        {
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                CheckAdditionalContent = false,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                

            });
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }

    public class CpqPresenter
    {
        public CpqPresenterForm Form { get; set; }
    }

    public class CpqPresenterForm
    {
        public List<CpqPresenterFormChild> Children { get; set; } = new List<CpqPresenterFormChild>();
    }

    public class CpqPresenterFormChild
    {
        public string Type { get; set; }
        public string UniqueKey { get; set; }
        public string DefaultValue { get; set; }
        public Dictionary<string, string> Title { get; set; }

    }

    public class CpqComponent
    {
        public string ComponentId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}