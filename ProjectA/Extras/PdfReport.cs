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
        public static void printPdfReport(string folderPath)
        {
            try
            {
                //#region Common Part
                //PdfPTable pdfTableBlank = new PdfPTable(1);
                ////Footer Section
                //PdfPTable pdfTableFooter = new PdfPTable(1);
                //pdfTableFooter.DefaultCell.BorderWidth = 0;
                //pdfTableFooter.WidthPercentage = 100;
                //pdfTableFooter.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                //Chunk cnkFooter = new Chunk("FYP Reports", FontFactory.GetFont("Times New Roman"));
                ////cnkFooter.Font.SetStyle(1);
                //cnkFooter.Font.Size = 10;
                //pdfTableFooter.AddCell(new Phrase(cnkFooter));
                ////End Of Footer Section

                //PdfWriter writer = new PdfWriter();
                //string footerText="this is foooter";
                //Paragraph footer = new Paragraph(footerText, FontFactory.GetFont(FontFactory.TIMES, 8, iTextSharp.text.Font.NORMAL, BaseColor.GRAY));
                //footer.Alignment = Element.ALIGN_RIGHT;
                //PdfPTable footerTbl = new PdfPTable(1);
                //footerTbl.TotalWidth = 300;
                //footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;

                //PdfPCell cell = new PdfPCell(footer);
                //cell.Border = 0;
                //cell.PaddingLeft = 5;

                //footerTbl.AddCell(cell);
                //footerTbl.WriteSelectedRows(0, -1, 500, 30, writer.DirectContent);


                //pdfTableBlank.AddCell(new Phrase(" "));
                //pdfTableBlank.DefaultCell.Border = 0;
                //#endregion
                //#region Page
                //#region Section-1
                //PdfPTable pdfTable1 = new PdfPTable(1);//Here 1 is Used For Count of Column
                //PdfPTable pdfTable2 = new PdfPTable(1);
                //PdfPTable pdfTable3 = new PdfPTable(2);
                ////Font Style
                //System.Drawing.Font fontH1 = new System.Drawing.Font("Currier", 16);
                ////pdfTable1.DefaultCell.Padding = 5;
                //pdfTable1.WidthPercentage = 80;
                //pdfTable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                //pdfTable1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                ////pdfTable1.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170);
                //pdfTable1.DefaultCell.BorderWidth = 0;
                ////pdfTable1.DefaultCell.Padding = 5;
                //pdfTable2.WidthPercentage = 80;
                //pdfTable2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                //pdfTable2.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                ////pdfTab2e1.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170);
                //pdfTable2.DefaultCell.BorderWidth = 0;
                //pdfTable3.DefaultCell.Padding = 5;
                //pdfTable3.WidthPercentage = 80;
                //pdfTable3.DefaultCell.BorderWidth = 0.5f;
                //Chunk c1 = new Chunk("Reports", FontFactory.GetFont("Times New Roman"));
                //c1.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                //c1.Font.SetStyle(0);
                //c1.Font.Size = 14;
                //Phrase p1 = new Phrase();
                //p1.Add(c1);
                //pdfTable1.AddCell(p1);
             
                //#endregion
                //#region Section-1
                //PdfPTable pdfTable4 = new PdfPTable(4);
                
                //pdfTable4.DefaultCell.Padding = 5;
                //pdfTable4.WidthPercentage = 80;
                //pdfTable4.DefaultCell.BorderWidth = 0.0f;
                //pdfTable4.AddCell(new Phrase("Bill No "));
                //pdfTable4.AddCell(new Phrase("B001"));
                //pdfTable4.AddCell(new Phrase("Date "));
                //pdfTable4.AddCell(new Phrase("01-01-2017"));
                //pdfTable4.AddCell(new Phrase("Vendor "));
                //pdfTable4.AddCell(new Phrase("Demo Vendor"));
                //pdfTable4.AddCell(new Phrase("Address "));
                //pdfTable4.AddCell(new Phrase("Kolkata"));
                //#endregion
                //#region Section-Image
                //string imageURL = "D:\\Pic\\me.jpg";
                //iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                ////Resize image depend upon your need
                //jpg.ScaleToFit(140f, 120f);
                ////Give space before image
                //jpg.SpacingBefore = 10f;
                ////Give some space after the image
                //jpg.SpacingAfter = 1f;
                //jpg.Alignment = Element.ALIGN_CENTER;
                //#endregion
                //#region section Table
                //pdfTable3.AddCell(new Phrase("COMPANY NAME "));
                //pdfTable3.AddCell(new Phrase(""));
                //pdfTable3.AddCell(new Phrase("JOB TITLE "));
                //pdfTable3.AddCell(new Phrase(""));
                //pdfTable3.AddCell(new Phrase("ADDRESS"));
                //pdfTable3.AddCell(new Phrase(""));
                //pdfTable3.AddCell(new Phrase("CONTACT NO "));
                //pdfTable3.AddCell(new Phrase(""));
                //#endregion
                //#endregion
                //#region Pdf Generation
     
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                //File Name
                int fileCount = Directory.GetFiles(folderPath).Length;
                string strFileName = "DescriptionForm" + (fileCount + 1) + ".pdf";
                using (FileStream stream = new FileStream(folderPath +"\\"+ strFileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    #region PAGE-1
                    //pdfDoc.Add(pdfTable1);
                    //pdfDoc.Add(pdfTable2);
                    //pdfDoc.Add(pdfTableBlank);
                    //pdfDoc.Add(jpg);
                    //pdfDoc.Add(pdfTable3);
                    //pdfDoc.Add(pdfTableFooter);
                    //pdfDoc.NewPage();
                    //pdfDoc.Add(pdfTableFooter);
                    #endregion
                    // pdfDoc.Add(jpg);
                    //pdfDoc.Add(pdfTable2);
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
