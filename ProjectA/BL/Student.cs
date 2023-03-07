using ProjectA.Extras;
using ProjectA.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectA.BL
{
    public class Student : Person
    {
        private string registrationNo;
        public Student() { }
        public Student(string registrationNo, int id, string firstName, string lastName, string contact, string email, int gender, string dateOfBirth) : base(id, firstName, lastName, contact, email, gender, dateOfBirth)
        {
            this.RegistrationNo = registrationNo;
        }

        public string RegistrationNo { get => registrationNo; set => registrationNo = value; }
        public static DataTable loadStudents()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select S.ID,FirstName,LastName,RegistrationNo,Contact,Email,DateOfBirth,l.value Gender from Student S Join Person P on S.id=P.id Left Join Lookup L on L.Id=Gender", con);
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
        public static DataTable searchInStudents(string name)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select S.ID,FirstName,LastName,RegistrationNo,Contact,Email,DateOfBirth,l.value Gender from Student S Join Person P on S.id=P.id Left Join Lookup L on L.Id=Gender where FirstName+LastName+RegistrationNo LIKE '%'+@name+'%'", con);
                cmd.Parameters.AddWithValue("@name", name);
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
        public static bool AddStudent(int id, string registrationNo)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd;
                cmd = new SqlCommand("Insert into Student values (@id, @registrationNo)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@registrationNo", registrationNo);
                cmd.ExecuteNonQuery();
                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        internal static bool updateStudent(int id, string registrationNo)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd;
                cmd = new SqlCommand("Update  Student SET  registrationNo=@registrationNo where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@registrationNo", registrationNo);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
