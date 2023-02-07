using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;
using TenTec.Windows.iGridLib;

// ReSharper disable All
namespace Poppel_Order_Processing_System.PresentationLayer
{
    public partial class AddModifyOrderForm : Form
    {
        #region Constructors

        public AddModifyOrderForm(ProductController productController, CustomerController customerController,
            OrderController orderController, OrderItemController orderItemController)
        {
            InitializeComponent();
            this.productController = productController;
            this.customerController = customerController;
            this.orderController = orderController;
            this.orderItemController = orderItemController;
            this.numbOfOrders = orderController.AllOrders.Count;
            this.counterPrevious = numbOfOrders;
            this.counterForward = 0;
            deliveryInformationLabel.Text = "Free Delivery For Orders Greater Than Or Equal To R" + freeDeliveryFee;
            SetUpOrderItemIgrid();
            if (myState == FormState.Add)
            {
                orderDateTimePicker.Value = DateTime.Today.Date;
                shippedDateTimePicker.CustomFormat = " ";
                completedDateTimePicker.CustomFormat = " ";
                deliveryFeeTextBox.Text = "0.00";
                orderTotalPriceTextBox.Text = "0.00";
                orderTotalItemsTextBox.Text = "0";
                orderStatusComboBox.SelectedIndex = 0;
                paymentMethodComboBox.SelectedIndex = 0;
            }
            else
            {
                shippedDateTimePicker.CustomFormat = " ";
                completedDateTimePicker.CustomFormat = " ";
                orderTotalPriceTextBox.Text = "0.00";
                deliveryFeeTextBox.Text = "0.00";
            }
        }

        #endregion

        #region Fields

        public enum FormState
        {
            Add = 0,
            Edit = 1
        }

        public static FormState myState;
        private decimal beforeEditValue;
        private int beforeOrderItemQuantity;
        private bool closeButtonSelected;
        private int counterForward;
        private int counterPrevious;
        private Customer currentCustomer;
        private Order currentOrder;
        private CustomerController customerController;
        private decimal deliveryFee = 100.00m;
        private Order editOrder;
        bool endFileBackward = false;
        bool endFileForward = false;
        private bool fistRun = true;
        private decimal freeDeliveryFee = 500.00m;
        private int numbOfOrders;
        private OrderController orderController;
        private bool orderItemCancelled;
        private OrderItemController orderItemController;
        private bool orderStatusToBeSetAutomatically;
        private ProductController productController;
        private Collection<Product> productsToEdit = new Collection<Product>();
        Dictionary<string, int> productsToOrderQuantity = new Dictionary<string, int>();
        Dictionary<string, int> quantityOfOrderItem = new Dictionary<string, int>();
        Dictionary<string, int> reservedInventory = new Dictionary<string, int>();
        Collection<int> rowsToClear = new Collection<int>();
        private bool saveOrderButtonSelected;
        private Product selectedProduct;
        private decimal tempdeliveryFee = 0.00m;
        private decimal tempOrderTotalPrice;
        Product tempProduct;
        Dictionary<string, int> tempProductQuantity = new Dictionary<string, int>();
        Collection<int> tempProductQuantityGridLocation = new Collection<int>();
        Dictionary<string, int> tempReservedInventory = new Dictionary<string, int>();
        private Collection<int> totalOrderItems = new Collection<int>();
        private Collection<decimal> totalOrderPrice = new Collection<decimal>();

        #endregion

        #region Property Methods

        public Collection<StockCategory> StockCategories { get; set; }

        public Order EditOrder
        {
            get => editOrder;
            set => editOrder = value;
        }

        #endregion

        #region Methods

        public void FormatForm(FormState stateValue)
        {
            switch (stateValue)
            {
                case FormState.Add:
                    myState = stateValue;
                    this.Text = "Order Maintenance (Add New)";
                    break;
                default:
                    myState = stateValue;
                    this.Text = "Order Maintenance (Edit Mode)";
                    orderItemIgrid.Cols[3].Width = 0;
                    orderItemIgrid.Cols[1].Width = orderItemIgrid.Cols[1].Width + 107;
                    customerIdTextBox.ReadOnly = true;
                    orderStatusComboBox.Items.RemoveAt(0);
                    break;
            }
        }

        private void SetUpOrderItemIgrid()
        {
            if (myState == FormState.Add)
            {
                DisableCols();
                Selectable(0);
            }
            else
            {
                DisableCols();
                foreach (iGCol iCol in orderItemIgrid.Cols)
                {
                    iCol.AllowSizing = false;
                }
            }
        }

        private void ResetEverything()
        {
            productsToEdit.Clear();
            reservedInventory.Clear();
            quantityOfOrderItem.Clear();
            totalOrderPrice.Clear();
            totalOrderItems.Clear();
            tempProductQuantityGridLocation.Clear();
            tempProductQuantity.Clear();
            paymentMethodComboBox.SelectedIndex = 0;
            orderTotalPriceTextBox.Text = "0.00";
            orderTotalItemsTextBox.Text = "0";
            deliveryFeeTextBox.Text = "0.00";
            selectedProduct = null;
            tempProduct = null;
            currentCustomer = null;
        }

        private void ClearCols()
        {
            foreach (iGCol col in orderItemIgrid.Cols)
            {
                foreach (iGCell iGCell in col.Cells)
                {
                    iGCell.Value = "";
                }
            }
        }

        private void DisableCols()
        {
            foreach (iGCol col in orderItemIgrid.Cols)
            {
                foreach (iGCell iGCell in col.Cells)
                {
                    iGCell.ReadOnly = iGBool.True;
                    iGCell.Selectable = iGBool.False;
                    iGCell.ValueType = typeof(String);
                }
            }
        }

        private void DisableCols(int rowIndexArg)
        {
            for (int rowIndex = rowIndexArg; rowIndex < orderItemIgrid.Rows.Count; rowIndex++)
            {
                foreach (iGCell iGCell in orderItemIgrid.Rows[rowIndex].Cells)
                {
                    iGCell.ReadOnly = iGBool.True;
                    iGCell.Selectable = iGBool.False;
                    iGCell.ValueType = typeof(String);
                }
            }
        }

        public void Selectable(int rowIndex)
        {
            foreach (iGCell iGCell in orderItemIgrid.Rows[rowIndex].Cells)
            {
                if (iGCell.ColIndex == 0 || iGCell.ColIndex == 6)
                {
                    iGCell.ReadOnly = iGBool.False;
                    iGCell.Selectable = iGBool.True;
                }
            }
        }

        private void KeyDownOnControl(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab || e.KeyData == Keys.Down)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            else
            {
                if (e.KeyData == Keys.Up)
                {
                    SelectNextControl(ActiveControl, false, true, true, true);
                }
            }
        }

