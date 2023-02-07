using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;
using Poppel_Order_Processing_System.Properties;

// ReSharper disable All

namespace Poppel_Order_Processing_System.PresentationLayer
{
    public partial class AddModifyCustomerFile : Form
    {
        #region Constructors

        public AddModifyCustomerFile(CustomerController customerController)
        {
            InitializeComponent();
            this.Load += AddModifyCustomerFile_Load;
            this.customerController = customerController;
        }

        #endregion

        #region Fields

        private AddModifyCustomerForm addModifyCustomerForm;

        public bool addModifyCustomerFileClosed;
        private CustomerController customerController;
        private Collection<Customer> customers;
        private PoppelOrderProcessingSystem poppelOrderProcessingSystem;
        public static FormState myState;
        private Customer selectedCustomer;
        private Collection<Order> orders;

        public enum FormState
        {
            Edit = 0,
            Select = 1
        }

        #endregion

        #region Property Methods

        public Collection<Order> Orders
        {
            get => orders;
            set => orders = value;
        }

        public Customer SelectedCustomer => selectedCustomer;

        public PoppelOrderProcessingSystem PoppelOrderProcessingSystem => poppelOrderProcessingSystem;

        #endregion

        #region Methods

        public void FormatForm(FormState stateValue)
        {
            switch (stateValue)
            {
                case FormState.Edit:
                    myState = stateValue;
                    this.Text = "Customer File";
                    break;
                default:
                    myState = stateValue;
                    this.Text = "Customer File (Select Mode)";
                    modifyCustomerButton.Image = new Bitmap(Resources.Select);
                    modifyCustomerButton.Text = "Select";
                    break;
            }
        }

        private void CreateAddModifyCustomerForm()
        {
            this.addModifyCustomerForm = new AddModifyCustomerForm(customerController);
            this.addModifyCustomerForm.Orders = Orders;
            this.addModifyCustomerForm.FormatForm(AddModifyCustomerForm.FormState.Add);
            this.Hide();
            this.addModifyCustomerForm.ShowDialog();
            this.Show();
            Search();
        }

        public void CreateAddModifyCustomerForm(Customer customer)
        {
            this.addModifyCustomerForm = new AddModifyCustomerForm(customerController);
            this.addModifyCustomerForm.Orders = Orders;
            this.addModifyCustomerForm.EditCustomer = customer;
            this.addModifyCustomerForm.FormatForm(AddModifyCustomerForm.FormState.Edit);
            this.addModifyCustomerForm.PopulateCustomerForm(customer);
            if (poppelOrderProcessingSystem != null)
            {
                this.Hide();
            }

            this.addModifyCustomerForm.ShowDialog();
            if (poppelOrderProcessingSystem != null)
            {
                Search();
                this.Show();
            }
        }


        public void setUpCustomerListView(string filter)
        {
            ListViewItem customerDetails;
            customers = customerController.AllCustomers;
            customerListView.Clear();
            customerListView.Columns.Insert(0, "Customer Id", 78, HorizontalAlignment.Left);
            customerListView.Columns.Insert(1, "First Name", 170, HorizontalAlignment.Left);
            customerListView.Columns.Insert(2, "Last Name", 100, HorizontalAlignment.Left);
            customerListView.Columns.Insert(3, "Phone Number", 96, HorizontalAlignment.Left);
            customerListView.Columns.Insert(4, "Email Address", 250, HorizontalAlignment.Left);
            customerListView.Columns.Insert(5, "Customer Credit", 100, HorizontalAlignment.Left);
            customerListView.Columns.Insert(6, "Credit Status", 81, HorizontalAlignment.Left);
            customerListView.Columns.Insert(7, "Delivery Address", 105, HorizontalAlignment.Left);

            if (!filter.Equals(""))
            {
                foreach (Customer customer in customers)
                {
                    if (customer.CreditStatus.Equals(filter))
                    {
                        customerDetails = new ListViewItem();
                        customerDetails.Text = customer.CustomerId.ToString();
                        customerDetails.SubItems.Add(customer.FirstName);
                        customerDetails.SubItems.Add(customer.LastName);
                        customerDetails.SubItems.Add(customer.PhoneNumber);
                        customerDetails.SubItems.Add(customer.EmailAddress);
                        customerDetails.SubItems.Add("R" + string.Format("{0:0.00}", customer.CustomerCredit));
                        customerDetails.SubItems.Add(customer.CreditStatus);
                        if (customer.DeliveryAddress == null)
                        {
                            customerDetails.SubItems.Add("No");
                        }
                        else
                        {
                            customerDetails.SubItems.Add("Yes");
                        }

                        customerListView.Items.Add(customerDetails);
                    }
                }
            }
            else
            {
                foreach (Customer cust in customers)
                {
                    customerDetails = new ListViewItem();
                    customerDetails.Text = cust.CustomerId.ToString();
                    customerDetails.SubItems.Add(cust.FirstName);
                    customerDetails.SubItems.Add(cust.LastName);
                    customerDetails.SubItems.Add(cust.PhoneNumber);
                    customerDetails.SubItems.Add(cust.EmailAddress);
                    customerDetails.SubItems.Add("R" + string.Format("{0:0.00}", cust.CustomerCredit));
                    customerDetails.SubItems.Add(cust.CreditStatus);
                    if (cust.DeliveryAddress == null)
                    {
                        customerDetails.SubItems.Add("No");
                    }
                    else
                    {
                        customerDetails.SubItems.Add("Yes");
                    }

                    customerListView.Items.Add(customerDetails);
                }
            }

            customerListView.Refresh();
            customerListView.GridLines = true;
        }

