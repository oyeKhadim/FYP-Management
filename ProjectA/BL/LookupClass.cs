using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
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
        public static string getValue(int id)
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select value from Lookup Where id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            return (string)cmd.ExecuteScalar();
        }

        internal static List<string> getValuesOfCategory(string category)
        {
            List<string> values=new List<string>();
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd;
            cmd = new SqlCommand("Select value from Lookup where category=@category", con);
            cmd.Parameters.AddWithValue("@category", category);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                values.Add(DR[0].ToString());
            }
            return values;
        }
    }
}
