using IntranetDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuraProductsAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers.V1.Intranet.Logistics.Shipments
{
    [Route("api/v1/intranet/logistics/shipments/[controller]")]
    [ApiController]
    public class ShipmentEmployeeController : ControllerBase
    {
        // GET: api/<ShipmentEmployee>
        [HttpGet]
        public async Task<ActionResult<List<IntranetDataAccessLibrary.Models.ShipmentEmployee>>> Get()
        {
            List<IntranetDataAccessLibrary.Models.ShipmentEmployee> employees = new List<IntranetDataAccessLibrary.Models.ShipmentEmployee>();

            try
            {
                using (IntranetDataAccessLibrary.Context.ItturaContext context = new())
                {
                    employees = await context.ShipmentEmployees.Where(y => y.IsDeleted == false).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return employees;
        }

        // GET api/<ShipmentEmployee>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            string employee = string.Empty;

            try
            {
                using (IntranetDataAccessLibrary.Context.ItturaContext context = new())
                {
                    var emp = await context.ShipmentEmployees.Where(y => y.Id == id).FirstOrDefaultAsync();

                    if (emp != null)
                    {
                        employee = emp.FirstName + " " + emp.LastName;
                    }
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }

            return employee;
        }
    }
}
