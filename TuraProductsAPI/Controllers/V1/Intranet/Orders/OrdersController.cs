using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers.V1.Intranet.Orders
{
    [Route("api/v1/intranet/orders/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/<Orders>
        [HttpGet]
        public async Task<ActionResult<List<Services.Intranet.Orders.Order>>> Get()
        {
            Services.Intranet.Orders.OrdersDataRetriever ordersDataRet = new();
            var orders = ordersDataRet.GetOrders();

            Console.WriteLine(orders.Count);

            return orders;
        }
    }
}
