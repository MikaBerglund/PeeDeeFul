using PeeDeeFul.DocumentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PeeDeeFul.Client
{
    public class ImageActions
    {
        internal ImageActions(PdfClientContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private PdfClientContext Context { get; set; }



        /// <summary>
        /// Loads the specified image file and encodes it in the given <paramref name="target"/> image DOM object.
        /// </summary>
        /// <param name="source">The source file to load.</param>
        /// <param name="target">The image to encode the loaded image to.</param>
        /// <returns></returns>
        public async Task LoadImageAsync(FileInfo source, Image target)
        {
            byte[] buffer;
            using (var strm = source.OpenRead())
            {
                buffer = new byte[strm.Length];
                await strm.ReadAsync(buffer, 0, buffer.Length);
            }

            await this.LoadImageAsync(buffer, source.Name, target);
        }

        /// <summary>
        /// Encodes the given data to a Base64 string and stores it in the given <paramref name="target"/> image DOM object.
        /// </summary>
        /// <param name="data">The image data to encode.</param>
        /// <param name="name">The file name for the image.</param>
        /// <param name="target">The target image DOM object.</param>
        /// <returns></returns>
        public async Task LoadImageAsync(byte[] data, string name, Image target)
        {
            await Task.Run(() =>
            {
                target.Base64Data = Convert.ToBase64String(data);
            });

            target.Name = name;
        }

    }
}
