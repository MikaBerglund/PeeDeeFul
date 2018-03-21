using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class Document : DocumentObject
    {
        /// <summary>
        /// Creates a new document.
        /// </summary>
        public Document() : base(null)
        {
        }



        /// <summary>
        /// Sets or reurns the default page setup that is used on all sections added to the document.
        /// </summary>
        public PageSetup DefaultPageSetup
        {
            get { return this.GetProperty<PageSetup>(nameof(DefaultPageSetup)); }
            set { this.SetProperty(nameof(DefaultPageSetup), value); }
        }

        /// <summary>
        /// Sets or returns the document info for the document.
        /// </summary>
        public DocumentInfo Info
        {
            get { return this.GetProperty<DocumentInfo>(nameof(Info)); }
            set { this.SetProperty(nameof(Info), value); }
        }

        /// <summary>
        /// Returns the last added section.
        /// </summary>
        public Section LastSection
        {
            get { return this.Sections.Last(); }
        }

        /// <summary>
        /// Returns all sections.
        /// </summary>
        public IEnumerable<Section> Sections
        {
            get { return this.GetChildren<Section>(); }
        }



        /// <summary>
        /// Adds the given section to the document.
        /// </summary>
        public Document Add(Section section)
        {
            base.Add(section);
            if (null == section.PageSetup) section.PageSetup = this.DefaultPageSetup;
            return this;
        }

        /// <summary>
        /// Adds a new section to the document and returns the section.
        /// </summary>
        public Section AddSection()
        {
            var s = new Section(this);
            this.Add(s);
            return s;
        }

        public Document SetInfo(DocumentInfo info)
        {
            this.Info = info;
            return this;
        }


        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("\\document");
            writer.WriteLine("[");
            if (null != this.Info) this.Info.WriteDdl(writer);
            writer.WriteLine("]");

            writer.WriteLine("{");
            base.WriteDdl(writer);
            writer.WriteLine("}");

        }

    }
}
