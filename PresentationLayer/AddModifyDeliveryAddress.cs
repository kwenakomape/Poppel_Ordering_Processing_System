using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;

// ReSharper disable All

namespace Poppel_Order_Processing_System.PresentationLayer
{
    public partial class AddModifyDeliveryAddress : Form
    {
        #region Constructors

        public AddModifyDeliveryAddress()
        {
            InitializeComponent();
            this.deliveryAddressController = new DeliveryAddressController();
        }

        #endregion

        #region Property Methods

        public Customer EditCustomer
        {
            get => editCustomer;
            set => editCustomer = value;
        }

        public CustomerController CustomerController
        {
            get => customerController;
            set => customerController = value;
        }

        #endregion

        #region Fields

        private DeliveryAddressController deliveryAddressController;
        private CustomerController customerController;
        private DeliveryAddress deliveryAddress;
        public static bool saveButtonClicked;
        public DeliveryAddressController DeliveryAddressController => deliveryAddressController;
        public DeliveryAddress DeliveryAddress => deliveryAddress;
        public static FormState myState;
        private Customer editCustomer;

        public enum FormState
        {
            Add = 0,
            Edit = 1,
        }

        #endregion

        #region Methods

        public DeliveryAddress Add()
        {
            if (myState == FormState.Add)
            {
                deliveryAddress = PopulateDeliveryAddress();
            }

            if (deliveryAddress != null)
            {
                bool success = deliveryAddressController.Add(deliveryAddress);
                if (success)
                {
                    string sqlQuery = "SELECT TOP 1 * FROM DeliveryAddress ORDER BY [Delivery Address Id] DESC";
                    deliveryAddress = new DeliveryAddressController(sqlQuery).DeliveryAddress;
                    deliveryAddressController.AllDeliveryAddresses.Add(deliveryAddress);
                    saveButtonClicked = true;
                    this.Close();
                    return deliveryAddress;
                }
            }

            return null;
        }

        public void FormatForm(FormState stateValue)
        {
            switch (stateValue)
            {
                case FormState.Add:
                    this.Text = "Delivery Address Maintenance (Add New)";
                    myState = stateValue;
                    break;
                default:
                    this.Text = "Delivery Address Maintenance (Edit Mode)";
                    myState = stateValue;
                    break;
            }
        }

        public void PopulateDeliveryAddressForm(Customer customer)
        {
            if (customer != null && customer.DeliveryAddress != null)
            {
                recipientNameTextBox.Text = customer.DeliveryAddress.RecipientName;
                recipientPhoneNumberTextBox.Text = customer.DeliveryAddress.RecipientPhoneNumber;
                streetAddressTextBox.Text = customer.DeliveryAddress.StreetAddress;
                buildingNameTextBox.Text = customer.DeliveryAddress.BuildingName;
                suburbTextBox.Text = customer.DeliveryAddress.Suburb;
                cityTextBox.Text = customer.DeliveryAddress.City;
                provinceComboBox.Text = customer.DeliveryAddress.Province;
                postalCodeTextBox.Text = customer.DeliveryAddress.PostalCode;
            }
            else
            {
                recipientNameTextBox.Text = "";
                recipientPhoneNumberTextBox.Text = "";
                streetAddressTextBox.Text = "";
                buildingNameTextBox.Text = "";
                suburbTextBox.Text = "";
                cityTextBox.Text = "";
                provinceComboBox.SelectedIndex = -1;
                postalCodeTextBox.Text = "";
            }
        }

