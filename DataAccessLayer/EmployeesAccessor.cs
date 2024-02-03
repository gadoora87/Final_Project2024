using IDataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using DataObjects;
namespace DataAccessLayer
{
    public class EmployeesAccessor : IEmployeesAccessor
    {
        public int deleteEmployee(Employee employee)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_delete_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeID);
            try
            {
                conn.Open();
                int reader = 0;
                reader = cmd.ExecuteNonQuery();
                result = reader;
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public bool insertEmployee(Employee employee)
        {
            bool result = false;

            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_insert_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GivenName", employee.GivenName);
            cmd.Parameters.AddWithValue("@FamilyName", employee.FamilyName);
            cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@PasswordHash", employee.Password);
            cmd.Parameters.AddWithValue("@Active", 1);
            try
            {
                conn.Open();
                int reader = 0;
                reader = cmd.ExecuteNonQuery();
                if (reader != 0) { result = true; }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public List<string> selectEmployeeRoles(int employeeId)
        {
            List<string> employeeRoles = new List<string>();
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_select_roles_by_employee_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@employee_id", employeeId);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeRoles.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return employeeRoles;
        }

        public List<Employee> selectEmployees()
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_select_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeID = reader.GetInt32(0);
                        employee.GivenName = reader.GetString(1);
                        employee.FamilyName = reader.GetString(2);
                        employee.PhoneNumber = reader.GetString(3);
                        employee.Email = reader.GetString(4);
                        employee.Password = reader.GetString(5);
                        employee.Active = reader.GetBoolean(6);
                        employees.Add(employee);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return employees;
        }

        public int updateEmployee(Employee? employee)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_update_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //old data
            cmd.Parameters.AddWithValue("@employeeId", employee.EmployeeID);
            cmd.Parameters.AddWithValue("@GivenName", employee.GivenName);
            cmd.Parameters.AddWithValue("@FamilyName", employee.FamilyName);
            cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@PasswordHash", employee.Password);
            cmd.Parameters.AddWithValue("@Active", employee.Active);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }finally { conn.Close(); }
            return result;
        }

        public int verifyEmployee(string username, string password)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_verify_user", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", username);
            cmd.Parameters.AddWithValue("@PasswordHash", password);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader.GetInt32(0);
                }
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
