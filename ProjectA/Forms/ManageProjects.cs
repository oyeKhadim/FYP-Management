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
    public partial class ManageProjects : Form
    {
        public ManageProjects()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form = new Forms.AddProject();
            form.ShowDialog();
            loadData();
        }

        private void ManageProjects_Load(object sender, EventArgs e)
        {
            ThemeColor.loadTheme(this.tableLayoutPanel);
            loadData();
        }
        private void loadData()
        {
            
            DataTable dt = Project.loadProjects();
            fillDGV(dt);
        }
        private void fillDGV(DataTable dt)
        {
            dgv.DataSource = dt;
            dgv.Columns["ID"].Visible = false;
            dgv.Columns["Title"].DisplayIndex = 1;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {


                Project project = new Project();
                int col = 0;
                project.Id = int.Parse(dgv.SelectedRows[0].Cells[col++].Value.ToString());
                project.Title = dgv.SelectedRows[0].Cells[col++].Value.ToString();
                project.Description = dgv.SelectedRows[0].Cells[col++].Value.ToString();
                Form form = new EditProject(project);
                form.ShowDialog();
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select A valid Project to Edit");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = Project.searchWithTitle(txtBoxSearch.Text);
            fillDGV(dt);
        }



        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = Project.searchWithTitle(txtBoxSearch.Text);
            fillDGV(dt);

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Text = "";
            loadData();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblHeading_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

    
    }
}
