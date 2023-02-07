// ReSharper disable All

namespace Poppel_Order_Processing_System.BusinessLayer
{
    public class Customer
    {
        #region Fields

        private int customerId;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string emailAddress;
        private DeliveryAddress deliveryAddress;
        private decimal customerCredit;
        private string creditStatus;
        public static readonly decimal customerCreditLimit = 2000.00m;

        #endregion

        #region Constructors

        public Customer()
        {
            this.customerId = 0;
            this.firstName = "";
            this.lastName = "";
            this.phoneNumber = "";
            this.emailAddress = "";
            this.deliveryAddress = null;
            this.customerCredit = customerCreditLimit;
            this.creditStatus = "Released";
        }

        public Customer(int customerId, string firstName, string lastName, string phoneNumber, string emailAddress,
            DeliveryAddress deliveryAddress, decimal customerCredit, string creditStatus)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.emailAddress = emailAddress;
            this.deliveryAddress = deliveryAddress;
            this.customerCredit = customerCredit;
            this.creditStatus = creditStatus;
        }

        #endregion

        #region Property Methods

        public int CustomerId
        {
            get => customerId;
            set => customerId = value;
        }

        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set => phoneNumber = value;
        }

        public string EmailAddress
        {
            get => emailAddress;
            set => emailAddress = value;
        }

        public DeliveryAddress DeliveryAddress
        {
            get => deliveryAddress;
            set => deliveryAddress = value;
        }

        public decimal CustomerCredit
        {
            get => customerCredit;
            set => customerCredit = value;
        }

        public string CreditStatus
        {
            get => creditStatus;
            set => creditStatus = value;
        }

        #endregion
    }
}