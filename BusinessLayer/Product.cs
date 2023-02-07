using System;

// ReSharper disable All

namespace Poppel_Order_Processing_System.BusinessLayer
{
    public class Product
    {
        #region Fields

        private int productTableId;
        private string productId;
        private string productDetails;
        private DateTime expiryDate;
        private bool trackExpiryDate;
        private string productCategory;
        private int quantityOnHand;
        private decimal retailPrice;
        private decimal costPrice;

        #endregion

        #region Constructors

        public Product()
        {
            this.productTableId = -1;
            this.productId = "-1";
            this.productDetails = "";
            this.expiryDate = new DateTime(1800, 1, 1);
            this.trackExpiryDate = false;
            this.productCategory = "";
            this.quantityOnHand = 0;
            this.retailPrice = 0.00m;
            this.costPrice = 0.00m;
        }

        public Product(string productId, string productDetails, DateTime expiryDate, bool trackExpiryDate,
            string productCategory, int quantityOnHand, decimal retailPrice, decimal costPrice)
        {
            this.productTableId = -1;
            this.productId = productId;
            this.productDetails = productDetails;
            this.expiryDate = expiryDate;
            this.trackExpiryDate = trackExpiryDate;
            this.productCategory = productCategory;
            this.quantityOnHand = quantityOnHand;
            this.retailPrice = retailPrice;
            this.costPrice = costPrice;
        }

        public Product(Product product)
        {
            this.productTableId = product.ProductTableId;
            this.productId = product.ProductId;
            this.productDetails = product.productDetails;
            this.expiryDate = product.ExpiryDate;
            this.trackExpiryDate = product.TrackExpiryDate;
            this.productCategory = product.ProductCategory;
            this.quantityOnHand = product.QuantityOnHand;
            this.retailPrice = product.RetailPrice;
            this.costPrice = product.CostPrice;
        }

        #endregion

        #region Property Methods

        public int ProductTableId
        {
            get => productTableId;
            set => productTableId = value;
        }

        public string ProductId
        {
            get => productId;
            set => productId = value;
        }

        public string ProductDetails
        {
            get => productDetails;
            set => productDetails = value;
        }

        public DateTime ExpiryDate
        {
            get => expiryDate;
            set => expiryDate = value;
        }

        public bool TrackExpiryDate
        {
            get => trackExpiryDate;
            set => trackExpiryDate = value;
        }

        public string ProductCategory
        {
            get => productCategory;
            set => productCategory = value;
        }


        public int QuantityOnHand
        {
            get => quantityOnHand;
            set => quantityOnHand = value;
        }

        public decimal RetailPrice
        {
            get => retailPrice;
            set => retailPrice = value;
        }

        public decimal CostPrice
        {
            get => costPrice;
            set => costPrice = value;
        }

        #endregion
    }
}