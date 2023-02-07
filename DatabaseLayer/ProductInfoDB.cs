using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;

// ReSharper disable All

namespace Poppel_Order_Processing_System.DatabaseLayer
{
    public class ProductInfoDB : Database
    {
        #region Fields

        private string sqlQuery = "SELECT * FROM Product";
        private Collection<Product> products;
        private Product product;

        #endregion

        #region Constructors

        public ProductInfoDB(string connectionString) : base(connectionString)
        {
            this.products = new Collection<Product>();
            ReadDataFromTable(sqlQuery);
        }

        public ProductInfoDB(string connectionString, string sqlQuery) : base(connectionString)
        {
            this.products = new Collection<Product>();
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

        public Product Product => product;
        public Collection<Product> AllProducts => products;

        #endregion

        #region DataReader Methods

        private void FillProducts(SqlDataReader reader, Collection<Product> products)
        {
            Product product;
            while (reader.Read())
            {
                product = new Product();
                product.ProductTableId = reader.GetInt32(0);
                product.ProductId = reader.GetString(1).Trim();
                product.ProductDetails = reader.GetString(2).Trim();
                if (!reader.IsDBNull(3))
                {
                    product.ExpiryDate = reader.GetDateTime(3).Date;
                }

                product.TrackExpiryDate = Convert.ToBoolean(reader.GetString(4).Trim());
                product.ProductCategory = reader.GetString(5).Trim();
                product.QuantityOnHand = reader.GetInt32(6);
                product.RetailPrice = reader.GetDecimal(7);
                product.CostPrice = reader.GetDecimal(8);
                products.Add(product);
            }
        }

        private Product FillProducts(SqlDataReader reader)
        {
            Product tempProduct = new Product();
            ;
            while (reader.Read())
            {
                tempProduct.ProductTableId = reader.GetInt32(0);
                tempProduct.ProductId = reader.GetString(1).Trim();
                tempProduct.ProductDetails = reader.GetString(2).Trim();
                if (!reader.IsDBNull(3))
                {
                    tempProduct.ExpiryDate = reader.GetDateTime(3).Date;
                }

                tempProduct.TrackExpiryDate = Convert.ToBoolean(reader.GetString(4).Trim());
                tempProduct.ProductCategory = reader.GetString(5).Trim();
                tempProduct.QuantityOnHand = reader.GetInt32(6);
                tempProduct.RetailPrice = reader.GetDecimal(7);
                tempProduct.CostPrice = reader.GetDecimal(8);
                return tempProduct;
            }

            return null;
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
                    this.product = FillProducts(reader);
                    reader.Close();
                    return true;
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
                    FillProducts(reader, products);
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

        public string GetValueString(Product tempProduct)
        {
            if (tempProduct.ExpiryDate.Equals(new DateTime(1800, 1, 1)))
            {
                string aStr = "'" + tempProduct.ProductId + "'," +
                              "'" + tempProduct.ProductDetails + "'," +
                              "'" + tempProduct.TrackExpiryDate.ToString() + "'," +
                              "'" + tempProduct.ProductCategory + " ' ," +
                              tempProduct.QuantityOnHand + "," +
                              tempProduct.RetailPrice + "," +
                              tempProduct.CostPrice;
                return aStr;
            }
            else
            {
                string aStr = "'" + tempProduct.ProductId + "'," +
                              "'" + tempProduct.ProductDetails + "'," +
                              "'" + tempProduct.ExpiryDate.ToString("dd-MMM-yyyy") + "'," +
                              "'" + tempProduct.TrackExpiryDate.ToString() + "'," +
                              "'" + tempProduct.ProductCategory + "'," +
                              tempProduct.QuantityOnHand + "," +
                              tempProduct.RetailPrice + "," +
                              tempProduct.CostPrice;
                return aStr;
            }
        }

        public bool DatabaseAdd(Product tempProduct)
        {
            if (tempProduct.ExpiryDate.Equals(new DateTime(1800, 1, 1)))
            {
                string strSQL = "";
                strSQL = "INSERT into " +
                         "Product([Product_Id], [Product_Details], [Track_Expiry_Date], [Product_Category], [Quantity_On_Hand], [Retail_Price], [Cost_Price])"
                         + " VALUES(" + GetValueString(tempProduct) + ")";
                SqlCommand sqlCommand = new SqlCommand(strSQL, mainConnection);
                return UpdateDataSource(sqlCommand);
            }
            else
            {
                string strSQL = "";
                strSQL = "INSERT into " +
                         "Product([Product_Id], [Product_Details], [Expiry_Date], [Track_Expiry_Date], [Product_Category], [Quantity_On_Hand], [Retail_Price], [Cost_Price])"
                         + " VALUES(" + GetValueString(tempProduct) + ")";
                SqlCommand sqlCommand = new SqlCommand(strSQL, mainConnection);
                return UpdateDataSource(sqlCommand);
            }
        }

        public bool DatabaseEdit(Product tempProduct)
        {
            if (!tempProduct.ExpiryDate.Equals(new DateTime(1800, 1, 1)))
            {
                string sqlString = "Update Product Set [Product_Id] = '" + tempProduct.ProductId + "'," +
                                   "[Product_Details] = '" + tempProduct.ProductDetails + "'," +
                                   "[Expiry_Date] = '" + tempProduct.ExpiryDate.ToString("dd-MMM-yyyy") + "'," +
                                   "[Track_Expiry_Date] = '" + tempProduct.TrackExpiryDate.ToString() + "'," +
                                   "[Product_Category] = '" + tempProduct.ProductCategory + "'," +
                                   "[Quantity_On_Hand] = '" + tempProduct.QuantityOnHand + "'," +
                                   "[Retail_Price] = '" + tempProduct.RetailPrice + "'," +
                                   "[Cost_Price] = '" + tempProduct.CostPrice + "'" +
                                   "WHERE ([Product_Table_Id] = '" + tempProduct.ProductTableId + "')";
                SqlCommand sqlCommand = new SqlCommand(sqlString, mainConnection);
                return UpdateDataSource(sqlCommand);
            }
            else
            {
                string sqlString = "Update Product Set [Product_Id] = '" + tempProduct.ProductId + "'," +
                                   "[Product_Details] = '" + tempProduct.ProductDetails + "'," +
                                   "[Expiry_Date] = NULL ," +
                                   "[Track_Expiry_Date] = '" + tempProduct.TrackExpiryDate.ToString() + "'," +
                                   "[Product_Category] = '" + tempProduct.ProductCategory + "'," +
                                   "[Quantity_On_Hand] = '" + tempProduct.QuantityOnHand + "'," +
                                   "[Retail_Price] = '" + tempProduct.RetailPrice + "'," +
                                   "[Cost_Price] = '" + tempProduct.CostPrice + "'" +
                                   "WHERE ([Product_Table_Id] = '" + tempProduct.ProductTableId + "')";
                SqlCommand sqlCommand = new SqlCommand(sqlString, mainConnection);
                return UpdateDataSource(sqlCommand);
            }
        }

        #endregion
    }
}