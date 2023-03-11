using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Windows.Forms;
using iTextSharp.text.pdf.draw;

namespace ProjectA.Extras
{
    internal class PdfReport
    {
        public static void printPdfReport(string folderPath, DataGridView dgv, string heading)
        {
            try
            {
                PdfPTable dataTable = new PdfPTable(1);//Here 1 is Used For Count of Column
                ////Font Style
                System.Drawing.Font fontH1 = new System.Drawing.Font("Currier", 16);
                dataTable.DefaultCell.Padding = 5;
                dataTable.WidthPercentage = 80;
                dataTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                dataTable.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                dataTable.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170);
                dataTable.DefaultCell.BorderWidth = 0;
                dataTable.DefaultCell.Padding = 5;
                //create a chunk of text
                Chunk c1 = new Chunk(heading, FontFactory.GetFont("Times New Roman"));
                c1.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c1.Font.SetStyle(0);
                c1.Font.Size = 14;
                //CreateParams a phrase and and chunk in it
                Phrase p1 = new Phrase();
                p1.Add(c1);
                //add phrase in table
                dataTable.AddCell(p1);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                PdfPTable table = new PdfPTable(dgv.Columns.Count);
                table.DefaultCell.Padding = 5;

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    table.AddCell(new Phrase(dgv.Columns[i].Name));
                }
                table.HeaderRows = 1;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv[j, i].Value != null)
                            table.AddCell(new Phrase(dgv[j, i].Value.ToString()));
                    }
                }
                //File Name
                int fileCount = Directory.GetFiles(folderPath).Length;
                string strFileName = "DescriptionForm" + (fileCount + 1) + ".pdf";
                using (FileStream stream = new FileStream(folderPath + "\\" + strFileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(dataTable);
                    pdfDoc.Add(table);
                    pdfDoc.Close();
                    stream.Close();
                }
                //#endregion
                #region Display PDF
                System.Diagnostics.Process.Start(folderPath + "\\" + strFileName);
                #endregion
                MessageBox.Show("Saved");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void GeneratePdfTesting(String appPhysicalPath)
        {
            //You need physical path of file you want to create
            var filePath = appPhysicalPath + "\\" + DateTime.Now.Ticks.ToString() + ".pdf";

            //Create Document
            var doc1 = new Document();

            //Create Document Instance and load in 'doc1'
            var streamObj = new System.IO.FileStream(filePath, System.IO.FileMode.CreateNew);
            PdfWriter.GetInstance(doc1, streamObj);
            doc1.Open();

            doc1.Add(new Paragraph("This is a custom size"));

            Chunk linebreak = new Chunk(new LineSeparator());
            //Chunk linebreak = new Chunk(new DottedLineSeparator());

            doc1.Add(linebreak);


            //Create a table with number of columns
            PdfPTable table = new PdfPTable(2);

            //Create Phrase Object (Data, Font object)
            Phrase ph = new Phrase("ABC's Data", new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, BaseColor.BLACK));

            //Create Cell using Phrase object
            PdfPCell cell = new PdfPCell(ph);
            cell.Colspan = 2;
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;

            table.AddCell(cell);

            //Second row
            table.AddCell(new PdfPCell(new Phrase("Size", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.BOLD))));
            table.AddCell("1024K");

            //Third row
            table.AddCell(new PdfPCell(new Phrase("Type", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.BOLD))));
            table.AddCell("Image");


            doc1.Add(table);

            doc1.Close();
        }

    }
}
