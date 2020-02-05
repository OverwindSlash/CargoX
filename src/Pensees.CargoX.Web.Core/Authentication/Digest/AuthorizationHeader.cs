using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.Authentication.Digest
{
    public class AuthorizationHeader
    {
        public string Username { get; set; }

        public string Realm { get; set; }

        public string Nonce { get; set; }

        public string ClientNonce { get; set; }

        public string NonceCounter { get; set; }

        public string Qop { get; set; }

        public string Response { get; set; }

        public string RequestMethod { get; set; }

        public string Uri { get; set; }
    }
}
