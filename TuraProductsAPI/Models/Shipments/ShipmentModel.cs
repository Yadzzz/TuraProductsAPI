namespace TuraProductsAPI.Models.Shipments
{
    public class ShipmentModel
    {
        public ShipmentData? Shipment { get; set; }
        public ShipmentDeviationData? ShipmentDeviation { get; set; }
        public ShipmentUpdateData? ShipmentUpdate { get; set; }
        public List<ShipmentUpdateData>? ShipmentUpdates { get; set; }
    }
}
