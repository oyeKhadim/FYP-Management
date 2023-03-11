using ProjectA.BL;
using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectA.Forms
{
    public partial class UpdateGroup : Form
    {
        List<int> studentsAlreadyAdded;
        List<int> studentsTobeAdded;
        List<int> studentsTobeRemoved;
        int groupId;
        public UpdateGroup(int groupId)
        {
            InitializeComponent();
            studentsAlreadyAdded = new List<int>();
            studentsTobeAdded = new List<int>();
            studentsTobeRemoved = new List<int>();
            this.groupId = groupId;
        }

        private void UpdateGroup_MouseDown(object sender, MouseEventArgs e)
        {
            Extras.Drag.dragPage(this);
        }

        private void UpdateGroup_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadData()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select S.ID,FirstName,LastName ,RegistrationNo from Student S Join Person P on S.id=P.id Except Select S.ID,FirstName,LastName ,RegistrationNo from Student S Join Person P on S.id=P.id  Join GroupStudent gs on gs.StudentId=s.Id Join Lookup l on l.id=gs.status where l.Value=@status", con);
                cmd.Parameters.AddWithValue("@status", "active");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAllStudents.DataSource = dt;
                dgvAllStudents.Columns["ID"].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand(" Select  S.ID,FirstName,LastName ,RegistrationNo From Student s  Join GroupStudent gs on s.Id=gs.StudentId Join Person P on S.id=P.id left join lookup l on l.Id=gs.Status   where gs.GroupId=@groupid and l.Value<>@status", con);
                cmd.Parameters.AddWithValue("@status", "inactive");
                cmd.Parameters.AddWithValue("@groupid", groupId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvChoosedStudents.DataSource = dt;
                dgvChoosedStudents.Columns["ID"].Visible = false;

                SqlDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    studentsAlreadyAdded.Add(int.Parse(DR[0].ToString()));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = dgvAllStudents.SelectedRows[0].Index;

                int col = 0;
                DataTable dt = (dgvChoosedStudents.DataSource) as DataTable;
                DataRow newRow = dt.NewRow();
                int studentid = int.Parse(dgvAllStudents.SelectedRows[0].Cells[col++].Value.ToString());
                //if (!studentsAlreadyAdded.Contains(studentid))
                //{
                newRow["ID"] = studentid.ToString();
                newRow["FirstName"] = dgvAllStudents.SelectedRows[0].Cells[col++].Value;
                newRow["LastName"] = dgvAllStudents.SelectedRows[0].Cells[col++].Value;
                newRow["RegistrationNo"] = dgvAllStudents.SelectedRows[0].Cells[col++].Value;
                dt.Rows.Add(newRow);
                dgvChoosedStudents.DataSource = dt;
                studentsTobeAdded.Add(studentid);
                studentsTobeRemoved.Remove(studentid);

                dgvAllStudents.Rows.RemoveAt(selectedIndex);

                //}

            }
            catch (Exception ex)
            {
                //MessageBox.Show("No operation can be performed on empty row");
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
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
                int selectedIndex = dgvChoosedStudents.SelectedRows[0].Index;
                dgvChoosedStudents.Rows.RemoveAt(selectedIndex);
                //studentsAlreadyAdded.Remove(studentid);
                studentsTobeAdded.Remove(studentid);
                studentsTobeRemoved.Add(studentid);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("No operation can be performed on empty row");
            }
        }

        private void btnUpdateGroup_Click(object sender, EventArgs e)
        {

            try
            {
                //remove all those students from tobeAddedlist who was already in this group
                foreach (int sid in studentsAlreadyAdded)
                {
                    studentsTobeAdded.Remove(sid);
                }

                SqlCommand cmd;
                SqlConnection con = Configuration.getInstance().getConnection();
                //Getting status in int from lookup table
                int activeStatus = LookupClass.findId("Active", "status");
                int inActiveStatus = LookupClass.findId("inActive", "status");
                DateTime dateTime = DateTime.Now;
                //Getting those students who are already in this group and their status is inActive
                cmd = new SqlCommand("select Studentid from GroupStudent where groupid=@groupId and status=@status", con);
                cmd.Parameters.AddWithValue("@groupid", groupId);
                cmd.Parameters.AddWithValue("@status", inActiveStatus);
                SqlDataReader DR = cmd.ExecuteReader();
                studentsAlreadyAdded.Clear();
                while (DR.Read())
                {
                    //storing them in seperate list as just their status will be updated
                    int sid = int.Parse(DR[0].ToString());
                    if (studentsTobeAdded.Contains(sid))
                    {

                        studentsAlreadyAdded.Add(sid);
                        studentsTobeAdded.Remove(sid);
                    }

                }
                foreach (int sId in studentsTobeAdded)
                {
                    //Inserting data in groupstudent table
                    cmd = new SqlCommand("Insert into GroupStudent values(@groupId,@sId,@status,@date)", con);
                    cmd.Parameters.AddWithValue("@groupid", groupId);
                    cmd.Parameters.AddWithValue("@sId", sId);
                    cmd.Parameters.AddWithValue("@status", activeStatus);
                    cmd.Parameters.AddWithValue("@date", dateTime);
                    cmd.ExecuteNonQuery();
                }
                foreach (int sId in studentsTobeRemoved)
                {
                    //updating status of removed student in groupstudent table
                    cmd = new SqlCommand("Update  groupStudent SET status=@status,assignmentDate=@date where groupid=@groupid and studentId=@sId", con);
                    cmd.Parameters.AddWithValue("@groupid", groupId);
                    cmd.Parameters.AddWithValue("@sId", sId);
                    cmd.Parameters.AddWithValue("@status", inActiveStatus);
                    cmd.Parameters.AddWithValue("@date", dateTime);
                    cmd.ExecuteNonQuery();
                }
                foreach (int sId in studentsAlreadyAdded)
                {
                    //updating status of reAdded student in groupstudent table
                    cmd = new SqlCommand("Update  groupStudent SET status=@status,assignmentDate=@date where groupid=@groupid and studentId=@sId", con);
                    cmd.Parameters.AddWithValue("@groupid", groupId);
                    cmd.Parameters.AddWithValue("@sId", sId);
                    cmd.Parameters.AddWithValue("@status", activeStatus);
                    cmd.Parameters.AddWithValue("@date", dateTime);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("updated");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
