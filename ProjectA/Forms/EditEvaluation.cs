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
    public partial class EditEvaluation : Form
    {
        private Evaluation evaluation;
        public EditEvaluation(Evaluation evaluation)
        {
            InitializeComponent();
            this.evaluation = evaluation;
        }

        private void EditEvaluation_MouseDown(object sender, MouseEventArgs e)
        {
            Extras.Drag.dragPage(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditEvaluation_Load(object sender, EventArgs e)
        {
            textBoxName.Text = evaluation.Name;
            textBoxTotalMarks.Text = evaluation.TotalMarks.ToString();
            textBoxWeightage.Text = evaluation.TotalWeightage.ToString();
            textBoxTotalMarks.Enabled = false;
            textBoxWeightage.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                //validating all fields
                SqlConnection con = Configuration.getInstance().getConnection();
                bool isAllInfoValid = true;
                isAllInfoValid = Validations.validateTextBox(textBoxName, errorProvider) &&
                    Validations.validateTextBox(textBoxTotalMarks, errorProvider) &&
                    Validations.validateTextBox(textBoxWeightage, errorProvider) &&
                    Validations.validateIntTextBox(textBoxTotalMarks, errorProvider) &&
                    Validations.validateIntTextBox(textBoxWeightage, errorProvider);
                Validations.validateTextBox(textBoxTotalMarks, errorProvider);
                Validations.validateTextBox(textBoxWeightage, errorProvider);
                Validations.validateIntTextBox(textBoxTotalMarks, errorProvider);
                Validations.validateIntTextBox(textBoxWeightage, errorProvider);



                //if all fields all fill correctly store in database
                if (isAllInfoValid)
                {
                    evaluation.Name = textBoxName.Text;
                    //evaluation.TotalMarks = int.Parse(textBoxTotalMarks.Text);
                    //evaluation.TotalWeightage = int.Parse(textBoxWeightage.Text);

                    SqlCommand cmd;


                    //Adding data in project table
                    cmd = new SqlCommand("Update Evaluation SET  name=@name Where id=@id", con);
                    //cmd = new SqlCommand("Update Evaluation SET  name=@name,totalmarks=@marks,TotalWeightage=@weightage Where id=@id", con);
                    cmd.Parameters.AddWithValue("@id", evaluation.Id);
                    cmd.Parameters.AddWithValue("@name", evaluation.Name);
                    //cmd.Parameters.AddWithValue("@marks", evaluation.TotalMarks);
                    //cmd.Parameters.AddWithValue("@weightage", evaluation.TotalWeightage);
                    //inserting null values in database if user has not provided full informations

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
    }
}
