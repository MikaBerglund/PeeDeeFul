﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PeeDeeFul.DocumentModel
{
    /// <summary>
    /// Represents an image on a PDF document.
    /// </summary>
    /// <remarks>
    /// In <c>PeeDeeFul</c>, images are handled a bit differently than when normally building PDF documents. This is because
    /// the PDF DOM is usually built on one device, but rendered to a PDF document on another (PeeDeeFul.Server). IN normal
    /// situations, images are just separate files that are referenced from disk, but when the document rendering is done
    /// elsewhere, the image must be packed with the DOM itself, and sent with the DOM to the server for rendering.
    /// </remarks>
    public class Image : Shape
    {
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        public Image()
        {
            this.LockAspectRatio = true;
        }


        /// <summary>
        /// Not to be set directly from application code.
        /// </summary>
        public string Base64Data
        {
            get { return this.GetProperty<string>(nameof(Base64Data)); }
            set { this.SetProperty(nameof(Base64Data), value); }
        }

        public bool LockAspectRatio
        {
            get { return this.GetProperty<bool>(nameof(LockAspectRatio)); }
            set { this.SetProperty(nameof(LockAspectRatio), value); }
        }

        public string Name
        {
            get { return this.GetProperty<string>(nameof(Name)); }
            set { this.SetProperty(nameof(Name), value); }
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

        /// <summary>
        /// Sets or returns the reference to the image file.
        /// </summary>
        public FileInfo SourceFile
        {
            get { return this.GetProperty<FileInfo>(nameof(SourceFile)); }
            set
            {
                this.SetProperty(nameof(SourceFile), value);
                if(null != value)
                {
                    this.Name = value.Name;
                    this.SourceUrl = null; // If file reference is set, then we clear the URL reference.
                }

                // Clear the Base64 data to ensure that it gets updated to match the change in the property.
                this.Base64Data = null;
            }
        }

        /// <summary>
        /// Sets or returns the reference to the image as a URL. When the document is processed,
        /// this image is downloaded and included in the document.
        /// </summary>
        public Uri SourceUrl
        {
            get { return this.GetProperty<Uri>(nameof(SourceUrl)); }
            set
            {
                this.SetProperty(nameof(SourceUrl), value);
                if(null != value)
                {
                    this.SourceFile = null; // If URL reference is set, then we clear the file reference.
                }

                // Clear the Base64 data to ensure that it gets updated to match the change in the property.
                this.Base64Data = null;
            }
        }



        /// <summary>
        /// This method takes care of preparing image sources by loading the images from the URL specified
        /// in <see cref="SourceUrl"/> or the file specified in <see cref="SourceFile"/> and stores the
        /// image in the <see cref="Base64Data"/> property for transfering to the server.
        /// </summary>
        /// <returns></returns>
        public async Task PrepareSourcesAsync()
        {
            if(null != this.SourceFile)
            {
                await this.LoadFileAsync(this.SourceFile);
            }
            else if(null != this.SourceUrl)
            {
                await this.DownloadImageAsync(this.SourceUrl);
            }
        }

        public override void WriteDdl(TextWriter writer)
        {
            if (string.IsNullOrEmpty(this.Name)) this.Name = "image.jpg";

            writer.Write("\\image");
            writer.Write("(/*");
            writer.Write("{");

            writer.Write("name: \"");
            writer.Write(this.Name);
            writer.Write("\"");

            writer.Write(", data: \"");
            writer.Write(this.Base64Data);
            writer.Write("\"");

            writer.Write("}");
            writer.Write("*/)");

            writer.WriteLine();
            writer.WriteLine("[");

            writer.WriteLine("LockAspectRatio = {0}", this.LockAspectRatio);
            if (null != this.PictureFormat) this.PictureFormat.WriteDdl(writer);
            if (this.Resolution.HasValue) writer.WriteLine(string.Format(this.NumberFormatProvider, "Resolution = {0}", this.Resolution));
            if (this.ScaleHeight.HasValue) writer.WriteLine(string.Format(this.NumberFormatProvider, "ScaleHeight = {0}", this.ScaleHeight));
            if (this.ScaleWidth.HasValue) writer.WriteLine(string.Format(this.NumberFormatProvider, "ScaleWidth = {0}", this.ScaleWidth));

            base.WriteDdl(writer);

            writer.WriteLine("]");

        }


        private static WebClient webClient = new WebClient();

        private async Task DownloadImageAsync(Uri sourceUrl)
        {
            this.LoadBuffer(await webClient.DownloadDataTaskAsync(SourceUrl));
        }

        private async Task LoadFileAsync(FileInfo sourceFile)
        {
            using (var strm = sourceFile.OpenRead())
            {
                byte[] buffer = new byte[strm.Length];
                await strm.ReadAsync(buffer, 0, buffer.Length);
                this.LoadBuffer(buffer);

                if (string.IsNullOrEmpty(this.Name)) this.Name = sourceFile.Name;
            }
        }

        private void LoadBuffer(byte[] buffer)
        {
            this.Base64Data = Convert.ToBase64String(buffer);
        }
    }
}
