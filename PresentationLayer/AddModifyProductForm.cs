using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;

// ReSharper disable All

namespace Poppel_Order_Processing_System.PresentationLayer
{
    public partial class AddModifyProductForm : Form
    {
        #region Constructors

        public AddModifyProductForm(ProductController productController, Collection<StockCategory> stockCategories)
        {
            InitializeComponent();
            this.productController = productController;
            this.numbOfProd = productController.AllProducts.Count;
            this.counterPrevious = numbOfProd;
            this.counterForward = 0;
            profitTextBox.ReadOnly = true;
            expiryDateTimePicker.CustomFormat = " ";
            productCategoryComboBox.Items.Add("");
            foreach (StockCategory stockCategory in stockCategories)
            {
                productCategoryComboBox.Items.Add(stockCategory.StockCategoryName);
            }

            /*if (productCategoryComboBox.Items.Count > 0)
            {
                productCategoryComboBox.SelectedIndex = 0;
            }*/
        }

        #endregion

        #region Fields

        private ProductController productController;
        private Product currentProduct;
        private Product editProduct;
        private Collection<StockCategory> stockCategories;

        public static FormState myState;
        bool endFileForward = false;
        bool endFileBackward = false;
        private int numbOfProd;
        private int counterPrevious;
        private int counterForward;
        private bool firstTime = true;

        public enum FormState
        {
            Add = 0,
            Edit = 1
        }

        #endregion

        #region Property Methods

        public Collection<StockCategory> StockCategories
        {
            get => stockCategories;
            set => stockCategories = value;
        }

        public Product EditProduct
        {
            get => editProduct;
            set => editProduct = value;
        }

        #endregion

        #region Methods

        public void FormatForm(FormState stateValue)
        {
            switch (stateValue)
            {
                case FormState.Add:
                    myState = stateValue;
                    this.Text = "Product Maintenance (Add New)";
                    break;
                default:
                    myState = stateValue;
                    this.Text = "Product Maintenance (Edit Mode)";
                    break;
            }
        }

        public void PopulateProductForm(Product product)
        {
            if (product != null)
            {
                this.currentProduct = product;
                trackExpiryDateCheckBox.Checked = product.TrackExpiryDate;
                productIdTextBox.Text = product.ProductId;
                if (product.TrackExpiryDate == true)
                {
                    expiryDateTimePicker.Value = product.ExpiryDate.Date;
                    expiryDateTimePicker.CustomFormat = "dd MMM yyyy";
                }

                productDetailsTextBox.Text = product.ProductDetails;
                retailPriceTextBox.Text = string.Format("{0:0.00}", Convert.ToDecimal(product.RetailPrice.ToString()));
                costPriceTextBox.Text = string.Format("{0:0.00}", Convert.ToDecimal(product.CostPrice.ToString()));
                profitTextBox.Text = string.Format("{0:0.00}",
                    Convert.ToDecimal((product.RetailPrice - product.CostPrice).ToString()));
                productCategoryComboBox.Text = product.ProductCategory;
                quantityOnHandTextBox.Text = product.QuantityOnHand.ToString();
            }
            else
            {
                productIdTextBox.Text = "";
                productDetailsTextBox.Text = "";
                expiryDateTimePicker.CustomFormat = " ";
                retailPriceTextBox.Text = string.Format("{0:0.00}", Convert.ToDecimal("0"));
                retailPriceTextBox.Text = string.Format("{0:0.00}", Convert.ToDecimal("0"));
                retailPriceTextBox.Text = string.Format("{0:0.00}", Convert.ToDecimal("0"));
                productCategoryComboBox.Text = "";
                quantityOnHandTextBox.Text = "0";
                trackExpiryDateCheckBox.Checked = true;
            }
        }

