using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuraProductsAPI.Models.Shipments;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers.V1.Intranet.Logistics.Shipments
{
    [Route("api/v1/intranet/logistics/shipments/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        // GET: api/<ShipmentsController>
        [HttpGet]
        public async Task<ActionResult<List<ShipmentModel>>> Get()
        {
            List<ShipmentModel> shipmentModels = new();

            try
            {
                using (var context = new IntranetDataAccessLibrary.Context.ItturaContext())
                {
                    var shipments = await context.Shipments.OrderByDescending(x => x.Id).Take(100).ToListAsync();

                    foreach (var shipment in shipments)
                    {
                        ShipmentModel shipmentModel = new()
                        {
                            Shipment = shipment
                        };

                        var shipmentUpdate = await context.ShipmentUpdates.Where(x => x.ShipmentId == shipment.Id).OrderByDescending(x => x.UpdatedAt).FirstOrDefaultAsync();

                        if (shipmentUpdate != null)
                        {
                            if (shipmentUpdate.StatusId != 4)
                            {
                                var shipmentDeviation = await context.ShipmentDeviations.Where(x => x.ShipmentId == shipment.Id).FirstOrDefaultAsync();
                                shipmentModels.Add(shipmentModel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return shipmentModels;
        }

        // POST api/<ShipmentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShipmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShipmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
