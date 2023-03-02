using CheapSkies.Infrastructure.Repositories.FlightRepository;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;
using CheapSkies.Model.DataModel;
using Moq;
using Xunit;

namespace SearchFlightUnitTest
{
    public class SearchFlightbyAirlineCodeUnitTest
    {
        [Fact]
        public void GetFlightData_UsingAirlineCode_ReturnsFlight()
        {
            //Arrange
            var listOfFlights = new List<FlightBase>()
            {
                new FlightBase
                {
                    AirlineCode = "5J",
                    FlightNumber = 124,
                    ArrivalStation = "MNL",
                    DepartureStation = "CEB",
                    ScheduleTimeOfArrival = "12:00",
                    ScheduleTimeOfDeparture = "08:00"
                }, 

                new FlightBase
                {
                    AirlineCode = "5J",
                    FlightNumber = 125,
                    ArrivalStation = "MNL",
                    DepartureStation = "CEB",
                    ScheduleTimeOfArrival = "13:00",
                    ScheduleTimeOfDeparture = "09:00"
                }
            };

            var mockFlightRepository = new Mock<IFlightRepository>();
            mockFlightRepository.Setup(x => x.GetFlightData()).Returns(listOfFlights.Where(x => x;

            //Act
            var softwareUnderTest = new FlightRepository();
            var result = softwareUnderTest.GetFlightData("5J");

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