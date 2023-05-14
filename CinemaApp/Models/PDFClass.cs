using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Drawing;
using PdfSharp.Drawing.Layout;
using System.Diagnostics;

namespace CinemaApp.Models
{
    public class PDFClass
    {

        public static bool DownloadPdf(SummaryModel model)
        {
            try
            {
                // utworzenie dokumentu PDF
                PdfDocument document = new PdfDocument();
                MemoryStream memoryStream = new MemoryStream();

                // dodanie strony do dokumentu
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // dodanie treści do strony
                XFont titleFont = new XFont("Arial", 20, XFontStyle.Bold);
                gfx.DrawString("Bilety", titleFont, XBrushes.Black,
                    new XRect(0, 30, page.Width.Point, 0),
                    XStringFormats.Center);

                XFont dataFont = new XFont("Arial", 12);
                int y = 150;
                gfx.DrawString("Film:", dataFont, XBrushes.Black, new XPoint(50, y));
                gfx.DrawString(model.Schedule.Movie.Title, dataFont, XBrushes.Black, new XPoint(200, y));
                y += 20;
                gfx.DrawString("Sala:", dataFont, XBrushes.Black, new XPoint(50, y));
                gfx.DrawString(model.Schedule.Hall.HallName, dataFont, XBrushes.Black, new XPoint(200, y));
                y += 20;
                gfx.DrawString("Data:", dataFont, XBrushes.Black, new XPoint(50, y));
                gfx.DrawString(model.Schedule.Date.ToString(), dataFont, XBrushes.Black, new XPoint(200, y));
                y += 40;
                gfx.DrawString("Bilety:", dataFont, XBrushes.Black, new XPoint(50, y));

                XFont ticketFont = new XFont("Arial", 10);
                foreach (var ticket in model.Reservations)
                {
                    y += 20;
                    gfx.DrawString($"Rząd: {ticket.Row}, Miejsce: {ticket.Place}, Cena: {ticket.Price}", ticketFont, XBrushes.Black, new XPoint(50, y));
                }

                var Customer = model.Reservations.First();
                y += 40;
                gfx.DrawString("Dane klienta:", dataFont, XBrushes.Black, new XPoint(50, y));
                y += 20;
                gfx.DrawString($"Imię: {Customer.FirstName}", dataFont, XBrushes.Black, new XPoint(50, y));
                y += 20;
                gfx.DrawString($"Nazwisko: {Customer.LastName}", dataFont, XBrushes.Black, new XPoint(50, y));
                y += 20;
                gfx.DrawString($"Email: {Customer.Email}", dataFont, XBrushes.Black, new XPoint(50, y));
                y += 20;
                gfx.DrawString($"Telefon: {Customer.Phone}", dataFont, XBrushes.Black, new XPoint(50, y));

                string path = @"E:\ASP.NET-App\CinemaApp\CinemaApp\wwwroot\pdf";
                string filename = $"reservation{Customer.Email}{Customer.ReservationDate}.pdf";
                string filepath = Path.Combine(path, filename);

                document.Save(filepath);

                model.PDFUrl = filename;
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;

        }

    }
}