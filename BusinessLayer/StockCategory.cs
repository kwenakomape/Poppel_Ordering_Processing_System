// ReSharper disable All

namespace Poppel_Order_Processing_System.BusinessLayer
{
    public class StockCategory
    {
        #region Constructors

        public StockCategory()
        {
            this.stockCategoryId = -1;
            this.stockCategoryName = "";
        }

        #endregion

        #region Fields

        private int stockCategoryId;
        private string stockCategoryName;

        #endregion

        #region Property Methods

        public int StockCategoryId
        {
            get => stockCategoryId;
            set => stockCategoryId = value;
        }

        public string StockCategoryName
        {
            get => stockCategoryName;
            set => stockCategoryName = value;
        }

        #endregion
    }
}