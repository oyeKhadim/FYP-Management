using System;
using System.Data.SqlClient;
namespace ProjectA.Extras
{
    class Configuration
    {
        String ConnectionStr = @"Data Source=(local);Initial Catalog=ProjectA;Integrated Security=True ;MultipleActiveResultSets=true";
        SqlConnection con;
        private static Configuration _instance;
        public static Configuration getInstance()
        {
            if (_instance == null)
                _instance = new Configuration();
            return _instance;
        }
        private Configuration()
        {
            con = new SqlConnection(ConnectionStr);
            con.Open();
        }
        public SqlConnection getConnection()
        {
            return con;
        }
    }
}





