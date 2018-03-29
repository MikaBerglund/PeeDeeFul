using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeeDeeFul.DocumentModel.Tests
{
    public static class Tools
    {

        /// <summary>
        /// Serializes the given document to DDL and renders a PDF document from it to make sure that 
        /// the generated DDL is valid.
        /// </summary>
        public static void ParseDdl(Document doc)
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
