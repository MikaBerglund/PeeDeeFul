using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    /// <summary>
    /// A composite object that contains other document objects but has itself no visual elements or
    /// does not affect the appearance of other objects.
    /// </summary>
    /// <remarks>
    /// You can think of composite objects as reusable components on a document.
    /// </remarks>
    public abstract class CompositeObject : DocumentObject
    {
        /// <summary>
        /// Creates a new instance of the composite object.
        /// </summary>
        /// <param name="parent">The parent object of the composite object.</param>
        protected CompositeObject(DocumentObject parent) { }

        /// <summary>
        /// Writes the DDL of the current object to the given <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The writer object to write the DDL to.</param>
        public override void WriteDdl(TextWriter writer)
        {
            base.WriteDdl(writer);
        }

    }
}
