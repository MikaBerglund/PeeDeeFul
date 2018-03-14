using PeeDeeFul.DocumentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PeeDeeFul.Client
{
    /// <summary>
    /// Represents actions that you can perform on documents.
    /// </summary>
    public class DocumentActions
    {

        internal DocumentActions(PdfClientContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private PdfClientContext Context { get; set; }



        /// <summary>
        /// Renders the given PDF DOM to an actual PDF document and writes it to the given stream.
        /// </summary>
        /// <param name="document">The document model to render to a PDF document.</param>
        /// <param name="target">The stream to write the rendered PDF document to.</param>
        public async Task RenderAsync(Document document, Stream target)
        {
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                document.WriteDdl(writer);
            }

            var ddl = sb.ToString();
            var buffer = Encoding.UTF8.GetBytes(ddl);

            var req = this.Context.CreatePostRequest("Documents/Render");
            req.ContentLength = buffer.Length;
            req.ContentType = "application/x-www-form-urlencoded";

            using (var strm = await req.GetRequestStreamAsync())
            {
                await strm.WriteAsync(buffer, 0, buffer.Length);
            }

            using (var response = await this.Context.ExecuteRequestAsync(req))
            {
                using (var strm = response.GetResponseStream())
                {
                    await strm.CopyToAsync(target);
                }
            }
        }
    }
}
