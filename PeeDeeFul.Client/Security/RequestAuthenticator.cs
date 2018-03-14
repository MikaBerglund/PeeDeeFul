using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PeeDeeFul.Client.Security
{
    /// <summary>
    /// The base implementation for all request authenticators. A request authenticator is
    /// responsible for authenticating web requests before sending them to the server.
    /// Authenticating a request means adding any necessary headers or other information to
    /// a request to make it pass the authentication on the server.
    /// </summary>
    public abstract class RequestAuthenticator
    {

        /// <summary>
        /// Called before the given request is sent to the server.
        /// </summary>
        /// <param name="request">The request that needs to be authenticated.</param>
        public virtual async Task AuthenticateRequestAsync(System.Net.HttpWebRequest request)
        {
            throw new NotImplementedException($"You must override the '{nameof(AuthenticateRequestAsync)}' method in your request authenticator.");
        }

    }
}
