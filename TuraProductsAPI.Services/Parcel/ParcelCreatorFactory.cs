using DataAccessLibrary;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalEntitiesDataAccessLibrary.Models;

namespace TuraProductsAPI.Services.Parcel
{
    public class ParcelCreatorFactory
    {
        private string _invoiceNumber { get; set; }
        private int[] _actors { get; set; }

        public ParcelCreatorFactory(string invoiceNumber)
        {
            this._invoiceNumber = invoiceNumber;
        }

        public ParcelContainer GetParcelNumbers()
        {
            ParcelContainer container = new();

            try
            {
                using (var context = new DataAccessLibrary.Context.TIDataDbContext())
                {
                    //var parameter = new SqlParameter("invoiceNo", this._invoiceNumber);
                    //var parcels = context.GetParcelNumberByNavInvoice_Results.FromSql($"GetParcelNumberByNavInvoice {this._invoiceNumber}").ToList();

                    using (var cmd = context.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = "dbo.GetParcelNumberByNavInvoice";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@invoiceNo", this._invoiceNumber));

                        if (cmd.Connection.State != ConnectionState.Open)
                            cmd.Connection.Open();

                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                container.Parcels.Add(new ParcelData()
                                {
                                    InvoiceNo = dataReader[0].ToString(),
                                    Posting_Date = Convert.ToDateTime(dataReader[1].ToString()),
                                    NAV_OrderNo = dataReader[2].ToString(),
                                    PickListNo = dataReader[3].ToString(),
                                    Line_No_ = Convert.ToInt32(dataReader[4].ToString()),
                                    ItemNo = dataReader[5].ToString(),
                                    PickedQuantity = Convert.ToDecimal(dataReader[6].ToString()),
                                    ParcelNumber = dataReader[7].ToString(),
                                    ShippingCode = dataReader[8].ToString(),
                                    ShippingName = dataReader[9].ToString(),
                                    Internet_Address = dataReader[10].ToString(),
                                });
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                return null;
            }

            return container;
        }
    }
}
