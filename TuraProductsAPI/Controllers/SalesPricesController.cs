using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLibrary.Context;
using DataAccessLibrary.Models;
using TuraProductsAPI.Attributes;

namespace TuraProductsAPI.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPricesController : ControllerBase
    {
        private readonly TIDataDbContext _context;

        public SalesPricesController(TIDataDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesPrices/5?salesCode=REK_DKK&currencyCode=DKK
        [HttpGet("{id}/{salesCode}/{currencyCode}")]
        public async Task<ActionResult<TiNavSalesPrice>> GetTiNavSalesPrice(string id, string salesCode, string currencyCode)
        {
            //var tiNavSalesPrice = await _context.TiNavSalesPrices.FindAsync(id);
            //var tiNavSalesPrice = await _context.TiNavSalesPrices.AsNoTracking().
            //                            Where(i => i.ItemNo == id && i.SalesCode == salesCode && i.CurrencyCode == currencyCode).FirstOrDefaultAsync();
            var tiNavSalesPrice = await _context.TiNavSalesPrices.AsNoTracking().
                                        Where(i => i.ItemNo == id).Where(i => i.SalesCode == salesCode && i.CurrencyCode == currencyCode).FirstOrDefaultAsync();

            if (tiNavSalesPrice == null)
            {
                return NotFound();
            }

            return tiNavSalesPrice;
        }

        private bool TiNavSalesPriceExists(string id)
        {
            return _context.TiNavSalesPrices.Any(e => e.ItemNo == id);
        }
    }
}
