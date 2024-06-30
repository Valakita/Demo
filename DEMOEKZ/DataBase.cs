using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOEKZ
{
    class DataBase
    {
        public static string FIO;
        public static string Mail;
        public static string Role;
        SqlConnection SqlConnection = new SqlConnection("Data Source=WIN-NICKJ3OLMQH;Initial Catalog=MyBase;Integrated Security=True");

        public void OpenConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Closed)
            {
                SqlConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return SqlConnection;
        }

    }
}
