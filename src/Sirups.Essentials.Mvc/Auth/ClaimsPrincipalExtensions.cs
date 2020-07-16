using System.Security.Claims;
using Optional;

namespace Sirups.Essentials.Mvc.Auth
{
    public static class ClaimsPrincipalExtensions
    {
        public static Option<string> GetClaimValue(this ClaimsPrincipal principal, string type = null,
            string valueType = null,
            string issuer = null)
        {
            return principal.Claims.GetClaimValue(type, valueType, issuer);
        }
    }
}