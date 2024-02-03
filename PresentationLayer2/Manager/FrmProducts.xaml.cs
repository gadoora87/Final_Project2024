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
using LogicLayer;
using ILogicLayer;
using DataObjects;

namespace PresentationLayer.Manager
{
    /// <summary>
    /// Interaction logic for FrmProducts.xaml
    /// </summary>
    public partial class FrmProducts : Window
    {
        private IManagerManager productManager = null;
        private List<ProductTypes> productTypes = null;
        private List<ProductSizes> productSizes = null;
        private Products products;
        private bool isEdit = false;

        public FrmProducts()
        {
            InitializeComponent();
            productManager = new ManagerManager();
            productTypes = new List<ProductTypes>();
            productSizes = new List<ProductSizes>();
            this.products = new Products();
            RetrivecomboData();
        }

        public FrmProducts(Products products)
        {
            InitializeComponent();
            productManager = new ManagerManager();
            productTypes = new List<ProductTypes>();
            productSizes = new List<ProductSizes>();
            RetrivecomboData();
            this.products = products;
            txtProductName.Text = this.products.ProductName;
            comboType.SelectedItem = this.products.Type;
            comboSize.SelectedItem = this.products.Size;
            txtPrice.Text = this.products.Price;
            isEdit = true;
        }

        private void RetrivecomboData()
        {
            productTypes = productManager.getProductType();
            List<string> names = new List<string>();
            foreach (ProductTypes type in productTypes)
            {
                if (type.ProductTypeName != null)
                {
                    names.Add(type.ProductTypeName);
                }
                
            }
            comboType.ItemsSource = names; 
            comboType.SelectedIndex = 0;
            names = new List<string>();
            productSizes = productManager.getProductSize();
            foreach (ProductSizes type in productSizes)
            {
                if (type.ProductsSizeName != null)
                {
                    names.Add(type.ProductsSizeName);
                }                
            }
            comboSize.ItemsSource = names; 
            comboSize.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateData())
            {
                return;
            }
            int result = 0;
            
            this.products.ProductName = txtProductName.Text;
            this.products.Type = comboType.SelectedItem.ToString() ;
            this.products.Size = comboSize.SelectedItem.ToString();
            this.products.Price = txtPrice.Text;
            if (isEdit)
            {
                result = productManager.editProduct(this.products);
            }
            else
            {
                result = productManager.addProduct(this.products);
            }
            
            if (result == 0)
            {
                lblFormMessage.Content = "there is an error, please try again";
                return;
            }
            lblFormMessage.Content = "Product added";
            clearForm();
        }

        private void clearForm()
        {
            txtProductName.Text = string.Empty;
            comboType.SelectedIndex = 0;
            comboSize.SelectedIndex = 0;
            txtPrice.Text = string.Empty;
        }

        private bool validateData()
        {
            if (txtProductName.Text == string.Empty)
            {
                lblFormMessage.Content = "Product Name is require";
                return false;
            }
            if (comboType.SelectedItem == null)
            {
                lblFormMessage.Content = "Product Type is require";
                return false;
            }
            if (comboSize.SelectedItem == null)
            {
                lblFormMessage.Content = "Product Size is require";
                return false;
            }
            if (txtPrice.Text == string.Empty)
            {
                lblFormMessage.Content = "Product Price is require";
                return false;
            }
            lblFormMessage.Content = string.Empty;
            return true;
        }
    }
}
