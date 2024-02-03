using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;
using DataObjects;
namespace FakeDataAccessLayer
{
    public class FakeCustomersAccessor : ICustomerAccessor
    {
        private List<Customer> customers;
        private List<CustomerCreditCard> creditCards;  
        private List<CustomerTransaction> transactions;
        private List<Zipcode> zipcodes;
        public FakeCustomersAccessor()
        {
            customers = new List<Customer>();
            customers.Add(new Customer()
            {
                CustomerID = 1,
                GivenName = "Foo1",
                FamilyName = "Bar1",
                PhoneNumber = "123-111-2222",
                Email = "foo1@company.com",
                line1 = "1st street",
                line2 = "house 1",
                zipcode = "1111"
            });
            customers.Add(new Customer()
            {
                CustomerID = 2,
                GivenName = "Foo2",
                FamilyName = "Bar2",
                PhoneNumber = "123-111-2222",
                Email = "foo2@company.com",
                line1 = "1st street",
                line2 = "house 1",
                zipcode = "1111"
            });
            customers.Add(new Customer()
            {
                CustomerID = 3,
                GivenName = "Foo3",
                FamilyName = "Bar3",
                PhoneNumber = "123-111-2222",
                Email = "foo3@company.com",
                line1 = "1st street",
                line2 = "house 1",
                zipcode = "1111"
            });
            customers.Add(new Customer()
            {
                CustomerID = 4,
                GivenName = "Foo4",
                FamilyName = "Bar4",
                PhoneNumber = "123-111-2222",
                Email = "foo4@company.com",
                line1 = "1st street",
                line2 = "house 1",
                zipcode = "1111"
            });
            customers.Add(new Customer()
            {
                CustomerID = 5,
                GivenName = "Foo5",
                FamilyName = "Bar5",
                PhoneNumber = "123-111-2222",
                Email = "foo5@company.com",
                line1 = "1st street",
                line2 = "house 1",
                zipcode = "1111"
            });
            creditCards = new List<CustomerCreditCard>();
            creditCards.Add(new CustomerCreditCard()
            {
                CustomerID = 1,
                CreditCardNumber = "123456789",
                zipcode = "1234",
                cvv = "123",
                dateOfExpiration = "11/11/2023",
                nameOnTheCard = "test"
            });
            creditCards.Add(new CustomerCreditCard()
            {
                CustomerID = 1,
                CreditCardNumber = "123456785",
                zipcode = "1234",
                cvv = "123",
                dateOfExpiration = "11/17/2023",
                nameOnTheCard = "test2"
            });
            creditCards.Add(new CustomerCreditCard()
            {
                CustomerID = 1,
                CreditCardNumber = "123456786",
                zipcode = "1234",
                cvv = "123",
                dateOfExpiration = "11/08/2023",
                nameOnTheCard = "test3"
            });
            creditCards.Add(new CustomerCreditCard()
            {
                CustomerID = 1,
                CreditCardNumber = "123456787",
                zipcode = "1234",
                cvv = "123",
                dateOfExpiration = "11/09/2023",
                nameOnTheCard = "test4"
            });
            creditCards.Add(new CustomerCreditCard()
            {
                CustomerID = 5,
                CreditCardNumber = "123456788",
                zipcode = "1234",
                cvv = "123",
                dateOfExpiration = "11/10/2023",
                nameOnTheCard = "test5"
            });
            transactions = new List<CustomerTransaction>();
            transactions.Add(new CustomerTransaction() {
                customerId = 1,
                productId = 1,
                price = "100",
                dateOfBuy = DateTime.Today.ToString(),

            });
            transactions.Add(new CustomerTransaction()
            {
                customerId = 2,
                productId = 2,
                price = "100",
                dateOfBuy = DateTime.Today.ToString(),

            });
            transactions.Add(new CustomerTransaction()
            {
                customerId = 3,
                productId = 3,
                price = "100",
                dateOfBuy = DateTime.Today.ToString(),

            });
            zipcodes = new List<Zipcode>();
            zipcodes.Add(new Zipcode()
            {
                zipcode = "1111",
                city = "Cedar Rapids",
                state = "IA"
            });
            zipcodes.Add(new Zipcode()
            {
                zipcode = "2222",
                city = "City 2",
                state = "IA"
            });
            zipcodes.Add(new Zipcode()
            {
                zipcode = "3333",
                city = "City 3",
                state = "IA"
            });
            zipcodes.Add(new Zipcode()
            {
                zipcode = "4444",
                city = "City 4",
                state = "IA"
            });
            zipcodes.Add(new Zipcode()
            {
                zipcode = "5555",
                city = "City 5",
                state = "IA"
            });
        }
        public int insert(Customer customer)
        {
            int old = customers.Count;
            customers.Add(customer);
            int result = customers.Count;
            return result - old;
        }

        public int insertCustomerCreditCard(CustomerCreditCard creditCard)
        {
            int result = creditCards.Count; 
            creditCards.Add(creditCard);
            return creditCards.Count - result;
        }

        public int insertTransaction(CustomerTransaction customerTransaction)
        {
            int oldCount = transactions.Count;
            transactions.Add(customerTransaction);
            int newCount = transactions.Count;
            return newCount - oldCount;
        }

        public int insertZipcode(Zipcode zipcode)
        {
            int oldCount = zipcodes.Count;
            zipcodes.Add(zipcode);
            int newCount = zipcodes.Count;
            return newCount - oldCount;
        }

        public List<Customer> SelectAllCustomers()
        {
            return customers;
        }

        public List<CustomerTransaction> selectCustomerTransactions(int customerID)
        {
            return transactions;
        }

        public CustomerCreditCard selectCustomerCreditCard(int customerID)
        {
            CustomerCreditCard customerCreditCard = new CustomerCreditCard();
            foreach (CustomerCreditCard cc in creditCards) {
                if (cc.CustomerID == customerID)
                {
                    customerCreditCard = cc;
                    break;
                }
            }
            return customerCreditCard;
        }

        public List<Zipcode> SelectZipcodes()
        {
            return zipcodes;
        }

        public int update(Customer customer)
        {
            int result = 0;
            foreach (Customer c in customers)
            {
                if (c.CustomerID == customer.CustomerID)
                {
                    c.GivenName = customer.GivenName;
                    c.FamilyName = customer.FamilyName;
                    c.PhoneNumber = customer.PhoneNumber;
                    c.Email = customer.Email;
                    c.line1 = customer.line1;
                    c.line2 = customer.line2;
                    c.zipcode = customer.zipcode;
                    result =1;
                    break;
                }                
            }
            return result;
        }

        public int updateCustomerCreditCard(CustomerCreditCard creditCard)
        {
            int result = 0;
            foreach (CustomerCreditCard cc in creditCards)
            {
                if (cc.CustomerID == creditCard.CustomerID)
                {
                    cc.CreditCardNumber = creditCard.CreditCardNumber;
                    cc.zipcode = creditCard.zipcode;
                    cc.cvv = creditCard.cvv;
                    cc.dateOfExpiration = creditCard.dateOfExpiration;
                    cc.nameOnTheCard = creditCard.nameOnTheCard;
                    result = 1; break;
                }
            }
            return result;
        }
    }
}
