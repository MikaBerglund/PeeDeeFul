using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    /// <summary>
    /// Represents a PDF document.
    /// </summary>
    /// <remarks>
    /// You can customize how doucuments look by inheriting from this class and overriding its methods and properties. You
    /// can also create new document types that introduce their own elements.
    /// </remarks>
    public class Document : ContainerObject
    {
        /// <summary>
        /// Creates a new document.
        /// </summary>
        public Document() : base(null) { }


        public IEnumerable<Section> Sections
        {
            get { return this.GetChildren<Section>(); }
        }

        public Section AddSection()
        {
            return this.Add<Section>();
        }


        public override void WriteDdl(TextWriter writer)
        {
            // TODO: Write the doucument stuff here...

            // Then add all child objects.
            base.WriteDdl(writer);


            // TODO: Then close of anything we need to close up.

        }
    }
}
