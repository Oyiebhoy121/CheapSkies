using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using Moq;
using Xunit;

namespace FlightValidatorUnitTest
{
    public class IsTimeFormatValidUnitTest
    {
        [Theory]
        [InlineData("00:00")]
        [InlineData("23:59")]
        [InlineData("12:09")]
        public void IsTimeFormatValid_WhenTimeIsValid_ReturnsTrue(string validTime)
        {
            //Arrange
            var mockFlightRepository = Mock.Of<IFlightRepository>();
            var softwareUnderTest = new FlightValidator(mockFlightRepository);

            //Act
            var result = softwareUnderTest.IsTimeFormatValid(validTime);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("0:00")]
        [InlineData("00:0")]
        [InlineData("-23:59")]
        [InlineData("12:0a")]
        [InlineData("12:00:23")]
        [InlineData("12/00")]
        [InlineData("25:00")]
        public void IsTimeFormatValid_WhenTimeIsInvalid_ReturnsFalse(string invalidTime)
        {
            //Arrange
            var mockFlightRepository = Mock.Of<IFlightRepository>();
            var softwareUnderTest = new FlightValidator(mockFlightRepository);

            //Act
            var result = softwareUnderTest.IsTimeFormatValid(invalidTime);

            //Assert
            Assert.False(result);
        }
    }
}