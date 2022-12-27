using Microsoft.AspNetCore.Mvc;
using TuraProductsAPI.Services.Invoice;
using TuraProductsAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private ILogger<DocumentsController> _logger;
        private Services.InvoiceService _invoiceService;

        public InvoiceController(ILogger<DocumentsController> logger, Services.InvoiceService invoiceService)
        {
            this._logger = logger;
            this._invoiceService = invoiceService;
        }

        // GET: api/<InvoiceService>/55/SWE
        [HttpGet("{invoiceNumber}/{language}")]
        public IActionResult Get(string invoiceNumber, string language)
        {
            var rowResult = this._invoiceService.GetInvoiceRows(invoiceNumber, language);

            if (rowResult == null)
            {
                Console.WriteLine("null");
                return NotFound("Not Found");
            }
            else
            {
                Console.WriteLine("Not null");
            }

            return Ok(rowResult);
        }

        // GET: api/<InvoiceService>/55/SWE/55
        [HttpGet("getinvoicerows/{invoiceNumber}/{language}/{customerNumber}")]
        public IActionResult Get(string invoiceNumber, string language, string customerNumber)
        {
            bool isOwner = false;

            try
            {
                using (var context = new StreamServiceDataAccessLibrary.Context.StrsTuraArchiveNewContext())
                {
                    isOwner = context.MetaInvoices.Where(x => x.InvoiceNumber == invoiceNumber && x.CustomerNumber == customerNumber).Count() == 1;
                }
            }
            catch
            {
                //Log
            }

            if(!isOwner)
            {
                return NoContent();
            }

            var rowResult = this._invoiceService.GetInvoiceRows(invoiceNumber, language);

            if(rowResult == null)
            {
                Console.WriteLine("null");
                return NotFound("Not Found");
            }
            else
            {
                Console.WriteLine("Not null");
            }

            return Ok(rowResult);
        }

        // GET: api/<InvoiceService>/55/SWE
        [HttpGet("{itemNo}/{ean}/{customerNo}/{orderNo}/{invoiceNo}/{custOrderNo}/{startDate}/{endDate}/{take}/{skip}")]
        public IActionResult GetInvoiceHeaders(string itemNo, string ean, string customerNo, string orderNo, string invoiceNo, string custOrderNo, DateTime startDate, DateTime endDate, int take, int skip)
        {
            //var req = this.ActionContext;
            //string encodedUsernamePassword = "";
            //try
            //{
            //    encodedUsernamePassword = req.Request.Headers.Authorization.Parameter.ToString();
            //}
            //catch (Exception ex)
            //{

            //    return Ok(new InvoiceHeaderResult() { ErrorMessage = ex.Message });
            //}

            //if (!AuthService.CheckUser(encodedUsernamePassword))
            //{
            //    return Ok(new InvoiceHeaderResult() { ErrorMessage = "Unauthorized" });
            //}

            var rmaItems = this._invoiceService.GetInvoiceHeaders(itemNo, ean, customerNo, orderNo, invoiceNo, custOrderNo, startDate, endDate, take, skip);

            foreach (var item in rmaItems.Items)
            {
                item.CustomerOrderNumber = string.IsNullOrEmpty(item.CustomerOrderNumber) ? this._invoiceService.GetCustomerOrderNumbers(item.InvoiceNumber) : item.CustomerOrderNumber;
            }

            return Ok(rmaItems);
        }
    }
}
