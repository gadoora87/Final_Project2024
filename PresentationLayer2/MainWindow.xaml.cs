using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicLayer;
using ILogicLayer;
using DataObjects;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEmployeesManager employeesManager;
        private IManagerManager managerManager;
        private string dataType = "";
        private Customer customer;
        private ICustomersManager customersManager;
        public MainWindow()
        {
            InitializeComponent();
            employeesManager = new EmployeesManager();
            managerManager = new ManagerManager();
            customer = new Customer();
            customersManager = new CustomersManager();
            gridBody.Visibility = Visibility.Collapsed;
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (btnLogin.Content.ToString() == "login")
            {
                lblLoginMessages.Content = "";                
                string username = txt_username.Text;
                string password = txt_password.Password.ToString();
                bool isUserNameValid = validateUserName(username);
                bool isPasswordValid = validatePassword(password);
                if (!(isUserNameValid && isPasswordValid))
                {
                    return;
                }
                int isEmployeeVerify = employeesManager.verifyEmployee(username, password);
                if (isEmployeeVerify < 1)
                {
                    lblLoginMessages.Content = "username and password are not correct";
                    return;
                }
                
                clearLoginText();
                hidLoginElements();
                List<string> employeeRoles = employeesManager.getEmployeeRoles(isEmployeeVerify);
                foreach (string item in employeeRoles)
                {
                    lblLoginMessages.Content += item;
                }
                showTabByRole(employeeRoles[0]);
                
            }
            else
            {
                showLoginElements();
            }
           
        }

        private void showTabByRole(string role)
        {
            lblLoginMessages.Content = role;
            gridBody.Visibility = Visibility.Visible;
            gridAdminMenu.Visibility = Visibility.Collapsed;    
             if (role == "admin")
            {
                btnAdmin.Visibility = Visibility.Visible;
                btnManager.Visibility = Visibility.Hidden;
                btnReciption.Visibility = Visibility.Hidden;
                gridAdminMenu.Visibility = Visibility.Visible;
                gridManagerMenu.Visibility = Visibility.Hidden;
                gridEmployeeMenu.Visibility = Visibility.Hidden;
            }
            else if(role == "manager")
            {
                btnAdmin.Visibility = Visibility.Hidden;
                btnManager.Visibility = Visibility.Visible;
                btnReciption.Visibility = Visibility.Hidden;
                gridAdminMenu.Visibility = Visibility.Hidden;
                gridManagerMenu.Visibility = Visibility.Visible;
                gridEmployeeMenu.Visibility = Visibility.Hidden;
            }
            else if (role == "employee")
            {
                btnAdmin.Visibility = Visibility.Hidden;
                btnManager.Visibility = Visibility.Hidden;
                btnReciption.Visibility = Visibility.Visible;
                gridAdminMenu.Visibility = Visibility.Hidden;
                gridManagerMenu.Visibility = Visibility.Hidden;
                gridEmployeeMenu.Visibility = Visibility.Visible;
                fillCustomerDataGrid();
            }
        }

        private void fillCustomerDataGrid()
        {
            List<Customer> cus = new List<Customer>();
            cus = customersManager.getAllCustomers();
            dgCustomers.ItemsSource = cus;
        }

        private void clearLoginText()
        {
            txt_username.Text = string.Empty;
            txt_password.Password = string.Empty;
        }

        private void showLoginElements()
        {
            lbl_username.Visibility = Visibility.Visible;
            lbl_password.Visibility = Visibility.Visible;
            txt_username.Visibility = Visibility.Visible;   
            txt_password.Visibility = Visibility.Visible;
            btnLogin.Content = "login";
            gridBody.Visibility = Visibility.Collapsed;
            lblLoginMessages.Content = "";
        }

        private void hidLoginElements()
        {
            lbl_username.Visibility = Visibility.Collapsed;
            lbl_password.Visibility = Visibility.Collapsed;
            txt_password.Visibility = Visibility.Collapsed; 
            txt_username.Visibility = Visibility.Collapsed;
            btnLogin.Content = "logout";
        }

        private bool validatePassword(string password)
        {
            bool result = true;
            if (password.Length < 8)
            {
                lblLoginMessages.Content = "minimum length of password is 8";
                result = false;
            }
            return result;
        }

        private bool validateUserName(string username)
        {
            bool result = true;
            if (username.Length < 8)
            {
                lblLoginMessages.Content = "minimum length of username is 8";
                result = false;
            }
            return result;
        }

        private void btnNewUserClicked(object sender, RoutedEventArgs e)
        {
            Admin.EmployeeDataForm employeeDataForm = new Admin.EmployeeDataForm();
            employeeDataForm.Show();
        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> employees = new List<Employee>();
            employees = employeesManager.getEmployees();
            dgEmployees.ItemsSource = employees;
        }

        private void dgEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Employee employee = (Employee)dgEmployees.SelectedItem;
            Admin.EmployeeDataForm employeeDataForm = new Admin.EmployeeDataForm(employee);
            employeeDataForm.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployees.SelectedItem == null)
            {
                lblDeleteSpan.Content = "Please select a row";
                return;
            }
            Employee employee = (Employee)dgEmployees.SelectedItem;
            int result = employeesManager.deleteEmployee(employee);
            if (result != 0)
            {
                List<Employee> employees = new List<Employee>();
                employees = employeesManager.getEmployees();
                dgEmployees.ItemsSource = employees;
            }

        }

        private void btnProductTypes_Click(object sender, RoutedEventArgs e)
        {
            List<ProductTypes> productTypes = new List<ProductTypes>();
            productTypes = managerManager.getProductType();
            dataGridProducts.ItemsSource = productTypes;
            dataType = "productTypes";
        }

        private void btnProductSizes_Click(object sender, RoutedEventArgs e)
        {
            List<ProductSizes> productSizes = new List<ProductSizes>();
            productSizes = managerManager.getProductSize();
            dataGridProducts.ItemsSource = productSizes;
            dataType = "productSizes";
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            List<Products> products = new List<Products>();
            products = managerManager.getProducts();
            dataGridProducts.ItemsSource = products;
            dataType = "products";
        }

        private void btnProductImages_Click(object sender, RoutedEventArgs e)
        {
            List<Images> productImages = new List<Images>();
            productImages = managerManager.getProductImages();
            dataGridProducts.ItemsSource = productImages;
            dataType = "productImages";

        }

        private void dataGridProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataType == "productImages")
            {
                Images images = new Images();
                images = (Images)dataGridProducts.SelectedItem;
                Manager.FrmProductImage frmProductImage = new Manager.FrmProductImage(images);
                frmProductImage.ShowDialog();
                List<Images> productImages = new List<Images>();
                productImages = managerManager.getProductImages();
                dataGridProducts.ItemsSource = productImages;
                dataType = "productImages";

            }
            else if (dataType == "products")
            {
                Products products = new Products();
                products = (Products)dataGridProducts.SelectedItem;
                Manager.FrmProducts frmProducts = new Manager.FrmProducts(products);
                frmProducts.ShowDialog();
                List<Products> allProducts = new List<Products>();
                allProducts = managerManager.getProducts();
                dataGridProducts.ItemsSource = allProducts;
                dataType = "products";
            }
            else if(dataType == "productSizes")
            {
                ProductSizes productSize = new ProductSizes(); 
                productSize = (ProductSizes)dataGridProducts.SelectedItem;
                Manager.FrmProductSize frmProductSize = new Manager.FrmProductSize(productSize);
                frmProductSize.ShowDialog();
                List<ProductSizes> productSizes = new List<ProductSizes>();
                productSizes = managerManager.getProductSize();
                dataGridProducts.ItemsSource = productSizes;
                dataType = "productSizes";
            }
            else if (dataType == "productTypes")
            {
                ProductTypes productType = new ProductTypes();
                productType = (ProductTypes)dataGridProducts.SelectedItem;
                Manager.FrmProductTypes frmProductTypes = new Manager.FrmProductTypes(productType);
                frmProductTypes.ShowDialog();
                List<ProductTypes> productTypes = new List<ProductTypes>();
                productTypes = managerManager.getProductType();
                dataGridProducts.ItemsSource = productTypes;
                dataType = "productTypes";
            }
            else 
            {
                //there is no button clicked!
            }
        }

        private void btnAddProductImages_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrmProductImage frmProductImage = new Manager.FrmProductImage();
            frmProductImage.ShowDialog();
            List<Images> productImages = new List<Images>();
            productImages = managerManager.getProductImages();
            dataGridProducts.ItemsSource = productImages;
            dataType = "productImages";
        }

        private void btnAddProducts_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrmProducts frmProducts = new Manager.FrmProducts();
            frmProducts.ShowDialog();
            List<Products> products = new List<Products>();
            products = managerManager.getProducts();
            dataGridProducts.ItemsSource = products;
            dataType = "products";
        }

        private void btnAddProductSize_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrmProductSize frmProductSize = new Manager.FrmProductSize();
            frmProductSize.ShowDialog();
            List<ProductSizes> productSizes = new List<ProductSizes>();
            productSizes = managerManager.getProductSize();
            dataGridProducts.ItemsSource= productSizes;
            dataType = "productSizes";
        }

        private void btnAddProductType_Click(object sender, RoutedEventArgs e)
        {
            Manager.FrmProductTypes frmProductTypes = new Manager.FrmProductTypes();
            frmProductTypes.ShowDialog();
            List<ProductTypes> productTypes = new List<ProductTypes>();
            productTypes = managerManager.getProductType();
            dataGridProducts.ItemsSource= productTypes;
            dataType = "productTypes";
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            CustomerForms.FrmCustomer frmCustomer = new CustomerForms.FrmCustomer();
            frmCustomer.ShowDialog();
            fillCustomerDataGrid();
        }

        private void dgCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Customer customer = new Customer();
            customer = (Customer)dgCustomers.SelectedItem;
            CustomerForms.FrmCustomer frmCustomer = new CustomerForms.FrmCustomer(customer);
            frmCustomer.ShowDialog();
            fillCustomerDataGrid();
        }
    }
}