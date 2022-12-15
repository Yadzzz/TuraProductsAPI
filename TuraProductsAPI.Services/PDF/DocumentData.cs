using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraProductsAPI.Services.PDF
{
    public class DocumentData
    {
        public string DocumentNumber { get; set; }
        public DocumentType DocumentType { get; set; }
        public byte[] Data { get; set; }

        public DocumentData(string documentNumber, DocumentType documentType, byte[] data)
        {
            this.DocumentNumber = documentNumber;
            this.DocumentType = documentType;
            this.Data = data;
        }
    }
}
