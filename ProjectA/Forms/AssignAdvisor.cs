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
using System.Web.UI;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectA.Forms
{
    public partial class AssignAdvisor : Form
    {
        private ProjectAdvisor projectAdvisor;
        List<string> advisorRoles;
        private string searchByName = "Search By Name...";
        public AssignAdvisor()
        {
            InitializeComponent();
            projectAdvisor = new ProjectAdvisor();
            advisorRoles = new List<string>();
        }

        private void txtBoxSearchAdvisor_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxSearchAdvisor.Text != searchByName)
            {
                DataTable dt = Advisor.searchWithName(txtBoxSearchAdvisor.Text);
                dgvAdvisors.DataSource = dt;
                dgvAdvisors.Columns["ID"].Visible = false;
                projectAdvisor.AdvisorId = getAdvisorId();
            }

        }

        private void txtBoxSearchAdvisor_Click(object sender, EventArgs e)
        {

            if (txtBoxSearchAdvisor.Text == searchByName)
            {
                txtBoxSearchAdvisor.Text = "";
                txtBoxSearchAdvisor.Font = new Font(txtBoxSearchAdvisor.Font, FontStyle.Regular);
                txtBoxSearchAdvisor.ForeColor = Color.Black;
            }

        }

        private void txtBoxSearchAdvisor_Leave(object sender, EventArgs e)
        {

            if (txtBoxSearchAdvisor.Text == "")
            {
                txtBoxSearchAdvisor.Font = new Font(txtBoxSearchAdvisor.Font, FontStyle.Italic);
                txtBoxSearchAdvisor.ForeColor = Color.FromName("ScrollBar");
                txtBoxSearchAdvisor.Text = "Search By Name...";
            }
        }

        private void textBoxSearchProject_Leave(object sender, EventArgs e)
        {

            if (textBoxSearchProject.Text == "")
            {
                textBoxSearchProject.Font = new Font(textBoxSearchProject.Font, FontStyle.Italic);
                textBoxSearchProject.ForeColor = Color.FromName("ScrollBar");
                textBoxSearchProject.Text = "Search By Name...";
            }
        }

        private void textBoxSearchProject_Click(object sender, EventArgs e)
        {
            if (textBoxSearchProject.Text == searchByName)
            {
                textBoxSearchProject.Text = "";
                textBoxSearchProject.Font = new Font(txtBoxSearchAdvisor.Font, FontStyle.Regular);
                textBoxSearchProject.ForeColor = Color.Black;
            }

        }

        private void AssignAdvisor_Load(object sender, EventArgs e)
        {
            loadData();

            comboBoxAdvisorRole.SelectedIndex = 0;
            projectAdvisor.AdvisorId = getAdvisorId();
            projectAdvisor.ProjectId = getProjectId();


        }

        private void loadData()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd;
            try
            {

                DataTable dt = Advisor.load();
                dgvAdvisors.DataSource = dt;
                dgvAdvisors.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            try
            {

                DataTable dt = Project.loadProjects();
                fillDGV(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            try
            {
                advisorRoles = LookupClass.getValuesOfCategory("ADVISOR_ROLE"); 
                comboBoxAdvisorRole.DataSource=advisorRoles;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }

        }
        private void fillDGV(DataTable dt)
        {
            dgvProjects.DataSource = dt;
            dgvProjects.Columns["ID"].Visible = false;
            dgvProjects.Columns["Title"].DisplayIndex = 1;
        }



        private void dgvAdvisors_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            projectAdvisor.AdvisorId = getAdvisorId();

        }

        private void dgvProjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            projectAdvisor.ProjectId = getProjectId();

        }

        private int getAdvisorId()
        {
            int col = 0;
            try
            {
                int id = int.Parse(dgvAdvisors.SelectedRows[0].Cells[col++].Value.ToString());
                return id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        private int getProjectId()
        {

            int col = 0;
            try
            {
                int id = int.Parse(dgvProjects.SelectedRows[0].Cells[col++].Value.ToString());
                return id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        private void textBoxSearchProject_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearchProject.Text != searchByName)
            {

            DataTable dt = Project.searchWithTitle(textBoxSearchProject.Text);
            fillDGV(dt);
            projectAdvisor.ProjectId = getProjectId();
            }
        }

        private void comboBoxAdvisorRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAssign_Click(object sender, EventArgs e)
        {

            try
            {
                string aRole;
                try
                {
                    aRole = comboBoxAdvisorRole.SelectedItem.ToString();
                }
                catch
                {
                    errorProvider.SetError(comboBoxAdvisorRole, "Choose correct Role");
                    throw new Exception("Please Choose Correct Advisor Role");
                }

                SqlCommand cmd;
                SqlConnection con = Configuration.getInstance().getConnection();
                //Getting role in int from lookup table
                projectAdvisor.AdvisorRole = LookupClass.findId(aRole, "advisor_role");
                projectAdvisor.AssignmentDate = DateTime.Now;

                //Inserting data in  table
                try
                {
                    ProjectAdvisor.addProjectAdvisor(projectAdvisor);
                }
                catch
                {
                    throw new Exception("This Advisor is Already Assigned to this project");
                }
                MessageBox.Show("Assigned");
                loadData();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
