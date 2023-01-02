namespace TuraProductsAPI.Models.Shipments
{
    public class ShipmentData
    {
        public int Id { get; set; }

        public DateTime ReceivedAt { get; set; }

        public int? ReceivedBy { get; set; }

        public int? ReceivingCompany { get; set; }

        public string? OrderNumbers { get; set; }

        public int? NumberOfPallets { get; set; }

        public int? NumberOfPackages { get; set; }

        public string? Placement { get; set; }

        public int? InitatedBy { get; set; }

        public string? Supplier { get; set; }

        public bool? Prioritized { get; set; }
    }
}
