using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class Color : DocumentObject
    {
        public Color() : this(null) { }

        public Color(uint r, uint g, uint b) : this(r, g, b, null) { }

        public Color(uint r, uint g, uint b, DocumentObject parent) : this(parent)
        {

        }

        public Color(DocumentObject parent) : base(parent) { }


        public uint R
        {
            get { return this.GetProperty<uint>(nameof(R)); }
            set { this.SetProperty(nameof(R), value); }
        }

        public uint G
        {
            get { return this.GetProperty<uint>(nameof(G)); }
            set { this.SetProperty(nameof(G), value); }
        }

        public uint B
        {
            get { return this.GetProperty<uint>(nameof(B)); }
            set { this.SetProperty(nameof(B), value); }
        }


        public override void WriteDdl(TextWriter writer)
        {
            writer.Write("RGB({0},{1},{2})", this.R, this.G, this.B);
        }

    }
}
