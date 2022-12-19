using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        // GET api/<ParcelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {


            return "value";
        }
    }
}
