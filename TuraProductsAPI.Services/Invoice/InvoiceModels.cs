namespace TuraProductsAPI.Services.Invoice
{
    public class InvoiceRow
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

    public class InvoiceRowResult
    {
        public InvoiceRowResult()
        {
            Rows = new List<InvoiceRow>();
        }
        public List<InvoiceRow> Rows { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class InvoiceHeaderModel
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

    public class InvoiceHeaderResult
    {
        public InvoiceHeaderResult()
        {
            Items = new List<InvoiceHeaderModel>();
        }

        public string ErrorMessage { get; set; }
        public List<InvoiceHeaderModel> Items { get; set; }
        public int TotalNrOfInvoices { get; set; }
    }

    public class DocumentResult
    {
        public DocumentResult()
        {
            Items = new List<DocumentItem>();
        }

        public string ErrorMessage { get; set; }
        public List<DocumentItem> Items { get; set; }
        public int TotalNrOfDocuments { get; set; }
    }

    public class SearchModel
    {

        public string itemNo { get; set; }
        public string ean { get; set; }
        public string customerNo { get; set; }
        public string orderNo { get; set; }
        public string invoiceNo { get; set; }
        public string custOrderNo { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int take { get; set; }
        public int skip { get; set; }
        public bool isCredit { get; set; }

    }
}
