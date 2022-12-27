namespace TuraProductsAPI.Services
{
    public class InvoiceService
    {
        public TuraProductsAPI.Services.Invoice.InvoiceRowResult GetInvoiceRows(string id, string language)
        {
            Invoice.Invoice invoice = new Invoice.Invoice();

            return invoice.GetInvoiceRows(id, language);
        }

        public TuraProductsAPI.Services.Invoice.InvoiceHeaderResult GetInvoiceHeaders(string itemNo, string ean, string customerNo, string orderNo, string invoiceNo, string custOrderNo, DateTime startDate, DateTime endDate, int take, int skip)
        {
            Invoice.Invoice invoice = new Invoice.Invoice();

            return invoice.GetInvoiceHeaders(itemNo, ean, customerNo, orderNo, invoiceNo, custOrderNo, startDate, endDate, take, skip);
        }

        public string GetCustomerOrderNumbers(string invoiceNumber)
        {
            Invoice.Invoice invoice = new Invoice.Invoice();

            return invoice.GetCustomerOrderNumbers(invoiceNumber);
        }
    }
}
