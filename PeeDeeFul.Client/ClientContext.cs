using PeeDeeFul.Client.Security;
using PeeDeeFul.DocumentModel;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PeeDeeFul.Client
{
    /// <summary>
    /// A context class that is configured to communicate with an instance of the PeeDeeFul.Server implementation.
    /// </summary>
    public class ClientContext
    {
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        public ClientContext(string appNameOrUrl, RequestAuthenticator authenticator)
        {
            this.SetUrl(appNameOrUrl);
            this.Authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
            this.Documents = new DocumentActions(this);
        }


        public RequestAuthenticator Authenticator { get; private set; }

        /// <summary>
        /// Returns a set of document actions.
        /// </summary>
        public DocumentActions Documents { get; private set; }

        /// <summary>
        /// Returns URL to the functions application to communicate with.
        /// </summary>
        public Uri Url { get; set; }


        private void SetUrl(string appNameOrUrl)
        {
            if(appNameOrUrl.Contains("://"))
            {
                // Assume it is a URL.
                var u = new Uri(appNameOrUrl);
                var sb = new StringBuilder();
                sb.Append(u.Scheme).Append("://").Append(u.Host);

                if((u.Scheme == Uri.UriSchemeHttps && u.Port != 443) || (u.Scheme == Uri.UriSchemeHttp && u.Port != 80))
                {
                    sb.Append(":").Append(u.Port);
                }

                this.Url = new Uri(sb.ToString());
            }
            else
            {
                this.Url = new Uri($"https://{appNameOrUrl}.azurewebsites.net/");
            }
        }
    }
}
