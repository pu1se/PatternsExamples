using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleExample.Templates.Builder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Templates.BuilderWithRecurciveGeneric.MainProgram.Code();

            Templates.BuilderWithFluentApi.MainProgram.Code();

            var formData = "{\"quantitycontrolBox1\":2,\"ChargePeriod\":{\"offerId\":\"248b20fd-0208-41fa-b841-97d4bf63ef73\",\"offerRulePricingId\":\"5034b694-7ab4-4ff6-acdc-8c1c03d2d16e\",\"pricingFrequency\":\"Monthly\",\"offerRuleFrequency\":\"Monthly\"},\"DropdownKey\":\"value1\"}";
            var formDefinition = "{\"vendorId\":\"d785793b-3edf-472a-8eff-0845437aecd2\",\"offerId\":\"248b20fd-0208-41fa-b841-97d4bf63ef73\",\"form\":{\"type\":\"Plan\",\"panelDirection\":\"Vertical\",\"id\":\"1ec11fe4-7a1f-4cb8-b55a-fef08f16ca40\",\"children\":[{\"type\":\"QuantityBox\",\"uniqueKey\":\"quantitycontrolBox1\",\"width\":\"3to12\",\"id\":\"c9615732-171b-4ee2-baa6-1c1edfaaf263\",\"title\":{\"en-US\":\"<p>Quanrcontrol</p>\",\"sv-FI\":\"Määrä\",\"da-DK\":\"Antal\",\"sv-SE\":\"Antal\",\"de\":\"Anzahl\",\"no\":\"Antall*\"},\"children\":[]},{\"type\":\"BillingCycle\",\"uniqueKey\":\"ChargePeriod\",\"width\":\"3to12\",\"id\":\"aec88c70-f0a0-4d75-84e5-3b7c25d5be1a\",\"title\":{\"en-US\":\"<p>ChargePeriodtest</p>\"},\"children\":[]},{\"type\":\"Panel\",\"panelDirection\":\"Vertical\",\"width\":\"3to12\",\"id\":\"62ec2da6-44dc-4487-9639-c191f1c65e02\",\"title\":{\"en-US\":\"<p>Paneltest</p>\"},\"children\":[{\"type\":\"DropDown\",\"uniqueKey\":\"DropdownKey\",\"width\":\"3to12\",\"isRequired\":true,\"useExternalOptions\":false,\"id\":\"0e768186-019c-4455-a337-481eace671e8\",\"title\":{\"en-US\":\"<p>Dropdown</p>\"},\"children\":[{\"type\":\"DropDownItem\",\"value\":\"value1\",\"id\":\"779496a3-69cb-4b71-a8d7-93298d49aa70\",\"title\":{\"en-US\":\"title1\"},\"children\":[]},{\"type\":\"DropDownItem\",\"value\":\"value2\",\"id\":\"ff71acaf-8bc7-42e1-b406-d37d8ba3e783\",\"title\":{\"en-US\":\"title2\"},\"children\":[]},{\"type\":\"DropDownItem\",\"value\":\"value3\",\"id\":\"f9bd1919-e121-4bfe-8e7d-7049f1acd5c3\",\"title\":{\"en-US\":\"title3\"},\"children\":[]}]}]}]},\"postPurchaseRestrictions\":{\"rules\":[]}}";

            var result = GetFieldsView(formData, formDefinition);
        }

        static List<CpqField> GetFieldsView(string formDataString, string formDefinitionString)
        {
            var formData = JToken.Parse(formDataString);
            var formDefinition = JToken.Parse(formDefinitionString);
            var result = new List<CpqField>();
            
            var jProperties = formData.Children().OfType<JProperty>();
            foreach (var property in jProperties)
            {
                var cpqField = new CpqField
                {
                    Key = property.Name,
                    Value = property.Value.ToString(),
                    JToken = property.Value,
                    HasComplexValue = property.Value.Type == JTokenType.Object,
                    LocalizationLanguage = "en-US"
                };
                result.Add(cpqField);
            }

            if (formDefinitionString.Contains("children") == false)
            {
                return result;
            }

            foreach (var field in result)
            {
                FillTypeAndTitle(field, formDefinition["form"]["children"]);    
            }

            foreach (var field in result)
            {
                FillSpecificValue(field, formDefinition["form"]["children"]);    
            }

            return result;
        }

        static void FillSpecificValue(CpqField field, JToken children)
        {
            switch (field.FieldType)
            {
                case CpqFieldType.BillingCycle:

                    field.Value = field.JToken["pricingFrequency"].Value<string>();
                    break;

                case CpqFieldType.DropDown:

                    FillDropDownValue(field, children);
                    break;
            }
        }


        static void FillDropDownValue(CpqField field, JToken children)
        {
            foreach (var child in children.OfType<JObject>())
            {
                if (child["uniqueKey"] != null && child["uniqueKey"].Value<string>() == field.Key)
                {
                    var selectedOption = field.Value;

                    foreach (var option in child["children"])
                    {
                        if (option["value"].Value<string>() == selectedOption)
                        {
                            field.Value = option["title"]?[field.LocalizationLanguage]?.Value<string>();
                            if (field.Value == null)
                            {
                                var defaultLocalizationLanguage = "en-US";
                                field.Value = option["title"]?[defaultLocalizationLanguage]?.Value<string>();
                            }
                        }
                    }
                    return;
                }

                FillDropDownValue(field, child["children"]);
            }
        }

        static void FillTypeAndTitle(CpqField field, JToken children)
        {
            foreach (var child in children.OfType<JObject>())
            {
                if (child["uniqueKey"] != null && child["uniqueKey"].Value<string>() == field.Key)
                {
                    field.FieldType = child["type"].Value<string>();
                    field.Title = child["title"]?[field.LocalizationLanguage]?.Value<string>();
                    if (field.Value == null)
                    {
                        var defaultLocalizationLanguage = "en-US";
                        field.Title = child["title"]?[defaultLocalizationLanguage]?.Value<string>();
                    }

                    return;
                }

                FillTypeAndTitle(field, child["children"]);
            }
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