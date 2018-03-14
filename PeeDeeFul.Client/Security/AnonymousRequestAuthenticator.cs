using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PeeDeeFul.Client.Security
{
    /// <summary>
    /// Takes care of anonymous authentication, meaning this class does nothing.
    /// </summary>
    public class AnonymousRequestAuthenticator : RequestAuthenticator
    {
        /// <summary>
        /// Does not modify the given request in any way.
        /// </summary>
        public override Task AuthenticateRequestAsync(HttpWebRequest request)
        {
            return Task.CompletedTask;
        }
    }
}
