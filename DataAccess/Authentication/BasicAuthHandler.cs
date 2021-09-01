using DataAccess.Repository;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace DataAccess.Authentication
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        UserDataAccess userDataAccess = new();
        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            User user = null;
            StringValues values;
            if (!Request.Headers.TryGetValue("Authorization", out values))
            {
                return AuthenticateResult.Fail("Authorization Header Bulunmamaktadır");
            }

            try
            {
                user = userDataAccess.Authentication(values, user);
                
                    
            }
            catch
            {
                return AuthenticateResult.Fail("Geçersiz Authorization Header");
            }

            if (user == null)
                return AuthenticateResult.Fail("Kullanıcı adı yada şifre geçersiz");

            var claims = new[]
                {new Claim(ClaimTypes.Name, user.UserName), new Claim(ClaimTypes.Name, user.Password),};
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
