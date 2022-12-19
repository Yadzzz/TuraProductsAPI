namespace TuraProductsAPI.Services
{
    public class InvoiceService
    {
        public TuraProductsAPI.Services.Invoice.InvoiceRowResult GetInvoiceRows(string id, string language)
        {
            Invoice.Invoice invoice = new Invoice.Invoice();

            return invoice.GetInvoiceRows(id, language);
        }
    }
}
