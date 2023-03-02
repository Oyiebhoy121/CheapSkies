using CheapSkies.Controller.Validators;

namespace PassengerValidatorUnitTest
{
    public class IsBirthDateValidUnitTest
    {
        [Theory]
        [InlineData("12/24/2022")]
        [InlineData("03/02/2023")]
        [InlineData("03/02/1899")]
        public void IsBirthDateValid_WhenBirthDateIsValid_ReturnsTrue(string validBirthDate) 
        {
            //Arrange
            var softwareUnderTest = new PassengerValidator();

            //Act
            bool result = softwareUnderTest.IsBirthDateValid(validBirthDate);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("03/03/2099")]
        [InlineData("25/07/2022")]
        [InlineData("12:09")]
        [InlineData("02-24-2023")]
        [InlineData(" 12/24/2022 ")]
        [InlineData("12-0a-2023")]
        public void IsBirthDateValid_WhenBirthDateIsInvalid_ReturnsFalse(string invalidBirthDate)
        {
            //Arrange
            var softwareUnderTest = new PassengerValidator();

            //Act
            bool result = softwareUnderTest.IsBirthDateValid(invalidBirthDate);

            //Assert
            Assert.False(result);
        }
    }
}
