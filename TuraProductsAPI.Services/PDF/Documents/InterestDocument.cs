using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StreamServiceDataAccessLibrary.Context;

namespace TuraProductsAPI.Services.PDF.Documents
{
    public class InterestDocument : IDocument
    {
        public string DocumentNumber { get; set; }
        public DocumentType DocumentType { get; set; }

        public InterestDocument(string documentNumber, DocumentType documentType)
        {
            this.DocumentNumber = documentNumber;
            this.DocumentType = documentType;
        }

        public DocumentData? GetDocumentData()
        {
            byte[] documentData;

            using (StrsTuraArchiveNewContext context = new StrsTuraArchiveNewContext())
            {
                try
                {
                    var data = context.MetaFinanceChrgs.AsNoTracking().AsNoTracking().OrderByDescending(y => y.BlobInfoCreationDateTime).AsNoTracking()
                                                                    .Where(x => x.InvoiceNumber == this.DocumentNumber).AsNoTracking().FirstOrDefault();

                    if (data == null || data.DocumentData == null)
                    {
                        return null;
                    }

                    documentData = data.DocumentData;
                }
                catch (Exception ex)
                {
                    //Log
                    return null;
                }
            }

            return new DocumentData(this.DocumentNumber, this.DocumentType, documentData);
        }

        public void DeleteDocumentData()
        {

        }
    }
}
