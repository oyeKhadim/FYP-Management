using ProjectA.BL;
using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectA.Forms
{
    public partial class EditStudent : Form
    {
        Student s;
        SqlConnection con;
        public EditStudent(Student student)
        {
            InitializeComponent();
            this.s = student;
            con = Configuration.getInstance().getConnection();
        
        }

        private void loadPreviousData()
        {
            textBoxFirstName.Text = s.FirstName;
            textBoxLastName.Text = s.LastName;
            textBoxRegNo.Text = s.RegistrationNo;
            textBoxEmail.Text = s.Email;
            textBoxContact.Text = s.Contact;
            if (s.Gender == -1)
            {
                comboBoxGender.SelectedIndex = 2;
            }
            else
            {
                comboBoxGender.SelectedIndex = s.Gender - 1;
            }
            if (s.DateOfBirth == "")
            {
                checkBoxisDoBApplicable.Checked = true;
                dateTimePickerDoB.Enabled = false;
            }
            else
            {
                dateTimePickerDoB.Value = Convert.ToDateTime(s.DateOfBirth);
            }
          
        }
        private void EditStudent_MouseDown(object sender, MouseEventArgs e)
        {
            Extras.Drag.dragPage(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditStudent_Load(object sender, EventArgs e)
        {
            loadPreviousData();
        }
     

        private void checkBoxisDoBApplicable_CheckedChanged(object sender, EventArgs e)
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                s.FirstName = textBoxFirstName.Text;
                s.LastName = textBoxLastName.Text;
                s.Contact = textBoxContact.Text;
                s.Email = textBoxEmail.Text;
                s.RegistrationNo = textBoxRegNo.Text;
                //Handling Exceptions as Fields should be filled properly to store Data
                bool isAllInfoValid = true;
                isAllInfoValid = Validations.validateTextBox(textBoxFirstName, errorProvider) &&
                Validations.validateTextBox(textBoxEmail, errorProvider) &&
                Validations.validateTextBox(textBoxRegNo, errorProvider) &&
                Validations.validateIntTextBox(textBoxContact, errorProvider) &&
                Validations.validateEmailTextBox(textBoxEmail, errorProvider);
                Validations.validateTextBox(textBoxFirstName, errorProvider);
                Validations.validateTextBox(textBoxEmail, errorProvider);
                Validations.validateTextBox(textBoxRegNo, errorProvider);
                Validations.validateIntTextBox(textBoxContact, errorProvider);
                Validations.validateEmailTextBox(textBoxEmail, errorProvider);
                if (isAllInfoValid)
                {
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
                        else
                        {
                            s.Gender = -1;
                        }
                    }
                    catch
                    {
                        throw new Exception("Provide Correct Gender");
                    }

                    //Adding data in person table
                    cmd = new SqlCommand("Update Person SET firstName=@firstName, lastName=@lastName, contact=@contact,email=@email,dateofbirth=@dob,gender=@gender where id=@id", con);
                    cmd.Parameters.AddWithValue("@firstName", s.FirstName);
                    cmd.Parameters.AddWithValue("@id", s.Id);
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
                    if (s.Gender == -1)
                    {
                        cmd.Parameters.AddWithValue("@gender", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@gender", s.Gender);
                    }
                    cmd.ExecuteNonQuery();

                    //Inserting data in student table
                    cmd = new SqlCommand("Update  Student SET  registrationNo=@registrationNo where id=@id", con);
                    cmd.Parameters.AddWithValue("@id", s.Id);
                    cmd.Parameters.AddWithValue("@registrationNo", s.RegistrationNo);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                    this.Close();
                }
                else
                {
                    throw new Exception("Fill All Fields Correctly");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            Validations.validateTextBox(textBoxFirstName, errorProvider);
        }



        private void textBoxRegNo_Leave(object sender, EventArgs e)
        {
            Validations.validateTextBox(textBoxRegNo, errorProvider);

        }


        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            Validations.validateTextBox(textBoxEmail, errorProvider);


        }

        private void textBoxContact_Leave(object sender, EventArgs e)
        {
            Validations.validateIntTextBox(textBoxContact, errorProvider);

        }
    }
}
