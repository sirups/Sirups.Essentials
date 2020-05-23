using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Moq;
using Sirups.Essentials.Mvc.Auth;
using Xunit;

namespace Sirups.Essentials.Mvc.Tests.Auth.ContextAccessorAuthServiceTests {
	public class SignInAsyncTests {
		private readonly ContextAccessorAuthService _service;
		private readonly Mock<IHttpContextAccessor> _accessor;
		private readonly Mock<IAuthenticationService> _wrappedService;

		public SignInAsyncTests() {
			_accessor = new Mock<IHttpContextAccessor>();
			_wrappedService = new Mock<IAuthenticationService>();
			_service = new ContextAccessorAuthService(_accessor.Object, _wrappedService.Object);
		}

		[Fact]
		public async Task ShouldDelegateToWrappedService() {
			//Arrange
			const string scheme = "some scheme";
			ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
				{new Claim("SomeClaim", "SomeValue", ClaimValueTypes.String, "https://sirups.dk")}, scheme));
			AuthenticationProperties properties = new AuthenticationProperties();

			//Act
			await _service.SignInAsync(scheme, principal, properties);

			//Assert
			_accessor.Verify(x => x.HttpContext, Times.Once);
			_wrappedService.Verify(x => x.SignInAsync(It.IsAny<HttpContext>(), scheme, principal, properties),
				Times.Once);
		}
	}
}