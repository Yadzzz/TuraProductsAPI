namespace TuraProductsAPI.Services.Invoice
{
    public class Invoice
    {
        public InvoiceRowResult GetInvoiceRows(string id, string language)
        {
            var result = new InvoiceRowResult();
            using (var repo = new InvoiceRepository())
            {
                try
                {
                    var items = repo.GetInoviceRows(id, language);
                    
                    if(items == null)
                    {
                        return null;
                    }

                    foreach (var item in items)
                    {
                        result.Rows.Add(new InvoiceRow()
                        {
                            Quantity = item.Quantity,
                            Description = item.Description,
                            ItemNumber = item.ItemNumber,
                            InvoiceDate = item.InvoiceDate,
                            RowNumber = item.RowNumber,
                            UnitPrice = item.UnitPrice,
                            ActivityCode = item.ActivityCode,
                            Ean = item.Ean,
                            InvoiceNumber = item.InvoiceNumber
                        });
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    result.ErrorMessage = ex.Message;
                    return null;
                }
            }
        }

        public string GetCustomerOrderNumbers(string invoiceNumber)
        {
            using (var repo = new InvoiceRepository())
            {
                return repo.GetOrdernumbersForInvoice(invoiceNumber);
            }
        }

        public InvoiceHeaderResult FilterInvoiceHeaders(SearchModel model, bool isCredit)
        {
            var result = new InvoiceHeaderResult();

            using (var repo = new InvoiceRepository())
            {
                try
                {
                    var items = repo.GetInvoicesByItem(model.itemNo, model.ean, model.customerNo, model.orderNo, model.invoiceNo, model.custOrderNo, model.startDate, model.endDate, model.take, model.skip, isCredit);
                    int total = repo.GetInvoicesByItem(model.itemNo, model.ean, model.customerNo, model.orderNo, model.invoiceNo, model.custOrderNo, model.startDate, model.endDate, model.take, 0, isCredit).Count();
                    foreach (var item in items)
                    {
                        result.Items.Add(new InvoiceHeaderModel()
                        {
                            CustomerNumber = item.CustomerNumber,
                            InvoiceNumber = item.InvoiceNumber,
                            InvoiceDate = item.InvoiceDate,
                            OrderDate = item.OrderDate,
                            CustomerOrderNumber = item.CustomerOrderNumber,
                            InvoiceTotalAmount = item.InvoiceTotalAmount,
                            DueDate = item.DueDate,
                            IsPayed = item.IsPayed,
                            OrderNumber = item.OrderNumber,
                            Currency = item.Currency,
                            InvoiceTotalAmountIncVAT = item.InvoiceTotalAmountIncVAT
                        });
                    }
                    if (result.Items.Count < 1)
                    {
                        result.ErrorMessage = "No hits";
                        //result.ErrorMessage = string.IsNullOrEmpty(itemNo) ? "Ean code " + ean : "Item number " + itemNo;
                        //result.ErrorMessage += " returned no hits";
                    }
                    result.TotalNrOfInvoices = total;
                    return result;
                }
                catch (Exception ex)
                {
                    result = new InvoiceHeaderResult();

                    result.ErrorMessage = ex.Message;
                    return result;
                }
            }
        }




        public InvoiceHeaderResult GetInvoiceHeaders(string itemNo, string ean, string customerNo, string orderNo, string invoiceNo, string custOrderNo, DateTime startDate, DateTime endDate, int take, int skip, bool isCredit)
        {
            var result = new InvoiceHeaderResult();

            using (var repo = new InvoiceRepository())
            {
                try
                {
                    var items = repo.GetInvoicesByItem(itemNo, ean, customerNo, orderNo, invoiceNo, custOrderNo, startDate, endDate, take, skip, isCredit);
                    int total = repo.GetInvoicesByItem(itemNo, ean, customerNo, orderNo, invoiceNo, custOrderNo, startDate, endDate, 5000, 0, isCredit).Count();
                    foreach (var item in items)
                    {
                        result.Items.Add(new InvoiceHeaderModel()
                        {
                            CustomerNumber = item.CustomerNumber,
                            InvoiceNumber = item.InvoiceNumber,
                            InvoiceDate = item.InvoiceDate,
                            OrderDate = item.OrderDate,
                            CustomerOrderNumber = item.CustomerOrderNumber,
                            InvoiceTotalAmount = item.InvoiceTotalAmount,
                            DueDate = item.DueDate,
                            IsPayed = item.IsPayed,
                            OrderNumber = item.OrderNumber,
                            Currency = item.Currency,
                            InvoiceTotalAmountIncVAT = item.InvoiceTotalAmountIncVAT
                        });
                    }
                    if (result.Items.Count < 1)
                    {
                        result.ErrorMessage = "No hits";
                        //result.ErrorMessage = string.IsNullOrEmpty(itemNo) ? "Ean code " + ean : "Item number " + itemNo;
                        //result.ErrorMessage += " returned no hits";
                    }
                    result.TotalNrOfInvoices = total;
                    return result;
                }
                catch (Exception ex)
                {

                    result.ErrorMessage = ex.Message;
                    return result;
                }
            }
        }

        internal DocumentResult FindDocuments(string customer, string order, string invoice, string type, DateTime from, DateTime to, int take, int skip)
        {
            var result = new DocumentResult();

            using (var repo = new InvoiceRepository())
            {
                try
                {
                    var items = repo.FindDocuments(customer, order, invoice, type, from, to, take, skip);
                    result.Items = items.ToList();
                    int total = repo.TotalDocuments(customer, order, invoice, type, from, to);
                    result.TotalNrOfDocuments = total;
                }
                catch (Exception ex)
                {

                    result.ErrorMessage = ex.Message;
                }

                return result;
            }
        }
    }
}
