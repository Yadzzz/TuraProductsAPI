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
using System.Net;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDataController : ControllerBase
    {
        private readonly ILogger<ProductsDataController> logger;
        private readonly TIDataDbContext _context;

        public ProductsDataController(TIDataDbContext context, ILogger<ProductsDataController> _logger)
        {
            this.logger = _logger;
            this._context = context;
        }

        // GET: api/ProductsData/5/DKK
        [HttpGet("{id}/{currencyCode}")]
        public async Task<ActionResult<ProductDataModel>> GetProductData(string id, string currencyCode)
        {
            try
            {
                string salesCode = string.Empty;
                if (currencyCode.ToLower().Contains("sek") || currencyCode == null || currencyCode == string.Empty)
                    salesCode = "REK_SEK";
                else
                    salesCode = "REK_" + currencyCode.ToUpper();

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

                var tiNavSalesPriceREK = await _context.TiNavSalesPrices.AsNoTracking().
                                            Where(i => i.ItemNo == id).Where(i => i.CurrencyCode == currencyCode 
                                                    && i.SalesCode == salesCode).FirstOrDefaultAsync();

                if (tiNavSalesPriceREK == null)
                {
                    return NotFound();
                }

                var priceWithoutVat = await _context.TiNavSalesPrices.AsNoTracking().
                                            Where(i => i.ItemNo == id).Where(i => i.CurrencyCode == currencyCode
                                                    && i.PriceIncludesVat == 0 && i.SalesCode == string.Empty).Select(u => u.UnitPrice).FirstOrDefaultAsync();
                //if (priceWithoutVat == null)
                //{
                //    return NotFound();
                //}

                var tiNavItem = await _context.TiNavItems.FindAsync(id);
                if (tiNavItem == null)
                {
                    return NotFound();
                }

                var tiNavQtyTmp = await _context.TiNavQtyTmps.FindAsync(id);
                if (tiNavQtyTmp == null)
                {
                    return NotFound();
                }

                var tiNavItemUnitOfMeasure = await _context.TiNavItemUnitOfMeasures.FindAsync(id, "INNER");
                if(tiNavItemUnitOfMeasure == null)
                {
                    return NotFound();
                }

                productDataModel.SetProductDescriptionData(tiLitProductDescription);
                productDataModel.SetSalesPrices(tiNavSalesPriceREK);
                productDataModel.SetItem(tiNavItem);
                productDataModel.SetQtyTmp(tiNavQtyTmp);
                productDataModel.SetItemUnitOfMeasure(tiNavItemUnitOfMeasure);
                productDataModel.SetUnitPriceWithoutVat(priceWithoutVat);


                //this._context.Dispose();

                return productDataModel;
            }
            catch(Exception exception)
            {
                this.logger.LogError(exception, exception.ToString());

                //this._context.Dispose();

                return BadRequest();
            }
        }
    }
}

