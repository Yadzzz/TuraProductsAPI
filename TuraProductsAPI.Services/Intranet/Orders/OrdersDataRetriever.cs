using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraProductsAPI.Services.Parcel;

namespace TuraProductsAPI.Services.Intranet.Orders
{
    public class OrdersDataRetriever
    {
        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            try
            {
                using (var context = new IntranetDataAccessLibrary.Context.ItturaContext())
                {
                    //var parameter = new SqlParameter("invoiceNo", this._invoiceNumber);
                    //var parcels = context.GetParcelNumberByNavInvoice_Results.FromSql($"GetParcelNumberByNavInvoice {this._invoiceNumber}").ToList();

                    using (var cmd = context.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = "dbo.GetAstroTripStatus";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.Add(new SqlParameter("@invoiceNo", this._invoiceNumber));

                        if (cmd.Connection.State != ConnectionState.Open)
                            cmd.Connection.Open();

                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                orders.Add(new Order()
                                {
                                    routeno = dataReader["routeno"].ToString(),
                                    regdate = Convert.ToDateTime(dataReader["regdate"].ToString()),
                                    tripstat = Convert.ToInt16(dataReader["tripstat"].ToString()),
                                    noordl = Convert.ToInt32(dataReader["noordl"].ToString()),
                                    norordl = Convert.ToInt32(dataReader["norordl"].ToString()),
                                    nopordl = Convert.ToInt32(dataReader["nopordl"].ToString())
                                });
                            }
                        }
                    }
                }

                Console.WriteLine(orders.Count());
                return orders;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
