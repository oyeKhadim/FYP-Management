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
    public partial class MakeGroup : Form
    {
        List<int> studentsTobeAdded;
        public MakeGroup()
        {
            InitializeComponent();
            studentsTobeAdded = new List<int>();
        }

        private void MakeGroup_MouseDown(object sender, MouseEventArgs e)
        {
            Extras.Drag.dragPage(this);
        }

        private void MakeGroup_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select S.ID,FirstName,LastName ,RegistrationNo from Student S Join Person P on S.id=P.id   Left Join GroupStudent gs on gs.StudentId=s.Id Left Join Lookup l on l.id=gs.status where gs.GroupId is null or l.value=@status", con);
                cmd.Parameters.AddWithValue("@status", "inActive");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAllStudents.DataSource = dt;
                dgvAllStudents.Columns["ID"].Visible = false;
                dgvChoosedStudents.DataSource = dt.Clone();
                dgvChoosedStudents.Columns["ID"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnMakeGroup_Click(object sender, EventArgs e)
        {

            try
            {


                SqlCommand cmd;
                SqlConnection con = Configuration.getInstance().getConnection();

                //Adding data in group table
                cmd = new SqlCommand("Insert into [Group] values (@date)", con);
                DateTime dateTime = DateTime.Now;
                cmd.Parameters.AddWithValue("@date", dateTime.ToString());
                cmd.ExecuteNonQuery();
                //getting id of group which is auto genrated on above entry 
                int groupId = retrieveId();
                //Getting status in int from lookup table
                cmd = new SqlCommand("Select id from Lookup Where value = @value and Category = @category", con);
                cmd.Parameters.AddWithValue("@value", "Active");
                cmd.Parameters.AddWithValue("@category", "Status");
                int activeStatus = (Int32)cmd.ExecuteScalar();
                foreach (int sId in studentsTobeAdded)
                {
                    //Inserting data in groupstudent table
                    cmd = new SqlCommand("Insert into groupStudent values (@gid, @sId,@status,@date)", con);
                    cmd.Parameters.AddWithValue("@gid", groupId);
                    cmd.Parameters.AddWithValue("@sId", sId);
                    cmd.Parameters.AddWithValue("@status", activeStatus);
                    cmd.Parameters.AddWithValue("@date", dateTime);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Maked");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private int retrieveId()
        {
            //Getting latest autoincremented id
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select MAX(id) from [group]", con);
            return (Int32)cmd.ExecuteScalar();
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            int selectedIndex = dgvAllStudents.SelectedRows[0].Index;
            if (selectedIndex >= 0)
            {
                int col = 0;
                DataTable dt = (dgvChoosedStudents.DataSource) as DataTable;
                DataRow newRow = dt.NewRow();
                int studentid = int.Parse(dgvAllStudents.SelectedRows[0].Cells[col++].Value.ToString());
                newRow["ID"] = studentid.ToString();
                if (!studentsTobeAdded.Contains(studentid))
                {
                    newRow["FirstName"] = dgvAllStudents.SelectedRows[0].Cells[col++].Value;
                    newRow["LastName"] = dgvAllStudents.SelectedRows[0].Cells[col++].Value;
                    newRow["RegistrationNo"] = dgvAllStudents.SelectedRows[0].Cells[col++].Value;
                    dt.Rows.Add(newRow);
                    dgvChoosedStudents.DataSource = dt;
                    studentsTobeAdded.Add(studentid);
                    dgvAllStudents.Rows.RemoveAt(selectedIndex);

                }
            }

        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

            int col = 0;
            DataTable dt = (dgvAllStudents.DataSource) as DataTable;
            DataRow newRow = dt.NewRow();
            int studentid = int.Parse(dgvChoosedStudents.SelectedRows[0].Cells[col++].Value.ToString());
            newRow["ID"] = studentid.ToString();
            newRow["FirstName"] = dgvChoosedStudents.SelectedRows[0].Cells[col++].Value;
            newRow["LastName"] = dgvChoosedStudents.SelectedRows[0].Cells[col++].Value;
            newRow["RegistrationNo"] = dgvChoosedStudents.SelectedRows[0].Cells[col++].Value;
            dt.Rows.Add(newRow);
            dgvAllStudents.DataSource = dt;
            studentsTobeAdded.Remove(studentid);
            int selectedIndex = dgvChoosedStudents.SelectedRows[0].Index;

            dgvChoosedStudents.Rows.RemoveAt(selectedIndex);



        }
    }
}
