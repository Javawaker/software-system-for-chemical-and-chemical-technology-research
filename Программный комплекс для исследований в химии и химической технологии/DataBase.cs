using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DataBase
    {
        //static SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-R88ICHUA\\SEREVERMSSQL;Initial Catalog=Users;Integrated Security=True");
        //static SqlConnection sqlConnection1 = new SqlConnection("Data Source=LAPTOP-R88ICHUA\\SEREVERMSSQL;Initial Catalog=PK_MK;Integrated Security=True");
        static SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-BT04AFL;Initial Catalog=Users;Integrated Security=True");
        static SqlConnection sqlConnection1 = new SqlConnection("Data Source=DESKTOP-BT04AFL;Initial Catalog=PK_MK;Integrated Security=True");

        public static void openConnection()
        {

            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            if (sqlConnection1.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection1.Open();
            }
        }

        public static void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            if (sqlConnection1.State == System.Data.ConnectionState.Open)
            {
                sqlConnection1.Close();
            }
        }

        public static SqlConnection GetConnection()
        {
            return sqlConnection;
        }
        public static SqlConnection GetConnection1()
        {
            return sqlConnection1;
        }
    }
}
