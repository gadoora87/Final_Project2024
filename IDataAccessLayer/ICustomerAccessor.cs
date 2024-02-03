using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace IDataAccessLayer
{
    public interface ICustomerAccessor
    {
        public int insert(Customer customer);
        public int insertCustomerCreditCard(CustomerCreditCard creditCard);
        public int insertTransaction(CustomerTransaction customerTransaction);
        public int insertZipcode(Zipcode zipcode);
        public List<Customer> SelectAllCustomers();
        public List<CustomerTransaction> selectCustomerTransactions(int customerID);
        public CustomerCreditCard selectCustomerCreditCard(int customerID);
        public List<Zipcode> SelectZipcodes();
        public int update(Customer customer);
        public int updateCustomerCreditCard(CustomerCreditCard creditCard);
    }
}
