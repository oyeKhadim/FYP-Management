using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectA.Forms
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            ThemeColor.loadTheme(this.tableLayoutPanel);
            comboBoxReport.SelectedIndex = 0;
 
        }

        private void buttonViewReport_Click(object sender, EventArgs e)
        {
            if(comboBoxReport.SelectedIndex == 0)
            {
                dgv.DataSource = Report.detailsOfProjects();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgv.DataSource == null)
            {
                MessageBox.Show("Kindly Select a Report to Print");
            }
        }

        private void comboBoxReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxReport.SelectedIndex == 0)
            {
                dgv.DataSource = Report.detailsOfProjects();
            }
            else if(comboBoxReport.SelectedIndex == 1)
            {
                dgv.DataSource = Report.markSheet();
            }
        }
    }
}
