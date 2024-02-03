using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;

namespace DataAccessLayer
{
    internal class DBConnection 
    {

        internal static SqlConnection getConnection()
        {            

            string connectionString = "data source=localhost;initial catalog=SportDress;integrated security=true";
            SqlConnection conn = new SqlConnection(connectionString);

            return conn;
        }
        
    }
}
