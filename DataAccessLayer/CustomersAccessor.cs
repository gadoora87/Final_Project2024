using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;
using DataObjects;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;

namespace DataAccessLayer
{
    public class CustomersAccessor : ICustomerAccessor
    {
        public CustomersAccessor() { }

        public int insert(Customer customer)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_insert_customer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GivenName", customer.GivenName);
            cmd.Parameters.AddWithValue("@FamilyName", customer.FamilyName);
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@line1", customer.line1);
            cmd.Parameters.AddWithValue("@line2", customer.line2);
            cmd.Parameters.AddWithValue("@zipcode", customer.zipcode);
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

        public int insertCustomerCreditCard(CustomerCreditCard creditCard)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_insert_customer_credit_card", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", creditCard.CustomerID);
            cmd.Parameters.AddWithValue("@CreditCardNumber", creditCard.CreditCardNumber);
            cmd.Parameters.AddWithValue("@zipcode", creditCard.zipcode);
            cmd.Parameters.AddWithValue("@cvv", creditCard.cvv);
            cmd.Parameters.AddWithValue("@dateOfExpiration", creditCard.dateOfExpiration);
            cmd.Parameters.AddWithValue("@nameOnTheCard", creditCard.nameOnTheCard);
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

        public int insertTransaction(CustomerTransaction customerTransaction)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_insert_transaction", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customerId", customerTransaction.customerId);
            cmd.Parameters.AddWithValue("@productId", customerTransaction.productId);
            cmd.Parameters.AddWithValue("@price", customerTransaction.price);
            cmd.Parameters.AddWithValue("@dateOfBuy", customerTransaction.dateOfBuy);
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

        public int insertZipcode(Zipcode zipcode)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_insert_zipcode", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@zipcode", zipcode.zipcode);
            cmd.Parameters.AddWithValue("@city", zipcode.city);
            cmd.Parameters.AddWithValue("@state", zipcode.state);
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

        public List<Customer> SelectAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_select_all_customers", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerID = reader.GetInt32(0);
                        customer.GivenName = reader.GetString(1);
                        customer.FamilyName = reader.GetString (2);
                        customer.PhoneNumber = reader.GetString (3);
                        customer.Email = reader.GetString(4);
                        customer.line1 = reader.GetString (5);
                        customer.line2 = reader.GetString(6);
                        customer.zipcode = reader.GetString(7);
                        customers.Add(customer);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return customers;
        }

        public List<CustomerTransaction> selectCustomerTransactions(int customerID)
        {
            List<CustomerTransaction> customerTransactions = new List<CustomerTransaction>();
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_select_customer_transactions", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customerID", customerID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CustomerTransaction customer = new CustomerTransaction();
                        customer.customerId = reader.GetInt32(0);
                        customer.productId = reader.GetInt32(1);
                        customer.price = reader.GetString(2);
                        customer.dateOfBuy = reader.GetString(3);
                        customerTransactions.Add(customer);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return customerTransactions;
        }

        public CustomerCreditCard selectCustomerCreditCard(int customerID)
        {
            CustomerCreditCard customerCreditCard = new CustomerCreditCard();
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_select_customer_credit_card", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customerID", customerID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customerCreditCard.CustomerID = reader.GetInt32(0);
                        customerCreditCard.CreditCardNumber = reader.GetString(1);
                        customerCreditCard.zipcode = reader.GetString(2);
                        customerCreditCard.cvv = reader.GetString(3);
                        customerCreditCard.dateOfExpiration = reader.GetString(4);
                        customerCreditCard.nameOnTheCard = reader.GetString(5);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return customerCreditCard;
        }

        public List<Zipcode> SelectZipcodes()
        {
            List<Zipcode> zipcodes = new List<Zipcode>();
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_select_all_zipcodes", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Zipcode code = new Zipcode();
                        code.zipcode = reader.GetString(0);
                        code.city = reader.GetString(1);
                        code.state = reader.GetString(2);
                        zipcodes.Add(code);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return zipcodes;
        }

        public int update(Customer customer)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_update_customer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@GivenName", customer.GivenName);
            cmd.Parameters.AddWithValue("@FamilyName", customer.FamilyName);
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@line1", customer.line1);
            cmd.Parameters.AddWithValue("@line2", customer.line2);
            cmd.Parameters.AddWithValue("@zipcode", customer.zipcode);
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

        public int updateCustomerCreditCard(CustomerCreditCard creditCard)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_update_customer_credit_card", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", creditCard.CustomerID);
            cmd.Parameters.AddWithValue("@CreditCardNumber", creditCard.CreditCardNumber);
            cmd.Parameters.AddWithValue("@zipcode", creditCard.zipcode);
            cmd.Parameters.AddWithValue("@cvv", creditCard.cvv);
            cmd.Parameters.AddWithValue("@dateOfExpiration", creditCard.dateOfExpiration);
            cmd.Parameters.AddWithValue("@nameOnTheCard", creditCard.nameOnTheCard);
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
