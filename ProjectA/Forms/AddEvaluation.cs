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
    public partial class AddEvaluation : Form
    {
        public AddEvaluation()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEvaluation_MouseDown(object sender, MouseEventArgs e)
        {
            Extras.Drag.dragPage(this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
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
 
                Evaluation evaluation = new Evaluation();


                //if all fields all fill correctly store in database
                if (isAllInfoValid)
                {
                    evaluation.Name = textBoxName.Text;
                    evaluation.TotalMarks = int.Parse(textBoxTotalMarks.Text);
                    evaluation.TotalWeightage = int.Parse(textBoxWeightage.Text);

                    //checking weightage of evaluations
                    
                    int sumOfWeightage = Evaluation.getTotalWeightage();
                    if (sumOfWeightage + int.Parse(textBoxWeightage.Text) > 100)
                    {
                        throw new Exception("Sum of TotalWeightage of all evaluations cannot exceed 100" +
                            "\nRemaining Weightage : "+(100-sumOfWeightage));
                    }

                    //Adding data in project table
                    Evaluation.addEvaluation(evaluation);
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

        private void AddEvaluation_Load(object sender, EventArgs e)
        {

        }
    }
}
