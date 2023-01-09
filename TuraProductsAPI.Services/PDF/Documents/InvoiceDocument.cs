using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using StreamServiceDataAccessLibrary.Context;

namespace TuraProductsAPI.Services.PDF.Documents
{
    public class InvoiceDocument : IDocument
    {
        private Microsoft.Extensions.Logging.ILogger _logger { get; set; }
        public string DocumentNumber { get; set; }
        public DocumentType DocumentType { get; set; }

        public InvoiceDocument(string documentNumber, DocumentType documentType)
        {
            this.DocumentNumber = documentNumber;
            this.DocumentType = documentType;

            //Temporary logger
            var loggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => builder.AddSerilog());
            var logger = loggerFactory.CreateLogger(string.Empty);
            this._logger = logger;
        }

        public DocumentData? GetDocumentData()
        {
            DocumentData document = new();
            //byte[] documentData;

            using (StrsTuraArchiveNewContext context = new StrsTuraArchiveNewContext())
            {
                try
                {
                    var data = context.MetaInvoices.AsNoTracking().OrderByDescending(y => y.BlobInfoCreationDateTime).AsNoTracking()
                                                                    .Where(x => x.InvoiceNumber == this.DocumentNumber).AsNoTracking().FirstOrDefault();

                    if (data == null || data.DocumentData == null)
                    {
                        return null;
                    }

                    document.PartPartId = data.PartPartId;
                    document.InvoiceDate = data.InvoiceDate;
                    document.Data = data.DocumentData;
                    document.InvoiceNumber = data.InvoiceNumber;
                    document.CustomerNumber = data.CustomerNumber;
                    document.CreationDateTime = data.BlobInfoCreationDateTime;
                }
                catch (Exception ex)
                {
                    //Log
                    this._logger.LogError(ex.ToString());
                    return null;
                }
            }

            return document;
        }

        public void DeleteDocumentData()
        {

        }
    }
}
