using System.Collections.ObjectModel;
using Poppel_Order_Processing_System.DatabaseLayer;
using Poppel_Order_Processing_System.Properties;

// ReSharper disable All

namespace Poppel_Order_Processing_System.BusinessLayer
{
    public class ProductController
    {
        #region Fields

        private ProductInfoDB productInfoDb;
        private Collection<Product> products;
        private Product product;

        #endregion

        #region Constructors

        public ProductController()
        {
            this.productInfoDb = new ProductInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString);
            this.products = productInfoDb.AllProducts;
        }

        public ProductController(string sqlQuery)
        {
            this.productInfoDb =
                new ProductInfoDB(Settings.Default.PoppelOrderProcessingSystemConnectionString, sqlQuery);
            this.product = productInfoDb.Product;
        }

        #endregion

        #region Property Methods

        public Product Product => product;
        public Collection<Product> AllProducts => products;

        #endregion

        #region Methods

        public Product FindById(string id)
        {
            if (products.Count > 0)
            {
                int position = 0;
                bool found = false;
                if (products.Count > 0)
                {
                    found = id.ToUpper().Equals(products[position].ProductId.ToUpper());
                }

                if (!found)
                {
                    position++;
                }

                while (!found && position < products.Count)
                {
                    found = id.ToUpper().Equals(products[position].ProductId.ToUpper());
                    if (found)
                    {
                        break;
                    }

                    position++;
                }

                if (found)
                {
                    return products[position];
                }

                return null;
            }

            return null;
        }

        public bool Add(Product aProduct)
        {
            return productInfoDb.DatabaseAdd(aProduct);
        }

        public bool Edit(Product aProduct)
        {
            return productInfoDb.DatabaseEdit(aProduct);
        }

        #endregion
    }
}