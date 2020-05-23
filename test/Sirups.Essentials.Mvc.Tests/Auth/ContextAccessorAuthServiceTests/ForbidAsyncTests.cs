using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Moq;
using Sirups.Essentials.Mvc.Auth;
using Xunit;

namespace Sirups.Essentials.Mvc.Tests.Auth.ContextAccessorAuthServiceTests {
	public class ForbidAsyncTests {
		private readonly ContextAccessorAuthService _service;
		private readonly Mock<IHttpContextAccessor> _accessor;
		private readonly Mock<IAuthenticationService> _wrappedService;

		public ForbidAsyncTests() {
			_accessor = new Mock<IHttpContextAccessor>();
			_wrappedService = new Mock<IAuthenticationService>();
			_service = new ContextAccessorAuthService(_accessor.Object, _wrappedService.Object);
		}

		[Fact]
		public async Task ShouldDelegateToWrappedService() {
			//Arrange
			const string scheme = "some scheme";
			AuthenticationProperties properties = new AuthenticationProperties();

			//Act
			await _service.ForbidAsync(scheme, properties);

			//Assert
			_accessor.Verify(x => x.HttpContext, Times.Once);
			_wrappedService.Verify(x => x.ForbidAsync(It.IsAny<HttpContext>(), scheme, properties), Times.Once);
		}
	}
}