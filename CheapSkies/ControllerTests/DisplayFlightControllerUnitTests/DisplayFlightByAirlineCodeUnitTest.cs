using CheapSkies.Controller.Controller.FlightMaintenanceScreen;
using CheapSkies.Controller.Controller.Interface.FlightMaintenancScreen.Interface;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.View.View.Interface;
using Moq;
using Xunit;

namespace ControllerTests.NewFolder
{
    public class DisplayFlightByAirlineCodeUnitTest
    {
        [Fact]
        public void DisplayFlightByAirlineCode_WhenFlightSearchesMatched_ShouldDisplayShowingFlightResults()
        {
            //Arrange
            var mockUserInterface = new Mock<IUserInterface>();
            var mockFlightRepository = new Mock<IFlightRepository>();

            var listOfFlightsFromRepository = new List<FlightBase>
            {
                new FlightBase
                {
                    AirlineCode = "5J",
                    FlightNumber = 124,
                    ArrivalStation = "MNL",
                    DepartureStation = "CEB",
                    ScheduleTimeOfArrival = "12:00",
                    ScheduleTimeOfDeparture = "08:00"
                }
            };

            mockFlightRepository.Setup(x => x.GetFlightData(It.IsAny<string>()))
                .Returns(listOfFlightsFromRepository);

            var menuStorage = new List<string>();
            mockUserInterface.Setup(x => x.Display(It.IsAny<string>()))
                .Callback<string>((menu) =>
                {
                    menuStorage.Add(menu);
                });

            //Act 
            var displayFlightController = new DisplayFlightController(mockFlightRepository.Object, mockUserInterface.Object);
            displayFlightController.DisplayFlightByAirlineCode();

            //Assert
            Assert.Equal("\nShowing Flight Results:", menuStorage[menuStorage.Count - 2]);
        }

        [Fact]
        public void DisplayFlightByAirlineCode_WhenFlightSearchesWithoutMatch_ShouldDisplayNoAvailableFlights()
        {
            //Arrange
            var mockUserInterface = new Mock<IUserInterface>();
            var mockFlightRepository = new Mock<IFlightRepository>();

            var listOfFlightsFromRepository = new List<FlightBase>();


            mockFlightRepository.Setup(x => x.GetFlightData(It.IsAny<string>()))
                .Returns(listOfFlightsFromRepository);

            string menuStorage = "";
            string airlineCode = "";
            mockUserInterface.Setup(x => x.Display(It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string>((menu, code) =>
                {
                    menuStorage = menu;
                    airlineCode = code;
                });

            //Act 
            var displayFlightController = new DisplayFlightController(mockFlightRepository.Object, mockUserInterface.Object);
            displayFlightController.DisplayFlightByAirlineCode();

            //Assert
            Assert.Equal("\nNo available flights with the Airline Code of ", menuStorage);
        }
    }
}
