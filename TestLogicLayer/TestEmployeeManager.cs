using IDataAccessLayer;
using ILogicLayer;
using LogicLayer;
using DataObjects;
using FakeDataAccessLayer;
namespace TestLogicLayer
{
    public class TestEmployeeManager
    {
        private IEmployeesAccessor employeesAccessor;
        private IEmployeesManager employeesManager;

        [SetUp]
        public void Setup()
        {
            employeesAccessor = new FakeEmployeesAccessor();
            employeesManager = new EmployeesManager(employeesAccessor);
        }

        [Test]
        public void TestSetEmployee()
        {
            Employee employee = new Employee()
            {
                EmployeeID = 1,
                GivenName = "Test",
                FamilyName = "Test",
                Email = "Test",
                PhoneNumber = "Test",
                Password = "Test",
                 Active = true
            };
            bool expected = true;
            bool actual = employeesManager.setEmployee(employee);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestDeleteEmployee()
        {
            Employee employee = new Employee() 
            {
                EmployeeID = 1,
                GivenName = "Name1",
                FamilyName = "Name1",
                PhoneNumber = "1234567890",
                Email = "Name1@company.com",
                Password = "password",
                Active = true,

            };
            int expected = 1;
            int actual = employeesManager.deleteEmployee(employee);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestEditEmployee()
        {
            Employee employee = new Employee()
            {
                EmployeeID = 1,
                GivenName = "NameTest",
                FamilyName = "NameTest",
                PhoneNumber = "1234567890",
                Email = "NameTest@company.com",
                Password = "password",
                Active = true,
            };
            int expected = 1;
            int actual = employeesManager.editEmployee(employee);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestGetEmployeeRoles()
        {
            string expected = "Manager";
            string actual = employeesManager.getEmployeeRoles(1)[0];
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestGetEmployees()
        {
            int expected = 5;
            int actual = employeesManager.getEmployees().Count;
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestVerifyEmployee()
        {
            string username = "Name1@company.com";
            string password = "password";
            int expected = 1;
            int actual = employeesManager.verifyEmployee(username,password);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}