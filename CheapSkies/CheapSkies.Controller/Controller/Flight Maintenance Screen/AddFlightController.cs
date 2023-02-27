using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.Model.ViewModel;
using CheapSkies.View;

namespace CheapSkies.Controller.Controller
{
    public class AddFlightController
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

        private string GetAirlineCode()
        {
            string airlineCode;
            bool parse;

            do
            {
                airlineCode = _addFlightScreen.AskForAirlineCodeAndGetInput();
                parse = _flightValidator.ValidateAirlineCode(airlineCode);
                if(parse == false)
                {
                    _addFlightScreen.DisplayInvalidAirlineCodeMessage();
                }
            } while (!parse);

            return airlineCode;
        }

        private int GetFlightNumber()
        {
            string flightNumber;
            bool parse;

            do
            {
                flightNumber = _addFlightScreen.AskForFlightNumberAndGetInput();
                parse = _flightValidator.ValidateFlightNumber(flightNumber);
                if (parse == false)
                {
                    _addFlightScreen.DisplayInvalidFlightNumberMessage();
                }
            } while (!parse);

            return Int32.Parse(flightNumber);
        }

        private string GetStation(string arrivalOrDepartureStation)
        {
            string station;
            bool parse;

            do
            {
                station = _addFlightScreen.AskForStationAndGetInput(arrivalOrDepartureStation);
                parse = _flightValidator.ValidateStation(station);
            } while (!parse);
            return station;
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
