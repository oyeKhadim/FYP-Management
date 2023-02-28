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
    public partial class ManageAdvisors : Form
    {
        public ManageAdvisors()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form = new Forms.AddAdvisor();
            form.ShowDialog();
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
     
        }

        private void ManageAdvisors_Load(object sender, EventArgs e)
        {
            ThemeColor.loadTheme(this.tableLayoutPanel);
        }
    }
}
