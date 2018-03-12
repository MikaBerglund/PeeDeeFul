using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PeeDeeFul.Client.Security
{
    public abstract class RequestAuthenticator
    {

        public virtual async Task AuthenticateRequestAsync(System.Net.HttpWebRequest request)
        {
            throw new NotImplementedException($"You must override the '{nameof(AuthenticateRequestAsync)}' method in your request authenticator.");
        }

    }
}
