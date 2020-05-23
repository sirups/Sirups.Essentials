using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Sirups.Essentials.Mvc.Auth {
	public class ContextAccessorAuthService : IAuthService {
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly IAuthenticationService _authz;

		public ContextAccessorAuthService(IHttpContextAccessor contextAccessor, IAuthenticationService authz) {
			_contextAccessor = contextAccessor;
			_authz = authz;
		}

		public Task<AuthenticateResult> AuthenticateAsync(string scheme) {
			return _authz.AuthenticateAsync(_contextAccessor.HttpContext, scheme);
		}

		public Task ChallengeAsync(string scheme, AuthenticationProperties properties) {
			return _authz.ChallengeAsync(_contextAccessor.HttpContext, scheme, properties);
		}

		public Task ForbidAsync(string scheme, AuthenticationProperties properties) {
			return _authz.ForbidAsync(_contextAccessor.HttpContext, scheme, properties);
		}

		public Task SignInAsync(string scheme, ClaimsPrincipal principal, AuthenticationProperties properties) {
			return _authz.SignInAsync(_contextAccessor.HttpContext, scheme, principal, properties);
		}

		public Task SignOutAsync(string scheme, AuthenticationProperties properties) {
			return _authz.SignOutAsync(_contextAccessor.HttpContext, scheme, properties);
		}
	}
}