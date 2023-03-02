using CheapSkies.Controller.Validators;
using Xunit;
using Moq;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;

namespace TestProject1
{
    public class IsFlightDateValidUnitTest
    {
        [Theory]
        [InlineData("03/04/2023")]
        [InlineData("07/08/2023")]
        [InlineData("07/08/2099")]
        public void IsFlightDateValid_WhenFlightDateIsValid_ReturnsTrue(string validFlightDate)
        {
            //Arrange
            var mockFlightRepository = Mock.Of<IFlightRepository>();
            var softwareUnderTest = new ReservationValidator(mockFlightRepository);

            //Act
            bool result = softwareUnderTest.IsFlightDateValid(validFlightDate);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("3/01/2023")]
        [InlineData("25/04/2023")]
        [InlineData("03-01-2023")]
        [InlineData(" 03/01/2023 ")]
        [InlineData(" 03/01/20a3 ")]
        public void IsFlightDateValid_WhenFlightDateIsInvalid_ReturnsFalse(string invalidFlightDate)
        {
            //Arrange
            var mockFlightRepository = Mock.Of<IFlightRepository>();
            var softwareUnderTest = new ReservationValidator(mockFlightRepository);

            //Act
            bool result = softwareUnderTest.IsFlightDateValid(invalidFlightDate);

            //Assert
            Assert.False(result);
        }
    }
}