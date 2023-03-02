using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using Moq;
using Xunit;

namespace ReservationValidatorUnitTest
{
    public class IsFlightValidForReservationUnitTest
    {
        [Fact]
        public void IsFlightValidForReservation_WhenFlightIsNonexisting_ReturnsFalse()
        {
            //Arrange
            var mockFlightRepositry = new Mock<IFlightRepository>(); //Mock.Of does not work
            mockFlightRepositry.Setup(x => x.GetFlightData())
                .Returns(new List<FlightBase>());

            //Act
            var softwareUnderTest = new ReservationValidator(mockFlightRepositry.Object);
            var result = softwareUnderTest.IsFlightValidForReservation(It.IsAny<Reservation>());

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsFlightValidForReservation_WhenFlightIsExisting_ReturnsTrue()
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

            Reservation reservation = new Reservation("5J", 124, "MNL", "CEB", new DateOnly(2023, 7, 8), 3, new List<string>()); //Should this be on "Act" or "Arrange"

            //Act
            var softwareUnderTest = new ReservationValidator(mockFlightRepo.Object);
            var result = softwareUnderTest.IsFlightValidForReservation(reservation);

            //Assert
            Assert.True(result);
        }
    }
}
