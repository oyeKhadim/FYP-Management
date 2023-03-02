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
    public partial class EditAdvisor : Form
    {
        Advisor a;
        SqlConnection con;
        public EditAdvisor(Advisor advisor)
        {
            InitializeComponent();
            this.a = advisor;
            con = Configuration.getInstance().getConnection();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void EditAdvisor_MouseDown(object sender, MouseEventArgs e)
        {
            Extras.Drag.dragPage(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //validating all fields
                bool isAllInfoValid = true;
                isAllInfoValid = Validations.validateTextBox(textBoxFirstName, errorProvider) &&
                Validations.validateTextBox(textBoxEmail, errorProvider) &&
                    Validations.validateIntTextBox(textBoxSalary, errorProvider) &&
                Validations.validateIntTextBox(txtBoxContact, errorProvider) &&
                Validations.validateEmailTextBox(textBoxEmail, errorProvider);
                Validations.validateTextBox(textBoxFirstName, errorProvider);
                Validations.validateTextBox(textBoxEmail, errorProvider);
                Validations.validateIntTextBox(textBoxSalary, errorProvider);
                Validations.validateIntTextBox(txtBoxContact, errorProvider);
                Validations.validateEmailTextBox(textBoxEmail, errorProvider);
                a.FirstName = textBoxFirstName.Text;
                a.LastName = textBoxLastName.Text;
                a.Contact = txtBoxContact.Text;
                a.Email = textBoxEmail.Text;


                //if all fields all fill correctly store in database
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
                            a.Gender = (Int32)cmd.ExecuteScalar();
                        }
                        else
                        {
                            a.Gender = -1;
                        }
                    }
                    catch
                    {
                        throw new Exception("Provide Correct Gender");

                    }
                    string designation = "";
                    //Checking whether designation is valid or not
                    try
                    {
                        designation = comboBoxDesignation.SelectedItem.ToString();
                        //Getting designation in int from lookup table
                        cmd = new SqlCommand("Select id from Lookup Where value = @value and Category = @category", con);
                        cmd.Parameters.AddWithValue("@value", designation);
                        cmd.Parameters.AddWithValue("@category", "designation");
                        a.Designation = (Int32)cmd.ExecuteScalar();

                    }
                    catch
                    {
                        throw new Exception("Choose Correct Designation");

                    }
                    if (textBoxSalary.Text == "")
                    {
                        a.Salary = -1;
                    }
                    else
                    {
                        a.Salary = int.Parse(textBoxSalary.Text);
                    }
                    //updating data in person table
                    cmd = new SqlCommand("Update  Person Set firstName=@firstName, lastName=@lastName, contact=@contact,email=@email,dateofbirth=@dob,gender=@gender where id=@id", con);
                    cmd.Parameters.AddWithValue("@firstName", a.FirstName);
                    cmd.Parameters.AddWithValue("@id", a.Id);

                    //inserting null values in database if user has not provided full informations
                    if (a.LastName == "")
                    {
                        cmd.Parameters.AddWithValue("@lastName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@lastName", a.LastName);
                    }
                    if (a.Contact == "")
                    {
                        cmd.Parameters.AddWithValue("@contact", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@contact", a.Contact);
                    }
                    cmd.Parameters.AddWithValue("@email", a.Email);
                    if (a.DateOfBirth != null)
                    {
                        cmd.Parameters.AddWithValue("@dob", a.DateOfBirth);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@dob", DBNull.Value);

                    }
                    if (a.Gender == -1)
                    {
                        cmd.Parameters.AddWithValue("@gender", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@gender", a.Gender);
                    }
                    cmd.ExecuteNonQuery();
                 
                    //Inserting data in student table
                    cmd = new SqlCommand("Update  Advisor SET  designation=@designation,salary=@salary where id=@id", con);
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

        private void EditAdvisor_Load(object sender, EventArgs e)
        {
            loadPreviousData();
        }
        private void loadPreviousData()
        {
            textBoxFirstName.Text = a.FirstName;
            textBoxLastName.Text = a.LastName;
            if (a.Salary != -1)
            {
                textBoxSalary.Text = a.Salary.ToString();
            }
            textBoxEmail.Text = a.Email;
            txtBoxContact.Text = a.Contact;
            //getting designation from lookup table
            SqlCommand cmd = new SqlCommand("Select value from Lookup Where id = @id and Category = @category", con);
            cmd.Parameters.AddWithValue("@id", a.Designation);
            cmd.Parameters.AddWithValue("@category", "designation");
            comboBoxDesignation.SelectedItem = cmd.ExecuteScalar();
            if (a.Gender == -1)
            {
                comboBoxGender.SelectedIndex = 2;
            }
            else
            {
                comboBoxGender.SelectedIndex = a.Gender - 1;
            }
            if (a.DateOfBirth == "")
            {
                checkBoxisDoBApplicable.Checked = true;
                dateTimePickerDoB.Enabled = false;
            }
            else
            {
                dateTimePickerDoB.Value = Convert.ToDateTime(a.DateOfBirth);
            }

        }

        private void checkBoxisDoBApplicable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxisDoBApplicable.Checked)
            {
                dateTimePickerDoB.Enabled = false;
                a.DateOfBirth = null;
            }
            else
            {
                dateTimePickerDoB.Enabled = true;
                a.DateOfBirth = dateTimePickerDoB.Value.ToString();
            }
        }
    }
}
