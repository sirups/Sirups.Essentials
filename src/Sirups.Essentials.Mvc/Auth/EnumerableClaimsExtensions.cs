using System.Collections.Generic;
using System.Security.Claims;
using Optional;

namespace Sirups.Essentials.Mvc.Auth {
	public static class EnumerableClaimsExtensions {
		public static Option<string> GetClaimValue(this IEnumerable<Claim> claims, string type = null,
			string valueType = null,
			string issuer = null) {
			if (claims == null || (type == null && valueType == null && issuer == null))
				return Option.None<string>();
			foreach (Claim claim in claims) {
				if (type != null && claim.Type != type)
					continue;

				if(valueType != null && claim.ValueType != valueType)
					continue;
				
				if(issuer != null && claim.Issuer != issuer)
					continue;

				return claim.Value.SomeNotNull();
			}
			
			return Option.None<string>();
		}
	}
}