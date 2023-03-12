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
    public partial class EditProject : Form
    {
        private Project project;
        public EditProject(Project project)
        {
            InitializeComponent();
            this.project = project;
         
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditProject_Load(object sender, EventArgs e)
        {
            loadPreviousData();
        }
        private void loadPreviousData()
        {
            textBoxTitle.Text = project.Title;
            richTextBoxDescription.Text = project.Description;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                //validating all fields
                SqlConnection con = Configuration.getInstance().getConnection();
                bool isAllInfoValid = true;
                isAllInfoValid = Validations.validateTextBox(textBoxTitle, errorProvider);
                //Validations.validateTextBox(textBoxTitle, errorProvider);
                project.Title = textBoxTitle.Text;
                project.Description = richTextBoxDescription.Text;

                //if all fields all fill correctly store in database
                if (isAllInfoValid)
                {
                    //updating data in project table
                    Project.updateProject(project);
                    MessageBox.Show("updated");
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
