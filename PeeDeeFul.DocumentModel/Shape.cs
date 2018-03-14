using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class Shape : DocumentObject
    {

        public FillFormat FillFormat
        {
            get { return this.GetProperty<FillFormat>(nameof(FillFormat)); }
            set { this.SetProperty(nameof(FillFormat), value); }
        }
        public Unit Height
        {
            get { return this.GetProperty<Unit>(nameof(Height)); }
            set { this.SetProperty(nameof(Height), value); }
        }

        public Unit Left
        {
            get { return this.GetProperty<Unit>(nameof(Left)); }
            set { this.SetProperty(nameof(Left), value); }
        }

        public LineFormat LineFormat
        {
            get { return this.GetProperty<LineFormat>(nameof(LineFormat)); }
            set { this.SetProperty(nameof(LineFormat), value); }
        }

        public Unit Top
        {
            get { return this.GetProperty<Unit>(nameof(Top)); }
            set { this.SetProperty(nameof(Top), value); }
        }

        public Unit Width
        {
            get { return this.GetProperty<Unit>(nameof(Width)); }
            set { this.SetProperty(nameof(Width), value); }
        }

        public WrapFormat WrapFormat
        {
            get { return this.GetProperty<WrapFormat>(nameof(WrapFormat)); }
            set { this.SetProperty(nameof(WrapFormat), value); }
        }




        public override void WriteDdl(TextWriter writer)
        {
            this.FillFormat?.WriteDdl(writer);

            if (null != this.Height) writer.WriteLine("Height = {0}", this.Height);

            if (null != this.Left) writer.WriteLine("Left = {0}", this.Left);

            if(null != this.LineFormat) this.LineFormat.WriteDdl(writer);

            if (null != this.Top) writer.WriteLine("Top = {0}", this.Top);

            if (null != this.Width) writer.WriteLine("Width = {0}", this.Width);

            if (null != this.WrapFormat) this.WrapFormat.WriteDdl(writer);

        }
    }
}
