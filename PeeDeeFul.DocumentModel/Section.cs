using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class Section : DocumentObject
    {
        public Section() : base(null) { }

        public Section(DocumentObject parent) : base(parent) { }


        public PageSetup PageSetup
        {
            get { return this.GetProperty<PageSetup>(nameof(PageSetup)); }
            set { this.SetProperty(nameof(PageSetup), value); }
        }

        public HeaderFooter PrimaryHeader
        {
            get { return this.GetProperty<HeaderFooter>(nameof(PrimaryHeader)); }
            set
            {
                if(null != value)
                {
                    value.IsHeader = true;
                    value.IsFooter = false;
                    value.IsPrimary = true;
                }
                this.SetProperty(nameof(PrimaryHeader), value);
            }
        }

        public HeaderFooter PrimaryFooter
        {
            get { return this.GetProperty<HeaderFooter>(nameof(PrimaryFooter)); }
            set
            {
                if (null != value)
                {
                    value.IsHeader = true;
                    value.IsFooter = false;
                    value.IsPrimary = true;
                }
                this.SetProperty(nameof(PrimaryFooter), value);
            }
        }



        public Section Add(Paragraph p)
        {
            base.Add(p);
            return this;
        }

        public Paragraph AddParagraph(string text)
        {
            var p = new Paragraph(this);
            p.AddText(text);
            this.Add(p);
            return p;
        }

        public Section SetPageSetup()
        {
            this.SetPageSetup(new PageSetup());
            return this;
        }

        public Section SetPageSetup(PageSetup pageSetup)
        {
            this.PageSetup = pageSetup;
            return this;
        }

        public Section SetPrimaryHeader()
        {
            this.SetPrimaryHeader(new HeaderFooter());
            return this;
        }

        public Section SetPrimaryHeader(HeaderFooter header)
        {
            this.PrimaryHeader = header;
            return this;
        }

        public Section SetPrimaryFooter()
        {
            this.SetPrimaryFooter(new HeaderFooter());
            return this;
        }

        public Section SetPrimaryFooter(HeaderFooter footer)
        {
            this.PrimaryFooter = footer;
            return this;
        }

        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("\\section");
            writer.WriteLine("[");
            if (null != this.PageSetup) this.PageSetup.WriteDdl(writer);
            writer.WriteLine("]");

            writer.WriteLine("{");

            if (null != this.PrimaryHeader) this.PrimaryHeader.WriteDdl(writer);
            if (null != this.PrimaryFooter) this.PrimaryFooter.WriteDdl(writer);
            base.WriteDdl(writer);

            writer.WriteLine("}");
        }
    }
}
