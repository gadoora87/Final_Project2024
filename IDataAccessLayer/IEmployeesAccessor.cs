using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccessLayer
{
    public interface IEmployeesAccessor
    {
        public int verifyEmployee(string username, string password);
        public List<string> selectEmployeeRoles(int employeeId);
        public bool insertEmployee(Employee employee);
        public List<Employee> selectEmployees();
        int updateEmployee(Employee? employee);
        int deleteEmployee(Employee employee);
    }
}
