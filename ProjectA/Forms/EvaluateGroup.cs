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

namespace ProjectA.Forms
{
    public partial class EvaluateGroup : Form
    {
        int groupId;
        int evaluationId;
        int totalMarks;
        int weightage;
        int obtainedMarks;
        public EvaluateGroup(int groupId)
        {
            InitializeComponent();
            this.groupId = groupId;
        }

        private void EvaluateGroup_MouseDown(object sender, MouseEventArgs e)
        {
            Extras.Drag.dragPage(this);
        }

        private void EvaluateGroup_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("   select  E.ID,E.Name,E.TotalWeightage,E.TotalMarks   from Evaluation E     Except   select  E.ID,E.Name,E.TotalWeightage,E.TotalMarks   from Evaluation E  Join GroupEvaluation GE  on e.Id=ge.EvaluationId      where ge.GroupId=@groupId", con);
                cmd.Parameters.AddWithValue("@groupId", groupId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                fillDGV(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void fillDGV(DataTable dt)
        {
            dgv.DataSource = dt;
            dgv.Columns["ID"].Visible = false;

        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int col = 0;
                evaluationId = int.Parse(dgv.SelectedRows[0].Cells[col++].Value.ToString());
                dgv.SelectedRows[0].Cells[col++].Value.ToString();
                weightage = int.Parse(dgv.SelectedRows[0].Cells[col++].Value.ToString());
                totalMarks = int.Parse(dgv.SelectedRows[0].Cells[col++].Value.ToString());
                textBoxTotalMarks.Text = "/ " + totalMarks.ToString();
            }
            catch (Exception ex) { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            bool isAllInfoValid = true;
            try
            {
                if (textBoxObtainedMarks.Text == String.Empty)
                {
                    errorProvider.SetError(textBoxObtainedMarks, "Please fill Marks");
                    throw new Exception("Please fill Marks");
                }
                isAllInfoValid = Validations.validateIntTextBox(textBoxObtainedMarks, errorProvider);
                if (isAllInfoValid)
                {
                    obtainedMarks = int.Parse(textBoxObtainedMarks.Text);
                    if (totalMarks < obtainedMarks)
                    {
                        throw new Exception("Obtained Marks cannot Exceed Total Marks");
                    }
                    SqlConnection con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into GroupEvaluation values (@gId, @eId,@obtainedMarks,@date)", con);
                    cmd.Parameters.AddWithValue("@gId", groupId);
                    cmd.Parameters.AddWithValue("@eId", evaluationId);
                    cmd.Parameters.AddWithValue("@obtainedMarks", obtainedMarks);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Marks Saved");
                    this.Close();
                }
                else
                {
                    throw new Exception("Give Marks Correctly");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