        public DeliveryAddress PopulateDeliveryAddress()
        {
            if (deliveryAddress == null && myState == FormState.Add)
            {
                deliveryAddress = new DeliveryAddress();
            }
            else
            {
                if (myState == FormState.Edit && EditCustomer.DeliveryAddress != null)
                {
                    deliveryAddress = EditCustomer.DeliveryAddress;
                }
                else
                {
                    deliveryAddress = new DeliveryAddress();
                }
            }

            if (!recipientNameTextBox.Text.Trim().Equals("") &&
                !recipientPhoneNumberTextBox.Text.Trim().Equals("") &&
                !streetAddressTextBox.Text.Trim().Equals("") &&
                !suburbTextBox.Text.Trim().Equals("") &&
                !cityTextBox.Text.Trim().Equals("") &&
                !provinceComboBox.Text.Trim().Equals("") &&
                !postalCodeTextBox.Text.Trim().Equals(""))
            {
                try
                {
                    if (recipientPhoneNumberTextBox.Text.Trim().Length == 10 &&
                        Regex.IsMatch(recipientPhoneNumberTextBox.Text.Trim(), @"^\d+$") &&
                        postalCodeTextBox.Text.Trim().Length == 4 &&
                        Regex.IsMatch(postalCodeTextBox.Text.Trim(), @"^\d+$"))
                    {
                        deliveryAddress.RecipientName = recipientNameTextBox.Text.Trim();
                        deliveryAddress.RecipientPhoneNumber = recipientPhoneNumberTextBox.Text.Trim();
                        deliveryAddress.StreetAddress = streetAddressTextBox.Text.Trim();
                        deliveryAddress.BuildingName = buildingNameTextBox.Text.Trim();
                        deliveryAddress.Suburb = suburbTextBox.Text.Trim();
                        deliveryAddress.City = cityTextBox.Text.Trim();
                        deliveryAddress.Province = provinceComboBox.Text.Trim();
                        deliveryAddress.PostalCode = postalCodeTextBox.Text.Trim();
                        return deliveryAddress;
                    }

                    if (recipientPhoneNumberTextBox.Text.Trim().Length != 10 ||
                        !Regex.IsMatch(recipientPhoneNumberTextBox.Text.Trim(), @"^\d+$"))
                    {
                        throw new InvalidDataException("Invalid Recipient Phone Number");
                    }

                    throw new InvalidDataException("Invalid Postal Code");
                }
                catch (InvalidDataException e)
                {
                    MessageBox.Show(this, e.Message + " Entered",
                        e.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }

            MessageBox.Show(this,
                "Some Fields Are Missing,\nAll The Fields Are Required\nExcept The \"Building Name\" Field",
                "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        #endregion

        #region Events

        private void closeDeliveryAddressFormButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveDeliveryAddressButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Add)
            {
                deliveryAddress = Add();
            }
            else
            {
                deliveryAddress = PopulateDeliveryAddress();
                if (deliveryAddress != null && deliveryAddress.DeliveryAddressId != -1)
                {
                    bool success = deliveryAddressController.Edit(deliveryAddress);
                    if (success)
                    {
                        this.Close();
                    }
                }
                else
                {
                    if (deliveryAddress != null)
                    {
                        DeliveryAddress newDeliveryAddress = Add();
                        EditCustomer.DeliveryAddress = newDeliveryAddress;
                        bool success = customerController.Edit(EditCustomer);
                    }
                }
            }
        }

        private void deleteDeliveryAddressButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit && EditCustomer.DeliveryAddress != null)
            {
                DialogResult reply = MessageBox.Show(this, "Are You Sure You Want To Delete The Delivery Address\n" +
                                                           "Of The Customer With Customer Id = \"" +
                                                           EditCustomer.CustomerId +
                                                           "\" ?",
                    "Warning: Delete Delivery Address?", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (reply == DialogResult.Yes)
                {
                    string sqlQuery = "DELETE FROM DeliveryAddress WHERE [Delivery Address Id] = " +
                                      EditCustomer.DeliveryAddress.DeliveryAddressId.ToString();
                    new DeliveryAddressController(sqlQuery);
                    DeliveryAddressController.AllDeliveryAddresses.Remove(EditCustomer.DeliveryAddress);
                    EditCustomer.DeliveryAddress = null;
                    customerController.Edit(EditCustomer);
                    PopulateDeliveryAddressForm(EditCustomer);
                }
            }
        }

        #endregion
    }
}