        private void KeyDownOnIgrid(KeyEventArgs e)
        {
            if (myState == FormState.Add)
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (orderItemIgrid.SelectedCells.Count > 0 &&
                        orderItemIgrid.SelectedCells[0].Value != null &&
                        orderItemIgrid.SelectedCells[0].Value.ToString().Length > 0)
                    {
                        if (orderItemIgrid.SelectedCells[0].ColIndex == 6)
                        {
                            Selectable(orderItemIgrid.SelectedCells[0].RowIndex + 1);
                            orderItemIgrid.Cells[orderItemIgrid.SelectedCells[0].RowIndex + 1, 0].Selected = true;
                        }
                        else
                        {
                            orderItemIgrid.Cells[orderItemIgrid.SelectedCells[0].RowIndex,
                                orderItemIgrid.SelectedCells[0].ColIndex + 6].Selected = true;
                        }
                    }
                }
            }
        }

        private void PopulateProduct(Product aProduct, int Quantity, int rowIndex)
        {
            int colIndex = 0;
            tempProduct = aProduct;

            orderItemIgrid.Cells[rowIndex, colIndex].Value = tempProduct.ProductId;
            orderItemIgrid.Cells[rowIndex, colIndex + 1].Value = tempProduct.ProductDetails;
            orderItemIgrid.Cells[rowIndex, colIndex + 2].Value = tempProduct.ProductCategory;
            orderItemIgrid.Cells[rowIndex, colIndex + 4].Value =
                string.Format("{0:0.00}", tempProduct.RetailPrice);
            orderItemIgrid.Cells[rowIndex, colIndex + 5].Value =
                string.Format("{0:0.00}", tempProduct.CostPrice);
            orderItemIgrid.Cells[rowIndex, colIndex + 6].Value = Quantity;

            orderItemIgrid.Cells[rowIndex, colIndex + 7].Value = string.Format("{0:0.00}",
                Convert.ToInt32(orderItemIgrid.Cells[rowIndex, colIndex + 6].Value) *
                tempProduct.RetailPrice);

            totalOrderPrice.Add(
                Convert.ToDecimal(orderItemIgrid.Cells[rowIndex, colIndex + 7].Value.ToString()));
            totalOrderItems.Add(Convert.ToInt32(orderItemIgrid.Cells[rowIndex, colIndex + 6].Value
                .ToString()));

            orderTotalItemsTextBox.Text = string.Format("{0:0}", Enumerable.Sum(totalOrderItems));
        }

        private void PopulateProduct(Product aProduct, iGAfterCommitEditEventArgs e)
        {
            tempProductQuantityGridLocation.Clear();
            tempProductQuantity.Clear();
            tempProduct = null;
            if (aProduct != null)
            {
                tempProduct = new Product(aProduct);
            }

            if (tempProduct != null)
            {
                if (!reservedInventory.ContainsKey(tempProduct.ProductId))
                {
                    reservedInventory.Add(tempProduct.ProductId, tempProduct.QuantityOnHand);
                }

                if (reservedInventory[tempProduct.ProductId] >= 1)
                {
                    orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Value = tempProduct.ProductId;
                    orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 1].Value = tempProduct.ProductDetails;
                    orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 2].Value = tempProduct.ProductCategory;
                    orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 3].Value = tempProduct.QuantityOnHand;
                    orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 4].Value =
                        string.Format("{0:0.00}", tempProduct.RetailPrice);
                    orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 5].Value =
                        string.Format("{0:0.00}", tempProduct.CostPrice);
                    orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 6].Value = 1;
                    reservedInventory[tempProduct.ProductId] = reservedInventory[tempProduct.ProductId] - 1;
                    orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 7].Value = string.Format("{0:0.00}",
                        Convert.ToInt32(orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 6].Value) *
                        tempProduct.RetailPrice);
                    totalOrderPrice.Add(
                        Convert.ToDecimal(orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 7].Value.ToString()));
                    totalOrderItems.Add(Convert.ToInt32(orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 6].Value
                        .ToString()));

                    orderTotalItemsTextBox.Text = string.Format("{0:0}", Enumerable.Sum(totalOrderItems));
                    tempProductQuantity.Clear();
                    tempProductQuantityGridLocation.Clear();
                    tempProductQuantity.Add(tempProduct.ProductId,
                        Convert.ToInt32(orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 6].Value));
                    tempProductQuantityGridLocation.Add(e.RowIndex);
                    tempProductQuantityGridLocation.Add(e.ColIndex + 6);
                    if (!productsToEdit.Contains(tempProduct) &&
                        !ContainsProduct(tempProduct.ProductId.ToString()))
                    {
                        productsToEdit.Add(tempProduct);
                    }

                    orderTotalPriceTextBox.Text = string.Format("{0:0.00}",
                        Enumerable.Sum(totalOrderPrice) + Convert.ToDecimal(deliveryFeeTextBox.Text));
                    if (!orderItemCancelled)
                    {
                        orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 6].Selected = true;
                    }

                    orderItemCancelled = false;
                }
                else
                {
                    MessageBox.Show(this,
                        "Product is not Enough in Stock, Product Id = " + tempProduct.ProductId +
                        "\nHas Only " + reservedInventory[tempProduct.ProductId] + " Available Product(s)",
                        "Warning: Not Enough Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    orderItemIgrid.Cells[e.RowIndex, 0].Value = "";
                }
            }
            else
            {
                AddModifyStockFile addModifyStockFile = new AddModifyStockFile(productController, StockCategories);
                addModifyStockFile.FormatForm(AddModifyStockFile.FormState.Select);
                addModifyStockFile.ShowDialog();
                selectedProduct = addModifyStockFile.SelectedProduct;
                if (selectedProduct != null)
                {
                    PopulateProduct(selectedProduct, e);
                    selectedProduct = null;
                }
                else
                {
                    clearOrderItemRow(e);
                }
            }
        }

        private void clearOrderItemRow(iGAfterCommitEditEventArgs e)
        {
            orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Value = "";
            orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 1].Value = "";
            orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 2].Value = "";
            orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 3].Value = "";
            orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 4].Value = "";
            orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 5].Value = "";
            orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 6].Value = "";
            orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 7].Value = "";
        }

        private void clearOrderItemRow(int rowIndex)
        {
            int colIndex = 0;
            orderItemIgrid.Cells[rowIndex, colIndex].Value = "";
            orderItemIgrid.Cells[rowIndex, colIndex + 1].Value = "";
            orderItemIgrid.Cells[rowIndex, colIndex + 2].Value = "";
            orderItemIgrid.Cells[rowIndex, colIndex + 3].Value = "";
            orderItemIgrid.Cells[rowIndex, colIndex + 4].Value = "";
            orderItemIgrid.Cells[rowIndex, colIndex + 5].Value = "";
            orderItemIgrid.Cells[rowIndex, colIndex + 6].Value = "";
            orderItemIgrid.Cells[rowIndex, colIndex + 7].Value = "";
        }

        public void PopulateCustomerForm(Customer customer)
        {
            this.currentCustomer = customer;
            if (customer != null)
            {
                customerIdTextBox.Text = customer.CustomerId.ToString();
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
                customerIdTextBox.Text = "";
                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
                phoneNumberTextBox.Text = "";
                emailAddressTextBox.Text = "";
                customerCreditTextBox.Text = "";
                creditStatusComboBox.SelectedIndex = -1;
            }
        }

        public void PopulateOrderForm(Order order)
        {
            ResetEverything();
            if (order != null)
            {
                this.currentOrder = order;
                customerIdTextBox.Text = order.CustomerId.ToString();
                currentCustomer = customerController.FindByID(order.CustomerId.ToString());
                PopulateCustomerForm(currentCustomer);
                orderDateTimePicker.Value = order.OrderDate.Date;
                if (!order.ShippedDate.Equals(new DateTime(1800, 1, 1)))
                {
                    shippedDateTimePicker.CustomFormat = "dd MMM yyyy";
                    shippedDateTimePicker.Value = order.ShippedDate;
                }
                else
                {
                    shippedDateTimePicker.CustomFormat = " ";
                }

                if (!order.CompletedDate.Equals(new DateTime(1800, 1, 1)))
                {
                    completedDateTimePicker.CustomFormat = "dd MMM yyyy";
                    completedDateTimePicker.Value = order.CompletedDate;
                }
                else
                {
                    completedDateTimePicker.CustomFormat = " ";
                }

                if (currentOrder.OrderStatus == Order.OrderStatuses.Shipped ||
                    currentOrder.OrderStatus == Order.OrderStatuses.Completed)
                {
                    deliveryRadioButton.Enabled = false;
                    collectRadioButton.Enabled = false;
                }

                orderStatusComboBox.SelectedIndex = (int) order.OrderStatus - 1;

                if (currentOrder.OrderStatus == Order.OrderStatuses.Cancelled ||
                    currentOrder.OrderStatus == Order.OrderStatuses.Refunded ||
                    order.PaymentMethod == Order.PaymentMethods.NotPaid)
                {
                    if (order.PaymentMethod != Order.PaymentMethods.NotPaid)
                    {
                        deliveryRadioButton.Enabled = false;
                        collectRadioButton.Enabled = false;
                    }

                    orderStatusComboBox.Enabled = false;
                }
                else
                {
                    orderStatusComboBox.Enabled = true;
                }

                paymentMethodComboBox.SelectedIndex = (int) order.PaymentMethod;
                if (order.PaymentMethod != Order.PaymentMethods.NotPaid)
                {
                    paymentMethodComboBox.Enabled = false;
                }

                if (!order.DeliveryAddress.Equals(""))
                {
                    deliveryRadioButton.Checked = true;
                }
                else
                {
                    collectRadioButton.Checked = true;
                }

                PopulateOrderItems(order.OrderItems);
                deliveryFeeTextBox.Text = string.Format("{0:0.00}", order.DeliveryFee);
                orderTotalItemsTextBox.Text = string.Format("{0:0}", Enumerable.Sum(totalOrderItems));
                orderTotalPriceTextBox.Text = string.Format("{0:0.00}", order.OrderTotalPrice.ToString());
                fistRun = false;
            }
            else
            {
                this.currentOrder = order;
                customerIdTextBox.ReadOnly = false;

                orderDateTimePicker.Value = DateTime.Today.Date;
                shippedDateTimePicker.CustomFormat = " ";

                shippedDateTimePicker.Value = new DateTime(1800, 1, 1).Date;
                completedDateTimePicker.CustomFormat = " ";

                completedDateTimePicker.Value = new DateTime(1800, 1, 1).Date;
                deliveryFeeTextBox.Text = string.Format("{0:0.00}", 0);

                orderStatusComboBox.Enabled = false;
                paymentMethodComboBox.Enabled = true;

                orderStatusComboBox.Items.Add("New Order");

                orderStatusComboBox.SelectedIndex = orderStatusComboBox.Items.Count - 1;
                paymentMethodComboBox.SelectedIndex = (int) Order.PaymentMethods.NotPaid;

                deliveryRadioButton.Enabled = true;
                collectRadioButton.Enabled = true;

                deliveryRadioButton.Checked = false;
                collectRadioButton.Checked = false;

                ClearCols();
                DisableCols();
                ResetEverything();
                Selectable(0);
                PopulateCustomerForm(currentCustomer);
            }
        }

        private void PopulateOrderItems(Collection<OrderItem> orderItems)
        {
            int rowindex = 0;
            foreach (OrderItem orderItem in orderItems)
            {
                Product product = orderItem.Product;
                PopulateProduct(product, orderItem.Quantity, rowindex);
                rowindex++;
            }
        }

        private bool ContainsProduct(string productId)
        {
            foreach (var prod in productsToEdit)
            {
                if (prod.ProductId.ToString().ToUpper().Equals(productId.ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }

        private Product GetProduct(string productId)
        {
            foreach (var prod in productsToEdit)
            {
                if (prod.ProductId.ToString().ToUpper().Equals(productId.ToUpper()))
                {
                    return prod;
                }
            }

            return null;
        }

        private void ClosingForm()
        {
            if (!OrderItemsEntered())
            {
                closeButtonSelected = true;
                Close();
            }
            else
            {
                DialogResult reply = MessageBox.Show(this, "Are You Sure You Want To Abort ?",
                    "Warning: Work Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (reply == DialogResult.Yes)
                {
                    productsToEdit.Clear();
                    closeButtonSelected = true;
                    Close();
                }
            }
        }

        private void ClosingForm(FormClosingEventArgs e)
        {
            if (!OrderItemsEntered())
            {
                e.Cancel = false;
            }
            else
            {
                DialogResult reply = MessageBox.Show(this, "Are You Sure You Want To Abort ?",
                    "Warning: Work Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (reply == DialogResult.Yes)
                {
                    productsToEdit.Clear();
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private bool OrderItemsEntered()
        {
            foreach (iGCell iGCell in orderItemIgrid.Cols[0].Cells)
            {
                if (iGCell.Value != null && !iGCell.Value.ToString().Equals(""))
                {
                    return true;
                }
            }

            return false;
        }

        private void AdjustOrderItems(int indexOffSetArg)
        {
            int indexOffSet = indexOffSetArg;
            int finalQuantity = -1;
            if (tempProduct == null)
            {
                tempProduct = GetTempProductToAdjust(indexOffSet);
                if (tempProduct == null)
                {
                    MessageBox.Show(this,
                        "Order Item(s) Adjustment Didn't Help,\nCustomer Can't Make Order Using Credit",
                        "Insufficient Customer Credit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    paymentMethodComboBox.SelectedIndex = 0;
                    //orderItemCancelled = false;
                    totalOrderPrice.Clear();
                    totalOrderPrice.Add(tempOrderTotalPrice);
                    tempOrderTotalPrice = 0.00m;

                    reservedInventory.Clear();
                    reservedInventory = new Dictionary<string, int>(tempReservedInventory);
                    tempReservedInventory.Clear();

                    deliveryFeeTextBox.Text = tempdeliveryFee.ToString();
                    tempdeliveryFee = 0.00m;

                    orderTotalPriceTextBox.Text = string.Format("{0:0.00}",
                        Enumerable.Sum(totalOrderPrice) + Convert.ToDecimal(deliveryFeeTextBox.Text));

                    return;
                }

                finalQuantity = tempProductQuantity[tempProduct.ProductId];
            }

            decimal orderTotalPrice =
                Convert.ToDecimal(Enumerable.Sum(totalOrderPrice) + Convert.ToDecimal(deliveryFeeTextBox.Text));
            for (int deleteQuantity = 1;; deleteQuantity++)
            {
                if (finalQuantity != -1)
                {
                    if (deleteQuantity <= finalQuantity)
                    {
                        orderTotalPrice -= tempProduct.RetailPrice * deleteQuantity;
                        if (orderTotalPrice < freeDeliveryFee && deliveryRadioButton.Checked)
                        {
                            orderTotalPrice += deliveryFee;
                        }

                        if (orderTotalPrice <= currentCustomer.CustomerCredit || finalQuantity == deleteQuantity)
                        {
                            if (orderTotalPrice <= currentCustomer.CustomerCredit)
                            {
                                if (orderTotalPrice < freeDeliveryFee && deliveryRadioButton.Checked)
                                {
                                    deliveryFeeTextBox.Text = deliveryFee.ToString();
                                }

                                totalOrderPrice.Add(-tempProduct.RetailPrice * deleteQuantity);
                                orderTotalPriceTextBox.Text = string.Format("{0:0.00}",
                                    Enumerable.Sum(totalOrderPrice) + Convert.ToDecimal(deliveryFeeTextBox.Text));

                                totalOrderItems.Add(-deleteQuantity);
                                orderTotalItemsTextBox.Text = Enumerable.Sum(totalOrderItems).ToString();
                                orderItemIgrid.Cells[tempProductQuantityGridLocation[0],
                                            tempProductQuantityGridLocation[1]]
                                        .Value =
                                    (tempProductQuantity[tempProduct.ProductId] - deleteQuantity).ToString();
                                reservedInventory[tempProduct.ProductId] += tempProductQuantity[tempProduct.ProductId] -
                                                                            (tempProductQuantity
                                                                                 [tempProduct.ProductId] -
                                                                             deleteQuantity);
                                orderItemIgrid.Cells[tempProductQuantityGridLocation[0],
                                            tempProductQuantityGridLocation[1] + 1]
                                        .Value =
                                    string.Format("{0:0.00}",
                                        (tempProductQuantity[tempProduct.ProductId] - deleteQuantity) *
                                        tempProduct.RetailPrice);
                            }

                            if ((tempProductQuantity[tempProduct.ProductId] - deleteQuantity) == 0)
                            {
                                
                                rowsToClear.Add(tempProductQuantityGridLocation[0]);
                                if (orderTotalPrice > currentCustomer.CustomerCredit)
                                {
                                    orderTotalPrice -= tempProduct.RetailPrice * deleteQuantity;
                                    tempProduct = null;
                                    AdjustOrderItems(indexOffSetArg + 1);
                                }

                                if (tempProduct == null)
                                {
                                    break;
                                }
                            }

                            foreach (int row in rowsToClear)
                            {
                                clearOrderItemRow(row);
                                orderItemIgrid.Cells[tempProductQuantityGridLocation[0], 0].Selected = true;
                                orderItemCancelled = true;
                            }

                            rowsToClear.Clear();
                            tempProduct = null;
                            break;
                        }
                        else
                        {
                            orderTotalPrice += tempProduct.RetailPrice * deleteQuantity;
                            if (orderTotalPrice < freeDeliveryFee && deliveryRadioButton.Checked)
                            {
                                orderTotalPrice -= deliveryFee;
                            }
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    orderTotalPrice -= tempProduct.RetailPrice * deleteQuantity;
                    if (orderTotalPrice <= currentCustomer.CustomerCredit)
                    {
                        totalOrderPrice.Add(-tempProduct.RetailPrice * deleteQuantity);

                        orderTotalPriceTextBox.Text = string.Format("{0:0.00}",
                            Enumerable.Sum(totalOrderPrice) + Convert.ToDecimal(deliveryFeeTextBox.Text));
                        totalOrderItems.Add(-deleteQuantity);

                        orderTotalItemsTextBox.Text = Enumerable.Sum(totalOrderItems).ToString();
                        orderItemIgrid.Cells[tempProductQuantityGridLocation[0], tempProductQuantityGridLocation[1]]
                                .Value =
                            (tempProductQuantity[tempProduct.ProductId] - deleteQuantity).ToString();
                        reservedInventory[tempProduct.ProductId] += tempProductQuantity[tempProduct.ProductId] -
                                                                    (tempProductQuantity[tempProduct.ProductId] -
                                                                     deleteQuantity);
                        orderItemIgrid.Cells[tempProductQuantityGridLocation[0], tempProductQuantityGridLocation[1] + 1]
                                .Value =
                            string.Format("{0:0.00}",
                                (tempProductQuantity[tempProduct.ProductId] - deleteQuantity) *
                                tempProduct.RetailPrice);
                        if ((tempProductQuantity[tempProduct.ProductId] - deleteQuantity) == 0)
                        {
                            clearOrderItemRow(tempProductQuantityGridLocation[0]);
                            tempProduct = null;
                            orderItemIgrid.Cells[tempProductQuantityGridLocation[0], 0].Selected = true;
                            orderItemCancelled = true;
                        }

                        break;
                    }
                    else
                    {
                        orderTotalPrice += tempProduct.RetailPrice * deleteQuantity;
                    }
                }
            }
        }

        private void SaveOrder()
        {
            if (currentCustomer != null &&
                (collectRadioButton.Checked || deliveryRadioButton.Checked) &&
                OrderItemsEntered()
            )
            {
                foreach (var prod in productsToEdit)
                {
                    foreach (iGCell iGCell in orderItemIgrid.Cols[0].Cells)
                    {
                        if (iGCell.Value != null && iGCell.Value.ToString().Equals(prod.ProductId.ToString()))
                        {
                            int onHand = Convert.ToInt32(orderItemIgrid.Cols[6].Cells[iGCell.RowIndex].Value);
                            prod.QuantityOnHand -= onHand;
                        }
                    }
                }


                foreach (var prod in productsToEdit.ToArray())
                {
                    foreach (var product in productController.AllProducts)
                    {
                        if (prod.ProductId.ToUpper().Equals(product.ProductId.ToUpper()))
                        {
                            if (product.QuantityOnHand != prod.QuantityOnHand)
                            {
                                if (!quantityOfOrderItem.ContainsKey(prod.ProductId))
                                {
                                    quantityOfOrderItem.Add(prod.ProductId,
                                        product.QuantityOnHand - prod.QuantityOnHand);
                                }
                                else
                                {
                                    quantityOfOrderItem[prod.ProductId] =
                                        product.QuantityOnHand - prod.QuantityOnHand;
                                }

                                product.QuantityOnHand = prod.QuantityOnHand;

                                break;
                            }
                            else
                            {
                                productsToEdit.Remove(prod);
                                break;
                            }
                        }
                    }
                }

                Order order = new Order();
                order.CustomerId = currentCustomer.CustomerId;
                order.OrderDate = orderDateTimePicker.Value.Date;
                order.DeliveryFee = Convert.ToDecimal(deliveryFeeTextBox.Text);
                order.OrderTotalPrice = Convert.ToDecimal(orderTotalPriceTextBox.Text);
                if (paymentMethodComboBox.Text.Equals("Credit") ||
                    paymentMethodComboBox.Text.Equals("Cash") ||
                    paymentMethodComboBox.Text.Equals("Credit Card"))
                {
                    order.OrderStatus = Order.OrderStatuses.Confirmed;
                }
                else
                {
                    if (paymentMethodComboBox.Text.Equals("Not Paid"))
                    {
                        order.OrderStatus = Order.OrderStatuses.PendingPayment;
                    }
                }

                if (deliveryRadioButton.Checked)
                {
                    if (currentCustomer.DeliveryAddress != null)
                    {
                        order.DeliveryAddress = currentCustomer.DeliveryAddress.ToString();
                    }
                    else
                    {
                        DialogResult reply = MessageBox.Show(this,
                            "Customer Does Not Have a Delivery Addess\nDo You Want To Add Delivery Address?",
                            "Customer Has No Delivery Address ", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (reply == DialogResult.Yes)
                        {
                            AddModifyCustomerFile addModifyCustomerFile =
                                new AddModifyCustomerFile(customerController);
                            addModifyCustomerFile.CreateAddModifyCustomerForm(currentCustomer);
                            addModifyCustomerFile.Close();
                            return;
                        }

                        collectRadioButton.Checked = true;
                        return;
                    }
                }

                order.PaymentMethod = Order.GetPaymentMethod(paymentMethodComboBox.Text);

                bool success = orderController.Add(order);
                if (success)
                {
                    string sqlQuery = "SELECT TOP 1 * FROM OrderTable ORDER BY [Order_Id] DESC";

                    Order tempOrder = new OrderController(sqlQuery).Order;

                    foreach (var prod in productsToEdit)
                    {
                        OrderItem orderItem = new OrderItem();
                        orderItem.OrderId = tempOrder.OrderId;
                        orderItem.Product = prod;
                        orderItem.Quantity = quantityOfOrderItem[prod.ProductId];
                        tempOrder.OrderItems.Add(orderItem);
                        success = orderItemController.Add(orderItem);
                        if (success)
                            orderItemController.AllOrderItems.Add(orderItem);
                    }

                    if (success)
                    {
                        if (tempOrder.PaymentMethod == Order.PaymentMethods.Credit)
                        {
                            currentCustomer.CustomerCredit -= tempOrder.OrderTotalPrice;
                            if (currentCustomer.CustomerCredit <= 0)
                            {
                                currentCustomer.CreditStatus = "Onhold";
                            }

                            customerController.Edit(currentCustomer);
                        }

                        orderController.AllOrders.Add(tempOrder);
                        ClearCols();
                        PopulateCustomerForm(null);
                        foreach (var product in productsToEdit)
                        {
                            productController.Edit(product);
                        }

                        DisableCols();
                        ResetEverything();
                        if (myState == FormState.Add)
                        {
                            Selectable(0);
                        }

                        if (collectRadioButton.Checked)
                        {
                            collectRadioButton.Checked = false;
                        }
                        else
                        {
                            deliveryRadioButton.Checked = false;
                        }
                    }
                }
            }
            else
            {
                if (currentCustomer == null)
                {
                    MessageBox.Show(this,
                        "Please Enter a Customer Id To Select a Customer",
                        "Customer Not Selected ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!(collectRadioButton.Checked || deliveryRadioButton.Checked))
                    {
                        MessageBox.Show(this,
                            "Please Select a Method To Receive Order",
                            "Receive Order Method Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this,
                            "Please Enter Order Item(s) To Proceed",
                            "Order Item(s) Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private Product GetTempProductToAdjust(int rowIndexOffSet)
        {
            foreach (iGCell iGCell in orderItemIgrid.Cols[0].Cells)
            {
                if (iGCell.Value != null && !iGCell.Value.ToString().Equals(""))
                {
                    continue;
                }
                else
                {
                    if (iGCell.Value == null || iGCell.Value.ToString().Equals(""))
                    {
                        if (iGCell.RowIndex - rowIndexOffSet >= 0)
                        {
                            Product prod =
                                GetProduct(orderItemIgrid.Cols[0].Cells[iGCell.RowIndex - rowIndexOffSet].Text);

                            tempProductQuantity.Clear();
                            tempProductQuantityGridLocation.Clear();
                            tempProductQuantity.Add(prod.ProductId,
                                Convert.ToInt32(orderItemIgrid.Cols[6].Cells[iGCell.RowIndex - rowIndexOffSet].Value));
                            tempProductQuantityGridLocation.Add(orderItemIgrid.Cols[6]
                                .Cells[iGCell.RowIndex - rowIndexOffSet].RowIndex);
                            tempProductQuantityGridLocation.Add(orderItemIgrid.Cols[6]
                                .Cells[iGCell.RowIndex - rowIndexOffSet].ColIndex);
                            return prod;
                        }

                        break;
                    }
                }
            }

            return null;
        }

        private void UpdateDeliveryFee()
        {
            if (deliveryRadioButton.Checked && Convert.ToDecimal(Enumerable.Sum(totalOrderPrice)) >= freeDeliveryFee)
            {
                deliveryFeeTextBox.Text = string.Format("{0:0.00}", 0);
                orderTotalPriceTextBox.Text = string.Format("{0:0.00}",
                    Enumerable.Sum(totalOrderPrice) + Convert.ToDecimal(deliveryFeeTextBox.Text));
            }
            else
            {
                if (deliveryRadioButton.Checked)
                {
                    deliveryFeeTextBox.Text = string.Format("{0:0.00}", deliveryFee);

                    orderTotalPriceTextBox.Text = string.Format("{0:0.00}",
                        Enumerable.Sum(totalOrderPrice) + Convert.ToDecimal(deliveryFeeTextBox.Text));
                }
                else
                {
                    if (collectRadioButton.Checked)
                    {
                        deliveryFeeTextBox.Text = string.Format("{0:0.00}", 0);
                        orderTotalPriceTextBox.Text = string.Format("{0:0.00}",
                            Enumerable.Sum(totalOrderPrice) + Convert.ToDecimal(deliveryFeeTextBox.Text));
                    }
                }
            }
        }

        #endregion

        #region Events

        private void closeOrderFormButton_Click(object sender, EventArgs e)
        {
            ClosingForm();
        }

        private void customerIdTextBox_Leave(object sender, EventArgs e)
        {
            if (!customerIdTextBox.Text.Trim().Equals(""))
            {
                Customer customer = customerController.FindByID(customerIdTextBox.Text);
                if (customer != null)
                {
                    currentCustomer = customer;
                    PopulateCustomerForm(currentCustomer);
                }
                else
                {
                    AddModifyCustomerFile addModifyCustomerFile = new AddModifyCustomerFile(customerController);
                    addModifyCustomerFile.FormatForm(AddModifyCustomerFile.FormState.Select);
                    addModifyCustomerFile.ShowDialog();
                    customer = addModifyCustomerFile.SelectedCustomer;
                    PopulateCustomerForm(customer);
                }
            }
            else
            {
                PopulateCustomerForm(null);
            }
        }

        private void customerIdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownOnControl(e);
        }

        private void orderItemIgrid_AfterCommitEdit(object sender, iGAfterCommitEditEventArgs e)
        {
            if (myState == FormState.Add)
            {
                if (e.ColIndex == 0)
                {
                    if (!orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Text.Trim().Equals(""))
                    {
                        string currentProductIdCell = orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Text.Trim();

                        Product aproduct = productController.FindById(currentProductIdCell);
                        PopulateProduct(aproduct, e);
                    }
                    else
                    {
                        clearOrderItemRow(e);
                    }
                }
                else
                {
                    if (e.ColIndex == 6)
                    {
                        int quantity;
                        if (orderItemIgrid.Cells[e.RowIndex, 0].Value != null &&
                            orderItemIgrid.Cells[e.RowIndex, 0].Value.ToString().Length > 0 &&
                            orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Value != null &&
                            int.TryParse(orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Value.ToString(), out quantity) &&
                            quantity > 0)
                        {
                            if (tempProduct == null && orderItemIgrid.Cells[e.RowIndex, 0].Value != null)
                            {
                                tempProduct =
                                    productController.FindById(
                                        orderItemIgrid.Cells[e.RowIndex, 0].Value.ToString());
                            }

                            if (tempProduct != null)
                            {
                                reservedInventory[tempProduct.ProductId] = reservedInventory[tempProduct.ProductId] +
                                                                           beforeOrderItemQuantity;
                                if (reservedInventory[tempProduct.ProductId] >=
                                    Convert.ToInt32(orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Value))
                                {
                                    reservedInventory[tempProduct.ProductId] =
                                        reservedInventory[tempProduct.ProductId] -
                                        Convert.ToInt32(orderItemIgrid
                                            .Cells[e.RowIndex, e.ColIndex].Value);

                                    orderItemIgrid.Cells[e.RowIndex, e.ColIndex + 1].Value = string.Format("{0:0.00}",
                                        Convert.ToDecimal(orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Value) *
                                        tempProduct.RetailPrice);


                                    totalOrderPrice.Add(-beforeEditValue);
                                    totalOrderItems.Add(-beforeOrderItemQuantity);
                                    totalOrderPrice.Add(
                                        Convert.ToDecimal(orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Value) *
                                        tempProduct.RetailPrice);
                                    totalOrderItems.Add(
                                        Convert.ToInt32(orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Value));

                                    orderTotalItemsTextBox.Text =
                                        string.Format("{0:0}", Enumerable.Sum(totalOrderItems));
                                    tempProductQuantity.Clear();
                                    tempProductQuantityGridLocation.Clear();
                                    tempProductQuantity.Add(tempProduct.ProductId,
                                        Convert.ToInt32(orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Value));
                                    tempProductQuantityGridLocation.Add(e.RowIndex);
                                    tempProductQuantityGridLocation.Add(e.ColIndex);


                                    orderTotalPriceTextBox.Text =
                                        string.Format("{0:0.00}",
                                            Enumerable.Sum(totalOrderPrice) +
                                            Convert.ToDecimal(deliveryFeeTextBox.Text));

                                    if (!productsToEdit.Contains(tempProduct) &&
                                        !ContainsProduct(tempProduct.ProductId.ToString()))
                                    {
                                        productsToEdit.Add(tempProduct);
                                    }

                                    tempProduct = null;

                                    if (e.RowIndex + 1 >= orderItemIgrid.Rows.Count)
                                    {
                                        orderItemIgrid.Rows.Count += 5;
                                        DisableCols(e.RowIndex + 1);
                                        Selectable(e.RowIndex + 1);
                                        orderItemIgrid.Cells[e.RowIndex + 1, e.ColIndex - 6].Selected = true;
                                    }
                                    else
                                    {
                                        Selectable(e.RowIndex + 1);
                                        orderItemIgrid.Cells[e.RowIndex + 1, e.ColIndex - 6].Selected = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this,
                                        "Product is not Enough in Stock, Product Id = " + tempProduct.ProductId +
                                        "\nHas Only " + reservedInventory[tempProduct.ProductId] +
                                        " Available Product(s) in Stock",
                                        "Warning: Not Enough Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    if (reservedInventory[tempProduct.ProductId] >= 1)
                                    {
                                        orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Value =
                                            reservedInventory[tempProduct.ProductId];
                                        reservedInventory[tempProduct.ProductId] =
                                            reservedInventory[tempProduct.ProductId] - beforeOrderItemQuantity;
                                        orderItemIgrid_AfterCommitEdit(sender, e);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (orderItemIgrid.Cells[e.RowIndex, 0].Value != null &&
                                orderItemIgrid.Cells[e.RowIndex, 0].Value.ToString().Length > 0)
                            {
                                MessageBox.Show(this,
                                    "Invalid Quantity Entered, Expected Input:\nInteger Number Greater Than Zero",
                                    "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Value = beforeOrderItemQuantity;
                                orderItemIgrid_AfterCommitEdit(sender, e);
                            }
                            else
                            {
                                orderItemIgrid.Cells[e.RowIndex, e.ColIndex].Value = "";
                                orderItemIgrid.Cells[e.RowIndex, 0].Selected = true;
                            }
                        }
                    }
                }
            }
        }

        private void orderItemIgrid_BeforeCommitEdit(object sender, iGBeforeCommitEditEventArgs e)
        {
            tempProduct = null;
            beforeOrderItemQuantity = 0;
            beforeEditValue = 0;
            if (e.ColIndex == 6 || e.ColIndex == 0)
            {
                if (orderItemIgrid.Cols[7].Cells[e.RowIndex].Value != null &&
                    orderItemIgrid.Cols[7].Cells[e.RowIndex].Value.ToString().Length > 0)
                {
                    beforeEditValue =
                        Convert.ToDecimal(orderItemIgrid.Cols[7].Cells[e.RowIndex].Value.ToString());
                }

                if (orderItemIgrid.Cols[0].Cells[e.RowIndex].Value != null &&
                    orderItemIgrid.Cols[0].Cells[e.RowIndex].Value.ToString().Length > 0 &&
                    orderItemIgrid.Cols[6].Cells[e.RowIndex].Value != null &&
                    orderItemIgrid.Cols[6].Cells[e.RowIndex].Value.ToString().Length > 0)
                {
                    beforeOrderItemQuantity =
                        Convert.ToInt32(orderItemIgrid.Cols[6].Cells[e.RowIndex].Value.ToString());
                    tempProduct = GetProduct(orderItemIgrid.Cols[0].Cells[e.RowIndex].Text);
                }

                if (e.ColIndex == 0)
                {
                    if (tempProduct != null)
                    {
                        reservedInventory[tempProduct.ProductId] += beforeOrderItemQuantity;
                    }

                    totalOrderItems.Add(-beforeOrderItemQuantity);
                    totalOrderPrice.Add(-beforeEditValue);
                    orderTotalPriceTextBox.Text = string.Format("{0:0.00}",
                        Enumerable.Sum(totalOrderPrice) + Convert.ToDecimal(deliveryFeeTextBox.Text));
                    orderTotalItemsTextBox.Text = string.Format("{0:0}", Enumerable.Sum(totalOrderItems));
                }

                tempProduct = null;
            }
        }

        private void AddModifyOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myState == FormState.Add)
            {
                if (!closeButtonSelected)
                {
                    ClosingForm(e);
                }
            }
            else
            {
                if (!saveOrderButtonSelected && !closeButtonSelected)
                {
                    ClosingForm(e);
                }
            }
        }

        private void orderItemIgrid_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownOnIgrid(e);
        }

        private void AdjustCustomerCredit(decimal addToCustomerCredit)
        {
            currentCustomer.CustomerCredit += addToCustomerCredit;
            if (currentCustomer.CustomerCredit > 0)
            {
                currentCustomer.CreditStatus = "Released";
            }
            else
            {
                currentCustomer.CreditStatus = "Onhold";
            }

            customerController.Edit(currentCustomer);
        }

        private void saveOrderButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Add)
            {
                SaveOrder();
            }
            else
            {
                if (orderStatusComboBox.SelectedIndex == (int) Order.OrderStatuses.Completed - 1 &&
                    shippedDateTimePicker.Value.Equals(new DateTime(1800, 1, 1)) && deliveryRadioButton.Checked)
                {
                    MessageBox.Show(this,
                        "Please Enter Order Shipped Date",
                        "Shipped Date Not Entered ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    shippedDateTimePicker.Enabled = true;
                    return;
                }
                else
                {
                    Order order = currentOrder;

                    if (paymentMethodComboBox.Text.Equals("Credit") &&
                        currentOrder.PaymentMethod == Order.PaymentMethods.NotPaid)
                    {
                        orderStatusToBeSetAutomatically = true;
                        order.OrderStatus = Order.OrderStatuses.Confirmed;
                        AdjustCustomerCredit(-currentOrder.OrderTotalPrice);
                    }

                    if ((orderStatusComboBox.Text.Equals("Cancelled") || orderStatusComboBox.Text.Equals("Refunded")) &&
                        currentOrder.PaymentMethod == Order.PaymentMethods.Credit &&
                        (currentOrder.OrderStatus != Order.OrderStatuses.Cancelled ||
                         currentOrder.OrderStatus != Order.OrderStatuses.Refunded))
                    {
                        if (currentCustomer.CustomerCredit < Customer.customerCreditLimit)
                        {
                            AdjustCustomerCredit(currentOrder.OrderTotalPrice);
                        }
                    }

                    if (!orderStatusToBeSetAutomatically)
                    {
                        order.OrderStatus = (Order.OrderStatuses) orderStatusComboBox.SelectedIndex + 1;
                    }

                    if (deliveryRadioButton.Checked)
                    {
                        if (currentCustomer.DeliveryAddress != null)
                        {
                            order.DeliveryAddress = currentCustomer.DeliveryAddress.ToString();
                            if (currentOrder.DeliveryFee < Convert.ToDecimal(deliveryFeeTextBox.Text)
                                && currentOrder.PaymentMethod == Order.PaymentMethods.Credit
                            )
                            {
                                AdjustCustomerCredit(-Convert.ToDecimal(deliveryFeeTextBox.Text));
                            }
                        }
                        else
                        {
                            DialogResult reply = MessageBox.Show(this,
                                "Customer Does Not Have a Delivery Addess\nDo You Want To Add Delivery Address?",
                                "Customer Has No Delivery Address ", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            if (reply == DialogResult.Yes)
                            {
                                AddModifyCustomerFile addModifyCustomerFile =
                                    new AddModifyCustomerFile(customerController);
                                addModifyCustomerFile.CreateAddModifyCustomerForm(currentCustomer);
                                addModifyCustomerFile.Close();
                                return;
                            }

                            collectRadioButton.Checked = true;
                            return;
                        }
                    }
                    else
                    {
                        if (collectRadioButton.Checked)
                        {
                            if (currentOrder.DeliveryFee > Convert.ToDecimal(deliveryFeeTextBox.Text)
                                && currentOrder.PaymentMethod == Order.PaymentMethods.Credit
                            )
                            {
                                AdjustCustomerCredit(currentOrder.DeliveryFee);
                            }

                            order.DeliveryAddress = "";
                        }
                    }

                    order.OrderTotalPrice = Convert.ToDecimal(orderTotalPriceTextBox.Text);
                    order.DeliveryFee = Convert.ToDecimal(deliveryFeeTextBox.Text);
                    order.PaymentMethod = Order.GetPaymentMethod(paymentMethodComboBox.Text);
                    order.ShippedDate = shippedDateTimePicker.Value.Date;
                    order.CompletedDate = completedDateTimePicker.Value.Date;

                    bool success = orderController.Edit(order);
                    if (success)
                    {
                        currentOrder = null;
                        saveOrderButtonSelected = true;
                        Close();
                    }
                }
            }
        }

        private void orderTotalPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (myState == FormState.Add)
            {
                if (Convert.ToDecimal(Enumerable.Sum(totalOrderPrice)) >= freeDeliveryFee)
                {
                    UpdateDeliveryFee();
                }

                if (currentCustomer != null)
                {
                    if (paymentMethodComboBox.Text.Equals("Credit") &&
                        Convert.ToDecimal(orderTotalPriceTextBox.Text) > currentCustomer.CustomerCredit)
                    {
                        MessageBox.Show(this,
                            "Customer Credit Limit Reached,\nOrder Item(s) Adjustment To Follow",
                            "Customer Credit Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tempOrderTotalPrice = Enumerable.Sum(totalOrderPrice);
                        tempReservedInventory = new Dictionary<string, int>(reservedInventory);
                        tempdeliveryFee = Convert.ToDecimal(deliveryFeeTextBox.Text);
                        AdjustOrderItems(1);
                    }
                }
            }
            else
            {
                if (!fistRun)
                {
                    if (paymentMethodComboBox.Text.Equals("Credit") &&
                        Convert.ToDecimal(orderTotalPriceTextBox.Text) > currentCustomer.CustomerCredit)
                    {
                        MessageBox.Show(this,
                            "Customer Credit Limit Reached,\nCustomer Can't Make Order Using Credit",
                            "Insufficient Customer Credit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        paymentMethodComboBox.SelectedText = "Not Paid";
                    }
                }
            }
        }

        private void deliveryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            tempProduct = null;
            UpdateDeliveryFee();
        }

        private void collectRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            tempProduct = null;
            UpdateDeliveryFee();

            if (collectRadioButton.Checked &&
                orderStatusComboBox.SelectedIndex == (int) Order.OrderStatuses.Shipped - 1 && myState == FormState.Edit)
            {
                orderStatusComboBox.SelectedIndex = (int) Order.OrderStatuses.NotShipped - 1;
            }

            if (shippedDateTimePicker.Enabled)
            {
                shippedDateTimePicker.Value = new DateTime(1800, 1, 1).Date;
                shippedDateTimePicker.CustomFormat = " ";
                shippedDateTimePicker.Enabled = false;
            }
        }

        private void paymentMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (paymentMethodComboBox.Text.Equals("Credit"))
            {
                tempProduct = null;
                orderTotalPriceTextBox_TextChanged(sender, e);
            }
        }

        private void customerCreditTextBox_TextChanged(object sender, EventArgs e)
        {
            if (myState == FormState.Add)
            {
                if (paymentMethodComboBox.Text.Equals("Credit"))
                {
                    tempProduct = null;
                    orderTotalPriceTextBox_TextChanged(sender, e);
                }
            }
        }

        private void orderStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fistRun)
            {
                if (shippedDateTimePicker.Enabled)
                {
                    shippedDateTimePicker.Value = new DateTime(1800, 1, 1).Date;
                    shippedDateTimePicker.Enabled = false;
                }

                if (orderStatusComboBox.SelectedIndex != (int) Order.OrderStatuses.Shipped - 1 &&
                    orderStatusComboBox.SelectedIndex != (int) Order.OrderStatuses.Completed - 1)
                {
                    shippedDateTimePicker.CustomFormat = " ";
                    shippedDateTimePicker.Value = new DateTime(1800, 1, 1).Date;
                    deliveryRadioButton.Enabled = true;
                    collectRadioButton.Enabled = true;
                }

                if (orderStatusComboBox.SelectedIndex == (int) Order.OrderStatuses.Completed - 1)
                {
                    completedDateTimePicker.CustomFormat = "dd MMM yyyy";
                    completedDateTimePicker.Value = DateTime.Today.Date;
                    deliveryRadioButton.Enabled = false;
                    collectRadioButton.Enabled = false;
                }
                else
                {
                    if (orderStatusComboBox.SelectedIndex == (int) Order.OrderStatuses.Shipped - 1 &&
                        deliveryRadioButton.Checked)
                    {
                        shippedDateTimePicker.CustomFormat = "dd MMM yyyy";
                        shippedDateTimePicker.Value = DateTime.Today.Date;
                        deliveryRadioButton.Enabled = false;
                        collectRadioButton.Enabled = false;
                    }
                    else
                    {
                        if (orderStatusComboBox.SelectedIndex == (int) Order.OrderStatuses.Shipped - 1)
                        {
                            orderStatusComboBox.SelectedIndex = (int) Order.OrderStatuses.NotShipped - 1;
                        }
                    }
                }

                if (orderStatusComboBox.SelectedIndex == (int) Order.OrderStatuses.PendingPayment - 1 &&
                    paymentMethodComboBox.SelectedIndex == (int) Order.PaymentMethods.Credit)
                {
                    orderStatusComboBox.SelectedIndex = (int) Order.OrderStatuses.Confirmed - 1;
                    deliveryRadioButton.Enabled = true;
                    collectRadioButton.Enabled = true;
                }


                if (orderStatusComboBox.SelectedIndex != (int) Order.OrderStatuses.Completed - 1 &&
                    orderStatusComboBox.SelectedIndex != (int) Order.OrderStatuses.NotShipped - 1)
                {
                    completedDateTimePicker.CustomFormat = " ";
                    completedDateTimePicker.Value = new DateTime(1800, 1, 1).Date;

                    if (orderStatusComboBox.SelectedIndex != (int) Order.OrderStatuses.Shipped - 1)
                    {
                        deliveryRadioButton.Enabled = true;
                        collectRadioButton.Enabled = true;
                    }
                }
                else
                {
                    if (orderStatusComboBox.SelectedIndex == (int) Order.OrderStatuses.NotShipped - 1 &&
                        !collectRadioButton.Checked)
                    {
                        completedDateTimePicker.CustomFormat = " ";
                        completedDateTimePicker.Value = new DateTime(1800, 1, 1).Date;
                        deliveryRadioButton.Enabled = true;
                        collectRadioButton.Enabled = true;
                    }
                }

                if (orderStatusComboBox.SelectedIndex == (int) Order.OrderStatuses.Cancelled - 1 ||
                    orderStatusComboBox.SelectedIndex == (int) Order.OrderStatuses.Refunded - 1)
                {
                    deliveryRadioButton.Enabled = false;
                    collectRadioButton.Enabled = false;
                }
            }
        }

        private void shippedDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (shippedDateTimePicker.Enabled)
            {
                shippedDateTimePicker.CustomFormat = "dd MMM yyyy";
            }
        }

        private void shippedDateTimePicker_Enter(object sender, EventArgs e)
        {
            if (shippedDateTimePicker.Enabled)
            {
                shippedDateTimePicker.Value = DateTime.Today.Date;
            }
        }

        private void shippedDateTimePicker_MouseEnter(object sender, EventArgs e)
        {
            if (shippedDateTimePicker.Enabled)
            {
                shippedDateTimePicker.Value = DateTime.Today.Date;
            }
        }

        private void deleteOrderButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit && currentOrder != null)
            {
                DialogResult reply = MessageBox.Show(this, "Are You Sure You Want To Delete\n" +
                                                           "The Order With Order Id = \"" +
                                                           currentOrder.OrderId +
                                                           "\" ?",
                    "Warning: Delete Order ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (reply == DialogResult.Yes)
                {
                    string sqlQueryOrder = "DELETE FROM OrderTable WHERE [Order_Id] = " +
                                           currentOrder.OrderId.ToString();
                    new OrderController(sqlQueryOrder);

                    bool deletedFromDatabase = false;

                    foreach (OrderItem orderItem in orderItemController.AllOrderItems.ToArray())
                    {
                        if (orderItem.OrderId == currentOrder.OrderId)
                        {
                            if (!deletedFromDatabase)
                            {
                                string sqlQueryOrderItems = "DELETE FROM OrderItem WHERE [Order_Id] = " +
                                                            currentOrder.OrderId.ToString();
                                new OrderItemController(sqlQueryOrderItems);
                                deletedFromDatabase = true;
                            }

                            orderItemController.AllOrderItems.Remove(orderItem);
                        }
                    }

                    orderController.AllOrders.Remove(currentOrder);
                    currentOrder = null;
                    PopulateOrderForm(currentOrder);
                    myState = FormState.Add;
                    FormatForm(myState);
                }
            }
        }

        private void previousOrderButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit)
            {
                if (orderController.AllOrders.Count != 0)
                {
                    if (!endFileBackward &&
                        !orderController.AllOrders[0].OrderId.ToString().ToUpper()
                            .Equals(currentOrder.OrderId.ToString().ToUpper()))
                    {
                        if (orderController.AllOrders.Count != 0)
                        {
                            EditOrder = currentOrder;
                            int currentOrderPosition = orderController.AllOrders.IndexOf(currentOrder);
                            int previouseOrderPosition = currentOrderPosition - 1;
                            currentOrder = orderController.AllOrders[previouseOrderPosition];
                            EditOrder = currentOrder;
                            while (counterPrevious > 0 && currentOrder == null)
                            {
                                previouseOrderPosition--;
                                currentOrder = orderController.AllOrders[previouseOrderPosition];
                                EditOrder = currentOrder;
                            }

                            if (currentOrder != null)
                            {
                                fistRun = true;
                                PopulateOrderForm(currentOrder);
                                endFileForward = false;
                                if (counterForward >= orderController.AllOrders.Count - 1)
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
                                "No Order(s) To Show",
                                "No Order(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        "No Order(s) To Show",
                        "No Order(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                FormatForm(FormState.Edit);
                if (!endFileBackward)
                {
                    if (orderController.AllOrders.Count != 0)
                    {
                        currentOrder = orderController.AllOrders[orderController.AllOrders.Count - 1];
                        EditOrder = currentOrder;
                        if (currentOrder != null)
                        {
                            fistRun = true;
                            PopulateOrderForm(currentOrder);
                            endFileForward = false;
                            if (counterForward >= orderController.AllOrders.Count - 1)
                            {
                                counterForward--;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this,
                            // ReSharper disable once LocalizableElement
                            "No Order(s) To Show",
                            "No Order(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void nextOrderButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit)
            {
                if (orderController.AllOrders.Count != 0)
                {
                    if (!endFileForward &&
                        orderController.AllOrders[orderController.AllOrders.Count - 1].OrderId !=
                        currentOrder.OrderId)
                    {
                        if (orderController.AllOrders.Count != 0)
                        {
                            EditOrder = currentOrder;
                            int currentOrderPosition = orderController.AllOrders.IndexOf(currentOrder);
                            int nextOrderPosition = currentOrderPosition + 1;
                            currentOrder = orderController.AllOrders[nextOrderPosition];
                            EditOrder = currentOrder;
                            while (counterForward < orderController.AllOrders.Count && currentOrder == null)
                            {
                                nextOrderPosition++;
                                currentOrder = orderController.AllOrders[nextOrderPosition];
                                EditOrder = currentOrder;
                            }

                            if (currentOrder != null)
                            {
                                fistRun = true;
                                PopulateOrderForm(currentOrder);
                                endFileBackward = false;
                                if (counterPrevious <= 1)
                                {
                                    counterPrevious++;
                                }

                                if (counterForward >= orderController.AllOrders.Count)
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
                                "No Order(s) To Show",
                                "No Order(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        "No Order(s) To Show",
                        "No Order(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                FormatForm(FormState.Edit);
                if (!endFileForward)
                {
                    if (orderController.AllOrders.Count != 0)
                    {
                        currentOrder = orderController.AllOrders[0];
                        EditOrder = currentOrder;
                        if (currentOrder != null)
                        {
                            fistRun = true;
                            PopulateOrderForm(currentOrder);
                            endFileBackward = false;
                            if (counterPrevious <= orderController.AllOrders.Count - 1)
                            {
                                counterPrevious++;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this,
                            // ReSharper disable once LocalizableElement
                            "No Order(s) To Show",
                            "No Order(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
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