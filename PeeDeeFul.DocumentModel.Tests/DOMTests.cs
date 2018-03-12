using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PeeDeeFul.DocumentModel.Tests
{
    [TestClass]
    public class DOMTests
    {
        [TestMethod]
        public void CreateDOM01()
        {
            var doc = new Document();
            doc.AddSection();
            ParseDdl(doc);
        }

        [TestMethod]
        public void CreateDOM02()
        {
            var doc = new Document();
            // Just testing various unit types.
            doc.AddSection().SetPageSetup(new PageSetup()
            {
                TopMargin = new Unit(1),
                RightMargin = new Unit(2.5, UnitType.Centimeter),
                BottomMargin = new Unit(0.8, UnitType.Inch),
                LeftMargin = new Unit(20, UnitType.Millimeter),
                PageHeight = new Unit(100, UnitType.Pica),
                PageWidth = new Unit(480, UnitType.Point)
            });

            ParseDdl(doc);
        }

        [TestMethod]
        public void CreateDOM03()
        {
            var doc = new Document().AddSection().Document;
            doc.LastSection.SetPrimaryHeader();
            
            ParseDdl(doc);
        }

        [TestMethod]
        public void CreateDOM04()
        {
            var doc = new Document().AddSection().Document.SetInfo(new DocumentInfo()
            {
                Author = "Sandy \"Sleepy\" Sandman",
                Keywords = "Key, words",
                Subject = "Le subject",
                Title = "Title is everything"
            });

            ParseDdl(doc);
        }


        /// <summary>
        /// Serializes the given document to DDL and renders a PDF document from it to make sure that 
        /// the generated DDL is valid.
        /// </summary>
        private void ParseDdl(Document doc)
        {
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                doc.WriteDdl(writer);
            }
            var ddl = sb.ToString();

            var mDoc = MigraDoc.DocumentObjectModel.IO.DdlReader.DocumentFromString(ddl);
            MigraDoc.Rendering.PdfDocumentRenderer renderer = new MigraDoc.Rendering.PdfDocumentRenderer(true)
            {
                Document = mDoc
            };
            renderer.RenderDocument();

            using (var strm = new MemoryStream())
            {
                renderer.PdfDocument.Save(strm);
            }
        }

    }
}
