using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using Moq;
using Xunit;

namespace FlightValidatorUnitTest
{
    public class IsFlightDuplicateUnitTest
    {
        [Fact]
        public void IsFlightDuplicate_WhenFlightIsNotDuplicate_ReturnsFalse()
        {
            //Arrange
            var mockFlightRepo = new Mock<IFlightRepository>();
            mockFlightRepo.Setup(x => x.GetFlightData())
                .Returns(new List<FlightBase>());

            //Act
            var softwareUnderTest = new FlightValidator(mockFlightRepo.Object);
            var result = softwareUnderTest.IsFlightDuplicate(It.IsAny<Flight>());

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsFlightDuplicate_WhenFlightIsDuplicate_ReturnsTrue()
        {
            //Arrange
            List<FlightBase> listOfFlightsFromRepository = new List<FlightBase>()
            {
                new FlightBase()
                {
                    AirlineCode = "5J", 
                    FlightNumber = 124, 
                    ArrivalStation = "MNL",
                    DepartureStation = "CEB",
                    ScheduleTimeOfArrival = "12:00",
                    ScheduleTimeOfDeparture = "08:00"
                }
            };
            
            var mockFlightRepo = new Mock<IFlightRepository>();
            mockFlightRepo.Setup(x => x.GetFlightData())
                .Returns(listOfFlightsFromRepository);

            //Act
            Flight flight = new Flight("5J", 124, "MNL", "CEB", "12:00", "08:00"); //Should this be on "Act" or "Arrange"
            var softwareUnderTest = new FlightValidator(mockFlightRepo.Object);
            var result = softwareUnderTest.IsFlightDuplicate(flight);

            //Assert
            Assert.True(result);
        }
    }
}
