using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILogicLayer;
using IDataAccessLayer;
using DataAccessLayer;
using DataObjects;

namespace LogicLayer
{
    public class CustomersManager : ICustomersManager
    {
        private ICustomerAccessor _customerAccessor;

        public CustomersManager() { 
            _customerAccessor = new CustomersAccessor();
        }

        public CustomersManager(ICustomerAccessor customerAccessor)
        {
            _customerAccessor = customerAccessor;
        }

        public int add(Customer customer)
        {
            int result = 0;
            result = _customerAccessor.insert(customer);
            return result;
        }

        public int addCustomerCreditCard(CustomerCreditCard creditCard)
        {
            int result = 0;
            result = _customerAccessor.insertCustomerCreditCard(creditCard); 
            return result;  
        }

        public int addTransaction(CustomerTransaction customerTransaction)
        {
            int result = 0;
            result = _customerAccessor.insertTransaction(customerTransaction);
            return result;
        }

        public int addZipCode(Zipcode zipcode)
        {
            int result = 0;
            result = _customerAccessor.insertZipcode(zipcode);
            return result;
        }

        public List<Customer> getAllCustomers()
        {
            List<Customer> list = new List<Customer>();
            list = _customerAccessor.SelectAllCustomers();
            return list;
        }

        public CustomerCreditCard getCustomerCreditCard(int customerID)
        {
            CustomerCreditCard creditCard = new CustomerCreditCard();
            creditCard = _customerAccessor.selectCustomerCreditCard(customerID);
            return creditCard;
        }

        public List<CustomerTransaction> getCustomerTransactions(int customerID)
        {
            List<CustomerTransaction> customerTransactions = new List<CustomerTransaction>();
            customerTransactions = _customerAccessor.selectCustomerTransactions(customerID);
            return customerTransactions;
        }

        public List<Zipcode> getZipcodes()
        {
            List<Zipcode> codes = new List<Zipcode>();
            codes = _customerAccessor.SelectZipcodes();
            return codes;
        }

        public int update(Customer customer)
        {
            int result = 0;
            result = _customerAccessor.update(customer);
            return result;
        }

        public int updateCustomerCreditCard(CustomerCreditCard creditCard)
        {
            int result = 0;
            result = _customerAccessor.updateCustomerCreditCard(creditCard);
            return result;
        }
    }
}
