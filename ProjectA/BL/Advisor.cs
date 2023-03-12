using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ProjectA.BL
{
    public class Advisor : Person
    {
        private int designation;
        private int salary;
        public Advisor() { }
        public Advisor(int designation, int salary, int id, string firstName, string lastName, string contact, string email, int gender, string dateOfBirth) : base(id, firstName, lastName, contact, email, gender, dateOfBirth)
        {
            this.designation = designation;
            this.salary = salary;
        }

        public int Designation { get => designation; set => designation = value; }
        public int Salary { get => salary; set => salary = value; }
        public static DataTable searchWithName(string search)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select A.ID,FirstName,LastName ,l2.value Designation,Salary,Contact,Email,DateOfBirth,l.value Gender from Advisor A Join Person P on A.id=P.id Left Join Lookup L on L.Id=Gender Join Lookup L2 on L2.id=Designation Where FirstName+' '+Lastname like '%'+ @search+'%'", con);
                cmd.Parameters.AddWithValue("@search", search);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            return null;
        }
        public static DataTable load()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select A.ID,FirstName,LastName ,l2.value Designation,Salary,Contact,Email,DateOfBirth,l.value Gender from Advisor A Join Person P on A.id=P.id Left Join Lookup L on L.Id=Gender Join Lookup L2 on L2.id=Designation", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            return null;
        }

        internal static void addAdvisor(Advisor a)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd;
            cmd = new SqlCommand("Insert into Advisor values (@id, @designation,@salary)", con);
            cmd.Parameters.AddWithValue("@id", a.Id);
            if (a.Salary == -1)
            {
                cmd.Parameters.AddWithValue("@salary", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@salary", a.Salary);
            }
            cmd.Parameters.AddWithValue("@designation", a.Designation);
            cmd.ExecuteNonQuery();
        }

        internal static void updateAdvisor(Advisor a)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd;
            cmd = new SqlCommand("Update Advisor SET  designation=@designation,salary=@salary where id=@id", con);
            cmd.Parameters.AddWithValue("@id", a.Id);
            if (a.Salary == -1)
            {
                cmd.Parameters.AddWithValue("@salary", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@salary", a.Salary);
            }
            cmd.Parameters.AddWithValue("@designation", a.Designation);
            cmd.ExecuteNonQuery();
        }
    }
}
