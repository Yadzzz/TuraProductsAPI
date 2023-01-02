using IntranetDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using TuraProductsAPI.Models.Shipments;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers.V1.Intranet.Logistics.Shipments
{
    [Route("api/v1/intranet/logistics/shipments/[controller]")]
    [ApiController]
    public class ShipmentUpdateController : ControllerBase
    {
        // POST api/<ShipmentUpdateController>
        [HttpPost]
        public async Task Post([FromBody] ShipmentUpdateData shipmentUpdateData)
        {
            try
            {
                using (var context = new IntranetDataAccessLibrary.Context.ItturaContext())
                {

                    await context.ShipmentUpdates.AddAsync(new ShipmentUpdate()
                    {
                        ShipmentId = shipmentUpdateData.ShipmentId,
                        UpdatedBy = shipmentUpdateData.UpdatedBy,
                        UpdatedAt = shipmentUpdateData.UpdatedAt,
                        StatusId = shipmentUpdateData.StatusId,
                        Note = shipmentUpdateData.Note
                    });

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
