using System;
using Novacode;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace WordDocumentGeneratorTest
{
    public class DocX_Examples
    {
        public void CreateDocument()
        {
            // Create Document
            string fileName = @"../../docxFile.docx";
            using (var doc = DocX.Create(fileName))
            {
                string headerText = "SoftUni OOP Game Contest";
                string[] contentText =
            {
                "SoftUni is organizing a contest for the best ",
                "role playing game",
                 " from the OOP teamwork projects. The winning teams will receive a ",
                 "grand prize",
                 "!",
                 " The game should be:"};

                string[] bullets =
            {
                "Properly structured and follow all good OOP practices",
                "Awesome",
                "..Very Awesome"
            };
                string[] tableHeaders =
            {
                "Team", "Game", "Points"
            };
                string[] footer =
            {
                "The top 3 teams will receive a ",
                "SPECTACULAR ",
                "prize:",
                "A handshake from Nakov"
            };

                // Document
                doc.MarginLeft = 140F;
                doc.MarginRight = 130F;
                doc.MarginTop = 100F;
                doc.MarginBottom = 180F;
                // A formatting object for our headerText:
                var headerFormat = new Formatting();
                headerFormat.FontFamily = new System.Drawing.FontFamily("Arial");
                headerFormat.Size = 24D;
                headerFormat.Position = 22;
                headerFormat.Bold = true;

                // A formatting object for our contentText:   
                var contentFormat = new Formatting();
                contentFormat.FontFamily = new System.Drawing.FontFamily("Arial");
                contentFormat.Size = 4D;

                // Header
                Paragraph title = doc.InsertParagraph(headerText, false, headerFormat);
                title.Alignment = Alignment.center;

                // Add an Image to the docx file
                Novacode.Image img = doc.AddImage(@"../../rpg-game.png");

                // Insert an emptyParagraph into this document.
                Paragraph p = doc.InsertParagraph("", false);
                Picture pic = img.CreatePicture();     // Create picture.
                pic.Height = 270;
                pic.Width = 520;
                p.Alignment = Alignment.center;
                p.InsertPicture(pic);


                // Content
                doc.InsertParagraph("", false);
                Paragraph contentBody = doc.InsertParagraph("", false, contentFormat);
                contentBody.Append(contentText[0]).Append(contentText[1]).Bold().Append(contentText[2]);
                contentBody.Append(contentText[3]).Bold().UnderlineColor(Color.Black).Append(contentText[4]);
                contentBody.AppendLine(contentText[5]);
                contentBody.Direction = Direction.LeftToRight;
                doc.InsertParagraph("", false);

                // Bullet
                var bulletedList = doc.AddList(bullets[0], 0, ListItemType.Bulleted);
                doc.AddListItem(bulletedList, bullets[1]);
                doc.AddListItem(bulletedList, bullets[2]);
                doc.InsertList(bulletedList);
                doc.InsertParagraph("");

                // Table
                Table table = doc.AddTable(4, 3);
                for (int i = 0; i < table.ColumnCount; i++)
                {
                    table.Rows[0].Cells[i].FillColor = Color.Blue;
                    table.Rows[0].Cells[i].Paragraphs.First().Append(tableHeaders[i])
                    .Color(Color.White).Bold().Alignment = Alignment.center;
                }
                for (int i = 1; i < table.RowCount; i++)
                {
                    for (int j = 0; j < table.ColumnCount; j++)
                    {
                        table.Rows[i].Cells[j].Paragraphs.First().Append("-").Alignment = Alignment.center;
                    }
                }
                table.Alignment = Alignment.center;
                table.Design = TableDesign.TableGrid;
                doc.InsertTable(table);

                // Footer
                doc.InsertParagraph("");
                doc.InsertParagraph(footer[0]).
                Append(footer[1]).Bold().CapsStyle(CapsStyle.caps).
                Append(footer[2]).Alignment = Alignment.center;
                doc.InsertParagraph(footer[3]).CapsStyle(CapsStyle.caps).
                    Bold().FontSize(24).UnderlineStyle(UnderlineStyle.singleLine).
                    Color(Color.DarkBlue).Alignment = Alignment.center;

                // Save
                doc.Save();

                // Open in Word:
                Process.Start("WINWORD.EXE", fileName);
            }
        }
   }

    class WordDocumentGenerator
    {
        static void Main(string[] args)
        {
            DocX_Examples docX = new DocX_Examples();
            docX.CreateDocument();
         }
    }
}
