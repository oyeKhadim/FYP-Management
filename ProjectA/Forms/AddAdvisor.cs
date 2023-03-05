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
    public partial class AddAdvisor : Form
    {

        Advisor a;
        SqlConnection con;
        public AddAdvisor()
        {
            InitializeComponent();
            start();
        }
        private void start()
        {
            a = new Advisor();
            con = Configuration.getInstance().getConnection();
            a.DateOfBirth = dateTimePickerDoB.Value.ToString();
            comboBoxGender.SelectedIndex = 0;
            comboBoxDesignation.SelectedIndex = 0;
        }

        private void AddAdvisor_MouseDown(object sender, MouseEventArgs e)
        {
            Extras.Drag.dragPage(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }



        private void btnAdd_Click(object sender, EventArgs e)
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
                    //Checking whether gender is valid or not
                    try
                    {
                        designation = comboBoxDesignation.SelectedItem.ToString();
                        //Getting Gender in int from lookup table
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
                    //Adding data in person table
                    cmd = new SqlCommand("Insert into Person values (@firstName, @lastName, @contact,@email,@dob,@gender)", con);
                    cmd.Parameters.AddWithValue("@firstName", a.FirstName);
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
                    //getting id of person which is auto genrated on above entry 
                    a.Id = Person.retrieveId();
                    //Inserting data in student table
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
                    MessageBox.Show("Added");
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







        private void textBoxSalary_Leave(object sender, EventArgs e)
        {
            Validations.validateIntTextBox(textBoxSalary, errorProvider);

        }
        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            Validations.validateTextBox(textBoxFirstName, errorProvider);
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            Validations.validateTextBox(textBoxEmail, errorProvider);


        }

        private void txtBoxContact_Leave(object sender, EventArgs e)
        {
            Validations.validateIntTextBox(txtBoxContact, errorProvider);

        }
    }
}
