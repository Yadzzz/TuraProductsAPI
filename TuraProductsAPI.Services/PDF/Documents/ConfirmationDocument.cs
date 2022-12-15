﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StreamServiceDataAccessLibrary.Context;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TuraProductsAPI.Services.PDF.Documents
{
    public class ConfirmationDocument : IDocument
    {
        public string DocumentNumber { get; set; }
        public DocumentType DocumentType { get; set; }

        public ConfirmationDocument(string documentNumber, DocumentType documentType)
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
                    var data = context.MetaOrderbeks.AsNoTracking().OrderByDescending(y => y.BlobInfoCreationDateTime).AsNoTracking()
                                                                    .Where(x => x.OrderNumber == this.DocumentNumber).AsNoTracking().FirstOrDefault();

                    if (data == null || data.DocumentData == null)
                    {
                        return null;
                    }

                    documentData = data.DocumentData;
                }
                catch(Exception ex)
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
