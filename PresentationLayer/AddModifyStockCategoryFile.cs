using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Poppel_Order_Processing_System.BusinessLayer;

// ReSharper disable All

namespace Poppel_Order_Processing_System.PresentationLayer
{
    public partial class AddModifyStockCategoryFile : Form
    {
        #region Constructors

        public AddModifyStockCategoryFile(StockCategoryController stockCategoryController)
        {
            InitializeComponent();
            this.Load += AddModifyStockCategoryFile_Load;
            this.stockCategoryController = stockCategoryController;
        }

        #endregion

        #region Fields

        private StockCategoryController stockCategoryController;
        private AddModifyStorkCategoryForm addModifyStorkCategoryForm;
        private StockCategory editStockCategory;
        private Collection<StockCategory> stockCategories;
        public bool addModifyStockCategoryFileClosed;

        #endregion

        #region Methods

        private void CreateAddModifyStockCategoryForm()
        {
            this.addModifyStorkCategoryForm = new AddModifyStorkCategoryForm(stockCategoryController);
            this.addModifyStorkCategoryForm.FormatForm(AddModifyStorkCategoryForm.FormState.Add);
            this.Hide();
            this.addModifyStorkCategoryForm.ShowDialog();
            this.Show();
            setUpStockCategoryListView();
        }

        private void CreateAddModifyStockCategoryForm(StockCategory stockCategory)
        {
            this.addModifyStorkCategoryForm = new AddModifyStorkCategoryForm(stockCategoryController);
            this.addModifyStorkCategoryForm.EditStockCategory = stockCategory;
            this.addModifyStorkCategoryForm.FormatForm(AddModifyStorkCategoryForm.FormState.Edit);
            this.addModifyStorkCategoryForm.PopulateStockCategoryForm(stockCategory);
            this.Hide();
            this.addModifyStorkCategoryForm.ShowDialog();
            this.Show();
            setUpStockCategoryListView();
        }

        public void setUpStockCategoryListView()
        {
            ListViewItem stockCategoryDetails;
            this.stockCategories = stockCategoryController.AllStockCategories;
            stockCategoryListView.Clear();
            stockCategoryListView.Columns.Insert(0, "Category Id", 80, HorizontalAlignment.Left);
            stockCategoryListView.Columns.Insert(1, "Category Name", 165, HorizontalAlignment.Left);
            foreach (StockCategory stockCategory in stockCategories)
            {
                stockCategoryDetails = new ListViewItem();
                stockCategoryDetails.Text = stockCategory.StockCategoryId.ToString();
                stockCategoryDetails.SubItems.Add(stockCategory.StockCategoryName);
                stockCategoryListView.Items.Add(stockCategoryDetails);
            }

            stockCategoryListView.Refresh();
        }

        #endregion

        #region Events

        private void modifyStockCategoryButton_Click(object sender, EventArgs e)
        {
            if (editStockCategory != null)
            {
                CreateAddModifyStockCategoryForm(editStockCategory);
            }
        }

        private void newStockCategoryButton_Click(object sender, EventArgs e)
        {
            CreateAddModifyStockCategoryForm();
        }

        private void deleteStockCategoryButton_Click(object sender, EventArgs e)
        {
            if (editStockCategory != null)
            {
                DialogResult reply = MessageBox.Show(this, "Are You Sure You Want To Delete\n" +
                                                           "The Stock Category With Category Id = \"" +
                                                           editStockCategory.StockCategoryId +
                                                           "\" ?",
                    "Warning: Delete Stock Category ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (reply == DialogResult.Yes)
                {
                    string sqlQuery = "DELETE FROM StockCategory WHERE [Category Id] = " +
                                      editStockCategory.StockCategoryId;
                    new StockCategoryController(sqlQuery);
                    stockCategoryController.AllStockCategories.Remove(editStockCategory);
                    editStockCategory = null;
                    setUpStockCategoryListView();
                }
            }
        }

        private void closeStockCategoryFormButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void modifyStockCategoryButton_MouseHover(object sender, EventArgs e)
        {
            if (stockCategoryListView.FocusedItem == null && stockCategoryListView.Items.Count > 0)
            {
                stockCategoryListView.Items[0].Selected = true;
                stockCategoryListView.Items[0].Focused = true;
                stockCategoryListView.Select();
            }
            else
            {
                if (stockCategoryListView.Items.Count > 0 && stockCategoryListView.SelectedItems.Count == 0)
                {
                    stockCategoryListView.FocusedItem.Selected = true;
                    stockCategoryListView.FocusedItem.Focused = true;
                    stockCategoryListView.Select();
                }

                if (stockCategoryListView.SelectedItems.Count > 0)
                {
                    StockCategory stockCategory =
                        stockCategoryController.FindByID(stockCategoryListView.SelectedItems[0].Text);
                    editStockCategory = stockCategory;
                }
            }
        }

        private void deleteStockCategoryButton_MouseHover(object sender, EventArgs e)
        {
            if (stockCategoryListView.FocusedItem == null && stockCategoryListView.Items.Count > 0)
            {
                stockCategoryListView.Items[0].Selected = true;
                stockCategoryListView.Items[0].Focused = true;
                stockCategoryListView.Select();
            }
            else
            {
                if (stockCategoryListView.Items.Count > 0 && stockCategoryListView.SelectedItems.Count == 0)
                {
                    stockCategoryListView.FocusedItem.Selected = true;
                    stockCategoryListView.FocusedItem.Focused = true;
                    stockCategoryListView.Select();
                }

                if (stockCategoryListView.SelectedItems.Count > 0)
                {
                    editStockCategory = stockCategoryController.FindByID(stockCategoryListView.SelectedItems[0].Text);
                }
            }
        }

        private void AddModifyStockCategoryFile_Load(object sender, EventArgs e)
        {
            stockCategoryListView.View = View.Details;
            setUpStockCategoryListView();
        }

        private void AddModifyStockCategoryFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            addModifyStockCategoryFileClosed = true;
            ((PoppelOrderProcessingSystem) MdiParent).EnableButtons(true);
        }

        #endregion
    }
}