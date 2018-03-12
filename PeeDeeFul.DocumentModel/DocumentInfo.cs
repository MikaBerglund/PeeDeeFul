using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    /// <summary>
    /// Exposes document information data.
    /// </summary>
    public class DocumentInfo : DocumentObject
    {

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        public DocumentInfo() : this(null) { }

        /// <summary>
        /// Creates a new instance of the class and specifies the parent object.
        /// </summary>
        /// <param name="parent"></param>
        public DocumentInfo(Document parent) : base(parent) { }


        public string Author
        {
            get { return this.GetProperty<string>(nameof(Author)); }
            set { this.SetProperty(nameof(Author), value); }
        }

        public string Keywords
        {
            get { return this.GetProperty<string>(nameof(Keywords)); }
            set { this.SetProperty(nameof(Keywords), value); }
        }

        public string Subject
        {
            get { return this.GetProperty<string>(nameof(Subject)); }
            set { this.SetProperty(nameof(Subject), value); }
        }

        public string Title
        {
            get { return this.GetProperty<string>(nameof(Title)); }
            set { this.SetProperty(nameof(Title), value); }
        }


        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("Info");
            writer.WriteLine("{");

            this.WriteStringProperty(nameof(Author), this.Author, writer);
            this.WriteStringProperty(nameof(Keywords), this.Keywords, writer);
            this.WriteStringProperty(nameof(Subject), this.Subject, writer);
            this.WriteStringProperty(nameof(Title), this.Title, writer);
            writer.WriteLine("}");
        }

    }
}
