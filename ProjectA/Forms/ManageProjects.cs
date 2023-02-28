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
        }

        private void ManageProjects_Load(object sender, EventArgs e)
        {
            ThemeColor.loadTheme(this.tableLayoutPanel);
        }
    }
}
