using System;
using System.Collections.ObjectModel;

// ReSharper disable All

namespace Poppel_Order_Processing_System.BusinessLayer
{
    public class Order
    {
        #region Fields

        private int orderId;
        private int customerId;
        private DateTime orderDate;
        private Collection<OrderItem> orderItems;
        private decimal deliveryFee;
        private decimal orderTotalPrice;
        private OrderStatuses orderStatus;
        private DateTime shippedDate;
        private DateTime completedDate;
        private string deliveryAddress;
        private PaymentMethods paymentMethod;


        public enum OrderStatuses
        {
            OnHold = 3,
            Shipped = 5,
            NotShipped = 6,
            Completed = 7,
            Cancelled = 8,
            PendingPayment = 1,
            Processing = 4,
            Confirmed = 2,
            NewOrder = 0,
            Refunded = 9
        }

        public enum PaymentMethods
        {
            Cash = 2,
            Credit = 1,
            CreditCard = 3,
            NotPaid = 0
        }

        #endregion

        #region Constructors

        public Order()
        {
            this.orderId = -1;
            this.customerId = -1;
            this.orderDate = new DateTime(1800, 1, 1);
            this.orderItems = new Collection<OrderItem>();
            this.deliveryFee = 0.00m;
            this.orderTotalPrice = 0.00m;
            this.orderStatus = OrderStatuses.NewOrder;
            this.shippedDate = new DateTime(1800, 1, 1);
            this.completedDate = new DateTime(1800, 1, 1);
            this.deliveryAddress = "";
            this.paymentMethod = PaymentMethods.NotPaid;
        }

        public Order(int orderId, int customerId, DateTime orderDate, Collection<OrderItem> orderItems,
            decimal deliveryFee, decimal orderTotalPrice, OrderStatuses orderStatus, DateTime shippedDate,
            DateTime completedDate, string deliveryAddress, PaymentMethods paymentMethod)
        {
            this.orderId = orderId;
            this.customerId = customerId;
            this.orderDate = orderDate;
            this.orderItems = orderItems;
            this.deliveryFee = deliveryFee;
            this.orderTotalPrice = orderTotalPrice;
            this.orderStatus = orderStatus;
            this.shippedDate = shippedDate;
            this.completedDate = completedDate;
            this.deliveryAddress = deliveryAddress;
            this.paymentMethod = paymentMethod;
        }

        #endregion

        #region Property Methods

        public int OrderId
        {
            get => orderId;
            set => orderId = value;
        }

        public int CustomerId
        {
            get => customerId;
            set => customerId = value;
        }

        public DateTime OrderDate
        {
            get => orderDate;
            set => orderDate = value;
        }

        public Collection<OrderItem> OrderItems
        {
            get => orderItems;
            set => orderItems = value;
        }

        public decimal DeliveryFee
        {
            get => deliveryFee;
            set => deliveryFee = value;
        }

        public decimal OrderTotalPrice
        {
            get => orderTotalPrice;
            set => orderTotalPrice = value;
        }


        public DateTime ShippedDate
        {
            get => shippedDate;
            set => shippedDate = value;
        }

        public DateTime CompletedDate
        {
            get => completedDate;
            set => completedDate = value;
        }

        public string DeliveryAddress
        {
            get => deliveryAddress;
            set => deliveryAddress = value;
        }

        public OrderStatuses OrderStatus
        {
            get => orderStatus;
            set => orderStatus = value;
        }

        public PaymentMethods PaymentMethod
        {
            get => paymentMethod;
            set => paymentMethod = value;
        }

        #endregion

        #region Methods

        public static OrderStatuses GetOrderStatus(string orderStatus)
        {
            switch (orderStatus)
            {
                case "On Hold":
                    return OrderStatuses.OnHold;
                case "Shipped":
                    return OrderStatuses.Shipped;
                case "Not Shipped":
                    return OrderStatuses.NotShipped;
                case "Completed":
                    return OrderStatuses.Completed;
                case "Cancelled":
                    return OrderStatuses.Cancelled;
                case "Pending Payment":
                    return OrderStatuses.PendingPayment;
                case "Confirmed":
                    return OrderStatuses.Confirmed;
                case "Processing":
                    return OrderStatuses.Processing;
                case "Refunded":
                    return OrderStatuses.Refunded;
                default:
                    return OrderStatuses.NewOrder;
            }
        }

        public static string GetOrderStatus(OrderStatuses orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatuses.OnHold:
                    return "On Hold";
                case OrderStatuses.Shipped:
                    return "Shipped";
                case OrderStatuses.NotShipped:
                    return "Not Shipped";
                case OrderStatuses.Completed:
                    return "Completed";
                case OrderStatuses.Cancelled:
                    return "Cancelled";
                case OrderStatuses.PendingPayment:
                    return "Pending Payment";
                case OrderStatuses.Confirmed:
                    return "Confirmed";
                case OrderStatuses.Processing:
                    return "Processing";
                case OrderStatuses.Refunded:
                    return "Refunded";
                default:
                    return "New Order";
            }
        }

        public static PaymentMethods GetPaymentMethod(string paymentMethod)
        {
            switch (paymentMethod)
            {
                case "Cash":
                    return PaymentMethods.Cash;
                case "Credit":
                    return PaymentMethods.Credit;
                case "Credit Card":
                    return PaymentMethods.CreditCard;
                default:
                    return PaymentMethods.NotPaid;
            }
        }

        public static string GetPaymentMethod(PaymentMethods paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethods.Cash:
                    return "Cash";
                case PaymentMethods.Credit:
                    return "Credit";
                case PaymentMethods.CreditCard:
                    return "Credit Card";
                default:
                    return "Not Paid";
            }
        }

        private decimal CalculateOrderTotalPrice()
        {
            decimal totalPrice = 0.00m;
            foreach (OrderItem orderItem in orderItems)
            {
                totalPrice += (orderItem.Product.RetailPrice * orderItem.Quantity);
            }

            return totalPrice;
        }

        #endregion
    }
}