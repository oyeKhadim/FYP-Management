using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.BL
{
    public class LookupClass
    {
        public static int findId(string value, string category)
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select id from Lookup Where value = @value and Category = @category", con);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Parameters.AddWithValue("@category", category);
            return (Int32)cmd.ExecuteScalar();
        }
    }
}
