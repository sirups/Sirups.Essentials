using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Sirups.Essentials.Mvc.Auth {
	public interface IAuthService {
		Task<AuthenticateResult> AuthenticateAsync(string scheme);
		Task ChallengeAsync(string scheme, AuthenticationProperties properties);
		Task ForbidAsync(string scheme, AuthenticationProperties properties);
		Task SignInAsync(string scheme, ClaimsPrincipal principal, AuthenticationProperties properties);
		Task SignOutAsync(string scheme, AuthenticationProperties properties);
	}
}