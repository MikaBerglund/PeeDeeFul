using System;
using System.Collections.Generic;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class DocumentInfo : DocumentObject
    {

        public DocumentInfo() : this(null) { }

        public DocumentInfo(DocumentObject parent) : base(parent) { }


        public string Author
        {
            get { return this.GetProperty<string>(nameof(Author)); }
            set { this.SetProperty(nameof(Author), value); }
        }

        public string Comment
        {
            get { return this.GetProperty<string>(nameof(Comment)); }
            set { this.SetProperty(nameof(Comment), value); }
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

    }
}
