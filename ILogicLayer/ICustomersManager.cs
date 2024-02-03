using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace ILogicLayer
{
    public interface ICustomersManager
    {
        public int add(Customer customer);
        public int addCustomerCreditCard(CustomerCreditCard creditCard);
        public int addTransaction(CustomerTransaction customerTransaction);
        public int addZipCode(Zipcode zipcode);
        public List<Customer> getAllCustomers();
        public CustomerCreditCard getCustomerCreditCard(int customerID);
        public List<CustomerTransaction> getCustomerTransactions(int customerID);
        public List<Zipcode> getZipcodes();
        public int update(Customer customer);
        public int updateCustomerCreditCard(CustomerCreditCard creditCard);
    }
}
