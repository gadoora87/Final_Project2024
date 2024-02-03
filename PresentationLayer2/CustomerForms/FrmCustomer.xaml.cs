using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ILogicLayer;
using LogicLayer;
using DataObjects;

namespace PresentationLayer.CustomerForms
{
    /// <summary>
    /// Interaction logic for FrmCustomer.xaml
    /// </summary>
    public partial class FrmCustomer : Window
    {
        private Customer customer;
        private ICustomersManager customerManager;
        private IManagerManager productManager;
        private List<Zipcode> zipcodeList;
        private List<Customer> customerList;
        private CustomerCreditCard creditCard;
        private Products product;
        private List<Products> products;
        private CustomerTransaction customerTransaction;
        private List<CustomerTransaction> transactionList;
        public FrmCustomer()
        {
            InitializeComponent();
            customer = new Customer();
            customerList = new List<Customer>();
            customerManager = new CustomersManager();
            productManager = new ManagerManager();
            creditCard = new CustomerCreditCard();
            zipcodeList = new List<Zipcode>();
            product = new Products();
            products = new List<Products>();
            customerTransaction = new CustomerTransaction();
            transactionList = new List<CustomerTransaction>();
            fillCombos();
        }

        private void fillFormsDataByCustomerInfo()
        {
            txtGivenName.Text = customer.GivenName;
            txtFamilyName.Text = customer.FamilyName;
            txtPhoneNumber.Text = customer.PhoneNumber;
            txtEmail.Text = customer.Email;
            txtLine1.Text = customer.line1;
            txtLine2.Text = customer.line2;
            comboZipCode.SelectedItem = customer.zipcode;
            Zipcode zipcode = new Zipcode();
            foreach (Zipcode code in zipcodeList)
            {
                if (code.zipcode == customer.zipcode)
                {
                    zipcode = code; break;
                }
            }
            txtNewZipcode.Text = customer.zipcode;
            txtState.Text = zipcode.state;
            txtCity.Text = zipcode.city;
            comboCustomers.SelectedItem = customer.FamilyName;
            comboZipCode.SelectedItem =customer.zipcode;
            creditCard = customerManager.getCustomerCreditCard(customer.CustomerID);
            txtCCNumber.Text = creditCard.CreditCardNumber;
            txtCVV.Text = creditCard.cvv;
            txtDateOfBirth.Text = creditCard.dateOfExpiration;
            txtNameOnCard.Text = creditCard.nameOnTheCard;
            txtNewZipcode.IsReadOnly = true;
            txtState.IsReadOnly = true;
            txtCity.IsReadOnly = true;
            btnAddZipCode.IsEnabled = false;
            btnSubmit.Content = "Update Customer";
            btnAddCard.Content = "Add Card";
            comboTransactionCustomer.SelectedItem = customer.FamilyName;
            comboTransactionCustomer.IsReadOnly = true;
            comboTransactionProduct.IsReadOnly = false;
            txtTransactionDate.IsReadOnly = false;
            txtTransactionPrice.IsReadOnly = false;
            btnTransactionSubmit.IsEnabled = true;
            transactionList = new List<CustomerTransaction>();
            transactionList = customerManager.getCustomerTransactions(customer.CustomerID);
            dgTransaction.ItemsSource = transactionList;
        }

        public FrmCustomer(Customer custom)
        {
            InitializeComponent();
            customer = custom;
            customerList = new List<Customer>();
            customerManager = new CustomersManager();
            productManager = new ManagerManager();
            creditCard = new CustomerCreditCard();
            zipcodeList = new List<Zipcode>();
            product = new Products();
            products = new List<Products>();
            customerTransaction = new CustomerTransaction();
            fillCombos();
            fillFormsDataByCustomerInfo();
        }

