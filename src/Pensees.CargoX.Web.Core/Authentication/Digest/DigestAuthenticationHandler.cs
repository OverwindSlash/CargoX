using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Pensees.CargoX.Authorization.Users;

namespace Pensees.CargoX.Authentication.Digest
{
    public class DigestAuthenticationHandler : AuthenticationHandler<DigestAuthenticationOptions>
    {
        private static readonly Encoding _encoding = Encoding.UTF8;
        private readonly IOptionsMonitor<DigestAuthenticationOptions> _options;

        private UserManager _userManager = null;

        public DigestAuthenticationHandler(
            IOptionsMonitor<DigestAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            UserManager userManager
        )
            : base(options, logger, encoder, clock)
        {
            _options = options;
            _userManager = userManager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                AddAuthenticateHeaderToResponse();
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            var authHeader = GetAuthenticationHeader(Context.Request);
            if (authHeader.RequestMethod != "GET")
            {
                return AuthenticateResult.Fail("Missing Authentication Header");
            }

            if (!ValidateNonce(authHeader.Nonce))
            {
                AddAuthenticateHeaderToResponse(true);
                return AuthenticateResult.Fail("Nonce timeout");
            }
            else
            {
                string password = await _userManager.GetPassword(authHeader.Username);
                string calculatedResponse = CalculateClientResponse(authHeader, password);

                if (calculatedResponse == authHeader.Response)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, authHeader.Username),
                    };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
            }

            return AuthenticateResult.Fail("Invalid username or password");
        }

        private void AddAuthenticateHeaderToResponse(bool isNonceExpired = false)
        {
            string realm = $"realm=\"{_options.CurrentValue.Realm}\"";
            string qop = $"qop=\"{_options.CurrentValue.Qop}\"";
            string nonce = $"nonce=\"{CreateNonce()}\"";
            string stale = $"stale={isNonceExpired}";
            string authorization = $"Digest {realm}, {qop}, {nonce}, {stale}";
            Response.Headers.Add("WWW-Authenticate", authorization);
        }

        private string CreateNonce(DateTimeOffset? timestamp = null)
        {
            var privateKey = Options.PrivateKey;
            var timestampStr = timestamp?.ToString() ?? DateTimeOffset.UtcNow.ToString();

            return Convert.ToBase64String(
                _encoding.GetBytes($"{timestampStr} {$"{timestampStr}:{privateKey}".ToMd5Hash()}"));
        }

        private string CalculateClientResponse(AuthorizationHeader header, string password)
        {
            var a1Hash = $"{header.Username}:{header.Realm}:{password}".ToMd5Hash();
            var a2Hash = $"{header.RequestMethod}:{header.Uri}".ToMd5Hash();
            var response = $"{a1Hash}:{header.Nonce}:{header.NonceCounter}:{header.ClientNonce}:{header.Qop}:{a2Hash}"
                .ToMd5Hash();

            return response;
        }

        private AuthorizationHeader GetAuthenticationHeader(HttpRequest request)
        {
            AuthorizationHeader authHeader = new AuthorizationHeader();

            try
            {
                string credentials = GetCredentials(request);
                if (string.IsNullOrEmpty(credentials))
                {
                    return authHeader;
                }

                authHeader.RequestMethod = request.Method;
                var nameValueStrs = credentials
                    .Replace("\"", string.Empty)
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim());

                foreach (var nameValueStr in nameValueStrs)
                {
                    var index = nameValueStr.IndexOf('=');
                    var name = nameValueStr.Substring(0, index);
                    var value = nameValueStr.Substring(index + 1);

                    switch (name)
                    {
                        case "username":
                            authHeader.Username = value;
                            break;
                        case "realm":
                            authHeader.Realm = value;
                            break;
                        case "nonce":
                            authHeader.Nonce = value;
                            break;
                        case "cnonce":
                            authHeader.ClientNonce = value;
                            break;
                        case "nc":
                            authHeader.NonceCounter = value;
                            break;
                        case "qop":
                            authHeader.Qop = value;
                            break;
                        case "response":
                            authHeader.Response = value;
                            break;
                        case "uri":
                            authHeader.Uri = value;
                            break;
                    }
                }

                return authHeader;
            }
            catch (Exception e)
            {
                return authHeader;
            }
        }

        private string GetCredentials(HttpRequest request)
        {
            string credentials = string.Empty;

            string authorization = request.Headers[HeaderNames.Authorization];

            if (authorization?.StartsWith("Digest", StringComparison.OrdinalIgnoreCase) == true)
            {
                credentials = authorization.Substring("Digest".Length).Trim();
            }

            return credentials;
        }

        private bool ValidateNonce(string nonce)
        {
            try
            {
                var plainNonce = _encoding.GetString(Convert.FromBase64String(nonce));
                var timestamp = DateTimeOffset.Parse(plainNonce.Substring(0, plainNonce.LastIndexOf(' ')));

                //验证Nonce是否被篡改
                if (nonce != CreateNonce(timestamp))
                {
                    return false;
                }

                //验证是否过期
                if (Math.Abs((timestamp - DateTimeOffset.UtcNow).TotalSeconds) > Options.MaxNonceAgeSeconds)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
