using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogicLayer
{
    public interface IManagerManager
    {
        public int addProduct(Products product);
        public int addProductImage(Images productImage);
        public int addProductSize(ProductSizes productSizes);
        public int addProductType(ProductTypes productTypes);
        public int editProduct(Products products);
        public int editProductImage(Images productImage);
        public int editProductSize(ProductSizes productSize);
        public int editProductType(ProductTypes productType);
        public List<Images> getProductImages();
        public List<Products> getProducts();
        public List<ProductSizes> getProductSize();
        public List<ProductTypes> getProductType();
    }
}
