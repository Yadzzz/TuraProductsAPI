using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Imaging;
using TuraProductsAPI.Attributes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers.V1.Intranet.Logistics.Shipments
{
    [ApiKey]
    [Route("api/v1/intranet/logistics/shipments/[controller]")]
    [ApiController]
    public class ShipmentReceivingCompanyController : ControllerBase
    {
        // GET: api/<ShipmentReceivingCompanyController>
        [HttpGet]
        public async Task<ActionResult<List<IntranetDataAccessLibrary.Models.ShipmentReceivingCompany>>> Get()
        {
            List<IntranetDataAccessLibrary.Models.ShipmentReceivingCompany> companies = new();

            try
            {
                using (IntranetDataAccessLibrary.Context.ItturaContext context = new())
                {
                    companies = await context.ShipmentReceivingCompanies.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return companies;
        }

        // GET api/<ShipmentReceivingCompanyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            string company = string.Empty;

            try
            {
                using (IntranetDataAccessLibrary.Context.ItturaContext context = new())
                {
                    var comp = await context.ShipmentReceivingCompanies.Where(x => x.Id == id).FirstOrDefaultAsync();

                    if (comp != null)
                    {
                        company = comp.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }

            return company;
        }
    }
}
