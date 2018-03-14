using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class PictureFormat : DocumentObject
    {

        public Unit CropTop
        {
            get { return this.GetProperty<Unit>(nameof(CropTop)); }
            set { this.SetProperty(nameof(CropTop), value); }
        }

        public Unit CropRight
        {
            get { return this.GetProperty<Unit>(nameof(CropRight)); }
            set { this.SetProperty(nameof(CropRight), value); }
        }

        public Unit CropBottom
        {
            get { return this.GetProperty<Unit>(nameof(CropBottom)); }
            set { this.SetProperty(nameof(CropBottom), value); }
        }

        public Unit CropLeft
        {
            get { return this.GetProperty<Unit>(nameof(CropLeft)); }
            set { this.SetProperty(nameof(CropLeft), value); }
        }



        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("PictureFormat");
            writer.WriteLine("{");

            if (null != this.CropTop) writer.WriteLine("CropTop = {0}", this.CropTop);
            if (null != this.CropRight) writer.WriteLine("CropRight = {0}", this.CropRight);
            if (null != this.CropBottom) writer.WriteLine("CropBottom = {0}", this.CropBottom);
            if (null != this.CropLeft) writer.WriteLine("CropLeft = {0}", this.CropLeft);

            writer.WriteLine("}");
        }
    }
}
