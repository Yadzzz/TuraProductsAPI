using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TuraProductsAPI.Services.Parcel
{
    public class ParcelContainer
    {
        [JsonPropertyName("InvoiceNumber")]
        public string InvoiceNumber { get; set; }

        [JsonPropertyName("ErrorMessage")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("Parcels")]
        public List<ParcelData> Parcels { get; set; }

        public ParcelContainer()
        {
            this.Parcels = new List<ParcelData>();
        }
    }
}
