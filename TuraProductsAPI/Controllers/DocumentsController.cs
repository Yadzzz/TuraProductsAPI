using Microsoft.AspNetCore.Mvc;
using System;
using System.IO.Compression;
using System.Net;
using System.Net.Http.Headers;
using TuraProductsAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private ILogger<DocumentsController> _logger { get; set; }
        private PdfService _pdfService { get; set; }

        public DocumentsController(ILogger<DocumentsController> logger, PdfService pdfService)
        {
            this._logger = logger;
            this._pdfService = pdfService;
        }

        // GET api/<DocumentsController>/5/invoice
        [HttpGet("{documentNumber}/{type}")]
        public byte[]? Get(string documentNumber, string type)
        {
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            return this._pdfService.GetDocumentData(documentNumber, type);
        }
    }
}
