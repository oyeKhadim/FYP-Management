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
    public partial class AssignProject : Form
    {

        private GroupProject groupProject;
        SqlConnection con;
        public AssignProject(int groupId)
        {
            InitializeComponent();
             groupProject = new GroupProject();
            groupProject.GroupId = groupId;
            con=Configuration.getInstance().getConnection();
        }

        private void AssignProject_MouseDown(object sender, MouseEventArgs e)
        {
            Extras.Drag.dragPage(this);
        }

        private void AssignProject_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            try
            {
                DataTable dt = Project.loadProjects();
                fillDGV(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
        private void fillDGV(DataTable dt)
        {
            dgv.DataSource = dt;
            dgv.Columns["ID"].Visible = false;
            dgv.Columns["Title"].DisplayIndex = 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxSearchProject_TextChanged(object sender, EventArgs e)
        {
            if(textBoxSearchProject.Text!= "Search By Title...")
            {
                DataTable dt = Project.searchWithTitle(textBoxSearchProject.Text);
                fillDGV(dt);
            }
      
        }

        private void textBoxSearchProject_Leave(object sender, EventArgs e)
        {
            if (textBoxSearchProject.Text == "")
            {
                textBoxSearchProject.Font = new Font(textBoxSearchProject.Font, FontStyle.Italic);
                textBoxSearchProject.ForeColor = Color.FromName("ScrollBar");
                textBoxSearchProject.Text = "Search By Title...";
            }
        }

        private void textBoxSearchProject_Click(object sender, EventArgs e)
        {

            if (textBoxSearchProject.Text == "Search By Title...")
            {
                textBoxSearchProject.Text = "";
                textBoxSearchProject.Font = new Font(textBoxSearchProject.Font, FontStyle.Regular);
                textBoxSearchProject.ForeColor = Color.Black;
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            groupProject.ProjectId = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            groupProject.AssignmentDate=DateTime.Now;
            try
            {
                groupProject.assignProject();
                MessageBox.Show("Project Assigned");
                this.Close();
            }catch(Exception ex) { }
        }
    }
}
