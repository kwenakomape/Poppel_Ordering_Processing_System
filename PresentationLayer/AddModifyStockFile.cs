using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;
using Poppel_Order_Processing_System.Properties;

// ReSharper disable All

namespace Poppel_Order_Processing_System.PresentationLayer
{
    public partial class AddModifyStockFile : Form
    {
        #region Constructors

        public AddModifyStockFile(ProductController productController, Collection<StockCategory> stockCategories)
        {
            InitializeComponent();
            this.Load += AddModifyStockFile_Load;
            this.productController = productController;
            this.StockCategories = stockCategories;
            stockCatergoryComboBox.Items.Add("");
            foreach (StockCategory stockCategory in stockCategories)
            {
                stockCatergoryComboBox.Items.Add(stockCategory.StockCategoryName);
            }

            stockCatergoryComboBox.SelectedIndex = 0;
        }

        #endregion

        #region Fields

        public enum FormState
        {
            Edit = 0,
            Select = 1
        }

        public static FormState myState;
        private AddModifyProductForm addModifyProductForm;
        public bool addModifyStockFileClosed;
        private ProductController productController;
        private Collection<Product> products;
        private PoppelOrderProcessingSystem poppelOrderProcessingSystem;
        private Collection<StockCategory> stockCategories;
        private Product selectedProduct;

        #endregion

        #region Property Methods

        public Product SelectedProduct => selectedProduct;

        public Collection<StockCategory> StockCategories
        {
            get => stockCategories;
            set => stockCategories = value;
        }

        #endregion

        #region Methods

        public void FormatForm(FormState stateValue)
        {
            switch (stateValue)
            {
                case FormState.Edit:
                    myState = stateValue;
                    this.Text = "Stock File";
                    break;
                default:
                    myState = stateValue;
                    this.Text = "Stock File (Select Mode)";
                    modifyStockButton.Image = new Bitmap(Resources.Select);
                    modifyStockButton.Text = "Select";
                    break;
            }
        }

        private void CreateAddModifyProductForm()
        {
            this.addModifyProductForm = new AddModifyProductForm(productController, stockCategories);
            this.addModifyProductForm.FormatForm(AddModifyProductForm.FormState.Add);
            this.Hide();
            this.addModifyProductForm.ShowDialog();
            this.Show();
            Search(false);
        }

        private void CreateAddModifyProductForm(Product product)
        {
            this.addModifyProductForm = new AddModifyProductForm(productController, stockCategories);
            this.addModifyProductForm.EditProduct = product;
            this.addModifyProductForm.FormatForm(AddModifyProductForm.FormState.Edit);
            this.addModifyProductForm.PopulateProductForm(product);
            this.Hide();
            this.addModifyProductForm.ShowDialog();
            this.Show();
            Search(false);
        }

        private void Search(bool applyFilter)
        {
            setUpProductListView(stockCatergoryComboBox.Text.Trim(), stockSearchTextBox.Text.Trim(),
                expiryDateComboBox.Text.Trim(), applyFilter);
        }

