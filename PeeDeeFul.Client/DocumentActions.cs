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

        internal DocumentActions(ClientContext context)
        {
            this.Context = context;
        }

        private ClientContext Context { get; set; }



        /// <summary>
        /// Renders the given PDF DOM to an actual PDF document and writes it to the given stream.
        /// </summary>
        /// <param name="document">The document model to render to a PDF document.</param>
        /// <param name="target">The stream to write the rendered PDF document to.</param>
        public async Task RenderAsync(Document document, Stream target)
        {

        }
    }
}
