using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;

// ReSharper disable All

namespace Poppel_Order_Processing_System.DatabaseLayer
{
    public class DeliveryAddressInfoDB : Database
    {
        #region Property Methods

        public Collection<DeliveryAddress> AllDeliveryAddresses => deliveryAddresses;

        #endregion

        #region Fields

        private string sqlQuery = "SELECT * FROM DeliveryAddress";
        private Collection<DeliveryAddress> deliveryAddresses;
        private DeliveryAddress deliveryAddress;

        public DeliveryAddress DeliveryAddress => deliveryAddress;

        #endregion

        #region Constructors

        public DeliveryAddressInfoDB(string connectionString) : base(connectionString)
        {
            this.deliveryAddresses = new Collection<DeliveryAddress>();
            ReadDataFromTable(sqlQuery);
        }

        public DeliveryAddressInfoDB(string connectionString, string sqlQuery) : base(connectionString)
        {
            this.deliveryAddresses = new Collection<DeliveryAddress>();
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

        #region DataReader Methods

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

        private void FillDeliveryAddress(SqlDataReader reader,
            Collection<DeliveryAddress> deliveryAddresses)
        {
            DeliveryAddress deliveryAddress;
            while (reader.Read())
            {
                deliveryAddress = new DeliveryAddress();

                deliveryAddress.DeliveryAddressId = reader.GetInt32(0);
                deliveryAddress.RecipientName = reader.GetString(1).Trim();
                deliveryAddress.RecipientPhoneNumber = reader.GetString(2).Trim();
                deliveryAddress.StreetAddress = reader.GetString(3).Trim();
                if (!reader.IsDBNull(4))
                {
                    deliveryAddress.BuildingName = reader.GetString(4).Trim();
                }

                deliveryAddress.Suburb = reader.GetString(5).Trim();
                deliveryAddress.City = reader.GetString(6).Trim();
                deliveryAddress.PostalCode = reader.GetString(7).Trim();

                deliveryAddresses.Add(deliveryAddress);
            }
        }

        private DeliveryAddress FillDeliveryAddress(SqlDataReader reader)
        {
            DeliveryAddress deliveryAddress;
            while (reader.Read())
            {
                deliveryAddress = new DeliveryAddress();

                deliveryAddress.DeliveryAddressId = reader.GetInt32(0);
                deliveryAddress.RecipientName = reader.GetString(1).Trim();
                deliveryAddress.RecipientPhoneNumber = reader.GetString(2).Trim();
                deliveryAddress.StreetAddress = reader.GetString(3).Trim();
                if (!reader.IsDBNull(4))
                {
                    deliveryAddress.BuildingName = reader.GetString(4).Trim();
                }

                deliveryAddress.Suburb = reader.GetString(5).Trim();
                deliveryAddress.City = reader.GetString(6).Trim();
                deliveryAddress.Province = reader.GetString(7).Trim();
                deliveryAddress.PostalCode = reader.GetString(8).Trim();

                return deliveryAddress;
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
                    FillDeliveryAddress(reader, deliveryAddresses);
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
                    deliveryAddress = FillDeliveryAddress(reader);
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

        public string GetValueString(DeliveryAddress tempDeliveryAddress)
        {
            if (tempDeliveryAddress.BuildingName.Equals(""))
            {
                string aStr = " ' " + tempDeliveryAddress.RecipientName + " ' ," +
                              " ' " + tempDeliveryAddress.RecipientPhoneNumber + " ' ," +
                              " ' " + tempDeliveryAddress.StreetAddress + " ' ," +
                              " ' " + tempDeliveryAddress.Suburb + " ' ," +
                              " ' " + tempDeliveryAddress.City + " ' ," +
                              " ' " + tempDeliveryAddress.Province + " ' ," +
                              " ' " + tempDeliveryAddress.PostalCode + " ' ";
                return aStr;
            }
            else
            {
                string aStr = " ' " + tempDeliveryAddress.RecipientName + " ' ," +
                              " ' " + tempDeliveryAddress.RecipientPhoneNumber + " ' ," +
                              " ' " + tempDeliveryAddress.StreetAddress + " ' ," +
                              " ' " + tempDeliveryAddress.BuildingName + " ' ," +
                              " ' " + tempDeliveryAddress.Suburb + " ' ," +
                              " ' " + tempDeliveryAddress.City + " ' ," +
                              " ' " + tempDeliveryAddress.Province + " ' ," +
                              " ' " + tempDeliveryAddress.PostalCode + " ' ";
                return aStr;
            }
        }

        public bool DatabaseAdd(DeliveryAddress tempDeliveryAddress)
        {
            if (tempDeliveryAddress.BuildingName.Equals(""))
            {
                string strSQL = "";
                strSQL = "INSERT into " +
                         "DeliveryAddress([Recipient Name], [Recipient Phone Number], [Street Address], [Suburb], [City], [Province], [Postal Code])"
                         + "VALUES(" + GetValueString(tempDeliveryAddress) + ")";
                SqlCommand sqlCommand = new SqlCommand(strSQL, mainConnection);
                return UpdateDataSource(sqlCommand);
            }
            else
            {
                string strSQL = "";
                strSQL = "INSERT into " +
                         "DeliveryAddress([Recipient Name], [Recipient Phone Number], [Street Address], [Building Name], [Suburb], [City], [Province], [Postal Code])"
                         + "VALUES(" + GetValueString(tempDeliveryAddress) + ")";
                SqlCommand sqlCommand = new SqlCommand(strSQL, mainConnection);
                return UpdateDataSource(sqlCommand);
            }
        }

        public bool DatabaseEdit(DeliveryAddress tempDeliveryAddress)
        {
            if (!tempDeliveryAddress.BuildingName.Equals(""))
            {
                string sqlString = "Update DeliveryAddress Set [Recipient Name] = '" +
                                   tempDeliveryAddress.RecipientName + "'," +
                                   "[Recipient Phone Number] = '" + tempDeliveryAddress.RecipientPhoneNumber + "'," +
                                   "[Street Address] = '" + tempDeliveryAddress.StreetAddress + "'," +
                                   "[Suburb] = '" + tempDeliveryAddress.Suburb + "'," +
                                   "[Building Name] = '" + tempDeliveryAddress.BuildingName + "'," +
                                   "[City] = '" + tempDeliveryAddress.City + "'," +
                                   "[Province] = '" + tempDeliveryAddress.Province + "'," +
                                   "[Postal Code] = '" + tempDeliveryAddress.PostalCode + "'" +
                                   "WHERE ([Delivery Address Id] = '" + tempDeliveryAddress.DeliveryAddressId + "')";
                SqlCommand sqlCommand = new SqlCommand(sqlString, mainConnection);
                return UpdateDataSource(sqlCommand);
            }
            else
            {
                string sqlString = "Update DeliveryAddress Set [Recipient Name] = '" +
                                   tempDeliveryAddress.RecipientName + "'," +
                                   "[Recipient Phone Number] = '" + tempDeliveryAddress.RecipientPhoneNumber + "'," +
                                   "[Street Address] = '" + tempDeliveryAddress.StreetAddress + "'," +
                                   "[Suburb] = '" + tempDeliveryAddress.Suburb + "'," +
                                   "[City] = '" + tempDeliveryAddress.City + "'," +
                                   "[Province] = '" + tempDeliveryAddress.Province + "'," +
                                   "[Postal Code] = '" + tempDeliveryAddress.PostalCode + "'" +
                                   "WHERE ([Delivery Address Id] = '" + tempDeliveryAddress.DeliveryAddressId + "')";
                SqlCommand sqlCommand = new SqlCommand(sqlString, mainConnection);
                return UpdateDataSource(sqlCommand);
            }
        }

        #endregion
    }
}