using CheapSkies.Controller.Controller.FlightMaintenanceScreen;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.View.View.Interface;
using Moq;
using Xunit;

namespace ControllerTests.NewFolder
{
    public class DisplayFlightByFlightNumberUnitTest
    {
        [Fact]
        public void DisplayFlightByFlightNumber_WhenFlightSearchesMatched_ShouldDisplayShowingFlightResults()
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

            mockUserInterface.Setup(x => x.GetInput())
                .Returns("124");

            mockFlightRepository.Setup(x => x.GetFlightData(It.IsAny<int>()))
                .Returns(listOfFlightsFromRepository);


            var menuStorage = new List<string>();
            mockUserInterface.Setup(x => x.Display(It.IsAny<string>()))
                .Callback<string>((menu) =>
                {
                    menuStorage.Add(menu);
                });

            //Act
            var displayFlightController = new DisplayFlightController(mockFlightRepository.Object, mockUserInterface.Object);
            displayFlightController.DisplayFlightbyFlightNumber();

            //Assert
            Assert.Equal("\nShowing Flight Results:", menuStorage[menuStorage.Count - 2]);
        }

        [Fact]
        public void DisplayFlightByFlightNumber_WhenFlightSearchesWithoutMatch_ShouldDisplayNoAvailableFlights()
        {
            //Arrange
            var mockFlightRepository = new Mock<IFlightRepository>();
            var mockUserInterface = new Mock<IUserInterface>();

            mockUserInterface.Setup(x => x.GetInput())
                .Returns("124");

            mockFlightRepository.Setup(x => x.GetFlightData(It.IsAny<int>()))
                .Returns(new List<FlightBase>());

            var passedMenu = "";
            var passedFlightNumber = 0;
            mockUserInterface.Setup(x => x.Display(It.IsAny<string>(), It.IsAny<int>()))
                .Callback<string, int>((menu, flightNumber) =>
                {
                    passedMenu = menu;
                    passedFlightNumber = flightNumber;

                });

            //Act
            var displayFlightController = new DisplayFlightController(mockFlightRepository.Object,
                mockUserInterface.Object);
            displayFlightController.DisplayFlightbyFlightNumber();

            //Assert
            Assert.Equal("\nNo available flights with the FlightNumber of ", passedMenu);
        }
    }
}
