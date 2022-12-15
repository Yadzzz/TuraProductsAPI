using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamServiceDataAccessLibrary.Context;

namespace TuraProductsAPI.Services.PDF
{
    public interface IDocument
    {
        public string DocumentNumber { get; set; }
        public DocumentType DocumentType { get; set; }
        public DocumentData? GetDocumentData();
        public void DeleteDocumentData();
    }
}
