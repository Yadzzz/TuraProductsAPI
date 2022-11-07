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
    public class ProductDescriptionsController : ControllerBase
    {
        private readonly TIDataDbContext _context;

        public ProductDescriptionsController(TIDataDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductDescriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiLitProductDescription>> GetTiLitProductDescription(string id)
        {
            var tiLitProductDescription = await _context.TiLitProductDescriptions.FindAsync(id);

            if (tiLitProductDescription == null)
            {
                return NotFound();
            }

            return tiLitProductDescription;
        }

        private bool TiLitProductDescriptionExists(string id)
        {
            return _context.TiLitProductDescriptions.Any(e => e.VariantId == id);
        }
    }
}
