using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class LineFormat : DocumentObject
    {

        public Color Color
        {
            get { return this.GetProperty<Color>(nameof(Color)); }
            set { this.SetProperty(nameof(Color), value); }
        }

        public DashStyle DashStyle
        {
            get { return this.GetProperty<DashStyle>(nameof(DashStyle)); }
            set { this.SetProperty(nameof(DashStyle), value); }
        }

        public LineStyle Style
        {
            get { return this.GetProperty<LineStyle>(nameof(Style)); }
            set { this.SetProperty(nameof(Style), value); }
        }

        public Unit Width
        {
            get { return this.GetProperty<Unit>(nameof(Width)); }
            set { this.SetProperty(nameof(Width), value); }
        }

        public bool Visible
        {
            get { return this.GetProperty<bool>(nameof(Visible)); }
            set { this.SetProperty(nameof(Visible), value); }
        }



        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("LineFormat");
            writer.WriteLine("{");

            if (null != this.Color) writer.WriteLine("Color = {0}", this.Color);
            writer.WriteLine("DashStyle = {0}", this.DashStyle);
            writer.WriteLine("Style = {0}", this.Style);
            if (null != this.Width) writer.WriteLine("Width = {0}", this.Width);
            writer.WriteLine("Visible = {0}", this.Visible);

            writer.WriteLine("}");
        }
    }
}
