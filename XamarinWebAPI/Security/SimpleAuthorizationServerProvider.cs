using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using XamarinWebAPI.Interfaces;
using XamarinWebAPI.Models;
using XamarinWebAPI.Services;

namespace XamarinWebAPI.Security
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly ISecurityService _securityService;
        public SimpleAuthorizationServerProvider()
        {
            _securityService = new SecurityService();
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId, clientSecret;
            if (context.TryGetFormCredentials(out clientId, out clientSecret))
            {
                context.OwinContext.Set<string>("as:client_id", clientId);
                context.Validated();
            }
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var result = _securityService.SignIn(context.UserName, context.Password);

            if (result == null)
            {
                context.SetError("invalid_grant", "Usuario Inválido");
                return;
            }

            var identity = ClaimsParser.Create<UserModel>(result);
            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                { "as:client_id", context.ClientId }
            });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.OwinContext.Get<string>("as:client_id");

            if (originalClient != currentClient)
            {
                context.Rejected();
                return;
            }

            var newId = new ClaimsIdentity(context.Ticket.Identity);
            newId.AddClaim(new Claim("newClaim", "refreshToken"));

            var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
            context.Validated(newTicket);
        }

    }
}