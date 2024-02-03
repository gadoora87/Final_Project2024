using IDataAccessLayer;
using ILogicLayer;
using LogicLayer;
using DataObjects;
using FakeDataAccessLayer;
namespace TestLogicLayer
{
    public class TestCustomersManager
    {
        private ICustomerAccessor customerAccessor;
        private ICustomersManager customersManager;

        [SetUp]
        public void Setup()
        {
            customerAccessor = new FakeCustomersAccessor();
            customersManager = new CustomersManager(customerAccessor);
        }

        [Test]
        public void TestAddCustomer()
        {
            Customer customer = new Customer() 
            { 
                CustomerID = 1000,
                 Email = "Customer@Test.com",
                 FamilyName = "Fam",
                 GivenName = "Given",
                 line1 = "street address",
                 line2 = "house number",
                  PhoneNumber = "1234567890",
                  zipcode = "1111"
            };
            int expected = 1;
            int actual = customersManager.add(customer);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestAddCreditCard()
        {
            CustomerCreditCard creditCard = new CustomerCreditCard() 
            {
                CustomerID = 1000,
                CreditCardNumber = "1234567890",
                cvv = "123",
                dateOfExpiration = "11/11/2011",
                nameOnTheCard = "test",
                zipcode = "1111"
            };
            int expected = 1;
            int actual = customersManager.addCustomerCreditCard(creditCard);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestAddCustomerTransaction()
        {
            CustomerTransaction transaction = new CustomerTransaction() 
            { 
                customerId = 1000,
                dateOfBuy = DateTime.Now.ToString(),
                price = "1000",
                 productId = 1000,                 
            };
            int expected = 1;
            int actual = customersManager.addTransaction(transaction);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestGetZipCodes()
        {
            int expected = 5;
            int actual = customersManager.getZipcodes().Count;
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestUpdateCustomer()
        {
            Customer customer = new Customer() 
            { 
                CustomerID = 1,
                Email = "test@test1.com",
                FamilyName = "Test",
                GivenName = "Test",
                line1 = "Test",
                 line2 = "Test",
                 PhoneNumber = "Test",
                 zipcode = "Test"
            };
            int expected = 1;
            int actual = customersManager.update(customer);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestUpdateCustomerCreditCard()
        {
            CustomerCreditCard customerCreditCard = new CustomerCreditCard() 
            { 
                CustomerID = 1,
                CreditCardNumber = "Test",
                zipcode= "Test",
                cvv = "Test",
                dateOfExpiration = DateTime.Now.ToString(),
                nameOnTheCard = "Test",
            };
            int expected = 1;
            int actual = customersManager.updateCustomerCreditCard(customerCreditCard);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}