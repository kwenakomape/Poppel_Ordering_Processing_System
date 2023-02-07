using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

// ReSharper disable All

namespace Poppel_Order_Processing_System.DatabaseLayer
{
    public class Database
    {
        #region Constructors

        public Database(string connectionString)
        {
            this.connectionString = connectionString;
            try
            {
                this.mainConnection = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error: Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Methods

        protected bool UpdateDataSource(SqlCommand currentCommand)
        {
            bool success;
            try
            {
                mainConnection.Open();
                currentCommand.CommandType = CommandType.Text;
                currentCommand.ExecuteNonQuery();
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " => " + e.StackTrace, "Error: Database Update", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                success = false;
            }
            finally
            {
                mainConnection.Close();
            }

            return success;
        }

        #endregion

        #region Fields

        private string connectionString;
        protected SqlConnection mainConnection;

        #endregion
    }
}