using System;
using System.Collections.Generic;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class Text : DocumentObject
    {
        public Text(): this(null, null) { }

        public Text(string content) : this(null, content) { }

        public Text(DocumentObject parent, string content) : base(parent)
        {
            this.Content = content;
        }

        public string Content
        {
            get { return this.GetProperty<string>(nameof(Content)); }
            set { this.SetProperty(nameof(Content), value); }
        }

    }
}
