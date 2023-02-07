using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;

// ReSharper disable All

namespace Poppel_Order_Processing_System.DatabaseLayer
{
    public class OrderInfoDB : Database
    {
        #region Fields

        private string sqlQuery = "SELECT * FROM OrderTable";
        private Collection<Order> orders;
        private Order order;

        #endregion

        #region Constructors

        public OrderInfoDB(string connectionString) : base(connectionString)
        {
            this.orders = new Collection<Order>();
            ReadDataFromTable(sqlQuery);
        }

        public OrderInfoDB(string connectionString, string sqlQuery) : base(connectionString)
        {
            this.orders = new Collection<Order>();
            if (sqlQuery.Contains("DELETE"))
            {
                DeleteRecordFromTable(sqlQuery);
            }
            else
            {
                ReadRecordFromTable(sqlQuery);
            }
        }

        #endregion

        #region Property Methods

        public Collection<Order> AllOrders => orders;

        public Order Order => order;

        #endregion

        #region Methods

        private void FillOrders(SqlDataReader reader, Collection<Order> orders)
        {
            Order order;
            while (reader.Read())
            {
                order = new Order();
                order.OrderId = reader.GetInt32(0);
                order.CustomerId = reader.GetInt32(1);
                order.OrderDate = reader.GetDateTime(2).Date;
                order.DeliveryFee = reader.GetDecimal(3);
                order.OrderTotalPrice = reader.GetDecimal(4);
                order.OrderStatus = Order.GetOrderStatus(reader.GetString(5));
                if (!reader.IsDBNull(6))
                {
                    order.ShippedDate = reader.GetDateTime(6).Date;
                }

                if (!reader.IsDBNull(7))
                {
                    order.CompletedDate = reader.GetDateTime(7).Date;
                }

                if (!reader.IsDBNull(8))
                {
                    order.DeliveryAddress = reader.GetString(8);
                }

                order.PaymentMethod = Order.GetPaymentMethod(reader.GetString(9));
                orders.Add(order);
            }
        }

        private Order FillOrders(SqlDataReader reader)
        {
            Order order;
            while (reader.Read())
            {
                order = new Order();
                order.OrderId = reader.GetInt32(0);
                order.CustomerId = reader.GetInt32(1);
                order.OrderDate = reader.GetDateTime(2).Date;
                order.DeliveryFee = reader.GetDecimal(3);
                order.OrderTotalPrice = reader.GetDecimal(4);
                order.OrderStatus = Order.GetOrderStatus(reader.GetString(5));
                if (!reader.IsDBNull(6))
                {
                    order.ShippedDate = reader.GetDateTime(6).Date;
                }

                if (!reader.IsDBNull(7))
                {
                    order.CompletedDate = reader.GetDateTime(7).Date;
                }

                if (!reader.IsDBNull(8))
                {
                    order.DeliveryAddress = reader.GetString(8);
                }

                order.PaymentMethod = Order.GetPaymentMethod(reader.GetString(9));
                return order;
            }

            return null;
        }

        private string ReadDataFromTable(string sqlQuery)
        {
            SqlDataReader reader;
            SqlCommand command;

            try
            {
                command = new SqlCommand(sqlQuery, mainConnection);
                mainConnection.Open();
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    FillOrders(reader, orders);
                    reader.Close();
                    return "Success";
                }

                reader.Close();
                return "Result Has No Rows";
            }
            catch (Exception e)
            {
                return (e.ToString());
            }
            finally
            {
                mainConnection.Close();
            }
        }

