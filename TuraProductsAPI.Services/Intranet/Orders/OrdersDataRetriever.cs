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
        public List<R08T1> GetOrders()
        {
            List<R08T1> orders = new List<R08T1>();

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
                                orders.Add(new R08T1()
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

                return orders;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public List<O08T1> GetNavOrder(string? navId, string? orderId)
        {
            List<O08T1> orders = new();

            try
            {
                using (var context = new IntranetDataAccessLibrary.Context.ItturaContext())
                {
                    using (var cmd = context.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = "dbo.[GetAstroOrderstatusByNavOrder]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (navId == null)
                        {
                            cmd.Parameters.Add(new SqlParameter("@NavOrderNo", DBNull.Value));
                            cmd.Parameters.Add(new SqlParameter("@CustomerOrderNo", orderId));

                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@NavOrderNo", navId));
                            cmd.Parameters.Add(new SqlParameter("@CustomerOrderNo", DBNull.Value));
                        }

                        if (cmd.Connection.State != ConnectionState.Open)
                            cmd.Connection.Open();

                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                O08T1 order = new()
                                {
                                    ordno = dataReader["ordno"].ToString(),
                                    regdate = Convert.ToDateTime(dataReader["regdate"]),
                                    linestat = Convert.ToInt16(dataReader["linestat"]),
                                    statdate = Convert.ToDateTime(dataReader["statdate"]),
                                    partno = dataReader["partno"].ToString(),
                                    partdsc1 = dataReader["partdsc1"].ToString(),
                                    reqquant = Convert.ToDecimal(dataReader["reqquant"]),
                                    delquant = Convert.ToDecimal(dataReader["delquant"]),
                                    ordline2 = dataReader["ordline2"].ToString(),
                                    eorderid = dataReader["eorderid"].ToString()
                                };

                                orders.Add(order);
                            }
                        }
                    }
                }

                return orders;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
