using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Optional;
using Optional.Unsafe;
using Sirups.Essentials.Mvc.Auth;
using Xunit;

namespace Sirups.Essentials.Mvc.Tests.Auth.ClaimsExtensionsTests {
	public class GetClaimValueTests {
		private readonly string _validType;
		private readonly string _validValue;
		private readonly string _validValueType;
		private readonly string _validIssuer;
		private readonly Claim _validClaim;
		private readonly List<Claim> _validClaims;

		public GetClaimValueTests() {
			_validType = "sometype";
			_validValue = "slskfmslkj45tlkmsvlskmvl";
			_validValueType = ClaimValueTypes.String;
			_validIssuer = "https://sirups.dk";

			_validClaim = new Claim(_validType, _validValue, _validValueType, _validIssuer);
			_validClaims = new List<Claim> {
				new Claim("unknownClaim", "Someother value", ClaimValueTypes.Email, "https://example.com"),
				_validClaim
			};
		}

		[Fact]
		public void ShouldNoValueOnNullEnumerable() {
			//Arrange
			IEnumerable<Claim> claims = null;

			//Act
			Option<string> result = claims.GetClaimValue("type");

			//Assert
			Assert.False(result.HasValue);
		}

		[Fact]
		public void ShouldNoValueOnNoInput() {
			//Arrange
			//Act
			var result = _validClaims.GetClaimValue();

			//Assert
			Assert.False(result.HasValue);
		}


		[Fact]
		public void GetsActualClaimValueOnJustType() {
			//Arrange
			//Act
			Option<string> result = _validClaims.GetClaimValue(_validType);

			//Assert
			Assert.True(result.HasValue);
			Assert.Equal(_validValue, result.ValueOrFailure());
		}

		[Fact]
		public void GetsActualClaimValueOnJustValueType() {
			//Arrange
			//Act
			Option<string> result = _validClaims.GetClaimValue(valueType: _validValueType);

			//Assert
			Assert.True(result.HasValue);
			Assert.Equal(_validValue, result.ValueOrFailure());
		}
		
		[Fact]
		public void GetsActualClaimValueOnJustIssuer() {
			//Arrange
			//Act
			Option<string> result = _validClaims.GetClaimValue(issuer: _validIssuer);

			//Assert
			Assert.True(result.HasValue);
			Assert.Equal(_validValue, result.ValueOrFailure());
		}

		[Fact]
		public void ShouldNoValueOnNoMatch() {
			//Arrange
			//Act
			var result = _validClaims.GetClaimValue(_validType + "lasdfkmsdlfkdsmfl");

			//Assert
			Assert.False(result.HasValue);
		}
	}
}