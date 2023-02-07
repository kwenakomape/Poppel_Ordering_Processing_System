using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;

// ReSharper disable All

namespace Poppel_Order_Processing_System.PresentationLayer
{
    public partial class AddModifyCustomerForm : Form
    {
        #region Constructors

        public AddModifyCustomerForm(CustomerController customerController)
        {
            InitializeComponent();
            this.customerController = customerController;
            this.numbOfCust = customerController.AllCustomers.Count;
            this.counterPrevious = numbOfCust;
            this.counterForward = 0;
            this.customerCreditTextBox.Text = Customer.customerCreditLimit.ToString();
        }

        #endregion

        #region Fields

        private AddModifyDeliveryAddress addModifyDeliveryAddress;
        private CustomerController customerController;
        private Customer currentCustomer;
        private Customer editCustomer;
        public static FormState myState;
        bool endFileForward = false;
        bool endFileBackward = false;
        private int numbOfCust;
        private int counterPrevious;
        private int counterForward;
        private bool saveButtonClicked;
        private Collection<Order> orders;

        public enum FormState
        {
            Add = 0,
            Edit = 1,
        }

        #endregion

        #region Property Methods

        public Collection<Order> Orders
        {
            get => orders;
            set => orders = value;
        }

        public Customer EditCustomer
        {
            get => editCustomer;
            set => editCustomer = value;
        }

        #endregion

        #region Methods

        public void FormatForm(FormState stateValue)
        {
            switch (stateValue)
            {
                case FormState.Add:
                    myState = stateValue;
                    creditStatusComboBox.Text = "Released";
                    this.Text = "Customer Maintenance (Add New)";
                    creditStatusComboBox.Enabled = false;
                    customerCreditTextBox.ReadOnly = true;
                    customerCreditTextBox.Text = Customer.customerCreditLimit.ToString();

                    break;
                default:
                    myState = stateValue;
                    this.Text = "Customer Maintenance (Edit Mode)";
                    customerCreditTextBox.ReadOnly = false;
                    creditStatusComboBox.Enabled = true;
                    break;
            }
        }

        private void CreateAddModifyDeliveryAddressForm()
        {
            this.addModifyDeliveryAddress = new AddModifyDeliveryAddress();
            this.addModifyDeliveryAddress.FormatForm(AddModifyDeliveryAddress.FormState.Add);
            this.addModifyDeliveryAddress.ShowDialog();
            if (AddModifyDeliveryAddress.saveButtonClicked)
            {
                EnableAddressButton(false);
            }
        }

        private void CreateAddModifyDeliveryAddressForm(Customer customer)
        {
            this.addModifyDeliveryAddress = new AddModifyDeliveryAddress();
            this.addModifyDeliveryAddress.CustomerController = customerController;
            this.addModifyDeliveryAddress.EditCustomer = customer;
            this.addModifyDeliveryAddress.FormatForm(AddModifyDeliveryAddress.FormState.Edit);
            this.addModifyDeliveryAddress.PopulateDeliveryAddressForm(customer);
            this.addModifyDeliveryAddress.ShowDialog();
        }

        public void PopulateCustomerForm(Customer customer)
        {
            if (customer != null)
            {
                this.currentCustomer = customer;
                firstNameTextBox.Text = customer.FirstName;
                lastNameTextBox.Text = customer.LastName;
                phoneNumberTextBox.Text = customer.PhoneNumber;
                emailAddressTextBox.Text = customer.EmailAddress;
                customerCreditTextBox.Text =
                    string.Format("{0:0.00}", Convert.ToDecimal(customer.CustomerCredit.ToString()));
                creditStatusComboBox.Text = customer.CreditStatus;
            }
            else
            {
                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
                phoneNumberTextBox.Text = "";
                emailAddressTextBox.Text = "";
                customerCreditTextBox.Text =
                    string.Format("{0:0.00}", Convert.ToDecimal("0"));
                creditStatusComboBox.SelectedIndex = -1;
            }
        }

        public bool IsValid(string emailaddress)
        {
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z");
            Match match = regex.Match(emailaddress);
            if (match.Success)
                return true;
            else
                return false;
        }

