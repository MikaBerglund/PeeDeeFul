using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeeDeeFul.DocumentModel
{
    public class Image : Shape
    {
        public Image()
        {
            this.LockAspectRatio = true;
        }



        public bool LockAspectRatio
        {
            get { return this.GetProperty<bool>(nameof(LockAspectRatio)); }
            set { this.SetProperty(nameof(LockAspectRatio), value); }
        }

        public PictureFormat PictureFormat
        {
            get { return this.GetProperty<PictureFormat>(nameof(PictureFormat)); }
            set { this.SetProperty(nameof(PictureFormat), value); }
        }

        public double? Resolution
        {
            get { return this.GetProperty<double?>(nameof(Resolution)); }
            set { this.SetProperty(nameof(Resolution), value); }
        }

        public double? ScaleHeight
        {
            get { return this.GetProperty<double?>(nameof(ScaleHeight)); }
            set { this.SetProperty(nameof(ScaleHeight), value); }
        }

        public double? ScaleWidth
        {
            get { return this.GetProperty<double?>(nameof(ScaleWidth)); }
            set { this.SetProperty(nameof(ScaleWidth), value); }
        }



        public override void WriteDdl(TextWriter writer)
        {
            writer.WriteLine("\\image");
            writer.WriteLine("[");

            writer.WriteLine("LockAspectRatio = {0}", this.LockAspectRatio);
            if (null != this.PictureFormat) this.PictureFormat.WriteDdl(writer);
            if (this.Resolution.HasValue) writer.WriteLine(string.Format(this.NumberFormatProvider, "Resolution = {0}", this.Resolution));
            if (this.ScaleHeight.HasValue) writer.WriteLine(string.Format(this.NumberFormatProvider, "ScaleHeight = {0}", this.ScaleHeight));
            if (this.ScaleWidth.HasValue) writer.WriteLine(string.Format(this.NumberFormatProvider, "ScaleWidth = {0}", this.ScaleWidth));

            base.WriteDdl(writer);

            writer.WriteLine("]");

        }
    }
}
