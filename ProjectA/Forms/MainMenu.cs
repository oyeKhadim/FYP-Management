using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectA.Forms
{
    public partial class MainMenu : Form
    {

        private Button currentButton;
        private Random random = new Random();
        private int tempIndex;
        private Form activeForm;



        public MainMenu()
        {
            InitializeComponent();
            btnCloseChildForm.Visible = false;
        }

        private Color selectColor()
        {

            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void activateButton(object sender)
        {
            if (sender != null)
            {
                if (currentButton != (Button)sender)
                {
                    deactivateButton();
                    Color color = selectColor();
                    currentButton = (Button)sender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.WhiteSmoke;
                    currentButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTopBar.BackColor = color;
                    Color backColor = ThemeColor.ChangeColorBrightness(color, 0.3);
                    paneltopLeft.BackColor = backColor;
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = backColor;
                }
            }
        }
        private void deactivateButton()
        {
            foreach (Control control in panelSideBar.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.BackColor = Color.FromArgb(85, 107, 47);
                    control.ForeColor = Color.White;
                    control.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void openCildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelChildForm.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
            lblTopBar.Text = childForm.Text;
            btnCloseChildForm.Visible = true;
        }

        private void buttonManageStudents_Click(object sender, EventArgs e)
        {
            openCildForm(new Forms.ManageStudents(), sender);
        }

        private void buttonManageAdvisors_Click(object sender, EventArgs e)
        {
            openCildForm(new Forms.ManageAdvisors(), sender);

        }

        private void buttonManageProjects_Click(object sender, EventArgs e)
        {
            openCildForm(new Forms.ManageProjects(), sender);

        }

        private void buttonManageGroups_Click(object sender, EventArgs e)
        {
            openCildForm(new Forms.ManageGroups(), sender);

        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if(activeForm!=null)
            {
                activeForm.Close();

            }    
            reset();
        }
        private void reset()
        {
            deactivateButton();
            lblTopBar.Text = "HOME";
            panelTopBar.BackColor = Color.FromArgb(160, 160, 160);
            paneltopLeft.BackColor = Color.FromArgb(188, 188, 188);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

   



        private void panelTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            Extras.Drag.dragPage(this);
        }

        private void panelSideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonManageEvaluations_Click(object sender, EventArgs e)
        {
            openCildForm(new Forms.ManageEvaluations(), sender);
        }

        private void buttonAssignAdvisor_Click(object sender, EventArgs e)
        {
            openCildForm(new Forms.AssignAdvisor(), sender);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