        public Product PopulateProduct()
        {
            Product product = new Product();
            if (!productIdTextBox.Text.Trim().Equals(""))
            {
                product.ProductId = productIdTextBox.Text.Trim();
                product.ProductDetails = productDetailsTextBox.Text.Trim();
                if (trackExpiryDateCheckBox.Checked)
                {
                    if (!expiryDateTimePicker.Value.Equals(new DateTime(1800, 1, 1)))
                    {
                        product.ExpiryDate = expiryDateTimePicker.Value;
                        product.TrackExpiryDate = true;
                    }
                    else
                    {
                        MessageBox.Show(this,
                            // ReSharper disable once LocalizableElement
                            "Please Select Expiry Date",
                            "Expiry Date Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                }

                product.RetailPrice = Convert.ToDecimal(retailPriceTextBox.Text.Trim());
                product.CostPrice = Convert.ToDecimal(costPriceTextBox.Text.Trim());
                if (productCategoryComboBox.Text.Trim().Equals(""))
                {
                    product.ProductCategory = "Other";
                }
                else
                {
                    product.ProductCategory = productCategoryComboBox.Text.Trim();
                }
                
                return product;
            }
            else
            {
                MessageBox.Show(this,
                    // ReSharper disable once LocalizableElement
                    "Please Enter A Valid Product Id ,\nProduct Id Field Is Required",
                    "Product Id Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        public Product PopulateProduct(Product aProduct)
        {
            Product product = aProduct;
            if (!productIdTextBox.Text.Trim().Equals(""))
            {
                product.ProductId = productIdTextBox.Text.Trim();
                product.ProductDetails = productDetailsTextBox.Text.Trim();
                if (trackExpiryDateCheckBox.Checked)
                {
                    if (!expiryDateTimePicker.Value.Equals(new DateTime(1800, 1, 1)))
                    {
                        product.ExpiryDate = expiryDateTimePicker.Value;
                        product.TrackExpiryDate = true;
                    }
                    else
                    {
                        MessageBox.Show(this,
                            // ReSharper disable once LocalizableElement
                            "Please Select Expiry Date",
                            "Expiry Date Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                }
                else
                {
                    product.ExpiryDate = expiryDateTimePicker.Value;
                    product.TrackExpiryDate = false;
                }

                decimal retail;
                if (decimal.TryParse(retailPriceTextBox.Text.Trim(), out retail) && retail > 0)
                {
                    product.RetailPrice = Convert.ToDecimal(retailPriceTextBox.Text.Trim());
                }
                else
                {
                    MessageBox.Show(this,
                        // ReSharper disable once LocalizableElement
                        "Please Enter A Invalid Retail Price,\nExpected Input: Positive Decimal/Integer Number",
                        "Invalid Retail Price Entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                decimal cost;
                if (decimal.TryParse(costPriceTextBox.Text.Trim(), out cost) && cost > 0)
                {
                    product.CostPrice = Convert.ToDecimal(costPriceTextBox.Text.Trim());
                }
                else
                {
                    MessageBox.Show(this,
                        // ReSharper disable once LocalizableElement
                        "Please Enter A Invalid Cost Price,\nExpected Input: Positive Decimal/Integer Number",
                        "Invalid Cost Price Entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                if (productCategoryComboBox.Text.Trim().Equals(""))
                {
                    product.ProductCategory = "Other";
                }
                else
                {
                    product.ProductCategory = productCategoryComboBox.Text.Trim();
                }
                return product;
            }
            else
            {
                MessageBox.Show(this,
                    // ReSharper disable once LocalizableElement
                    "Please Enter A Valid Product Id,\nProduct Id Field Is Required",
                    "Product Id Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        private void UpdateProfit()
        {
            profitTextBox.Text = string.Format("{0:0.00}",
                Convert.ToDecimal(retailPriceTextBox.Text) - Convert.ToDecimal(costPriceTextBox.Text));
        }

        private void LeaveControl()
        {
            foreach (var prod in productController.AllProducts)
            {
                if (prod.ProductId.ToUpper().Equals(productIdTextBox.Text.ToUpper()))
                {
                    if (myState == FormState.Add)
                    {
                        myState = FormState.Edit;
                        EditProduct = prod;
                        FormatForm(myState);
                        PopulateProductForm(EditProduct);
                        break;
                    }
                    else
                    {
                        if (EditProduct != null && !prod.ProductId.ToUpper().Equals(EditProduct.ProductId.ToUpper()))
                        {
                            DialogResult result = MessageBox.Show(this,
                                "This Product Id Is Already Used For Another Product, Recall ?",
                                "Product Id Already Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                            if (result == DialogResult.Yes)
                            {
                                EditProduct = prod;
                                PopulateProductForm(EditProduct);
                            }
                            else
                            {
                                productIdTextBox.Text = EditProduct.ProductId;
                            }

                            break;
                        }
                    }
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

        #endregion

        #region Events

        private void expiryDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            expiryDateTimePicker.CustomFormat = "dd MMM yyyy";
        }

        private void trackExpiryDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (trackExpiryDateCheckBox.Checked)
            {
                expiryDateTimePicker.Value = DateTime.Today;
                expiryDateTimePicker.CustomFormat = " ";
                expiryDateTimePicker.Enabled = true;
            }
            else
            {
                expiryDateTimePicker.Value = new DateTime(1800, 1, 1);
                expiryDateTimePicker.CustomFormat = " ";
                expiryDateTimePicker.Enabled = false;
            }
        }

        private void saveProductButton_Click(object sender, EventArgs e)
        {
            if (EditProduct == null) myState = FormState.Add;
            if (myState == FormState.Add)
            {
                Product product = PopulateProduct();
                if (product != null)
                {
                    bool success = productController.Add(product);
                    if (success)
                    {
                        string sqlQuery = "SELECT TOP 1 * FROM Product ORDER BY [Product_Table_Id] DESC";
                        productController.AllProducts.Add(new ProductController(sqlQuery).Product);
                        this.Close();
                    }
                }
            }
            else
            {
                Product product = PopulateProduct(EditProduct);
                if (product != null)
                {
                    bool success = productController.Edit(product);
                    if (success)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void previousProductButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit)
            {
                if (productController.AllProducts.Count != 0)
                {
                    if (!endFileBackward &&
                        !productController.AllProducts[0].ProductId.ToUpper()
                            .Equals(currentProduct.ProductId.ToUpper()))
                    {
                        if (productController.AllProducts.Count != 0)
                        {
                            EditProduct = currentProduct;
                            int currentProductPosition = productController.AllProducts.IndexOf(currentProduct);
                            int previouseProductPosition = currentProductPosition - 1;
                            currentProduct = productController.AllProducts[previouseProductPosition];
                            EditProduct = currentProduct;
                            while (counterPrevious > 0 && currentProduct == null)
                            {
                                previouseProductPosition--;
                                currentProduct = productController.AllProducts[previouseProductPosition];
                                EditProduct = currentProduct;
                            }

                            if (currentProduct != null)
                            {
                                PopulateProductForm(currentProduct);
                                endFileForward = false;
                                if (counterForward >= productController.AllProducts.Count - 1)
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
                                "No Products To Show",
                                "No Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        "No Products To Show",
                        "No Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                FormatForm(FormState.Edit);
                if (!endFileBackward)
                {
                    if (productController.AllProducts.Count != 0)
                    {
                        currentProduct = productController.AllProducts[productController.AllProducts.Count - 1];
                        EditProduct = currentProduct;
                        if (currentProduct != null)
                        {
                            PopulateProductForm(currentProduct);
                            endFileForward = false;
                            if (counterForward >= productController.AllProducts.Count - 1)
                            {
                                counterForward--;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this,
                            // ReSharper disable once LocalizableElement
                            "No Products To Show",
                            "No Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void nextProductButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit)
            {
                if (productController.AllProducts.Count != 0)
                {
                    if (!endFileForward &&
                        productController.AllProducts[productController.AllProducts.Count - 1].ProductId !=
                        currentProduct.ProductId)
                    {
                        if (productController.AllProducts.Count != 0)
                        {
                            EditProduct = currentProduct;
                            int currentProductPosition = productController.AllProducts.IndexOf(currentProduct);
                            int nextProductPosition = currentProductPosition + 1;
                            currentProduct = productController.AllProducts[nextProductPosition];
                            EditProduct = currentProduct;
                            while (counterForward < productController.AllProducts.Count && currentProduct == null)
                            {
                                nextProductPosition++;
                                currentProduct = productController.AllProducts[nextProductPosition];
                                EditProduct = currentProduct;
                            }

                            if (currentProduct != null)
                            {
                                PopulateProductForm(currentProduct);
                                endFileBackward = false;
                                if (counterPrevious <= 1)
                                {
                                    counterPrevious++;
                                }

                                if (counterForward >= productController.AllProducts.Count)
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
                                "No Products To Show",
                                "No Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        "No Products To Show",
                        "No Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                FormatForm(FormState.Edit);
                if (!endFileForward)
                {
                    if (productController.AllProducts.Count != 0)
                    {
                        currentProduct = productController.AllProducts[0];
                        EditProduct = currentProduct;
                        if (currentProduct != null)
                        {
                            PopulateProductForm(currentProduct);
                            endFileBackward = false;
                            if (counterPrevious <= productController.AllProducts.Count - 1)
                            {
                                counterPrevious++;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this,
                            // ReSharper disable once LocalizableElement
                            "No Products To Show",
                            "No Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Edit && EditProduct != null)
            {
                DialogResult reply = MessageBox.Show(this, "Are You Sure You Want To Delete\n" +
                                                           "The Product With Product Id = \"" +
                                                           EditProduct.ProductId +
                                                           "\" ?",
                    "Warning: Delete Product ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (reply == DialogResult.Yes)
                {
                    string sqlQuery = "DELETE FROM Product WHERE [Product_Table_Id] = " +
                                      EditProduct.ProductTableId.ToString();
                    new ProductController(sqlQuery);
                    productController.AllProducts.Remove(EditProduct);
                    EditProduct = null;
                    PopulateProductForm(EditProduct);
                    myState = FormState.Add;
                    FormatForm(myState);
                }
            }
        }

        private void closeProductFormButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void productIdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownOnControl(e);
        }

        private void retailPriceTextBox_Leave(object sender, EventArgs e)
        {
            UpdateProfit();
        }

        private void costPriceTextBox_Leave(object sender, EventArgs e)
        {
            UpdateProfit();
        }

        private void productIdTextBox_Leave(object sender, EventArgs e)
        {
            LeaveControl();
        }

        private void productDetailsTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownOnControl(e);
        }

        private void expiryDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownOnControl(e);
        }

        private void expiryDateTimePicker_MouseEnter(object sender, EventArgs e)
        {
            if (firstTime && myState != FormState.Edit)
            {
                expiryDateTimePicker.Value = DateTime.Today;
                firstTime = false;
            }
        }

        private void retailPriceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownOnControl(e);
        }

        private void costPriceTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownOnControl(e);
        }

        private void productCategoryComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownOnControl(e);
        }

        private void quantityOnHandTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownOnControl(e);
        }

        private void trackExpiryDateCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownOnControl(e);
        }

        private void profitTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownOnControl(e);
        }

        private void expiryDateTimePicker_Enter(object sender, EventArgs e)
        {
            if (firstTime && myState != FormState.Edit)
            {
                expiryDateTimePicker.Value = DateTime.Today;
                firstTime = false;
            }
        }

        #endregion
    }
}