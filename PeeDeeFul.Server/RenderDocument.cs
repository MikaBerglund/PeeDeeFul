using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace PeeDeeFul.Server
{
    public static class RenderDocument
    {
        [FunctionName("RenderDocument")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "POST", Route = "Documents/Render")]HttpRequestMessage req, TraceWriter log)
        {
            PdfDocument doc = null;
            PdfDocumentRenderer renderer = null;
            string ddl = await req.Content.ReadAsStringAsync();

            await Task.Run(() =>
            {
                renderer = new PdfDocumentRenderer(true)
                {
                    Document = DdlReader.DocumentFromString(ddl)
                };
            });

            await Task.Run(() =>
            {
                renderer.RenderDocument();
                doc = renderer.PdfDocument;
            });


            return req.CreateResponse();
        }
    }
}
