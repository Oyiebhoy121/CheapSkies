using CheapSkies.Controller.Validators;
using Xunit;

namespace RecordValidatorUnitTest
{
    public class IsFlightNumberValidUnitTest
    {
        [Theory]
        [InlineData("1")]
        [InlineData("124")]
        [InlineData("9999")]
        public void IsFlightNumberValid_WhenFlightNumberIsValid_ReturnsTrue(string validFlightNumber)
        {
            //Arrange
            var softwareUnderTest = new RecordValidator();
            //Act
            bool result = softwareUnderTest.IsFlightNumberValid(validFlightNumber);
            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("-5")]
        [InlineData("0")]
        [InlineData("10000")]
        [InlineData("3.14")]
        [InlineData("125&")]
        [InlineData("1abc")]
        [InlineData("9999 ")]
        public void IsFlightNumberValid_WhenFlightNumberIsInvalid_ReturnsFalse(string invalidFlightNumber)
        {
            //Arrange
            var validator = new RecordValidator();
            //Act
            bool actual = validator.IsFlightNumberValid(invalidFlightNumber);
            //Assert
            Assert.False(actual);
        }
    }
}