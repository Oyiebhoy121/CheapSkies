using CheapSkies.Controller.Validators;
using Xunit;
using Moq;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;

namespace PassengerValidatorUnitTest
{
    public class ValidatePassengerNumberUnitTest
    {
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        public void IsPassengerNumberValid_WhenPassengerNumberIsValid_ReturnsTrue(string validPassengerNumber)
        {
            //Arrange
            var mockFlightRepository = Mock.Of<IFlightRepository>();
            var softwareUnderTest = new ReservationValidator(mockFlightRepository);

            //Act
            bool result1 = softwareUnderTest.IsNumberOfPassengersValid(validPassengerNumber);

            //Assert
            Assert.True(result1);
        }

        [Theory]
        [InlineData("")]
        [InlineData("0")]
        [InlineData("6")]
        [InlineData("1.5")]
        [InlineData("-2")]
        [InlineData("4!")]
        [InlineData("4a")]
        [InlineData(" 1 ")]
        public void IsPassengerNumberValid_WhenPassengerNumberIsInvalid_ReturnsFalse(string invalidPassengerNumber)
        {
            //Arrange
            var mockFlightRepository = Mock.Of<IFlightRepository>();
            var softwareUnderTest = new ReservationValidator(mockFlightRepository);

            //Act
            bool result1 = softwareUnderTest.IsNumberOfPassengersValid(invalidPassengerNumber);

            //Assert
            Assert.False(result1);
        }
    }
}

