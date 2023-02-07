using System;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;

// ReSharper disable All

namespace Poppel_Order_Processing_System.PresentationLayer
{
    public partial class AddModifyStorkCategoryForm : Form
    {
        #region Constructors

        public AddModifyStorkCategoryForm(StockCategoryController stockCategoryController)
        {
            InitializeComponent();
            this.stockCategoryController = stockCategoryController;
        }

        #endregion

        #region Property Methods

        public StockCategory EditStockCategory
        {
            get => editStockCategory;
            set => editStockCategory = value;
        }

        #endregion

        #region Fields

        private StockCategory editStockCategory;
        private StockCategoryController stockCategoryController;
        public static FormState myState;

        public enum FormState
        {
            Add = 0,
            Edit = 1,
        }

        #endregion

        #region Methods

        public void FormatForm(FormState stateValue)
        {
            switch (stateValue)
            {
                case FormState.Add:
                    myState = stateValue;
                    this.Text = "Category Maintenance (Add New)";
                    break;
                default:
                    myState = stateValue;
                    this.Text = "Category Maintenance (Edit Mode)";
                    break;
            }
        }

        public void PopulateStockCategoryForm(StockCategory stockCategory)
        {
            stockCategoryTextBox.Text = stockCategory.StockCategoryName;
        }

        public StockCategory PopulateStockCategory(StockCategory aStockCategory)
        {
            StockCategory stockCategory = aStockCategory;
            if (!stockCategoryTextBox.Text.Trim().Equals(""))
            {
                stockCategory.StockCategoryName = stockCategoryTextBox.Text.Trim();
                return stockCategory;
            }
            else
            {
                MessageBox.Show(this,
                    // ReSharper disable once LocalizableElement
                    "Please Enter A Valid Stock Category Name,\nStock Category Name Field Is Required",
                    "Stock Category Name Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        public StockCategory PopulateStockCategory()
        {
            StockCategory stockCategory = new StockCategory();
            if (!stockCategoryTextBox.Text.Trim().Equals(""))
            {
                stockCategory.StockCategoryName = stockCategoryTextBox.Text.Trim();
                return stockCategory;
            }
            else
            {
                MessageBox.Show(this,
                    // ReSharper disable once LocalizableElement
                    "Please Enter A Valid Stock Category Name,\nStock Category Name Field Is Required",
                    "Stock Category Name Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
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

        private void saveStorkCategoryButton_Click(object sender, EventArgs e)
        {
            if (myState == FormState.Add)
            {
                StockCategory stockCategory = PopulateStockCategory();
                if (stockCategory != null)
                {
                    bool success = stockCategoryController.Add(stockCategory);
                    if (success)
                    {
                        string sqlQuery = "SELECT TOP 1 * FROM StockCategory ORDER BY [Category Id] DESC";
                        stockCategoryController.AllStockCategories.Add(new StockCategoryController(sqlQuery)
                            .StockCategory);
                        Close();
                    }
                }
            }
            else
            {
                StockCategory stockCategory = PopulateStockCategory(EditStockCategory);
                if (stockCategory != null)
                {
                    bool success = stockCategoryController.Edit(stockCategory);
                    if (success)
                    {
                        Close();
                    }
                }
            }
        }

        private void closeStorkCategoryFormButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddModifyStorkCategoryForm_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownOnControl(e);
        }

        #endregion
    }
}