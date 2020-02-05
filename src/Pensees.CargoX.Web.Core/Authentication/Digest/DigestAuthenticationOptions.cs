using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace Pensees.CargoX.Authentication.Digest
{
    public class DigestAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultRealm = "VIID";
        public const string DefaultQop = "auth";
        public const int DefaultMaxNonceAgeSeconds = 60;

        public string Realm { get; set; } = DefaultRealm;

        public string Qop { get; set; } = DefaultQop;

        public int MaxNonceAgeSeconds { get; set; } = DefaultMaxNonceAgeSeconds;

        public string PrivateKey { get; set; }
    }
}
