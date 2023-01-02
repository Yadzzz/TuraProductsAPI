namespace TuraProductsAPI.Models.Shipments
{
    public class ShipmentUpdateData
    {
        public DateTime UpdatedAt { get; set; }

        public int Id { get; set; }

        public int? UpdatedBy { get; set; }

        public int ShipmentId { get; set; }

        public string? Note { get; set; }

        public int StatusId { get; set; }
    }
}
