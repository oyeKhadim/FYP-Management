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
    public partial class AddProject : Form
    {
        public AddProject()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddProject_MouseDown(object sender, MouseEventArgs e)
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
                isAllInfoValid = Validations.validateTextBox(textBoxTitle, errorProvider);
                Validations.validateTextBox(textBoxTitle, errorProvider);
                Project project = new Project();
                project.Title = textBoxTitle.Text;
                project.Description = richTextBoxDescription.Text;

                //if all fields all fill correctly store in database
                if (isAllInfoValid)
                {
                    //Adding data in project table
                    Project.addProject(project);
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
    }
}
