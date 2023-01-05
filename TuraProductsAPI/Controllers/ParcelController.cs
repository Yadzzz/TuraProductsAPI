using Microsoft.AspNetCore.Mvc;
using TuraProductsAPI.Attributes;
using TuraProductsAPI.Services;
using TuraProductsAPI.Services.Parcel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        private ILogger<ParcelController> _logger {get; set; }
        private ParcelService _parcelService { get; set;}

        public ParcelController(ILogger<ParcelController> logger, ParcelService parcelService)
        {
            this._logger = logger;
            this._parcelService = parcelService;
        }

        // GET api/<ParcelController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var data = this._parcelService.GetParcelContainer(id);

            if(data == null)
            {
                ParcelContainer emptyContainer = new();
                return NotFound();
            }

            return Ok(data);
        }
    }
}
