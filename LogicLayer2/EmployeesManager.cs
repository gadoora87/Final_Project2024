using DataAccessLayer;
using DataObjects;
using ILogicLayer;
using System.Security.Cryptography;
using System.Text;
using IDataAccessLayer;
namespace LogicLayer
{
    public class EmployeesManager : IEmployeesManager
    {
        private IEmployeesAccessor employeesAccessor;

        public EmployeesManager()
        {
            employeesAccessor = new EmployeesAccessor();
        }

        public EmployeesManager(IEmployeesAccessor employeesAccessor)
        {
            this.employeesAccessor = employeesAccessor;
        }

        public int deleteEmployee(Employee employee)
        {
            int result = 0;
            try
            {
                result = employeesAccessor.deleteEmployee(employee);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public int editEmployee(Employee? employee)
        {
            int result = 0;
            try
            {
                employee.Password = hashSHA256(employee.Password);
                result = employeesAccessor.updateEmployee(employee);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public List<string> getEmployeeRoles(int EmployeeId)
        {
            List<string> employeeRoles = employeesAccessor.selectEmployeeRoles(EmployeeId);
            return employeeRoles;
        }

        public List<Employee> getEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees = employeesAccessor.selectEmployees();
            foreach (Employee employee in employees)
            {
                employee.Password = null;
            }
            return employees;
        }

        public bool setEmployee(Employee employee)
        {
            employee.Password = hashSHA256(employee.Password);
            bool result = employeesAccessor.insertEmployee(employee);
            return result;
        }

        public int verifyEmployee(string username, string password)
        {
            int result = 0;
            result = employeesAccessor.verifyEmployee(username, hashSHA256(password));
            return result;
        }
        private string hashSHA256(string source)
        {
            string result = "";
            byte[] data;
            using (SHA256 sha256sha = SHA256.Create())
            {
                data = sha256sha.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            var s = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }
            result = s.ToString();
            return result;
        }
    }
}

