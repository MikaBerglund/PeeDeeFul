using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class Font : DocumentObject
    {
        public Font() : this(null) { }

        public Font(DocumentObject parent) : base(parent)
        {
            this.Color = new Color(0, 0, 0);
        }



        public bool Bold
        {
            get { return this.GetProperty<bool>(nameof(Bold)); }
            set { this.SetProperty(nameof(Bold), value); }
        }

        public Color Color
        {
            get { return this.GetProperty<Color>(nameof(Color)); }
            set { this.SetProperty(nameof(Color), value); }
        }

        public bool Italic
        {
            get { return this.GetProperty<bool>(nameof(Italic)); }
            set { this.SetProperty(nameof(Italic), value); }
        }

        public string Name
        {
            get { return this.GetProperty<string>(nameof(Name)); }
            set { this.SetProperty(nameof(Name), value); }
        }

        public Unit Size
        {
            get { return this.GetProperty<Unit>(nameof(Size)); }
            set { this.SetProperty(nameof(Size), value); }
        }

        public bool Subscript
        {
            get { return this.GetProperty<bool>(nameof(Subscript)); }
            set { this.SetProperty(nameof(Subscript), value); }
        }

        public bool Superscript
        {
            get { return this.GetProperty<bool>(nameof(Superscript)); }
            set { this.SetProperty(nameof(Superscript), value); }
        }


        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("Font");
            writer.Write("{");

            writer.Write("}");
        }
    }
}
