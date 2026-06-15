using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleExample.Algorithms
{
    public class MainProgram
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };

        public static void RunCode()
        {
        

            var jsonDeserializationSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
            };

            var tmp = JsonConvert.DeserializeObject<TenantCategoryPrice>(
                """
                {
                  "TenantCategoryId": "d92e19e2-3627-4e7c-b37c-8ad482234e7c",
                  "ProfileVendorId": "af817907-beb0-4ce2-be96-b674de7a876b",
                  "PriceTier": 2,
                  "Markup": 3.0,
                  "CreatedOnUtc": "2024-11-13T07:54:44.6741174Z",
                  "LastUpdatedOnUtc": "2024-11-13T07:54:44.6741174Z",
                  "CreatedById": "49e473d6-b284-4f48-8f1f-05a7e014136d",
                  "LastUpdatedById": "49e473d6-b284-4f48-8f1f-05a7e014136d",
                  "NotStarted": true,
                  "Id": "04cff2f7-8891-4ddf-ba53-cd913de5ff66",
                  "EffectiveFromDateUtc": "2024-11-15T00:00:00Z",
                  "EffectiveTillDateUtc": "2024-12-13T00:00:00Z"
                }
                """, jsonDeserializationSettings
            );
        }

    }

    public class TenantCategoryPrice
    {
        public Guid TenantCategoryId { get; set; }

        public Guid? ProfileVendorId { get; set; }

        public Guid? OfferId { get; set; }

        public decimal? Markup { get; set; }

        public decimal? FixedFee { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime LastUpdatedOnUtc { get; set; }

        public Guid CreatedById { get; set; }

        public Guid LastUpdatedById { get; set; }

    }
}
