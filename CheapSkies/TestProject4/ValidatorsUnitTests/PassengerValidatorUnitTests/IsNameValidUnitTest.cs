using CheapSkies.Controller.Validators;
using Xunit;


namespace PassengerValidatorUnitTest
{
    public class IsNameValidUnitTest
    {
        [Theory]
        [InlineData("Felipe")]
        [InlineData("Felipe III")]
        [InlineData("FeLiPe")]
        [InlineData("Naomi")]
        [InlineData("Abcde fghij klmno qr")]
        public void IsNameValid_WhenNameIsValid_ReturnsTrue(string validName)  
        {
            //Arrange
            var softwareUnderTest = new PassengerValidator();
            //Act
            bool result = softwareUnderTest.IsNameValid(validName);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("Felipe!!!")]
        [InlineData("   Felipe   ")]
        [InlineData("")]
        [InlineData("Abcde fghijk lmnop qrstuv")]
        public void IsNameValid_WhenNameIsInvalid_ReturnsFalse(string inValidName)
        {
            //Arrange
            var softwareUnderTest = new PassengerValidator();
            //Act
            bool result = softwareUnderTest.IsNameValid(inValidName);

            //Assert
            Assert.False(result);
        }
    }
}