        public void setUpProductListView(string categoryFilter, string productId, string expiryDateFilter,
            bool applyFilter)
        {
            ListViewItem productDetails;
            this.products = productController.AllProducts;
            stockFileListView.Clear();
            stockFileListView.Columns.Insert(0, "Product Id", 110, HorizontalAlignment.Left);
            stockFileListView.Columns.Insert(1, "Product Details", 262, HorizontalAlignment.Left);
            stockFileListView.Columns.Insert(2, "Qty", 80, HorizontalAlignment.Left);
            stockFileListView.Columns.Insert(3, "Expiry Date", 123, HorizontalAlignment.Left);
            stockFileListView.Columns.Insert(4, "Retail Price", 75, HorizontalAlignment.Left);
            stockFileListView.Columns.Insert(5, "Cost Price", 75, HorizontalAlignment.Left);
            stockFileListView.Columns.Insert(6, "Profit", 75, HorizontalAlignment.Left);
            stockFileListView.Columns.Insert(7, "Product Category", 110, HorizontalAlignment.Left);

            foreach (Product product in products)
            {
                if (expiryDateFilter.ToUpper().Trim().Equals("YES"))
                {
                    expiryDateFilter = "True";
                }
                else
                {
                    if (expiryDateFilter.ToUpper().Trim().Equals("NO"))
                    {
                        expiryDateFilter = "False";
                    }
                }

                if (product.ProductId.ToString().ToUpper().Contains(productId.ToUpper()) &&
                    (product.ProductCategory.Equals(categoryFilter) || categoryFilter.Equals("")) &&
                    (product.TrackExpiryDate.ToString().Equals(expiryDateFilter) || expiryDateFilter.Equals("")) &&
                    applyFilter)
                {
                    productDetails = new ListViewItem();
                    productDetails.Text = product.ProductId.ToString();
                    productDetails.SubItems.Add(product.ProductDetails);
                    productDetails.SubItems.Add(product.QuantityOnHand.ToString());
                    if (!product.ExpiryDate.Equals(new DateTime(1800, 1, 1)))
                    {
                        productDetails.SubItems.Add(product.ExpiryDate.ToString("dd MMM yyyy"));
                    }
                    else
                    {
                        productDetails.SubItems.Add("");
                    }

                    productDetails.SubItems.Add("R" + string.Format("{0:0.00}", product.RetailPrice));
                    productDetails.SubItems.Add("R" + string.Format("{0:0.00}", product.CostPrice));
                    productDetails.SubItems.Add("R" + string.Format("{0:0.00}",
                        product.RetailPrice - product.CostPrice));
                    productDetails.SubItems.Add(product.ProductCategory);
                    stockFileListView.Items.Add(productDetails);
                }
                else
                {
                    if (!applyFilter)
                    {
                        productDetails = new ListViewItem();
                        productDetails.Text = product.ProductId.ToString();
                        productDetails.SubItems.Add(product.ProductDetails);
                        productDetails.SubItems.Add(product.QuantityOnHand.ToString());
                        if (!product.ExpiryDate.Equals(new DateTime(1800, 1, 1)))
                        {
                            productDetails.SubItems.Add(product.ExpiryDate.ToString("dd MMM yyyy"));
                        }
                        else
                        {
                            productDetails.SubItems.Add("");
                        }

                        productDetails.SubItems.Add("R" + string.Format("{0:0.00}", product.RetailPrice));
                        productDetails.SubItems.Add("R" + string.Format("{0:0.00}", product.CostPrice));
                        productDetails.SubItems.Add("R" + string.Format("{0:0.00}",
                            product.RetailPrice - product.CostPrice));
                        productDetails.SubItems.Add(product.ProductCategory);
                        stockFileListView.Items.Add(productDetails);
                    }
                }
            }

            stockFileListView.Refresh();
            stockFileListView.GridLines = true;
        }

        #endregion

        #region Events

        private void stockFileCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddModifyStockFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (myState == FormState.Edit)
            {
                addModifyStockFileClosed = true;
                ((PoppelOrderProcessingSystem) MdiParent).EnableButtons(true);
            }
        }

        private void newStockButton_Click(object sender, EventArgs e)
        {
            CreateAddModifyProductForm();
        }

        private void modifyStockButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit)
            {
                if (stockFileListView.FocusedItem != null && stockFileListView.SelectedItems.Count > 0)
                {
                    Product product = productController.FindById(stockFileListView.SelectedItems[0].Text);
                    CreateAddModifyProductForm(product);
                }
            }
            else
            {
                if (stockFileListView.FocusedItem != null && stockFileListView.SelectedItems.Count > 0)
                {
                    selectedProduct = productController.FindById(stockFileListView.SelectedItems[0].Text);
                    Close();
                }
            }
        }

        private void AddModifyStockFile_Load(object sender, EventArgs e)
        {
            poppelOrderProcessingSystem = (PoppelOrderProcessingSystem) this.MdiParent;
            stockFileListView.View = View.Details;
            Search(false);
        }

        private void stockSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            Search(true);
        }

        private void stockCatergoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search(true);
        }

        private void expiryDateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search(true);
        }

        private void stockSearchButton_Click(object sender, EventArgs e)
        {
            Search(true);
        }

        private void AddModifyStockFile_Activated(object sender, EventArgs e)
        {
            Search(false);
        }

        private void modifyStockButton_MouseHover(object sender, EventArgs e)
        {
            if (stockFileListView.FocusedItem == null && stockFileListView.Items.Count > 0)
            {
                stockFileListView.Items[0].Selected = true;
                stockFileListView.Items[0].Focused = true;
                stockFileListView.Select();
            }
        }

        #endregion
    }
}