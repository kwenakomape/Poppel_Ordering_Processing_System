using System.Collections.ObjectModel;
using Poppel_Order_Processing_System.DatabaseLayer;
using Poppel_Order_Processing_System.Properties;

// ReSharper disable All

namespace Poppel_Order_Processing_System.BusinessLayer
{
    public class StockCategoryController
    {
        #region Fields

        private StockCategoryInfoDB stockCategoryInfoDb;
        private Collection<StockCategory> stockCategories;
        private StockCategory stockCategory;

        #endregion

        #region Constructors

        public StockCategoryController()
        {
            this.stockCategoryInfoDb =
                new StockCategoryInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString);
            this.stockCategories = stockCategoryInfoDb.AllStockCategories;
        }

        public StockCategoryController(string sqlQuery)
        {
            this.stockCategoryInfoDb =
                new StockCategoryInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString, sqlQuery);
            this.stockCategory = stockCategoryInfoDb.StockCategory;
        }

        #endregion

        #region Property Methods

        public StockCategory StockCategory => stockCategory;
        public Collection<StockCategory> AllStockCategories => stockCategories;

        #endregion

        #region Methods

        public bool Add(StockCategory aStockCategory)
        {
            return stockCategoryInfoDb.DatabaseAdd(aStockCategory);
        }

        public bool Edit(StockCategory aStockCategory)
        {
            return stockCategoryInfoDb.DatabaseEdit(aStockCategory);
        }

        public StockCategory FindByID(string id)
        {
            if (stockCategories.Count > 0)
            {
                int position = 0;
                bool found = id.Equals(stockCategories[position].StockCategoryId.ToString());
                if (!found)
                {
                    position++;
                }

                while (!found && position < stockCategories.Count)
                {
                    found = id.Equals(stockCategories[position].StockCategoryId.ToString());
                    if (found)
                    {
                        break;
                    }

                    position++;
                }

                if (found)
                {
                    return stockCategories[position];
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        #endregion
    }
}