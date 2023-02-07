// ReSharper disable All

namespace Poppel_Order_Processing_System.BusinessLayer
{
    public class DeliveryAddress
    {
        #region Methods

        public override string ToString()
        {
            string deliveryAddressString = recipientName + ", " +
                                           recipientPhoneNumber + ", ";
            if (!buildingName.Equals(""))
            {
                deliveryAddressString += buildingName + ", ";
            }

            deliveryAddressString += buildingName + ", " +
                                     streetAddress + ", " +
                                     suburb + ", " +
                                     city + ", " +
                                     province + ", " +
                                     postalCode;
            return deliveryAddressString;
        }

        #endregion

        #region Fields

        private int deliveryAddressId;
        private string recipientName;
        private string recipientPhoneNumber;
        private string streetAddress;
        private string buildingName;
        private string suburb;
        private string city;
        private string province;
        private string postalCode;

        #endregion

        #region Constructors

        public DeliveryAddress()
        {
            this.deliveryAddressId = -1;
            this.recipientName = "";
            this.recipientPhoneNumber = "";
            this.streetAddress = "";
            this.buildingName = "";
            this.suburb = "";
            this.city = "";
            this.province = "";
            this.postalCode = "";
        }

        public DeliveryAddress(int deliveryAddressId, string recipientName, string recipientPhoneNumber,
            string streetAddress, string buildingName, string suburb, string city, string province, string postalCode)
        {
            this.deliveryAddressId = deliveryAddressId;
            this.recipientName = recipientName;
            this.recipientPhoneNumber = recipientPhoneNumber;
            this.streetAddress = streetAddress;
            this.buildingName = buildingName;
            this.suburb = suburb;
            this.city = city;
            this.province = province;
            this.postalCode = postalCode;
        }

        #endregion

        #region Property Methods

        public int DeliveryAddressId
        {
            get => deliveryAddressId;
            set => deliveryAddressId = value;
        }

        public string RecipientName
        {
            get => recipientName;
            set => recipientName = value;
        }

        public string RecipientPhoneNumber
        {
            get => recipientPhoneNumber;
            set => recipientPhoneNumber = value;
        }

        public string StreetAddress
        {
            get => streetAddress;
            set => streetAddress = value;
        }

        public string BuildingName
        {
            get => buildingName;
            set => buildingName = value;
        }

        public string Suburb
        {
            get => suburb;
            set => suburb = value;
        }

        public string City
        {
            get => city;
            set => city = value;
        }

        public string Province
        {
            get => province;
            set => province = value;
        }

        public string PostalCode
        {
            get => postalCode;
            set => postalCode = value;
        }

        #endregion
    }
}