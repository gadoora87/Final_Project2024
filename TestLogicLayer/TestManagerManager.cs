using IDataAccessLayer;
using ILogicLayer;
using LogicLayer;
using DataObjects;
using FakeDataAccessLayer;
using DataAccessLayer;
namespace TestLogicLayer
{
    public class TestManagerManager
    {
        private IManagerManager _manager;
        private IManagerAccessor _accessor;

        [SetUp]
        public void Setup()
        {
            _accessor = new FakeManagersAccessor();
            _manager = new ManagerManager(_accessor);
        }

        [Test]
        public void TestAddProduct()
        {
            Products product = new Products() 
            { 
                ProductId = 1000,
                ProductName = "Test",
                Price = "100000",
                Size = "xl",
                Type = "Shoes"
            };
            int expected = 1;
            int actual = _manager.addProduct(product);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestAddProductImage()
        {
            Images images = new Images()
            { 
                ProductId= 1000,
                ImageID = 10000,
                 ImageUrl = "Test",
            };
            int expected = 1;
            int actual = _manager.addProductImage(images);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestAddProductSize()
        {
            ProductSizes sizes = new ProductSizes() 
            { 
                ProductsSizeName = "Test",
                Description = "test"
            };            
            int expected = 1;
            int actual = _manager.addProductSize(sizes);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestAddProductType()
        {
            ProductTypes types = new ProductTypes() 
            { 
                ProductTypeName = "Test",
                Description = "Test"
            };
            int expected = 1;
            int actual = _manager.addProductType(types);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestEditProduct()
        {
            Products product = new Products()
            { 
                ProductId = 1,
                ProductName = "Test",
                Type = "Test",
                Size = "Test",
                Price = "Test"
            };
            int expected = 1;
            int actual = _manager.editProduct(product);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestEditProductImage()
        {
            Images image = new Images()
            { 
                ImageID = 1,
                ProductId = 1,
                ImageUrl = "test"
            };
            int expected = 1;
            int actual = _manager.editProductImage(image);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestEditProductSize()
        {
            ProductSizes size = new ProductSizes()
            {
                ProductsSizeName = "Test1",
                Description = "Test"
            };
            int expected = 1;
            int actual = _manager.editProductSize(size);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestEditProductType()
        {
            ProductTypes type = new ProductTypes() 
            { 
                ProductTypeName = "T-shirt",
                Description = "Test"
            };
            int expected = 1;
            int actual = _manager.editProductType(type);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestGetProductImages()
        {            
            int expected = 5;
            int actual = _manager.getProductImages().Count;
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestGetProducts()
        {
            int expected = 5;
            int actual = _manager.getProducts().Count;
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestGetProductSize()
        {
            int expected = 5;
            int actual = _manager.getProductSize().Count;
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestGetProductType()
        {
            int expected = 3;
            int actual = _manager.getProductType().Count;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}