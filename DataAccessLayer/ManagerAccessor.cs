using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;
using DataObjects;
using System.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public class ManagerAccessor : IManagerAccessor
    {
        public int updateProductType(Products product)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_update_product", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@Type", product.Type);
            cmd.Parameters.AddWithValue("@Size", product.Size);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public int insertProduct(Products product)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_insert_product", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@Type", product.Type);
            cmd.Parameters.AddWithValue("@Size", product.Size);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public int insertProductImage(Images productImage)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_insert_product_image", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", productImage.ProductId);
            cmd.Parameters.AddWithValue("@ImageUrl", productImage.ImageUrl);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public int insertProductSize(ProductSizes productSizes)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_insert_product_size", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductsSizeName", productSizes.ProductsSizeName);
            cmd.Parameters.AddWithValue("@Description", productSizes.Description);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public int insertProductType(ProductTypes productTypes)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_insert_product_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductTypeName", productTypes.ProductTypeName);
            cmd.Parameters.AddWithValue("@Description", productTypes.Description);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public List<Images> selectProductImages()
        {
            List<Images> images = new List<Images>();
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_select_product_images", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Images image = new Images();
                        image.ImageID = reader.GetInt32(0);
                        image.ProductId = reader.GetInt32(1);
                        image.ImageUrl = reader.GetString(2);
                        images.Add(image);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return images;
        }

        public List<Products> selectProducts()
        {
            List<Products> products = new List<Products>();
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_select_products", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Products product = new Products();
                        product.ProductId = reader.GetInt32(0);
                        product.ProductName  = reader.GetString(1);
                        product.Type = reader.GetString(2);
                        product.Size = reader.GetString(3);
                        product.Price = reader.GetString(4);
                        products.Add(product);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return products;
        }

        public List<ProductSizes> selectProductSizes()
        {
            List<ProductSizes> productSizes = new List<ProductSizes>();
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_select_product_sizes", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductSizes productSize = new ProductSizes();
                        productSize.ProductsSizeName = reader.GetString(0);
                        productSize.Description = reader.GetString(1);
                        productSizes.Add(productSize);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return productSizes;
        }

        public List<ProductTypes> selectProductTypes()
        {
            List<ProductTypes> productTypes = new List<ProductTypes>();
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_select_product_types", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductTypes productType = new ProductTypes();
                        productType.ProductTypeName = reader.GetString(0);
                        productType.Description = reader.GetString(1);
                        productTypes.Add(productType);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return productTypes;
        }

        public int updateProductImage(Images productImage)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_update_product_image", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ImageID", productImage.ImageID );
            cmd.Parameters.AddWithValue("@ProductId", productImage.ProductId);
            cmd.Parameters.AddWithValue("@ImageUrl", productImage.ImageUrl);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public int updateProductType(ProductTypes productType)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_update_product_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductTypeName", productType.ProductTypeName);
            cmd.Parameters.AddWithValue("@Description", productType.Description);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public int updateProductSize(ProductSizes productSize)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_update_product_size", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductsSizeName", productSize.ProductsSizeName);
            cmd.Parameters.AddWithValue("@Description", productSize.Description);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public int updateProduct(Products product)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_update_product", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@Type", product.Type);
            cmd.Parameters.AddWithValue("@Size", product.Size);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }
    }
}
