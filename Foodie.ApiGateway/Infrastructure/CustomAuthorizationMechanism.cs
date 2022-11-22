using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Foodie.ApiGateway.Infrastructure
{
    public static class CustomAuthorizationMechanism
    {
        public static bool Authorize(HttpContext ctx)
        {
            if (string.IsNullOrEmpty(ctx.Items.DownstreamRoute().AuthenticationOptions.AuthenticationProviderKey))
            {
                return true;
            }
            else
            {
                bool auth = false;
                Claim[] claims = ctx.User.Claims.ToArray<Claim>();
                Dictionary<string, string> required = ctx.Items.DownstreamRoute().RouteClaimsRequirement;
                Regex reor = new Regex(@"[^,\s+$ ][^\,]*[^,\s+$ ]");
                MatchCollection matches;

                Regex reand = new Regex(@"[^&\s+$ ][^\&]*[^&\s+$ ]");
                MatchCollection matchesand;
                int cont = 0;
                foreach (KeyValuePair<string, string> claim in required)
                {
                    matches = reor.Matches(claim.Value);
                    foreach (Match match in matches)
                    {
                        matchesand = reand.Matches(match.Value);
                        cont = 0;
                        foreach (Match m in matchesand)
                        {
                            foreach (Claim cl in claims)
                            {
                                if (cl.Type == claim.Key)
                                {
                                    if (cl.Value == m.Value)
                                    {
                                        cont++;
                                    }
                                }
                            }
                        }
                        if (cont == matchesand.Count)
                        {
                            auth = true;
                            break;
                        }
                    }
                }
                return auth;
            }
        }
    }
}
