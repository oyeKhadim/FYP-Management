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
    public partial class ManageEvaluations : Form
    {
        public ManageEvaluations()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Form form = new Forms.AddEvaluation();
            form.ShowDialog();
            loadData();
        }

        private void ManageEvaluations_Load(object sender, EventArgs e)
        {
            ThemeColor.loadTheme(this.tableLayoutPanel);
            loadData();
        }
        private void loadData()
        {
            DataTable dt = Evaluation.loadEvaluations();
            fillDGV(dt);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try { 
            Evaluation ev = new Evaluation();
            int col = 0;
            ev.Id = int.Parse(dgv.SelectedRows[0].Cells[col++].Value.ToString());
            ev.Name = dgv.SelectedRows[0].Cells[col++].Value.ToString();
            ev.TotalMarks = int.Parse(dgv.SelectedRows[0].Cells[col++].Value.ToString());
            ev.TotalWeightage = int.Parse(dgv.SelectedRows[0].Cells[col++].Value.ToString());
            Form form = new EditEvaluation(ev);
            form.ShowDialog();
            loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select An Evaluation First");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Text = "";
            loadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchWithName();
        }

        private void searchWithName()
        {
            
            DataTable dt = Evaluation.searchEvaluations(txtBoxSearch.Text);
            fillDGV(dt);
        }
        private void fillDGV(DataTable dt)
        {
            dgv.DataSource = dt;
            dgv.Columns["ID"].Visible = false;
         
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            searchWithName();
        }
    }
}