        private void fillCombos()
        {
            zipcodeList = customerManager.getZipcodes();
            List<string> zipcodes = new List<string>();
            foreach (Zipcode code in zipcodeList)
            {
                if (code.zipcode != null)
                {
                    zipcodes.Add(code.zipcode);
                }                
            }
            comboZipCode.ItemsSource = zipcodes; 
            comboZipCode.SelectedIndex = 0;
            customerList = customerManager.getAllCustomers();
            List<string> customerNames = new List<string>();
            foreach (Customer custom in customerList) {
                if (custom.FamilyName != null)
                customerNames.Add(custom.FamilyName);
            }
            comboCustomers.ItemsSource = customerNames;
            comboCustomers.SelectedIndex = 0;
            comboZipcodeCard.ItemsSource = zipcodes;
            comboZipcodeCard.SelectedIndex = 0;
            txtNewZipcode.IsReadOnly = false;
            txtState.IsReadOnly = false;
            txtCity.IsReadOnly = false;
            btnAddZipCode.IsEnabled = true;
            btnSubmit.Content = "Add Customer";
            btnAddCard.Content = "Add Card";
            comboTransactionCustomer.ItemsSource = customerNames;
            comboTransactionCustomer.SelectedIndex = 0;
            products = productManager.getProducts();
            List<string> productsNames = new List<string>();
            foreach (Products pro in products)
            {
                if (pro.ProductName != null)
                {
                    productsNames.Add(pro.ProductName);
                }

            }
            comboTransactionProduct.ItemsSource = productsNames;
            transactionList = new List<CustomerTransaction>();
            comboTransactionProduct.SelectedIndex = 0;
            comboTransactionCustomer.IsReadOnly = false;
            comboTransactionProduct.IsReadOnly = false;
            txtTransactionDate.IsReadOnly = false;
            txtTransactionPrice.IsReadOnly = false;
            btnTransactionSubmit.IsEnabled = true;

        }

        private void btnCustomerSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateCustomerForm())
            {
                return;
            }
            int result = 0;
            customer.GivenName = txtGivenName.Text;
            customer.FamilyName = txtFamilyName.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;
            customer.Email = txtEmail.Text;
            customer.line1 = txtLine1.Text;
            customer.line2 = txtLine2.Text;
            customer.zipcode = comboZipCode.SelectedItem.ToString();
            if (btnSubmit.Content.ToString() == "Add Customer")
            {
                result = customerManager.add(customer);
            }
            else
            {
                result = customerManager.update(customer);
            }
            
