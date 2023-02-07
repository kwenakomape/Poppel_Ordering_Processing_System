using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;

// ReSharper disable All

namespace Poppel_Order_Processing_System.DatabaseLayer
{
    public class OrderItemInfoDB : Database
    {
        #region Fields

        private string sqlQuery = "SELECT * FROM OrderItem";
        private Collection<OrderItem> orderItems;
        private OrderItem orderItem;

        #endregion

        #region Constructors

        public OrderItemInfoDB(string connectionString) : base(connectionString)
        {
            this.orderItems = new Collection<OrderItem>();
            ReadDataFromTable(sqlQuery);
        }

        public OrderItemInfoDB(string connectionString, string sqlQuery) : base(connectionString)
        {
            this.orderItems = new Collection<OrderItem>();
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

        public OrderItem OrderItem => orderItem;

        public Collection<OrderItem> AllOrderItems => orderItems;

        #endregion

        #region Methods

        private void FillOrderItems(SqlDataReader reader, Collection<OrderItem> orderItems)
        {
            OrderItem orderItem;
            while (reader.Read())
            {
                orderItem = new OrderItem();
                orderItem.OrderItemId = reader.GetInt32(0);
                orderItem.OrderId = reader.GetInt32(1);
                Product product = new Product();
                product.ProductId = reader.GetString(2);
                product.ProductDetails = reader.GetString(3);
                if (!reader.IsDBNull(4))
                {
                    product.ProductCategory = reader.GetString(4);
                }

                product.RetailPrice = reader.GetDecimal(5);
                product.CostPrice = reader.GetDecimal(6);
                orderItem.Product = product;
                orderItem.Quantity = reader.GetInt32(7);
                orderItems.Add(orderItem);
            }
        }

        private OrderItem FillOrderItems(SqlDataReader reader)
        {
            OrderItem orderItem;
            while (reader.Read())
            {
                orderItem = new OrderItem();
                orderItem.OrderItemId = reader.GetInt32(0);
                orderItem.OrderId = reader.GetInt32(1);
                Product product = new Product();
                product.ProductId = reader.GetString(2);
                product.ProductDetails = reader.GetString(3);
                if (!reader.IsDBNull(4))
                {
                    product.ProductCategory = reader.GetString(4);
                }

                product.RetailPrice = reader.GetDecimal(5);
                product.CostPrice = reader.GetDecimal(6);
                orderItem.Product = product;
                orderItem.Quantity = reader.GetInt32(7);
                return orderItem;
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
                    FillOrderItems(reader, orderItems);
                    reader.Close();
                    mainConnection.Close();
                    return "Success";
                }

                reader.Close();
                mainConnection.Close();
                return "Result Has No Rows";
            }
            catch (Exception e)
            {
                return (e.ToString());
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
                    this.orderItem = FillOrderItems(reader);
                    reader.Close();
                    mainConnection.Close();
                    return false;
                }

                reader.Close();
                mainConnection.Close();
                return false;
            }
            catch (Exception)
            {
                return false;
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

        public string GetValueString(OrderItem tempOrderItem)
        {
            string aStr = "'" + tempOrderItem.OrderId + "'," +
                          "'" + tempOrderItem.Product.ProductId + "'," +
                          "'" + tempOrderItem.Product.ProductDetails + "',";
            if (!tempOrderItem.Product.ProductCategory.Equals(""))
            {
                aStr += "'" + tempOrderItem.Product.ProductCategory + "',";
            }

            aStr += tempOrderItem.Product.RetailPrice + "," +
                    tempOrderItem.Product.CostPrice + "," +
                    tempOrderItem.Quantity;
            return aStr;
        }

        public bool DatabaseAdd(OrderItem tempOrderItem)
        {
            string strSQL = "";
            strSQL = "INSERT into ";
            if (!tempOrderItem.Product.ProductCategory.Equals(""))
            {
                strSQL +=
                    "OrderItem([Order_Id], [Product_Id], [Product_Details], [Product_Category], [Retail_Price], [Cost_Price], [Quantity])";
            }
            else
            {
                strSQL +=
                    "OrderItem([Order_Id], [Product_Id], [Product_Details], [Retail_Price], [Cost_Price], [Quantity])";
            }

            strSQL += " VALUES(" + GetValueString(tempOrderItem) + ")";
            SqlCommand sqlCommand = new SqlCommand(strSQL, mainConnection);
            return UpdateDataSource(sqlCommand);
        }

        public bool DatabaseEdit(OrderItem tempOrderItem)
        {
            string sqlString = "Update OrderItem Set [Product_Id] = '" + tempOrderItem.Product.ProductId + "'," +
                               "[Product_Details] = '" + tempOrderItem.Product.ProductDetails + "',";
            if (!tempOrderItem.Product.ProductCategory.Equals(""))
            {
                sqlString += "[Product_Category] = '" + tempOrderItem.Product.ProductCategory + "',";
            }

            sqlString += "[Retail_Price] = '" + tempOrderItem.Product.RetailPrice + "'," +
                         "[Cost_Price] = '" + tempOrderItem.Product.CostPrice + "'," +
                         "[Quantity] = '" + tempOrderItem.Quantity + "'" +
                         "WHERE ([Order Item Id] = '" + tempOrderItem.OrderItemId + "')";
            SqlCommand sqlCommand = new SqlCommand(sqlString, mainConnection);
            return UpdateDataSource(sqlCommand);
        }

        #endregion
    }
}