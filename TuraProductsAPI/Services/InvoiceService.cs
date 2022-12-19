using TotalEntitiesDataAccessLibrary.Context;

namespace TuraProductsAPI.Services
{
    public class InvoiceService
    {
        public List<InvoiceDto> GetInvoice(string invoiceId, string language)
        {
            language = language.ToUpper() == "SWE" ? "" : language;

            var context = new TuraTotalContext();

            try
            {
                var items = (from s in context.SalesInvoiceHeaders
                             join l in context.SalesCrMemoLines
                             on s.No equals l.DocumentNo
                             join i in context.Items on l.No equals i.No
                             join t in context.ItemTranslations on new { Key1 = i.No, Key2 = language.ToUpper() } equals new { Key1 = t.ItemNo, Key2 = t.LanguageCode.ToUpper() } into trans
                             from result in trans.DefaultIfEmpty()
                             where s.No == invoiceId
                             && l.Quantity > 0
                             select new InvoiceDto()
                             {
                                 ActivityCode = i.ActivityCode,
                                 Ean = i.PrimaryEanCode,
                                 RowNumber = l.LineNo,
                                 Quantity = l.Quantity,
                                 Description = result.Description == null ? i.Description : result.Description,
                                 UnitPrice = l.UnitPrice,
                                 ItemNumber = i.No,
                                 InvoiceDate = s.PostingDate,
                                 InvoiceNumber = s.No
                             }).ToList();

                return items;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }

    public class InvoiceDto
    {
        public int RowNumber { get; set; }
        public string ItemNumber { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Description { get; set; }
        public string Ean { get; set; }
        public string ActivityCode { get; set; }
        public string InvoiceNumber { get; set; }
    }

    public class InvoiceHeader
    {
        public string InvoiceNumber { get; set; }
        public string CustomerNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal InvoiceTotalAmount { get; set; }
        public decimal InvoiceTotalAmountIncVAT { get; set; }
        public string CustomerOrderNumber { get; set; }
        public bool IsPayed { get; set; }
        public DateTime DueDate { get; set; }
        public string OrderNumber { get; set; }
        public string Currency { get; set; }


    }

    public class DocumentItem
    {
        public string InvoiceNumber { get; set; }
        public string CustomerNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerOrderNumber { get; set; }
        public string Type { get; set; }
        public DateTime Created { get; set; }
        public Guid PartId { get; set; }
    }
}
