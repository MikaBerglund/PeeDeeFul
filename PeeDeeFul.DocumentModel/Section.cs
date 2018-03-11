using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class Section : ContainerObject
    {
        public Section() : base(null) { }

        public Section(DocumentObject parent) : base(parent) { }


        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("\\section");
            writer.WriteLine("[");
            writer.WriteLine("]");

            writer.WriteLine("{");
            base.WriteDdl(writer);
            writer.WriteLine("}");
        }
    }
}
