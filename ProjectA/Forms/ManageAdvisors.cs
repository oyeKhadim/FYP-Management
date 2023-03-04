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
    public partial class ManageAdvisors : Form
    {
        public ManageAdvisors()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form = new AddAdvisor();
            form.ShowDialog();
            loadData();
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ManageAdvisors_Load(object sender, EventArgs e)
        {
            ThemeColor.loadTheme(this.tableLayoutPanel);
            loadData();
        }
        private void loadData()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select A.ID,FirstName,LastName,l2.value Designation,Salary,Contact,Email,DateOfBirth,l.value Gender from Advisor A Join Person P on A.id=P.id Left Join Lookup L on L.Id=Gender Join Lookup L2 on L2.id=Designation", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchWithFirstName();
        }
        private void searchWithFirstName()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select A.ID,FirstName,LastName,l2.value Designation,Salary,Contact,Email,DateOfBirth,l.value Gender from Advisor A Join Person P on A.id=P.id Left Join Lookup L on L.Id=Gender Join Lookup L2 on L2.id=Designation Where FirstName like \'%" + (txtBoxSearch.Text + "%\'"), con);
                //cmd.Parameters.AddWithValue("@FirstName", txtBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {

            Advisor advisor = new Advisor();
            try
            {
                //getting data from grid view
                int col = 0;
                advisor.Id = int.Parse(dgv.SelectedRows[0].Cells[col++].Value.ToString());
                advisor.FirstName = dgv.SelectedRows[0].Cells[col++].Value.ToString();
                advisor.LastName = dgv.SelectedRows[0].Cells[col++].Value.ToString();
                string designation = dgv.SelectedRows[0].Cells[col++].Value.ToString();
                string salary = dgv.SelectedRows[0].Cells[col++].Value.ToString();
                advisor.Contact = dgv.SelectedRows[0].Cells[col++].Value.ToString();
                advisor.Email = dgv.SelectedRows[0].Cells[col++].Value.ToString();
                advisor.DateOfBirth = dgv.SelectedRows[0].Cells[col++].Value.ToString();
                string gender = dgv.SelectedRows[0].Cells[col++].Value.ToString();
                if (salary == string.Empty) { advisor.Salary = -1; } else { advisor.Salary = int.Parse(salary); }
                SqlConnection con;
                SqlCommand cmd;
                if (gender != "")
                {
                    //Getting Gender in int from lookup table
                    con = Configuration.getInstance().getConnection();
                    cmd = new SqlCommand("Select id from Lookup Where value = @value and Category = @category", con);
                    cmd.Parameters.AddWithValue("@value", gender);
                    cmd.Parameters.AddWithValue("@category", "Gender");
                    advisor.Gender = (Int32)cmd.ExecuteScalar();
                }
                else
                {
                    advisor.Gender = -1;
                }
                con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("Select id from Lookup Where value = @value and Category = @category", con);
                cmd.Parameters.AddWithValue("@value", designation);
                cmd.Parameters.AddWithValue("@category", "designation");
                advisor.Designation = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Form form = new EditAdvisor(advisor);
            form.ShowDialog();
            loadData();
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            searchWithFirstName();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Text = "";
            loadData();
        }
    }
}
