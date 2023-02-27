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
    public partial class ManageStudents : Form
    {
        public ManageStudents()
        {
            InitializeComponent();
     
        }
        private void loadTheme()
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button button= (Button) control;
                    button.BackColor = ThemeColor.PrimaryColor;
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private void ManageStudents_Load(object sender, EventArgs e)
        {
            loadTheme();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form = new Forms.AddStudent();
            form.ShowDialog ();
        }
    }
}
