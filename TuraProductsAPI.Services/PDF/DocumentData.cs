using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraProductsAPI.Services.PDF
{
    public class DocumentData
    {
        public Guid PartPartId { get; set; }
        //public DocumentType DocumentType { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? CustomerNumber { get; set; }
        public byte[]? Data { get; set; }

        public DocumentData()
        {

        }

        public DocumentData(string documentNumber, DocumentType documentType, byte[] data)
        {
            this.InvoiceNumber = documentNumber;
            //this.DocumentType = documentType;
            this.Data = data;
        }
    }
}
