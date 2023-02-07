using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;
using Poppel_Order_Processing_System.PresentationLayer.Reports;

// ReSharper disable All

namespace Poppel_Order_Processing_System.PresentationLayer
{
    public partial class PoppelOrderProcessingSystem : Form
    {
        #region Constructors

        public PoppelOrderProcessingSystem()
        {
            InitializeComponent();
            this.customerController = new CustomerController();
            this.productController = new ProductController();
            this.stockCategoryController = new StockCategoryController();
            this.orderController = new OrderController();
            this.orderItemController = new OrderItemController();
        }

        #endregion

        #region Property Methods

        public AddModifyCustomerFile AddModifyCustomerFile => addModifyCustomerFile;

        #endregion


        #region Fields

        // Child Forms
        private AddModifyCustomerFile addModifyCustomerFile;
        private AddModifyStockFile addModifyStockFile;
        private AddModifyOrderFile addModifyOrderFile;
        private AddModifyStockCategoryFile addModifyStockCategoryFile;
        private StockQuantityAdjustment stockQuantityAdjustment;
        private ExpiredProductReport expiredProductReport;
        private OrderPickingList orderPickingList;
        // Controllers
        private CustomerController customerController;
        private ProductController productController;
        private StockCategoryController stockCategoryController;
        private OrderController orderController;
        private OrderItemController orderItemController;

        #endregion

        #region Methods
        private void CreateOrderPickingList(Order order)
        {
            this.orderPickingList = new OrderPickingList(addModifyOrderFile.SelectedOrder);
            this.orderPickingList.MdiParent = this;
            this.orderPickingList.StartPosition = FormStartPosition.Manual;
            this.orderPickingList.Location = new Point(0, 0);
            this.orderPickingList.Show();
        }

        private void CreateExpiredProductReport()
        {
            this.expiredProductReport = new ExpiredProductReport();
            this.expiredProductReport.MdiParent = this;
            this.expiredProductReport.StartPosition = FormStartPosition.Manual;
            this.expiredProductReport.Location = new Point(0, 0);
            this.expiredProductReport.Show();
        }

        private void CreateAddModifyStockCategoryFile()
        {
            this.addModifyStockCategoryFile = new AddModifyStockCategoryFile(stockCategoryController);

            this.addModifyStockCategoryFile.MdiParent = this;
            this.addModifyStockCategoryFile.Show();
        }

        private void CreateAddModifyCustomerFileForm()
        {
            this.addModifyCustomerFile = new AddModifyCustomerFile(this.customerController);
            this.addModifyCustomerFile.Orders = orderController.AllOrders;
            this.addModifyCustomerFile.FormatForm(AddModifyCustomerFile.FormState.Edit);
            this.addModifyCustomerFile.MdiParent = this;
            this.addModifyCustomerFile.Show();
        }

        private void CreateAddModifyStockFileForm()
        {
            this.addModifyStockFile =
                new AddModifyStockFile(productController, stockCategoryController.AllStockCategories);
            this.addModifyStockFile.FormatForm(AddModifyStockFile.FormState.Edit);
            this.addModifyStockFile.MdiParent = this;
            this.addModifyStockFile.Show();
        }

        private void CreateAddModifyOrderFileForm()
        {
            this.addModifyOrderFile = new AddModifyOrderFile(productController, customerController, orderController,
                orderItemController);
            this.addModifyOrderFile.FormatForm(AddModifyOrderFile.FormState.Edit);
            this.addModifyOrderFile.StockCategories = stockCategoryController.AllStockCategories;
            this.addModifyOrderFile.MdiParent = this;
            this.addModifyOrderFile.Show();
        }

        private void CreateAddModifyOrderFileForm(AddModifyOrderFile.FormState formState)
        {
            this.addModifyOrderFile = new AddModifyOrderFile(productController, customerController, orderController,
                orderItemController);
            this.addModifyOrderFile.FormatForm(formState);
            this.addModifyOrderFile.StockCategories = stockCategoryController.AllStockCategories;
            this.addModifyOrderFile.ShowDialog();
            this.addModifyOrderFile.addModifyOrderFileClosed = true;
        }

