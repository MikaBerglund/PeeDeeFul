using PeeDeeFul.Client;
using PeeDeeFul.DocumentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeeDeeFulTestConsole
{
    class Program
    {
        static string baseUrl = "http://localhost:7071/api/";

        static void Main(string[] args)
        {
            CreatePdf01();
        }



        static void CreatePdf01()
        {
            var doc = new Document().Add(new Section()
            {
                PageSetup = new PageSetup()
                {

                }
            }).SetInfo(new DocumentInfo()
            {
                Author = "Me myself and I",
                Subject = "Test subject",
                Title = "Document Title"
            })
            .LastSection
            .AddParagraph("Hello! This is plain text for testing purposes.")
            .Document
            ;

            RenderDocument(doc);
        }

        static void CreatePdf02()
        {

        }


        static PdfClientContext GetContext()
        {
            return new PdfClientContext(baseUrl);
        }

        static string GetTempPdfPath()
        {
            return $@"C:\Temp\{Guid.NewGuid()}.pdf";
        }


        static void RenderDocument(Document doc)
        {
            var ctx = GetContext();
            var path = GetTempPdfPath();

            using (var strm = File.OpenWrite(path))
            {
                var t = ctx.Documents.RenderAsync(doc, strm);
                Task.WaitAll(t);
            }

            Process.Start(path);
        }
    }
}
