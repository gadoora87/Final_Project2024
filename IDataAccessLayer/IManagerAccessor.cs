using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace IDataAccessLayer
{
    public interface IManagerAccessor
    {
        public int updateProductType(Products products);
        public int insertProduct(Products product);
        public int insertProductImage(Images productImage);
        public int insertProductSize(ProductSizes productSizes);
        public int insertProductType(ProductTypes productTypes);
        public List<Images> selectProductImages();
        public List<Products> selectProducts();
        public List<ProductSizes> selectProductSizes();
        public List<ProductTypes> selectProductTypes();
        public int updateProductImage(Images productImage);
        public int updateProductType(ProductTypes productType);
        public int updateProductSize(ProductSizes productSize);
        public int updateProduct(Products products);
    }
}
