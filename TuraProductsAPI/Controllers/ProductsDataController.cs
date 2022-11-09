using DataAccessLibrary.Context;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.EntityFrameworkCore;
using TuraProductsAPI.Attributes;
using TuraProductsAPI.Models;
using System.Linq;
using System.Buffers.Text;
using System.Drawing.Drawing2D;
using NuGet.Packaging.Signing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDataController : ControllerBase
    {
        private readonly TIDataDbContext _context;

        public ProductsDataController(TIDataDbContext context)
        {
            this._context = context;
        }

        // GET: api/<ProductsDataController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SalesPrices/5/DKK
        [HttpGet("{id}/{currencyCode}")]
        public async Task<ActionResult<ProductDataModel>> GetProductData(string id, string currencyCode)
        {
            if (currencyCode.ToLower().Contains("sek") || currencyCode == null || currencyCode == string.Empty)
                currencyCode = "";
            else
                currencyCode = currencyCode.ToUpper();

            ProductDataModel productDataModel = new ProductDataModel();

            var tiLitProductDescription = await _context.TiLitProductDescriptions.FindAsync(id);

            if (tiLitProductDescription == null)
            {
                return NotFound();
            }

            productDataModel.SetProductDescriptionData(tiLitProductDescription);

            var tiNavSalesPrice = await _context.TiNavSalesPrices.AsNoTracking().
                                        Where(i => i.ItemNo == id).Where(i => i.CurrencyCode == currencyCode).FirstOrDefaultAsync();

            if (tiNavSalesPrice == null)
            {
                return NotFound();
            }

            productDataModel.SetSalesPrices(tiNavSalesPrice);

            return productDataModel;
        }
    }
}

