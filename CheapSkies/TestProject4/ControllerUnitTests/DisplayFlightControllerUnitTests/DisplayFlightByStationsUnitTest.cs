using Xunit;
using Moq;
using CheapSkies.View.View.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;
using CheapSkies.Controller.Controller.FlightMaintenanceScreen;
using CheapSkies.Model.ViewModel;

namespace ControllerTests.DisplayFlightControllerUnitTests
{
    public class DisplayFlightByStationsUnitTest
    {
        [Fact]
        public void DisplayFlightByStations_WhenFlightSearchesMatched_ShouldDisplayShowingFlightResults()
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

            mockFlightRepository.Setup(x => x.GetFlightData(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(listOfFlightsFromRepository);

            var menuStorage = new List<string>();

            var list = new List<string>();
            mockUserInterface.Setup(x => x.Display(It.IsAny<string>()))
                .Callback<string>((menu) =>
                {
                    menuStorage.Add(menu);
                });

            //Act
            var displayFlightController = new DisplayFlightController(mockFlightRepository.Object, mockUserInterface.Object);
            displayFlightController.DisplayFlightByStations();

            //Assert
            Assert.Equal("\nShowing Flight Results:", menuStorage[menuStorage.Count - 2]);
        }

        [Fact]
        public void DisplayFlightByStations_WhenFlightSearchesNoMatches_ShouldDisplayShowingFlightResults()
        {
            //Arrange
            var mockFlightRepository = new Mock<IFlightRepository>();
            var mockUi = new Mock<IUserInterface>();

            mockFlightRepository.Setup(x => x.GetFlightData(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<FlightBase>());

            var menuStorage = "";
            mockUi.Setup(x => x.Display(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string, string>((menu1, menu2, menu3) =>
                {
                    menuStorage = menu1;
  
                });

            //Act
            var displayFlightController = new DisplayFlightController(mockFlightRepository.Object,
                mockUi.Object);
            displayFlightController.DisplayFlightByStations();

            //Assert
            Assert.Equal("\nNo available flights with the Market Pair of ", menuStorage);
        }
    }
}
