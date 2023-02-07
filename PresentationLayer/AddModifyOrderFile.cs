using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;
using Poppel_Order_Processing_System.Properties;

// ReSharper disable All

namespace Poppel_Order_Processing_System.PresentationLayer
{
    public partial class AddModifyOrderFile : Form
    {
        #region Constructors

        public AddModifyOrderFile(ProductController productController, CustomerController customerController,
            OrderController orderController, OrderItemController orderItemController)
        {
            InitializeComponent();
            this.productController = productController;
            this.customerController = customerController;
            this.orderController = orderController;
            this.orderItemController = orderItemController;
        }

        #endregion

        #region Property Methods
        

        public Collection<StockCategory> StockCategories { get; set; }

        #endregion

        #region Fields

        public static FormState myState;
        public bool addModifyOrderFileClosed;
        private AddModifyOrderForm addModifyOrderForm;
        private CustomerController customerController;
        private OrderController orderController;
        private OrderItemController orderItemController;
        private Collection<Order> orders;
        private PoppelOrderProcessingSystem poppelOrderProcessingSystem;
        private ProductController productController;
        private Order selectedOrder;

        public Order SelectedOrder
        {
            get => selectedOrder;
            set => selectedOrder = value;
        }


        public enum FormState
        {
            Edit = 0,
            Select = 1
        }
        #endregion

        #region Methods
        public void FormatForm(FormState stateValue)
        {
            switch (stateValue)
            {
                case FormState.Edit:
                    myState = stateValue;
                    this.Text = "Order File";
                    break;
                default:
                    myState = stateValue;
                    this.Text = "Order File (Select Mode)";
                    modifyOrderButton.Image = new Bitmap(Resources.Select);
                    modifyOrderButton.Text = "Select";
                    break;
            }
        }
        private void CreateAddModifyOrderForm()
        {
            AddModifyOrderForm.myState = AddModifyOrderForm.FormState.Add;
            this.addModifyOrderForm = new AddModifyOrderForm(productController, customerController, orderController,
                orderItemController);
            this.addModifyOrderForm.StockCategories = StockCategories;
            this.addModifyOrderForm.FormatForm(AddModifyOrderForm.FormState.Add);
            this.Hide();
            Search(false);
            this.addModifyOrderForm.ShowDialog();
            Search(false);
            this.Show();
        }

        private void CreateAddModifyOrderForm(Order order)
        {
            AddModifyOrderForm.myState = AddModifyOrderForm.FormState.Edit;
            this.addModifyOrderForm = new AddModifyOrderForm(productController, customerController, orderController,
                orderItemController);
            this.addModifyOrderForm.FormatForm(AddModifyOrderForm.FormState.Edit);
            this.addModifyOrderForm.EditOrder = order;
            this.addModifyOrderForm.StockCategories = StockCategories;
            this.addModifyOrderForm.PopulateOrderForm(order);
            this.Hide();
            this.addModifyOrderForm.ShowDialog();
            Search(false);
            this.Show();
        }

        public void Search(bool applyFilter)
        {
            string orderId = orderSearchTextBox.Text.Trim();
            setUpOrderListView(orderId, orderStatusComboBox.Text, paymentMethodComboBox.Text,
                recieveOrderMethodComboBox.Text, applyFilter);
        }

