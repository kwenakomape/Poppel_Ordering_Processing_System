using System.Collections.ObjectModel;
using Poppel_Order_Processing_System.DatabaseLayer;
using Poppel_Order_Processing_System.Properties;

// ReSharper disable All

namespace Poppel_Order_Processing_System.BusinessLayer
{
    public class OrderItemController
    {
        #region Fields

        private OrderItemInfoDB orderItemInfoDb;
        private Collection<OrderItem> orderItems;
        private OrderItem orderItem;

        #endregion

        #region Constructors

        public OrderItemController()
        {
            this.orderItemInfoDb = new OrderItemInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString);
            this.orderItems = orderItemInfoDb.AllOrderItems;
        }

        public OrderItemController(string sqlQuery)
        {
            this.orderItemInfoDb =
                new OrderItemInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString, sqlQuery);
            this.orderItem = orderItemInfoDb.OrderItem;
        }

        #endregion

        #region Property Methods

        public Collection<OrderItem> AllOrderItems => orderItems;

        public OrderItem OrderItem => orderItem;

        #endregion

        #region Methods

        public OrderItem FindById(string id)
        {
            if (orderItems.Count > 0)
            {
                int position = 0;
                bool found = false;
                if (orderItems.Count > 0)
                {
                    found = id.ToUpper().Equals(orderItems[position].OrderItemId.ToString().ToUpper());
                }

                if (!found)
                {
                    position++;
                }

                while (!found && position < orderItems.Count)
                {
                    found = id.ToUpper().Equals(orderItems[position].OrderItemId.ToString().ToUpper());
                    if (found)
                    {
                        break;
                    }

                    position++;
                }

                if (found)
                {
                    return orderItems[position];
                }

                return null;
            }

            return null;
        }

        public bool Add(OrderItem aOrderItem)
        {
            return orderItemInfoDb.DatabaseAdd(aOrderItem);
        }

        public bool Edit(OrderItem aOrderItem)
        {
            return orderItemInfoDb.DatabaseEdit(aOrderItem);
        }

        #endregion
    }
}