        public void CreateStockQuantityAdjustment()
        {
            this.stockQuantityAdjustment = new StockQuantityAdjustment(productController);
            this.stockQuantityAdjustment.StockCategories = stockCategoryController.AllStockCategories;
            this.stockQuantityAdjustment.MdiParent = this;
            this.stockQuantityAdjustment.Show();
        }

        public void EnableButtons(bool enable)
        {
            orderToolStripMenuItem.Enabled = enable;
            customerToolStripMenuItem.Enabled = enable;
            stockToolStripMenuItem.Enabled = enable;
            helpMenu.Enabled = enable;

            addModifyOrderToolStripButton.Enabled = enable;
            addModifyCustomerToolStripButton.Enabled = enable;
            addModifyStockToolStripButton.Enabled = enable;
            helpToolStripButton.Enabled = enable;
            aboutToolStripButton.Enabled = enable;
            exitSystemToolStripButton.Enabled = enable;
        }

        public void EnableGeneratePickingListButton(bool enable)
        {
            generatePickingListToolStripButton.Enabled = enable;
            generatePickingListToolStripMenuItem.Enabled = enable;
        }
        private void StockQuantityAdjustment()
        {
            if (stockQuantityAdjustment == null || stockQuantityAdjustment.stockQuantityAdjustmentClosed)
            {
                CreateStockQuantityAdjustment();
            }
        }

        private void AddModifyCustomer()
        {
            if (addModifyCustomerFile == null || addModifyCustomerFile.addModifyCustomerFileClosed)
            {
                CreateAddModifyCustomerFileForm();
                EnableButtons(false);
            }
        }

        private void OrderPickingList(Order order)
        {
            if (orderPickingList == null || orderPickingList.orderPickingListClosed)
            {
                CreateOrderPickingList(order);
                EnableGeneratePickingListButton(false);
            }
        }

        private void ExpiredProductReport()
        {
            if (expiredProductReport == null || expiredProductReport.expiredProductReportClosed)
            {
                CreateExpiredProductReport();
            }
        }

        private void AddModifyStockCategory()
        {
            if (addModifyStockCategoryFile == null || addModifyStockCategoryFile.addModifyStockCategoryFileClosed)
            {
                CreateAddModifyStockCategoryFile();
                EnableButtons(false);
            }
        }

        private void AddModifyStock()
        {
            if (addModifyStockFile == null || addModifyStockFile.addModifyStockFileClosed)
            {
                CreateAddModifyStockFileForm();
                EnableButtons(false);
            }
        }

        private void AddModifyOrder()
        {
            if (addModifyOrderFile == null || addModifyOrderFile.addModifyOrderFileClosed)
            {
                CreateAddModifyOrderFileForm();
                EnableButtons(false);
            }
        }

        #endregion

        #region MenuStrips

        private void addModifyCustomerToolStripButton_Click(object sender, EventArgs e)
        {
            AddModifyCustomer();
        }

        private void addModifyCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddModifyCustomer();
        }

        private void addModifyStockToolStripButton_Click(object sender, EventArgs e)
        {
            AddModifyStock();
        }

        private void addModifyStockkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddModifyStock();
        }


        private void addModifyOrderToolStripButton_Click(object sender, EventArgs e)
        {
            AddModifyOrder();
        }

        private void addModifyOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddModifyOrder();
        }

        private void calculatorToolStripButton_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void exitSystemToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddModifyCustomer();
        }

        private void listStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddModifyStock();
        }

        private void stockCatergoryMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddModifyStockCategory();
        }

        private void stockAdjastmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockQuantityAdjustment();
        }

        private void generatePickingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAddModifyOrderFileForm(AddModifyOrderFile.FormState.Select);
            if (addModifyOrderFile.SelectedOrder != null)
            {
                OrderPickingList(addModifyOrderFile.SelectedOrder);
                addModifyOrderFile.SelectedOrder = null;
            }
           
        }

        private void expiredSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpiredProductReport();
        }
        private void generatePickingListToolStripButton_Click(object sender, EventArgs e)
        {
            CreateAddModifyOrderFileForm(AddModifyOrderFile.FormState.Select);
            if (addModifyOrderFile.SelectedOrder != null)
            {
                OrderPickingList(addModifyOrderFile.SelectedOrder);
                addModifyOrderFile.SelectedOrder = null;
            }
        }
        private void listOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddModifyOrder();
        }

        private void dailySalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}