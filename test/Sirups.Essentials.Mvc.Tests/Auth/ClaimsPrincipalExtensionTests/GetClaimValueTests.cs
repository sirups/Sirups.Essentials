using System.Security.Claims;
using Optional;
using Sirups.Essentials.Mvc.Auth;
using Xunit;

namespace Sirups.Essentials.Mvc.Tests.Auth.ClaimsPrincipalExtensionTests
{
    public class GetClaimValueTests
    {
        private readonly ClaimsPrincipal _validPrincipal;
        private readonly string _validIssuer = "https://example.com";
        private readonly string _validEmail;
        private readonly string _validSub;

        public GetClaimValueTests()
        {
            _validSub = "ldkfmlaklkghmaldffkmasdlfkmalk4mawl5k";
            _validEmail = "somegal@example.com";
            _validPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim("sub", _validSub, ClaimValueTypes.String, _validIssuer),
                new Claim("email", _validEmail, ClaimValueTypes.String, _validIssuer),
            }, "cookie"));
        }

        [Fact]
        public void ShouldDelegateToClaims()
        {
            //Arrange
            //Act
            Option<string> subResult = _validPrincipal.GetClaimValue("sub");
            Option<string> subResult2 = _validPrincipal.GetClaimValue("sub", ClaimValueTypes.String);
            Option<string> subResult3 = _validPrincipal.GetClaimValue("sub", issuer: _validIssuer);

            //Assert
            Assert.Equal(_validSub, subResult.ValueOr(""));
            Assert.Equal(_validSub, subResult2.ValueOr(""));
            Assert.Equal(_validSub, subResult3.ValueOr(""));
        }
    }
}