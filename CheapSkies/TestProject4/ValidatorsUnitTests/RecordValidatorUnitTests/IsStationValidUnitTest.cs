using CheapSkies.Controller.Validators;
using Xunit;

namespace RecordValidatorUnitTest
{
    public class IsStationValid
    {
        [Theory]
        [InlineData("MNL")]
        [InlineData("A3X")]
        [InlineData("X23")]
        [InlineData("AB9")]
        public void IsStationValid_WhenStationIsValid_ReturnsTrue(string validStation)
        {
            //Arrange
            var softwareUnderTest = new RecordValidator();

            //Act
            bool result = softwareUnderTest.IsStationValid(validStation);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("M")]
        [InlineData("MN")]
        [InlineData("MNLO")]
        [InlineData("mnl")]
        [InlineData("1NL")]
        [InlineData("M&N")]
        [InlineData("MN ")]
        [InlineData(" RT")]
        public void IsStationValid_WhenStationIsInvalid_ReturnsFalse(string inValidStation)
        {
            
            //Arrange
            var softwareUnderTest = new RecordValidator();

            //Act
            bool result = softwareUnderTest.IsStationValid(inValidStation);

            //Assert
            Assert.False(result);
        }
    }
}
