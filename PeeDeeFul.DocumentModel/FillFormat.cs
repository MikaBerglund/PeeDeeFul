using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class FillFormat : DocumentObject
    {
        public FillFormat()
        {
            this.Color = new Color(0, 0, 0);
            this.Visible = false;
        }

        public Color Color { get; set; }

        public bool Visible { get; set; }


        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("FillFormat");
            writer.WriteLine("{");

            if(null != this.Color)
            {
                writer.Write("Color = ");
                this.Color.WriteDdl(writer);
                writer.WriteLine();
            }

            writer.Write(nameof(Visible));
            writer.Write(" = ");
            writer.WriteLine(this.Visible);

            writer.WriteLine("}");
        }
    }
}
