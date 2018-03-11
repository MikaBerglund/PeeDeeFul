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

            var mDoc = MigraDoc.DocumentObjectModel.IO.DdlReader.DocumentFromString(sb.ToString());
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
