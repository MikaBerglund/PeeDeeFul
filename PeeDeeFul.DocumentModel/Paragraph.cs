using System;
using System.Collections.Generic;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class Paragraph : ContainerObject
    {
        public Paragraph() : this(null) { }

        public Paragraph(DocumentObject parent) : base(parent) { }


        /// <summary>
        /// The name of the style that applies to the object.
        /// </summary>
        public string StyleName
        {
            get { return this.GetProperty<string>(nameof(StyleName)); }
            set { this.SetProperty(nameof(StyleName), value); }
        }

        /// <summary>
        /// The format that is associated with the object.
        /// </summary>
        public ParagraphFormat Format
        {
            get { return this.GetProperty<ParagraphFormat>(nameof(Format)); }
            set { this.SetProperty(nameof(Format), value); }
        }


        public Paragraph Add(Text text)
        {
            this.Add(text);
            return this;
        }

        public Text AddText(string text)
        {
            var t = new Text(text);
            this.Add(t);
            return t;
        }

        
    }
}
