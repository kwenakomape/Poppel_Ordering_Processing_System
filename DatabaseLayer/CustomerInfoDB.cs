// ReSharper disable All

using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;

namespace Poppel_Order_Processing_System.DatabaseLayer
{
    public class CustomerInfoDB : Database
    {
        #region Fields

        private string sqlQuery = "SELECT * FROM Customer";
        private Collection<Customer> customers;
        private Customer customer;

        #endregion

        #region Constructors

        public CustomerInfoDB(string connectionString) : base(connectionString)
        {
            this.customers = new Collection<Customer>();
            ReadDataFromTable(sqlQuery);
        }

        public CustomerInfoDB(string connectionString, string sqlQuery) : base(connectionString)
        {
            this.customers = new Collection<Customer>();
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

        public Customer Customer => customer;
        public Collection<Customer> AllCustomers => customers;

        #endregion

        #region DataReader Methods

        private void FillCustomers(SqlDataReader reader, Collection<Customer> customers)
        {
            Customer customer;
            while (reader.Read())
            {
                customer = new Customer();

                customer.CustomerId = reader.GetInt32(0);
                customer.FirstName = reader.GetString(1).Trim();
                customer.LastName = reader.GetString(2).Trim();
                customer.PhoneNumber = reader.GetString(3).Trim();
                customer.EmailAddress = reader.GetString(4).Trim();

                if (!reader.IsDBNull(5))
                {
                    string sqlQuery = "SELECT * FROM DeliveryAddress WHERE [Delivery Address Id] =" +
                                      reader.GetInt32(5);
                    customer.DeliveryAddress = new DeliveryAddressController(sqlQuery).DeliveryAddress;
                }

                customer.CustomerCredit = reader.GetDecimal(6);
                customer.CreditStatus = reader.GetString(7).Trim();

                customers.Add(customer);
            }
        }

        private Customer FillCustomers(SqlDataReader reader)
        {
            Customer tempCustomer = new Customer();
            while (reader.Read())
            {
                tempCustomer.CustomerId = reader.GetInt32(0);
                tempCustomer.FirstName = reader.GetString(1).Trim();
                tempCustomer.LastName = reader.GetString(2).Trim();
                tempCustomer.PhoneNumber = reader.GetString(3).Trim();
                tempCustomer.EmailAddress = reader.GetString(4).Trim();

                if (!reader.IsDBNull(5))
                {
                    string sqlQuery = "SELECT * FROM DeliveryAddress WHERE [Delivery Address Id] =" +
                                      reader.GetInt32(5);
                    tempCustomer.DeliveryAddress = new DeliveryAddressController(sqlQuery).DeliveryAddress;
                }

                tempCustomer.CustomerCredit = reader.GetDecimal(6);
                tempCustomer.CreditStatus = reader.GetString(7).Trim();

                return tempCustomer;
            }

            return null;
        }

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
                    FillCustomers(reader, customers);
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
                    this.customer = FillCustomers(reader);
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

        #endregion

        #region CRUD Methods

        public string GetValueString(Customer tempCustomer)
        {
            if (tempCustomer.DeliveryAddress == null)
            {
                string aStr = " ' " + tempCustomer.FirstName + " ' ," +
                              " ' " + tempCustomer.LastName + " ' ," +
                              " ' " + tempCustomer.PhoneNumber + " ' , " +
                              " ' " + tempCustomer.EmailAddress + " ' , " +
                              tempCustomer.CustomerCredit + " ," +
                              " ' " + tempCustomer.CreditStatus + " ' ";
                return aStr;
            }
            else
            {
                string aStr = " ' " + tempCustomer.FirstName + " ' ," +
                              " ' " + tempCustomer.LastName + " ' ," +
                              " ' " + tempCustomer.PhoneNumber + " ' , " +
                              " ' " + tempCustomer.EmailAddress + " ' , " +
                              +tempCustomer.DeliveryAddress.DeliveryAddressId + " ," +
                              +tempCustomer.CustomerCredit + " ," +
                              " ' " + tempCustomer.CreditStatus + " ' ";
                return aStr;
            }
        }

        public bool DatabaseAdd(Customer tempCustomer)
        {
            if (tempCustomer.DeliveryAddress == null)
            {
                string strSQL = "INSERT into " +
                         "Customer([First_Name], [Last_Name], [Phone_Number], [Email_Address], [Customer_Credit], [Credit_Status])"
                         + " VALUES(" + GetValueString(tempCustomer) + ")";
                SqlCommand sqlCommand = new SqlCommand(strSQL, mainConnection);
                return UpdateDataSource(sqlCommand);
            }
            else
            {
                string strSQL = "INSERT into " +
                         "Customer([First_Name], [Last_Name], [Phone_Number], [Email_Address], [Delivery_Address], [Customer_Credit], [Credit_Status])"
                         + " VALUES(" + GetValueString(tempCustomer) + ")";
                SqlCommand sqlCommand = new SqlCommand(strSQL, mainConnection);
                return UpdateDataSource(sqlCommand);
            }
        }

        public bool DatabaseEdit(Customer tempCustomer)
        {
            if (tempCustomer.DeliveryAddress != null)
            {
                string sqlString = "Update Customer Set [First_Name] = '" + tempCustomer.FirstName + "'," +
                                   "[Last_Name] = '" + tempCustomer.LastName + "'," +
                                   "[Phone_Number] = '" + tempCustomer.PhoneNumber + "'," +
                                   "[Email_Address] = '" + tempCustomer.EmailAddress + "'," +
                                   "[Delivery_Address] = '" + tempCustomer.DeliveryAddress.DeliveryAddressId + "'," +
                                   "[Customer_Credit] = '" + tempCustomer.CustomerCredit + "'," +
                                   "[Credit_Status] = '" + tempCustomer.CreditStatus + "'" +
                                   "WHERE ([Customer_Id] = '" + tempCustomer.CustomerId + "')";
                SqlCommand sqlCommand = new SqlCommand(sqlString, mainConnection);
                return UpdateDataSource(sqlCommand);
            }
            else
            {
                string sqlString = "Update Customer Set [First_Name] = '" + tempCustomer.FirstName + "'," +
                                   "[Last_Name] = '" + tempCustomer.LastName + "'," +
                                   "[Phone_Number] = '" + tempCustomer.PhoneNumber + "'," +
                                   "[Email_Address] = '" + tempCustomer.EmailAddress + "'," +
                                   "[Delivery_Address] = NULL," +
                                   "[Customer_Credit] = '" + tempCustomer.CustomerCredit + "'," +
                                   "[Credit_Status] = '" + tempCustomer.CreditStatus + "'" +
                                   "WHERE ([Customer_Id] = '" + tempCustomer.CustomerId + "')";
                SqlCommand sqlCommand = new SqlCommand(sqlString, mainConnection);
                return UpdateDataSource(sqlCommand);
            }
        }

        #endregion
    }
}