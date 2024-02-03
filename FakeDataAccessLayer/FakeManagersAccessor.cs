using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;
using DataObjects;
using System.Net.Http.Headers;
namespace DataAccessLayer
{
    public class FakeManagersAccessor : IManagerAccessor
    {
        private List<Products> products;
        private List<Images> images;
        private List<ProductSizes> productSizes;
        private List<ProductTypes> productTypes;
        public FakeManagersAccessor() 
        {
            products = new List<Products>();
            products.Add(new Products()
            { 
                ProductId = 1,
                ProductName = "Test",
                Price = "100",
                Size = "XL",
                Type = "T-Shirt"
            });
            products.Add(new Products()
            {
                ProductId = 2,
                ProductName = "Test",
                Price = "200",
                Size = "XL",
                Type = "T-Shirt"
            });
            products.Add(new Products()
            {
                ProductId = 3,
                ProductName = "Test",
                Price = "300",
                Size = "XL",
                Type = "T-Shirt"
            });
            products.Add(new Products()
            {
                ProductId = 4,
                ProductName = "Test",
                Price = "400",
                Size = "XL",
                Type = "T-Shirt"
            });
            products.Add(new Products()
            {
                ProductId = 5,
                ProductName = "Test",
                Price = "500",
                Size = "XL",
                Type = "T-Shirt"
            });
            images = new List<Images>();
            images.Add(new Images()
            { 
                ImageID = 1,
                ProductId = 1,
                ImageUrl = "link1"
            });
            images.Add(new Images()
            {
                ImageID = 2,
                ProductId = 2,
                ImageUrl = "link2"
            });
            images.Add(new Images()
            {ImageID = 3,
                ProductId = 3,
                ImageUrl = "link13"
            });
            images.Add(new Images()
            {ImageID = 4,
                ProductId = 4,
                ImageUrl = "link4"
            });
            images.Add(new Images()
            {ImageID = 5,   
                ProductId = 5,
                ImageUrl = "link5"
            });
            productSizes = new List<ProductSizes>();
            productSizes.Add(new ProductSizes()
            {
                ProductsSizeName = "Test1",
                Description = "Description1"
            });
            productSizes.Add(new ProductSizes()
            {
                ProductsSizeName = "Test2",
                Description = "Description2"
            });
            productSizes.Add(new ProductSizes()
            {
                ProductsSizeName = "Test3",
                Description = "Description3"
            });
            productSizes.Add(new ProductSizes()
            {
                ProductsSizeName = "Test4",
                Description = "Description4"
            });
            productSizes.Add(new ProductSizes()
            {
                ProductsSizeName = "Test5",
                Description = "Description5"
            });
            productTypes = new List<ProductTypes>();
            productTypes.Add(new ProductTypes()
            {
                ProductTypeName = "T-shirt",
                Description = "Description1"
            });
            productTypes.Add(new ProductTypes()
            {
                ProductTypeName = "Shirt",
                Description = "Description1"
            });
            productTypes.Add(new ProductTypes()
            {
                ProductTypeName = "Shoes",
                Description = "Description1"
            });
        }
        public int insertProduct(Products product)
        {
            int result = products.Count;
            products.Add(product);
            return products.Count - result;
        }
        public int insertProductImage(Images productImage)
        {
            int result = images.Count;
            images.Add(productImage);
            return images.Count - result;
        }
        public int insertProductSize(ProductSizes productSize)
        {
            int result = productSizes.Count();
            productSizes.Add(productSize);
            return productSizes.Count - result;            
        }
        public int insertProductType(ProductTypes productType)
        {
            int result = productTypes.Count;
            productTypes.Add(productType);
            return productTypes.Count - result;
        }
        public List<Images> selectProductImages()
        {
            return images;
        }
        public List<Products> selectProducts()
        {
           return products;
        }
        public List<ProductSizes> selectProductSizes()
        {
            return productSizes;
        }
        public List<ProductTypes> selectProductTypes()
        {
            return productTypes;
        }

        public int updateProduct(Products product)
        {
            int result = 0;
            foreach (Products pro in products)
            {
                if (pro.ProductId == product.ProductId) 
                {
                    pro.ProductName = product.ProductName;
                    pro.Price = product.Price;
                    pro.Size = product.Size;
                    pro.Type = product.Type;
                    result = 1;
                    break;
                }
            }
            return result;
        }

        public int updateProductImage(Images productImage)
        {
            int result = 0;
            foreach (Images image in images)
            {
                if (image.ImageID == productImage.ImageID)
                {
                    image.ProductId = productImage.ProductId;
                    image.ImageUrl = productImage.ImageUrl;
                    result = 1;
                    break;
                }
            }
            return result;
        }
        public int updateProductSize(ProductSizes productSize)
        {
            int result =0;
            foreach (ProductSizes size in productSizes)
            {
                if (size.ProductsSizeName == productSize.ProductsSizeName )
                {
                    size.Description = productSize.Description;
                    result = 1; 
                    break;
                }
            }
            return result;
        }
        public int updateProductType(Products product)
        {
           int result = 0;
            foreach (Products p in products) 
            {
                if (p.ProductId == product.ProductId)
                {
                    p.Type = product.Type;
                    result = 1;
                    break;
                }
            }
            return result;
        }
        public int updateProductType(ProductTypes productType)
        {
            int result = 0;
            foreach(ProductTypes p in productTypes)
            {
                if (p.ProductTypeName == productType.ProductTypeName)
                {
                    p.Description = productType.Description;
                    result = 1;
                    break;
                }
            }
            return result;
        }
    }
}
