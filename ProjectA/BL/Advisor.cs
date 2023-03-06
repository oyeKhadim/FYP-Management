using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                SqlCommand cmd = new SqlCommand("Select A.ID,FirstName+' '+LastName Name,l2.value Designation,Salary,Contact,Email,DateOfBirth,l.value Gender from Advisor A Join Person P on A.id=P.id Left Join Lookup L on L.Id=Gender Join Lookup L2 on L2.id=Designation Where FirstName+' '+Lastname like \'%" + (search + "%\'"), con);
                //cmd.Parameters.AddWithValue("@FirstName", txtBoxSearch.Text);
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
                SqlCommand cmd = new SqlCommand("Select A.ID,FirstName+' '+LastName Name,l2.value Designation,Salary,Contact,Email,DateOfBirth,l.value Gender from Advisor A Join Person P on A.id=P.id Left Join Lookup L on L.Id=Gender Join Lookup L2 on L2.id=Designation", con);
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
    }
}
