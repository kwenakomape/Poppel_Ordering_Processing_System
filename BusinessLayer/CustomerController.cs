using System.Collections.ObjectModel;
using Poppel_Order_Processing_System.DatabaseLayer;
using Poppel_Order_Processing_System.Properties;

// ReSharper disable All

namespace Poppel_Order_Processing_System.BusinessLayer
{
    public class CustomerController
    {
        #region Fields

        private CustomerInfoDB customerInfoDb;
        private Collection<Customer> customers;
        private Customer customer;

        #endregion

        #region Constructors

        public CustomerController()
        {
            this.customerInfoDb = new CustomerInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString);
            this.customers = customerInfoDb.AllCustomers;
        }

        public CustomerController(string sqlQuery)
        {
            this.customerInfoDb =
                new CustomerInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString, sqlQuery);
            this.customer = customerInfoDb.Customer;
        }

        #endregion

        #region Property Methods

        public Customer Customer => customer;

        public Collection<Customer> AllCustomers
        {
            get => customers;
        }

        #endregion

        #region Methods

        public Customer FindByID(string id)
        {
            if (customers.Count > 0)
            {
                int position = 0;
                bool found = id.Equals(customers[position].CustomerId.ToString());
                if (!found)
                {
                    position++;
                }

                while (!found && position < customers.Count)
                {
                    found = id.Equals(customers[position].CustomerId.ToString());
                    if (found)
                    {
                        break;
                    }

                    position++;
                }

                if (found)
                {
                    return customers[position];
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        public bool Add(Customer aCustomer)
        {
            return customerInfoDb.DatabaseAdd(aCustomer);
        }

        public bool Edit(Customer aCustomer)
        {
            return customerInfoDb.DatabaseEdit(aCustomer);
        }

        #endregion
    }
}