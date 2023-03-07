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

            DataTable dt = Group.loadGroups();
            dgvGroups.DataSource = dt;
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
                MessageBox.Show("Please Select A Group First");
            }
        }

        private void dgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string groupId = dgvGroups.SelectedRows[0].Cells[0].Value.ToString();
                var con = Configuration.getInstance().getConnection();
                DataTable dt = Group.loadStudentsOfGroup(groupId);
                dgvStudents.DataSource = dt;
            }
            catch (Exception ex)
            {


            }
        }

        private void btnAssignProject_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Please Select A Group First");

            }
        }

        private void buttonEvaluate_Click(object sender, EventArgs e)
        {
            try
            {
                int groupId = int.Parse(dgvGroups.SelectedRows[0].Cells[0].Value.ToString());
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(" select count(EvaluationId) from GroupEvaluation where GroupId=@groupId", con);
                cmd.Parameters.AddWithValue("@groupId", groupId);
                int countEvaluationTaken = (Int32)cmd.ExecuteScalar();
                cmd = new SqlCommand("   select count(Id) from Evaluation", con);
                cmd.Parameters.AddWithValue("@groupId", groupId);
                int totalEvaluation = (Int32)cmd.ExecuteScalar();
                if (totalEvaluation <= countEvaluationTaken)
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
            catch (Exception ex)
            {
                MessageBox.Show("Please Select A Group First");
            }
        }
    }
}