        public Customer PopulateCustomer()
        {
            Customer customer = new Customer();
            if (!firstNameTextBox.Text.Trim().Equals("") &&
                !lastNameTextBox.Text.Trim().Equals("") &&
                !phoneNumberTextBox.Text.Trim().Equals("") &&
                !emailAddressTextBox.Text.Trim().Equals("") &&
                !customerCreditTextBox.Text.Trim().Equals("") &&
                !creditStatusComboBox.Text.Trim().Equals("")
            )
            {
                customer.FirstName = firstNameTextBox.Text.Trim();
                customer.LastName = lastNameTextBox.Text.Trim();
                customer.CreditStatus = creditStatusComboBox.Text.Trim();
                try
                {
                    if (IsValid(emailAddressTextBox.Text.Trim()) &&
                        phoneNumberTextBox.Text.Trim().Length == 10 &&
                        Regex.IsMatch(phoneNumberTextBox.Text.Trim(), @"^\d+$"))
                    {
                        foreach (var cust in customerController.AllCustomers)
                        {
                            if (cust.PhoneNumber.Equals(phoneNumberTextBox.Text.Trim()))
                            {
                                MessageBox.Show(this,
                                    "This Phone Number Has Already Been\nRegistered With, By Another Customer",
                                    "Phone Number Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return null;
                            }

                            if (cust.EmailAddress.Equals(emailAddressTextBox.Text.Trim()))
                            {
                                MessageBox.Show(this,
                                    "This Email Address Has Already Been\nRegistered With, By Another Customer",
                                    "Email Address Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return null;
                            }
                        }

                        customer.PhoneNumber = phoneNumberTextBox.Text.Trim();
                        customer.EmailAddress = emailAddressTextBox.Text.Trim();
                    }
                    else
                    {
                        if (!IsValid(emailAddressTextBox.Text.Trim()))
                        {
                            throw new InvalidDataException("Invalid Email Address");
                        }

                        throw new InvalidDataException("Invalid Phone Number");
                    }

                    customer.CustomerCredit = decimal.Round(Convert.ToDecimal(customerCreditTextBox.Text.Trim()), 2);
                }
                catch (FormatException)
                {
                    MessageBox.Show(this, "Invalid Customer Credit Entered\nExpected Input: Decimal Number",
                        "Invalid Customer Credit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                catch (InvalidDataException e)
                {
                    MessageBox.Show(this, e.Message + " Entered",
                        e.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                return customer;
            }

            MessageBox.Show(this,
                // ReSharper disable once LocalizableElement
                "Some Fields Are Missing,\nAll The Fields Are Required",
                "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        public Customer PopulateCustomer(Customer aCustomer)
        {
            Customer customer = aCustomer;
            if (!firstNameTextBox.Text.Trim().Equals("") &&
                !lastNameTextBox.Text.Trim().Equals("") &&
                !phoneNumberTextBox.Text.Trim().Equals("") &&
                !emailAddressTextBox.Text.Trim().Equals("") &&
                !customerCreditTextBox.Text.Trim().Equals("") &&
                !creditStatusComboBox.Text.Trim().Equals("")
            )
            {
                customer.FirstName = firstNameTextBox.Text.Trim();
                customer.LastName = lastNameTextBox.Text.Trim();
                customer.CreditStatus = creditStatusComboBox.Text.Trim();
                try
                {
                    if (IsValid(emailAddressTextBox.Text.Trim()) &&
                        phoneNumberTextBox.Text.Trim().Length == 10 &&
                        Regex.IsMatch(phoneNumberTextBox.Text.Trim(), @"^\d+$"))
                    {
                        foreach (var cust in customerController.AllCustomers)
                        {
                            if (cust.PhoneNumber.Equals(phoneNumberTextBox.Text.Trim()) &&
                                cust.CustomerId != customer.CustomerId)
                            {
                                MessageBox.Show(this,
                                    "This Phone Number Has Already Been\nRegistered With, By Another Customer",
                                    "Phone Number Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return null;
                            }

                            if (cust.EmailAddress.Equals(emailAddressTextBox.Text.Trim()) &&
                                cust.CustomerId != customer.CustomerId)
                            {
                                MessageBox.Show(this,
                                    "This Email Address Has Already Been\nRegistered With, By Another Customer",
                                    "Email Address Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return null;
                            }
                        }

                        customer.PhoneNumber = phoneNumberTextBox.Text.Trim();
                        customer.EmailAddress = emailAddressTextBox.Text.Trim();
                    }
                    else
                    {
                        if (!IsValid(emailAddressTextBox.Text.Trim()))
                        {
                            throw new InvalidDataException("Invalid Email Address");
                        }

                        throw new InvalidDataException("Invalid Phone Number");
                    }

                    customer.CustomerCredit = decimal.Round(Convert.ToDecimal(customerCreditTextBox.Text.Trim()), 2);
                }
                catch (FormatException)
                {
                    MessageBox.Show(this, "Invalid Customer Credit Entered\nExpected Input: Decimal Number",
                        "Invalid Customer Credit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                catch (InvalidDataException e)
                {
                    MessageBox.Show(this, e.Message + " Entered",
                        e.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                return customer;
            }

            MessageBox.Show(this,
                // ReSharper disable once LocalizableElement
                "Some Fields Are Missing,\nAll The Fields Are Required",
                "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        private void EnableAddressButton(bool enable)
        {
            customerDeliveryAddressButton.Enabled = enable;
        }

        #endregion

        #region Events

        private void closeCustomerFormButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void customerDeliveryAddressButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Add)
            {
                CreateAddModifyDeliveryAddressForm();
            }
            else
            {
                CreateAddModifyDeliveryAddressForm(EditCustomer);
            }
        }


        private void saveCustomerButton_Click(object sender, EventArgs e)
        {
            if (EditCustomer == null) myState = FormState.Add;
            if (myState == FormState.Add)
            {
                Customer customer = PopulateCustomer();
                if (customer != null)
                {
                    if (addModifyDeliveryAddress != null)
                    {
                        customer.DeliveryAddress = addModifyDeliveryAddress.DeliveryAddress;
                    }

                    bool success = customerController.Add(customer);
                    if (success)
                    {
                        string sqlQuery = "SELECT TOP 1 * FROM Customer ORDER BY [Customer_Id] DESC";

                        customerController.AllCustomers.Add(new CustomerController(sqlQuery).Customer);
                        saveButtonClicked = true;
                        this.Close();
                    }
                }
            }
            else
            {
                Customer customer = PopulateCustomer(EditCustomer);
                if (customer != null)
                {
                    bool success = customerController.Edit(customer);
                    if (success)
                    {
                        this.Close();
                        saveButtonClicked = true;
                    }
                }
            }
        }

        private void AddModifyCustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (myState == FormState.Add)
            {
                if (addModifyDeliveryAddress != null && AddModifyDeliveryAddress.saveButtonClicked &&
                    !saveButtonClicked)
                {
                    DeliveryAddress deliveryAddress = addModifyDeliveryAddress.DeliveryAddress;
                    string sqlQuery = "DELETE FROM DeliveryAddress WHERE [Delivery Address Id] = " +
                                      deliveryAddress.DeliveryAddressId.ToString();
                    new DeliveryAddressController(sqlQuery);
                    addModifyDeliveryAddress.DeliveryAddressController.AllDeliveryAddresses.Remove(deliveryAddress);
                }

                EnableAddressButton(true);
                AddModifyDeliveryAddress.saveButtonClicked = false;
                saveButtonClicked = false;
            }
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit && EditCustomer != null)
            {
                DialogResult reply = MessageBox.Show(this, "Are You Sure You Want To Delete\n" +
                                                           "The Customer With Customer Id = \"" +
                                                           EditCustomer.CustomerId +
                                                           "\" ?",
                    "Warning: Delete Customer ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (reply == DialogResult.Yes)
                {
                    string sqlQueryCustomer = "DELETE FROM Customer WHERE [Customer_Id] = " +
                                              EditCustomer.CustomerId.ToString();
                    new CustomerController(sqlQueryCustomer);
                    customerController.AllCustomers.Remove(EditCustomer);
                    if (EditCustomer.DeliveryAddress != null)
                    {
                        string sqlQueryDeliveryAddress = "DELETE FROM DeliveryAddress WHERE [Delivery Address Id] = " +
                                                         EditCustomer.DeliveryAddress.DeliveryAddressId.ToString();
                        new DeliveryAddressController(sqlQueryDeliveryAddress);
                        new DeliveryAddressController().AllDeliveryAddresses.Remove(EditCustomer.DeliveryAddress);
                    }

                    string sqlQueryOrder = "DELETE FROM OrderTable WHERE [Customer_Id] = " +
                                           EditCustomer.CustomerId.ToString();
                    new OrderController(sqlQueryOrder);
                    bool deletedFromDatabase = false;
                    foreach (Order order in Orders.ToArray())
                    {
                        if (order.CustomerId == EditCustomer.CustomerId)
                        {
                            if (!deletedFromDatabase)
                            {
                                string sqlQueryOrderItems = "DELETE FROM OrderItem WHERE [Order_Id] = " +
                                                            order.OrderId.ToString();
                                new OrderItemController(sqlQueryOrderItems);
                                deletedFromDatabase = true;
                            }

                            orders.Remove(order);
                        }
                    }
                }

                EditCustomer = null;
                PopulateCustomerForm(EditCustomer);
                myState = FormState.Add;
                FormatForm(myState);
            }
        }


        private void previousCustomerButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit)
            {
                if (customerController.AllCustomers.Count != 0)
                {
                    if (!endFileBackward && customerController.AllCustomers[0].CustomerId != currentCustomer.CustomerId)
                    {
                        if (customerController.AllCustomers.Count != 0)
                        {
                            EditCustomer = currentCustomer;
                            int currentCustomerId = currentCustomer.CustomerId;
                            int customerId = currentCustomerId - 1;
                            currentCustomer = customerController.FindByID(Convert.ToString(customerId));
                            EditCustomer = currentCustomer;
                            while (counterPrevious > 0 && currentCustomer == null)
                            {
                                customerId--;
                                currentCustomer = customerController.FindByID(Convert.ToString(customerId));
                                EditCustomer = currentCustomer;
                            }

                            if (currentCustomer != null)
                            {
                                PopulateCustomerForm(currentCustomer);
                                endFileForward = false;
                                if (counterForward >= customerController.AllCustomers.Count - 1)
                                {
                                    counterForward--;
                                }

                                if (counterPrevious <= 1)
                                {
                                    endFileBackward = true;
                                }
                            }

                            counterPrevious--;
                        }
                        else
                        {
                            MessageBox.Show(this,
                                // ReSharper disable once LocalizableElement
                                "No Customers To Show",
                                "No Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this,
                            // ReSharper disable once LocalizableElement
                            "End Of File Reached...",
                            "End Of File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this,
                        // ReSharper disable once LocalizableElement
                        "No Customers To Show",
                        "No Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                FormatForm(FormState.Edit);
                if (!endFileBackward)
                {
                    if (customerController.AllCustomers.Count != 0)
                    {
                        currentCustomer = customerController.AllCustomers[customerController.AllCustomers.Count - 1];
                        EditCustomer = currentCustomer;
                        if (currentCustomer != null)
                        {
                            PopulateCustomerForm(currentCustomer);
                            endFileForward = false;
                            if (counterForward >= customerController.AllCustomers.Count - 1)
                            {
                                counterForward--;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this,
                            // ReSharper disable once LocalizableElement
                            "No Customers To Show",
                            "No Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this,
                        // ReSharper disable once LocalizableElement
                        "End Of File Reached...",
                        "End Of File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void nextCustomerButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit)
            {
                if (customerController.AllCustomers.Count != 0)
                {
                    if (!endFileForward &&
                        customerController.AllCustomers[customerController.AllCustomers.Count - 1].CustomerId !=
                        currentCustomer.CustomerId)
                    {
                        if (customerController.AllCustomers.Count != 0)
                        {
                            EditCustomer = currentCustomer;
                            int currentCustomerId = currentCustomer.CustomerId;
                            int customerId = currentCustomerId + 1;
                            currentCustomer = customerController.FindByID(Convert.ToString(customerId));
                            EditCustomer = currentCustomer;
                            while (counterForward < customerController.AllCustomers.Count && currentCustomer == null)
                            {
                                customerId++;
                                currentCustomer = customerController.FindByID(Convert.ToString(customerId));
                                EditCustomer = currentCustomer;
                            }

                            if (currentCustomer != null)
                            {
                                PopulateCustomerForm(currentCustomer);
                                endFileBackward = false;
                                if (counterPrevious <= 1)
                                {
                                    counterPrevious++;
                                }

                                if (counterForward >= customerController.AllCustomers.Count)
                                {
                                    endFileForward = true;
                                }
                            }

                            counterForward++;
                        }
                        else
                        {
                            MessageBox.Show(this,
                                // ReSharper disable once LocalizableElement
                                "No Customers To Show",
                                "No Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this,
                            // ReSharper disable once LocalizableElement
                            "End Of File Reached...",
                            "End Of File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this,
                        // ReSharper disable once LocalizableElement
                        "No Customers To Show",
                        "No Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                FormatForm(FormState.Edit);
                if (!endFileForward)
                {
                    if (customerController.AllCustomers.Count != 0)
                    {
                        currentCustomer = customerController.AllCustomers[0];
                        EditCustomer = currentCustomer;
                        if (currentCustomer != null)
                        {
                            PopulateCustomerForm(currentCustomer);
                            endFileBackward = false;
                            if (counterPrevious <= customerController.AllCustomers.Count - 1)
                            {
                                counterPrevious++;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this,
                            // ReSharper disable once LocalizableElement
                            "No Customers To Show",
                            "No Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this,
                        // ReSharper disable once LocalizableElement
                        "End Of File Reached...",
                        "End Of File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion
    }
}