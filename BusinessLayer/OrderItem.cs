// ReSharper disable All

namespace Poppel_Order_Processing_System.BusinessLayer
{
    public class OrderItem
    {
        #region Fields

        private int orderItemId;
        private int orderId;
        private Product product;
        private int quantity;

        #endregion

        #region Constructors

        public OrderItem()
        {
            this.orderItemId = -1;
            orderId = -1;
            product = null;
            quantity = 0;
        }

        public OrderItem(int orderItemId, int orderId, Product product, int quantity)
        {
            this.orderItemId = orderItemId;
            this.orderId = orderId;
            this.product = product;
            this.quantity = quantity;
        }

        #endregion

        #region Property Methods

        public int OrderItemId
        {
            get => orderItemId;
            set => orderItemId = value;
        }

        public int OrderId
        {
            get => orderId;
            set => orderId = value;
        }

        public Product Product
        {
            get => product;
            set => product = value;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        #endregion
    }
}