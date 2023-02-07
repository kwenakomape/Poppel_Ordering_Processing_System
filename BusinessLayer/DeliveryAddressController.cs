using System.Collections.ObjectModel;
using Poppel_Order_Processing_System.DatabaseLayer;
using Poppel_Order_Processing_System.Properties;

// ReSharper disable All

namespace Poppel_Order_Processing_System.BusinessLayer
{
    public class DeliveryAddressController
    {
        #region Property Methods

        public Collection<DeliveryAddress> AllDeliveryAddresses => deliveryAddresses;

        #endregion

        #region Fields

        private DeliveryAddressInfoDB deliveryAddressInfoDb;
        private Collection<DeliveryAddress> deliveryAddresses;
        private DeliveryAddress deliveryAddress;
        public DeliveryAddress DeliveryAddress => deliveryAddress;

        #endregion

        #region Constructors

        public DeliveryAddressController()
        {
            this.deliveryAddressInfoDb =
                new DeliveryAddressInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString);
            this.deliveryAddresses = deliveryAddressInfoDb.AllDeliveryAddresses;
        }

        public DeliveryAddressController(string sqlQuery)
        {
            this.deliveryAddressInfoDb =
                new DeliveryAddressInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString, sqlQuery);
            this.deliveryAddress = deliveryAddressInfoDb.DeliveryAddress;
        }

        #endregion

        #region Methods

        public bool Add(DeliveryAddress aDeliveryAddress)
        {
            return deliveryAddressInfoDb.DatabaseAdd(aDeliveryAddress);
        }

        public bool Edit(DeliveryAddress deliveryAddress)
        {
            return deliveryAddressInfoDb.DatabaseEdit(deliveryAddress);
        }

        #endregion
    }
}