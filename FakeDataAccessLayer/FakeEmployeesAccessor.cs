using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using IDataAccessLayer;

namespace FakeDataAccessLayer
{
    public class FakeEmployeesAccessor : IEmployeesAccessor
    {
        private List<Employee> employees;
        private List<employeesRoles> employeesRolesList;
        private List<String> roles;
        public FakeEmployeesAccessor()
        {
            employees = new List<Employee>();
            employees.Add(new Employee()
            {
                EmployeeID = 1,
                GivenName = "Name1",
                FamilyName = "Name1",
                PhoneNumber = "1234567890",
                Email = "Name1@company.com",
                Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = true,
            });
            employees.Add(new Employee()
            {
                EmployeeID = 2,
                GivenName = "Name2",
                FamilyName = "Name2",
                PhoneNumber = "1234567890",
                Email = "Name2@company.com",
                Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = true,
            });
            employees.Add(new Employee()
            {
                EmployeeID = 3,
                GivenName = "Name3",
                FamilyName = "Name3",
                PhoneNumber = "1234567890",
                Email = "Name3@company.com",
                Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = true,
            });
            employees.Add(new Employee()
            {
                EmployeeID = 4,
                GivenName = "Name4",
                FamilyName = "Name4",
                PhoneNumber = "1234567890",
                Email = "Name4@company.com",
                Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = true,
            });
            employees.Add(new Employee()
            {
                EmployeeID = 5,
                GivenName = "Name5",
                FamilyName = "Name5",
                PhoneNumber = "1234567890",
                Email = "Name5@company.com",
                Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                Active = true,
            });
            roles = new List<string>();
            roles.Add("Admin");
            roles.Add("Manager");
            roles.Add("Employee");
            employeesRolesList = new List<employeesRoles>();
            employeesRolesList.Add(new employeesRoles()
            {
                EmployeeID = 1,
                RoleID = roles[1]
            });
            employeesRolesList.Add(new employeesRoles()
            {
                EmployeeID = 2,
                RoleID = roles[2]
            });
            employeesRolesList.Add(new employeesRoles()
            {
                EmployeeID = 3,
                RoleID = roles[0]
            });
            employeesRolesList.Add(new employeesRoles()
            {
                EmployeeID = 4,
                RoleID = roles[1]
            });
        }
        public int deleteEmployee(Employee employee)
        {
            int result = 0;
            foreach (Employee emp in employees) 
            {
                if (emp.EmployeeID == employee.EmployeeID)
                {
                    employees.Remove(emp);
                    result = 1; break;
                }
            }
            return result;
        }

        public bool insertEmployee(Employee employee)
        {
            int result = employees.Count();
            employees.Add(employee);
            return employees.Count - result == 1;
        }

        public List<string> selectEmployeeRoles(int employeeId)
        {
            List<string> roles = new List<string>();
            foreach (employeesRoles role in employeesRolesList)
            {
                if (role.EmployeeID == employeeId)
                {
                    if (role.RoleID != null)
                    {
                        roles.Add(role.RoleID);
                    }
                }
            }
            return roles;
        }

        public List<Employee> selectEmployees()
        {
            return employees;
        }

        public int updateEmployee(Employee? employee)
        {
            int result = 0;
            foreach (Employee emp in employees)
            {
                if (emp.EmployeeID == employee.EmployeeID)
                {
                    emp.GivenName = employee.GivenName;
                    emp.FamilyName =  employee.FamilyName;
                    emp.PhoneNumber = employee.PhoneNumber;
                    emp.Email = employee.Email;
                    emp.Password = employee.Password;
                    emp.Active = employee.Active;
                    result = 1; break;
                }
            }
            return result;
        }

        public int verifyEmployee(string username, string password)
        {
            int result = 0;
            foreach (Employee emp in employees)
            {
                if (emp.Email == username && emp.Password == password)
                {
                    result = 1;
                    break;
                }
            }
            return result;
        }
    }
}
