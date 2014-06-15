using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;



class GeneratePDF
{
    static void Main()
    {
        string[] cardFace = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K", "A" };
        char[] cardSuits = { '♣', '♦', '♥', '♠' };

        PdfDocument pdf = new PdfDocument();

        PdfPageBase page = pdf.Pages.Add();

        Font font = new System.Drawing.Font("Arial Unicode MS", 14f, FontStyle.Bold);
        PdfTrueTypeFont trueTypeFont = new PdfTrueTypeFont(font, true);

        for (int m = 0; m < cardFace.Length; m++)
        {
            for (int j = 0; j < cardSuits.Length; j++)
            {
                page.Canvas.DrawString(cardFace[m], trueTypeFont,
          new PdfSolidBrush(Color.Black), j * 30, m * 40 + 20);
                if (j == 1 || j == 2)
                {
                    page.Canvas.DrawString(cardSuits[j] + "", trueTypeFont,
          new PdfSolidBrush(Color.Red), j * 30 + 7, m * 40 + 20);
                }
                else
                {
                    page.Canvas.DrawString(cardSuits[j] + "", trueTypeFont,
                        new PdfSolidBrush(Color.Black), j * 30 + 7, m * 40 + 20);
                }
            }
        }
        pdf.SaveToFile("hello.pdf");
        pdf.Close();

        System.Diagnostics.Process.Start("hello.pdf");
    }
}

