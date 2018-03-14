using PeeDeeFul.Client.Security;
using PeeDeeFul.DocumentModel;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PeeDeeFul.Client
{
    /// <summary>
    /// A context class that is configured to communicate with an instance of the PeeDeeFul.Server implementation.
    /// </summary>
    public class PdfClientContext
    {

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="appNameOrUrl">The name of the server application or full URL to it.</param>
        /// <remarks>
        /// Uses the <see cref="AnonymousRequestAuthenticator"/> as authenticator.
        /// </remarks>
        public PdfClientContext(string appNameOrUrl) : this(appNameOrUrl, new AnonymousRequestAuthenticator()) { }

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="appNameOrUrl">
        /// The application name that represents the server application, or the full URL to it. If only the name of the application
        /// is specified, then that name is used to build the base URL as <c>https://&lt;app name&gt;.azurewebsites.net/api</c>.
        /// If the given value is a full URL, then that given URL is used as base URL.
        /// </param>
        /// <param name="authenticator">The authenticator instnace used by the client.</param>
        public PdfClientContext(string appNameOrUrl, RequestAuthenticator authenticator)
        {
            this.SetUrl(appNameOrUrl);
            this.Authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
            this.Documents = new DocumentActions(this);
        }


        /// <summary>
        /// The authenticator to use in the client context. The authenticator is responsible for modifying
        /// a request so that it passes authentication before it is sent to the server.
        /// </summary>
        public RequestAuthenticator Authenticator { get; private set; }

        /// <summary>
        /// Returns a set of document actions.
        /// </summary>
        public DocumentActions Documents { get; private set; }

        /// <summary>
        /// Returns URL to the functions application to communicate with.
        /// </summary>
        public Uri BaseUrl { get; private set; }




        internal HttpWebRequest CreateGetRequest(string relativeUrl)
        {
            return this.CreateRequest("GET", relativeUrl);
        }

        internal HttpWebRequest CreateRequest(string method, string relativeUrl)
        {
            var url = this.CreateUrl(relativeUrl);
            var req = WebRequest.CreateHttp(url);
            req.Method = method;
            return req;
        }

        internal HttpWebRequest CreatePostRequest(string relativeUrl)
        {
            return this.CreateRequest("POST", relativeUrl);
        }



        private Uri CreateUrl(string relativeUrl)
        {
            return new Uri(this.BaseUrl, relativeUrl);
        }

        private void SetUrl(string appNameOrUrl)
        {
            if(appNameOrUrl.Contains("://"))
            {
                // Assume it is a URL.
                this.BaseUrl = new Uri(appNameOrUrl);
            }
            else
            {
                this.BaseUrl = new Uri($"https://{appNameOrUrl}.azurewebsites.net/api");
            }
        }

    }
}