        public void setUpCustomerListView(string filter, string customerId)
        {
            ListViewItem customerDetails;
            customers = customerController.AllCustomers;
            customerListView.Clear();
            customerListView.Columns.Insert(0, "Customer Id", 78, HorizontalAlignment.Left);
            customerListView.Columns.Insert(1, "First Name", 170, HorizontalAlignment.Left);
            customerListView.Columns.Insert(2, "Last Name", 100, HorizontalAlignment.Left);
            customerListView.Columns.Insert(3, "Phone Number", 96, HorizontalAlignment.Left);
            customerListView.Columns.Insert(4, "Email Address", 250, HorizontalAlignment.Left);
            customerListView.Columns.Insert(5, "Customer Credit", 100, HorizontalAlignment.Left);
            customerListView.Columns.Insert(6, "Credit Status", 81, HorizontalAlignment.Left);
            customerListView.Columns.Insert(7, "Delivery Address", 105, HorizontalAlignment.Left);

            if (!filter.Equals("") && !customerId.Trim().Equals(""))
            {
                foreach (Customer customer in customers)
                {
                    if (customer.CreditStatus.Equals(filter) &&
                        customer.CustomerId.ToString().StartsWith(customerId.Trim()))
                    {
                        customerDetails = new ListViewItem();
                        customerDetails.Text = customer.CustomerId.ToString();
                        customerDetails.SubItems.Add(customer.FirstName);
                        customerDetails.SubItems.Add(customer.LastName);
                        customerDetails.SubItems.Add(customer.PhoneNumber);
                        customerDetails.SubItems.Add(customer.EmailAddress);
                        customerDetails.SubItems.Add("R" + string.Format("{0:0.00}", customer.CustomerCredit));
                        customerDetails.SubItems.Add(customer.CreditStatus);
                        if (customer.DeliveryAddress == null)
                        {
                            customerDetails.SubItems.Add("No");
                        }
                        else
                        {
                            customerDetails.SubItems.Add("Yes");
                        }

                        customerListView.Items.Add(customerDetails);
                    }
                }

                customerListView.Refresh();
                customerListView.GridLines = true;
            }
            else
            {
                foreach (Customer tempCustomer in customers)
                {
                    if (tempCustomer.CustomerId.ToString().StartsWith(customerId.Trim()))
                    {
                        customerDetails = new ListViewItem();
                        customerDetails.Text = tempCustomer.CustomerId.ToString();
                        customerDetails.SubItems.Add(tempCustomer.FirstName);
                        customerDetails.SubItems.Add(tempCustomer.LastName);
                        customerDetails.SubItems.Add(tempCustomer.PhoneNumber);
                        customerDetails.SubItems.Add(tempCustomer.EmailAddress);
                        customerDetails.SubItems.Add("R" + string.Format("{0:0.00}", tempCustomer.CustomerCredit));
                        customerDetails.SubItems.Add(tempCustomer.CreditStatus);
                        if (tempCustomer.DeliveryAddress == null)
                        {
                            customerDetails.SubItems.Add("No");
                        }
                        else
                        {
                            customerDetails.SubItems.Add("Yes");
                        }

                        customerListView.Items.Add(customerDetails);
                    }
                }

                customerListView.Refresh();
                customerListView.GridLines = true;
            }
        }

        private void Search()
        {
            if (!customerCreditComboBox.Text.Equals("") && !customerSearchTextBox.Text.Trim().Equals(""))
            {
                setUpCustomerListView(customerCreditComboBox.Text, customerSearchTextBox.Text);
            }
            else
            {
                if (customerCreditComboBox.Text.Equals("") && !customerSearchTextBox.Text.Trim().Equals(""))
                {
                    setUpCustomerListView(customerCreditComboBox.Text, customerSearchTextBox.Text);
                }
                else
                {
                    setUpCustomerListView(customerCreditComboBox.Text);
                }
            }
        }

        #endregion

        #region Events

        private void customerFileCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void newCustomerButton_Click(object sender, EventArgs e)
        {
            CreateAddModifyCustomerForm();
        }


        private void customerSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void AddModifyCustomerFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (myState == FormState.Edit)
            {
                addModifyCustomerFileClosed = true;
                if (PoppelOrderProcessingSystem != null)
                    ((PoppelOrderProcessingSystem) MdiParent).EnableButtons(true);
            }
        }

        private void AddModifyCustomerFile_Activated(object sender, EventArgs e)
        {
            Search();
        }

        private void AddModifyCustomerFile_Load(object sender, EventArgs e)
        {
            poppelOrderProcessingSystem = (PoppelOrderProcessingSystem) this.MdiParent;
            customerListView.View = View.Details;
            Search();
        }

        private void modifyCustomerButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit)
            {
                if (customerListView.FocusedItem != null && customerListView.SelectedItems.Count > 0)
                {
                    Customer customer = customerController.FindByID(customerListView.SelectedItems[0].Text);
                    CreateAddModifyCustomerForm(customer);
                }
            }
            else
            {
                if (customerListView.FocusedItem != null && customerListView.SelectedItems.Count > 0)
                {
                    selectedCustomer = customerController.FindByID(customerListView.SelectedItems[0].Text);
                    Close();
                }
            }
        }

        private void customerCreditComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void searchCustomerButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void modifyCustomerButton_MouseHover(object sender, EventArgs e)
        {
            if (customerListView.FocusedItem == null && customerListView.Items.Count > 0)
            {
                customerListView.Items[0].Selected = true;
                customerListView.Items[0].Focused = true;
                customerListView.Select();
            }
        }

        #endregion
    }
}