        public void setUpOrderListView(string orderId, string orderStatus, string paymentMethod,
            string recieveOrderMethod, bool applyFilter)
        {
            ListViewItem orderDetails;
            orders = orderController.AllOrders;
            orderFileListView.Clear();
            orderFileListView.Columns.Insert(0, "Order Id", 90, HorizontalAlignment.Left);
            orderFileListView.Columns.Insert(1, "Customer Id", 90, HorizontalAlignment.Left);
            orderFileListView.Columns.Insert(2, "Order Total Price", 120, HorizontalAlignment.Left);
            orderFileListView.Columns.Insert(3, "Order Status", 110, HorizontalAlignment.Left);
            orderFileListView.Columns.Insert(4, "Payment Method", 105, HorizontalAlignment.Left);
            orderFileListView.Columns.Insert(5, "Recieve Order Method", 135, HorizontalAlignment.Left);
            orderFileListView.Columns.Insert(6, "Order Date", 90, HorizontalAlignment.Left);
            orderFileListView.Columns.Insert(7, "Shipped Date", 90, HorizontalAlignment.Left);
            orderFileListView.Columns.Insert(8, "Completed Date", 102, HorizontalAlignment.Left);


            foreach (Order order in orders)
            {
                if (!order.DeliveryAddress.Equals(""))
                {
                    recieveOrderMethod = "Delivery";
                }
                else
                {
                    recieveOrderMethod = "Collect";
                }

                if (order.OrderId.ToString().Contains(orderId) &&
                    (Order.GetOrderStatus(order.OrderStatus).Equals(orderStatus) || orderStatus.Equals("")) &&
                    (Order.GetPaymentMethod(order.PaymentMethod).Equals(paymentMethod) || paymentMethod.Equals("")) &&
                    (recieveOrderMethod.Equals(recieveOrderMethod) || recieveOrderMethod.Equals("")) && applyFilter)
                {
                    orderDetails = new ListViewItem();
                    orderDetails.Text = order.OrderId.ToString();
                    orderDetails.SubItems.Add(order.CustomerId.ToString());
                    orderDetails.SubItems.Add("R" + string.Format("{0:0.00}", order.OrderTotalPrice));
                    orderDetails.SubItems.Add(Order.GetOrderStatus(order.OrderStatus));
                    orderDetails.SubItems.Add(Order.GetPaymentMethod(order.PaymentMethod));
                    if (order.DeliveryAddress.Equals(""))
                    {
                        orderDetails.SubItems.Add("Collect");
                    }
                    else
                    {
                        orderDetails.SubItems.Add("Delivery");
                    }

                    orderDetails.SubItems.Add(order.OrderDate.ToString("dd MMM yyyy"));
                    if (!order.ShippedDate.Equals(new DateTime(1800, 1, 1)))
                    {
                        orderDetails.SubItems.Add(order.ShippedDate.ToString("dd MMM yyyy"));
                    }
                    else
                    {
                        orderDetails.SubItems.Add("");
                    }

                    if (!order.CompletedDate.Equals(new DateTime(1800, 1, 1)))
                    {
                        orderDetails.SubItems.Add(order.CompletedDate.ToString("dd MMM yyyy"));
                    }

                    orderFileListView.Items.Add(orderDetails);
                }
                else
                {
                    if (!applyFilter)
                    {
                        orderDetails = new ListViewItem();
                        orderDetails.Text = order.OrderId.ToString();
                        orderDetails.SubItems.Add(order.CustomerId.ToString());
                        orderDetails.SubItems.Add("R" + string.Format("{0:0.00}", order.OrderTotalPrice));
                        orderDetails.SubItems.Add(Order.GetOrderStatus(order.OrderStatus));
                        orderDetails.SubItems.Add(Order.GetPaymentMethod(order.PaymentMethod));
                        if (order.DeliveryAddress.Equals(""))
                        {
                            orderDetails.SubItems.Add("Collect");
                        }
                        else
                        {
                            orderDetails.SubItems.Add("Delivery");
                        }

                        orderDetails.SubItems.Add(order.OrderDate.ToString("dd MMM yyyy"));
                        if (!order.ShippedDate.Equals(new DateTime(1800, 1, 1)))
                        {
                            orderDetails.SubItems.Add(order.ShippedDate.ToString("dd MMM yyyy"));
                        }
                        else
                        {
                            orderDetails.SubItems.Add("");
                        }

                        if (!order.CompletedDate.Equals(new DateTime(1800, 1, 1)))
                        {
                            orderDetails.SubItems.Add(order.CompletedDate.ToString("dd MMM yyyy"));
                        }

                        orderFileListView.Items.Add(orderDetails);
                    }
                }
            }

            orderFileListView.Refresh();
            orderFileListView.GridLines = true;
        }

        #endregion

        #region Events

        private void orderFileCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddModifyOrderFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (myState ==FormState.Edit)
            {
                addModifyOrderFileClosed = true;
                ((PoppelOrderProcessingSystem)MdiParent).EnableButtons(true);
            }
        }

        private void modifyOrderButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit)
            {
                if (orderFileListView.FocusedItem != null && orderFileListView.SelectedItems.Count > 0)
                {
                    Order order = orderController.FindById(orderFileListView.SelectedItems[0].Text);
                    CreateAddModifyOrderForm(order);
                }
            }
            else
            {
                if (orderFileListView.FocusedItem != null && orderFileListView.SelectedItems.Count > 0)
                {
                    selectedOrder = orderController.FindById(orderFileListView.SelectedItems[0].Text);
                    Close();
                }
            }
        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            CreateAddModifyOrderForm();
        }

        private void AddModifyOrderFile_Load(object sender, EventArgs e)
        {
            poppelOrderProcessingSystem = (PoppelOrderProcessingSystem) this.MdiParent;
            orderFileListView.View = View.Details;
            Search(false);
        }

        private void modifyOrderButton_MouseHover(object sender, EventArgs e)
        {
            if (orderFileListView.FocusedItem == null && orderFileListView.Items.Count > 0)
            {
                orderFileListView.Items[0].Selected = true;
                orderFileListView.Items[0].Focused = true;
                orderFileListView.Select();
            }
        }

        private void orderSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            Search(true);
        }

        private void orderStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search(true);
        }

        private void paymentMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search(true);
        }

        private void recieveOrderMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search(true);
        }

        #endregion
    }
}