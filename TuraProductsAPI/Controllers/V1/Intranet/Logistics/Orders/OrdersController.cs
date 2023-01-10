using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuraProductsAPI.Attributes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers.V1.Intranet.Logistics.Orders
{
    //[ApiKey]
    [Route("api/v1/intranet/logistics/orders/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/<Orders>
        [HttpGet]
        public async Task<ActionResult<List<Services.Intranet.Orders.R08T1>>> Get()
        {
            Services.Intranet.Orders.OrdersDataRetriever ordersDataRet = new();
            var orders = ordersDataRet.GetOrders();

            if (orders == null || orders.Count == 0)
            {
                return BadRequest();
            }

            return orders;
        }

        // GET: api/Orders/5
        [HttpGet("{id}/{type}")]
        public async Task<ActionResult<List<Services.Intranet.Orders.O08T1>>> GetCustomer(string id, string type)
        {
            Services.Intranet.Orders.OrdersDataRetriever ordersDataRetriever = new();

            if (type.ToLower() == "nav")
            {
                var orders = ordersDataRetriever.GetNavOrder(id, null);

                if (orders == null)
                {
                    return NotFound();
                }

                return orders;
            }
            else
            {
                var orders = ordersDataRetriever.GetNavOrder(null, id);

                if (orders == null)
                {
                    return NotFound();
                }

                return orders;
            }
        }
    }
}
