using Moq;
using CheapSkies.View.View.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.Controller.Controller.Reservation_Screen;
using CheapSkies.Infrastructure.Repository.Interface.PassengerRepository.Interface;
using CheapSkies.Infrastructure.Repository.Interface.ReservationRepository.Interface;

namespace ControllerTests.SearchReservationControllerUnitTests
{
    public class DisplayReservationsByPNR
    {
        [Fact]
        public void DisplayAllReservationsByPNR_WhenReservationSearchesMatched_ShouldDisplaySuccessfullyDisplayedAllReservations()
        {
            //Arrange
            var mockUserInterface = new Mock<IUserInterface>();
            var mockReservationRepository = new Mock<IReservationRepository>();
            var mockPassengerRepository = new Mock<IPassengerRepository>();

            var listOfReservations = new List<ReservationBase>
            {
                new ReservationBase
                {
                    AirlineCode = "5J",
                    FlightNumber = 124,
                    ArrivalStation = "MNL",
                    DepartureStation = "CEB",
                    FlightDate = new DateOnly(2023, 7, 8),
                    NumberOfPassenger = 1,
                    PNR = "A12345"
                }
            };

            var listOfPassengers = new List<PassengerBase>()
            {
                new PassengerBase
                {
                    FirstName = "Felipe",
                    LastName = "Goleta",
                    BirthDate = new DateOnly(1999, 7, 8),
                    Age = 23,
                    PNR = "A12345"
                }
            };

            mockReservationRepository.Setup(x => x.GetReservationData(It.IsAny<string>()))
                .Returns(listOfReservations);

            mockPassengerRepository.Setup(x => x.GetPassengerData(It.IsAny<string>()))
                .Returns(listOfPassengers);

            var menuStorage = new List<string>();

            var list = new List<string>();
            mockUserInterface.Setup(x => x.Display(It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string>((menu1, menu2) =>
                {
                    menuStorage.Add(menu1);
                });

            //Act
            var searchReservationController = new SearchReservationController(mockUserInterface.Object, mockReservationRepository.Object, mockPassengerRepository.Object);
            searchReservationController.DisplaReservationsByPNR();

            //Assert
            Assert.Equal("\n\nSuccessfully Displayed All Reservations based on PNR ", menuStorage[menuStorage.Count - 1]);
        }

        [Fact]
        public void DisplayFlightByStations_WhenFlightSearchesNoMatches_ShouldDisplayShowingFlightResults()
        {
            //Arrange
            var mockUserInterface = new Mock<IUserInterface>();
            var mockReservationRepository = new Mock<IReservationRepository>();
            var mockPassengerRepository = new Mock<IPassengerRepository>();

            mockReservationRepository.Setup(x => x.GetReservationData(It.IsAny<string>()))
                .Returns(new List<ReservationBase>());

            var menuStorage = new List<string>();

            var list = new List<string>();
            mockUserInterface.Setup(x => x.Display(It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string>((menu1, menu2) =>
                {
                    menuStorage.Add(menu1);
                });

            //Act
            var searchReservationController = new SearchReservationController(mockUserInterface.Object, mockReservationRepository.Object, mockPassengerRepository.Object);
            searchReservationController.DisplaReservationsByPNR();

            //Assert
            Assert.Equal("\nNo Reservations found based on Input PNR", menuStorage[menuStorage.Count - 1]);
        }
    }
}