            if (result == 0)
            {
                lblFormNote.Content = "Customer did not added correctly";
                return;
            }
            lblFormNote.Content = "Customer added correctly";
        }

        private bool validateCustomerForm()
        {
            if (txtGivenName.Text.Length == 0)
            {
                lblFormNote.Content = "Given name require";
                return false;
            }
            if (txtFamilyName.Text.Length == 0)
            {
                lblFormNote.Content = "Family name require";
                return false;
            }
            if (txtPhoneNumber.Text.Length == 0)
            {
                lblFormNote.Content = "Phone Number require";
                return false;
            }
            if (txtEmail.Text.Length == 0)
            {
                lblFormNote.Content = "Email require";
                return false;
            }
            if (txtLine1.Text.Length == 0)
            {
                lblFormNote.Content = "Line 1 require";
                return false;
            }
            if (txtLine2.Text.Length == 0)
            {
                lblFormNote.Content = "line 2 require";
                return false;
            }
            if (comboZipCode.SelectedItem == null)
            {
                lblFormNote.Content = "line 2 require";
                return false;
            }
            lblFormNote.Content = "";
            return true;
        }

        private void btnAddZipCode_Click(object sender, RoutedEventArgs e)
        {
            if (!validateZipcodeForm())
            {
                return;
            }
            Zipcode zipcode = new Zipcode();
            zipcode.zipcode = txtNewZipcode.Text;
            zipcode.city = txtCity.Text;
            zipcode.state = txtState.Text;
            int result = 0;
            result = customerManager.addZipCode(zipcode);
            if (result == 0)
            {
                lblFormNote.Content = "zipcode did not added!";
                return;
            }
            lblFormNote.Content = "zipcode added";
            fillCombos();
        }

        private bool validateZipcodeForm()
        {
            if (txtNewZipcode.Text.Length == 0)
            {
                lblFormNote.Content = "zipcode require";
                return false;
            }
            if (txtCity.Text.Length == 0)
            {
                lblFormNote.Content = "City require";
                return false;
            }
            if (txtState.Text.Length == 0)
            {
                lblFormNote.Content = "State require";
                return false;
            }
            lblFormNote.Content = "";
            return true;
        }

        private void btnAddCard_Click(object sender, RoutedEventArgs e)
        {
            if (!validateCardForm())
            {
                return;
            }
            foreach (Customer custom in customerList)
            {
                if (custom.FamilyName != null && custom.FamilyName.Equals(comboCustomers.SelectedItem.ToString()))
                {
                    creditCard.CustomerID = custom.CustomerID;
                    break;
                }
            }            
            creditCard.CreditCardNumber = txtCCNumber.Text;
            creditCard.zipcode = comboZipCode.SelectedItem.ToString();
            creditCard.cvv = txtCVV.Text;
            creditCard.dateOfExpiration = txtDateOfBirth.Text;
            creditCard.nameOnTheCard = txtNameOnCard.Text;
            int result = 0;
            if (btnAddCard.Content.ToString() == "Add Card")
            {
                result = customerManager.addCustomerCreditCard(creditCard);
            }
            else
            {
                result = customerManager.updateCustomerCreditCard(creditCard);
            }
            
            if (result == 0)
            {
                lblFormNote.Content = "Credit Card did not added";
                return;
            }
            lblFormNote.Content = "Credit Card added";
        }

        private bool validateCardForm()
        {
            if (comboCustomers.SelectedItem == null)
            {
                lblFormNote.Content = "Customer require";
                return false;
            }
            if (comboZipcodeCard.SelectedItem == null)
            {
                lblFormNote.Content = "Zipcode require";
                return false;
            }
            if (txtCCNumber.Text.Length == 0)
            {
                lblFormNote.Content = "Credit Card number require";
                return false;
            }
            if (txtCVV.Text.Length == 0)
            {
                lblFormNote.Content = "CVV require";
                return false;
            }
            if (txtDateOfBirth.Text.Length == 0)
            {
                lblFormNote.Content = "Date of Birth require";
                return false;
            }
            if (txtNameOnCard.Text.Length == 0)
            {
                lblFormNote.Content = "Name on card require";
                return false;
            }
            lblFormNote.Content = "";
            return true;
        }

        private void btnTransactionSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateTransactionForm())
            {
                return;
            }
            int result = 0;
            foreach (Customer custom in customerList)
            {
                if (custom.GivenName != null && custom.FamilyName == comboTransactionCustomer.SelectedItem.ToString())
                {
                    customerTransaction.customerId = custom.CustomerID;
                    break;
                }
            }
            foreach (Products pro in products)
            {
                if (pro.ProductName != null && pro.ProductName == comboTransactionProduct.SelectedItem.ToString())
                {
                    customerTransaction.productId = pro.ProductId;
                    break;
                }
            }
            customerTransaction.price = txtTransactionPrice.Text;
            customerTransaction.dateOfBuy = txtTransactionPrice.Text;
            result = customerManager.addTransaction(customerTransaction);
            if (result == 0)
            {
                lblFormNote.Content = "Transaction did not added!";
                return;
            }
            lblFormNote.Content = "Transaction Added";
            transactionList = new List<CustomerTransaction>();
            transactionList =  customerManager.getCustomerTransactions(customer.CustomerID);
            dgTransaction.ItemsSource = transactionList;

        }

        private bool validateTransactionForm()
        {
            if (comboTransactionCustomer.SelectedItem == null)
            {
                lblFormNote.Content = "customer require";
                return false;
            }
            if (comboTransactionProduct.SelectedItem == null)
            {
                lblFormNote.Content = "Product require";
                return false;
            }
            if (txtTransactionPrice.Text.Length == 0)
            {
                lblFormNote.Content = "Price require";
                return false;
            }
            if (txtTransactionDate.Text.Length == 0)
            {
                lblFormNote.Content = "Date require";
                return false;
            }
            lblFormNote.Content = "";
            return true;
        }
    }
}
