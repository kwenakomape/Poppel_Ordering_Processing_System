using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;

// ReSharper disable All

namespace Poppel_Order_Processing_System.DatabaseLayer
{
    class StockCategoryInfoDB : Database
    {
        #region Fields

        private string sqlQuery = "SELECT * FROM StockCategory";
        private Collection<StockCategory> stockCategories;
        private StockCategory stockCategory;

        #endregion

        #region Constructors

        public StockCategoryInfoDB(string connectionString) : base(connectionString)
        {
            this.stockCategories = new Collection<StockCategory>();
            ReadDataFromTable(sqlQuery);
        }

        public StockCategoryInfoDB(string connectionString, string sqlQuery) : base(connectionString)
        {
            this.stockCategories = new Collection<StockCategory>();
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

        public Collection<StockCategory> AllStockCategories => stockCategories;
        public StockCategory StockCategory => stockCategory;

        #endregion

        #region DataReader Methods

        private void FillStockCategories(SqlDataReader reader, Collection<StockCategory> stockCategories)
        {
            StockCategory stockCategory;
            while (reader.Read())
            {
                stockCategory = new StockCategory();
                stockCategory.StockCategoryId = reader.GetInt32(0);
                stockCategory.StockCategoryName = reader.GetString(1).Trim();

                stockCategories.Add(stockCategory);
            }
        }

        private StockCategory FillStockCategories(SqlDataReader reader)
        {
            StockCategory stockCategory;
            while (reader.Read())
            {
                stockCategory = new StockCategory();
                stockCategory.StockCategoryId = reader.GetInt32(0);
                stockCategory.StockCategoryName = reader.GetString(1).Trim();

                return stockCategory;
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
                    this.stockCategory = FillStockCategories(reader);
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
                    FillStockCategories(reader, stockCategories);
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

        public string GetValueString(StockCategory tempStockCategory)
        {
            string aStr = "'" + tempStockCategory.StockCategoryName + "'";
            return aStr;
        }

        public bool DatabaseAdd(StockCategory tempStockCategory)
        {
            string strSQL = "";
            strSQL = "INSERT into " +
                     "StockCategory([Category Name])"
                     + " VALUES(" + GetValueString(tempStockCategory) + ")";
            SqlCommand sqlCommand = new SqlCommand(strSQL, mainConnection);
            return UpdateDataSource(sqlCommand);
        }

        public bool DatabaseEdit(StockCategory tempStockCategory)
        {
            string sqlString = "Update StockCategory Set [Category Name] = '" + tempStockCategory.StockCategoryName +"'" +
                               "WHERE ([Category Id] = '" + tempStockCategory.StockCategoryId + "')";
            SqlCommand sqlCommand = new SqlCommand(sqlString, mainConnection);
            return UpdateDataSource(sqlCommand);
        }

        #endregion
    }
}