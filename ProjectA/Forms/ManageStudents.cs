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
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select S.ID,FirstName,LastName,RegistrationNo,Contact,Email,DateOfBirth,Gender from Student S Join Person P on S.id=P.id", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form = new Forms.AddStudent();
            form.ShowDialog();
            loadData();
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Id = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            student.FirstName = dgv.SelectedRows[0].Cells[1].Value.ToString();
            student.LastName = dgv.SelectedRows[0].Cells[2].Value.ToString();
            student.RegistrationNo = dgv.SelectedRows[0].Cells[3].Value.ToString();
            student.Contact = dgv.SelectedRows[0].Cells[4].Value.ToString();
            student.Email = dgv.SelectedRows[0].Cells[5].Value.ToString();
            student.DateOfBirth = dgv.SelectedRows[0].Cells[6].Value.ToString();
            string gender = dgv.SelectedRows[0].Cells[7].Value.ToString();
            if (gender == "")
            {
                gender = "0";
            }
            student.Gender =int.Parse( gender);
            Form form = new EditStudent(student);
            form.ShowDialog();
            loadData();
        }
    }
}
