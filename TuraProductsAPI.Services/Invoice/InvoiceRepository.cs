using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalEntitiesDataAccessLibrary.Context;

namespace TuraProductsAPI.Services.Invoice
{
    public class InvoiceRepository : IDisposable
    {
        private TuraTotalContext _totalContext;
        private StreamServiceDataAccessLibrary.Context.StrsTuraArchiveNewContext _pdfContext;

        public InvoiceRepository()
        {
            this._totalContext = new TuraTotalContext();
            this._pdfContext = new StreamServiceDataAccessLibrary.Context.StrsTuraArchiveNewContext();
        }

        public IEnumerable<InvoiceDto> GetInoviceRows(string invoiceNr, string language)
        {
            language = language.ToUpper() == "SWE" ? "" : language;
            try
            {
                var items = (from s in _totalContext.SalesInvoiceHeaders
                             join l in _totalContext.SalesInvoiceLines
                             on s.No equals l.DocumentNo
                             join i in _totalContext.Items on l.No equals i.No
                             join t in _totalContext.ItemTranslations on new { Key1 = i.No, Key2 = language.ToUpper() } equals new { Key1 = t.ItemNo, Key2 = t.LanguageCode.ToUpper() } into trans
                             from result in trans.DefaultIfEmpty()
                             where s.No == invoiceNr
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

                if (items == null || items.Count == 0)
                {
                    return null;
                }

                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public IEnumerable<InvoiceHeader> GetInvoicesByItem(string itemNo, string ean, string customerNo, string orderNo, string invoiceNo, string custOrderNo, DateTime startDate, DateTime endDate, int take, int skip)
        {
            try
            {
                List<string> invoices = new List<string>();
                if (itemNo != "0" || ean != "0" || custOrderNo != "0")
                {
                    var invoiceNr = (from s in this._totalContext.SalesInvoiceHeaders
                                     join l in this._totalContext.SalesInvoiceLines
                                     on s.No equals l.DocumentNo
                                     join i in this._totalContext.Items
                                     on l.No equals i.No
                                     where (itemNo == "0" ? 1 == 1 : l.No == itemNo)
                                     && (ean == "0" ? 1 == 1 : i.PrimaryEanCode == ean)
                                     && (custOrderNo == "0" ? 1 == 1 : l.YourOrderNo == custOrderNo)
                                     && s.SellToCustomerNo == customerNo
                                     && l.Quantity > 0
                                     select s.No).ToList();
                    invoices = invoiceNr.Distinct().ToList();
                    if (invoices.Count < 1)
                    {
                        return new List<InvoiceHeader>();
                    }
                }


                var invoiceHeaders = (from s in this._totalContext.SalesInvoiceHeaders
                                          //join l in context.Sales_Invoice_Line
                                          //on s.No_ equals l.Document_No_
                                          //join i in context.Item on l.No_ equals i.No_
                                      orderby s.PostingDate descending
                                      where s.SellToCustomerNo == customerNo
                                      //&& (itemNo == "0" ? 1 == 1 : l.No_ == itemNo)
                                      //&& (ean == "0" ? 1 == 1 : i.Primary_EAN_Code == ean)
                                      && (orderNo == "0" ? 1 == 1 : s.OrderNo == orderNo)
                                      && (invoiceNo == "0" ? 1 == 1 : s.No == invoiceNo)
                                      && s.PostingDate >= startDate
                                      && s.PostingDate <= endDate
                                      && (invoices.Count == 0 ? 1 == 1 : invoices.Contains(s.No))
                                      //&& (customerNo == "0" ? 1 == 1 :  == customerNo) Finns inte med i tabellen än, men den kommer
                                      select new InvoiceHeader()
                                      {
                                          CustomerNumber = s.SellToCustomerNo,
                                          //Ean = i.Primary_EAN_Code,
                                          InvoiceDate = s.PostingDate,
                                          InvoiceNumber = s.No,
                                          //ItemNumber = i.No_,
                                          OrderDate = s.OrderDate,
                                          OrderNumber = s.OrderNo,
                                          IsPayed = s.IsOpen.HasValue ? !s.IsOpen.Value : false,
                                          DueDate = s.DueDate.HasValue ? s.DueDate.Value : DateTime.MinValue,
                                          CustomerOrderNumber = s.YourOrderNo,
                                          Currency = s.CurrencyCode,
                                          InvoiceTotalAmountIncVAT = s.AmountInclVat.HasValue ? s.AmountInclVat.Value : 0,
                                          InvoiceTotalAmount = s.AmountInclVat.Value
                                      }).Skip(skip).Take(take).ToList();

                return invoiceHeaders;





            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public IEnumerable<InvoiceHeader> GetInvoicesByItem(string itemNo, string ean, string customerNo, string orderNo, string invoiceNo, string custOrderNo, DateTime startDate, DateTime endDate, int take, int skip, bool isCretit)
        {
            try
            {
                itemNo = string.IsNullOrEmpty(itemNo) ? "0" : itemNo;
                ean = string.IsNullOrEmpty(ean) ? "0" : ean;
                orderNo = string.IsNullOrEmpty(orderNo) ? "0" : orderNo;
                invoiceNo = string.IsNullOrEmpty(invoiceNo) ? "0" : invoiceNo;
                custOrderNo = string.IsNullOrEmpty(custOrderNo) ? "0" : custOrderNo;

                var context = new TuraTotalContext();

                List<string> invoices = new List<string>();


                if (itemNo != "0" || ean != "0" || custOrderNo != "0")
                {
                    invoices = GetInvoiceNumbers(itemNo, ean, customerNo, custOrderNo, context, invoices, isCretit);
                    if (invoices.Count < 1)
                    {
                        return new List<InvoiceHeader>();
                    }
                }


                var invoiceHeaders = GetInvoiceHeaders(customerNo, orderNo, invoiceNo, startDate, endDate, take, skip, context, invoices, isCretit);

                return invoiceHeaders;





            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private static List<InvoiceHeader> GetInvoiceHeaders(string customerNo, string orderNo, string invoiceNo, DateTime startDate, DateTime endDate, int take, int skip, TuraTotalContext context, List<string> invoices, bool isCredit)
        {
            if (!isCredit)
            {
                var invoiceHeaders = (from s in context.SalesInvoiceHeaders
                                          //join l in context.Sales_Invoice_Line
                                          //on s.No_ equals l.Document_No_
                                          //join i in context.Item on l.No_ equals i.No_
                                      orderby s.PostingDate descending
                                      where s.SellToCustomerNo == customerNo
                                      //&& (itemNo == "0" ? 1 == 1 : l.No_ == itemNo)
                                      //&& (ean == "0" ? 1 == 1 : i.Primary_EAN_Code == ean)
                                      && (orderNo == "0" ? 1 == 1 : s.OrderNo == orderNo)
                                      && (invoiceNo == "0" ? 1 == 1 : s.No == invoiceNo)
                                      && s.PostingDate >= startDate
                                      && s.PostingDate <= endDate
                                      && (invoices.Count == 0 ? 1 == 1 : invoices.Contains(s.No))
                                      //&& (customerNo == "0" ? 1 == 1 :  == customerNo) Finns inte med i tabellen än, men den kommer
                                      select new InvoiceHeader()
                                      {
                                          CustomerNumber = s.SellToCustomerNo,
                                          //Ean = i.Primary_EAN_Code,
                                          InvoiceDate = s.PostingDate,
                                          InvoiceNumber = s.No,
                                          //ItemNumber = i.No_,
                                          OrderDate = s.OrderDate,
                                          OrderNumber = s.OrderNo,
                                          IsPayed = s.IsOpen.HasValue ? !s.IsOpen.Value : false,
                                          DueDate = s.DueDate.HasValue ? s.DueDate.Value : DateTime.MinValue,
                                          CustomerOrderNumber = s.YourOrderNo,
                                          Currency = s.CurrencyCode,
                                          InvoiceTotalAmountIncVAT = s.AmountInclVat.HasValue ? s.AmountInclVat.Value : 0,
                                          InvoiceTotalAmount = s.AmountInclVat.Value
                                      }).Skip(skip).Take(take).ToList();
                return invoiceHeaders;
            }
            else
            {
                var invoiceHeaders = (from s in context.SalesCrMemoHeaders
                                          //join l in context.Sales_Invoice_Line
                                          //on s.No_ equals l.Document_No_
                                          //join i in context.Item on l.No_ equals i.No_
                                      orderby s.PostingDate descending
                                      where s.SellToCustomerNo == customerNo
                                      //&& (itemNo == "0" ? 1 == 1 : l.No_ == itemNo)
                                      //&& (ean == "0" ? 1 == 1 : i.Primary_EAN_Code == ean)
                                      && (orderNo == "0" ? 1 == 1 : s.ReturnOrderNo == orderNo)
                                      && (invoiceNo == "0" ? 1 == 1 : s.No == invoiceNo)
                                      && s.PostingDate >= startDate
                                      && s.PostingDate <= endDate
                                      && (invoices.Count == 0 ? 1 == 1 : invoices.Contains(s.No))
                                      //&& (customerNo == "0" ? 1 == 1 :  == customerNo) Finns inte med i tabellen än, men den kommer
                                      select new InvoiceHeader()
                                      {
                                          CustomerNumber = s.SellToCustomerNo,
                                          //Ean = i.Primary_EAN_Code,
                                          InvoiceDate = s.PostingDate,
                                          InvoiceNumber = s.No,
                                          //ItemNumber = i.No_,
                                          //OrderDate = s.da,
                                          OrderNumber = s.ReturnOrderNo,
                                          IsPayed = s.IsOpen.HasValue ? !s.IsOpen.Value : false,
                                          DueDate = s.DueDate.HasValue ? s.DueDate.Value : DateTime.MinValue,
                                          CustomerOrderNumber = s.YourOrderNo,
                                          Currency = s.CurrencyCode,
                                          InvoiceTotalAmountIncVAT = s.AmountInclVat.HasValue ? s.AmountInclVat.Value : 0,
                                          InvoiceTotalAmount = s.AmountInclVat.Value
                                      }).Skip(skip).Take(take).ToList();
                return invoiceHeaders;
            }

        }

        private static List<string> GetInvoiceNumbers(string itemNo, string ean, string customerNo, string custOrderNo, TuraTotalContext context, List<string> invoices, bool isCredit)
        {
            if (!isCredit)
            {
                var invoiceNr = (from s in context.SalesInvoiceHeaders
                                 join l in context.SalesInvoiceLines
                                 on s.No equals l.DocumentNo
                                 join i in context.Items
                                 on l.No equals i.No
                                 where (itemNo == "0" ? 1 == 1 : l.No == itemNo)
                                 && (ean == "0" ? 1 == 1 : i.PrimaryEanCode == ean)
                                 && (custOrderNo == "0" ? 1 == 1 : l.YourOrderNo == custOrderNo)
                                 && s.SellToCustomerNo == customerNo
                                 && l.Quantity > 0
                                 select s.No).ToList();
                invoices = invoiceNr.Distinct().ToList();
                return invoices;
            }
            else
            {
                var invoiceNr = (from s in context.SalesCrMemoHeaders
                                 join l in context.SalesCrMemoLines
                                 on s.No equals l.DocumentNo
                                 join i in context.Items
                                 on l.No equals i.No
                                 where (itemNo == "0" ? 1 == 1 : l.No == itemNo)
                                 && (ean == "0" ? 1 == 1 : i.PrimaryEanCode == ean)
                                 && (custOrderNo == "0" ? 1 == 1 : l.YourOrderNo == custOrderNo)
                                 && s.SellToCustomerNo == customerNo
                                 && l.Quantity > 0
                                 select s.No).ToList();
                invoices = invoiceNr.Distinct().ToList();
                return invoices;
            }

        }

        public string GetOrdernumbersForInvoice(string invoiceNumber)
        {
            var numbers = _totalContext.SalesInvoiceLines.Where(x => x.DocumentNo == invoiceNumber && x.Quantity > 0).Select(x => x.YourOrderNo).ToList();
            string orders = "";
            if (numbers != null)
            {
                //if(numbers.Count > 0)
                //{
                //    orders = string.Join(",", numbers);
                //}
                if (numbers.Count > 0)
                {
                    bool first = true;
                    foreach (var s in numbers)
                    {
                        if (!first)
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                orders += ", " + s;
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                orders += s;
                                first = false;
                            }
                        }
                    }
                }
            }
            return orders;
        }

        public IEnumerable<DocumentItem> FindDocuments(string customer, string order, string invoice, string type, DateTime fromdate, DateTime todate, int take, int skip)
        {
            switch (type)
            {
                case "interest":
                    var financechrg = (from s in _pdfContext.MetaFinanceChrgs

                                       orderby s.InvoiceDate descending
                                       where //s.Sell_to_Customer_No_ == customerNo

                                        (invoice == "0" ? 1 == 1 : s.InvoiceNumber == invoice)
                                       && s.InvoiceDate >= fromdate
                                       && s.InvoiceDate < todate
                                       && (customer == "0" ? 1 == 1 : s.CustomerNumber == customer)
                                       //&& (customerNo == "0" ? 1 == 1 :  == customerNo) Finns inte med i tabellen än, men den kommer
                                       select new DocumentItem()
                                       {
                                           CustomerNumber = s.CustomerNumber,
                                           //Ean = i.Primary_EAN_Code,
                                           InvoiceDate = s.InvoiceDate.HasValue ? s.InvoiceDate.Value : DateTime.Now,
                                           InvoiceNumber = s.InvoiceNumber,
                                           Type = type,
                                           Created = s.BlobInfoCreationDateTime.Value,
                                           PartId = s.PartPartId

                                       }).Skip(skip).Take(take).ToList();

                    return financechrg;
                case "invoice":

                    var invoiceHeaders = (from s in _pdfContext.MetaInvoices

                                          orderby s.InvoiceDate descending
                                          where //s.Sell_to_Customer_No_ == customerNo

                                           (invoice == "0" ? 1 == 1 : s.InvoiceNumber == invoice)
                                          && s.InvoiceDate >= fromdate
                                          && s.InvoiceDate < todate
                                          && (customer == "0" ? 1 == 1 : s.CustomerNumber == customer)
                                          //&& (customerNo == "0" ? 1 == 1 :  == customerNo) Finns inte med i tabellen än, men den kommer
                                          select new DocumentItem()
                                          {
                                              CustomerNumber = s.CustomerNumber,
                                              //Ean = i.Primary_EAN_Code,
                                              InvoiceDate = s.InvoiceDate.HasValue ? s.InvoiceDate.Value : DateTime.Now,
                                              InvoiceNumber = s.InvoiceNumber,
                                              Type = type,
                                              Created = s.BlobInfoCreationDateTime.Value,
                                              PartId = s.PartPartId

                                          }).Skip(skip).Take(take).ToList();

                    return invoiceHeaders;
                case "delivery":
                    var delivery = (from s in _pdfContext.MetaLeveransbeks

                                    orderby s.OrderDate descending
                                    where //s.Sell_to_Customer_No_ == customerNo

                                     (order == "0" ? 1 == 1 : s.OrderNumber == order)
                                    && s.OrderDate >= fromdate
                                    && s.OrderDate < todate
                                    && (customer == "0" ? 1 == 1 : s.CustomerNumber == customer)
                                    //&& (customerNo == "0" ? 1 == 1 :  == customerNo) Finns inte med i tabellen än, men den kommer
                                    select new DocumentItem()
                                    {
                                        CustomerNumber = s.CustomerNumber,
                                        //Ean = i.Primary_EAN_Code,
                                        OrderDate = s.OrderDate.HasValue ? s.OrderDate.Value : DateTime.Now,
                                        OrderNumber = s.OrderNumber,
                                        Type = type,
                                        Created = s.BlobInfoCreationDateTime.Value,
                                        PartId = s.PartPartId


                                    }).Skip(skip).Take(take).ToList();

                    return delivery;
                case "confirmation":
                    var confirmation = (from s in _pdfContext.MetaOrderbeks

                                        orderby s.OrderDate descending
                                        where //s.Sell_to_Customer_No_ == customerNo

                                         (order == "0" ? 1 == 1 : s.OrderNumber == order)
                                        && s.OrderDate >= fromdate
                                        && s.OrderDate < todate
                                        && (customer == "0" ? 1 == 1 : s.CustomerNumber == customer)
                                        //&& (customerNo == "0" ? 1 == 1 :  == customerNo) Finns inte med i tabellen än, men den kommer
                                        select new DocumentItem()
                                        {
                                            CustomerNumber = s.CustomerNumber,
                                            //Ean = i.Primary_EAN_Code,
                                            OrderDate = s.OrderDate.HasValue ? s.OrderDate.Value : DateTime.Now,
                                            OrderNumber = s.OrderNumber,
                                            Type = type,
                                            Created = s.BlobInfoCreationDateTime.Value,
                                            PartId = s.PartPartId


                                        }).Skip(skip).Take(take).ToList();

                    return confirmation;
                case "return":
                    var retrunorder = (from s in _pdfContext.MetaReturorders

                                       orderby s.OrderDate descending
                                       where //s.Sell_to_Customer_No_ == customerNo

                                        (order == "0" ? 1 == 1 : s.OrderNumber == order)
                                       && s.OrderDate >= fromdate
                                       && s.OrderDate < todate
                                       && (customer == "0" ? 1 == 1 : s.CustomerNumber == customer)
                                       //&& (customerNo == "0" ? 1 == 1 :  == customerNo) Finns inte med i tabellen än, men den kommer
                                       select new DocumentItem()
                                       {
                                           CustomerNumber = s.CustomerNumber,
                                           //Ean = i.Primary_EAN_Code,
                                           OrderDate = s.OrderDate.HasValue ? s.OrderDate.Value : DateTime.Now,
                                           OrderNumber = s.OrderNumber,
                                           Type = type,
                                           Created = s.BlobInfoCreationDateTime.Value,
                                           PartId = s.PartPartId


                                       }).Skip(skip).Take(take).ToList();

                    return retrunorder;
                default:
                    return null;

            }
        }

        public int TotalDocuments(string customer, string order, string invoice, string type, DateTime fromDate, DateTime toDate)
        {
            switch (type)
            {
                case "interest":
                    return (from s in _pdfContext.MetaFinanceChrgs

                            where //s.Sell_to_Customer_No_ == customerNo

                                          (invoice == "0" ? 1 == 1 : s.InvoiceNumber == invoice)
                                         && s.InvoiceDate >= fromDate
                                         && s.InvoiceDate < toDate
                                         && (customer == "0" ? 1 == 1 : s.CustomerNumber == customer)
                            select s).Count();

                //return PdfContext.META_FinanceChrg.Where(x => invoice == "0" ? 1 == 1 : x.InvoiceNumber == invoice && customer == "0" ? 1 == 1 : x.CustomerNumber == customer && x.InvoiceDate >= from && x.InvoiceDate <= to).Count();

                case "invoice":
                    return (from s in _pdfContext.MetaInvoices

                            where //s.Sell_to_Customer_No_ == customerNo

                                          (invoice == "0" ? 1 == 1 : s.InvoiceNumber == invoice)
                                         && s.InvoiceDate >= fromDate
                                         && s.InvoiceDate < toDate
                                         && (customer == "0" ? 1 == 1 : s.CustomerNumber == customer)
                            select s).Count();

                //return PdfContext.META_Invoice.Where(x => invoice == "0" ? 1 == 1 : x.InvoiceNumber == invoice && customer == "0" ? 1 == 1 : x.CustomerNumber == customer && x.InvoiceDate >= from && x.InvoiceDate <= to).Count();

                case "delivery":
                    return (from s in _pdfContext.MetaLeveransbeks

                            where //s.Sell_to_Customer_No_ == customerNo

                                          (order == "0" ? 1 == 1 : s.OrderNumber == order)
                                         && s.OrderDate >= fromDate
                                         && s.OrderDate < toDate
                                         && (customer == "0" ? 1 == 1 : s.CustomerNumber == customer)
                            select s).Count();
                //return PdfContext.META_Leveransbek.Where(x => order == "0" ? 1 == 1 : x.OrderNumber == order && customer == "0" ? 1 == 1 : x.CustomerNumber == customer && x.OrderDate >= from && x.OrderDate <= to).Count();

                case "confirmation":

                    return (from s in _pdfContext.MetaLeveransbeks

                            where //s.Sell_to_Customer_No_ == customerNo

                                          (order == "0" ? 1 == 1 : s.OrderNumber == order)
                                         && s.OrderDate >= fromDate
                                         && s.OrderDate < toDate
                                         && (customer == "0" ? 1 == 1 : s.CustomerNumber == customer)
                            select s).Count();
                //return PdfContext.META_Orderbek.Where(x => order == "0" ? 1 == 1 : x.OrderNumber == order && customer == "0" ? 1 == 1 : x.CustomerNumber == customer && x.OrderDate >= from && x.OrderDate <= to).Count();
                case "return":

                    return (from s in _pdfContext.MetaReturorders

                            where //s.Sell_to_Customer_No_ == customerNo

                                          (order == "0" ? 1 == 1 : s.OrderNumber == order)
                                         && s.OrderDate >= fromDate
                                         && s.OrderDate < toDate
                                         && (customer == "0" ? 1 == 1 : s.CustomerNumber == customer)
                            select s).Count();
                default:
                    return 0;

            }
        }

        public void Dispose()
        {
            this._totalContext.Dispose();
            this._pdfContext.Dispose();
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
