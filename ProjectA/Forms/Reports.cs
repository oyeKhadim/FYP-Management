using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
            else
            {
                #region open File and save at required location
                //    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //    saveFileDialog1.Filter = "Pdf|*.pdf";
                //    saveFileDialog1.Title = "Save Pdf Report";
                //    saveFileDialog1.FileName = "Report";
                //    saveFileDialog1.ShowDialog();
                //if (saveFileDialog1.FileName != "")
                //{
                //    // Saves the Image via a FileStream created by the OpenFile method.
                //    System.IO.FileStream fs =
                //        (System.IO.FileStream)saveFileDialog1.OpenFile();
                //fs.Close();
                //}
                //string name = saveFileDialog1.FileName;
                #endregion
                string heading = comboBoxReport.Items[comboBoxReport.SelectedIndex].ToString();
                var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                //var folderPath = "D:\\PDF\\";
                PdfReport.printPdfReport(folderPath,dgv,heading);
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
