using System;
using System.Collections.Generic;
using System.IO;
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



        /// <summary>
        /// Adds the given <see cref="Text"/> object to the paragraph.
        /// </summary>
        /// <param name="text">The text to add.</param>
        /// <returns>Returns the current paragraph instance.</returns>
        public Paragraph Add(Text text)
        {
            base.Add(text);
            return this;
        }

        /// <summary>
        /// Adds a space to the current section.
        /// </summary>
        public Paragraph AddSpace()
        {
            this.AddText(" ");
            return this;
        }

        /// <summary>
        /// Adds the given string as a <see cref="Text"/> object to the current paragraph
        /// and returns the <see cref="Text"/> object.
        /// </summary>
        /// <param name="text">The string to add as text.</param>
        public Text AddText(string text)
        {
            var t = new Text(text);
            this.Add(t);
            return t;
        }

        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("\\paragraph");
            writer.WriteLine("[");
            writer.WriteLine("]");

            writer.WriteLine("{");

            foreach (var child in this.Children)
            {
                child.WriteDdl(writer);
            }

            writer.WriteLine("}");
        }

    }
}
