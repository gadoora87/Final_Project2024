using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace ILogicLayer
{
    public interface IEmployeesManager
    {
        public int verifyEmployee(string username, string password);
        public List<string> getEmployeeRoles(int isEmployeeVerify);
        public bool setEmployee(Employee employee);
        public List<Employee> getEmployees();
        int editEmployee(Employee? employee);
        int deleteEmployee(Employee employee);
    }
}
