using ProjectA.BL;
using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectA.Forms
{
    public partial class AddStudent : Form
    {

        Student s;
        SqlConnection con;

        public AddStudent()
        {
            InitializeComponent();
            start();
        }
        //public AddStudent(Student student)
        //{
        //    this.s = student;
        //    InitializeComponent();
        //    start();
        //    loadPreviousData();
        //}

        //private void loadPreviousData()
        //{
        //    textBoxFirstName.Text = s.FirstName;
        //    textBoxLastName.Text = s.LastName;
        //    textBoxRegNo.Text = s.RegistrationNo;
        //    textBoxEmail.Text = s.Email;
        //    textBoxContact.Text = s.Contact;
        //    if (s.Gender == 0)
        //    {
        //        comboBoxGender.SelectedIndex = 2;
        //    }
        //    else
        //    {
        //        comboBoxGender.SelectedIndex = s.Gender - 1;
        //    }
        //    if (s.DateOfBirth == "")
        //    {
        //        checkBoxisDoBApplicable.Checked = true;
        //        dateTimePickerDoB.Enabled = false;
        //    }
        //    else
        //    {
        //        dateTimePickerDoB.Value = Convert.ToDateTime(s.DateOfBirth);
        //    }
        //    lblHeading.Text = "Edit Details of Student";
        //}

        private void start()
        {
            s = new Student();
            con = Configuration.getInstance().getConnection();
            s.DateOfBirth = dateTimePickerDoB.Value.ToString();
            comboBoxGender.SelectedIndex = 0;
        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                s.FirstName = textBoxFirstName.Text;
                s.LastName = textBoxLastName.Text;
                s.Contact = textBoxContact.Text;
                s.Email = textBoxEmail.Text;
                s.RegistrationNo = textBoxRegNo.Text;
                //Handling Exceptions as Fields should be filled properly to store Data
                if (s.FirstName == "")
                {
                    throw new Exception("First Name cannot be Empty");
                }
                if (s.RegistrationNo == "")
                {
                    throw new Exception("Registration No cannot be Empty");
                }
                if (s.Email == "")
                {
                    throw new Exception("Email cannot be Empty");
                }
                if (!Validations.isNumber(s.Contact))
                {
                    throw new Exception("Contact No only consists of digits cannot be Empty");
                }
                if (!Validations.IsValidEmail(s.Email))
                {
                    throw new Exception("Enter Valid Email");
                }
                SqlCommand cmd;
                string gender = "";
                //Checking whether gender is valid or not
                try
                {
                    gender = comboBoxGender.SelectedItem.ToString();
                    if (gender != "NULL")
                    {
                        //Getting Gender in int from lookup table
                        cmd = new SqlCommand("Select id from Lookup Where value = @value and Category = @category", con);
                        cmd.Parameters.AddWithValue("@value", gender);
                        cmd.Parameters.AddWithValue("@category", "Gender");
                        s.Gender = (Int32)cmd.ExecuteScalar();
                    }
                }
                catch
                {
                    throw new Exception("Provide Correct Gender");
                }

                //Adding data in person table
                cmd = new SqlCommand("Insert into Person values (@firstName, @lastName, @contact,@email,@dob,@gender)", con);
                cmd.Parameters.AddWithValue("@firstName", s.FirstName);
                //inserting null values in database if user has not provided full informations
                if (s.LastName == "")
                {
                    cmd.Parameters.AddWithValue("@lastName", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@lastName", s.LastName);
                }
                if (s.Contact == "")
                {
                    cmd.Parameters.AddWithValue("@contact", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@contact", s.Contact);
                }
                cmd.Parameters.AddWithValue("@email", s.Email);
                if (s.DateOfBirth != null)
                {
                    cmd.Parameters.AddWithValue("@dob", s.DateOfBirth);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dob", DBNull.Value);

                }
                if (s.Gender == 0)
                {
                    cmd.Parameters.AddWithValue("@gender", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@gender", s.Gender);
                }
                cmd.ExecuteNonQuery();
                //getting id of person which is auto genrated on above entry 
                s.Id = retrieveId();
                //Inserting data in student table
                cmd = new SqlCommand("Insert into Student values (@id, @registrationNo)", con);
                cmd.Parameters.AddWithValue("@id", s.Id);
                cmd.Parameters.AddWithValue("@registrationNo", s.RegistrationNo);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int retrieveId()
        {
            //Getting latest autoincremented id
            SqlCommand cmd = new SqlCommand("Select MAX(id) from Person", con);
            return (Int32)cmd.ExecuteScalar();
        }

        private void dateTimePickerDoB_ValueChanged(object sender, EventArgs e)
        {
            s.DateOfBirth = dateTimePickerDoB.Value.ToString();
        }

        private void checkBoxisDoBApplicable_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxisDoBApplicable.Checked)
            {
                dateTimePickerDoB.Enabled = false;
                s.DateOfBirth = null;
            }
            else
            {
                dateTimePickerDoB.Enabled = true;
                s.DateOfBirth = dateTimePickerDoB.Value.ToString();
            }
        }
    }
}
