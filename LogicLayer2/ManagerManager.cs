using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataObjects;
using IDataAccessLayer;
using ILogicLayer;

namespace LogicLayer
{
    public class ManagerManager : IManagerManager
    {
        private IManagerAccessor managerAccessor;

        public ManagerManager()
        {
            managerAccessor = new ManagerAccessor();
        }

        public ManagerManager(IManagerAccessor accessor)
        {
            managerAccessor = accessor;
        }

        public int addProduct(Products product)
        {
            int result = 0;
            result = managerAccessor.insertProduct(product);
            return result;
        }

        public int addProductImage(Images productImage)
        {
            int result = 0;
            result = managerAccessor.insertProductImage(productImage);
            return result;
        }

        public int addProductSize(ProductSizes productSizes)
        {
            int result = 0;
            result = managerAccessor.insertProductSize(productSizes);
            return result;
        }

        public int addProductType(ProductTypes productTypes)
        {
            int result = 0;
            result = managerAccessor.insertProductType(productTypes);
            return result;
        }

        public int editProduct(Products products)
        {
            int result = 0;
            result = managerAccessor.updateProduct(products);
            return result;
        }

        public int editProductImage(Images productImage)
        {
            int result = 0;
            result = managerAccessor.updateProductImage(productImage);
            return result;
        }

        public int editProductSize(ProductSizes productSize)
        {
            int result = 0;
            result = managerAccessor.updateProductSize(productSize);
            return result;
        }

        public int editProductType(ProductTypes productType)
        {
            int result = 0;
            result = managerAccessor.updateProductType(productType);
            return result;
        }

        public List<Images> getProductImages()
        {
            List<Images> images = new List<Images>();
            images = managerAccessor.selectProductImages();
            return images;
        }

        public List<Products> getProducts()
        {
            List<Products> products = new List<Products>();
            products = managerAccessor.selectProducts();
            return products;
        }

        public List<ProductSizes> getProductSize()
        {
            List<ProductSizes> productSizes = new List<ProductSizes>();
            productSizes = managerAccessor.selectProductSizes();
            return productSizes;
        }

        public List<ProductTypes> getProductType()
        {
            List<ProductTypes> productTypes = new List<ProductTypes>();
            productTypes = managerAccessor.selectProductTypes();
            return productTypes;
        }
    }
}
