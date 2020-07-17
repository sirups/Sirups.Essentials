using Sirups.Essentials.Mvc.Routing;
using Xunit;

namespace Sirups.Essentials.Mvc.Tests.Routing.ContextActionUrlHelperTests
{
    public class CleanControllerNameTests
    {
        [Fact]
        public void ShouldRemoveControllerFromName()
        {
            //Arrange
            const string expectedControllerName = "Test";
            const string controllerInput = expectedControllerName + "Controller";
            
            //Act
            var result = ContextActionUrlHelper.CleanControllerName(controllerInput);
            
            //Assert
            Assert.Equal(expectedControllerName, result);
        }

        [Theory]
        [InlineData("Testcontroller")]
        [InlineData("TestControlle")]
        [InlineData("TestControllerTest")]
        public void ShouldLeaveUnchangedOnNoControllerOnEnd(string input)
        {
            //Arrange
            //Act
            var result = ContextActionUrlHelper.CleanControllerName(input);
            
            //Assert
            Assert.Equal(input, result);
        }
    }
}