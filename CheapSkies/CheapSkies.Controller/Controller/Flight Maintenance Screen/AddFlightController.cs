using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.Model.ViewModel;
using CheapSkies.View;

namespace CheapSkies.Controller.Controller
{
    public class AddFlightController : RecordController
    {
        private AddFlightScreen _addFlightScreen;
        private FlightValidator _flightValidator;
        private FlightRepository _flightRepository;
        public AddFlightController(AddFlightScreen addFlightScreen, FlightValidator flightValidator,
                                    FlightRepository flightRepository) 
        { 
            _addFlightScreen = addFlightScreen;
            _flightValidator = flightValidator;
            _flightRepository = flightRepository;
        }

        public void AddFlight()
        {
            bool parse = false;
            _addFlightScreen.DisplayAddFlightScreen();

            string airlineCode = GetAirlineCode();
            int flightNumber = GetFlightNumber();
            string arrivalStation = GetStation("Arrival");
            string departureStation = GetStation("Departure");
            TimeSpan scheduleTimeOfArrival = GetScheduleTime("Arrival");
            TimeSpan scheduleTimeOfDeparture = GetScheduleTime("Departure");

            Flight flight = new Flight(airlineCode, flightNumber, arrivalStation, departureStation,
                scheduleTimeOfArrival, scheduleTimeOfDeparture);

            _flightRepository.SaveFlight(flight);
            _addFlightScreen.DisplaySuccessfullyAddedFlight();

        }

        private TimeSpan GetScheduleTime(string arrivalOrDepartureScheduleTime)
        {
            string scheduleTime;
            bool parse;

            do
            {
                scheduleTime = _addFlightScreen.AskForScheduleTimeAndGetInput(arrivalOrDepartureScheduleTime);
                parse = _flightValidator.ValidateTimeFormat(scheduleTime);
            } while (!parse);
            return TimeSpan.Parse(scheduleTime);
        }
    }
}
