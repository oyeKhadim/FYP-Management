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
    public partial class ManageStudents : Form
    {
        public ManageStudents()
        {
            InitializeComponent();
        }
        private void ManageStudents_Load(object sender, EventArgs e)
        {
            ThemeColor.loadTheme(this.tableLayoutPanel);
            loadData();
        }
        private void loadData()
        {
            DataTable dt = Student.loadStudents();
            dgv.DataSource = dt;
            dgv.Columns["ID"].Visible = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form = new Forms.AddStudent();
            form.ShowDialog();
            loadData();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            try
            {
                //getting data from grid view
                student.Id = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
                student.FirstName = dgv.SelectedRows[0].Cells[1].Value.ToString();
                student.LastName = dgv.SelectedRows[0].Cells[2].Value.ToString();
                student.RegistrationNo = dgv.SelectedRows[0].Cells[3].Value.ToString();
                student.Contact = dgv.SelectedRows[0].Cells[4].Value.ToString();
                student.Email = dgv.SelectedRows[0].Cells[5].Value.ToString();
                student.DateOfBirth = dgv.SelectedRows[0].Cells[6].Value.ToString();
                string gender = dgv.SelectedRows[0].Cells[7].Value.ToString();
                if (gender != "")
                {
                    //Getting Gender in int from lookup table
                    student.Gender = LookupClass.findId(gender, "Gender");

                }
                else
                {
                    student.Gender = -1;
                }
                Form form = new EditStudent(student);
                form.ShowDialog();
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select A valid Student");
            }
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = Student.searchInStudents(txtBoxSearch.Text);
            dgv.DataSource = dt;
            dgv.Columns["ID"].Visible = false;
        }


        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = Student.searchInStudents(txtBoxSearch.Text);
            dgv.DataSource = dt;
            dgv.Columns["ID"].Visible = false;

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Text = "";
            loadData();
        }
    }
}
