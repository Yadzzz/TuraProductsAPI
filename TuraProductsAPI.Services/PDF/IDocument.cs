using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraProductsAPI.Services.PDF
{
    public interface IDocument
    {
        public DocumentData GetDocumentData();
        public void DeleteDocumentData();
    }
}
