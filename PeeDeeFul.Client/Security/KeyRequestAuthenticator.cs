using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PeeDeeFul.Client.Security
{
    /// <summary>
    /// A request authenticator that a function or host key to authenticate a request to the server functions app.
    /// </summary>
    public class KeyRequestAuthenticator : RequestAuthenticator
    {
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="key">The function or host key to use when authenticating.</param>
        public KeyRequestAuthenticator(string key)
        {
            this.Key = key;
        }

        /// <summary>
        /// Returns the key specified for the authenticator.
        /// </summary>
        public string Key { get; private set; }


        /// <summary>
        /// Adds the specified <see cref="Key"/> to the given request as an <c>x-functions-key</c> header.
        /// </summary>
        public async override Task AuthenticateRequestAsync(HttpWebRequest request)
        {
            request.Headers.Add("x-functions-key", this.Key);
        }

    }
}
