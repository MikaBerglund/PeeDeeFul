using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class HeaderFooter : ContainerObject
    {
        public HeaderFooter() : this(null) { }

        public HeaderFooter(DocumentObject parent) : base(parent) { }



        public bool IsHeader
        {
            get { return this.GetProperty<bool>(nameof(IsHeader)); }
            set { this.SetProperty(nameof(IsHeader), value); }
        }

        public bool IsFooter
        {
            get { return this.GetProperty<bool>(nameof(IsFooter)); }
            set { this.SetProperty(nameof(IsFooter), value); }
        }

        public bool IsPrimary
        {
            get { return this.GetProperty<bool>(nameof(IsPrimary)); }
            set { this.SetProperty(nameof(IsPrimary), value); }
        }


        public override void WriteDdl(TextWriter writer)
        {
            writer.Write("\\");

            if (this.IsPrimary) writer.Write("primary");
            if(this.IsHeader) writer.Write("header");
            if (this.IsFooter) writer.Write("footer");
            writer.WriteLine();

            writer.Write("[");
            writer.Write("]");

            writer.Write("{");
            writer.Write("}");
        }

    }
}
