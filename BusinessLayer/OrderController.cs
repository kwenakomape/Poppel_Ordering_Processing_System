using System.Collections.ObjectModel;
using Poppel_Order_Processing_System.DatabaseLayer;
using Poppel_Order_Processing_System.Properties;

// ReSharper disable All

namespace Poppel_Order_Processing_System.BusinessLayer
{
    public class OrderController
    {
        #region Fields

        private OrderInfoDB orderInfoDb;
        private OrderItemInfoDB orderItemInfoDb;
        private Collection<Order> orders;
        private Order order;
        private Collection<OrderItem> orderItems;

        #endregion

        #region Constructors

        public OrderController()
        {
            this.orderItemInfoDb = new OrderItemInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString);
            this.orderInfoDb = new OrderInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString);
            this.orderItems = orderItemInfoDb.AllOrderItems;
            this.orders = orderInfoDb.AllOrders;
            addOrderItems();
        }

        public OrderController(string sqlQuery)
        {
            this.orderInfoDb = new OrderInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString, sqlQuery);
            this.order = orderInfoDb.Order;
        }

        #endregion

        #region Property Methods

        public Collection<Order> AllOrders => orders;

        public Order Order => order;

        #endregion

        #region Methods

        private void addOrderItems()
        {
            foreach (Order order in orders)
            {
                foreach (OrderItem orderItem in orderItems)
                {
                    if (orderItem.OrderId == order.OrderId)
                    {
                        order.OrderItems.Add(orderItem);
                    }
                }
            }
        }

        public Order FindById(string id)
        {
            if (orders.Count > 0)
            {
                int position = 0;
                bool found = false;
                if (orders.Count > 0)
                {
                    found = id.ToUpper().Equals(orders[position].OrderId.ToString().ToUpper());
                }

                if (!found)
                {
                    position++;
                }

                while (!found && position < orders.Count)
                {
                    found = id.ToUpper().Equals(orders[position].OrderId.ToString().ToUpper());
                    if (found)
                    {
                        break;
                    }

                    position++;
                }

                if (found)
                {
                    return orders[position];
                }

                return null;
            }

            return null;
        }

        public bool Add(Order aOrder)
        {
            return orderInfoDb.DatabaseAdd(aOrder);
        }

        public bool Edit(Order aOrder)
        {
            return orderInfoDb.DatabaseEdit(aOrder);
        }

        #endregion
    }
}