        private bool ReadRecordFromTable(string sqlQuery)
        {
            SqlDataReader reader;
            SqlCommand command;

            try
            {
                command = new SqlCommand(sqlQuery, mainConnection);
                mainConnection.Open();
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    this.order = FillOrders(reader);
                    reader.Close();
                    return false;
                }

                reader.Close();
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                mainConnection.Close();
            }
        }

        #endregion

        #region CRUD Methods

        private bool DeleteRecordFromTable(string sqlQuery)
        {
            SqlCommand command;

            try
            {
                command = new SqlCommand(sqlQuery, mainConnection);
                mainConnection.Open();
                command.CommandType = CommandType.Text;
                command.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error: Database Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                mainConnection.Close();
            }
        }

        public string GetValueString(Order tempOrder)
        {
            string aStr = tempOrder.CustomerId + "," +
                          "'" + tempOrder.OrderDate.ToString("dd-MMM-yyyy") + "'" + "," +
                          tempOrder.DeliveryFee + "," +
                          tempOrder.OrderTotalPrice + "," +
                          "'" + Order.GetOrderStatus(tempOrder.OrderStatus) + "'" + ",";

            if (!tempOrder.ShippedDate.Equals(new DateTime(1800, 1, 1)))
            {
                aStr += "'" + tempOrder.ShippedDate.ToString("dd-MMM-yyyy") + "'" + ",";
            }
            else
            {
                aStr += SqlDateTime.Null + ",";
            }

            if (!tempOrder.CompletedDate.Equals(new DateTime(1800, 1, 1)))
            {
                aStr += "'" + tempOrder.CompletedDate.ToString("dd-MMM-yyyy") + "'" + ",";
            }
            else
            {
                aStr += SqlDateTime.Null + ",";
            }

            if (!tempOrder.DeliveryAddress.Equals(""))
            {
                aStr += "'" + tempOrder.DeliveryAddress.ToString() + "'" + ",";
            }
            else
            {
                aStr += "NULL" + ",";
            }

            aStr += "'" + Order.GetPaymentMethod(tempOrder.PaymentMethod) + "'";
            return aStr;
        }

        public bool DatabaseAdd(Order tempOrder)
        {
            string strSQL = "";
            strSQL = "INSERT into " +
                     "OrderTable([Customer_Id], " +
                     "[Order_Date], [Delivery_Fee], " +
                     "[OrderTotal_Price], [Order_Status], " +
                     "[Shipped_Date], [Completed_Date], " +
                     "[Delivery_Address], [Payment_Method]) VALUES(" + GetValueString(tempOrder) + ")";

            SqlCommand sqlCommand = new SqlCommand(strSQL, mainConnection);
            return UpdateDataSource(sqlCommand);
        }

        public bool DatabaseEdit(Order tempOrder)
        {
            string sqlString = "Update OrderTable Set [Customer_Id] = '" + tempOrder.CustomerId + "'," +
                               "[Delivery_Fee] = '" + tempOrder.DeliveryFee + "'," +
                               "[OrderTotal_Price] = '" + tempOrder.OrderTotalPrice + "'," +
                               "[Order_Status] = '" + Order.GetOrderStatus(tempOrder.OrderStatus) + "',";
            if (!tempOrder.ShippedDate.Equals(new DateTime(1800, 1, 1)))
            {
                sqlString += "[Shipped_Date] = '" + tempOrder.ShippedDate.ToString("dd-MMM-yyyy") + "',";
            }
            else
            {
                sqlString += "[Shipped_Date] =" + SqlDateTime.Null + ",";
            }


            if (!tempOrder.CompletedDate.Equals(new DateTime(1800, 1, 1)))
            {
                sqlString += "[Completed_Date] = '" + tempOrder.CompletedDate.ToString("dd-MMM-yyyy") + "',";
            }
            else
            {
                sqlString += "[Completed_Date] =" + SqlDateTime.Null + ",";
            }

            if (!tempOrder.DeliveryAddress.Equals(""))
            {
                sqlString += "[Delivery_Address] = '" + tempOrder.DeliveryAddress.ToString() + "',";
            }
            else
            {
                sqlString += "[Delivery_Address] = NULL,";
            }


            sqlString += "[Payment_Method] = '" + Order.GetPaymentMethod(tempOrder.PaymentMethod) + "'" +
                         " WHERE ([Order_Id] = '" + tempOrder.OrderId + "')";
            SqlCommand sqlCommand = new SqlCommand(sqlString, mainConnection);
            return UpdateDataSource(sqlCommand);
        }

        #endregion
    }
}