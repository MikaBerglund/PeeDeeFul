using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    /// <summary>
    /// Represents plain text on a PDF document.
    /// </summary>
    public class Text : DocumentObject
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public Text(): this(null, null) { }

        /// <summary>
        /// Creates a new instance using the given string as content.
        /// </summary>
        /// <param name="content">The text to use as content.</param>
        public Text(string content) : this(null, content) { }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="parent">The parent object of the <see cref="Text"/> object.</param>
        /// <param name="content">The text to use as content.</param>
        public Text(DocumentObject parent, string content) : base(parent)
        {
            this.Content = content;
        }

        /// <summary>
        /// Sets or returns the text content of the current object.
        /// </summary>
        public string Content
        {
            get { return this.GetProperty<string>(nameof(Content)); }
            set { this.SetProperty(nameof(Content), value); }
        }



        /// <summary>
        /// Renders the content.
        /// </summary>
        public override void WriteDdl(TextWriter writer)
        {
            writer.Write(this.Content);
        }

    }
}
