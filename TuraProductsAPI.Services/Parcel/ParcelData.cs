using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TuraProductsAPI.Services.Parcel
{
    public class ParcelData
    {
        [JsonPropertyName("InvoiceNo")]
        public string InvoiceNo { get; set; }

        [JsonPropertyName("Posting_Date")]
        public DateTime Posting_Date { get; set; }

        [JsonPropertyName("NAV_OrderNo")]
        public string NAV_OrderNo { get; set; }

        [JsonPropertyName("PickListNo")]
        public string PickListNo { get; set; }

        [JsonPropertyName("Line_No_")]
        public int Line_No_ { get; set; }

        [JsonPropertyName("ItemNo")]
        public string ItemNo { get; set; }

        [JsonPropertyName("PickedQuantity")]
        public decimal PickedQuantity { get; set; }

        [JsonPropertyName("ParcelNumber")]
        public string ParcelNumber { get; set; }

        [JsonPropertyName("ShippingCode")]
        public string ShippingCode { get; set; }

        [JsonPropertyName("ShippingName")]
        public string ShippingName { get; set; }

        [JsonPropertyName("Internet_Address")]
        public string Internet_Address { get; set; }
    }
}
