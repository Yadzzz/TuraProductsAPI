using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers.V1.Intranet.Logistics.Shipments
{
    [Route("api/v1/intranet/logistics/shipments/[controller]")]
    [ApiController]
    public class ShipmentStatusController : ControllerBase
    {
        // GET: api/<ShipmentStatusController>
        [HttpGet]
        public async Task<ActionResult<List<IntranetDataAccessLibrary.Models.ShipmentStatus>>> Get()
        {
            List<IntranetDataAccessLibrary.Models.ShipmentStatus> statuses = new();

            try
            {
                using (IntranetDataAccessLibrary.Context.ItturaContext context = new())
                {
                    statuses = await context.ShipmentStatuses.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return statuses;
        }
    }
}
