using IntranetDataAccessLibrary.Models;

namespace TuraProductsAPI.Models.Shipments
{
    public class ShipmentModel
    {
        public Shipment Shipment { get; set; }
        public ShipmentDeviation ShipmentDeviation { get; set; }
        //public IEnumerable<ShipmentUpdate> ShipmentUpdate { get; set; }
    }
}
