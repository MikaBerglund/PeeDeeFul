using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class WrapFormat : DocumentObject
    {



        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("WrapFormat");
            writer.WriteLine("{");


            writer.WriteLine("}");
        }
    }
}
