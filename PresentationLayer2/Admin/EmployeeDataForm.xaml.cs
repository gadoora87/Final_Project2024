using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Mail;
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
using DataObjects;
using ILogicLayer;
using LogicLayer;


namespace PresentationLayer.Admin
{
    /// <summary>
    /// Interaction logic for EmployeeDataForm.xaml
    /// </summary>
    public partial class EmployeeDataForm : Window
    {
        Employee? employee = null;
        IEmployeesManager employeesManager;
        public EmployeeDataForm()
        {
            InitializeComponent();
            lblTitleForm.Content = "New Employee";
            employeesManager = new EmployeesManager();
        }
        public EmployeeDataForm(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            lblTitleForm.Content = "Edit Employee";
            employeesManager = new EmployeesManager();
            fillTextByEmployeeData();
        }

        private void fillTextByEmployeeData()
        {
            txtGivenName.Text = employee.GivenName;
            txtFamilyName.Text = employee.FamilyName;
            txtPhoneNumber.Text = employee.PhoneNumber;
            txtEmail.Text = employee.Email;
            txtActive.Text = employee.Active.ToString();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateGivenName()) return;
            if (!validateFamilyName()) return;
            if (!validatePhoneNumber()) return;
            if (!validateEmail()) return;
            if (!validatePassword()) return;
            if (lblTitleForm.Content == "Edit Employee")
            {
                
                employee.GivenName = txtGivenName.Text;
                employee.FamilyName = txtFamilyName.Text;
                employee.Email = txtEmail.Text;
                employee.PhoneNumber = txtPhoneNumber.Text;
                employee.Password = txtPassword.Text;
                employee.Active = true;
                int result = employeesManager.editEmployee(employee);
                if (result != 0)
                {
                    lblFormMessage.Content = "Employee Record Updated Correctly"; 
                    
                }
                else
                {
                    lblFormMessage.Content = "Employee did not update";
                }
                
            }
            else
            {
               
                employee = new Employee();
                employee.GivenName = txtGivenName.Text;
                employee.FamilyName = txtFamilyName.Text;
                employee.Email = txtEmail.Text;
                employee.PhoneNumber = txtPhoneNumber.Text;
                employee.Password = txtPassword.Text;
                employee.Active = true;
                bool result = employeesManager.setEmployee(employee);
                if (result)
                {
                    lblFormMessage.Content = "user entered correctly";
                    txtGivenName.Text = "";
                    txtFamilyName.Text = "";
                    txtEmail.Text = "";
                    txtPhoneNumber.Text = "";
                    txtPassword.Text = "";
                    txtActive.Text = "";
                };
            }
            
        }

        private bool validatePassword()
        {
            if (txtPassword.Text.Length == 0)
            {
                lblErrorPassword.Content = "password require";
                return false;
            }
            lblErrorPassword.Content = "";
            return true;
        }

        private bool validateEmail()
        {
            if (txtEmail.Text.Length == 0)
            {
                lblErrorEmail.Content = "Email require";
                return false;
            }
            lblErrorEmail.Content = "";
            return true;
        }

        private bool validatePhoneNumber()
        {
            if (txtPhoneNumber.Text.Length == 0)
            {
                lblErrorPhoneNumber.Content = "Phone number require";
                return false;
            }
            lblErrorPhoneNumber.Content = "";
            return true;
        }

        private bool validateFamilyName()
        {
            if (txtFamilyName.Text.Length == 0)
            {
                lblErrorFamilyName.Content = "Family name require";
                return false;
            }
            lblErrorFamilyName.Content = "";
            return true;
        }

        private bool validateGivenName()
        {
            if (txtGivenName.Text.Length == 0)
            {
                lblErrorGivenName.Content = "given name require";
                return false;
            }
            lblErrorGivenName.Content = "";
            return true;
        }
    }
}
