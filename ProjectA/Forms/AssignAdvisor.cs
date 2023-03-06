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

                cmd = new SqlCommand("Select A.ID,FirstName+' '+LastName Name,l2.value Designation,Salary,Contact,Email,DateOfBirth,l.value Gender from Advisor A Join Person P on A.id=P.id Left Join Lookup L on L.Id=Gender Join Lookup L2 on L2.id=Designation", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAdvisors.DataSource = dt;
                dgvAdvisors.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            try
            {

                cmd = new SqlCommand("Select * from Project", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                fillDGV(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            try
            {

                cmd = new SqlCommand("Select value from Lookup where category=@category", con);
                cmd.Parameters.AddWithValue("@category", "ADVISOR_ROLE");
                SqlDataReader DR = cmd.ExecuteReader();
                comboBoxAdvisorRole.Items.Clear();
                advisorRoles.Clear();
                while (DR.Read())
                {
                    comboBoxAdvisorRole.Items.Add(DR[0]);
                    advisorRoles.Add(DR[0].ToString());
                }
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
                cmd = new SqlCommand("Select id from Lookup Where value = @value and Category = @category", con);
                cmd.Parameters.AddWithValue("@value", aRole);
                cmd.Parameters.AddWithValue("@category", "ADVISOR_ROLE");
                projectAdvisor.AdvisorRole = (Int32)cmd.ExecuteScalar();
                projectAdvisor.AssignmentDate = DateTime.Now;

                //Inserting data in  table
                try
                {
                    cmd = new SqlCommand("Insert into ProjectAdvisor values (@advisroId,@projectId,@aRole,@date)", con);
                    cmd.Parameters.AddWithValue("@advisroId", projectAdvisor.AdvisorId);
                    cmd.Parameters.AddWithValue("@projectId", projectAdvisor.ProjectId);
                    cmd.Parameters.AddWithValue("@aRole", projectAdvisor.AdvisorRole);
                    cmd.Parameters.AddWithValue("@date", projectAdvisor.AssignmentDate);

                    cmd.ExecuteNonQuery();
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
