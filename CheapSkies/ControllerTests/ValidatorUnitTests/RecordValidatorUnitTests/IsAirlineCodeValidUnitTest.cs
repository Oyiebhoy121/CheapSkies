using CheapSkies.Controller.Validators;
using Xunit;

namespace RecordValidatorUnitTest
{
    public class IsAirlineCodeValidUnitTest
    {
        [Theory]
        [InlineData("5J")]
        [InlineData("5JK")]
        [InlineData("J5")]
        [InlineData("J5K")]
        [InlineData("JKL")]
        public void IsAirlineCodeValid_WhenAirlineCodeIsValid_ReturnsTrue(string validAirlineCode)
        {
            //Arrange
            var softwareUnderTest = new RecordValidator();
            //Act
            bool actual = softwareUnderTest.IsAirlineCodeValid(validAirlineCode);
            //Assert
            Assert.True(actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("M")]
        [InlineData("5")]
        [InlineData("5j")]
        [InlineData("MNLA")]
        [InlineData("MnL")]
        [InlineData("mnl")]
        [InlineData("A34")] 
        [InlineData("5J&")]
        [InlineData(" 5J ")]
        public void IsAirlineCodeValid_WhenAirlineCodeIsInvalid_ReturnsFalse(string invalidAirlineCode)
        {
            //Arrange
            var softwareUnderTest = new RecordValidator();
            //Act
            bool actual = softwareUnderTest.IsAirlineCodeValid(invalidAirlineCode);
            //Assert
            Assert.False(actual);
        }
    }
}