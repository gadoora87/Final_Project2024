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
    /// Interaction logic for FrmProductTypes.xaml
    /// </summary>
    public partial class FrmProductTypes : Window
    {
        private IManagerManager manager;
        private ProductTypes _productType = null;
        private string formType = string.Empty;
        public FrmProductTypes()
        {
            InitializeComponent();
            manager = new ManagerManager();
            this._productType = new ProductTypes();
            formType = "New";
        }

        public FrmProductTypes(ProductTypes productType)
        {
            InitializeComponent();
            manager = new ManagerManager();
            _productType = productType;
            fillForm();
        }

        private void fillForm()
        {
            txtProductTypeName.Text = _productType.ProductTypeName;
            txtProductTypeName.IsReadOnly = true;
            txtDescription.Text = _productType.Description;
            formType = "Edit";
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateFormData())
            {
                return;
            }
            _productType.ProductTypeName = txtProductTypeName.Text;
            _productType.Description = txtDescription.Text;
            int result = 0;
            if (formType == "New") {
                result = manager.addProductType(_productType);
            }
            else
            {
                result = manager.editProductType(_productType);
            }
             
            if (result == 0)
            {
                lblFormMessage.Content = "there is an error, call admin";
                return;
            }
            lblFormMessage.Content = "added correctly";
        }

        private bool validateFormData()
        {
            if (txtProductTypeName.Text.Length == 0) {
                lblFormMessage.Content = "Enter a product type";
                return false;
            }
            if (txtDescription.Text.Length == 0)
            {
                lblFormMessage.Content = "Enter a description";
                return false;
            }
            lblFormMessage.Content = "";
            return true;
        }
    }
}
