using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectA.BL
{
    public class Evaluation
    {
        private int id;
        private string name;
        private int totalMarks;
        private int totalWeightage;

        public Evaluation() { }
        public Evaluation(int id, string name, int totalMarks, int totalWeightage)
        {
            this.Id = id;
            this.Name = name;
            this.TotalMarks = totalMarks;
            this.TotalWeightage = totalWeightage;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int TotalMarks { get => totalMarks; set => totalMarks = value; }
        public int TotalWeightage { get => totalWeightage; set => totalWeightage = value; }

        internal static DataTable loadEvaluations()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from Evaluation", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                return null;
            }
        }

        internal static DataTable searchEvaluations(string text)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand("Select * from Evaluation where name LIKE '%'+@text+'%'", con);
                cmd.Parameters.AddWithValue("@text", text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                return null;
            }
        }
    }
}
