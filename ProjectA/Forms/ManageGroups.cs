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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectA.Forms
{
    public partial class ManageGroups : Form
    {
        public ManageGroups()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ManageGroups_Load(object sender, EventArgs e)
        {
            ThemeColor.loadTheme(this.tableLayoutPanel);
            loadData();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form = new MakeGroup();
            form.ShowDialog();
            loadData();
        }

        private void loadData()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from [group]", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGroups.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgvGroups.SelectedRows[0].Cells[0].Value.ToString());
                Form form = new UpdateGroup(id);
                form.ShowDialog();
                loadData();
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string groupId = dgvGroups.SelectedRows[0].Cells[0].Value.ToString();
                int status = LookupClass.findId("active", "status");
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("select FirstName,LastName,RegistrationNo from GroupStudent Join Student s on s.Id=StudentId join person P on s.Id=p.id  where groupid =@groupId and status=@status", con);
                cmd.Parameters.AddWithValue("@groupId", groupId);
                cmd.Parameters.AddWithValue("@status", status);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
            }
            catch (Exception ex) { }
        }

        private void btnAssignProject_Click(object sender, EventArgs e)
        {
            int groupId = int.Parse(dgvGroups.SelectedRows[0].Cells[0].Value.ToString());
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select count(ProjectId) from GroupProject where GroupId=@groupId", con);
            cmd.Parameters.AddWithValue("@groupId", groupId);
            int count = (Int32)cmd.ExecuteScalar();
            if (count == 0)
            {
                Form form = new AssignProject(groupId);
                form.ShowDialog();
                loadData();

            }
            else
            {
                MessageBox.Show("Project is Already Assigned to this group");
            }
        }

        private void buttonEvaluate_Click(object sender, EventArgs e)
        {
            int groupId = int.Parse(dgvGroups.SelectedRows[0].Cells[0].Value.ToString());
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(" select count(EvaluationId) from GroupEvaluation where GroupId=@groupId", con);
            cmd.Parameters.AddWithValue("@groupId", groupId);
            int countEvaluationTaken = (Int32)cmd.ExecuteScalar();
             cmd = new SqlCommand("   select count(Id) from Evaluation", con);
            cmd.Parameters.AddWithValue("@groupId", groupId);
            int totalEvaluation = (Int32)cmd.ExecuteScalar();
            if(totalEvaluation<=countEvaluationTaken)
            {
                MessageBox.Show("All Available Evaluations has been done with this Group" +
                    "\nPlease Add more Evaluations to Evaluate this group");
            }
            else
            {
                Form form = new EvaluateGroup(groupId);
                form.ShowDialog();
                loadData();
            }
        }
    }
}
